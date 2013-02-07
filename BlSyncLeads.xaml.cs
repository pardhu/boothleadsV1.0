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
using System.IO;
using System.Text;
using System.Runtime.Serialization.Json;
using BoothLeads.ServiceClient;
using BoothLeads.ServiceClient.DataContracts;

namespace BoothLeads
{
    public partial class BlSyncLeads : PhoneApplicationPage
    {
        public BlSyncLeads()
        {
            InitializeComponent();

            boothLeadsHeader boothLead = new boothLeadsHeader();
            boothLead.HeaderText = "Sync Lead";
            boothLead.PreviousPage = "mainpage";
            TitlePanel.Children.Add(boothLead);
            //SyncLeads(BoothLeadGlobalAccess.BLUserDetails.UserID,BoothLeadGlobalAccess.BLUserDetails.Edetails[0].Event_ID);
            DeviceUsage(BoothLeadGlobalAccess.BLUserDetails.UserID, BoothLeadGlobalAccess.BLUserDetails.Edetails[0].Event_ID);
        }

        private void DeviceUsage(string userid, string eventId)
        {
            WebClient wbClient = new WebClient();
            wbClient.DownloadStringCompleted += new DownloadStringCompletedEventHandler(wbClient_DownloadStringCompleted);
            string devUiseusageUrl = string.Format(SalesForceServiceURL.SVC_DEVICE_USAGE_URL, eventId, userid, "", "");
            wbClient.Headers["Authorization"] = BoothLeadGlobalAccess.Access_Token;
            wbClient.DownloadStringAsync(new Uri(devUiseusageUrl));
        }

        void wbClient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            Stream stream = new MemoryStream(Encoding.Unicode.GetBytes(e.Result));
            DataContractJsonSerializer obj = new DataContractJsonSerializer(typeof(ServiceResponse));
            ServiceResponse slResponse = (ServiceResponse)obj.ReadObject(stream);
        }
        private void SyncLeads(string userid, string eventId)
        {
            WebClient wbClient = new WebClient();
            wbClient.UploadStringCompleted += new UploadStringCompletedEventHandler(wbClient_UploadStringCompleted);
            string syncLeadsUrl = string.Format(SalesForceServiceURL.SVC_SYNCHLEADS_URL, eventId, userid);
            wbClient.Headers["Authorization"] = BoothLeadGlobalAccess.Access_Token;
            wbClient.UploadStringAsync(new Uri(syncLeadsUrl), "POST", string.Empty);
        }

        void wbClient_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            Stream stream = new MemoryStream(Encoding.Unicode.GetBytes(e.Result));
            DataContractJsonSerializer obj = new DataContractJsonSerializer(typeof(SyncLeadResponse));
            SyncLeadResponse slResponse = (SyncLeadResponse)obj.ReadObject(stream);
        }


    }
}