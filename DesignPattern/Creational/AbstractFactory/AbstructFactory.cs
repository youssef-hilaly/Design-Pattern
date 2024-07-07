using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Creational.AbstractFactory
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

    interface IPaymentCard
    {
        string GetName();
    }

    class CardA : IPaymentCard
    {
        public string GetName()
        {
            return "Visa";
        }
    }
    class CardB : IPaymentCard
    {
        public string GetName()
        {
            return "MasterCard";
        }
    }

    interface IFactory
    {
        IBank GetBank(string CardNumber);

        IPaymentCard GetPaymentCard(string CardNumber);
    }

    class BankFactory : IFactory
    {
        public IBank GetBank(string CardNumber)
        {
            string bankCode = CardNumber.Substring(0, 4);

            return bankCode switch
            {
                "1234" => new BankA(),
                "1111" => new BankB(),
                _ => throw new Exception("Invalid Card Number"), // or null
            };
        }

        public IPaymentCard GetPaymentCard(string CardNumber) 
        {
            string PaymentCardCode = CardNumber.Substring(0, 2);

            return PaymentCardCode switch
            {
                "12" => new CardA(),
                "11" => new CardB(),
                _ => throw new Exception("Invalid Card Number"), // or null
            };
        }
    }

    internal class AbstructFactory
    {
        public static void test()
        {
            string cardNumber1 = "123456789";
            string cardNumber2 = "111111111";

            IFactory bankFactory = new BankFactory();

            IBank bank1 = bankFactory.GetBank(cardNumber1);
            Console.WriteLine(bank1.Withdrow());

            IPaymentCard card1 = bankFactory.GetPaymentCard(cardNumber2);
            Console.WriteLine(card1.GetName());
        }
    }
}
