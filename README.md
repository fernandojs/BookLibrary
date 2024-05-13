  
 # Clean Architecture Book Library for testing purpose

This is a solution template for creating a test purpose with ASP.NET MVC and ASP.NET Core following the principles of Clean Architecture. 


## Technologies

* ASP.NET Core 7
* ASP.NET MVC
* Dapper
* [NUnit](https://nunit.org/)
* [Docker](https://www.docker.com/)

## Getting Started

The easiest way to get started is to install the [NuGet package](https://www.nuget.org/packages/Clean.Architecture.Solution.Template) and run `dotnet new ca-sln`:

### Database Configuration

1. Create the Database
2. Create the BOOKS table using the script below:

```
CREATE TABLE [dbo].[books](
	[book_id] [int] IDENTITY(1,1) NOT NULL,
	[title] [varchar](100) NOT NULL,
	[first_name] [varchar](50) NOT NULL,
	[last_name] [varchar](50) NOT NULL,
	[total_copies] [int] NOT NULL,
	[copies_in_use] [int] NOT NULL,
	[type] [varchar](50) NULL,
	[isbn] [varchar](80) NULL,
	[category] [varchar](50) NULL,
	[status] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[book_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[books] ADD  DEFAULT ((0)) FOR [total_copies]
GO

ALTER TABLE [dbo].[books] ADD  DEFAULT ((0)) FOR [copies_in_use]
GO
```

## Overview

### Domain

This will contain all entities, enums, exceptions, interfaces, types and logic specific to the domain layer.

### Application

This layer contains all application logic. It is dependent on the domain layer, but has no dependencies on any other layer or project. This layer defines interfaces that are implemented by outside layers. For example, if the application need to access a notification service, a new interface would be added to application and an implementation would be created within infrastructure.

### Infrastructure

This layer contains classes for accessing external resources such as databases, file systems, web services, smtp, and so on. These classes should be based on interfaces defined within the application layer.

### WebUI

This layer is a single page application based on ASP.NET Core MVC. 

## License

This project is licensed with the [MIT license](LICENSE).
