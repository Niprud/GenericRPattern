using GenRepositoryPattern.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GenRepositoryPattern.DAL
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext() : base("EmployeeConnection") { }
       
        public DbSet<Employee> Employees { get; set; }
    }
}