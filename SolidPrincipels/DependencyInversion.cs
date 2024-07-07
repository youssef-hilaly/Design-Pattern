using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrincipels
{
    // Dependency Inversion Principle
    // High-level modules should not depend on low-level modules. Both should depend on abstractions

    // violation of Dependency Inversion Principle
    internal class EmployeeDataAccess
    {
        public List<Employee> GetEmployees()
        {
            // get employees from database
            return new List<Employee>();
        }
    }

    internal class EmployeeBusinessLogic
    {
        private EmployeeDataAccess _dataAccess;

        public EmployeeBusinessLogic()
        {
            _dataAccess = new EmployeeDataAccess();
        }

        public List<Employee> GetEmployees()
        {
            return _dataAccess.GetEmployees();
        }
    }

    // Solution
    internal interface IEmployeeDataAccess
    {
        List<Employee> GetEmployees();
    }

    internal class EmployeeDataAccessNew : IEmployeeDataAccess
    {
        public List<Employee> GetEmployees()
        {
            // get employees from database
            return new List<Employee>();
        }
    }

    internal class EmployeeBusinessLogicNew
    {
        private IEmployeeDataAccess _dataAccess;

        public EmployeeBusinessLogicNew(IEmployeeDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public List<Employee> GetEmployees()
        {
            return _dataAccess.GetEmployees();
        }
    }
}
