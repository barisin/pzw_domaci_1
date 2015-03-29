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

namespace domaci_pzw_1.Controls
{
    /// <summary>
    /// Interaction logic for StatusControl.xaml
    /// </summary>
    public partial class StatusControl : UserControl
    {
        public StatusControl()
        {
            InitializeComponent();
        }

        public string Status
        {
            get { return (string)GetValue(StatusProperty); }
            set { SetValue(StatusProperty, value); }
        }

        public static readonly DependencyProperty StatusProperty = DependencyProperty.Register
        (
          "Status",
          typeof(string),
          typeof(StatusControl),
          new UIPropertyMetadata("What's on your mind?")
        );

        public string Name2
        {
            get { return (string)GetValue(StatusProperty2); }
            set { SetValue(StatusProperty2, value); }
        }

        public static readonly DependencyProperty StatusProperty2 = DependencyProperty.Register
        (
          "Name2",
          typeof(string),
          typeof(StatusControl),
          new UIPropertyMetadata("User2")
        );

       
        private void StatusItemControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.EditStatusButton.MouseLeftButtonUp += EditStatusButton_MouseLeftButtonUp;
        }

        void EditStatusButton_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            RaiseEditStatusEvent();
        }

        private void RaiseEditStatusEvent()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(StatusControl.EditStatus);
            RaiseEvent(newEventArgs);
        }

        public static readonly RoutedEvent EditStatus = EventManager.RegisterRoutedEvent
        (
           "EditStatus", //ime eventa
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(StatusControl) //tip elementa koji posjeduje event
        );

        public event RoutedEventHandler EditStatusHandle //za registraciju/deregistraciju 
        {
            add { AddHandler(EditStatus, value); }
            remove { RemoveHandler(EditStatus, value); }
        }

    }
}
