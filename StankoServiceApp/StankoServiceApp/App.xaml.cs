using StankoServiceApp.ServiceReference;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace StankoServiceApp
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ServiceClient Service = new ServiceClient();
        public static User CurrentUser = new User();
    }
}
