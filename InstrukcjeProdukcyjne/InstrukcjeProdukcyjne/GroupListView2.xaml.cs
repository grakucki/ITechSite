using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InstrukcjeProdukcyjne
{
    /// <summary>
    /// Interaction logic for GroupListView2.xaml
    /// </summary>
    public partial class GroupListView2 : UserControl
    {
        public GroupListView2()
        {
            InitializeComponent();

            System.Windows.Media.Color c = Colors.Gray;
            c.A = 200;
            PanelColor = new SolidColorBrush(c);
            c = Colors.Blue;
            c.A = 200;
            Panel2ReadColor = new SolidColorBrush(c);

            ColumnsCnt = 2;

        }


        public ObservableCollection<MyFileInfo> DataSource
        {
            get
            { 
                return Items;
            }
            set 
            {
                lvUsers.ItemsSource = null;
                Items = value;
                lvUsers.ItemsSource = Items;

                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvUsers.ItemsSource);
                if (view.GroupDescriptions.Count == 0)
                {
                    PropertyGroupDescription groupDescription = new PropertyGroupDescription("GroupBy");
                    view.GroupDescriptions.Add(groupDescription);
                    
                }

                
            }
        }


        public void Refresh()
        {
            //CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvUsers.ItemsSource);
            //view.Refresh();
                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvUsers.ItemsSource);
            //http://stackoverflow.com/questions/10878500/listview-grouping-does-not-update-when-bound-property-is-changed
            
        }

        /// <summary>
        ///  lista do prezentacji
        /// </summary>
        public ObservableCollection<MyFileInfo> Items = new ObservableCollection<MyFileInfo>();


        /// <summary>
        /// domyśly rBrush kafelka
        /// </summary>
        public SolidColorBrush PanelColor { get; set; }


        /// <summary>
        /// domyśly rBrush kafelka
        /// </summary>
        public SolidColorBrush Panel2ReadColor { get; set; }

        /// <summary>
        /// Liczba kolumn
        /// </summary>
        public int ColumnsCnt { get; set; }


        public delegate  void ChangedEventHandler (object sender, object e);

        public event  ChangedEventHandler OnMouseDoubleClickItem;


        private void lvUsers_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var x = lvUsers.SelectedItem;
            
            if (x != null)
            {
                if (OnMouseDoubleClickItem!=null)
                    OnMouseDoubleClickItem(sender, x);
            }
        }

        bool _DoScroll = false;
        private void lvUsers_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _DoScroll = true;
        }

        private void lvUsers_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            _DoScroll = false;

        }

        private void lvUsers_MouseMove(object sender, MouseEventArgs e)
        {
            if (_DoScroll)
            {
                
            }
        }

    }



    public class User
    {

        public string ItemText { get; set; }
        public string ItemText2 { get; set; }
        public ImageSource ItemIcon { get; set; }


        public ImageSource imageSourceForImageControl(Bitmap img)
        {
            ImageSourceConverter c = new ImageSourceConverter();
            return (ImageSource)c.ConvertFrom(img);
        }

        public void SetImage(Bitmap img)
        {
            ItemIcon = imageSourceForImageControl(img);
        }
        public string GroupBy { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Mail { get; set; }
    }
}
