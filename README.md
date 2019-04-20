# The Repository Pattern
---
These are the generic base interfaces needed for implementing a very basic repository pattern inside your C# projects.

Repositories  (`IRepository<T1, in T2>`)  always contain objects that implement `IEntity<T>` (where `T` is the type of unique identifier). Usually, `T` would be something like `string` or `int`...

**Make absolutely sure that your implementation guarantees the uniqueness and immutability of every `IEntity<T>.Id`!**
