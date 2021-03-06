﻿using System;
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
using System.Drawing.Imaging;

namespace StankoServiceApp.ServiceReference
{
    public partial class Worker
    {
        public File Photo => App.Service.GetFiles().FirstOrDefault(x => x.Id == this.PhotoId);

        public File Resume => App.Service.GetFiles().FirstOrDefault(x => x.Id == this.ResumeId);

        public List<Project> Projects => App.Service.GetProjects().Where(x => x.WorkerId == this.Id).ToList();

        public List<Task> Tasks => App.Service.GetTasks().Where(x => x.WorkerId == this.Id).ToList();

        public User User => App.Service.GetUsers().FirstOrDefault(x => x.Id == this.UserId);

        public Position Position => App.Service.GetPositions().FirstOrDefault(x => x.Id == this.PositionId);

        public BitmapImage ImgPhoto
        {
            get
            {
                if (this.PhotoId != null)
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
                else
                {
                    using (var memory = new MemoryStream())
                    {
                        Properties.Resources.no_photo.Save(memory, ImageFormat.Png);
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

        public byte[] PhotoShow
        {
            get
            {
                if (this.Photo != null)
                {
                    return this.Photo.Data;
                }
                else
                {
                    using (var stream = new MemoryStream())
                    {
                        Properties.Resources.загруженное.Save(stream, Properties.Resources.загруженное.RawFormat);
                        return stream.ToArray();
                    }
                }
            }
        }

        public int Age => DateTime.Now.Year - this.DateOfBirth.Year;

        public string FullName => $"{this.Surname} {this.Name} {this.Patronymic}";
    }
}
