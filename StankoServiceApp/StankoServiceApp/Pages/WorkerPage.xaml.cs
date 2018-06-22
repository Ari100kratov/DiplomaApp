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
        public bool IsPrint;

        public WorkerPage()
        {
            InitializeComponent();
        }

        private void FillList()
        {
            if (this.IsDirector)
                this.ListWorkers = App.Service.GetWorkers();
            else
                this.ListWorkers = App.Service.GetWorkers().Where(x => x.User.RoleId == (int)Role.Исполнитель).ToList();

            this.FillGc();
        }

        private void FillGc()
        {
            this.gcWorker.BeginDataUpdate();
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
            this.gcWorker.EndDataUpdate();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!this.IsDirector)
                {
                    this.bbiFilterRole.IsVisible = false;
                    this.bbiDeleteWorker.IsVisible = false;
                }

                this.cbFilterPosition.ItemsSource = App.Service.GetPositions();
                this.cbFilterPosition.DisplayMember = "PositionName";
                this.cbFilterPosition.ValueMember = "Id";

                this.bbiEditWorker.IsEnabled = false;
                this.bbiDeleteWorker.IsEnabled = false;
                this.bbiTasks.IsEnabled = false;
                this.bbiProjects.IsEnabled = false;
                this.bbiDownload.IsEnabled = false;

                this.FillList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Возникло исключение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void bbiNewWorker_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            try
            {
                var newWorker = new EditWorkerWindow();
                newWorker.ShowDialog();
                this.FillList();
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

        private void bbiEditWorker_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            try
            {
                var editWorker = new EditWorkerWindow(this.Worker);
                editWorker.ShowDialog();
                this.FillList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Возникло исключение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void bbiDeleteWorker_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            try
            {
                if (MessageBox.Show($"Вы действительно хотите удалить сотрудника: {this.Worker.FullName}?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                {
                    return;
                }

                App.Service.DeleteWorker(this.Worker);
                this.FillList();
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

        private void bbiRefresh_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            try
            {
                this.FillList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Возникло исключение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void bbiStandartPrint_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            var print = new BeforePrintWindow(this);
            print.ShowDialog();

            if (this.IsPrint)
            {
                PrintableControlLink link = new PrintableControlLink((CardView)this.gcWorker.View);
                var window = new DocumentPreviewWindow();
                window.PreviewControl.DocumentSource = link;
                link.CreateDocument();
                window.ShowDialog();
            }
        }

        private List<Worker> GetDataRowHandles()
        {
            List<Worker> rowHandles = new List<Worker>();
            for (int i = 0; i < this.gcWorker.VisibleRowCount; i++)
            {
                int rowHandle = this.gcWorker.GetRowHandleByVisibleIndex(i);
                var item = this.gcWorker.GetRow(rowHandle) as Worker;
                if (this.gcWorker.IsGroupRowHandle(rowHandle))
                {
                    if (!this.gcWorker.IsGroupRowExpanded(rowHandle))
                    {
                        rowHandles.AddRange(GetDataRowHandlesInGroup(rowHandle));
                    }
                }
                else
                    rowHandles.Add(item);
            }
            return rowHandles;
        }
        private List<Worker> GetDataRowHandlesInGroup(int groupRowHandle)
        {
            List<Worker> rowHandles = new List<Worker>();
            for (int i = 0; i < this.gcWorker.GetChildRowCount(groupRowHandle); i++)
            {
                int rowHandle = this.gcWorker.GetChildRowHandle(groupRowHandle, i);
                var item = this.gcWorker.GetRow(rowHandle) as Worker;

                if (this.gcWorker.IsGroupRowHandle(rowHandle))
                {
                    rowHandles.AddRange(GetDataRowHandlesInGroup(rowHandle));
                }
                else
                    rowHandles.Add(item);
            }
            return rowHandles;
        }

        private void bbiStatAll_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            var statAll = new StatWorkerWindow(this.ListWorkers);
            statAll.ShowDialog();
        }

        private void bbiStatFilter_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            var statFilter = new StatWorkerWindow(this.GetDataRowHandles());
            statFilter.ShowDialog();
        }
    }
}
