# Pharmagest

Focused to a scalable solution designed to add future enhancements (new services and views). I prioritized architectural design over error handling and exception management.

One significant limitation is .NET Framework 4.6, which restricts compatibility with some NuGet packages and deprecated components. Instead, I preferred to built some feautures from scratch and use pure WPF without any third party package.

## Project Structure

The solution is divided into several layers and modules focusing on maintainability:

- **Pharmagest.Db**  
  Manages database operations using Dapper.

- **Pharmagest.Dto**  
  Contains the system's Data Transfer Objects (DTOs).

- **Pharmagest.Entity**  
  Defines the database entities, representing the physical database tables.

- **Pharmagest.Interface**  
  Hosts all interfaces for Inversion of Control (IoC) and Dependency Injection (DI).

- **Pharmagest.Message**  
  Includes messages that can be published or subscribed (see `Pharmagest.ObserverManager`).

- **Pharmagest.Model**  
  Encapsulates the system's available services.

- **Pharmagest.ObserverManager**  
  Implements the Observer pattern. Since compatible NuGet packages were unavailable, I used a custom implementation I had developed in the past as a personal exercise.

- **Pharmagest.WebClient**  
  Provides web service integrations (SOAP or REST). I noticied REST didn't work at all testing by myself with Swagger

- **Pharmagest.WPF**  
  Contains the views and view models, with dependencies injected from the model layer via DI.

- **Pharmagest.Main**  
  The main application project. It uses Autofac for IoC and DI. In addition, it assembling the `MainWindow` with its associated ViewModels and Views through XAML and Autofac.




  
