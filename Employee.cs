//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EmployeeManager.Data
{
    using System;
    using EmployeeManager.DataBinding;
    
    public partial class Employee
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int EmployeeTypeId { get; set; }
    
        public virtual EmployeeType EmployeeType { get; set; }
    }
}
