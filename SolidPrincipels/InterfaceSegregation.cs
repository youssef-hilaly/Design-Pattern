using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSegregation
{
    // Interface Segregation Principle
    // A client should never be forced to implement an interface that it doesn't use
    // Avoid fat interfaces
    // Split the interfaces into smaller interfaces


    // violation of Interface Segregation Principle
    internal interface IOrder
    {
        void ProcessCashPayment();
        void ProcessCreditCardPayment();
        void ProcessPayPalPayment();
    }

    internal class OnlineOrder : IOrder
    {
        public void ProcessCashPayment()
        {
            throw new NotImplementedException();
        }

        public void ProcessCreditCardPayment()
        {
            // process credit card payment
        }

        public void ProcessPayPalPayment()
        {
            // process paypal payment
        }
    }

    // Solution

    internal interface ICreditCardPayment
    {
        void ProcessCreditCardPayment();
    }

    internal interface IPayPalPayment
    {
        void ProcessPayPalPayment();
    }

    internal interface ICashPayment
    {
        void ProcessCashPayment();
    }

    internal class OnlineOrderNew : ICreditCardPayment, IPayPalPayment
    {
        public void ProcessCreditCardPayment()
        {
            // process credit card payment
        }

        public void ProcessPayPalPayment()
        {
            // process paypal payment
        }
    }



}
