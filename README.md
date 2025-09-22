# Quizi
Aplikacja internetowa do przeprowadzania quizów.

## Spis treści
- [Architektura i wzorce](#architektura-i-wzorce)
- [Technologie](#technologie)
- [Narzędzia](#narzędzia)
- [Dostępne funkcje](#dostępne-funkcje)
- [Planowane funkcje](#planowane-funkcje)

## Architektura i wzorce
Aplikacja jest modularnym monolitem. Zbudowana jest w oparciu o
- Onion Architecture
- Domain-Driven Design (DDD)
- Command Query Responsibility Segregation (CQRS)

## Technologie
* Środowisko uruchomieniowe - **.NET 9**
* CQRS - **MediatR**
    - ORM (przetwarzanie komend) - **Entity Framework Core**
    - Odczyt danych z bazy (przetwarzania zapytań) - **Dapper**
* Testy jednostkowe - **xUnit**
    * Asercje - **Fluent Assertions**   
    * Mocki - **Moq**
    * Dane testowe - **AutoFixture**
* Logowanie błędów - **Serilog** 
* Mapowanie obiektów - **AutoMapper**
* Dokumentacja API - **Swagger**
* Kontener dependency injection - **Autofac**

## Narzędzia
* IDE - **Rider**
* Zarządzanie bazą - **SQL Server Management Studio**
* Baza danych - **SQL Server Express LocalDB**
* System kontroli wersji - **Git**
  
## Dostępne funkcje
- Lista quizów
- Dodawanie quizu
- Edytowanie quizu
- Usuwanie quizu
- Uruchamianie quizu

## Planowane funkcje
- Podgląd quizów
- Dzielenie się quizami
- Statystyki quizów
- Historia wyników quizów
