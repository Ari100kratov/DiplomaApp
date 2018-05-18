using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfServiceApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new ServiceHost(typeof(Service));
            host.Open();
            Console.WriteLine("Сервис запущен");
            Console.ReadLine();
            host.Close();
        }
    }
}
