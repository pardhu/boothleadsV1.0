using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using BoothLeads.ServiceClient.DataContracts;
using System.IO.IsolatedStorage;
using System.IO;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Collections.Generic;


namespace BoothLeads
{
    public static class BoothLeadGlobalAccess
    {
        public static string Access_Token { get; set; }
        public static string SfUserId { get; set; }
        public static UsersDetails BLUserDetails { get; set; }
        public static string QRCodeValue { get; set; }

        public static VerifyLead ScanVerifyLead { get; set; }
        
    }

    
    public static class ProxyLeadList
    {
        public static List<LeadDetail> Leads { get; set; }
    }


}

