using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Open_Close_Principle
{
    // Open Close Principle
    // The class should be open for extension but closed for modification


    // If we need to add a new type of employee, we will violate the Open Close Principle
    internal class Employee
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public string EmployeeType { get; set; }

        public decimal CalculateBonus(decimal salary)
        {
            if (EmployeeType == "Manager")
            {
                return salary * 0.1M * 2;
            }
            return salary * 0.1M;
        }
    }

    // Solution
    // abstract class solution
    internal abstract class EmployeeBase
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public abstract decimal CalculateBonus(decimal salary);
    }

    internal class Manager : EmployeeBase
    {
        public override decimal CalculateBonus(decimal salary)
        {
            return salary * 0.1M * 2;
        }
    }

    internal class Developer : EmployeeBase
    {
        public override decimal CalculateBonus(decimal salary)
        {
            return salary * 0.1M;
        }
    }


    // interface solution
    internal interface IEmployee
    {
        string ID { get; set; }
        string Name { get; set; }
        decimal Salary { get; set; }
        decimal CalculateBonus(decimal salary);
    }

    internal class Manager2 : IEmployee
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }

        public decimal CalculateBonus(decimal salary)
        {
            return salary * 0.1M * 2;
        }
    }

}
