using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
//using System.Windows.Data;

//using MS.Internal.Data;

namespace InstrukcjeProdukcyjne
{


    public class Doc2ReadConverter : IMultiValueConverter
    {

        private int GetToReadDoc(CollectionViewGroup obj)
        {
            int total = 0;
            foreach (object objItem in obj.Items)
            {
                MyFileInfo f = (MyFileInfo)objItem;
                if (!f.IsRead)
                    total++;
            }

            return total;
        }

        public object Convert(object[] value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            CollectionViewGroup cvg = ((CollectionViewGroup)(value[1]));
            int c = GetToReadDoc(cvg);
            if (c>0)
                return string.Format("{0} !", c);
            return string.Empty;
        }

        public object[] ConvertBack(object value, System.Type[] targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }



}