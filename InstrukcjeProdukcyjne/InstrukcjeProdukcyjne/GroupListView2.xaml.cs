using System;
using System.Collections.Generic;
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
            List<User> items = new List<User>();
            items.Add(new User() { Name = "Kay Doe", Age = 13, GroupBy = "Female", ItemIcon = null });
            items.Add(new User() { Name = "Pey Doe", Age = 13, GroupBy = "Female", ItemIcon = null });
            items.Add(new User() { Name = "Rey Doe", Age = 13, GroupBy = "Female2", ItemIcon = null });


            System.Windows.Media.Color c = Colors.Gray;
            c.A = 200;
            PanelColor = new SolidColorBrush(c);
            ColumnsCnt = 3;


            //lvUsers.ItemsSource = items; 
            //CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvUsers.ItemsSource);
            //PropertyGroupDescription groupDescription = new PropertyGroupDescription("GroupBy");
            //view.GroupDescriptions.Add(groupDescription);
        }


        public List<Object> DataSource
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
                PropertyGroupDescription groupDescription = new PropertyGroupDescription("GroupBy");
                view.GroupDescriptions.Add(groupDescription);
            }


        }




        /// <summary>
        ///  lista do prezentacji
        /// </summary>
        public List<Object> Items = new List<Object>();


        /// <summary>
        /// domyśly rBrush kafelka
        /// </summary>
        public SolidColorBrush PanelColor { get; set; }

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
                //User u = (User)x;
                //MessageBox.Show(u.Name);
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
