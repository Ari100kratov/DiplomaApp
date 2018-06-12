using Microsoft.Win32;
using StankoServiceApp.ServiceReference;
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
using StankoserviceEnums;

namespace StankoServiceApp.Windows
{
    /// <summary>
    /// Логика взаимодействия для EditTaskWindow.xaml
    /// </summary>
    public partial class EditTaskWindow : Window
    {
        public Worker Worker = null;
        private ServiceReference.Task Task = null;
        private List<File> ListFile = new List<File>();
        private File CurrentFile = null;
        private StatusTask StartStatus;
        private List<File> ListDelete = new List<File>();

        private bool IsAdd => this.Task == null;

        public EditTaskWindow(ServiceReference.Task task = null)
        {
            InitializeComponent();
            this.Task = task;
            this.Worker = this.Task?.Worker;
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
                this.tbFIO.Text = "";
                this.tbDateOfBirth.Text = "";
                this.tbPhone.Text = "";
                this.tbDateOfEmploy.Text = "";
                this.tbPosition.Text = "";
                this.tbEmail.Text = "";
                this.imgPhoto.Source = null;
            }
        }

        private void FillFiles()
        {
            if (this.ListFile.Count != 0)
            {
                this.gcFiles.ItemsSource = null;
                this.gcFiles.ItemsSource = this.ListFile;
            }
        }

        private void sbSelectWorker_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectWorker = new SelectWorkerWindow(this);
                selectWorker.ShowDialog();
                this.FillWorker();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Возникло исключение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void FillTask()
        {
            this.teNameTask.Text = this.Task.TaskName;
            this.ceProject.EditValue = this.Task.ProjectId;
            this.deEndDate.EditValue = this.Task.EndDate;
            this.cePriority.EditValue = this.Task.PriorityId;
            this.ceStatus.EditValue = this.Task.StatusId;
            this.deCompletionDate.EditValue = this.Task.CompletionDate;
            this.meDescription.Text = this.Task.Description;
        }

        private void FillCe()
        {
            this.ceProject.ItemsSource = App.Service.GetProjects();
            this.ceProject.DisplayMember = "Name";
            this.ceProject.ValueMember = "Id";
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                this.FillCe();

                if (this.IsAdd)
                {
                    this.liStatus.Visibility = Visibility.Collapsed;
                    this.liCompletionDate.Visibility = Visibility.Collapsed;
                    this.ceStatus.EditValue = (int)StatusTask.Новая;
                    return;
                }

                this.StartStatus = (StatusTask)this.Task.GetStatusTask;
                var taskFile = App.Service.GetTaskFiles().Where(x => x.TaskId == this.Task.Id).ToList();

                foreach (var item in taskFile)
                {
                    this.ListFile.Add(item.File);
                }

                this.FillTask();
                this.FillWorker();
                this.FillFiles();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Возникло исключение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void gcFiles_CurrentItemChanged(object sender, DevExpress.Xpf.Grid.CurrentItemChangedEventArgs e)
        {
            try
            {
                this.CurrentFile = this.gcFiles.CurrentItem as File;

                if (this.CurrentFile == null)
                {
                    this.sbDeleteFile.IsEnabled = false;
                    this.sbEditFile.IsEnabled = false;
                }
                else
                {
                    this.sbDeleteFile.IsEnabled = true;
                    this.sbEditFile.IsEnabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Возникло исключение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void sbDeleteWorker_Click(object sender, RoutedEventArgs e)
        {
            this.Worker = null;
            this.FillWorker();
        }

        private void ceStatus_EditValueChanged(object sender, DevExpress.Xpf.Editors.EditValueChangedEventArgs e)
        {
            if (!this.IsAdd)
            {
                if ((int)this.StartStatus == (int)this.ceStatus.EditValue)
                {
                    this.liComment.Visibility = Visibility.Collapsed;
                }
                else
                {
                    this.liComment.Visibility = Visibility.Visible;
                }
            }
        }

        private void sbAddFile_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var openFile = new OpenFileDialog();
                openFile.Filter = "Все файлы (*.*)|*.*";
                openFile.CheckFileExists = true;

                if (openFile.ShowDialog() == true)
                {
                    var file = new File()
                    {
                        FileName = System.IO.Path.GetFileName(openFile.FileName),
                        Title = System.IO.Path.GetExtension(openFile.FileName),
                        Data = System.IO.File.ReadAllBytes(openFile.FileName),
                        ChangeDate = DateTime.Now
                    };

                    this.ListFile.Add(file);
                    this.FillFiles();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Возникло исключение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void sbEditFile_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var openFile = new OpenFileDialog();
                openFile.Filter = "Все файлы (*.*)|*.*";
                openFile.CheckFileExists = true;

                if (openFile.ShowDialog() == true)
                {
                    var index = this.ListFile.IndexOf(this.CurrentFile);
                    this.CurrentFile.FileName = System.IO.Path.GetFileName(openFile.FileName);
                    this.CurrentFile.Title = System.IO.Path.GetExtension(openFile.FileName);
                    this.CurrentFile.Data = System.IO.File.ReadAllBytes(openFile.FileName);
                    this.CurrentFile.ChangeDate = DateTime.Now;

                    this.ListFile[index] = this.CurrentFile;
                    this.FillFiles();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Возникло исключение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void sbDeleteFile_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.CurrentFile.Id != 0)
                {
                    this.ListDelete.Add(this.CurrentFile);
                }

                var index = this.ListFile.IndexOf(this.CurrentFile);
                this.ListFile.RemoveAt(index);
                this.FillFiles();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Возникло исключение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void sbSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(this.teNameTask.Text) || this.cePriority.EditValue == null || this.ceStatus.EditValue == null)
                {
                    this.lblError.Text = "Заполните обязательные поля";
                    this.lblError.Visibility = Visibility.Visible;
                    return;
                }

                if (this.IsAdd)
                {
                    var task = new ServiceReference.Task
                    {
                        TaskName = this.teNameTask.Text,
                        WorkerId = this.Worker?.Id,
                        ProjectId = (int?)this.ceProject.EditValue,
                        EndDate = (DateTime?)this.deEndDate.EditValue,
                        StatusId = (int)this.ceStatus.EditValue,
                        PriorityId = (int)this.cePriority.EditValue,
                        Description = this.meDescription.Text,
                        CompletionDate = (DateTime?)this.deCompletionDate.EditValue,
                        ManagerId = App.CurrentUser.Id
                    };

                    await App.Service.AddNewTaskAsync(task, this.ListFile, App.CurrentUser, this.meComment.Text);

                    if (this.Worker != null)
                    {
                        if (MessageBox.Show("Хотите отправить сотруднику письмо уведомления на почту?", "Отправка", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                        {
                            Methods.SendMessageFromMainMail("Новая задача", $"Вас назначили исполнителем новой задачи\nЧтобы получить более подробную информацию - зайдите в АИС Станкосервис", this.Worker.User.Email);
                        }
                    }
                }
                else
                {
                    this.Task.TaskName = this.teNameTask.Text;
                    this.Task.WorkerId = this.Worker?.Id;
                    this.Task.ProjectId = (int?)this.ceProject.EditValue;
                    this.Task.EndDate = (DateTime?)this.deEndDate.EditValue;
                    this.Task.StatusId = (int)this.ceStatus.EditValue;
                    this.Task.PriorityId = (int)this.cePriority.EditValue;
                    this.Task.Description = this.meDescription.Text;
                    this.Task.CompletionDate = (DateTime?)this.deCompletionDate.EditValue;
                    this.Task.ManagerId = App.CurrentUser.Id;

                    if (this.StartStatus == this.Task.GetStatusTask)
                    {
                        User user = null;
                        await App.Service.EditTaskAsync(this.Task, this.ListFile, this.ListDelete, user, this.meComment.Text);
                    }
                    else
                    {
                        await App.Service.EditTaskAsync(this.Task, this.ListFile, this.ListDelete, App.CurrentUser, this.meComment.Text);
                    }

                    if (this.Worker != null)
                    {
                        if (MessageBox.Show("Хотите отправить сотруднику письмо уведомления на почту?", "Отправка", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                        {
                            Methods.SendMessageFromMainMail("Изменение информации о задаче", $"Информация о задаче, исполнителем которой вы являетесь, была изменена\nЧтобы получить более подробную информацию - зайдите в АИС Станкосервис", this.Worker.User.Email);
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
