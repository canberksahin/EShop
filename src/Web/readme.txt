﻿Application Core types* Entities (business model classes that are persisted)* Interfaces* Services* DTOsInfrastructure types* EF Core types (DbContext, Migration)* Data access implementation types (Repositories)* Infrastructure-specific services (for example, FileLogger or SmtpNotifier)UI layer types* Controllers* Filters* Views* ViewModels* Startup

* Packages

==UI layer types==
Install-Package Microsoft.AspNetCore.IdentityInstall-Package Microsoft.AspNetCore.Identity.EntityFrameworkCoreInstall-Package Microsoft.EntityFrameworkCore.SqlServerInstall-Package Microsoft.EntityFrameworkCore.Tools

==Infrastructure==

==Application Core==