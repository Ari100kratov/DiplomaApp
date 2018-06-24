using DevExpress.Xpf.Printing;
using Microsoft.Win32;
using StankoServiceApp.ServiceReference;
using StankoserviceEnums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
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
    /// Логика взаимодействия для StatProjectWindow.xaml
    /// </summary>
    public partial class StatProjectWindow : Window
    {
        List<Project> ListProject = new List<Project>();

        public StatProjectWindow(List<Project> list)
        {
            InitializeComponent();
            this.ListProject = list;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                this.series1.Points.Clear();
                this.series2.Points.Clear();
                this.series3.Points.Clear();
                this.series4.Points.Clear();
                this.series5.Points.Clear();
                this.series6.Points.Clear();
                this.series7.Points.Clear();
                this.series8.Points.Clear();
                this.series9.Points.Clear();
                this.SeriesActvity.Points.Clear();
                this.SeriesFalse.Points.Clear();

                //
                this.series1.AddPoint("Подготовка", this.ListProject.Where(x => x.GetStatusProject == StatusProject.Подготовка).Count());
                this.series2.AddPoint("Проектирование", this.ListProject.Where(x => x.GetStatusProject == StatusProject.Проектирование).Count());
                this.series3.AddPoint("Реализация", this.ListProject.Where(x => x.GetStatusProject == StatusProject.Реализация).Count());
                this.series4.AddPoint("Тестирование", this.ListProject.Where(x => x.GetStatusProject == StatusProject.Тестирование).Count());
                this.series5.AddPoint("Внедрение", this.ListProject.Where(x => x.GetStatusProject == StatusProject.Внедрение).Count());
                this.series6.AddPoint("Сопровождение", this.ListProject.Where(x => x.GetStatusProject == StatusProject.Сопровождение).Count());
                this.series7.AddPoint("Завершен", this.ListProject.Where(x => x.GetStatusProject == StatusProject.Завершен).Count());
                this.series8.AddPoint("Отложен", this.ListProject.Where(x => x.GetStatusProject == StatusProject.Отложен).Count());
                this.series9.AddPoint("Закрыт", this.ListProject.Where(x => x.GetStatusProject == StatusProject.Закрыт).Count());

                //
                var stat = this.ListProject.Where(x => x.EndDate != null).ToList();
                if (stat.Count() != 0)
                {
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
                //
                var listEnd = this.ListProject.Where(x => x.CompletionDate != null).ToList();
                if (listEnd.Count() != 0)
                {
                    int count = 0;
                    int days = 0;

                    if (listEnd.Count() != 0)
                    {
                        for (var i = 0; i < listEnd.Count(); i++)
                        {
                            count++;
                            days += (listEnd[i].CompletionDate.Value - listEnd[i].StartDate).Days;
                        }

                        this.tbCountDays.Text = $"Количество дней, затрачиваемое на проект в среднем - {days / count}";
                    }
                }

                //

                var listComp = this.ListProject.Where(x => x.CompletionDate != null).ToList();
                if (listComp.Count() != 0)
                {
                    var lastYear = DateTime.Now.AddYears(-1);

                    foreach (var item in EachDay(lastYear.AddMonths(1), DateTime.Now.AddMonths(1)))
                    {
                        var countProject = listComp.Where(x => x.CompletionDate.Value.Month == item.Month && (x.GetStatusProject == StatusProject.Завершен || x.GetStatusProject == StatusProject.Внедрение)).Count();
                        this.SeriesActvity.AddPoint(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(item.Month), countProject);

                        var countFalse = listComp.Where(x => x.CompletionDate.Value.Month == item.Month && x.GetStatusProject == StatusProject.Закрыт).Count();
                        this.SeriesFalse.AddPoint(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(item.Month), countFalse);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Возникло исключение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public IEnumerable<DateTime> EachDay(DateTime from, DateTime thru)
        {
            for (var month = from.Date; month.Date <= thru.Date; month = month.AddMonths(1))
                yield return month;
        }

        private void bbiPrintCurrent_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            try
            {
                switch (this.dxTab.SelectedIndex)
                {
                    case (0):
                        this.charCommon.PrintOptions.SizeMode = DevExpress.Xpf.Charts.PrintSizeMode.NonProportionalZoom;
                        this.charCommon.ShowRibbonPrintPreviewDialog(this);
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
                            this.charCommon.ExportToHtml(save.FileName);
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

        private void bbiprintAll_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {

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
                            this.charCommon.ExportToImage(save.FileName);
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
                            this.charCommon.ExportToMht(save.FileName);
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
                            this.charCommon.ExportToPdf(save.FileName);
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
                            this.charCommon.ExportToRtf(save.FileName);
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
                            this.charCommon.ExportToXls(save.FileName);
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
                            this.charCommon.ExportToXlsx(save.FileName);
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
                            this.charCommon.ExportToXps(save.FileName);
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
    }
}
