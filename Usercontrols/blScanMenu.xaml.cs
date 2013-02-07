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
using BoothLeads.ServiceClient;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using BoothLeads.ServiceClient.DataContracts;

namespace BoothLeads.Usercontrols
{
    public partial class blScanMenu : UserControl
    {
        public blScanMenu()
        {
            InitializeComponent();
        }

        private void btnScanAgain_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed; 
            //(App.Current.RootVisual as PhoneApplicationFrame).Navigate(new Uri("/blQRCodeScanner.xaml", UriKind.Relative));
        }

        private void btnVerifyLead_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(BoothLeadGlobalAccess.QRCodeValue) == false)
            {
                string[] values = BoothLeadGlobalAccess.QRCodeValue.Split('-');
                if (values.Length >1)
                {
                    VerifyLeads(BoothLeadGlobalAccess.BLUserDetails.UserID, values[1], values[0]);
                }
            }
        }
        private void VerifyLeads(string userid, string eventId, string qrCodeValue)
        {
            WebClient wbClient = new WebClient();
            wbClient.UploadStringCompleted += new UploadStringCompletedEventHandler(wbClient_UploadStringCompleted);
            string syncLeadsUrl = string.Format(SalesForceServiceURL.SVC_VERIFYLEADS_URL, eventId, userid, qrCodeValue);
            wbClient.Headers["Authorization"] = BoothLeadGlobalAccess.Access_Token;
            wbClient.UploadStringAsync(new Uri(syncLeadsUrl), "POST", string.Empty);
        }

        void wbClient_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            Stream stream = new MemoryStream(Encoding.Unicode.GetBytes(e.Result));
            DataContractJsonSerializer obj = new DataContractJsonSerializer(typeof(VerifyLead));
            VerifyLead slResponse = (VerifyLead)obj.ReadObject(stream);

            if (string.IsNullOrEmpty(slResponse.error) == false)
            {
                MessageBox.Show("Error: " + slResponse.error);
                return;
            }
            else
            {
                BoothLeadGlobalAccess.ScanVerifyLead = slResponse;
                (App.Current.RootVisual as PhoneApplicationFrame).Navigate(new Uri("/UserProfile.xaml", UriKind.Relative));
            }
            
        }

    }
}
