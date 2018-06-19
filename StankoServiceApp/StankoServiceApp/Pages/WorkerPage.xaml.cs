using DevExpress.Xpf.Grid;
using DevExpress.Xpf.Printing;
using Microsoft.Win32;
using StankoServiceApp.ServiceReference;
using StankoServiceApp.Windows;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StankoServiceApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для WorkerPage.xaml
    /// </summary>
    public partial class WorkerPage : Page
    {
        private Worker Worker = null;
        private List<Worker> ListWorkers = new List<Worker>();
        private bool IsDirector => App.CurrentUser.Worker == null;

        public WorkerPage()
        {
            InitializeComponent();
        }

        private async System.Threading.Tasks.Task FillList()
        {
            if (this.IsDirector)
                this.ListWorkers = await App.Service.GetWorkersAsync();
            else
                this.ListWorkers = App.Service.GetWorkers().Where(x => x.User.RoleId == (int)Role.Исполнитель).ToList();

            this.FillGc();
        }

        private void FillGc()
        {
            if (this.bbiFilterRole.EditValue == null && this.bbiFilterPosition.EditValue == null)
            {
                this.gcWorker.ItemsSource = this.ListWorkers;
            }

            if (this.bbiFilterPosition.EditValue != null && this.bbiFilterRole.EditValue == null)
            {
                this.gcWorker.ItemsSource = this.ListWorkers.Where(x => x.PositionId == (int)this.bbiFilterPosition.EditValue).ToList();
            }

            if (this.bbiFilterPosition.EditValue == null && this.bbiFilterRole.EditValue != null)
            {
                this.gcWorker.ItemsSource = this.ListWorkers.Where(x => x.User.RoleUser == (Role)this.bbiFilterRole.EditValue).ToList();
            }

            if (this.bbiFilterPosition.EditValue != null && this.bbiFilterRole.EditValue != null)
            {
                this.gcWorker.ItemsSource = this.ListWorkers.Where(x => x.PositionId == (int)this.bbiFilterPosition.EditValue && x.User.RoleUser == (Role)this.bbiFilterRole.EditValue).ToList();
            }
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!this.IsDirector)
                {
                    this.bbiFilterRole.IsVisible = false;
                    this.bbiDeleteWorker.IsVisible = false;
                }

                this.cbFilterPosition.ItemsSource = await App.Service.GetPositionsAsync();
                this.cbFilterPosition.DisplayMember = "PositionName";
                this.cbFilterPosition.ValueMember = "Id";

                this.bbiEditWorker.IsEnabled = false;
                this.bbiDeleteWorker.IsEnabled = false;
                this.bbiTasks.IsEnabled = false;
                this.bbiProjects.IsEnabled = false;
                this.bbiDownload.IsEnabled = false;

                await this.FillList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Возникло исключение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void bbiNewWorker_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            try
            {
                var newWorker = new EditWorkerWindow();
                newWorker.ShowDialog();
                await this.FillList();
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

                if (this.Worker == null)
                {

                    this.bbiEditWorker.IsEnabled = false;
                    this.bbiDeleteWorker.IsEnabled = false;
                    this.bbiTasks.IsEnabled = false;
                    this.bbiProjects.IsEnabled = false;
                    this.bbiDownload.IsEnabled = false;
                }
                else
                {

                    this.bbiEditWorker.IsEnabled = true;
                    this.bbiDeleteWorker.IsEnabled = true;
                    this.bbiTasks.IsEnabled = true;
                    this.bbiProjects.IsEnabled = true;

                    if (this.Worker.Resume == null)
                    {
                        this.bbiDownload.IsEnabled = false;
                    }
                    else
                    {
                        this.bbiDownload.IsEnabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Возникло исключение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void bbiEditWorker_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            try
            {
                var editWorker = new EditWorkerWindow(this.Worker);
                editWorker.ShowDialog();
                await this.FillList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Возникло исключение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void bbiDeleteWorker_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            try
            {
                if (MessageBox.Show($"Вы действительно хотите удалить сотрудника: {this.Worker.FullName}?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                {
                    return;
                }

                await App.Service.DeleteWorkerAsync(this.Worker);
                await this.FillList();
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
                    DefaultExt = this.Worker.Resume.Title,
                    AddExtension = true,
                    FileName = this.Worker.Resume.FileName
                };

                if (save.ShowDialog() == true)
                {
                    using (var stream = save.OpenFile())
                    {
                        stream.Write(this.Worker.Resume.Data, 0, this.Worker.Resume.Data.Length);
                    }
                }
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
                this.bbiFilterPosition.EditValue = null;
                this.bbiFilterRole.EditValue = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Возникло исключение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void bbiFilterPosition_EditValueChanged(object sender, RoutedEventArgs e)
        {
            try
            {
                this.FillGc();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Возникло исключение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void bbiFilterRole_EditValueChanged(object sender, RoutedEventArgs e)
        {
            try
            {
                this.FillGc();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Возникло исключение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void bbiRefresh_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            try
            {
                await this.FillList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Возникло исключение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void bbiStandartPrint_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            PrintableControlLink link = new PrintableControlLink((CardView)this.gcWorker.View);
            var window = new DocumentPreviewWindow();
            window.PreviewControl.DocumentSource = link;
            link.CreateDocument();
            window.ShowDialog();
        }
    }
}
