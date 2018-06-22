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
    /// Логика взаимодействия для ProfileWindow.xaml
    /// </summary>
    public partial class ProfileWindow : Window
    {
        private string ConfirmCode = null;
        private bool EditMail = false;
        private bool MailIsRight = false;
        private bool PasswordEdit = false;

        string newMail = "";
        string newPass = "";

        public ProfileWindow()
        {
            InitializeComponent();
        }

        private void sbEditMail_Click(object sender, RoutedEventArgs e)
        {
            if (this.EditMail == false)
            {
                this.teMail.IsEnabled = true;
                this.teMail.Text = null;
                this.sbNext.Visibility = Visibility.Visible;
                this.EditMail = true;
                this.sbEditMail.Content = "Отменить";
            }
            else
            {
                this.tbMessage.Visibility = Visibility.Collapsed;
                this.sbEditMail.Content = "Изменить";
                this.teMail.Text = App.CurrentUser.Email;
                this.teMail.IsEnabled = false;
                this.sbNext.Visibility = Visibility.Collapsed;
                this.liCode.Visibility = Visibility.Collapsed;
                this.spButtons.Visibility = Visibility.Collapsed;
                this.MailIsRight = false;
                this.EditMail = false;
            }

            this.SizeToContent = SizeToContent.WidthAndHeight;
        }

        public void GenerateConfirmCode()
        {
            var rnd = new Random();
            this.ConfirmCode = rnd.Next(1111, 9999).ToString();
        }

        public void SendMessage()
        {
            this.GenerateConfirmCode();
            Methods.SendMessageFromMainMail("Регистрация сотрудника", $"Ваш код подтверждения: {this.ConfirmCode}", this.teMail.Text);
        }

        private void sbNext_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var user = App.Service.GetUsers().FirstOrDefault(x => x.Email == this.teMail.Text);

                if (user != null)
                {
                    this.tbMessage.Text = "Электронный адрес уже существует";
                    this.tbMessage.Foreground = Brushes.IndianRed;
                    this.tbMessage.Visibility = Visibility.Visible;

                    return;
                }
                this.SendMessage();
                this.liCode.Visibility = Visibility.Visible;
                this.spButtons.Visibility = Visibility.Visible;
                this.tbMessage.Visibility = Visibility.Collapsed;

                this.SizeToContent = SizeToContent.WidthAndHeight;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Возникло исключение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void sbRepeat_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.SendMessage();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Возникло исключение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void sbOK_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.teCode.Text == this.ConfirmCode)
                {
                    this.tbMessage.Text = "Почта успешно подтверждена";
                    this.tbMessage.Foreground = Brushes.Green;
                    this.tbMessage.Visibility = Visibility.Visible;
                    this.teMail.IsEnabled = false;
                    this.MailIsRight = true;

                }
                else
                {
                    this.tbMessage.Text = "Ошибка подтверждения";
                    this.tbMessage.Foreground = Brushes.IndianRed;
                    this.tbMessage.Visibility = Visibility.Visible;
                    this.MailIsRight = false;
                }

                this.SizeToContent = SizeToContent.WidthAndHeight;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Возникло исключение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void sbSave_Click(object sender, RoutedEventArgs e)
        {
            if (this.EditMail)
            {
                if (this.MailIsRight == false)
                {
                    this.tbMessageError.Text = "Подтвердите почту";
                    this.tbMessageError.Background = Brushes.IndianRed;
                    this.tbMessageError.Foreground = Brushes.White;
                    this.tbMessageError.Visibility = Visibility.Visible;
                    return;
                }
            }

            if (!string.IsNullOrEmpty(this.pbNewPassword.Password))
            {
                this.PasswordEdit = true;
                if (this.pbCurrentPassword.Password != App.CurrentUser.Password)
                {
                    this.tbMessageError.Text = "Текущий пароль введен неправильно";
                    this.tbMessageError.Background = Brushes.IndianRed;
                    this.tbMessageError.Visibility = Visibility.Visible;
                    return;
                }

                if (string.IsNullOrWhiteSpace(this.pbNewPassword.Password))
                {
                    this.tbMessageError.Text = "Введите новый пароль";
                    this.tbMessageError.Background = Brushes.IndianRed;
                    this.tbMessageError.Visibility = Visibility.Visible;
                    return;
                }

                if (this.pbRepeatPassword.Password != this.pbNewPassword.Password)
                {
                    this.tbMessageError.Text = "Ошибка подтверждения пароля";
                    this.tbMessageError.Background = Brushes.IndianRed;
                    this.tbMessageError.Visibility = Visibility.Visible;
                    return;
                }
            }
            else
            {
                this.PasswordEdit = false;
            }

            if (this.EditMail == true)
                this.newMail = this.teMail.Text;

            if (this.PasswordEdit == true)
                this.newPass = this.pbNewPassword.Password;


            App.Service.EditLogin(App.CurrentUser, this.newMail, this.newPass);

            this.tbMessageError.Text = "Данные успешно сохранены";
            this.tbMessageError.Background = Brushes.White;
            this.tbMessageError.Foreground = Brushes.Green;
            this.tbMessageError.Visibility = Visibility.Visible;

            this.SizeToContent = SizeToContent.WidthAndHeight;
        }

        private void sbCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (App.CurrentUser.RoleId == (int)Role.Исполнитель)
            {
                this.li1.Visibility = Visibility.Collapsed;
                this.li2.Visibility = Visibility.Collapsed;
            }

            this.teMail.IsEnabled = false;
            var worker = App.CurrentUser.Worker;
            this.tbFIO.Text = $"{worker.Surname} {worker.Name} {worker.Patronymic}";
            this.tbDateOfBirth.Text = worker.DateOfBirth.ToLongDateString();
            this.tbPhone.Text = worker.Phone;
            this.tbDateOfEmploy.Text = worker.DateOfEmploy.ToLongDateString();
            this.tbPosition.Text = worker.Position.PositionName;
            this.tbEmail.Text = worker.User.Email;
            this.imgPhoto.Source = worker.ImgPhoto;
            this.teMail.Text = worker.User.Email;
        }

        private void sbStatProject_Click(object sender, RoutedEventArgs e)
        {
            var project = App.Service.GetProjects().Where(x => x.WorkerId == App.CurrentUser.Worker.Id).ToList();
            var stat = new StatProjectWindow(project);
            stat.ShowDialog();
        }

        private void sbStatTask_Click(object sender, RoutedEventArgs e)
        {
            var worker = new List<Worker>();
            worker.Add(App.CurrentUser.Worker);
            var stat = new StatWorkerWindow(worker);
            stat.ShowDialog();
        }
    }
}
