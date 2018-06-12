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
    /// Логика взаимодействия для ShowProjectWindow.xaml
    /// </summary>
    public partial class ShowProjectWindow : Window
    {
        Project Project = new Project();
        List<HistoryProject> History = new List<HistoryProject>();
        public ShowProjectWindow(Project project)
        {
            InitializeComponent();
            this.Project = project;
        }

        private void FillProject()
        {
            this.tbNameProject.Text = this.Project.Name;
            this.tbDateStart.Text = this.Project.StartDate.ToLongDateString();
            this.tbDateEnd.Text = this.Project.EndDate?.ToLongDateString();
            this.tbCompletionDate.Text = this.Project.CompletionDate?.ToLongDateString();
            this.tbTypeProject.Text = this.Project.TypeProject.ToString();
            this.imgIcon.Source = this.Project.StatusIcon;
            this.tbStatusProject.Text = this.Project.GetStatusProject.ToString();

            if (this.Project.File != null)
            {
                this.tbDownloadFile.Text = $"{this.Project.File.FileName} ({this.Project.File.ChangeDate.Value.ToLongDateString()})";
                this.tbDownloadFile.Foreground = Brushes.Green;
            }
            else
            {
                this.tbDownloadFile.Text = "Файл отсутствует";
                this.tbDownloadFile.Foreground = Brushes.IndianRed;
                this.sbDownLoad.IsEnabled = false;
            }
        }

        private void FillWorker()
        {
            var worker = this.Project.Worker;
            this.tbFIO.Text = $"{worker.Surname} {worker.Name} {worker.Patronymic}";
            this.tbDateOfBirth.Text = worker.DateOfBirth.ToLongDateString();
            this.tbPhone.Text = worker.Phone;
            this.tbDateOfEmploy.Text = worker.DateOfEmploy.ToLongDateString();
            this.tbPosition.Text = worker.Position.PositionName;
            this.tbEmail.Text = worker.User.Email;
            this.imgPhoto.Source = worker.ImgPhoto;
        }

        private void FillHistory()
        {
            if (this.History.Count == 0)
            {
                this.gbHistory.Header = "История изменения статусов на данный момент пуста";
                this.gcHistory.Visibility = Visibility.Collapsed;
                return;
            }

            this.gcHistory.ItemsSource = this.History;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.History = App.Service.GetHistoryProjects().Where(x => x.ProjectId == this.Project.Id).ToList();

            this.FillHistory();
            this.FillProject();
            this.FillWorker();
        }

        private void sbDownLoad_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var save = new SaveFileDialog
                {
                    Title = "Сохранить файл",
                    DefaultExt = this.Project.File.Title,
                    AddExtension = true,
                    FileName = this.Project.File.FileName
                };

                if (save.ShowDialog() == true)
                {
                    using (var stream = save.OpenFile())
                    {
                        stream.Write(this.Project.File.Data, 0, this.Project.File.Data.Length);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Возникло исключение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
