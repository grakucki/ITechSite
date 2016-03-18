using ITechInstrukcjeModel;
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

    public class MyFileInfoEx
    {
        public ImageSource AviBmp { get; set; }
        public ImageSource PdfBmp { get; set; }
        public ImageSource AnyBmp { get; set; }
        public string AviExt { get; set; }
        public string PdfExt { get; set; }


        public MyFileInfoEx()
        {
            AviBmp = BitmapToImageSource(Properties.Resources.ikonaAvi);
            PdfBmp = BitmapToImageSource(Properties.Resources.ikonaPDF);
            AnyBmp = BitmapToImageSource(Properties.Resources.ikonaPDF);
            AviExt = ".mp4,.avi,wmv";
            PdfExt =".pdf";
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
            if (AviExt.IndexOf(extension) >= 0)
                return AviBmp;

            if (PdfExt.IndexOf(extension) >= 0)
                return PdfBmp;

            return AnyBmp;
        }
    }
}
