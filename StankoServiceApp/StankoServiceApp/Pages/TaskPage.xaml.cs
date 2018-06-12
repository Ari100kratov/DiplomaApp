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
    /// Логика взаимодействия для TaskPage.xaml
    /// </summary>
    public partial class TaskPage : Page
    {
        private List<ServiceReference.Task> ListTask = new List<ServiceReference.Task>();
        private ServiceReference.Task Task = null;

        public TaskPage()
        {
            InitializeComponent();
        }

        private async void FillListDirector()
        {
            this.ListTask = await App.Service.GetTasksAsync();
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

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                this.FillListDirector();
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

        private void gcTask_CurrentItemChanged(object sender, DevExpress.Xpf.Grid.CurrentItemChangedEventArgs e)
        {
            try
            {
                this.Task = this.gcTask.CurrentItem as ServiceReference.Task;

                if (this.Task == null)
                {
                    this.bbiEditTask.IsEnabled = false;
                    this.bbiDeleteTask.IsEnabled = false;
                    this.bbiShowTask.IsEnabled = false;
                    this.rpgStatus.IsEnabled = false;
                }
                else
                {
                    this.bbiEditTask.IsEnabled = true;
                    this.bbiDeleteTask.IsEnabled = true;
                    this.bbiShowTask.IsEnabled = true;
                    this.rpgStatus.IsEnabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Возникло исключение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void bbiNewTask_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            try
            {
                var addTask = new EditTaskWindow();
                addTask.ShowDialog();
                this.FillListDirector();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Возникло исключение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void bbiEditTask_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            try
            {
                var editTask = new EditTaskWindow(this.Task);
                editTask.ShowDialog();
                this.FillListDirector();
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
                this.FillListDirector();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Возникло исключение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void bbiDeleteTask_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            try
            {
                if (MessageBox.Show($"Вы действительно хотите удалить задачу: {this.Task.TaskName}?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                {
                    return;
                }

                if (this.Task.Worker != null)
                {
                    if (MessageBox.Show("Хотите отправить сотруднику письмо уведомления на почту?", "Отправка", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        Methods.SendMessageFromMainMail("Задача удалена", $"Задача '{this.Task.TaskName}', исполнителем которой вы являлись, была удалена из базы данных\nЧтобы получить более подробную информацию - зайдите в АИС Станкосервис", this.Task.Worker.User.Email);
                    }
                }

                await App.Service.DeleteTaskAsync(this.Task);
                this.FillListDirector();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Возникло исключение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void bbiShowTask_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
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
    }
}
