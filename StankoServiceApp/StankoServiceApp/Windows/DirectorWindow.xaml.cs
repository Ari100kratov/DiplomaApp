using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
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
using Microsoft.Win32;
using StankoServiceApp.Pages;

namespace StankoServiceApp.Windows
{
    /// <summary>
    /// Логика взаимодействия для DirectorWindow.xaml
    /// </summary>
    public partial class DirectorWindow : Window
    {
        public DirectorWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.MainFrame.Navigate(new ProjectPage());
        }

        private void sbWorker_Click(object sender, RoutedEventArgs e)
        {
            this.MainFrame.Navigate(new WorkerPage());
        }

        private void sbProject_Click(object sender, RoutedEventArgs e)
        {
            this.MainFrame.Navigate(new ProjectPage());
        }
    }
}
