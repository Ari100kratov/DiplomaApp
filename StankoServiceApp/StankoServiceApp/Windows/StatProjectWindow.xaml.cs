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
                
                this.series1.AddPoint("Подготовка", this.ListProject.Where(x => x.GetStatusProject == StatusProject.Подготовка).Count());
                this.series2.AddPoint("Проектирование", this.ListProject.Where(x => x.GetStatusProject == StatusProject.Проектирование).Count());
                this.series3.AddPoint("Реализация", this.ListProject.Where(x => x.GetStatusProject == StatusProject.Реализация).Count());
                this.series4.AddPoint("Тестирование", this.ListProject.Where(x => x.GetStatusProject == StatusProject.Тестирование).Count());
                this.series5.AddPoint("Внедрение", this.ListProject.Where(x => x.GetStatusProject == StatusProject.Внедрение).Count());
                this.series6.AddPoint("Сопровождение", this.ListProject.Where(x => x.GetStatusProject == StatusProject.Сопровождение).Count());
                this.series7.AddPoint("Завершен", this.ListProject.Where(x => x.GetStatusProject == StatusProject.Завершен).Count());
                this.series8.AddPoint("Отложен", this.ListProject.Where(x => x.GetStatusProject == StatusProject.Отложен).Count());
                this.series9.AddPoint("Закрыт", this.ListProject.Where(x => x.GetStatusProject == StatusProject.Закрыт).Count());

                var listFilter = this.ListProject.Where(x => x.EndDate != null && x.CompletionDate != null).ToList();

                this.seriesSimple.AddPoint("Заврешенные в срок", listFilter.Where(x => x.CompletionDate <= x.EndDate).Count());
                this.seriesSimple.AddPoint("С опозданием", listFilter.Where(x => x.CompletionDate > x.EndDate).Count());

                var listEnd = this.ListProject.Where(x => x.CompletionDate != null).ToList();
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Возникло исключение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
