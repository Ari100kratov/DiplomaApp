using StankoServiceApp.ServiceReference;
using StankoServiceApp.Windows;
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

        public WorkerPage()
        {
            InitializeComponent();
        }

        private async void FillGc()
        {
            this.ListWorkers = await App.Service.GetWorkersAsync();
            this.gcWorker.ItemsSource = this.ListWorkers;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            this.FillGc();
        }

        private void bbiNewWorker_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            try
            {
                var newWorker = new EditWorkerWindow();
                newWorker.ShowDialog();
                this.FillGc();
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
                }
                else
                {
                    this.bbiEditWorker.IsEnabled = true;
                    this.bbiDeleteWorker.IsEnabled = true;
                    this.bbiTasks.IsEnabled = true;
                    this.bbiProjects.IsEnabled = true;
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
                this.FillGc();
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
                this.FillGc();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Возникло исключение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
