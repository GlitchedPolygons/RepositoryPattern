
namespace GlitchedPolygons.RepositoryPattern
{
    /// <summary>
    /// Uniquely identifiable entity inside a repository.
    /// </summary>
    public interface IEntity<T>
    {
        /// <summary>
        /// Gets or sets the entity's unique identifier.
        /// </summary>
        /// <value>The entity's unique id.</value>
        T Id { get; set; }
    }
}
