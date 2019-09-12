using GenRepositoryPattern.DAL.Abstract;
using GenRepositoryPattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GenRepositoryPattern.DAL.Repository
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
    }

    public interface IEmployeeRepository : IRepository<Employee> { }
}