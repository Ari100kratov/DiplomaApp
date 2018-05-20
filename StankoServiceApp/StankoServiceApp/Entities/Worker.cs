using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Drawing;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace StankoServiceApp.ServiceReference
{
    public partial class Worker
    {
        public File Photo => App.Service.GetFiles().FirstOrDefault(x => x.Id == this.PhotoId);

        public List<Project> Projects => App.Service.GetProjects().Where(x => x.WorkerId == this.Id).ToList();

        public List<Task> Tasks => App.Service.GetTasks().Where(x => x.WorkerId == this.Id).ToList();

        public User User => App.Service.GetUsers().FirstOrDefault(x => x.Id == this.UserId);

        public Position Position => App.Service.GetPositions().FirstOrDefault(x=>x.Id == this.PositionId);

        public BitmapImage ImgPhoto
        {
            get
            {
                MemoryStream stream = new MemoryStream();
                stream.Write(this.Photo.Data, 0, this.Photo.Data.Length);
                stream.Position = 0;
                System.Drawing.Image img = System.Drawing.Image.FromStream(stream);
                BitmapImage returnImage = new BitmapImage();
                returnImage.BeginInit();
                MemoryStream ms = new MemoryStream();
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                ms.Seek(0, SeekOrigin.Begin);
                returnImage.StreamSource = ms;
                returnImage.EndInit();

                return returnImage;
            }
        }

        public int Age => DateTime.Now.Year - this.DateOfBirth.Year;
    }
}
