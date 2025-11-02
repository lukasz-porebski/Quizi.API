using System.Net;
using Common.Application.Exceptions;
using Common.Domain.Exceptions;
using Common.Domain.Specification;
using Common.Host.Utils;
using Common.Shared.Exceptions;
using Common.Shared.Providers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Common.Host.Middlewares;

public class ErrorHandlerMiddleware(ILogger<ErrorHandlerMiddleware> logger, IMessageProvider messageProvider) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception exception)
        {
            logger.LogError(exception,
                "Unhandled exception: {Message}. Method: {RequestMethod}, Path: {RequestPath}, StatusCode: {StatusCode}",
                exception.Message,
                context.Request.Method,
                context.Request.Path.Value,
                context.Response.StatusCode);

            await HandleErrorAsync(context, exception);
        }
    }

    private Task HandleErrorAsync(HttpContext context, Exception exception)
    {
        var statusCode = HttpStatusCode.InternalServerError;
        var message = exception.Message;

        switch (exception)
        {
            case SpecificationException _:
            case DomainLogicException _:
            case BusinessLogicException _:
                statusCode = HttpStatusCode.BadRequest;
                message = GetExceptionMessage((exception as BaseException)!);
                break;
        }

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;

        return context.Response.WriteAsync(message);
    }

    private string GetExceptionMessage(BaseException exception)
    {
        var errors = exception.Messages.Select(message =>
        {
            var dirtyMessage = messageProvider.GetMessage(message.Code);
            return new ErrorResponse(message.Code, string.Format(dirtyMessage, args: message.Parameters ?? []));
        }).ToArray();
        return Serializer.ToJson(errors);
    }

    private record ErrorResponse(string Code, string Message);
}