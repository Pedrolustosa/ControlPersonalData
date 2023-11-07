  # ControlPersonalData
  [![License](https://img.shields.io/badge/License-MIT-blue.svg)](https://opensource.org/licenses/MIT)
  [![Version](https://img.shields.io/badge/Version-1.0-brightgreen)](https://github.com/seu-usuario/seu-projeto)
  [![In Development](https://img.shields.io/badge/Status-In%20Development-yellow)](https://github.com/seu-usuario/seu-projeto)
  ![Project Views](https://komarev.com/ghpvc/?username=seu-usuario&label=Project%20Views&color=brightgreen)

  ## Tecnologias Utilizadas (Technologies Used)

  <table>
    <tr>
      <td>Linguagem (Language):</td>
      <td><img src="https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white"></td>
      <td><img src="https://img.shields.io/badge/JSON-5E5C5C?style=for-the-badge&logo=json&logoColor=white"></td>
    </tr>
    <tr>
      <td>Plataforma (Platform):</td>
      <td><img src="https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white"></td>
    </tr>
    <tr>
      <td>Autenticação (Authentication):</td>
      <td><img src="https://img.shields.io/badge/JWT-000000?style=for-the-badge&logo=JSON%20web%20tokens&logoColor=white"></td>
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
      <td><img src="https://img.shields.io/badge/Identity-333333?style=for-the-badge&logo=identity&logoColor=white"></td>
    </tr>
    <tr>
      <td>Banco de Dados (Database):</td>
      <td><img src="https://img.shields.io/badge/Microsoft%20SQL%20Server-CC2927?style=for-the-badge&logo=microsoft%20sql%20server&logoColor=white"></td>
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
  </table>
  
<details>
  <summary><strong><a href="#versao-em-portugues">Versão em Português</a></strong></summary>
  <h2 id="versao-em-portugues">Versão em Português</h2>

  ## Arquitetura Limpa
  Arquitetura limpa é um conceito proposto por Robert C. Martin, em seu livro "Clean Architecture", como uma forma de construir soluções de software altamente flexíveis e sustentáveis. O conceito é baseado em boas práticas de arquitetura hexagonal e cebola, entre outras, que já propunham a separação de responsabilidades em camadas e tem como objetivo produzir sistemas com as seguintes características:

  - Independente de framework
  - Testáveis
  - Independentes da interface do usuário
  - Independentes do banco de dados
  - Independentes de qualquer agente externo
    
### Sobre Clean Architecture e suas responsabilidades
- Domínio (Domain)
  Essa camada é responsável por todas as suas entidades, enumerações, exceções, abstrações (interfaces por exemplo), tipos e lógicas específicas ao seu domínio.

- Aplicação (Application)
  Essa camada é responsável por toda lógica da sua aplicação. Ela depende da camada de domínio mas não tem dependência com nenhuma outra camada ou projeto. Essa camada descreve abstrações que são implementadas nas camadas de fora.
  Se por acaso você precisar implementar um acesso a dados, por exemplo o Entity Framework, essa implementação ficaria fora dessa camada (em infraestrutura), porém a abstração seria implementada aqui.

- Infraestrutura (Infrastructure)
  Essa camada é responsável por conter classes que acessem recursos externos a nossa aplicação, como por exemplo web services, emails ou até mesmo acesso a disco. Essas classes devem implementar abstrações da camada de aplicação.

-  Interface de Usuário (UI)
   Essa camada é responsável pela interface de usuário, no caso desse projeto temos um exemplo simples utilizando Angular 8 e ASP.NET Core 3. Essa camada depende da aplicação e infraestrutura porém toda dependência que vier de infraestrutura é apenas para consumir injeção de dependências.

  ## Projetos
  - ControlPersonalData.API: Controllers, Models
  - ControlPersonalData.Application: Regras de domínio da aplicação, mapeamentos, serviços, DTOs
  - ControlPersonalData.Domain: Modelo de domínio, regras de negócio e interfaces
  - ControlPersonalData.Infra.Data: EF Core, Contexto, Configurações, Migrations e Repositório
  - ControlPersonalData.Infra.IoC: Injeção de dependência, registros dos serviços

  ## Relacionamento e Dependências entre Projetos
  - ControlPersonalData.Domain: Não possui nenhuma dependência
  - ControlPersonalData.Application: Dependência com o Domain
  - ControlPersonalData.Infra.Data: Dependência com o Domain
  - ControlPersonalData.Infra.IoC: Dependência com o Domain, Application e Infra.Data
  - ControlPersonalData.API: Dependência com o Infra.IoC
</details>

<details>
  <summary><strong><a href="#english-version">English Version</a></strong></summary>
  <h2 id="english-version">English Version</h2>

  ## Clean Architecture
  Clean architecture is a concept proposed by Robert C. Martin in his book "Clean Architecture" as a way to build highly flexible and sustainable software solutions. The concept is based on best practices of hexagonal and onion architecture, among others, which already proposed the separation of responsibilities in layers and aims to produce systems with the following characteristics:

  - Independent of framework
  - Testable
  - Independent of the user interface
  - Independent of the database
  - Independent of any external agent

### About Clean Architecture and Its Responsibilities
- Domain
  This layer is responsible for all your entities, enumerations, exceptions, abstractions (such as interfaces), types, and domain-specific logic.

- Application
  This layer is responsible for all the application's logic. It depends on the domain layer but has no dependencies on any other layer or project. This layer describes abstractions that are implemented in outer layers.
  If you need to implement data access, such as using Entity Framework, the implementation would be located outside this layer (in infrastructure), but the abstraction would be implemented here.

- Infrastructure
  This layer is responsible for containing classes that access resources external to our application, such as web services, emails, or even file access. These classes should implement abstractions from the application layer.

- User Interface (UI)
  This layer is responsible for the user interface. In this project's case, we have a simple example using Angular 8 and ASP.NET Core 3. This layer depends on the application and infrastructure layers, but any dependency coming from the infrastructure is only for dependency injection.

  ## Projects
  - ControlPersonalData.API: Controllers, Models
  - ControlPersonalData.Application: Application domain rules, mappings, services, DTOs
  - ControlPersonalData.Domain: Domain model, business rules, and interfaces
  - ControlPersonalData.Infra.Data: EF Core, Context, Configurations, Migrations, and Repository
  - ControlPersonalData.Infra.IoC: Dependency injection, service registrations

  ## Relationships and Dependencies between Projects
  - ControlPersonalData.Domain: Has no dependencies
  - ControlPersonalData.Application: Dependency on the Domain
  - ControlPersonalData.Infra.Data: Dependency on the Domain
  - ControlPersonalData.Infra.IoC: Dependency on the Domain, Application, and Infra.Data
  - ControlPersonalData.API: Dependency on Infra.IoC
</details>

