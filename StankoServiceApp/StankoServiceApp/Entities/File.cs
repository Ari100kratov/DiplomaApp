using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace StankoServiceApp.ServiceReference
{
    public partial class File
    {
        public BitmapImage FileIcon
        {
            get
            {
                switch (this.Title)
                {
                    case (".doc"):
                        return Methods.ConvertFromBitmap(Properties.Resources.doc);

                    case (".docx"):
                        return Methods.ConvertFromBitmap(Properties.Resources.doc);

                    case (""):
                        return Methods.ConvertFromBitmap(Properties.Resources.image);

                    case (".pdf"):
                        return Methods.ConvertFromBitmap(Properties.Resources.pdf);

                    case (".ppt"):
                        return Methods.ConvertFromBitmap(Properties.Resources.ppt);

                    case (".pptx"):
                        return Methods.ConvertFromBitmap(Properties.Resources.ppt);

                    case (".rar"):
                        return Methods.ConvertFromBitmap(Properties.Resources.rar);

                    case (".zip"):
                        return Methods.ConvertFromBitmap(Properties.Resources.rar);

                    case (".txt"):
                        return Methods.ConvertFromBitmap(Properties.Resources.txt);

                    case (".xls"):
                        return Methods.ConvertFromBitmap(Properties.Resources.xls);

                    case (".xlsx"):
                        return Methods.ConvertFromBitmap(Properties.Resources.xls);

                    case (".gif"):
                        return Methods.ConvertFromBitmap(Properties.Resources.gif);

                    case (".png"):
                        return Methods.ConvertFromBitmap(Properties.Resources.png);

                    case (".jpg"):
                        return Methods.ConvertFromBitmap(Properties.Resources.jpg);

                    default:
                        return Methods.ConvertFromBitmap(Properties.Resources.unknown);
                }
            }
        }
    }
}
