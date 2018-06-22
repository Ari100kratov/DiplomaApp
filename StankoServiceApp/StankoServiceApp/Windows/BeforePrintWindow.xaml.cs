using StankoServiceApp.Pages;
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
    /// Логика взаимодействия для BeforePrintWindow.xaml
    /// </summary>
    public partial class BeforePrintWindow : Window
    {
        private ProjectPage ProjectPage = null;
        private TaskPage TaskPage = null;
        private WorkerPage WorkerPage = null;
        private WorkerWindow WorkerWindow = null;

        public BeforePrintWindow(ProjectPage projectPage)
        {
            InitializeComponent();
            this.ProjectPage = projectPage;
        }

        public BeforePrintWindow(TaskPage taskPage)
        {
            InitializeComponent();
            this.TaskPage = taskPage;
        }

        public BeforePrintWindow(WorkerWindow worker)
        {
            InitializeComponent();
            this.WorkerWindow = worker;
        }

        public BeforePrintWindow(WorkerPage workerPage)
        {
            InitializeComponent();
            this.WorkerPage = workerPage;
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            if (this.ProjectPage != null)
            {
                this.column1.CheckedStateContent = "Наименование";
                this.column1.UncheckedStateContent = "Наименование";

                this.column2.CheckedStateContent = "Дата начала";
                this.column2.UncheckedStateContent = "Дата начала";

                this.column3.CheckedStateContent = "Срок до";
                this.column3.UncheckedStateContent = "Срок до";

                this.column4.CheckedStateContent = "Завершено";
                this.column4.UncheckedStateContent = "Завершено";

                this.column5.CheckedStateContent = "Руководитель";
                this.column5.UncheckedStateContent = "Руководитель";

                this.column6.CheckedStateContent = "Типо проекта";
                this.column6.UncheckedStateContent = "Тип проекта";

                this.column7.CheckedStateContent = "Статус";
                this.column7.UncheckedStateContent = "Статус";

                this.column8.Visibility = Visibility.Collapsed;
                this.column9.Visibility = Visibility.Collapsed;
            }

            if (this.TaskPage != null || this.WorkerWindow!=null)
            {
                this.column1.CheckedStateContent = "Наименование";
                this.column1.UncheckedStateContent = "Наименование";

                this.column2.CheckedStateContent = "Менеджер";
                this.column2.UncheckedStateContent = "Менеджер";

                this.column3.CheckedStateContent = "Исполнитель";
                this.column3.UncheckedStateContent = "Исполнитель";

                this.column4.CheckedStateContent = "Проект";
                this.column4.UncheckedStateContent = "Проект";

                this.column5.CheckedStateContent = "Срок до";
                this.column5.UncheckedStateContent = "Срок до";

                this.column6.CheckedStateContent = "Завершено";
                this.column6.UncheckedStateContent = "Завершено";

                this.column7.CheckedStateContent = "Приоритет";
                this.column7.UncheckedStateContent = "Приоритет";

                this.column8.CheckedStateContent = "Статус";
                this.column8.UncheckedStateContent = "Статус";

                this.column9.Visibility = Visibility.Collapsed;
            }

            if (this.WorkerPage != null)
            {
                this.column1.CheckedStateContent = "Фото";
                this.column1.UncheckedStateContent = "Фото";

                this.column2.CheckedStateContent = "Имя";
                this.column2.UncheckedStateContent = "Имя";

                this.column3.CheckedStateContent = "Фамилия";
                this.column3.UncheckedStateContent = "Фамилия";

                this.column4.CheckedStateContent = "Отчество";
                this.column4.UncheckedStateContent = "Отчество";

                this.column5.CheckedStateContent = "Дата рождения";
                this.column5.UncheckedStateContent = "Дата рождения";

                this.column6.CheckedStateContent = "Работает с";
                this.column6.UncheckedStateContent = "Работает с";

                this.column7.CheckedStateContent = "Телефон";
                this.column7.UncheckedStateContent = "Телефон";

                this.column8.CheckedStateContent = "Должность";
                this.column8.UncheckedStateContent = "Должность";

                this.column9.CheckedStateContent = "Почта";
                this.column9.UncheckedStateContent = "Почта";
            }
        }

        private void sbCancel_Click(object sender, RoutedEventArgs e)
        {
            if (this.ProjectPage != null)
            {
                this.ProjectPage.IsPrint = false;
                this.Close();
            }

            if (this.TaskPage != null)
            {
                this.TaskPage.IsPrint = false;
                this.Close();
            }

            if (this.WorkerPage != null)
            {
                this.ProjectPage.IsPrint = false;
                this.Close();
            }

            if (this.WorkerWindow != null)
            {
                this.WorkerWindow.IsPrint = false;
                this.Close();
            }
        }

        private void sbSave_Click(object sender, RoutedEventArgs e)
        {
            if (this.ProjectPage != null)
            {
                this.ProjectPage.column1.AllowPrinting = (bool)this.column1.IsChecked;
                this.ProjectPage.column2.AllowPrinting = (bool)this.column2.IsChecked;
                this.ProjectPage.column3.AllowPrinting = (bool)this.column3.IsChecked;
                this.ProjectPage.column4.AllowPrinting = (bool)this.column4.IsChecked;
                this.ProjectPage.column5.AllowPrinting = (bool)this.column5.IsChecked;
                this.ProjectPage.column6.AllowPrinting = (bool)this.column6.IsChecked;
                this.ProjectPage.column7.AllowPrinting = (bool)this.column7.IsChecked;
                this.ProjectPage.IsPrint = true;
                this.Close();
            }

            if (this.TaskPage != null)
            {
                this.TaskPage.column1.AllowPrinting = (bool)this.column1.IsChecked;
                this.TaskPage.column2.AllowPrinting = (bool)this.column2.IsChecked;
                this.TaskPage.column3.AllowPrinting = (bool)this.column3.IsChecked;
                this.TaskPage.column4.AllowPrinting = (bool)this.column4.IsChecked;
                this.TaskPage.column5.AllowPrinting = (bool)this.column5.IsChecked;
                this.TaskPage.column6.AllowPrinting = (bool)this.column6.IsChecked;
                this.TaskPage.column7.AllowPrinting = (bool)this.column7.IsChecked;
                this.TaskPage.column8.AllowPrinting = (bool)this.column8.IsChecked;
                this.TaskPage.IsPrint = true;
                this.Close();
            }

            if (this.WorkerWindow != null)
            {
                this.WorkerWindow.column1.AllowPrinting = (bool)this.column1.IsChecked;
                this.WorkerWindow.column2.AllowPrinting = (bool)this.column2.IsChecked;
                this.WorkerWindow.column3.AllowPrinting = (bool)this.column3.IsChecked;
                this.WorkerWindow.column4.AllowPrinting = (bool)this.column4.IsChecked;
                this.WorkerWindow.column5.AllowPrinting = (bool)this.column5.IsChecked;
                this.WorkerWindow.column6.AllowPrinting = (bool)this.column6.IsChecked;
                this.WorkerWindow.column7.AllowPrinting = (bool)this.column7.IsChecked;
                this.WorkerWindow.column8.AllowPrinting = (bool)this.column8.IsChecked;
                this.WorkerWindow.IsPrint = true;
                this.Close();
            }

            if (this.WorkerPage != null)
            {
                this.WorkerPage.column1.AllowPrinting = (bool)this.column1.IsChecked;
                this.WorkerPage.column2.AllowPrinting = (bool)this.column2.IsChecked;
                this.WorkerPage.column3.AllowPrinting = (bool)this.column3.IsChecked;
                this.WorkerPage.column4.AllowPrinting = (bool)this.column4.IsChecked;
                this.WorkerPage.column5.AllowPrinting = (bool)this.column5.IsChecked;
                this.WorkerPage.column6.AllowPrinting = (bool)this.column6.IsChecked;
                this.WorkerPage.column7.AllowPrinting = (bool)this.column7.IsChecked;
                this.WorkerPage.column8.AllowPrinting = (bool)this.column8.IsChecked;
                this.WorkerPage.column9.AllowPrinting = (bool)this.column9.IsChecked;
                this.WorkerPage.IsPrint = true;
                this.Close();
            }
        }
    }
}
