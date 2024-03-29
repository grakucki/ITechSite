﻿using ITechInstrukcjeModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace InstrukcjeProdukcyjne
{
    public class MyFileInfo : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FullFileName { get; set; }
        public string ItemText { get; set; }
        public string ItemText2 { get; set; }
        public ImageSource ItemIcon { get; set; }
        public string GroupBy { get; set; }
        public bool _IsRead;
        public int Version { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;
        // This method is called by the Set accessor of each property.
        // The CallerMemberName attribute that is applied to the optional propertyName
        // parameter causes the property name of the caller to be substituted as an argument.
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        public bool IsRead {
            get { return _IsRead; }
            set { _IsRead=value;
            NotifyPropertyChanged();
            NotifyPropertyChanged("Panel2ReadColor2");
            }

        }


        public SolidColorBrush Panel2ReadColor2
        {
            get
            {
                System.Windows.Media.Color c;
                if (IsRead)
                    c = Colors.Gray;
                else
                    c = Colors.Blue;

                //c = Colors.Red;
                //c = Colors.Blue;
                c.A = 200;
                return new SolidColorBrush(c); ;
            }
        }


        public Dokument Dok { get; set; }
        
        public string Extension
        {
            get
            {
                return Path.GetExtension(FullFileName).ToLower();
            }
        }
        
        public int ExtensionIndex
        {
            get
            {
                string[] extab =  new string[] {".txt", ".mp4",".avi", ".jpg", ".pdf",".wmv"};
                string ex = Path.GetExtension(FullFileName).ToLower();

                return Math.Max(0, Array.IndexOf(extab, ex));
                //
            }
        }
    }


    public class MyFileInfoList : INotifyPropertyChanged
    {
        public MyFileInfoList(ICollection<MyFileInfo> list)
        {
            MyFileInfo = list.ToList();
            foreach (var item in MyFileInfo)
            {
                item.PropertyChanged += OnMyFileInfoPropertyChanged;
            }

        }

        private void OnMyFileInfoPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "IsRead")
            {
                PropertyChanged(this, new PropertyChangedEventArgs("MyFileInfo"));
            }
        }

        public List<MyFileInfo> MyFileInfo { get; private set; }


        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }

    public class MyFileInfoEx
    {
        public ImageSource AviBmp { get; set; }
        public ImageSource PdfBmp { get; set; }
        public ImageSource JpgBmp { get; set; }
        public ImageSource AnyBmp { get; set; }
        //public string AviExt { get; set; }
        //public string PdfExt { get; set; }
        //public string JpgExt { get; set; }


        public MyFileInfoEx()
        {
            AviBmp = BitmapToImageSource(Properties.Resources.ikonaAvi);
            PdfBmp = BitmapToImageSource(Properties.Resources.ikonaPDF);
            JpgBmp = BitmapToImageSource(Properties.Resources.ikonaJpg);
            AnyBmp = BitmapToImageSource(Properties.Resources.ikonaPDF);
            //AviExt = VideoViewerControl.SuportedEx; // ".mp4,.avi,.wmv,.m2t";
            //JpgExt = PictureViewerControl.SuportedEx;
            //PdfExt = PdfViewerControl.SuportedEx; // ".pdf";
        }


        public static ImageSource BitmapToImageSource(Bitmap img)
        {

            MemoryStream ms = new MemoryStream();
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            ms.Position = 0;
            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            bi.StreamSource = ms;
            bi.EndInit();

            return bi;
        }

        public ImageSource GetBitmapForFileExt(string extension)
        {

            if (VideoViewerControl.MediaSuported(extension))
                return AviBmp;

            if (PdfViewerControl.MediaSuported(extension))
                return PdfBmp;

            if (PictureViewerControl.MediaSuported(extension))
                return JpgBmp;

            //if (AviExt.IndexOf(extension) >= 0)
            //    return AviBmp;

            //if (PdfExt.IndexOf(extension) >= 0)
            //    return PdfBmp;

            return AnyBmp;
        }

        public ImageSource GetBitmapForFile(string fileName)
        {
            var extension = Path.GetExtension(fileName).ToLower();
            if (VideoViewerControl.MediaSuported(extension))
                return AviBmp;

            if (PdfViewerControl.MediaSuported(extension))
                return CreateImageFromPdfFile(fileName);  

            if (PictureViewerControl.MediaSuported(extension))
                 return CreateImageFromImgeFile(fileName);

            return AnyBmp;
        }

        private ImageSource CreateImageFromPdfFile(string fileName)
        {
            return PdfBmp;
        }

        private ImageSource CreateImageFromImgeFile(string fileName)
        {
            BitmapImage logo = new BitmapImage();
            if (File.Exists(fileName))
            {
                try
                {
                    logo.BeginInit();
                    logo.UriSource = new Uri(fileName);
                    logo.DecodePixelWidth = 96;
                    logo.EndInit();
                    return logo;
                }
                catch (Exception)
                {
                }
            }
            return JpgBmp;
         
        }
    }
}
