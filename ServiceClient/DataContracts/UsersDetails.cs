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
    public class VerifyLead
    {
        public string Title { get; set; }
        public string State { get; set; }
        public string PhoneNo { get; set; }
        public string LastName { get; set; }
        public string ImageUrl { get; set; }
        public string Firstname { get; set; }
        public string error { get; set; }
        public string Email { get; set; }
        public string country { get; set; }
        public string Company { get; set; }
        public string City { get; set; }
        public string BarcodeId { get; set; }
    }
    public class UsersDetails
    {
        public string UserID { get; set; }
        public bool isfreeuser { get; set; }
        public string Event_StartDate { get; set; }
        public string Session_ID { get; set; }
        public string User_Login_Time { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public string error { get; set; }
        public string message { get; set; }
        public string ImageUrl { get; set; }
        public string Country { get; set; }
        public List<BldbEventdetails> Edetails { get; set; }

    }

    //[{"State":"Bihar","Phoneno":"7565558952","FirstName":"Booth","Country":"India","Company":"Globalnes","LastName":"Admin","City":"aj","ImageBlob":"null"}]
    public class UpdateUserProfile
    {
        public string State { get; set; }
        public string Phoneno { get; set; }
        public string FirstName { get; set; }
        public string Country { get; set; }
        public string Company { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string ImageBlob { get; set; }
    }

    public class BldbEventdetails
    {
        public string Status { get; set; }
        public string HostingZipcode { get; set; }
        public string HostingState { get; set; }
        public string HostingPhone { get; set; }
        public string HostingCountry { get; set; }
        public string HostingCity { get; set; }
        public string HostingAddr2 { get; set; }
        public string HostingAddr1 { get; set; }
        public string EventLogoImageURL { get; set; }
        public string Event_StartHour { get; set; }
        public string Event_StartDate { get; set; }
        public string Event_Name { get; set; }
        public string Event_Location { get; set; }
        public string Event_ID { get; set; }
        public string Event_EndHour { get; set; }
        public string Event_Description { get; set; }
        public string Event_Date { get; set; }
    }
}
