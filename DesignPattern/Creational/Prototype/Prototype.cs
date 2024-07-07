using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Creational.Prototype
{
    internal abstract class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }

        // reference type objects will have a pointer pointing to the original object
        public abstract Employee ShallowClone();
        public abstract Employee DeepClone();

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Address: {Address.ToString()}";
        }
    }

    internal class TempEmployee : Employee
    {
        public override Employee ShallowClone()
        {
            return (TempEmployee) MemberwiseClone();
        }
        public override Employee DeepClone()
        {
            TempEmployee emp = new TempEmployee();
            emp = (TempEmployee) MemberwiseClone();

            emp.Address = new Address
            {
                City = Address.City,
                State = Address.State,
            };
            emp.Name = Name; // why? it is reference type

            return emp;
        }
    }

    internal class RegularEmployee : Employee
    {
        public override Employee ShallowClone()
        {
            return (RegularEmployee)MemberwiseClone();
        }
        public override Employee DeepClone()
        {
            RegularEmployee emp = new RegularEmployee();
            emp = (RegularEmployee)MemberwiseClone();

            emp.Address = new Address
            {
                City = Address.City,
                State = Address.State,
            };
            emp.Name = Name; // why?

            return emp;
        }
    }

    internal class Address
    {
        public string City { get; set; }
        public string State { get; set; }

        public override string ToString()
        {
            return $"City: {City}, State: {State}";
        }
    }

    internal class Prototype
    {
        public static void test()
        {
            Console.WriteLine("ShallowClone");
            Employee emp = new TempEmployee();
            emp.Id = 1;
            emp.Name = "name";
            emp.Address = new Address
            {
                City = "City",
                State = "State"
            };


            Employee emp2 = emp.ShallowClone();
            emp2.Name = "ShallowName";
            emp2.Address.State = "ShallowCity";

            Console.WriteLine(emp.ToString());
            Console.WriteLine(emp2.ToString());




            Console.WriteLine("DeepClone");
            Employee emp3 = new TempEmployee();
            emp3.Id = 1;
            emp3.Name = "name";
            emp3.Address = new Address
            {
                City = "City",
                State = "State"
            };

            Employee emp4 = emp3.DeepClone();
            emp4.Name = "DeepName";
            emp4.Address.State = "DeepCity";

            Console.WriteLine(emp3.ToString());
            Console.WriteLine(emp4.ToString());

        }
    }
}
