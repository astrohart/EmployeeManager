//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.ComponentModel;
using System.Data.Entity;
using EmployeeManager.Data;

namespace EmployeeManager.BusinessLayer
{
    /// <summary>
    /// Provides access to the entities of type <typeparamref name="TEntity"/> in the data source.
    /// </summary>
    /// <typeparam name="TEntity">Type of the POCO representing the entity to be accessed.</typeparam>
    public abstract partial class EmployeesRepository<TEntity> : IEmployeesRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Reference to an instance of an object that provides access to the data set.
        /// </summary>
        private readonly DbSet<TEntity> _dataset;
        
        /// <summary>
        /// Constructs a new instance of
        /// <see cref="T:EmployeeManager.BusinessLayer.EmployeesRepository" /> and
        /// returns a reference to it.
        /// </summary>
        /// <param name="context">
        /// A
        /// <see cref="T:EmployeeManager.Data.EmployeesEntities" />
        /// that provides access to the underlying data source.
        /// </param>
        protected EmployeesRepository(EmployeesEntities context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));
        
            _dataset = context.Set<TEntity>();
        }
        
        /// <summary>
        /// Gets all records available in the data source.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerable{T}" /> that
        /// allows access to the set of all records in the data source.
        /// </returns>
        public IBindingList GetAll()
        {
            _dataset.Load();
            return _dataset.Local.ToBindingList();
        }
        
        public TEntity GetById(int id)
        {
            return _dataset.Find(id);
        }
        
        public void Add(TEntity entity)
        {
            _dataset.Add(entity);
        }
        
        /// <summary>
        /// Deletes the record referred to by <paramref name="entity"/> from the dataset.
        /// </summary>
        /// <param name="entity">Reference to an instance of an entity object identifying the record to be removed.</param>
        public void Delete(TEntity entity)
        {
            if (entity == null) return;
            _dataset.Remove(entity);
        }
    }
}

