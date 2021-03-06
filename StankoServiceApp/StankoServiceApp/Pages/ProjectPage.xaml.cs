﻿using System;
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
using DevExpress.Xpf.Bars;
using DevExpress.Xpf.Editors;
using DevExpress.Xpf.Grid;
using DevExpress.Xpf.Printing;
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
        private bool IsDirector => App.CurrentUser.Worker == null;
        public bool IsPrint;

        public ProjectPage()
        {
            InitializeComponent();
        }

        private async void FillList()
        {
            if (this.IsDirector)
                this.ProjectList = await App.Service.GetProjectsAsync();
            else
                this.ProjectList = App.Service.GetProjects().Where(x => x.WorkerId == App.CurrentUser.Worker.Id).ToList();

            this.FillGc();
        }

        private void FillGc()
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
                this.gcProject.ItemsSource = this.ProjectList;
            }

            if (this.bbiFilterType.EditValue != null && this.bbiFilterStatus.EditValue == null)
            {
                this.gcProject.ItemsSource = this.ProjectList.Where(x => x.TypePeriodId == type).ToList();
            }

            if (this.bbiFilterType.EditValue == null && this.bbiFilterStatus.EditValue != null)
            {
                this.gcProject.ItemsSource = this.ProjectList.Where(x => x.StatusId == status).ToList();
            }

            if (this.bbiFilterType.EditValue != null && this.bbiFilterStatus.EditValue != null)
            {
                this.gcProject.ItemsSource = this.ProjectList.Where(x => x.TypePeriodId == type && x.StatusId == status).ToList();
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!this.IsDirector)
                {
                    this.bbiNewProject.IsVisible = false;
                    this.bbiEditProject.IsVisible = false;
                    this.bbiDeleteProject.IsVisible = false;
                }

                this.rbStatus.IsEnabled = false;
                this.bbiEditProject.IsEnabled = false;
                this.bbiDeleteProject.IsEnabled = false;
                this.bbiShowProject.IsEnabled = false;
                this.bbiDownload.IsEnabled = false;

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
                this.FillGc();
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
                    this.rbStatus.IsEnabled = false;
                    this.bbiEditProject.IsEnabled = false;
                    this.bbiDeleteProject.IsEnabled = false;
                    this.bbiShowProject.IsEnabled = false;
                    this.bbiDownload.IsEnabled = false;
                }
                else
                {
                    this.rbStatus.IsEnabled = true;
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
                this.FillGc();
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
                this.FillList();
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
                FillList();
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
                    Methods.SendMessageFromMainMail("Проект был удален", $"Проект '{this.SelectProject.Name}', руководителем которого вы являлись был удален из базы данных\nЧтобы получить более подробную информацию - зайдите в АИС Станкосервис", this.SelectProject.Worker.User.Email);
                }

                App.Service.DeleteProject(this.SelectProject);
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
            try
            {
                var statAll = new StatProjectWindow(App.Service.GetProjects());
                statAll.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Возникло исключение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void bbiStatFilter_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            try
            {
                var statAll = new StatProjectWindow(GetDataRowHandles());
                statAll.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Возникло исключение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private List<Project> GetDataRowHandles()
        {
            List<Project> rowHandles = new List<Project>();
            for (int i = 0; i < this.gcProject.VisibleRowCount; i++)
            {
                int rowHandle = this.gcProject.GetRowHandleByVisibleIndex(i);
                var item = this.gcProject.GetRow(rowHandle) as Project;
                if (this.gcProject.IsGroupRowHandle(rowHandle))
                {
                    if (!this.gcProject.IsGroupRowExpanded(rowHandle))
                    {
                        rowHandles.AddRange(GetDataRowHandlesInGroup(rowHandle));
                    }
                }
                else
                    rowHandles.Add(item);
            }
            return rowHandles;
        }
        private List<Project> GetDataRowHandlesInGroup(int groupRowHandle)
        {
            List<Project> rowHandles = new List<Project>();
            for (int i = 0; i < this.gcProject.GetChildRowCount(groupRowHandle); i++)
            {
                int rowHandle = this.gcProject.GetChildRowHandle(groupRowHandle, i);
                var item = this.gcProject.GetRow(rowHandle) as Project;

                if (this.gcProject.IsGroupRowHandle(rowHandle))
                {
                    rowHandles.AddRange(GetDataRowHandlesInGroup(rowHandle));
                }
                else
                    rowHandles.Add(item);
            }
            return rowHandles;
        }

        private void bbiShowProject_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            try
            {
                var show = new ShowProjectWindow(this.SelectProject);
                show.ShowDialog();
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
                FillList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Возникло исключение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EditStatus(StatusProject status)
        {
            try
            {
                if (this.SelectProject.StatusId == (int)status)
                {
                    MessageBox.Show("Это текущий статус проекта", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                var editStatus = new EditStatusWindow(this.SelectProject, status);
                editStatus.ShowDialog();
                FillList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Возникло исключение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void status0_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.EditStatus(StatusProject.Подготовка);
        }

        private void status1_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.EditStatus(StatusProject.Тестирование);
        }

        private void status2_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.EditStatus(StatusProject.Завершен);
        }

        private void status3_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.EditStatus(StatusProject.Проектирование);
        }

        private void status4_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.EditStatus(StatusProject.Внедрение);
        }

        private void status5_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.EditStatus(StatusProject.Отложен);
        }

        private void status6_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.EditStatus(StatusProject.Реализация);
        }

        private void status7_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.EditStatus(StatusProject.Сопровождение);
        }

        private void status8_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.EditStatus(StatusProject.Закрыт);
        }

        private void bbiStandartPrint_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                var print = new BeforePrintWindow(this);
                print.ShowDialog();

                if (this.IsPrint)
                {
                    if (this.column7.AllowPrinting)
                    {
                        this.tvProjects.BestFitColumn(this.column7);
                        this.column7.Visible = true;
                    }

                    PrintableControlLink link = new PrintableControlLink((TableView)this.gcProject.View);
                    var window = new DocumentPreviewWindow();
                    link.PageHeaderTemplate = (DataTemplate)Resources["PageHeader"];
                    window.PreviewControl.DocumentSource = link;
                    link.CreateDocument();
                    window.ShowDialog();

                    this.column7.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Возникло исключение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
