//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using EmployeeManager.Data;

namespace EmployeeManager.BusinessLayer
{
    /// <summary>
    ///     Provides access to data from the Employees table in the data
    ///     source.
    /// </summary>
    public partial class EmployeeRepository : EmployeesRepository<Employee>,
        IEmployeeRepository
    {
        /// <summary>
        ///     Constructs a new instance of
        ///     <see cref="T:EmployeeManager.BusinessLayer.EmployeeRepository" /> and
        ///     returns a reference to it.
        /// </summary>
        public EmployeeRepository(EmployeesEntities context) : base(context)
        {
            // TODO: Add code here to initialize the Employees repository.
        }
        
        // TODO: Add another part of this (partial) class to implement custom functionality.
        
    }
}
