using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Structural.Adapter
{

    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double BasicSalary { get; set; }
    }

    class SalaryCalculator
    {
        public double CalcSalary(Employee employee) => employee.BasicSalary * 1.5;
    }

    class MachineOperator
    {
        public int Id { get; set; }
        public int MachineCode { get; set; }
        public string Name { get; set; }
        public double BasicSalary { get; set; }
    } 
    class SalaryAdapter: SalaryCalculator
    {
        Employee _employee;
        public double CalcSalary(MachineOperator machineOperator)
        {
            _employee = new Employee { BasicSalary = machineOperator.BasicSalary };
            return base.CalcSalary(_employee);
        } 
    }
    internal class Adapter
    {
        public static void test()
        {
            MachineOperator machineOperator = new MachineOperator ();
            machineOperator.BasicSalary = 1200;

            SalaryAdapter calculator = new SalaryAdapter ();
            var salary= calculator.CalcSalary(machineOperator);
            Console.WriteLine(salary.ToString());
        }

    }
}
