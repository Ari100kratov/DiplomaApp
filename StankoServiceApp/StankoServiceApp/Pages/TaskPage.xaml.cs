using DevExpress.Xpf.Grid;
using DevExpress.Xpf.Printing;
using StankoServiceApp.ServiceReference;
using StankoServiceApp.Windows;
using StankoserviceEnums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
        private bool IsDirector => App.CurrentUser.Worker == null;
        public bool IsPrint;

        public TaskPage()
        {
            InitializeComponent();
        }

        private async void FillList()
        {
            if (this.IsDirector)
                this.ListTask = await App.Service.GetTasksAsync();
            else
                this.ListTask = App.Service.GetTasks().Where(x => x.ManagerId == App.CurrentUser.Id).ToList();

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
                this.bbiSolution.IsEnabled = false;
                this.rpgPriority.IsEnabled = false;
                this.rpgStatus.IsEnabled = false;
                this.bbiEditTask.IsEnabled = false;
                this.bbiDeleteTask.IsEnabled = false;
                this.bbiShowTask.IsEnabled = false;
                this.FillList();
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

        private void SelectRow()
        {
            if (this.Task == null)
            {
                this.rpgPriority.IsEnabled = false;
                this.rpgStatus.IsEnabled = false;
                this.bbiEditTask.IsEnabled = false;
                this.bbiDeleteTask.IsEnabled = false;
                this.bbiShowTask.IsEnabled = false;
                this.bbiSolution.IsEnabled = false;
            }
            else
            {
                this.bbiEditTask.IsEnabled = true;
                this.bbiDeleteTask.IsEnabled = true;
                this.bbiShowTask.IsEnabled = true;
                this.rpgStatus.IsEnabled = true;
                this.rpgPriority.IsEnabled = true;

                if (this.Task.Solution != null)
                    this.bbiSolution.IsEnabled = true;
                else
                    this.bbiSolution.IsEnabled = false;
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

        private void bbiNewTask_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            try
            {
                var addTask = new EditTaskWindow();
                addTask.ShowDialog();
                this.FillList();
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
                this.FillList();
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

        private async void bbiDeleteTask_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            try
            {
                if (MessageBox.Show($"Вы действительно хотите удалить задачу: {this.Task.TaskName}?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                {
                    return;
                }

                if (this.Task.Worker == null)
                {
                    return;
                }

                if (MessageBox.Show("Хотите отправить сотруднику письмо уведомления на почту?", "Отправка", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    Methods.SendMessageFromMainMail("Задача удалена", $"Задача '{this.Task.TaskName}', исполнителем которой вы являлись, была удалена из базы данных\nЧтобы получить более подробную информацию - зайдите в АИС Станкосервис", this.Task.Worker.User.Email);
                }

                await App.Service.DeleteTaskAsync(this.Task);
                this.FillList();
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

        private void EditStatus(StatusTask status)
        {
            try
            {
                if (this.Task.StatusId == (int)status)
                {
                    MessageBox.Show("Это текущий статус задачи", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                for (var i = 0; i < this.Task.Childs.Count(); i++)
                {
                    if (this.Task.Childs[i].StatusId != (int)StatusTask.Выполнена)
                    {
                        MessageBox.Show("Необходимо выполнить все подзадачи", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }
                }

                var editStatus = new EditStatusWindow(this.Task, status);
                editStatus.ShowDialog();
                this.FillList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Возникло исключение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Editpriority(PriorityTask prior)
        {
            try
            {
                if (this.Task.PriorityId == (int)prior)
                {
                    MessageBox.Show("Это текущий приоритет задачи задачи", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                if (MessageBox.Show($"Поменять приоритет задачи на {prior.ToString()}", "Подтверждение", MessageBoxButton.YesNo) == MessageBoxResult.No)
                {
                    return;
                }

                App.Service.EditPriorityTask(this.Task, (int)prior);
                this.FillList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Возникло исключение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void status1_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            this.EditStatus(StatusTask.Новая);
        }

        private void status2_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            this.EditStatus(StatusTask.Выполняется);
        }

        private void status6_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            this.EditStatus(StatusTask.Подтверждается);
        }

        private void status5_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            this.EditStatus(StatusTask.Выполнена);
        }

        private void status4_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            this.EditStatus(StatusTask.Отложена);
        }

        private void status3_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            this.EditStatus(StatusTask.Отменена);
        }

        private void prior6_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            this.Editpriority(PriorityTask.Отложенный);
        }

        private void prior5_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            this.Editpriority(PriorityTask.Низкий);
        }

        private void prior4_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            this.Editpriority(PriorityTask.Нормальный);
        }

        private void prior3_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            this.Editpriority(PriorityTask.Высокий);
        }

        private void prior2_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            this.Editpriority(PriorityTask.Срочный);
        }

        private void prior1_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            this.Editpriority(PriorityTask.Неотложный);
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

        private void bbiSolution_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            var sol = new ShowSolutionWindow(this.Task);
            sol.ShowDialog();
            this.FillList();
        }
    }
}
