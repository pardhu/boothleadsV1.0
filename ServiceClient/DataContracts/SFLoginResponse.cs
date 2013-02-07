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
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace BoothLeads.ServiceClient.DataContracts
{
    public class SFLoginResponse : ServiceResponse
    {
        public string access_token { get; set; }
        public string id { get; set; }
        public string instance_url { get; set; }
        public string issued_at { get; set; }
        public string signature { get; set; }
    }

    public class ServiceResponse
    {
        public int Code { get; set; }
        public string Message { get; set; }
    }

    public class SyncLeadResponse
    {
        public string message { get; set; }
    }
}
