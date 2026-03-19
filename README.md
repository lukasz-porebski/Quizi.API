<div align="center">

# 🎯 Quizi

### Aplikacja internetowa do przeprowadzania quizów

[![.NET](https://img.shields.io/badge/.NET-10-512BD4?style=flat&logo=dotnet)](https://dotnet.microsoft.com/)
[![PostgreSQL](https://img.shields.io/badge/PostgreSQL-Database-336791?style=flat&logo=postgresql)](https://www.postgresql.org/)

</div>

---

## 📑 Spis treści

- [🏗️ Architektura i wzorce](#️-architektura-i-wzorce)
- [⚙️ Technologie](#️-technologie)
- [🛠️ Narzędzia](#️-narzędzia)
- [✨ Dostępne funkcje](#-dostępne-funkcje)
- [🚀 Planowane funkcje](#-planowane-funkcje)

---

## 🏗️ Architektura i wzorce

Aplikacja jest **modularnym monolitem** zbudowanym w oparciu o sprawdzone wzorce projektowe:

- 🧅 **Onion Architecture** - separacja warstw i zależności
- 🎨 **Domain-Driven Design (DDD)** - modelowanie domeny biznesowej
- 🔀 **Command Query Responsibility Segregation (CQRS)** - rozdzielenie operacji odczytu i zapisu

---

## ⚙️ Technologie

### Backend & Framework
- 🟣 **.NET 10** - środowisko uruchomieniowe
- 📨 **MediatR** - implementacja CQRS
  - 💾 **Entity Framework Core** - ORM (przetwarzanie komend)
  - ⚡ **Dapper** - odczyt danych z bazy (przetwarzania zapytań)

### Testing
- ✅ **xUnit** - framework do testów jednostkowych
  - 🔍 **Fluent Assertions** - asercje
  - 🎭 **Moq** - mocki
  - 🎲 **AutoFixture** - dane testowe

### Pozostałe
- 📝 **Serilog** - logowanie błędów
- 🗺️ **AutoMapper** - mapowanie obiektów
- 📚 **Swagger** - dokumentacja API
- 🏗️ **Autofac** - kontener dependency injection

---

## 🛠️ Narzędzia

| Kategoria | Narzędzie |
|-----------|-----------|
| 💻 IDE | **JetBrains Rider** |
| 🗄️ Zarządzanie bazą | **Database Tools and SQL** (plugin do Ridera) |
| 🐘 Baza danych | **PostgreSQL** |
| 🌿 System kontroli wersji | **Git** |

---

## ✨ Dostępne funkcje

- ✅ Lista quizów
- ➕ Dodawanie quizu
- ✏️ Edytowanie quizu
- 🗑️ Usuwanie quizu
- ▶️ Uruchamianie quizu
- 📊 Historia wyników quizów
- 👥 Lista użytkowników
- 👁️ Podgląd quizu

---

## 🚀 Planowane funkcje

- 🔗 Dzielenie się quizami
- 📈 Statystyki quizów