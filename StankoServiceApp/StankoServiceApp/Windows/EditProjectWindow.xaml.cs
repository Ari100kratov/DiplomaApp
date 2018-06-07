﻿using Microsoft.Win32;
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
                this.FillWorker();
                this.teName.Text = this.Project.Name;
                this.deStartDate.EditValue = this.Project.StartDate;
                this.deEndDate.EditValue = this.Project.EndDate;
                this.deCompletionDate.EditValue = this.Project.CompletionDate;
                this.ceStatus.EditValue = this.Project.TypePeriodId;
                this.ceTypePeriod.EditValue = this.Project.StatusId;

                if (this.Project.File == null)
                {
                    this.tbDownloadFile.Foreground = Brushes.IndianRed;
                    return;
                }

                this.tbDownloadFile.Foreground = Brushes.DarkGreen;
                this.tbDownloadFile.Text = this.Project.File.FileName;
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
                        Data = System.IO.File.ReadAllBytes(openFile.FileName)
                    };

                    this.tbDownloadFile.Text = System.IO.Path.GetFileName(openFile.FileName);
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

        private void sbSave_Click(object sender, RoutedEventArgs e)
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

                    App.Service.AddNewProject(this.File, project);

                    if (MessageBox.Show("Хотите отправить сотруднику письмо уведомления на почту?", "Отправка", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        WorkWithMail.SendMessageFromMainMail("Вы - руководитель нового проекта", $"Вас назначали руководителем нового проекта '{this.teName.Text}'.\nЧтобы получить более подробную информацию - зайдите в АИС Станкосервис", this.Worker.User.Email);
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
                    App.Service.EditProject(this.File, this.Project);

                    if (MessageBox.Show("Хотите отправить сотруднику письмо уведомления на почту?", "Отправка", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        WorkWithMail.SendMessageFromMainMail("Изменение информации о проекте", $"Информация о проекте '{this.teName.Text} была изменена.'\nЧтобы получить более подробную информацию - зайдите в АИС Станкосервис", this.Worker.User.Email);
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
    }
}
