using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Structural.Proxy
{
    public interface ISMSService
    {
        string SendSMS(string customerId, string mobile, string message);
    }
    public class SMSService : ISMSService
    {
        public string SendSMS(string customerId, string mobile, string message)
        {
            return $"CustomerId: {customerId}, SMS sent to {mobile}";
        }
    }
    public class SMSServiceProxy
    {
        private ISMSService _service;
        Dictionary<string, int> remainingCount = new Dictionary<string, int>();
        public SMSServiceProxy(ISMSService service)
        {
            _service = service;
        }
        public string SendSMS(string customerId, string mobile, string message)
        {
            if (!remainingCount.ContainsKey(customerId))
                remainingCount.Add(customerId, 3);

            int SMSCount = remainingCount[customerId];
            
            if(SMSCount > 0)
            {
                remainingCount[customerId] = remainingCount[customerId] - 1;
                return _service.SendSMS(customerId, mobile, message);
            }

            return "Message Limit Exceded";
        }
    }
    internal class Proxy
    {
        //Remote Proxy, Virtual Proxy, Protection Proxy
        public static void test()
        {
            ISMSService sMSService = new SMSService();

            SMSServiceProxy sMSServiceProxy = new SMSServiceProxy(sMSService);

            for(int i = 0; i < 5; i++)
            {
                Console.WriteLine(sMSServiceProxy.SendSMS("1", "0123456", "Hello Proxy"));
            }
        }
    }
}
