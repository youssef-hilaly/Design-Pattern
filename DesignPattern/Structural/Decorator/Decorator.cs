using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Structural.Decorator
{
    public interface IService
    {
        string Send(string customerId, string mobile, string message);
        public void SetService(IService service);
    }
    public class SMSService : IService
    {
        private IService _service;
        public SMSService(){}
        public SMSService(IService service)
        {
            _service = service;
        }
        public string Send(string customerId, string mobile, string message)
        {
            if (_service != null)
            {
                Console.WriteLine(_service?.Send(customerId, mobile, message));
            }
            return $"CustomerId: {customerId}, SMS sent to {mobile}";
        }
        public void SetService(IService service)
        {
            _service = service;
        }
    }
    public class ServiceProxy(IService service)
    {
        private IService _service = service;
        private Dictionary<string, int> remainingCount = [];

        public string Send(string customerId, string mobile, string message)
        {
            remainingCount.TryAdd(customerId, 3);
            int SMSCount = remainingCount[customerId];

            if (SMSCount > 0)
            {
                remainingCount[customerId] = remainingCount[customerId] - 1;
                return _service.Send(customerId, mobile, message);
            }

            return "Message Limit Exceded";
        }
    }
    public class MailService : IService
    {
        private IService? _service;
        public MailService() { }
        public MailService(IService service)
        {
            _service = service;
        }
        public string Send(string customerId, string mobile, string message)
        {
            if(_service != null)
            {
                Console.WriteLine(_service?.Send(customerId, mobile, message));
            }
            return $"CustomerId: {customerId}, Mail sent to {mobile}";
        }
        public void SetService(IService service)
        {
            _service = service;
        }
    }

    internal class Decorator
    {
        public static void test()
        {
            // only Decorator
            IService MailService = new MailService();
            IService SMSService = new SMSService(MailService);

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(SMSService.Send("1", "0123456", "Hello Proxy"));
            }

            Console.WriteLine("___________________");
            Console.WriteLine();


            // only Decorator with a proxy 
            IService SMSService2 = new SMSService();
            IService MailService2 = new MailService(SMSService2);
            ServiceProxy ServiceProxy2 = new ServiceProxy(MailService2);

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(ServiceProxy2.Send("1", "0123456", "Hello Proxy"));
            }


        }
    }
}
