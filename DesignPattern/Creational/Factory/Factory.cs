using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Creational.Factory
{
    interface IBank
    {
        string Withdrow();
    }

    class BankA : IBank
    {
        public string Withdrow()
        {
            return "Withdrow Bank A";
        }
    }
    class BankB : IBank
    {
        public string Withdrow()
        {
            return "Withdrow Bank B";
        }
    }

    interface IFactory
    {
        IBank Create(string CardNumber);
    }

    class BankFactory: IFactory
    {
        public IBank Create(string CardNumber)
        {
            string bankCode = CardNumber.Substring(0, 4);

            return bankCode switch
            {
                "1234" => new BankA(),
                "1111" => new BankB(),
                _ => throw new Exception("Invalid Card Number"), // or null
            };
        }
    }

    internal class Factory
    {
        public static void test()
        {
            string cardNumber1 = "123456789";
            string cardNumber2 = "111111111";

            IFactory bankFactory = new BankFactory();

            IBank bank1 = bankFactory.Create(cardNumber1);
            Console.WriteLine(bank1.Withdrow());

            IBank bank2 = bankFactory.Create(cardNumber2);
            Console.WriteLine(bank2.Withdrow());
        }
    }
}
