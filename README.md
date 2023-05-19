# Food Shop
welcom to our site enjoy using it.
## Description and Architecture
The project is written with ASP.NET Core 7.0 The architecture of the project is REST API based, and divided into 3 Layers: Controllers, Bussiness and Data layer. The layers communicate with each other through Dependency Injection, for easier mainining and testabilly. DTO entities were also used, in order to prevent circular dependency between the objects and provide encapsulation. The conversion from entities to DTO object and vice versa was done by AutoMapper. The connection to the database is done using an ORM of EntitiesFramework of Microsoft, DB first.
