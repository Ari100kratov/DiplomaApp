using StankoServiceApp.ServiceReference;
using StankoserviceEnums;
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

namespace StankoServiceApp.Windows
{
    /// <summary>
    /// Логика взаимодействия для SelectWorkerWindow.xaml
    /// </summary>
    public partial class SelectWorkerWindow : Window
    {
        private EditProjectWindow EditProject = new EditProjectWindow();
        private EditTaskWindow EditTask = new EditTaskWindow();


        public SelectWorkerWindow(EditTaskWindow editTask, EditProjectWindow editProject = null)
        {
            InitializeComponent();
            this.EditProject = editProject;
            this.EditTask = editTask;
        }

        public SelectWorkerWindow(EditProjectWindow editProject, EditTaskWindow editTask = null)
        {
            InitializeComponent();
            this.EditTask = editTask;
            this.EditProject = editProject;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (this.EditTask == null)
            {
                this.gcWorker.ItemsSource = App.Service.GetWorkers().Where(x => x.User.RoleId == (int)Role.Менеджер).ToList();
            }
            else
            {
                this.gcWorker.ItemsSource = App.Service.GetWorkers().Where(x => x.User.RoleId == (int)Role.Исполнитель).ToList();
            }
        }

        private void sbCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void sbSelect_Click(object sender, RoutedEventArgs e)
        {
            var worker = this.gcWorker.CurrentItem as Worker;

            if (worker == null)
            {
                MessageBox.Show("Выберите сотрудника!", "Сообщение об ошибке", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (this.EditTask == null)
            {
                this.EditProject.Worker = worker;
            }
            else
            {
                this.EditTask.Worker = worker;
            }

            this.Close();
        }
    }
}
