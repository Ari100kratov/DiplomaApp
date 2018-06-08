using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace StankoServiceApp
{
    public static class WorkWithMail
    {
        public static void SendMessageFromMainMail(string sub, string body, string to)
        {
            using (var mm = new MailMessage("ООО ИЦ Станкосервис <stankoserviceorg@mail.ru>", to))
            {
                mm.Subject = sub;
                mm.Body = body;
                mm.IsBodyHtml = false;
                using (var sc = new SmtpClient("smtp.mail.ru", 587))
                {
                    sc.EnableSsl = true;
                    sc.DeliveryMethod = SmtpDeliveryMethod.Network;
                    sc.UseDefaultCredentials = false;
                    sc.Credentials = new NetworkCredential("stankoserviceorg@mail.ru", "vladik123");
                    sc.Send(mm);
                }
            }
        }

        public static BitmapImage StatusIcon(int status)
        {
            switch (status)
            {
                case (0):
                    return ConvertFromBitmap(Properties.Resources.yellow_15);
                case (1):
                    return ConvertFromBitmap(Properties.Resources.blue_15);
                case (2):
                    return ConvertFromBitmap(Properties.Resources.green_15);
                case (3):
                    return ConvertFromBitmap(Properties.Resources.orange_15);
                case (4):
                    return ConvertFromBitmap(Properties.Resources.brown_15);
                case (5):
                    return ConvertFromBitmap(Properties.Resources.purple_15);
                case (6):
                    return ConvertFromBitmap(Properties.Resources.lightblue_15);
                case (7):
                    return ConvertFromBitmap(Properties.Resources.gray_15);
                case (8):
                    return ConvertFromBitmap(Properties.Resources.red_15);
                default:
                    return ConvertFromBitmap(Properties.Resources.red_15);
            }
        }

        public static BitmapImage ConvertFromBitmap(Bitmap bmp)
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
    }
}
