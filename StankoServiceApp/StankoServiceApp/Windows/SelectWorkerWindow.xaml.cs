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
        private Worker Worker = null;

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

        private void ShowCurrent()
        {
            if (this.EditTask != null)
            {
                this.gbTask.Visibility = Visibility.Visible;
                this.gcTask.ItemsSource = App.Service.GetTasks().Where(x => x.WorkerId == this.Worker.Id && (x.StatusId != (int)StatusTask.Выполнена && x.StatusId != (int)StatusTask.Отложена && x.StatusId != (int)StatusTask.Отменена)).ToList();
            }
            else
            {
                this.gbProject.Visibility = Visibility.Visible;
                this.gcProject.ItemsSource = App.Service.GetProjects().Where(x => x.WorkerId == this.Worker.Id && (x.StatusId != (int)StatusProject.Завершен && x.StatusId != (int)StatusProject.Закрыт && x.StatusId != (int)StatusProject.Отложен)).ToList();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Возникло исключение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void sbCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void sbSelect_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.Worker == null)
                {
                    MessageBox.Show("Выберите сотрудника!", "Сообщение об ошибке", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (this.EditTask == null)
                {
                    this.EditProject.Worker = this.Worker;
                }
                else
                {
                    this.EditTask.Worker = this.Worker;
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Возникло исключение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void gcWorker_CurrentItemChanged(object sender, DevExpress.Xpf.Grid.CurrentItemChangedEventArgs e)
        {
            try
            {
                this.Worker = this.gcWorker.CurrentItem as Worker;

                if (this.Worker != null)
                {
                    this.ShowCurrent();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Возникло исключение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
