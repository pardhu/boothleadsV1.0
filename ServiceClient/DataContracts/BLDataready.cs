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
using System.Collections.Generic;

namespace BoothLeads.ServiceClient.DataContracts
{
    public class BLDataready
    {
        public List<BLDataReadyAttendeeDetail> Atd1 { get; set; }
        public List<BLDataReadyBoothDetail> booth5 { get; set; }
        public List<SFEventSchedule> Esc {get;set;}
    }

    public class BLDataReadyAttendeeDetail
    {
        public string Attendee_QR_ID { get; set; }
        public string barcode { get; set; }
        public string barcodeId { get; set; }
        public string City { get; set; }
        public string Company { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string Image { get; set; }
        public string LastName { get; set; }
        public string message { get; set; }
        public string PhoneNo { get; set; }
        public string State { get; set; }
        public string Title { get; set; }
    }

    public class BLDataReadyBoothDetail
    {
        public string Booth_ContactEmail { get; set; }
        public string Booth_ContactName { get; set; }
        public string Booth_ContactPhoneNo { get; set; }
        public string Booth_Description { get; set; }
        public string Booth_ID { get; set; }
        public string Booth_Location { get; set; }
        public string Booth_Name { get; set; }
        public string Booth_PdfLocationLink { get; set; }
        public string Booth_Phone { get; set; }
        public string Booth_RegistrationLink { get; set; }
        public string Booth_Website { get; set; }
        public string Message { get; set; }
    }
}
