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
    /// Логика взаимодействия для SelectWorkerWindow.xaml
    /// </summary>
    public partial class SelectWorkerWindow : Window
    {
        private EditProjectWindow EditProject = new EditProjectWindow();
        private EditTaskWindow EditTask = new EditTaskWindow();
        private Worker Worker = null;

        public SelectWorkerWindow(EditTaskWindow editTask, EditProjectWindow editProject = null)
        {
            InitializeComponent();
            this.EditProject = editProject;
            this.EditTask = editTask;
        }

        public SelectWorkerWindow(EditProjectWindow editProject, EditTaskWindow editTask = null)
        {
            InitializeComponent();
            this.EditTask = editTask;
            this.EditProject = editProject;
        }

        private void ShowCurrent()
        {
            if (this.EditTask != null)
            {
                this.seriesSimple.Points.Clear();
                this.gbTask.Visibility = Visibility.Visible;

                var list = App.Service.GetTasks().Where(x => x.WorkerId == this.Worker.Id).ToList();
                this.gcTask.ItemsSource = list.Where(x => x.StatusId != (int)StatusTask.Выполнена && x.StatusId != (int)StatusTask.Отложена && x.StatusId != (int)StatusTask.Отменена).ToList();

                this.gbInfoWorker.Visibility = Visibility.Visible;

                this.tbCountTask.Text = $"{list.Count().ToString()}";
                this.tb02.Text = $"{list.Where(x => x.StatusId == (int)StatusTask.Выполняется).Count()}";
                this.tb03.Text = $"{list.Where(x => x.StatusId == (int)StatusTask.Отменена).Count()}";
                this.tb04.Text = $"{list.Where(x => x.StatusId == (int)StatusTask.Отложена).Count()}";
                this.tb05.Text = $"{list.Where(x => x.StatusId == (int)StatusTask.Выполнена).Count()}";
                this.tb06.Text = $"{list.Where(x => x.StatusId == (int)StatusTask.Подтверждается).Count()}";

                var stat = list.Where(x => x.EndDate != null).ToList();
                var plus = 0;
                var minus = 0;

                for (var i = 0; i < stat.Count(); i++)
                {
                    if (stat[i].CompletionDate == null)
                    {
                        if (DateTime.Now > stat[i].EndDate)
                        {
                            minus++;
                        }
                    }
                    else
                    {
                        if (stat[i].CompletionDate <= stat[i].EndDate)
                        {
                            plus++;
                        }
                        else
                        {
                            minus++;
                        }
                    }
                }

                this.seriesSimple.AddPoint("Заврешенные в срок", plus);
                this.seriesSimple.AddPoint("С опозданием", minus);
            }
            else
            {
                this.seriesSimple.Points.Clear();
                this.gbInfoManager.Visibility = Visibility.Visible;
                this.gbProject.Visibility = Visibility.Visible;
                var list = App.Service.GetProjects().Where(x => x.WorkerId == this.Worker.Id).ToList();

                this.gcProject.ItemsSource = list.Where(x => x.StatusId != (int)StatusProject.Завершен && x.StatusId != (int)StatusProject.Закрыт && x.StatusId != (int)StatusProject.Отложен).ToList();

                this.tbAllProject.Text = list.Count().ToString();
                this.tbCurrent.Text = list.Where(x => x.StatusId != (int)StatusProject.Завершен && x.StatusId != (int)StatusProject.Закрыт && x.StatusId != (int)StatusProject.Отложен).Count().ToString();
                this.tb07.Text = list.Where(x => x.StatusId == (int)StatusProject.Завершен).Count().ToString();
                this.tb08.Text = list.Where(x => x.StatusId == (int)StatusProject.Отложен).Count().ToString();
                this.tb09.Text = list.Where(x => x.StatusId == (int)StatusProject.Закрыт).Count().ToString();

                var listTask = App.Service.GetTasks().Where(x => x.ManagerId == this.Worker.User.Id).ToList();
                this.tbCountCreateTask.Text = listTask.Count().ToString();
                var countApply = listTask.Where(x => x.StatusId == (int)StatusTask.Выполнена).Count();
                this.tbCountApplyTask.Text = $"{Math.Round((double)((listTask.Count() / 100) * countApply), 2)}";


                var stat = list.Where(x => x.EndDate != null).ToList();
                var plus = 0;
                var minus = 0;

                for (var i = 0; i < stat.Count(); i++)
                {
                    if (stat[i].CompletionDate == null)
                    {
                        if (DateTime.Now > stat[i].EndDate)
                        {
                            minus++;
                        }
                    }
                    else
                    {
                        if (stat[i].CompletionDate <= stat[i].EndDate)
                        {
                            plus++;
                        }
                        else
                        {
                            minus++;
                        }
                    }
                }

                this.seriesSimple.AddPoint("Заврешенные в срок", plus);
                this.seriesSimple.AddPoint("С опозданием", minus);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.EditTask == null)
                {
                    this.gcWorker.ItemsSource = App.Service.GetWorkers().Where(x => x.User.RoleId == (int)Role.Менеджер).ToList();
                }
                else
                {
                    this.gcWorker.ItemsSource = App.Service.GetWorkers().Where(x => x.User.RoleId == (int)Role.Исполнитель).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Возникло исключение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void sbCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void sbSelect_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.Worker == null)
                {
                    MessageBox.Show("Выберите сотрудника!", "Сообщение об ошибке", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (this.EditTask == null)
                {
                    this.EditProject.Worker = this.Worker;
                }
                else
                {
                    this.EditTask.Worker = this.Worker;
                }

                this.Close();
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

                if (this.Worker != null)
                {
                    this.ShowCurrent();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Возникло исключение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
