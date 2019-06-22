[![NuGet](https://img.shields.io/nuget/v/GlitchedPolygons.RepositoryPattern.svg)](https://www.nuget.org/packages/GlitchedPolygons.RepositoryPattern)
# The Repository Pattern
---
These are the generic base interfaces needed for implementing a very basic repository pattern inside your C# projects.

Repositories  (`IRepository<T1, in T2>`)  always contain objects that implement `IEntity<T>` (where `T` is the type of unique identifier). Usually, `T` would be something like `string` or `int`...

**Make absolutely sure that your implementation guarantees the uniqueness and immutability of every `IEntity<T>.Id`!**

## Existing implementations

The following are official (or officially tested) implementations:

* SQLite
* * [github.com/GlitchedPolygons/RepositoryPattern.SQLite](https://github.com/GlitchedPolygons/RepositoryPattern.SQLite)
* PostgreSQL
* * [github.com/GlitchedPolygons/RepositoryPattern.Postgres](https://github.com/GlitchedPolygons/RepositoryPattern.Postgres)
* MongoDB
* * [github.com/GlitchedPolygons/RepositoryPattern.MongoDB](https://github.com/GlitchedPolygons/RepositoryPattern.MongoDB)
