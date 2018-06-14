using StankoserviceEnums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace StankoServiceApp.ServiceReference
{
    public partial class HistoryTask
    {
        public Task Task => App.Service.GetTasks().FirstOrDefault(x => x.Id == this.TaskId);

        public User User => App.Service.GetUsers().FirstOrDefault(x => x.Id == this.UserId);

        public StatusTask StatusTaskHistory => (StatusTask)this.StatusId;

        public BitmapImage StatusIcon
        {
            get
            {
                switch (this.StatusId)
                {
                    case (0):
                        return this.ConvertFromBitmap(Properties.Resources.task01);
                    case (1):
                        return this.ConvertFromBitmap(Properties.Resources.task02);
                    case (2):
                        return this.ConvertFromBitmap(Properties.Resources.task03);
                    case (3):
                        return this.ConvertFromBitmap(Properties.Resources.task04);
                    case (4):
                        return this.ConvertFromBitmap(Properties.Resources.task05);
                    case (5):
                        return this.ConvertFromBitmap(Properties.Resources.task06);
                    default:
                        return this.ConvertFromBitmap(Properties.Resources.task01);
                }
            }
        }

        public BitmapImage ConvertFromBitmap(Bitmap bmp)
        {
            using (var memory = new MemoryStream())
            {
                bmp.Save(memory, ImageFormat.Png);
                memory.Position = 0;

                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                bitmapImage.Freeze();

                return bitmapImage;
            }
        }

        public string FullName
        {
            get
            {
                if (this.User.Worker == null)
                {
                    return "Директор";
                }
                else
                {
                    return this.User.Worker.FullName;
                }
            }
        }
    }
}
