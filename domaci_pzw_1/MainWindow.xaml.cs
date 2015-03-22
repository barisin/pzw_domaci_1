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
            this.left_cont.Children.Add(new Rectangle()
            {
                Height = 60,
                Width = 60,
                Fill = Brushes.Coral,
                Margin = new Thickness(10)
            });
        }

       
    }
}
