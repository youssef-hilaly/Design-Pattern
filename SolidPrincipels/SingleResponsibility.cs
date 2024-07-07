using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrincipels
{
    // violation of Single Responsibility Principle class level

    internal class EmployeeService
    {
        public void EmployeeRegitration(Object employee)
        {
            // Emplyees.Add(employee);
            SendEmail(employee.ToString(), "Employee Registration", "Employee has been registered successfully");
        }
        public void SendEmail(string email, string subject, string message)
        {
            // send email logic
        }
    }

    // Single Responsibility Principle
    // The class should have only one reason to change
    internal class Employee
    {
        public void EmployeeRegitration(Object employee)
        {
            // Emplyees.Add(employee);
            new EmailService().SendEmail(employee.ToString(), "Employee Registration", "Employee has been registered successfully");
        }
    }

    internal class EmailService
    {
        public void SendEmail(string email, string subject, string message)
        {
            // send email logic
        }
    }


}
