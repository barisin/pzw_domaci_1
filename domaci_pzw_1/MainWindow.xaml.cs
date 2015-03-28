using System;
using System.Collections.Generic;
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
using domaci_pzw_1.Controls;

namespace domaci_pzw_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void _OnWindowLoad(object sender, RoutedEventArgs e)
        {
            this.left_button.MouseLeftButtonDown += new MouseButtonEventHandler(left_button_MouseLeftButtonDown);
            this.right_button.MouseLeftButtonDown += new MouseButtonEventHandler(right_button_MouseLeftButtonDown);
            this.You.ImageItemControl.Delete += ImageItemControl_Delete;

            for (var i = 0; i < this.left_cont.Children.Count; i++)
            {
                var element = this.left_cont.Children[i];
                if (element is ImageControl)
                {
                    var mediaItem = (ImageControl)element;
                    mediaItem.Delete += mediaItem_Delete;
                    mediaItem.Edit += mediaItem_Edit;
                }
            }
        }

        void mediaItem_Edit(object sender, RoutedEventArgs e)
        {
            if (!(sender is ImageControl)) { return; }
            var mediaItem = sender as ImageControl;

            var indexOfElement = this.left_cont.Children.IndexOf(mediaItem);

            if (indexOfElement == -1) { return; }



            mediaItem.Title = "";
        }

        void ImageItemControl_Delete(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("You cannot delete yourself!", "Error");
        }

        void mediaItem_Delete(object sender, RoutedEventArgs e)
        {
            if (!(sender is ImageControl)) { return; }
            var mediaItem = sender as ImageControl;

            var indexOfElement = this.left_cont.Children.IndexOf(mediaItem);

            if (indexOfElement == -1) { return; }

            this.left_cont.Children.RemoveAt(indexOfElement);
        }

        void right_button_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            this.right_cont.Children.Add(new Rectangle()
            {
                Height=40,
                Fill=Brushes.DarkRed,
                Margin=new Thickness(10)                
            });
        }

        void left_button_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.left_cont.Children.Add(new ImageControl()
            {
                Height = 80,
                Width = 80,
                Margin = new Thickness(5)
            });

                var element = this.left_cont.Children[this.left_cont.Children.Count-1];
                if (element is ImageControl)
                {
                    var mediaItem = (ImageControl)element;
                    mediaItem.Delete += mediaItem_Delete;
                }
        }

        private void ImageControl_Loaded(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("ALERT", "OK");
        }

       
    }
}
