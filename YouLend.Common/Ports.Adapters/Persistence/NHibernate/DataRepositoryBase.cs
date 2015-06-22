using NHibernate;
using YouLend.Common.Ports.Adapters.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouLend.Common.Ports.Adapters.Persistence.NHibernate
{
 public abstract class DataRepositoryBase<T> : IDataRepository<T>
                 where T : class
    {
        #region Private Members
        /// <summary>
        /// A variable to hold the NHibernate session object
        /// </summary>
        private ISession session;

      

        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="DataContext"/> class. It injects the the <see cref="QueryTranslator"/> class, 
        /// from the <see cref="DataAccessInfrastructure"/> library, into itself to break the dependency.
        /// </summary>
        public DataRepositoryBase()  
        {
            this.session = SessionHelper.GetNewSession();
        }

        #endregion

        /// <summary>
        /// Gets a value indicating whether there are any objects that require persisting to the data store.
        /// </summary>
        public bool IsDirty
        {
            get
            {
                return this.session.IsDirty();
            }
        }

        #region Public Methods
        /// <summary>
        /// Gets a value indicating whether the data context is currently in a transaction
        /// </summary>
        public bool IsInTransaction
        {
            get
            {
                return this.session.Transaction != null && this.session.Transaction.IsActive;
            }
        }

        /// <summary>
        /// Gets all objects of the type T which are classes and are not abstract
        /// </summary>
        /// <typeparam name="T">The type of the object to get from the data store</typeparam>
        /// <returns>A list of objects of type T</returns>
        public IList<T> GetAll()
        {
            return this.GetAll(0, 0);
        }

        /// <summary>
        /// Gets all objects of the type T which are classes and are not abstract. It limits the objects returned based on the 
        /// page size and gets the objects starting from the value in page index
        /// </summary>
        /// <typeparam name="T">The type of the object to get from the data store</typeparam>
        /// <param name="pageIndex">The page (row) in the database to start retrieving data from</param>
        /// <param name="pageSize">The amount of data (rows) to retrieve in one chunk</param>
        /// <returns>A list of objects of type T</returns>
        public IList<T> GetAll(int pageIndex, int pageSize)
        {
            try
            {
                var query = this.session.Query<T>();

                if (pageSize > 0)
                {
                    query = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);
                }

                return query.ToList();
            }
            catch(Exception ex)
            {
                int a = 1;

                return new List<T>();
            }
            
        }

        protected IList<T> GetByCriteria<T>(Expression<Func<T, bool>> query) where T : class, new()
        {
            return GetByCriteria<T>(query, 0, 0);
        }

        protected IList<T> GetByCriteria<T>(Expression<Func<T, bool>> query, int pageIndex, int pageSize) where T : class, new()
        {
            try
            {
                var nHibernateQuery = session.Query<T>().Where(query);

                if (pageSize > 0)
                {
                    nHibernateQuery = nHibernateQuery.Skip((pageIndex - 1) * pageSize).Take(pageSize);
                }
                return nHibernateQuery.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        

        /// <summary>
        /// Gets an object of type T based on the id passed in and where the objects are classes and are not abstract.
        /// </summary>
        /// <typeparam name="T">The type of the object to get from the data store</typeparam>
        /// <param name="id">The id of the object to retrieve</param>
        /// <returns>An object of type T</returns>
        public T GetById(object id)
        {
            return this.session.Get<T>(id);
        }

        /// <summary>
        /// Gets a count of the number of objects of type T there are 
        /// </summary>
        /// <typeparam name="T">The type of the object to get from the data store</typeparam>
        /// <returns>An integer representing the count of objects</returns>
        public int GetCount()
        {
            var nhibernateQuery = this.session.Query<T>();

            return nhibernateQuery.Count();
        }

       

        /// <summary>
        /// Adds an object to the data store
        /// </summary>
        /// <param name="item">An object to add to the data store.</param>
        public void Add(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }

            this.session.Save(item);

            if (!this.IsInTransaction)
            {
                this.session.Flush();
            }
        }

        /// <summary>
        /// Deletes an object from the data store
        /// </summary>
        /// <param name="item">An object to delete from the data store</param>
        public void Delete(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }

            this.session.Delete(item);

            if (!this.IsInTransaction)
            {
                this.session.Flush();
            }
        }

        /// <summary>
        /// Updates an object in the data store
        /// </summary>
        /// <param name="item">An object to update in the data store</param>
        public void Save(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }

            this.session.Update(item);

            if (!this.IsInTransaction)
            {
                this.session.Flush();
            }
        }

        

        /// <summary>
        /// Logic to be run when the data context is disposed of in memory
        /// </summary>
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        #endregion
    }

}
