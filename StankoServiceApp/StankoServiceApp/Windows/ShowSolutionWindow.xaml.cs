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
    /// Логика взаимодействия для ShowSolutionWindow.xaml
    /// </summary>
    public partial class ShowSolutionWindow : Window
    {
        private Task Task = null;
        private Solution Solution => this.Task.Solution;
        private List<SolutionFile> ListFiles => this.Solution.SolutionFiles;

        public ShowSolutionWindow(Task task)
        {
            InitializeComponent();
            this.Task = task;
        }

        private void gcFiles_ItemsSourceChanged(object sender, DevExpress.Xpf.Grid.ItemsSourceChangedEventArgs e)
        {
            this.tvFiles.BestFitColumn(columnDownload);
            this.tvFiles.BestFitColumn(columnIcon);
            this.tvFiles.BestFitColumn(columnDate);
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var taskFile = this.gcFiles.CurrentItem as SolutionFile;

            if (taskFile == null)
            {
                return;
            }

            try
            {
                var save = new SaveFileDialog
                {
                    Title = "Сохранить файл",
                    DefaultExt = taskFile.File.Title,
                    AddExtension = true,
                    FileName = taskFile.File.FileName
                };

                if (save.ShowDialog() == true)
                {
                    using (var stream = save.OpenFile())
                    {
                        stream.Write(taskFile.File.Data, 0, taskFile.File.Data.Length);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Возникло исключение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.tbDate.Text = $"{this.Solution.DateTime.ToLongDateString()} {this.Solution.DateTime.ToLongTimeString()}";
            this.tbComment.Text = this.Solution.Comment;
            this.cbFilterStatus.EditValue = this.Task.StatusId;
            this.gcFiles.ItemsSource = this.ListFiles;
        }

        private void sbSave_Click(object sender, RoutedEventArgs e)
        {
            if (this.cbFilterStatus.EditValue == null)
            {
                MessageBox.Show("Выберите статус", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            int status = (int)this.cbFilterStatus.EditValue;
            var editStatus = new EditStatusWindow(this.Task, (StatusTask)status);
            editStatus.ShowDialog();
            this.cbFilterStatus.EditValue = App.Service.GetTasks().FirstOrDefault(x => x.Id == this.Task.Id).StatusId;
        }
    }
}
