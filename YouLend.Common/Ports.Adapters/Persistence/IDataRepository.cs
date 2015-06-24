using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouLend.Common.Ports.Adapters.Persistence
{
    public interface IDataRepository
    {
    }

    public interface IDataRepository<T> : IDataRepository
                     where T : class
    {
        /// <summary>
        /// Gets a value indicating whether data context contains any changes which must be synchronized with the database
        /// </summary>
        bool IsDirty { get; }

        /// <summary>
        /// Retrieves all the persisted instances of a given type
        /// </summary>
        /// <typeparam name="T">The type of the object to retrieve</typeparam>
        /// <returns>The list of persistent objects</returns>
        IList<T> GetAll();

        /// <summary>
        /// Retrieves all the persisted instances of a given type
        /// </summary>
        /// <typeparam name="T">The type of the object to retrieve</typeparam>
        /// <param name="pageIndex">The index of the page to retrieve</param>
        /// <param name="pageSize">The size of the page to retrieve</param>
        /// <returns>The list of persistent objects</returns>
        IList<T> GetAll(int pageIndex, int pageSize);

        /// <summary>
        /// Return the persistent instance of the given entity class with the given identifier, or null if there is no such persistent instance.
        /// </summary>
        /// <typeparam name="T">The type of the object</typeparam>
        /// <param name="id">The identifier of the object</param>
        /// <returns>The persistent instance or null</returns>
        T GetById(object id);

        /// <summary>
        /// Returns the amount of objects of a given type
        /// </summary>
        /// <typeparam name="T">The type of the object</typeparam>
        /// <returns>The amount of objects</returns>
        int GetCount();
        
        /// <summary>
        /// Adds an object to the repository
        /// </summary>
        /// <param name="item">The object to add</param>
        void Add(T item);

        /// <summary>
        /// Deletes an object from the repository
        /// </summary>
        /// <param name="item">The object to delete</param>
        void Delete(T item);

        /// <summary>
        /// Saves an object to the repository
        /// </summary>
        /// <param name="item">The object to save</param>
        void Save(T item);
    }
}
