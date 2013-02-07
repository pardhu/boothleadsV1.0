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


namespace BoothLeads.Usercontrols
{
    public partial class blHeaderMenuItems : UserControl
    {
        public blHeaderMenuItems()
        {
            InitializeComponent();
        }

        private void btnScanLeads_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = System.Windows.Visibility.Collapsed;
            (App.Current.RootVisual as PhoneApplicationFrame).Navigate(new Uri("/blQRCodeScanner.xaml", UriKind.Relative));
        }

        private void btnMenuEvents_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = System.Windows.Visibility.Collapsed;
            (App.Current.RootVisual as PhoneApplicationFrame).Navigate(new Uri("/blEvents.xaml", UriKind.Relative));
        }

        private void btnMenuSettings_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = System.Windows.Visibility.Collapsed;
            (App.Current.RootVisual as PhoneApplicationFrame).Navigate(new Uri("/UserProfile.xaml", UriKind.Relative));
        }

        private void btnMenuLogout_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void UserControl_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Visibility = System.Windows.Visibility.Collapsed;
        }

        

        private void UserControl_MouseMove(object sender, MouseEventArgs e)
        {
            this.Visibility = System.Windows.Visibility.Collapsed;
        }
    }
}
