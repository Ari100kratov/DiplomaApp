﻿using System;
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
            this.MainFrame.Navigate(new System.Uri("Pages/ProjectPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var index = int.Parse(((Button)e.Source).Uid);

                this.GridCursor.Margin = new Thickness(10 + (150 * index), 0, 0, 0);

                switch (index)
                {
                    case (0):
                        this.MainFrame.Navigate(new System.Uri("Pages/ProjectPage.xaml", UriKind.RelativeOrAbsolute));
                        break;
                    case (1):
                        this.MainFrame.Navigate(new System.Uri("Pages/TaskPage.xaml", UriKind.RelativeOrAbsolute));
                        break;
                    case (2):
                        this.MainFrame.Navigate(new System.Uri("Pages/WorkerPage.xaml", UriKind.RelativeOrAbsolute));
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Возникло исключение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
