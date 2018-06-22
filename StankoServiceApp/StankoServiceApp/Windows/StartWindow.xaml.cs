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
using DevExpress.Xpf.Editors;
using StankoServiceApp.ServiceReference;
using StankoServiceApp.Windows;
using StankoserviceEnums;

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
            this.teLogin.Text = Properties.Settings.Default.Login;
            this.pbPassword.Password = Properties.Settings.Default.Password;
        }

        private void sbLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var user = App.Service.Authorization(this.teLogin.Text, this.pbPassword.Password);

                if (user == null)
                {
                    this.tbErrorMessage.Visibility = Visibility.Visible;
                    this.pbPassword.Clear();
                    return;
                }

                if (this.cbRemember.IsChecked == true)
                {
                    Properties.Settings.Default.Login = this.teLogin.Text;
                    Properties.Settings.Default.Password = this.pbPassword.Password;
                }
                else
                {
                    Properties.Settings.Default.Login = "";
                    Properties.Settings.Default.Password = "";
                }

                Properties.Settings.Default.Save();
                this.tbErrorMessage.Visibility = Visibility.Collapsed;
                App.CurrentUser = user;

                switch (App.CurrentUser.RoleUser)
                {
                    case (Role.Директор):
                        var dirWin = new DirectorWindow();
                        dirWin.Show();
                        break;

                    case (Role.Менеджер):
                        var manWin = new ManagerWindow();
                        manWin.Show();
                        break;

                    case (Role.Исполнитель):
                        var worWin = new WorkerWindow();
                        worWin.Show();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Возникло исключение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(this.teLogin.Text))
                {
                    this.cbRemember.IsChecked = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Возникло исключение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
