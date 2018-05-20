using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Windows.Shapes;
using Microsoft.Win32;
using StankoServiceApp.Pages;

namespace StankoServiceApp.Windows
{
    /// <summary>
    /// Логика взаимодействия для DirectorWindow.xaml
    /// </summary>
    public partial class DirectorWindow : Window
    {
        public DirectorWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.MainFrame.Navigate(new WorkerPage());
        }

        private void sbWorker_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                //Связываем файловый поток с открываемым файлом
                FileStream fileStream = new FileStream(openFileDialog.FileName, FileMode.Open);
                //Создаем объект BinaryReader для чтения двоичных данных
                BinaryReader binaryReader = new BinaryReader(fileStream);
                //Объявляем переменную byte[], так как varbinary требует именно этот тип данных
                byte[] mas;
                //указади длинну массива
                mas = new byte[fileStream.Length];
                //в цикле считали побойтово файл
                for (int i = 0; i < fileStream.Length; i++)
                    mas[i] = binaryReader.ReadByte();
                //закрыли поток
                binaryReader.Close();
                fileStream.Close();

                var con = new SqlConnection(@"Data Source = DESKTOP-9A67565\SQLEXPRESS; Initial Catalog = Stankoservice; Integrated Security = true;");
                var cmd = new SqlCommand("UPDATE [File] SET Data = @data WHERE Id = 1", con);
                cmd.Parameters.AddWithValue("@data", mas);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
