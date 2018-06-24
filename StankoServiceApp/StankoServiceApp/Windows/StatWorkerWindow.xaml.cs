using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Win32;
using StankoServiceApp.ServiceReference;
using StankoserviceEnums;

namespace StankoServiceApp.Windows
{
    /// <summary>
    /// Логика взаимодействия для StatWorkerWindow.xaml
    /// </summary>
    public partial class StatWorkerWindow : Window
    {
        List<Worker> ListWorker = new List<Worker>();
        List<Task> ListTask = new List<Task>();
        private bool IsWorker = true;

        public StatWorkerWindow(List<Worker> list)
        {
            InitializeComponent();
            this.ListWorker = list;
        }

        public void FillTaskList()
        {
            var task = App.Service.GetTasks();
            this.ListTask.Clear();

            if (this.IsWorker)
            {
                var list = this.ListWorker.Where(x => x.User.RoleId == (int)Role.Исполнитель).ToList();

                foreach (var item in list)
                {
                    this.ListTask.AddRange(task.Where(x => x.WorkerId == item.Id));
                }
            }
            else
            {
                var list = this.ListWorker.Where(x => x.User.RoleId == (int)Role.Менеджер).ToList();

                foreach (var item in list)
                {
                    this.ListTask.AddRange(task.Where(x => x.ManagerId == item.User.Id));
                }
            }

            this.FillStat();
        }

        public void FillStat()
        {
            this.seriesStatus1.Points.Clear();
            this.seriesStatus2.Points.Clear();
            this.seriesStatus3.Points.Clear();
            this.seriesStatus4.Points.Clear();
            this.seriesStatus5.Points.Clear();
            this.seriesStatus6.Points.Clear();

            this.seriesSimple.Points.Clear();
            this.SeriesActvity.Points.Clear();
            this.SeriesFalse.Points.Clear();

            //
            this.seriesStatus1.AddPoint("Новая", this.ListTask.Where(x => x.GetStatusTask == StatusTask.Новая).Count());
            this.seriesStatus2.AddPoint("В работе", this.ListTask.Where(x => x.GetStatusTask == StatusTask.Выполняется).Count());
            this.seriesStatus3.AddPoint("Отменена", this.ListTask.Where(x => x.GetStatusTask == StatusTask.Отменена).Count());
            this.seriesStatus4.AddPoint("Отложена", this.ListTask.Where(x => x.GetStatusTask == StatusTask.Отложена).Count());
            this.seriesStatus5.AddPoint("Выполнена", this.ListTask.Where(x => x.GetStatusTask == StatusTask.Выполнена).Count());
            this.seriesStatus6.AddPoint("Подтверждается", this.ListTask.Where(x => x.GetStatusTask == StatusTask.Подтверждается).Count());
            //

            var stat = this.ListTask.Where(x => x.EndDate != null).ToList();
            if (stat.Count() != 0)
            {
                var plus = 0;
                var minus = 0;

                for (var i = 0; i < stat.Count(); i++)
                {
                    if (stat[i].CompletionDate == null)
                    {
                        if (DateTime.Now > stat[i].EndDate)
                            minus++;
                    }
                    else
                    {
                        if (stat[i].CompletionDate <= stat[i].EndDate)
                            plus++;
                        else
                            minus++;
                    }
                }

                this.seriesSimple.AddPoint("Заврешенные в срок", plus);
                this.seriesSimple.AddPoint("С опозданием", minus);
            }
            //
            this.tbTotalTaskEnd.Text = $"Всего выполнено задач: {this.ListTask.Where(x => x.GetStatusTask == StatusTask.Выполнена).Count()}";
            //

            var listComp = this.ListTask.Where(x => x.CompletionDate != null).ToList();
            if (listComp.Count() != 0)
            {
                var lastYear = DateTime.Now.AddYears(-1);

                foreach (var item in EachMonth(lastYear.AddMonths(1), DateTime.Now.AddMonths(1)))
                {
                    var CountTrue = listComp.Where(x => x.CompletionDate.Value.Month == item.Month && x.GetStatusTask == StatusTask.Выполнена).Count();
                    this.SeriesActvity.AddPoint(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(item.Month), CountTrue);

                    var countFalse = listComp.Where(x => x.CompletionDate.Value.Month == item.Month && x.GetStatusTask == StatusTask.Отменена).Count();
                    this.SeriesFalse.AddPoint(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(item.Month), countFalse);
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.ListWorker.Count() == 1)
                {
                    this.rpg.IsVisible = false;
                    var worker = this.ListWorker[0];

                    if (worker.User.RoleId == (int)Role.Менеджер)
                    {
                        this.IsWorker = false;
                    }
                    else
                    {
                        this.IsWorker = true;
                    }
                }

                if (App.CurrentUser.RoleId == (int)Role.Менеджер)
                {
                    this.rpg.IsVisible = false;
                }

                this.FillTaskList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Возникло исключение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public IEnumerable<DateTime> EachMonth(DateTime from, DateTime thru)
        {
            for (var month = from.Date; month.Date <= thru.Date; month = month.AddMonths(1))
                yield return month;
        }

        private void img_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            try
            {
                var save = new SaveFileDialog();

                save.Title = "Как сохранить файл";
                if (save.ShowDialog() == true)
                {

                    switch (this.dxTab.SelectedIndex)
                    {
                        case (0):
                            this.chartCommon.ExportToImage(save.FileName);
                            break;
                        case (1):
                            this.chartTerm.ExportToImage(save.FileName);
                            break;
                        case (2):
                            this.chartActivity.ExportToImage(save.FileName);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Возникло исключение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void mht_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            try
            {
                var save = new SaveFileDialog();
                save.DefaultExt = "mht";

                save.Title = "Как сохранить файл";
                if (save.ShowDialog() == true)
                {

                    switch (this.dxTab.SelectedIndex)
                    {
                        case (0):
                            this.chartCommon.ExportToMht(save.FileName);
                            break;
                        case (1):
                            this.chartTerm.ExportToMht(save.FileName);
                            break;
                        case (2):
                            this.chartActivity.ExportToMht(save.FileName);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Возникло исключение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void pdf_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            try
            {
                var save = new SaveFileDialog();
                save.DefaultExt = "pdf";

                save.Title = "Как сохранить файл";
                if (save.ShowDialog() == true)
                {

                    switch (this.dxTab.SelectedIndex)
                    {
                        case (0):
                            this.chartCommon.ExportToPdf(save.FileName);
                            break;
                        case (1):
                            this.chartTerm.ExportToPdf(save.FileName);
                            break;
                        case (2):
                            this.chartActivity.ExportToPdf(save.FileName);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Возникло исключение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void rtf_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            try
            {
                var save = new SaveFileDialog();
                save.DefaultExt = "rtf";

                save.Title = "Как сохранить файл";
                if (save.ShowDialog() == true)
                {

                    switch (this.dxTab.SelectedIndex)
                    {
                        case (0):
                            this.chartCommon.ExportToRtf(save.FileName);
                            break;
                        case (1):
                            this.chartTerm.ExportToRtf(save.FileName);
                            break;
                        case (2):
                            this.chartActivity.ExportToRtf(save.FileName);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Возникло исключение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void xls_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            try
            {
                var save = new SaveFileDialog();
                save.DefaultExt = "xls";

                save.Title = "Как сохранить файл";
                if (save.ShowDialog() == true)
                {

                    switch (this.dxTab.SelectedIndex)
                    {
                        case (0):
                            this.chartCommon.ExportToXls(save.FileName);
                            break;
                        case (1):
                            this.chartTerm.ExportToXls(save.FileName);
                            break;
                        case (2):
                            this.chartActivity.ExportToXls(save.FileName);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Возникло исключение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void xlsx_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            try
            {
                var save = new SaveFileDialog();
                save.DefaultExt = "xlsx";

                save.Title = "Как сохранить файл";
                if (save.ShowDialog() == true)
                {

                    switch (this.dxTab.SelectedIndex)
                    {
                        case (0):
                            this.chartCommon.ExportToXlsx(save.FileName);
                            break;
                        case (1):
                            this.chartTerm.ExportToXlsx(save.FileName);
                            break;
                        case (2):
                            this.chartActivity.ExportToXlsx(save.FileName);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Возникло исключение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void xps_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            try
            {
                var save = new SaveFileDialog();
                save.DefaultExt = "xps";

                save.Title = "Как сохранить файл";
                if (save.ShowDialog() == true)
                {

                    switch (this.dxTab.SelectedIndex)
                    {
                        case (0):
                            this.chartCommon.ExportToXps(save.FileName);
                            break;
                        case (1):
                            this.chartTerm.ExportToXps(save.FileName);
                            break;
                        case (2):
                            this.chartActivity.ExportToXps(save.FileName);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Возникло исключение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void bbiPrintCurrent_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            try
            {
                switch (this.dxTab.SelectedIndex)
                {
                    case (0):
                        this.chartCommon.PrintOptions.SizeMode = DevExpress.Xpf.Charts.PrintSizeMode.NonProportionalZoom;
                        this.chartCommon.ShowRibbonPrintPreviewDialog(this);
                        break;
                    case (1):
                        this.chartTerm.PrintOptions.SizeMode = DevExpress.Xpf.Charts.PrintSizeMode.NonProportionalZoom;
                        this.chartTerm.ShowRibbonPrintPreviewDialog(this);
                        break;
                    case (2):
                        this.chartActivity.PrintOptions.SizeMode = DevExpress.Xpf.Charts.PrintSizeMode.NonProportionalZoom;
                        this.chartActivity.ShowRibbonPrintPreviewDialog(this);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Возникло исключение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void html_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            try
            {
                var save = new SaveFileDialog();
                save.DefaultExt = "html";
                save.Title = "Как сохранить файл";
                if (save.ShowDialog() == true)
                {

                    switch (this.dxTab.SelectedIndex)
                    {
                        case (0):
                            this.chartCommon.ExportToHtml(save.FileName);
                            break;
                        case (1):
                            this.chartTerm.ExportToHtml(save.FileName);
                            break;
                        case (2):
                            this.chartActivity.ExportToHtml(save.FileName);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Возникло исключение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void bbiWorker_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            try
            {
                this.bbiManager.IsChecked = false;
                this.IsWorker = true;
                this.FillTaskList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Возникло исключение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void bbiManager_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            try
            {
                this.bbiWorker.IsChecked = false;
                this.IsWorker = false;
                this.FillTaskList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Возникло исключение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
