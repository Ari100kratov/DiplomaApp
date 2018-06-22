using DevExpress.Xpf.Grid;
using DevExpress.Xpf.Printing;
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
    /// Логика взаимодействия для WorkerWindow.xaml
    /// </summary>
    public partial class WorkerWindow : Window
    {
        public bool IsPrint;
        private List<ServiceReference.Task> ListTask = new List<ServiceReference.Task>();
        private ServiceReference.Task Task = null;

        public WorkerWindow()
        {
            InitializeComponent();
        }

        private void FillList()
        {
            this.ListTask = App.Service.GetTasks().Where(x => x.WorkerId == App.CurrentUser.Worker.Id || x.Worker == null).ToList();
            this.FillGc();
        }

        private void FillGc()
        {
            int status = 0;
            int priority = 0;

            if (this.bbiFilterStatus.EditValue != null)
            {
                status = (int)this.bbiFilterStatus.EditValue;
            }

            if (this.bbiFilterPriority.EditValue != null)
            {
                priority = (int)this.bbiFilterPriority.EditValue;
            }

            if (this.bbiFilterPriority.EditValue == null && this.bbiFilterStatus.EditValue == null)
            {
                this.gcTask.ItemsSource = this.ListTask;
            }

            if (this.bbiFilterPriority.EditValue != null && this.bbiFilterStatus.EditValue == null)
            {
                this.gcTask.ItemsSource = this.ListTask.Where(x => x.PriorityId == priority).ToList();
            }

            if (this.bbiFilterPriority.EditValue == null && this.bbiFilterStatus.EditValue != null)
            {
                this.gcTask.ItemsSource = this.ListTask.Where(x => x.StatusId == status).ToList();
            }

            if (this.bbiFilterPriority.EditValue != null && this.bbiFilterStatus.EditValue != null)
            {
                this.gcTask.ItemsSource = this.ListTask.Where(x => x.PriorityId == priority && x.StatusId == status).ToList();
            }
        }

        private void bbiClearFilter_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            try
            {
                this.bbiFilterPriority.EditValue = null;
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
                this.FillGc();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Возникло исключение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void bbiFilterPriority_EditValueChanged(object sender, RoutedEventArgs e)
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.bbiTakeTask.IsEnabled = false;
            this.bbiSolution.IsEnabled = false;
            this.bbiSend.IsEnabled = false;
            this.bbiShow.IsEnabled = false;

            this.FillList();
        }

        private void SelectRow()
        {
            if (this.Task == null)
            {
                this.bbiTakeTask.IsEnabled = false;
                this.bbiSolution.IsEnabled = false;
                this.bbiSend.IsEnabled = false;
                this.bbiShow.IsEnabled = false;
            }
            else
            {
                if (this.Task.Worker == null)
                {
                    this.bbiTakeTask.IsEnabled = true;

                    this.bbiSolution.IsEnabled = false;
                    this.bbiSend.IsEnabled = false;
                    this.bbiShow.IsEnabled = false;
                }
                else
                {
                    this.bbiTakeTask.IsEnabled = false;
                    this.bbiSolution.IsEnabled = true;
                    this.bbiSend.IsEnabled = true;
                    this.bbiShow.IsEnabled = true;
                }
            }
        }

        private void gcTask_CurrentItemChanged(object sender, DevExpress.Xpf.Grid.CurrentItemChangedEventArgs e)
        {
            try
            {
                this.Task = this.gcTask.CurrentItem as ServiceReference.Task;
                this.SelectRow();
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
                if (this.column7.AllowPrinting)
                {
                    this.tbTask.BestFitColumn(this.column7);
                    this.column7.Visible = true;
                }

                if (this.column8.AllowPrinting)
                {
                    this.tbTask.BestFitColumn(this.column8);
                    this.column8.Visible = true;
                }

                PrintableControlLink link = new PrintableControlLink((TreeListView)this.gcTask.View);
                var window = new DocumentPreviewWindow();
                window.PreviewControl.DocumentSource = link;
                link.CreateDocument();
                window.ShowDialog();

                this.column7.Visible = false;
                this.column8.Visible = false;
            }
        }

        private void bbiRefresh_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            this.FillList();
        }

        private void bbiShow_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            try
            {
                var show = new ShowTaskWindow(this.Task);
                show.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Возникло исключение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void bbiStat_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            var worker = new List<Worker>();
            worker.Add(App.CurrentUser.Worker);
            var stat = new StatWorkerWindow(worker);
            stat.ShowDialog();
        }

        private void bbiProfile_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            var prof = new ProfileWindow();
            prof.ShowDialog();
        }

        private void bbiSolution_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            var sol = new EditSolutionWindow(this.Task);
            sol.ShowDialog();

            this.FillList();
        }

        private void bbiTakeTask_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите стать исполнителем выбранной задачи?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
            {
                return;
            }

            App.Service.TakeTask(this.Task, App.CurrentUser);
            this.FillList();
        }

        private void bbiInWork_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            var edit = new EditStatusWindow(this.Task, StatusTask.Выполняется);
            edit.ShowDialog();
            this.FillList();
        }

        private void bbiSend_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            var edit = new EditStatusWindow(this.Task, StatusTask.Подтверждается);
            edit.ShowDialog();
            this.FillList();
        }
    }
}
