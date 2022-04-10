# Vueling Crud with DB

## Statement
Generate CRUD with SQL Queries, Stored procedures, EntityFramework Code first and Entity Framework Database First.<br>
Create a layered application with Wcf service to perform the above operations.

## Implementation

1. [WebServices](https://github.com/davidjimenez92/VuelingCrudDB/tree/master/VuelingCrudDB.Distributed.WebServices) is a wcf service from which the solution is executed. In this layer we load the autofac modules defined in lower layers and perform the dependency injection. In the contracts folder we include interface segregation by splitting the interface [IStudentWebService](https://github.com/davidjimenez92/VuelingCrudDB/blob/master/VuelingCrudDB.Distributed.WebServices/Contracts/IStudentWebService.cs) into other interfaces([IAdd](https://github.com/davidjimenez92/VuelingCrudDB/blob/master/VuelingCrudDB.Distributed.WebServices/Contracts/IAdd.cs), [IRead](https://github.com/davidjimenez92/VuelingCrudDB/blob/master/VuelingCrudDB.Distributed.WebServices/Contracts/IRead.cs), [IUpdate](https://github.com/davidjimenez92/VuelingCrudDB/blob/master/VuelingCrudDB.Distributed.WebServices/Contracts/IUpdate.cs), [IDelete](https://github.com/davidjimenez92/VuelingCrudDB/blob/master/VuelingCrudDB.Distributed.WebServices/Contracts/IDelete.cs)).
2. [Services](https://github.com/davidjimenez92/VuelingCrudDB/tree/master/VuelingCrudDB.Application.Services) a library in which an autofac module is created to inject the lower layer so that the upper layer has access to it. As in the upper layer, a segregation of interfaces is also performed.<br>
The function of this layer is to perform all operations related to business rules and send them to the lower layer.
3. [Entities](https://github.com/davidjimenez92/VuelingCrudDB/tree/master/VuelingCrudDB.Domain.Entities) This layer contains the entities of our application.
4. [Repositories](https://github.com/davidjimenez92/VuelingCrudDB/tree/master/VuelingCrudDB.Infrastructure.Repositories) Here I define the methods to connect to the database. In this case, as there are several ways to connect, I define an abstract factoria that I will show next in the [UML diagrams section](#abstract-factory-diagram). As in all layers where there are interfaces, interface segregation is also implemented.
5. [CrossCutting](https://github.com/davidjimenez92/VuelingCrudDB/tree/master/VuelingCrudDB.CrossCutting.ProjectSettings)this layer is created to strongly type the configuration variables of the app.config to encapsulate all configuration properties.

## Abstract Factory Diagram
![abstract factory diagram](https://github.com/davidjimenez92/VuelingCrudDB/blob/master/abstract-factory.png)

## Architecture Diagram
![architecture diagram](https://github.com/davidjimenez92/VuelingCrudDB/blob/master/architecture-diagram.png)

## Technology stack
`Visual Studio 2022 Comunity Edition | C# | .NET Framework 4.8`

## Libraries 
### Distribured Web Services 
1. `Autofac 6.3.0`
2. `Autofac.Wcf 6.0.0` 
3. `Autofac.log4net 6.0.1`
4. `log4net 2.0.14`
### Application Services
1. `Autofac 6.3.0`
### Domain Entities
1. `EntityFramework 6.4.4`
2. `EntityFramework.SqlServer 6.4.4 `
### Infrastructure Repositories
1. `EntityFramework 6.4.4`