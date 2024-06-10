Specyfikacja techniczna


Link do repozytorum na githubie
https://github.com/DudMichal/ContactApp
Zad1.
DataContext.cs

Kod definiuje kontekst bazy danych aplikacji za pomocą frameworka Entity Framework Core.
Służy on do interakcji z bazą danych za pomocą obiektów. Klasa DataContext dziedziczy po DbContext z Entity Framework, jest podstawową klasą odpowiedzialną za interakcje z bazą danych.

Contact.cs

Klasa reprezentuje dane kontaktu w aplikacji, z różnymi właściwościami opisującymi ten kontakt, takimi jak imię, nazwisko, e-mail, numer telefonu, kategoria 

ContactsController.cs

Jest to kontroler obsługujący operacje CRUD. Umożliwia pobieranie wszystkich kontaktów lub pojedynczego kontaktu, dodawanie nowych kontaktów, aktualizację istniejących kontaktów oraz usuwanie kontaktów. Korzysta z kontekstu bazy danych i modelu kontaktu.

Program.cs

Ten kod jest konfiguratorem aplikacji ASP.NET Core, który tworzy i konfiguruje serwer, dodaje potrzebne usługi, konfiguruje middleware, oraz uruchamia aplikację.

Seeder.cs

Kod definiuje klasę Seeder, która jest odpowiedzialna za wypełnienie bazy danych przykładowymi danymi.


Wykorzystane biblioteki:

Microsoft.EntityFrameworkCore - Zarządzanie bazą danych i kontekstem.
ASP.NET Core MVC - Tworzenie kontrolerów i zarządzanie routingiem.
Dependency Injection - Zarządzanie usługami i zależnościami.
Swagger/OpenAPI - Generowanie dokumentacji API.

Można by było uzyć biblioteki JWt

Do części fronted wykorzystano angulara

Sposób kompilacji aplikacji:

Sklonować repozytorium z githuba.
git clone [link z repozytoruim]
Uruchomienie API.
Dodać na server backup bazy danych zamieszczony w katalogu
Otworzyć solucje w VisualStudio 2022 i sprawdzić połączenie z bazą danych 
odpalić Seedera do wypełnienia bazy przykładowymi danymi
Uruchomienie Warstwy Forntendowej
otworzyć projekt w Visual Studio Code
w pliku contact.service.ts sprawdzić czy nasze Api odpala się na tym samym porcie jak nie to zmienić na prawidłowy.
