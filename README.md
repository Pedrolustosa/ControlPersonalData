  # ControlPersonalData
  [![License](https://img.shields.io/badge/License-MIT-blue.svg)](https://opensource.org/licenses/MIT)
  [![Version](https://img.shields.io/badge/Version-1.6-brightgreen)](https://github.com/seu-usuario/seu-projeto)
  ![Project Views](https://komarev.com/ghpvc/?username=seu-usuario&label=Project%20Views&color=brightgreen)

  ## Tecnologias Utilizadas (Technologies Used)
  <table>
    <tr>
      <td>Linguagem (Language):</td>
      <td>
        <img src="https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white">
        <img src="https://img.shields.io/badge/JSON-5E5C5C?style=for-the-badge&logo=json&logoColor=white">
      </td>
    </tr>
    <tr>
      <td>Plataforma (Platform):</td>
      <td><img src="https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white"></td>
    </tr>
    <tr>
      <td>Arquitetura (Architecture):</td>
      <td><img src="https://img.shields.io/badge/Clean-brightgreen?style=for-the-badge"></td>
    </tr>
    <tr>
      <td>Documentação (Documentation):</td>
      <td><img src="https://img.shields.io/badge/Swagger-85EA2D?style=for-the-badge&logo=Swagger&logoColor=white"></td>
    </tr>
    <tr>
      <td>Autenticação e Autorização (Authentication and Authorization):</td>
      <td>
        <img src="https://img.shields.io/badge/Identity-333333?style=for-the-badge&logo=identity&logoColor=white">
        <img src="https://img.shields.io/badge/JWT-000000?style=for-the-badge&logo=JSON%20web%20tokens&logoColor=white">
      </td>
    </tr>
    <tr>
      <td>Banco de Dados (Database):</td>
      <td>
        <img src="https://img.shields.io/badge/Microsoft%20SQL%20Server-CC2927?style=for-the-badge&logo=microsoft%20sql%20server&logoColor=white">
        <img src="https://img.shields.io/badge/InMemory-blue?style=for-the-badge&logoColor=white">
      </td>
    </tr>
    <tr>
      <td>Tipo de API (API Type):</td>
      <td><img src="https://img.shields.io/badge/REST%20API-009688?style=for-the-badge"></td>
    </tr>
    <tr>
      <td>Metodologia (Methodology):</td>
      <td><img src="https://img.shields.io/badge/DDD-FF5733?style=for-the-badge"></td>
    </tr>
    <tr>
      <td>Gerenciamento de Pacotes (Package Management):</td>
      <td><img src="https://img.shields.io/badge/NuGet-004880?style=for-the-badge&logo=nuget&logoColor=white"></td>
    </tr>
    <tr>
      <td>IDE (Integrated Development Environment):</td>
      <td><img src="https://img.shields.io/badge/Visual_Studio-5C2D91?style=for-the-badge&logo=visual%20studio&logoColor=white"></td>
    </tr>
    <tr>
      <td>Controle de Versão (Version Control):</td>
      <td><img src="https://img.shields.io/badge/GIT-E44C30?style=for-the-badge&logo=git&logoColor=white"></td>
    </tr>
    <tr>
      <td>SO (Operating System):</td>
      <td><img src="https://img.shields.io/badge/Windows_11-0078d4?style=for-the-badge&logo=windows-11&logoColor=white"></td>
    </tr>
    <tr>
      <td>Testes Unitários (Unit Tests)</td>
      <td>
        <img src="https://img.shields.io/badge/FakeItEasy-green?style=for-the-badge">
        <img src="https://img.shields.io/badge/FluentAssertions-yellow?style=for-the-badge">
        <img src="https://img.shields.io/badge/xUnit-red?style=for-the-badge">
      </td>
    </tr>
  </table>
  

  ## Description
  The User Data Control System is an application that allows efficient and secure management of user information. It offers various features to facilitate data management, making it a powerful solution for companies and organizations that need to control   user information in an organized and accessible manner.

  ## Key Features
  - User Registration: Administrators can add new users to the system, providing essential information such as name, last name, email address, phone number, etc.
  - User Authentication: To make any modifications to the data, logging in is required, ensuring the security of the information.
  - Data Search: Users can search for specific information in the database, allowing quick and precise retrieval of desired information.
  - Advanced Filtering: The system provides advanced filtering options to refine search results, such as registration dates, user categories, etc.
  - Data Update: Administrators can update user information, ensuring that the data remains accurate.
  - PDF Generation: A powerful feature is the ability to generate reports in PDF format containing user data, making it easy to share and print important information.

  ## Getting Started
  - To begin using the User Data Control System, follow these steps:
  - Clone the repository or download the project.
  - Install the necessary dependencies using [Insert dependency installation instructions].
  - Configure the database with the appropriate information.
  - Start the application server using [Insert startup command].
  - Access the system in your web browser and begin exploring the features.

  ## Clean Architecture
  Clean architecture is a concept proposed by Robert C. Martin in his book "Clean Architecture" as a way to build highly flexible and sustainable software solutions. The concept is based on best practices of hexagonal and onion architecture, among 
  others, which already proposed the separation of responsibilities in layers and aims to produce systems with the following characteristics:
  - Independent of framework
  - Testable
  - Independent of the user interface
  - Independent of the database
  - Independent of any external agent

  ### About Clean Architecture and Its Responsibilities
  - Domain:
    This layer is responsible for all your entities, enumerations, exceptions, abstractions (such as interfaces), types, and domain-specific logic.
  - Application:
    This layer is responsible for all the application's logic. It depends on the domain layer but has no dependencies on any other layer or project. This layer describes abstractions that are implemented in outer layers.
    If you need to implement data access, such as using Entity Framework, the implementation would be located outside this layer (in infrastructure), but the abstraction would be implemented here.
  - Infrastructure:
    This layer is responsible for containing classes that access resources external to our application, such as web services, emails, or even file access. These classes should implement abstractions from the application layer.
  - User Interface (UI):
    This layer is responsible for the user interface. In this project's case, we have a simple example using Angular 8 and ASP.NET Core 3. This layer depends on the application and infrastructure layers, but any dependency coming from the infrastructure 
    is only for dependency injection.

  ## Projects
  - ControlPersonalData.API: Controllers, Models
  - ControlPersonalData.Application: Application domain rules, mappings, services, DTOs
  - ControlPersonalData.Domain: Domain model, business rules, and interfaces
  - ControlPersonalData.Infra.Data: EF Core, Context, Configurations, Migrations, and Repository
  - ControlPersonalData.Infra.IoC: Dependency injection, service registrations
  - ControlPersonalData.Tests: Unit test

  ## Relationships and Dependencies between Projects
  - ControlPersonalData.Domain: Has no dependencies
  - ControlPersonalData.Application: Dependency on the Domain
  - ControlPersonalData.Infra.Data: Dependency on the Domain
  - ControlPersonalData.Infra.IoC: Dependency on the Domain, Application, and Infra.Data
  - ControlPersonalData.API: Dependency on Infra.IoC
  - ControlPersonalData.Tests: Dependency on Infra.Data and Domain
