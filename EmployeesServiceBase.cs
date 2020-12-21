//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;

namespace EmployeeManager.BusinessLayer
{
    /// <summary>
    /// Defines methods and properties utilized by all data services accessing the
    /// Employees data source.
    /// </summary>
    public abstract partial class EmployeesServiceBase : IEmployeesService
    {
        
        /*
        /// <summary>
        /// Constructs a new instance of
        /// <see
        ///     cref="T:EmployeeManager.BusinessLayer.EmployeesServiceBase" />
        /// and returns a reference to it.
        /// </summary>
        protected EmployeesServiceBase()
        {
            DoInitialize();
        }
        
        /// <summary>
        /// Constructs a new instance of
        /// <see
        ///     cref="T:EmployeeManager.BusinessLayer.EmployeesServiceBase" />
        /// and returns a reference to it.
        /// </summary>
        /// <param name="connectionString">
        /// String containing information to be utilized in
        /// making a connection to the specific data source needed.
        /// </param>
        protected EmployeesServiceBase(string connectionString)
        {
            DoInitialize(connectionString);
        }
        
        /// <summary>
        /// Constructs a new instance of
        /// <see
        ///     cref="T:EmployeeManager.BusinessLayer.EmployeesServiceBase" />
        /// and returns a reference to it.
        /// </summary>
        /// <param name="unitOfWorkObject">
        /// Reference to an instance of an already-instantiated unit of work objec that can
        /// be utilized to access the data source.
        /// </param>
        protected EmployeesServiceBase(IEmployees unitOfWorkObject)
        {
            DoInitialize(unitOfWorkObject);
        }
        */
        
        /// <summary>
        /// Gets or sets a reference to the object that implements
        /// <see
        ///     cref="T:EmployeeManager.BusinessLayer.IEmployeesUnitOfWork" />
        /// being used to serve requests.
        /// </summary>
        public IEmployeesUnitOfWork UnitOfWork { get; set; }
        
        /// <summary>
        /// Performs cleanup when this object is removed from memory by the garbage
        /// collector.
        /// </summary>
        ~EmployeesServiceBase()
        {
            CleanupUnitOfWork();
        }
        
        /// <summary>
        /// Performs cleanup of the underlying unit-of-work object.
        /// </summary>
        private void CleanupUnitOfWork()
        {
            UnitOfWork?.Dispose();
            UnitOfWork = null;
        }
        
        /// <summary>
        /// Initializes the underlying connection to the data source.  Callers can
        /// optionally pass a data source connection string or other key in the
        /// <paramref name="connectionString" /> parameter.
        /// </summary>
        /// <param name="connectionString">
        /// String containing information to be utilized in
        /// making a connection to the specific data source needed.
        /// </param>
        /// <remarks>
        /// If the <paramref name="connectionString" /> parameter is an empty string
        /// or whitespace, then the default connection to the data source, as configured
        /// in App.config, is utilized.  Otherwise, the connection string passed is
        /// sent to the underlying unit-of-work object.
        /// </remarks>
        // ReSharper disable once MemberCanBeProtected.Global
        public virtual void DoInitialize(
            string connectionString = "")
        {
            CleanupUnitOfWork();
        
            UnitOfWork = string.IsNullOrWhiteSpace(connectionString)
                ? new EmployeesUnitOfWork()
                : new EmployeesUnitOfWork(connectionString);
        }
        
        /// <summary>
        /// Initializes the underlying connection to the data source.  Callers can
        /// optionally pass a data source connection string or other key in the
        /// <paramref name="connectionString" /> parameter.
        /// </summary>
        /// <param name="connectionString">
        /// String containing information to be utilized in
        /// making a connection to the specific data source needed.
        /// </param>
        /// <remarks>
        /// If the <paramref name="connectionString" /> parameter is an empty string
        /// or whitespace, then the default connection to the data source, as configured
        /// in App.config, is utilized.  Otherwise, the connection string passed is
        /// sent to the underlying unit-of-work object.
        /// </remarks>
        // ReSharper disable once MemberCanBeProtected.Global
        public virtual void DoInitialize(
            IEmployeesUnitOfWork unitOfWorkObject)
        {
            CleanupUnitOfWork();
        
            UnitOfWork = unitOfWorkObject;
        }
        
        /// <summary>
        /// Raised when an error occurs.
        /// </summary>
        public event Action<Exception> ExceptionRaised;
        
        /// <summary>Raises the<see
        ///     cref="E:EmployeeManager.BusinessLayer.EmployeesServiceBase.ExceptionRaised" />
        /// event.</summary>
        /// <param name="ex">A <see cref="T:System.Exception" /> that provides
        /// information on the error that occurred.</param>
        protected virtual void OnExceptionRaised(Exception ex) => ExceptionRaised?.Invoke(ex);
        
        /// <summary>Raised when changes have been successfully saved to the data source.  This event's handler will be passed an integer specifying the number of rows affected by the Save operation.</summary>
        /// <remarks>Subscribe to this event to receive a notification that a Save operation has completed successfully.</remarks>
        public event Action<int> ChangesSaved;
        
        /// <summary>Raises the<see
        ///     cref="E:EmployeeManager.BusinessLayer.EmployeesServiceBase.ChangesSaved" />
        /// event.</summary>
        /// <param name="rowsAffected">(Required.) Integer that specifies the total number of rows affected by the Save operation.</param>
        protected virtual void OnChangesSaved(int rowsAffected) => ChangesSaved?.Invoke(rowsAffected);
        
        /// <summary>Saves changes made to the data source.</summary>
        /// <returns>Number of records affected by the Save operation; -1 if an 
        /// error occurred.</returns>
        /// <remarks>This method will automatically attempt a graceful closure of the handle to the underlying data source in the case that the return value is -1.  If the underlying unit of work has not been initialized, or the database is offline, this method also returns -1.</remarks>
        public int Save()
        {
            if (!EmployeesConnectionTester.IsDatabaseOnline())
            {
                return -1;
            }
            
            if (UnitOfWork == null) return -1;	// unit of work not initialized
            
            var result = -1;
        
            try
            {
                result = UnitOfWork.Save();
        
                // Notify event subscribers that changes have been saved successfully.
                OnChangesSaved(result);
            }
            catch(Exception ex)
            {
                OnExceptionRaised(ex);
        
                result = -1;
            }
            
            return result;
        }
        
        /// <summary>
        /// Gets a value that indicates whether there are changes pending to be
        /// saved to the underlying data source.
        /// </summary>
        public bool HasChanges => UnitOfWork != null && UnitOfWork.HasChanges;
        
    }
}
