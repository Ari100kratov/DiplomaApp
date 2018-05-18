using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using StankoServiceApp.Entities;

namespace StankoServiceApp
{
    /// <summary>
    /// Логика взаимодействия для StartWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        public StartWindow()
        {
            InitializeComponent();
        }

        private void sbLogin_Click(object sender, RoutedEventArgs e)
        {
            var user = App.service.Authorization(this.teLogin.Text, this.pbPassword.Password);

            if (user == null)
            {
                MessageBox.Show("Такого пользователя не существует");
            }
        }
    }
}
