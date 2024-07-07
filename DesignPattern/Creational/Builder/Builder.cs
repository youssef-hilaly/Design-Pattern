using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Creational.Builder
{
    public interface IBuilder
    {
        void StartUpOperations();
        void BuildBody();
        void InsertWheels();
        void AddHeadlight();
        void EndOperations();
        Product GetVehicle();
    }

    public class Product
    {
        public LinkedList<string> parts;
        public Product()
        {
            parts = new LinkedList<string>();
        }
        public void Add(string part)
        {
            parts.AddLast(part);
        }
        public string Show()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Product Components are:");
            foreach (string part in parts)
            {
                sb.AppendLine(part);
            }
            return sb.ToString();
        }
    }

    public class Car: IBuilder
    {
        private string BrandName;
        private Product Product;
        public Car(string brand)
        {
            Product = new Product();
            BrandName = brand;
        }

        public void StartUpOperations()
        {
            Product.Add($"Car Model name: {BrandName}");
        }

        public void BuildBody()
        {
            Product.Add($"Add Body");
        }

        public void InsertWheels()
        {
            Product.Add($"Add Wheels");
        }

        public void AddHeadlight()
        {
            Product.Add($"Add Headlight");
        }

        public void EndOperations()
        {
            Product.Add($"End Operations");
        }

        public Product GetVehicle()
        {
            return Product;
        }
    }

    public class Director
    {
        IBuilder _builder;

        public void Construct(IBuilder builder)
        {
            _builder = builder;
            _builder.StartUpOperations();
            _builder.BuildBody();
            _builder.InsertWheels();
            _builder.AddHeadlight();
            _builder.EndOperations();
        }
    }


    internal class Builder
    {
        public static void test()
        {
            IBuilder carBuilder = new Car("Honda");

            Director director = new Director();
            director.Construct(carBuilder);

            Product car = carBuilder.GetVehicle();
            Console.WriteLine(car.Show());
        }
    }
}
