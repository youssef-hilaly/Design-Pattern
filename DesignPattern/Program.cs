using DesignPattern.Creational.AbstractFactory;
using DesignPattern.Creational.Builder;
using DesignPattern.Creational.Factory;
using DesignPattern.Creational.Prototype;
using DesignPattern.Creational.Singleton;
using DesignPattern.Structural.Adapter;
using DesignPattern.Structural.Decorator;
using DesignPattern.Structural.Proxy;
using System.Diagnostics.Metrics;

namespace DesignPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Creational

            //Singleton.test();
            //Prototype.test();
            //Builder.test();
            //Factory.test();
            //AbstructFactory.test();


            // Structural
            //Proxy.test();
            //Decorator.test();
            Adapter.test();


            Console.ReadKey();
        }
    }
}
