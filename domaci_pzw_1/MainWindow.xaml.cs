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

            for (var i = 0; i < this.right_cont.Children.Count; i++)
            {
                var element = this.right_cont.Children[i];
                if (element is StatusControl)
                {
                    var mediaItem = (StatusControl)element;
                    mediaItem.ImgCtrl.Delete += ImgCtrl_Delete;
                    mediaItem.ImgCtrl.Edit += ImgCtrl_Edit;
                }
            }
        }

        void ImgCtrl_Edit(object sender, RoutedEventArgs e)
        {
            if (!(sender is ImageControl)) { return; }
            var mediaItem = sender as ImageControl;
            var imgItem = mediaItem.Parent as Grid;
            var a = imgItem.Parent as Viewbox;
            var b = a.Parent as StatusControl;

            var indexOfElement = this.right_cont.Children.IndexOf(b);
            
            if (indexOfElement == -1) { return; }

            string promptValue = prompt.ShowDialog("New name: ", "Edit name");

            if (promptValue != "")
               b.ImgCtrl.Title = promptValue;
        }

        void ImgCtrl_Delete(object sender, RoutedEventArgs e)
        {
            if (!(sender is ImageControl)) { return; }
            var mediaItem = sender as ImageControl;
            var imgItem = mediaItem.Parent as Grid;
            var a = imgItem.Parent as Viewbox;
            var b = a.Parent as StatusControl;
          
            var indexOfElement = this.right_cont.Children.IndexOf(b);

            if (indexOfElement == -1) { return; }

            this.right_cont.Children.RemoveAt(indexOfElement);
        }

        void mediaItem_Edit(object sender, RoutedEventArgs e)
        {
            if (!(sender is ImageControl)) { return; }
            var mediaItem = sender as ImageControl;

            var indexOfElement = this.left_cont.Children.IndexOf(mediaItem);

            if (indexOfElement == -1) { return; }

            string promptValue = prompt.ShowDialog("New name: ", "Edit name");

            if(promptValue!="")
                mediaItem.Title = promptValue;
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

            this.right_cont.Children.Add(new StatusControl()
            {
                Height=80,
                Margin=new Thickness(10),
                HorizontalAlignment = 0
            });

            var element = this.right_cont.Children[this.right_cont.Children.Count - 1];
            if (element is StatusControl)
            {
                var mediaItem = (StatusControl)element;
                mediaItem.ImgCtrl.Delete += ImgCtrl_Delete;
                mediaItem.ImgCtrl.Edit += ImgCtrl_Edit;
            }
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
                    mediaItem.Edit += mediaItem_Edit;
                }
        }

        private void ImageControl_Loaded(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("ALERT", "OK");
        }

       
    }
}
