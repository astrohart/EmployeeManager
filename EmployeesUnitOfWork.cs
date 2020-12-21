//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data;
using EmployeeManager.Data;

namespace EmployeeManager.BusinessLayer
{
    /// <summary>
    /// Implements a unit of work that manages data access to the Employees
    /// data source.
    /// </summary>
    public partial class EmployeesUnitOfWork : IEmployeesUnitOfWork
    {
        /// <summary>
        /// Constructs a new instance of
        /// <see
        ///     cref="T:EmployeeManager.BusinessLayer.EmployeesUnitOfWork" />
        /// and returns a reference to it.
        /// </summary>
        /// <param name="context">
        /// Reference to an instance of
        /// <see cref="T:EmployeeManager.BusinessLayer.EmployeesEntities" />
        /// that provides access to the underlying data source.
        /// </param>
        /// <remarks>
        /// This constructor initializes the
        /// <see
        ///     cref="P:EmployeeManager.BusinessLayer.EmployeesUnitOfWork.Context" />
        /// property with the reference provided in the <paramref name="context" />
        /// parameter.
        /// </remarks>
        public EmployeesUnitOfWork(EmployeesEntities context)
        {
            Context = context ??
                        throw new ArgumentNullException(nameof(context));
        }
        
        /// <summary>
        /// Constructs a new instance of
        /// <see
        ///     cref="T:EmployeeManager.BusinessLayer.EmployeesUnitOfWork" />
        /// and returns a reference to it.
        /// </summary>
        /// <param name="connectionString">
        /// String containing the connection string to be utilized
        /// in order to access the underlying data source.
        /// </param>
        /// <remarks>
        /// This constructor attempts to connect to the data source using the connection
        /// string provided in the <paramref name="connectionString"/> parameter.
        /// </remarks>
        public EmployeesUnitOfWork(string connectionString)
        {
            OnCreateContext(connectionString);
        }
        
        /// <summary>
        /// Constructs a new instance of
        /// <see
        ///     cref="T:EmployeeManager.BusinessLayer.EmployeesUnitOfWork" />
        /// and returns a reference to it.
        /// </summary>
        /// <remarks>
        /// This constructor creates a new context object using its default constructor.
        /// The context object provides access to the data source.
        /// The
        /// <see
        ///     cref="P:EmployeeManager.BusinessLayer.EmployeesUnitOfWork.Context" />
        /// property is assigned the reference to the newly-created context instance as its
        /// value by this constructor.
        /// </remarks>
        public EmployeesUnitOfWork()
        {
            OnCreateContext();
        }
            
        
        /// <summary>
        /// Gets a reference to an instance of an object that implements
        /// <see cref="T:EmployeeManager.BusinessLayer.IEmployeeTypeRepository"/> and
        /// which accesses the data in the EmployeeTypes table
        /// of the data source.
        /// </summary>
        public IEmployeeTypeRepository EmployeeTypes
                => new EmployeeTypeRepository(Context);
            
        /// <summary>
        /// Gets a reference to an instance of an object that implements
        /// <see cref="T:EmployeeManager.BusinessLayer.IEmployeeRepository"/> and
        /// which accesses the data in the Employees table
        /// of the data source.
        /// </summary>
        public IEmployeeRepository Employees
                => new EmployeeRepository(Context);
            
        /// <summary>
        /// Gets a reference to the synchronization root object for thread locking.
        /// </summary>
        protected object SyncRoot { get; } = new object();
        
        /// <summary>
        /// Saves changes made to the data source.
        /// </summary>
        /// <returns>Number of records affected by the Save operation; -1 if an 
        /// error occurred.</returns>
        /// <remarks>This method will automatically attempt a graceful closure 
        /// of the handle to the underlying data source in the case that the return
        // value is -1.</remarks>
        public int Save()
        {
            if (Context == null) return -1;
            
            var result = -1;
        
            try
            {
                lock(SyncRoot)
                {
                    result = Context.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                OnExceptionRaised(ex);
        
                result = -1;
            }
            finally
            {
                if (result == -1)
                    GracefullyCloseDatabase();
            }
            
            return result;
        }
        
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing,
        /// or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        
        /// <summary>
        /// Gets a reference to the data context object.
        /// </summary>
        public EmployeesEntities Context { get; private set; }
        
        /// <summary>
        /// Gets a string containing the connection string (or the configuraton-file section name)
        /// that was used to create this instance.
        /// </summary>
        public string ConnectionString => Context.Database.Connection.ConnectionString;
        
        /// <summary>
        /// Safely disposes of this object, releasing all associated resources.
        /// </summary>
        /// <param name="disposing">
        /// True if this object is disposed deterministically;
        /// Set to false if this method is being called by a finalizer.
        /// </param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposing) return;
            if (Context == null) return;
            Context.Dispose();
            Context = null;
        }
        
        protected void GracefullyCloseDatabase()
        {
            if (Context == null) return;
        
            try
            {
                if (Context.Database.Connection.State != ConnectionState.Closed)
                {
                    Context.Database.Connection.Close();
                    Context.Dispose();
                    Context = null;
                }
            }
            catch
            {
                // Ignored.
            }
        }
        
        /// <summary>
        /// Sets up the data context and initializes the database connection.  Checks
        /// whether the underlying database is available.
        /// </summary>
        /// <returns>True if succeeded; false otherwise.</returns>
        /// <remarks>
        /// This method should be called prior to any actual database operations
        /// for each unit of work.  The reasoning being that this method also ensures
        /// the connection to the underlying database is intact prior to actually
        /// allowing the context to be utilized.
        /// </remarks>
        protected virtual bool OnCreateContext()
        {
            if (!EmployeesConnectionTester
                .IsDatabaseOnline())
                {
                    OnDatabaseNotAvailable();
                    return false;
                }
        
            // Check if already connected
            if (Context != null) return true;
        
            var result = true;
        
            try
            {
                Context = new EmployeesEntities();
            }
            catch(Exception ex)
            {
                OnExceptionRaised(ex);
        
                result = false;
            }
            finally
            {
                if (!result)
                    GracefullyCloseDatabase();
            }
        
            if (result)
                OnDatabaseConnected();
        
            return result;
        }
        
        /// <summary>
        /// Sets up the data context and initializes the database connection.  Checks
        /// whether the underlying database is available.
        /// </summary>
        /// <param name="connectionString">String containing the connection string 
        /// to use to access the data source.  Must not be blank.</param>
        /// <returns>True if succeeded; false otherwise.</returns>
        /// <remarks>
        /// This method should be called prior to any actual database operations
        /// for each unit of work.  The reasoning being that this method also ensures 
        /// the connection to the underlying database is intact prior to actually 
        /// allowing the context to be utilized.
        /// </remarks>
        protected virtual bool OnCreateContext(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                return false;
        
            if (!EmployeesConnectionTester
                .IsDatabaseOnline())
                {
                    OnDatabaseNotAvailable();
                    return false;
                }
        
            // Check if already connected
            if (Context != null) return true;
        
            var result = true;
        
            try
            {
                Context = new EmployeesEntities(connectionString);
            }
            catch(Exception ex)
            {
                OnExceptionRaised(ex);
        
                result = false;
            }
            finally
            {
                if (!result)
                    GracefullyCloseDatabase();
            }
        
            if (result)
                OnDatabaseConnected();
        
            return result;
        }
        
        /// <summary>
        /// Raised when the connection to the data source is successful.
        /// </summary>
        public event EventHandler DatabaseConnected;
        
        /// <summary>
        /// Raises the
        /// <see
        ///     cref="E:EmployeeManager.BusinessLayer.EmployeesUnitOfWork.DatabaseConnected" />
        /// event.
        /// </summary>
        protected virtual void OnDatabaseConnected()
        {
            if (DatabaseConnected == null) return;
            DatabaseConnected(this, EventArgs.Empty);
        }
        
        /// <summary>
        /// Raised when a connection cannot be successfully established 
        /// to the underlying data store. 
        /// </summary>
        public event EventHandler DatabaseNotAvailable;
        
        /// <summary>
        /// Raises the
        /// <see
        ///     cref="E:EmployeeManager.BusinessLayer.EmployeesUnitOfWork.DatabaseNotAvailable" />
        /// event.
        /// </summary>
        protected virtual void OnDatabaseNotAvailable()
        {
            if (DatabaseNotAvailable == null) return;
            DatabaseNotAvailable(this, EventArgs.Empty);
        }
        
        /// <summary>
        /// Raised when an error occurs.
        /// </summary>
        public event Action<Exception> ExceptionRaised;
        
        /// <summary>
        /// Raises the
        /// <see
        ///     cref="E:EmployeeManager.BusinessLayer.EmployeesUnitOfWork.ExceptionRaised" />
        /// event.
        /// </summary>
        /// <param name="ex">
        /// A <see cref="T:System.Exception" /> containing information
        /// about the exception that occurred.
        /// </param>
        protected virtual void OnExceptionRaised(Exception ex)
        {
            if (ExceptionRaised == null) return;
            ExceptionRaised(ex);
        }
        
        /// <summary>
        /// Gets a value that indicates whether there are changes pending to be
        /// saved to the underlying data source.
        /// </summary>
        public bool HasChanges => Context != null && Context.ChangeTracker.HasChanges();
    }
}