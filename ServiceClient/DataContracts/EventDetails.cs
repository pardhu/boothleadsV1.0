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
using System.Windows.Media.Imaging;

namespace BoothLeads.ServiceClient.DataContracts
{
    public class EventDetail
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public string EventLogoImageURL { get; set; }
        public string Event_Type { get; set; }
        public string Event_StartHour { get; set; }
        public string Event_StartDate { get; set; }
        public string Event_Name { get; set; }
        public string Event_Location { get; set; }
        public string Event_ID { get; set; }
        public string Event_EndHour { get; set; }
        public string Event_EndDate { get; set; }
    }


    public class ListViewEventItem
    {
        public string EventId { get; set; }
        public BitmapImage ImageSource { get; set; }
        
    }
}
