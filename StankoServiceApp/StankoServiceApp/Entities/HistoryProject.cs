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
    public partial class HistoryProject
    {
        public Project Project => App.Service.GetProjects().FirstOrDefault(x => x.Id == this.ProjectId);

        public User User => App.Service.GetUsers().FirstOrDefault(x => x.Id == this.UserId);

        public StatusProject StatusProjectHistory => (StatusProject)this.StatusId;

        public BitmapImage StatusIcon
        {
            get
            {
                switch (this.StatusId)
                {
                    case (0):
                        return this.ConvertFromBitmap(Properties.Resources.yellow_15);
                    case (1):
                        return this.ConvertFromBitmap(Properties.Resources.blue_15);
                    case (2):
                        return this.ConvertFromBitmap(Properties.Resources.green_15);
                    case (3):
                        return this.ConvertFromBitmap(Properties.Resources.orange_15);
                    case (4):
                        return this.ConvertFromBitmap(Properties.Resources.brown_15);
                    case (5):
                        return this.ConvertFromBitmap(Properties.Resources.purple_15);
                    case (6):
                        return this.ConvertFromBitmap(Properties.Resources.lightblue_15);
                    case (7):
                        return this.ConvertFromBitmap(Properties.Resources.gray_15);
                    case (8):
                        return this.ConvertFromBitmap(Properties.Resources.red_15);
                    default:
                        return this.ConvertFromBitmap(Properties.Resources.red_15);
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
                if(this.User.Worker==null)
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
