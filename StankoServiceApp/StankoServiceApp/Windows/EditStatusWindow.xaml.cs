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
    /// Логика взаимодействия для EditStatusWindow.xaml
    /// </summary>
    public partial class EditStatusWindow : Window
    {
        Project Project = new Project();
        StatusProject StatusP;
        ServiceReference.Task Task = new ServiceReference.Task();
        StatusTask StatusT;

        public EditStatusWindow(Project project, StatusProject status, ServiceReference.Task task = null)
        {
            InitializeComponent();
            this.StatusP = status;
            this.Project = project;
            this.Task = task;
        }

        public EditStatusWindow(ServiceReference.Task task, StatusTask status, Project project = null)
        {
            InitializeComponent();
            this.StatusT = status;
            this.Project = project;
            this.Task = task;
        }

        private void sbCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private async void sbSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.Task == null)
                {
                    await App.Service.EditStatusProjectAsync(this.Project, (int)this.StatusP, App.CurrentUser, this.meComment.Text);

                    if (this.tsSend.IsChecked == true)
                    {
                        Methods.SendMessageFromMainMail("Изменился статус проекта", $"Статус проекта '{this.Project.Name}' был изменен.\nЧтобы получить более подробную информацию - зайдите в АИС Станкосервис", this.Project.Worker.User.Email);
                    }
                }
                else
                {
                    await App.Service.EditStatusTaskAsync(this.Task, (int)this.StatusT, App.CurrentUser, this.meComment.Text);

                    if (this.tsSend.IsChecked == true)
                    {
                        if (this.Task.Worker != null)
                        {
                            Methods.SendMessageFromMainMail("Изменился статус задачи", $"Статус задачи '{this.Task.TaskName}' был изменен.\nЧтобы получить более подробную информацию - зайдите в АИС Станкосервис", this.Task.Worker.User.Email);
                        }

                        if (this.Task.Manager != null && this.Task.Manager.Worker != null)
                        {
                            Methods.SendMessageFromMainMail("Изменился статус задачи", $"Статус задачи '{this.Task.TaskName}' был изменен.\nЧтобы получить более подробную информацию - зайдите в АИС Станкосервис", this.Task.Manager.Email);
                        }
                    }
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Возникло исключение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
