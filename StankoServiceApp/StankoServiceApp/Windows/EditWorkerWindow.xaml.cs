﻿using System;
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
using System.Net;
using System.Net.Mail;
using StankoserviceEnums;
using StankoServiceApp.ServiceReference;

namespace StankoServiceApp.Windows
{
    /// <summary>
    /// Логика взаимодействия для EditWorkerWindow.xaml
    /// </summary>
    public partial class EditWorkerWindow : Window
    {
        private string ConfirmCode = null;

        private Worker Worker = null;
        private bool IsAdd => this.Worker == null;

        public EditWorkerWindow(Worker worker = null)
        {
            InitializeComponent();
            this.Worker = worker;
        }

        public void GenerateConfirmCode()
        {
            var rnd = new Random();
            this.ConfirmCode = rnd.Next(1111, 9999).ToString();
        }

        public void SendMessage()
        {
            this.GenerateConfirmCode();
            WorkWithMail.SendMessageFromMainMail("Регистрация сотрудника", $"Ваш код подтверждения: {this.ConfirmCode}", this.teMail.Text);
        }

        private void sbConfirm_Click(object sender, RoutedEventArgs e)
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

                    this.liPassword.Visibility = Visibility.Visible;
                    this.liRepeatPassword.Visibility = Visibility.Visible;
                }
                else
                {
                    this.tbMessage.Text = "Ошибка подтверждения";
                    this.tbMessage.Foreground = Brushes.IndianRed;
                    this.tbMessage.Visibility = Visibility.Visible;

                    this.liPassword.Visibility = Visibility.Collapsed;
                    this.liRepeatPassword.Visibility = Visibility.Collapsed;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Возникло исключение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void sbSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(this.teName.Text) || string.IsNullOrWhiteSpace(this.teSurname.Text) || this.deDateOfBirth.EditValue == null || this.deDateOfEmploy.EditValue == null || this.cePosition.EditValue == null)
                {
                    this.LayoutGroup.SelectedTabIndex = 0;
                    this.tbMessageError.Text = "Заполните обязательные поля";
                    this.tbMessageError.Background = Brushes.IndianRed;
                    this.tbMessageError.Visibility = Visibility.Visible;

                    return;
                }

                if (this.IsAdd)
                {
                    if (string.IsNullOrWhiteSpace(this.teMail.Text))
                    {
                        this.LayoutGroup.SelectedTabIndex = 1;
                        this.tbMessageError.Text = "Введите почту и подтвердите ее";
                        this.tbMessageError.Background = Brushes.IndianRed;
                        this.tbMessageError.Visibility = Visibility.Visible;

                        return;
                    }

                    if (string.IsNullOrWhiteSpace(this.pbPassword.Password))
                    {
                        this.LayoutGroup.SelectedTabIndex = 1;
                        this.tbMessageError.Text = "Введите пароль";
                        this.tbMessageError.Background = Brushes.IndianRed;
                        this.tbMessageError.Visibility = Visibility.Visible;

                        return;
                    }

                    if (this.pbRepeatPassword.Password != this.pbPassword.Password)
                    {
                        this.LayoutGroup.SelectedTabIndex = 1;
                        this.tbMessageError.Text = "Введенные пароли не совпадают";
                        this.tbMessageError.Background = Brushes.IndianRed;
                        this.tbMessageError.Visibility = Visibility.Visible;

                        return;
                    }
                }

                var role = (bool)this.cheRole.IsChecked ? Role.Менеджер : Role.Сотрудник;

                if (this.IsAdd)
                {
                    File photo = null;

                    if (this.iePhoto.HasImage)
                    {
                        photo = new File
                        {
                            FileName = $"PhotoBy{this.teSurname.Text}",
                            Data = this.iePhoto.EditValue as byte[]
                        };
                    }

                    var user = new User
                    {
                        Email = this.teMail.Text,
                        Password = this.pbPassword.Password,
                        RoleId = (int)role
                    };

                    var worker = new Worker
                    {
                        Name = this.teName.Text,
                        Surname = this.teSurname.Text,
                        Patronymic = this.tePatronymic.Text,
                        DateOfBirth = (DateTime)this.deDateOfBirth.EditValue,
                        DateOfEmploy = (DateTime)this.deDateOfEmploy.EditValue,
                        Phone = this.tePhone.Text,
                        PositionId = (int)this.cePosition.EditValue
                    };

                    await App.Service.AddNewWorkerAsync(worker, photo, user);
                    this.Close();
                }
                else
                {
                    var user = this.Worker.User;
                    user.RoleId = (int)role;

                    File photo = null;

                    if (this.iePhoto.HasImage)
                    {
                        photo = this.Worker.Photo == null ? new File() : this.Worker.Photo;
                        photo.FileName = $"PhotoBy{this.teSurname.Text}";
                        photo.Data = this.iePhoto.EditValue as byte[];
                    }

                    this.Worker.Name = this.teName.Text;
                    this.Worker.Surname = this.teSurname.Text;
                    this.Worker.Patronymic = this.tePatronymic.Text;
                    this.Worker.DateOfBirth = (DateTime)this.deDateOfBirth.EditValue;
                    this.Worker.DateOfEmploy = (DateTime)this.deDateOfEmploy.EditValue;
                    this.Worker.Phone = this.tePhone.Text;
                    this.Worker.PositionId = (int)this.cePosition.EditValue;

                    await App.Service.EditWorkerAsync(this.Worker, photo, user);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Возникло исключение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                this.cePosition.ItemsSource = App.Service.GetPositions();
                this.cePosition.DisplayMember = "PositionName";
                this.cePosition.ValueMember = "Id";

                if (this.IsAdd)
                {
                    return;
                }

                this.lgLogin.Visibility = Visibility.Collapsed;

                this.teName.Text = this.Worker.Name;
                this.teSurname.Text = this.Worker.Surname;
                this.tePatronymic.Text = this.Worker.Patronymic;
                this.deDateOfBirth.EditValue = this.Worker.DateOfBirth;
                this.deDateOfEmploy.EditValue = this.Worker.DateOfEmploy;
                this.tePhone.Text = this.Worker.Phone;
                this.cePosition.EditValue = this.Worker.PositionId;
                this.iePhoto.EditValue = this.Worker.Photo?.Data;
                this.cheRole.IsChecked = this.Worker.User.RoleUser == Role.Менеджер;

                this.teShowMail.Visibility = Visibility.Visible;
                this.teShowMail.Text = this.Worker.User.Email;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Возникло исключение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
