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
using System.Windows.Media.Imaging;

namespace BoothLeads.ServiceClient.DataContracts
{
    public class LeadDetail
    {
        public string SurveyQuestion4 { get; set; }
        public string SurveyQuestion3 { get; set; }
        public string SurveyQuestion2 { get; set; }
        public string SurveyQuestion1 { get; set; }
        public string SurveyAnswer4 { get; set; }
        public string SurveyAnswer3 { get; set; }
        public string SurveyAnswer2 { get; set; }
        public string SurveyAnswer1 { get; set; }
        public string state { get; set; }
        public string ScanTime { get; set; }
        public string RecordId { get; set; }
        public string Phone { get; set; }
        public string NumberOfVisits { get; set; }
        public string Notes { get; set; }
        public string NextFollowUpdate { get; set; }
        public string leadRating { get; set; }
        public string leadId { get; set; }
        public string LeadCategory { get; set; }
        public string Lastname { get; set; }
        public string imageUrl { get; set; }
        public string ImageBlob { get; set; }
        public string FollowupTypes { get; set; }
        public string Firstname { get; set; }
        public string EventId { get; set; }
        public string Email { get; set; }
        public string Designation { get; set; }
        public string Company { get; set; }
        public string City { get; set; }
        public string BoothPersonnelId { get; set; }
        public string Barcodeid { get; set; }
        public string Barcode { get; set; }
        public string AttendeeId { get; set; }
    }


    public class ListViewLeadItem
    {
        public string LeadName { get; set; }
        public string ImageUrl { get; set; }
        public string CompanyName { get; set; }
        public string Barcodeid { get; set; }
        public BitmapImage ImageSource { get; set; }
        public BitmapImage Rating1 { get; set; }
        public BitmapImage Rating2 { get; set; }
        public BitmapImage Rating3 { get; set; }
        public BitmapImage Rating4 { get; set; }
        public BitmapImage Rating5 { get; set; }
    }


 }
