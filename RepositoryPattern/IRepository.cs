using System;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace GlitchedPolygons.RepositoryPattern
{
    /// <summary>
    /// Generic repository base interface for holding any type of uniquely identifiable <see cref="IEntity{T}"/>.
    /// Typically used for database access routines.
    /// </summary>
    /// <typeparam name="T1">The type of entity that the repository is going to store.</typeparam>
    /// <typeparam name="T2">The type of unique id that the repository's entities will have (e.g. guid <c>string</c>, <c>int</c>, etc...).</typeparam>
    public interface IRepository<T1, in T2> where T1 : IEntity<T2>
    {
        /// <summary>
        /// Gets the entity of type <typeparamref name="T1"/> with the specified unique identifier (synchronously).
        /// </summary>
        /// <param name="id">The entity's unique identifier.</param>
        /// <returns>The first found entity; <c>null</c> if nothing was found.</returns>
        T1 this[T2 id] { get; }

        /// <summary>
        /// Gets an entity by its unique identifier.
        /// </summary>
        /// <param name="id">The entity's unique identifier.</param>
        /// <returns>The first found <see cref="IEntity{T1}"/>; <c>null</c> if nothing was found.</returns>
        Task<T1> Get(T2 id);

        /// <summary>
        /// Gets all entities from the repository.
        /// </summary>
        /// <returns>All entities inside the repo.</returns>
        Task<IEnumerable<T1>> GetAll();

        /// <summary>
        /// Gets a single entity from the repo according to the specified predicate condition.<para> </para>
        /// If 0 or >1 entities are found, <c>null</c> is returned.
        /// </summary>
        /// <param name="predicate">The search predicate.</param>
        /// <returns>Single found entity; <c>null</c> if 0 or >1 entities were found.</returns>
        Task<T1> SingleOrDefault(Expression<Func<T1, bool>> predicate);

        /// <summary>
        /// Finds all entities according to the specified predicate <see cref="Expression"/>.
        /// </summary>
        /// <param name="predicate">The search predicate (all entities that match the provided conditions will be added to the query's result).</param>
        /// <returns>The found entities (<see cref="IEnumerable{T}"/>).</returns>
        Task<IEnumerable<T1>> Find(Expression<Func<T1, bool>> predicate);

        /// <summary>
        /// Adds the specified entity to the data repository.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <returns>Whether the entity could be added successfully or not.</returns>
        Task<bool> Add(T1 entity);

        /// <summary>
        /// Adds multiple entities at once.
        /// </summary>
        /// <param name="entities">The entities to add.</param>
        /// <returns>Whether the entities were added successfully or not.</returns>
        Task<bool> AddRange(IEnumerable<T1> entities);

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        /// <returns>Whether the entity could be updated successfully or not.</returns>
        Task<bool> Update(T1 entity);

        /// <summary>
        /// Removes the specified entity.
        /// </summary>
        /// <param name="entity">The entity to remove.</param>
        /// <returns>Whether the entity could be removed successfully or not.</returns>
        Task<bool> Remove(T1 entity);

        /// <summary>
        /// Removes the specified entity.
        /// </summary>
        /// <param name="id">The unique id of the entity to remove.</param>
        /// <returns>Whether the entity could be removed successfully or not.</returns>
        Task<bool> Remove(T2 id);

        /// <summary>
        /// Removes all entities at once from the repository.
        /// </summary>
        /// <returns>Whether the entities were removed successfully or not. If the repository was already empty, <c>false</c> is returned (because nothing was actually &lt;&lt;removed&gt;&gt; ).</returns>
        Task<bool> RemoveAll();

        /// <summary>
        /// Removes all entities that match the specified conditions (via the predicate <see cref="Expression"/> parameter).
        /// </summary>
        /// <param name="predicate">The predicate <see cref="Expression"/> that defines which entities should be removed.</param>
        /// <returns>Whether the entities were removed successfully or not.</returns>
        Task<bool> RemoveRange(Expression<Func<T1, bool>> predicate);

        /// <summary>
        /// Removes the range of entities from the repository.
        /// </summary>
        /// <param name="entities">The entities to remove.</param>
        /// <returns>Whether the entities were removed successfully or not.</returns>
        Task<bool> RemoveRange(IEnumerable<T1> entities);

        /// <summary>
        /// Removes the range of entities from the repository.
        /// </summary>
        /// <param name="ids">The unique ids of the entities to remove.</param>
        /// <returns>Whether all entities were removed successfully or not.</returns>
        Task<bool> RemoveRange(IEnumerable<T2> ids);
    }
}
