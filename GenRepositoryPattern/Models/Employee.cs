using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GenRepositoryPattern.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public Department Department { get; set; }
        public Gender Gender { get; set; }
        public bool IsActive { get; set; }
    }
}

public enum Department
{
    Sales,
    Management,
    IT,
    Security
}

public enum Gender
{
    Male,
    Female
}