using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

using System.Windows.Controls.Primitives;
using BoothLeads.Usercontrols;


namespace BoothLeads
{
    public partial class boothLeadsHeader : UserControl
    {
        public boothLeadsHeader()
        {
            InitializeComponent();

        }

        public string HeaderText { get; set; }
        public string PreviousPage { get; set; }

        private void btnLeads_Click(object sender, RoutedEventArgs e)
        {
            
            (App.Current.RootVisual as PhoneApplicationFrame).Navigate(new Uri("/BoothLeads.xaml", UriKind.Relative));
        }


        private void btnMore_Click(object sender, RoutedEventArgs e)
        {
            Popup popup;
            popup = new Popup();
            popup.Child = new blHeaderMenuItems();
            popup.VerticalOffset = 86;
            popup.HorizontalOffset = 2;
            popup.IsOpen = true; 
        }

        public Visibility VisibleScanButton
        {
            set
            {
                btnScan.Visibility = value;
            }
        }

        public Visibility VisibleLeadsButton
        {
            set
            {
                btnLeads.Visibility = value;
            }
        }

        public Visibility VisibleMoreButton
        {
            set
            {
                btnMore.Visibility = value;
            }
        }

        

        
        private void btnScan_Click(object sender, RoutedEventArgs e)
        {
            
            (App.Current.RootVisual as PhoneApplicationFrame).Navigate(new Uri("/blQRCodeScanner.xaml", UriKind.Relative));
        }

    }
}
