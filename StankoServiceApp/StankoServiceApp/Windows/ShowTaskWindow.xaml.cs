﻿using System;
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
using StankoServiceApp.ServiceReference;

namespace StankoServiceApp.Windows
{
    /// <summary>
    /// Логика взаимодействия для ShowTaskWindow.xaml
    /// </summary>
    public partial class ShowTaskWindow : Window
    {
        private ServiceReference.Task Task = new ServiceReference.Task();
        private Worker Worker = null;
        private User Manager = null;
        private List<TaskFile> ListFiles = new List<TaskFile>();
        private List<HistoryTask> ListHistory = new List<HistoryTask>();

        public ShowTaskWindow(ServiceReference.Task task)
        {
            InitializeComponent();
            this.Task = task;
        }

        private void FillTask()
        {
            var task = this.Task;

            this.tbNameTask.Text = task.TaskName;
            this.tbProject.Text = task.Project?.Name;
            this.tbEndDate.Text = task.EndDate?.ToLongDateString();

            this.tbPriority.Text = task.GetPriorityTask.ToString();
            this.imgIconPriority.Source = this.Task.PriorityIcon;

            this.tbStatus.Text = task.GetStatusTask.ToString();
            this.imgIconStatus.Source = task.StatusIcon;

            this.tbCompletionDate.Text = task.CompletionDate?.ToLongDateString();
            this.tbDescription.Text = task.Description;
        }

        private void FillWorker()
        {
            if (this.Worker != null)
            {
                var worker = this.Worker;
                this.tbFIO.Text = $"{worker.Surname} {worker.Name} {worker.Patronymic}";
                this.tbDateOfBirth.Text = worker.DateOfBirth.ToLongDateString();
                this.tbPhone.Text = worker.Phone;
                this.tbDateOfEmploy.Text = worker.DateOfEmploy.ToLongDateString();
                this.tbPosition.Text = worker.Position.PositionName;
                this.tbEmail.Text = worker.User.Email;
                this.imgPhoto.Source = worker.ImgPhoto;
            }
            else
            {
                this.gbWorker.Header = "Отсутствует исполнитель";
                this.lcWorker.Visibility = Visibility.Collapsed;
            }
        }

        private void FillManager()
        {
            if (this.Manager.Worker != null)
            {
                var worker = this.Manager.Worker;
                this.tbFIOM.Text = $"{worker.Surname} {worker.Name} {worker.Patronymic}";
                this.tbDateOfBirthM.Text = worker.DateOfBirth.ToLongDateString();
                this.tbPhoneM.Text = worker.Phone;
                this.tbDateOfEmployM.Text = worker.DateOfEmploy.ToLongDateString();
                this.tbPositionM.Text = worker.Position.PositionName;
                this.tbEmailM.Text = worker.User.Email;
                this.imgPhotoM.Source = worker.ImgPhoto;
            }
            else
            {
                this.gbManager.Header = "Менеджер задачи - директор";
                this.lcManager.Visibility = Visibility.Collapsed;
            }
        }

        private void FillFiles()
        {
            if (this.ListFiles.Count != 0)
            {
                this.gcFiles.ItemsSource = this.ListFiles;
            }
            else
            {
                this.gbFiles.Header = "Вложения отсутствуют";
            }
        }

        private void FillHistory()
        {
            if (this.ListHistory.Count != 0)
            {
                this.gcHistory.ItemsSource = this.ListHistory;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Worker = this.Task.Worker;
                this.Manager = this.Task.Manager;
                this.ListFiles = App.Service.GetTaskFiles().Where(x => x.TaskId == this.Task.Id).ToList();
                this.ListHistory = App.Service.GetHistoryTasks().Where(x => x.TaskId == this.Task.Id).ToList();

                this.FillFiles();
                this.FillWorker();
                this.FillManager();
                this.FillHistory();
                this.FillTask();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Возникло исключение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
