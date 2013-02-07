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

namespace BoothLeads.ServiceClient.DataContracts
{
    public class BLSFEXHIBITORS
    {
        public string Message { get; set; }
        public string Booth_Website { get; set; }
        public string Booth_Name { get; set; }
        public string Booth_ID { get; set; }
        public string Booth_Description { get; set; }
        public string Booth_ContactPhoneNo { get; set; }
        public string Booth_ContactName { get; set; }
        public string Booth_ContactEmail { get; set; }
    }
}
