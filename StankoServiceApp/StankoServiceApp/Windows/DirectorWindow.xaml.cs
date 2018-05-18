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

namespace StankoServiceApp
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

        private void ProjectPage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
             this.ChangeColorByClick(0);
        }

        private void ChangeColorByClick(int select)
        {
            var bc = new BrushConverter();

            this.ProjectPage.Background = Brushes.White;
            this.tbProject.Foreground = Brushes.Black;

            this.WorkerPage.Background = Brushes.White;
            this.tbWorker.Foreground = Brushes.Black;

            this.TaskPage.Background = Brushes.White;
            this.tbTask.Foreground = Brushes.Black;

            this.StatPage.Background = Brushes.White;
            this.tbStat.Foreground = Brushes.Black;

            this.CustomerPage.Background = Brushes.White;
            this.tbCustomer.Foreground = Brushes.Black;

            switch (select)
            {
                case (0):
                    this.ProjectPage.Background = (Brush)bc.ConvertFrom("#006A68");
                    this.tbProject.Foreground = Brushes.White;
                    break;

                case (1):
                    this.WorkerPage.Background = (Brush)bc.ConvertFrom("#006A68");
                    this.tbWorker.Foreground = Brushes.White;
                    break;

                case (2):
                    this.TaskPage.Background = (Brush)bc.ConvertFrom("#006A68");
                    this.tbTask.Foreground = Brushes.White;
                    break;

                case (3):
                    this.StatPage.Background = (Brush)bc.ConvertFrom("#006A68");
                    this.tbStat.Foreground = Brushes.White;
                    break;

                case (4):
                    this.CustomerPage.Background = (Brush)bc.ConvertFrom("#006A68");
                    this.tbCustomer.Foreground = Brushes.White;
                    break;
            }
        }

        private void WorkerPage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.ChangeColorByClick(1);
        }

        private void TaskPage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.ChangeColorByClick(2);
        }

        private void StatPage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.ChangeColorByClick(3);
        }

        private void CustomerPage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.ChangeColorByClick(4);
        }

        private void ProjectPage_MouseEnter(object sender, MouseEventArgs e)
        {
            //var bc = new BrushConverter();
           // this.ProjectPage.Background = (Brush)bc.ConvertFrom("#5FC0BA");
        }

        private void ProjectPage_MouseLeave(object sender, MouseEventArgs e)
        {
           // this.ProjectPage.Background = Brushes.White;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                this.MainFrame.Navigate(new ProjectPage());
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
