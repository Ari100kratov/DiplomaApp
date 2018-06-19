using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            try
            {
                using (var host = new ServiceHost(typeof(Service)))
                {

                    host.Open();
                    Console.WriteLine("Сервис успешно запущен");
                    Console.WriteLine("Выберите используемое подключение к базе данных: 1) Home 2) Colledge");
                    var con = Console.ReadLine();
                    var sqlCon = new SqlConnection();

                    if (con == "Home")
                    {
                        sqlCon.ConnectionString = Properties.Settings.Default.Home;
                        GenericRepositoryLibrary.DataManager.Connection = Properties.Settings.Default.Home;
                    }
                    else
                    {
                        sqlCon.ConnectionString = Properties.Settings.Default.Colledge;
                        GenericRepositoryLibrary.DataManager.Connection = Properties.Settings.Default.Colledge;
                    }

                    sqlCon.Open();
                    sqlCon.Close();

                    Console.WriteLine("Подключение к базе данных отработало без ошибок");
                    Console.WriteLine("Для остановки работы сервера нажмите на любую клавишу");
                    Console.ReadKey();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }
    }
}
