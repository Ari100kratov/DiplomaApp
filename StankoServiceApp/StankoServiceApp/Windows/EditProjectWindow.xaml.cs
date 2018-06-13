using Microsoft.Win32;
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
    /// Логика взаимодействия для EditProjectWindow.xaml
    /// </summary>
    public partial class EditProjectWindow : Window
    {
        private Project Project = null;
        private File File = new File();
        public Worker Worker = null;
        private bool IsAdd => this.Project == null;
        private StatusProject StartStatus;

        public EditProjectWindow(Project project = null)
        {
            InitializeComponent();
            this.Project = project;
            this.Worker = Project?.Worker;
            this.File = Project?.File;

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
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.IsAdd)
                {
                    return;
                }
                this.StartStatus = (StatusProject)this.Project.GetStatusProject;
                this.FillWorker();
                this.teName.Text = this.Project.Name;
                this.deStartDate.EditValue = this.Project.StartDate;
                this.deEndDate.EditValue = this.Project.EndDate;
                this.deCompletionDate.EditValue = this.Project.CompletionDate;
                this.ceStatus.EditValue = this.Project.StatusId;
                this.ceTypePeriod.EditValue = this.Project.TypePeriodId;

                if (this.Project.File == null)
                {
                    this.tbDownloadFile.Foreground = Brushes.IndianRed;
                    return;
                }

                this.tbDownloadFile.Foreground = Brushes.DarkGreen;
                this.tbDownloadFile.Text = $"{this.Project.File.FileName} ({this.Project.File.ChangeDate.Value.ToLongDateString()})";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Возникло исключение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void sbDownLoad_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var openFile = new OpenFileDialog();
                openFile.Filter = "Все файлы (*.*)|*.*";
                openFile.CheckFileExists = true;

                if (openFile.ShowDialog() == true)
                {
                    this.File = new File()
                    {
                        FileName = System.IO.Path.GetFileName(openFile.FileName),
                        Title = System.IO.Path.GetExtension(openFile.FileName),
                        Data = System.IO.File.ReadAllBytes(openFile.FileName),
                        ChangeDate = DateTime.Now
                    };

                    this.tbDownloadFile.Text = $"{System.IO.Path.GetFileName(openFile.FileName)} ({DateTime.Now.ToLongDateString()})";
                    this.tbDownloadFile.Foreground = Brushes.DarkGreen;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Возникло исключение", MessageBoxButton.OK, MessageBoxImage.Error);
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

        private async void sbSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.lblErrorManager.Visibility = Visibility.Collapsed;
                this.lblErrorProject.Visibility = Visibility.Collapsed;

                if (string.IsNullOrWhiteSpace(this.teName.Text) || this.deStartDate.EditValue == null || this.ceStatus.EditValue == null || this.ceTypePeriod.EditValue == null)
                {
                    this.lblErrorProject.Visibility = Visibility.Visible;
                    return;
                }

                if (this.Worker == null)
                {
                    this.lblErrorManager.Visibility = Visibility.Visible;
                    return;
                }

                if (this.IsAdd)
                {
                    var project = new Project
                    {
                        Name = this.teName.Text,
                        StartDate = (DateTime)this.deStartDate.EditValue,
                        EndDate = (DateTime?)this.deEndDate.EditValue,
                        CompletionDate = (DateTime?)this.deCompletionDate.EditValue,
                        StatusId = (int)this.ceStatus.EditValue,
                        TypePeriodId = (int)this.ceTypePeriod.EditValue,
                        WorkerId = this.Worker.Id
                    };

                    await App.Service.AddNewProjectAsync(this.File, project, App.CurrentUser, this.teComment.Text);

                    if (MessageBox.Show("Хотите отправить сотруднику письмо уведомления на почту?", "Отправка", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        Methods.SendMessageFromMainMail("Вы - руководитель нового проекта", $"Вас назначали руководителем нового проекта '{this.teName.Text}'.\nЧтобы получить более подробную информацию - зайдите в АИС Станкосервис", this.Worker.User.Email);
                    }

                }
                else
                {
                    this.Project.Name = this.teName.Text;
                    this.Project.StartDate = (DateTime)this.deStartDate.EditValue;
                    this.Project.EndDate = (DateTime?)this.deEndDate.EditValue;
                    this.Project.CompletionDate = (DateTime?)this.deCompletionDate.EditValue;
                    this.Project.StatusId = (int)this.ceStatus.EditValue;
                    this.Project.TypePeriodId = (int)this.ceTypePeriod.EditValue;
                    this.Project.WorkerId = this.Worker.Id;

                    if (this.StartStatus != this.Project.GetStatusProject)
                    {
                        App.Service.EditProject(this.File, this.Project, this.teComment.Text, App.CurrentUser);
                    }
                    else
                    {
                        User user = null;
                        await App.Service.EditProjectAsync(this.File, this.Project, this.teComment.Text, user);
                    }

                    if (MessageBox.Show("Хотите отправить сотруднику письмо уведомления на почту?", "Отправка", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        Methods.SendMessageFromMainMail("Изменение информации о проекте", $"Информация о проекте '{this.teName.Text}' была изменена.\nЧтобы получить более подробную информацию - зайдите в АИС Станкосервис", this.Worker.User.Email);
                    }
                }

                this.Close();
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

        private void ceStatus_EditValueChanged(object sender, DevExpress.Xpf.Editors.EditValueChangedEventArgs e)
        {
            if (this.IsAdd)
            {
                this.liComment.Visibility = Visibility.Visible;
            }
            else
            {
                if (this.ceStatus.EditValue != null)
                {
                    if ((int)this.ceStatus.EditValue == (int)this.StartStatus)
                    {
                        this.liComment.Visibility = Visibility.Collapsed;
                    }
                    else
                    {
                        this.liComment.Visibility = Visibility.Visible;
                    }
                }
            }
        }

        private void deCompletionDate_EditValueChanged(object sender, DevExpress.Xpf.Editors.EditValueChangedEventArgs e)
        {
            if (this.deCompletionDate.EditValue != null)
            {
                this.ceStatus.SelectedItem = StatusProject.Завершен;
                this.ceStatus.IsEnabled = false;
            }
            else
            {
                this.ceStatus.SelectedItem = null;
                this.ceStatus.IsEnabled = true;
            }
        }
    }
}
