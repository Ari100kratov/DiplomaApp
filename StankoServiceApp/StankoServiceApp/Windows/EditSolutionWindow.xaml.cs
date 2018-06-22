using Microsoft.Win32;
using StankoServiceApp.ServiceReference;
using StankoserviceEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Логика взаимодействия для EditSolutionWindow.xaml
    /// </summary>
    public partial class EditSolutionWindow : Window
    {
        private File CurrentFile = null;
        private Task Task = new Task();
        private List<File> ListFile = new List<File>();
        private List<File> ListDelete = new List<File>();

        public EditSolutionWindow(Task task)
        {
            InitializeComponent();
            this.Task = task;
        }

        private void FillFiles()
        {
            this.gcFiles.ItemsSource = null;
            this.gcFiles.ItemsSource = this.ListFile;
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

        private void gcFiles_ItemsSourceChanged(object sender, DevExpress.Xpf.Grid.ItemsSourceChangedEventArgs e)
        {
            this.tvFile.BestFitColumns();
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (this.Task.Solution == null)
            {
                return;
            }

            this.meComment.Text = this.Task.Solution.Comment;
            var taskFile = App.Service.GetSolutionFiles().Where(x => x.SolutionId == this.Task.SolutionId).ToList();

            foreach (var item in taskFile)
            {
                this.ListFile.Add(item.File);
            }

            this.FillFiles();
        }

        private void sbCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void sbSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.meComment.Text) || this.ListFile.Count() == 0)
            {
                this.lblError.Background = Brushes.IndianRed;
                this.lblError.Foreground = Brushes.White;
                this.lblError.Text = "Нечего сохранять!";
                this.lblError.Visibility = Visibility.Visible;
                return;
            }

            App.Service.EditSolution(this.Task, this.ListFile, this.ListDelete, this.meComment.Text, (bool)this.tsSend.IsChecked);

            if ((bool)this.tsMail.IsChecked)
            {
                Methods.SendMessageFromMainMail("Задача на подтверждении", $"Задача '{this.Task.TaskName}' ожидает вашего подтверждения\nЧтобы получить более подробную информацию - зайдите в АИС Станкосервис", this.Task.Manager.Email);
            }

            this.lblError.Background = Brushes.White;
            this.lblError.Foreground = Brushes.Green;
            this.lblError.Text = "Данные успешно сохранены!";
            this.lblError.Visibility = Visibility.Visible;
        }

        private void tsSend_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)this.tsSend.IsChecked == true)
            {
                this.liMail.Visibility = Visibility.Visible;
            }
            else
            {
                this.liMail.Visibility = Visibility.Collapsed;
                this.tsMail.IsChecked = false;
            }
        }

        private void tsSend_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
