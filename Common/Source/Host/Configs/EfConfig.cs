using System.Diagnostics;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using Common.Host.AppSettings;
using Common.Host.AppSettings.Sections;
using Common.Host.Extensions;
using Common.Infrastructure.Database.EF;
using Microsoft.AspNetCore.Builder;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace Common.Host.Configs;

internal static class EfConfig
{
    public static IServiceCollection AddEf<TDbContext>(this IServiceCollection services, IConfiguration configuration)
        where TDbContext : BaseDbContext
    {
        services.AddDbContext<TDbContext>(options =>
        {
            var settings = configuration.GetOptions(BaseAppSettingsSections.Database);
            options.UseSqlServer(settings.ConnectionString);
        });
        return services;
    }

    public static IApplicationBuilder UseAutoMigration<TDbContext>(
        this IApplicationBuilder builder, IConfiguration configuration)
        where TDbContext : BaseDbContext
    {
        using var scope = builder.ApplicationServices.CreateScope();

        try
        {
            Console.WriteLine("✅ Starting app migration initialization...");

            var settings = configuration.GetOptions(BaseAppSettingsSections.Database);
            Test(settings);

            var dbContext = scope.ServiceProvider.GetRequiredService<TDbContext>();

            var delaysSeconds = new[] { 5 };
            for (var i = 0; i < delaysSeconds.Length; i++)
            {
                try
                {
                    dbContext.Database.Migrate();
                    Console.WriteLine("[EF MIGRATION] Success");
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[EF MIGRATION] Attempt {i + 1} failed: {ex.Message}");
                    if (i == delaysSeconds.Length - 1) throw;
                    Thread.Sleep(TimeSpan.FromSeconds(delaysSeconds[i]));
                }
            }

            Console.WriteLine($"End migration initialization");
        }
        catch (Exception e)
        {
            Console.WriteLine(JsonConvert.SerializeObject(e));
        }

        return builder;
    }

    private static void Test(DatabaseSettings settings)
    {
        Console.WriteLine("✅ Settings");
        Console.WriteLine(JsonConvert.SerializeObject(settings));

        Console.WriteLine("=== CLOUD SQL EXTENDED DIAGNOSTICS ===");

// 1. Sprawdź wszystkie zmienne środowiskowe związane z Cloud SQL
        var envVars = new[] { "CLOUDSQL_INSTANCE", "INSTANCE_CONNECTION_NAME", "DB_HOST", "DB_PORT" };
        foreach (var envVar in envVars)
        {
            Console.WriteLine($"{envVar}: {Environment.GetEnvironmentVariable(envVar) ?? "NOT SET"}");
        }

// 2. Sprawdź informacje o instancji Cloud SQL
        var instanceName = Environment.GetEnvironmentVariable("CLOUDSQL_INSTANCE");
        if (!string.IsNullOrEmpty(instanceName))
        {
            Console.WriteLine($"Cloud SQL Instance: {instanceName}");

            // Sprawdź czy socket directory exists
            var socketPath = $"/cloudsql/{instanceName}";
            Console.WriteLine($"Socket path: {socketPath}");
            Console.WriteLine($"Socket directory exists: {Directory.Exists(socketPath)}");

            if (Directory.Exists(socketPath))
            {
                var files = Directory.GetFiles(socketPath);
                Console.WriteLine($"Files in socket directory: {files.Length}");
                foreach (var file in files)
                {
                    Console.WriteLine($"  - {file}");
                }
            }
        }

// 3. Testy dostępności portów
        var portsToTest = new[] { 1433, 5432, 3306 };
        foreach (var port in portsToTest)
        {
            TestPort("localhost", port);
            TestPort("127.0.0.1", port);
        }

// 4. Sprawdź aktywnych połączeń sieciowych
        Console.WriteLine("=== ACTIVE TCP CONNECTIONS ===");
        try
        {
            var properties = IPGlobalProperties.GetIPGlobalProperties();
            var connections = properties.GetActiveTcpConnections();
            Console.WriteLine($"Active TCP connections: {connections.Length}");

            foreach (var conn in connections.Take(10)) // Pierwsze 10
            {
                Console.WriteLine($"  {conn.LocalEndPoint} -> {conn.RemoteEndPoint} : {conn.State}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ TCP connections check failed: {ex.Message}");
        }

// 5. Sprawdź czy możemy rozwiązać localhost
        try
        {
            var hostEntry = Dns.GetHostEntry("localhost");
            Console.WriteLine($"localhost resolves to: {string.Join(", ", hostEntry.AddressList.Select(a => a.ToString()))}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ localhost resolution failed: {ex.Message}");
        }

// 6. Sprawdź procesy nasłuchujące (jeśli dostępne)
        try
        {
            Console.WriteLine("=== NETSTAT (if available) ===");
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "sh",
                    Arguments = "-c \"netstat -tulpn 2>/dev/null | grep LISTEN || echo 'netstat not available'\"",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                }
            };
            process.Start();
            var output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            Console.WriteLine(output);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Netstat check failed: {ex.Message}");
        }

// 7. Sprawdź czy Cloud SQL Proxy process jest uruchomiony
        try
        {
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "sh",
                    Arguments = "-c \"ps aux | grep cloud_sql_proxy || echo 'cloud_sql_proxy not found'\"",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                }
            };
            process.Start();
            var output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            Console.WriteLine("=== CLOUD SQL PROXY PROCESSES ===");
            Console.WriteLine(output);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Process check failed: {ex.Message}");
        }

// 8. Test połączenia z bazą danych z pełnym stack trace
        Console.WriteLine("=== DATABASE CONNECTION TEST ===");
        try
        {
            var connectionString = settings.ConnectionString;
            Console.WriteLine($"Connection string: {connectionString}");

            if (!string.IsNullOrEmpty(connectionString))
            {
                using var connection = new SqlConnection(connectionString);
                connection.Open();
                Console.WriteLine("✅ DATABASE CONNECTION - SUCCESS");

                // Sprawdź wersję SQL Server
                using var command = new SqlCommand("SELECT @@VERSION", connection);
                var version = command.ExecuteScalar();
                Console.WriteLine($"SQL Server version: {version}");
            }
            else
            {
                Console.WriteLine("❌ No connection string found");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ DATABASE CONNECTION - FAILED: {ex.Message}");
            Console.WriteLine($"Stack trace: {ex.StackTrace}");

            // Deep dive into inner exception
            var inner = ex.InnerException;
            while (inner != null)
            {
                Console.WriteLine($"INNER EXCEPTION: {inner.GetType().Name}: {inner.Message}");
                inner = inner.InnerException;
            }
        }

        Console.WriteLine("=== DIAGNOSTICS COMPLETE ===");

        void TestPort(string host, int port)
        {
            try
            {
                using var client = new TcpClient();
                var task = client.ConnectAsync(host, port);
                if (task.Wait(2000))
                {
                    Console.WriteLine($"✅ {host}:{port} - REACHABLE");
                    client.Close();
                }
                else
                {
                    Console.WriteLine($"❌ {host}:{port} - TIMEOUT");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ {host}:{port} - ERROR: {ex.Message}");
            }
        }
    }
}