using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using DevExpress.Xpf.Editors;
using Microsoft.Win32;
using StankoServiceApp.ServiceReference;
using StankoServiceApp.Windows;
using StankoserviceEnums;

namespace StankoServiceApp
{
    /// <summary>
    /// Логика взаимодействия для ProjectPage.xaml
    /// </summary>
    public partial class ProjectPage : Page
    {
        List<Project> ProjectList = new List<Project>();
        Project SelectProject = null;

        public ProjectPage()
        {
            InitializeComponent();
        }

        private void FillDgv()
        {
            int status = 0;
            int type = 0;

            if (this.bbiFilterStatus.EditValue != null)
            {
                status = (int)this.bbiFilterStatus.EditValue;
            }

            if (this.bbiFilterType.EditValue != null)
            {
                type = (int)this.bbiFilterType.EditValue;
            }


            if (this.bbiFilterStatus.EditValue == null && this.bbiFilterType.EditValue == null)
            {
                this.ProjectList = App.Service.GetProjects();
            }

            if (this.bbiFilterType.EditValue != null && this.bbiFilterStatus.EditValue == null)
            {
                this.ProjectList = App.Service.GetProjects().Where(x => x.TypePeriodId == type).ToList();
            }

            if (this.bbiFilterType.EditValue == null && this.bbiFilterStatus.EditValue != null)
            {
                this.ProjectList = App.Service.GetProjects().Where(x => x.StatusId == status).ToList();
            }

            if (this.bbiFilterType.EditValue != null && this.bbiFilterStatus.EditValue != null)
            {
                this.ProjectList = App.Service.GetProjects().Where(x => x.TypePeriodId == type && x.StatusId == status).ToList();
            }

            this.gcProject.ItemsSource = this.ProjectList;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                this.FillDgv();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Возникло исключение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void bbiClearFilter_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            try
            {
                this.bbiFilterType.EditValue = null;
                this.bbiFilterStatus.EditValue = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Возникло исключение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void bbiFilterStatus_EditValueChanged(object sender, RoutedEventArgs e)
        {
            try
            {
                this.FillDgv();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Возникло исключение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void bbiFilterManager_EditValueChanged(object sender, RoutedEventArgs e)
        {
            try
            {
                this.FillDgv();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Возникло исключение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void gcProject_CurrentItemChanged(object sender, DevExpress.Xpf.Grid.CurrentItemChangedEventArgs e)
        {
            try
            {
                this.SelectProject = this.gcProject.CurrentItem as Project;

                if (this.SelectProject == null)
                {
                    this.bbiEditProject.IsEnabled = false;
                    this.bbiDeleteProject.IsEnabled = false;
                    this.bbiShowProject.IsEnabled = false;
                    this.bbiHistory.IsEnabled = false;
                    this.bbiDownload.IsEnabled = false;
                }
                else
                {
                    this.bbiHistory.IsEnabled = true;
                    this.bbiEditProject.IsEnabled = true;
                    this.bbiDeleteProject.IsEnabled = true;
                    this.bbiShowProject.IsEnabled = true;

                    if (this.SelectProject.File == null)
                        this.bbiDownload.IsEnabled = false;
                    else
                        this.bbiDownload.IsEnabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Возникло исключение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void bbiFilterType_EditValueChanged(object sender, RoutedEventArgs e)
        {
            try
            {
                this.FillDgv();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Возникло исключение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void bbiNewProject_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            try
            {
                var newProject = new Windows.EditProjectWindow();
                newProject.ShowDialog();
                this.FillDgv();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Возникло исключение", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void bbiEditProject_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            try
            {
                var editProject = new Windows.EditProjectWindow(this.SelectProject);
                editProject.ShowDialog();
                this.gcProject.RefreshData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Возникло исключение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void bbiDeleteProject_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            try
            {
                if (MessageBox.Show($"Вы действительно хотите удалить проект '{this.SelectProject.Name}'?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                {
                    return;
                }

                if (MessageBox.Show("Хотите отправить сотруднику письмо уведомления на почту?", "Отправка", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    WorkWithMail.SendMessageFromMainMail("Проект был удален", $"Проект '{this.SelectProject.Name}', руководителем которого вы являлись был удален из базы данных\nЧтобы получить более подробную информацию - зайдите в АИС Станкосервис", this.SelectProject.Worker.User.Email);
                }

                App.Service.DeleteProject(this.SelectProject);
                this.FillDgv();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Возникло исключение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void bbiDownload_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            try
            {
                var save = new SaveFileDialog
                {
                    Title = "Сохранить файл",
                    DefaultExt = this.SelectProject.File.Title,
                    AddExtension = true,
                    FileName = this.SelectProject.File.FileName
                };

                if (save.ShowDialog() == true)
                {
                    using (var stream = save.OpenFile())
                    {
                        stream.Write(this.SelectProject.File.Data, 0, this.SelectProject.File.Data.Length);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Возникло исключение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void bbiStatAll_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            var statAll = new StatProjectWindow(App.Service.GetProjects());
            statAll.ShowDialog();

        }

        private void bbiStatFilter_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            var statAll = new StatProjectWindow(GetDataRowHandles());
            statAll.ShowDialog();
        }

        private List<Project> GetDataRowHandles()
        {
            List<Project> rowHandles = new List<Project>();
            for (int i = 0; i < this.gcProject.VisibleRowCount; i++)
            {
                var rowHandle = this.gcProject.GetRowByListIndex(i) as Project;
                rowHandles.Add(rowHandle);
            }
            return rowHandles;
        }

        private void bbiShowProject_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            var show = new ShowProjectWindow(this.SelectProject);
            show.ShowDialog();
        }
    }
}
