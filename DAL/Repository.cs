using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Linq.Expressions;
using System.Data.Entity;
using System.Configuration;


namespace DAL
{

        // Define interfaces

        /// <summary>
        /// Generic interface
        /// </summary>
        /// <typeparam name="T">Type of entity</typeparam>
        public interface IDataRepository<T> where T : class
        {
            IQueryable<T> GetAll();
            void Insert(T entity);
            void Update(T entity);
            void Delete(T entity);
            IQueryable<T> GetBySpecificKey(string KeyName, string KeyVal);
            IQueryable<T> GetBySpecificKey(string KeyName, int KeyVal);
        }

        /// <summary>
        /// Generic interface
        /// </summary>
        public interface IDataRepository
        {
            IQueryable GetAll();
            void Insert(object entity);
            void Update(object entity);
            void Delete(object entity);
            IQueryable GetBySpecificKey(string KeyName, string KeyVal);
            IQueryable GetBySpecificKey(string KeyName, int KeyVal);
        }




    // here is the repository class
    public class DataRepository<T> : IDataRepository<T>, IDataRepository where T : class
    {

        /// <summary>
        /// Data Context object to interact with the db
        /// </summary>
        readonly DbContext _dataContext;

        /// <summary>
        /// Public constructor
        /// </summary>
        public DataRepository()
        {
            //instantiate the datacontext by reading the connection string
            _dataContext = new DbContext(ConfigurationManager.ConnectionStrings["worthingtonEntities"].ConnectionString);
            // DbSet = _dataContext.Set<T>();
        }

        // INSERT ********************************************************
        void IDataRepository.Insert(object entity)
        {
            Insert((T)entity);
        }

        public virtual void Insert(T entity)
        {
            _dataContext.Set<T>().Add(entity);
            // DbSet.Add(entity);
            _dataContext.SaveChanges();
        }
        // ****************************************************************

        // DELETE *********************************************************
        void IDataRepository.Delete(object entity)
        {
            Delete((T)entity);
        }

        /*
        public virtual void Delete(T entity)
        {
            var entry = _dataContext.Entry(entity);
            if (entry != null)
            {
                entry.State = System.Data.EntityState.Deleted;
            }
            else
            {
                _dataContext.Set<T>().Attach(entity);
            }
            _dataContext.Entry(entity).State = System.Data.EntityState.Deleted;
            _dataContext.SaveChanges();

        }
         */

        public virtual void Delete(T entity)
        {
            _dataContext.Set<T>().Remove(entity);
            // DbSet.Remove(entity);
            _dataContext.SaveChanges();
        }
        // ****************************************************************

        // GET ALL ********************************************************
        IQueryable IDataRepository.GetAll()
        {
            return GetAll();
        }

        public virtual IQueryable<T> GetAll()
        {
            return _dataContext.Set<T>().AsQueryable();
            // return DbSet.AsQueryable();
        }
        // ****************************************************************

        // UPDATE *********************************************************
        void IDataRepository.Update(object entity)
        {
            Update((T)entity);
        }

        public virtual void Update(T entity)
        {
            _dataContext.Set<T>().Attach(entity);
            // DbSet.Attach(entity);
            _dataContext.Entry(entity).State = System.Data.EntityState.Modified;
            _dataContext.SaveChanges();
        }
        // ****************************************************************

        // GET BY SPECIFIC KEY ********************************************
        IQueryable IDataRepository.GetBySpecificKey(string KeyName, int KeyVal)
        {
            return GetBySpecificKey(KeyName, KeyVal);
        }

        public virtual IQueryable<T> GetBySpecificKey(string KeyName, int KeyVal)
        {

            var itemParameter = Expression.Parameter(typeof(T), "item");
            var whereExpression = Expression.Lambda<Func<T, bool>>
                (
                Expression.Equal(
                    Expression.Property(
                        itemParameter,
                       KeyName
                        ),
                    Expression.Constant(KeyVal)
                    ),
                new[] { itemParameter }
                );
            try
            {
                return GetAll().Where(whereExpression).AsQueryable();
            }
            catch
            {
                return null;
            }

        }



        IQueryable IDataRepository.GetBySpecificKey(string KeyName, string KeyVal)
        {
            return GetBySpecificKey(KeyName, KeyVal);
        }

        public virtual IQueryable<T> GetBySpecificKey(string KeyName, string KeyVal)
        {

            var itemParameter = Expression.Parameter(typeof(T), "item");
            var whereExpression = Expression.Lambda<Func<T, bool>>
                (
                Expression.Equal(
                    Expression.Property(
                        itemParameter,
                       KeyName
                        ),
                    Expression.Constant(KeyVal)
                    ),
                new[] { itemParameter }
                );
            try
            {
                return GetAll().Where(whereExpression).AsQueryable();
            }
            catch
            {
                return null;
            }

        }
        // ****************************************************************

    }

}
