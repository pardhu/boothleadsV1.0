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
using System.Collections.ObjectModel;
using BoothLeads.ServiceClient;
using System.IO;
using BoothLeads.ServiceClient.DataContracts;
using System.Text;
using System.Runtime.Serialization.Json;
using System.Windows.Controls.Primitives;

namespace BoothLeads
{
    public partial class BLLogin : PhoneApplicationPage
    {
        SFLoginResponse slResponse = null;
        
        public BLLogin()
        {
            InitializeComponent();
           
            

        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {

            

        }

        

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            string serviceUri = SalesForceServiceURL.SVC_AUTHORIZATION_URL;//string.Format(SalesForceServiceURL.SVC_AUTHORIZATION_URL, SalesForceServiceURL.SVC_AUTHORIZATION_USERNAME, SalesForceServiceURL.SVC_AUTHORIZATION_PASSWORD);
            WebClient wbClient = new WebClient();
            wbClient.UploadStringCompleted += new UploadStringCompletedEventHandler(wbClient_UploadStringCompleted);
            wbClient.UploadStringAsync(new Uri(serviceUri), "POST", string.Empty);
        }

        void wbClient_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            try
            {
                Stream stream = new MemoryStream(Encoding.Unicode.GetBytes(e.Result));
                DataContractJsonSerializer obj = new DataContractJsonSerializer(typeof(SFLoginResponse));
                slResponse = (SFLoginResponse)obj.ReadObject(stream);
                //txtUserName.Text = slResponse.id;
                BoothLeadGlobalAccess.Access_Token = "Bearer " + slResponse.access_token;
                //BoothLeadGlobalAccess.SfUserId = slResponse.id;

                WebClient wbClient = new WebClient();
                string loginURL = string.Format(SalesForceServiceURL.SVC_LOGIN_URL,txtUserName.Text,txtPassword.Password);
                //string loginURL = string.Format(SalesForceServiceURL.SVC_LOGIN_URL, "dayanand@globalnest.com", "global281");
                //string loginURL = string.Format(SalesForceServiceURL.SVC_LOGIN_URL, "boothleads.de@gmail.com", "booth281");
                //string loginURL = string.Format(SalesForceServiceURL.SVC_LOGIN_URL, "durga@globalnest.com", "global281");
                //string loginURL = string.Format(SalesForceServiceURL.SVC_LOGIN_URL, "meshramraj@gmail.com", "windows123");
                //string loginURL = string.Format(SalesForceServiceURL.SVC_LOGIN_URL, "boothleads.ba@gmail.com", "booth281");
                //string loginURL = string.Format(SalesForceServiceURL.SVC_LOGIN_URL, "boothleads.ea@gmail.com", "global281");
                wbClient.DownloadStringCompleted += new DownloadStringCompletedEventHandler(wbClient_DownloadStringCompleted);
                wbClient.Headers["Authorization"] = BoothLeadGlobalAccess.Access_Token;
                wbClient.DownloadStringAsync(new Uri(loginURL));
                ////wbClient.UploadStringAsync(new Uri(loginURL), "POST", string.Empty);
                //bool bresult = wbClient.IsBusy;
                //SFLoginResponse response = slResponse;
            }
            catch(Exception excp)
            {
                MessageBox.Show(excp.Message);
            }

        }

        void wbClient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            Stream stream = new MemoryStream(Encoding.Unicode.GetBytes(e.Result));
            DataContractJsonSerializer obj = new DataContractJsonSerializer(typeof(UsersDetails));
            BoothLeadGlobalAccess.BLUserDetails = (UsersDetails)obj.ReadObject(stream);
            if (string.IsNullOrEmpty(BoothLeadGlobalAccess.BLUserDetails.error) == false)
                MessageBox.Show(BoothLeadGlobalAccess.BLUserDetails.error);
            else
                NavigationService.Navigate(new Uri(string.Format("/BoothLeads.xaml"), UriKind.Relative));
            
            //NavigationService.Navigate(new Uri(string.Format("/boothleadsMore.xaml"), UriKind.Relative));
            //DataReady(BoothLeadGlobalAccess.BLUserDetails.Edetails[0].Event_ID, BoothLeadGlobalAccess.BLUserDetails.UserID);
            //NavigationService.Navigate(new Uri(string.Format("/BoothLeads.xaml"), UriKind.Relative));
            //NavigationService.Navigate(new Uri(string.Format("/blQRCodeScanner.xaml"), UriKind.Relative));
            //NavigationService.Navigate(new Uri(string.Format("/blEventLeadsGridView.xaml"), UriKind.Relative));
            //NavigationService.Navigate(new Uri(string.Format("/EventDetails.xaml"), UriKind.Relative));
            //NavigationService.Navigate(new Uri(string.Format("/blEventSchedule.xaml"), UriKind.Relative));
            //NavigationService.Navigate(new Uri(string.Format("/blEventExhibitors.xaml"), UriKind.Relative));
            //NavigationService.Navigate(new Uri(string.Format("/BlSyncLeads.xaml"), UriKind.Relative));
            //NavigationService.Navigate(new Uri(string.Format("/UserProfile.xaml"), UriKind.Relative));BlVerifyLead
            //NavigationService.Navigate(new Uri(string.Format("/BlVerifyLead.xaml"), UriKind.Relative));

        }

        private void DataReady(string eventid, string userid)
        {
            string serviceUri = string.Format(SalesForceServiceURL.SVC_DATAREADY_URL, eventid, userid, 2, 3);
            WebClient wbClient1 = new WebClient();
            wbClient1.DownloadStringCompleted += new DownloadStringCompletedEventHandler(wbClientDataReady_DownloadStringCompleted);
            wbClient1.Headers["Authorization"] = BoothLeadGlobalAccess.Access_Token;
            wbClient1.DownloadStringAsync(new Uri(serviceUri));
        }

        void wbClientDataReady_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            Stream stream = new MemoryStream(Encoding.Unicode.GetBytes(e.Result));
            DataContractJsonSerializer obj = new DataContractJsonSerializer(typeof(BLDataready));
            BLDataready evDetails = (BLDataready)obj.ReadObject(stream);

        }

        


        void proxy_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            Stream stream = new MemoryStream(Encoding.Unicode.GetBytes(e.Result));
            DataContractJsonSerializer obj = new DataContractJsonSerializer(typeof(string));
            string result = obj.ReadObject(stream).ToString();

            NavigationService.Navigate(new Uri(string.Format("/blEventSchedule.xaml?val={0}", "constant"), UriKind.Relative));
        }


        private void txtUserName_GotFocus(object sender, RoutedEventArgs e)
        {
            txtUserName.Text = string.Empty;
        }

        private void txtPassword_GotFocus(object sender, RoutedEventArgs e)
        {
            txtPassword.Password = string.Empty;
        }

        
    }
}