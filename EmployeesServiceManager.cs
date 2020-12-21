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
    /// Manages all the data services for the 
    /// Employees data source as a group.
    /// </summary>
    public partial class EmployeesServiceManager
    {
        /// <summary>
        /// Empty, static constructor to prohibit direct allocation of this class.
        /// </summary>
        static EmployeesServiceManager() { }
        
        /// <summary>
        /// Empty, protected constructor to prohibit direct allocation of this class.
        /// </summary>
        protected EmployeesServiceManager() { }
        
        /// <summary>Gets a reference to the one and only instance of <see cref="T:EmployeeManager.BusinessLayer.EmployeesServiceManager" />.</summary>
        public static EmployeesServiceManager Instance { get; } =
            new EmployeesServiceManager();
        
        /// <summary>Installs a <see cref="T:System.EventHandler" /> delegate to be attached to the <see cref="E:EmployeeManager.BusinessLayer.EmployeesServiceBase.ExceptionRaised" /> event for each of the data service objects managed by this object.</summary>
        /// <param name="exceptionRaisedEventHandler">(Optional.) A <see cref="T:System.EventHandler" /> delegate to be attached to the
        /// <see cref="E:EmployeeManager.BusinessLayer.EmployeesServiceBase.ExceptionRaised" /> event for each of the data service objects managed by this object.</param>
        private void InstallExceptionRaisedEventHandler(
            Action<Exception> exceptionRaisedEventHandler = null)
        {
            if (exceptionRaisedEventHandler == null) return;
            
            EmployeeTypeService.Instance.ExceptionRaised -= 
                exceptionRaisedEventHandler;
            EmployeeTypeService.Instance.ExceptionRaised += 
                exceptionRaisedEventHandler;
            
            EmployeeService.Instance.ExceptionRaised -= 
                exceptionRaisedEventHandler;
            EmployeeService.Instance.ExceptionRaised += 
                exceptionRaisedEventHandler;
            
        }
        
        /// <summary>Installs a <see cref="T:System.Action{System.Int32}" /> delegate to be attached to the
        /// <see
        ///     cref="E:EmployeeManager.BusinessLayer.EmployeesServiceBase.ChangesSaved" />
        /// event for each of the data service objects managed by this object.</summary>
        /// <param name="changesSavedEventHandler">(Optional.) <see cref="T:System.Action{System.Int32}" /> delegate to be attached to the
        /// <see
        ///     cref="E:EmployeeManager.BusinessLayer.EmployeesServiceBase.ChangesSaved" />
        /// event for each of the data service objects managed by this object.</param>
        private void InstallChangesSavedEventHandler(
            Action<int> changesSavedEventHandler = null)
        {
            if (changesSavedEventHandler == null) return;
            
            EmployeeTypeService.Instance.ChangesSaved -= 
                changesSavedEventHandler;
            EmployeeTypeService.Instance.ChangesSaved += 
                changesSavedEventHandler;
            
            EmployeeService.Instance.ChangesSaved -= 
                changesSavedEventHandler;
            EmployeeService.Instance.ChangesSaved += 
                changesSavedEventHandler;
            
        }
        
        /// <summary>Saves all pending changes to the underlying data source.</summary>
        /// <returns>Total number of rows affected across all transactions; or -1 if an error occurred.  If an error occurs, the offending service will raise an event that contains the exception information.</returns>
        public int SaveAll()
        {
            // ReSharper disable once TooWideLocalVariableScope
            var totalRowsAffected = 0;
            var rowsAffectedByCurrentSave = 0;
            
            try
            {
                rowsAffectedByCurrentSave = EmployeeTypeService.Instance.Save();
                if (rowsAffectedByCurrentSave > 0)
                    totalRowsAffected += rowsAffectedByCurrentSave;
                    
                rowsAffectedByCurrentSave = EmployeeService.Instance.Save();
                if (rowsAffectedByCurrentSave > 0)
                    totalRowsAffected += rowsAffectedByCurrentSave;
                    
            }
            catch(Exception)
            {
                totalRowsAffected = -1;
            }
            
            return totalRowsAffected;
            
        }
        
        
        /// <summary>
        /// Initializes all data services using the default underlying data source.
        /// </summary>
        /// <param name="connectionString">
        /// (Optional.) If supplied, is the connection string to utilize to connect
        /// to the underlying data source.  If no value is supplied for this parameter,
        /// the default data source as configured in App.config is utilized.
        /// </param>
        /// <param name="exceptionRaisedEventHandler">
        /// (Optional.) If specified, reference to a method that serves as a handler for
        /// exceptions raised by any one of the services.
        /// </param>
        public void InitializeAll(string connectionString = "",
            Action<Exception> exceptionRaisedEventHandler = null)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                EmployeeTypeService.Instance.DoInitialize();
                EmployeeService.Instance.DoInitialize();
            }
            else
            {
                EmployeeTypeService.Instance.DoInitialize(connectionString);
                EmployeeService.Instance.DoInitialize(connectionString);
            }
            
            InstallExceptionRaisedEventHandler(exceptionRaisedEventHandler);
        }
        
        /// <summary>
        /// Initializes all data services using the connection to the underlying data source provided by the unit-of-work object referenced by <paramref name="unitOfWorkObject" />.
        /// </summary>
        /// <param name="unitOfWorkObject">
        /// Reference to an instance of an object that implements
        /// <see
        ///     cref="T:EmployeeManager.BusinessLayer.IEmployeesUnitOfWork" />
        /// having the proper connection to the underlying data source.
        /// </param>
        /// <param name="exceptionRaisedEventHandler">
        /// (Optional.) If specified, reference to a method that serves as a handler for
        /// exceptions raised by any one of the services.
        /// </param>
        public void InitializeAll(IEmployeesUnitOfWork unitOfWorkObject,
            Action<Exception> exceptionRaisedEventHandler = null)
        {
            EmployeeTypeService.Instance.DoInitialize(unitOfWorkObject);
            EmployeeService.Instance.DoInitialize(unitOfWorkObject);
            
            InstallExceptionRaisedEventHandler(exceptionRaisedEventHandler);
        }
        
        /// <summary>
        /// Gets a value that indicates whether there are changes pending to be
        /// saved to the underlying data source.
        /// </summary>
        /// <remarks>
        /// This property returns the value of a logical OR operation performed
        /// against all the data services that this class manages.
        /// </remarks>
        public bool HasChanges =>
            EmployeeTypeService.Instance.HasChanges
                || EmployeeService.Instance.HasChanges;
    }
}
