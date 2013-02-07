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
using System.Text;
using System.Runtime.Serialization.Json;
using BoothLeads.ServiceClient.DataContracts;
using System.Windows.Media.Imaging;
using System.IO.IsolatedStorage;
using System.Windows.Resources;

namespace BoothLeads
{
    public partial class UserProfile : PhoneApplicationPage
    {
        private byte[] contents;
        public UserProfile()
        {
            InitializeComponent();
            boothLeadsHeader boothLead = new boothLeadsHeader();
            boothLead.HeaderText = BoothLeadGlobalAccess.BLUserDetails.FirstName + " " + BoothLeadGlobalAccess.BLUserDetails.LastName;
            boothLead.PreviousPage = "BoothLeads";
            TitlePanel.Children.Add(boothLead);
        }

        //private void ReadFile()
        //{
        //    WebClient client = new WebClient();
        //    client.OpenReadCompleted += new OpenReadCompletedEventHandler(client_OpenReadCompleted);
        //    client.OpenReadAsync(new Uri("http://d3sdoylwcs36el.cloudfront.net/VEN-virtual-enterprise-network-business-opportunities-small-fish_id799929_size485.jpg"));
        //    //client.OpenReadAsync(new Uri("/Images/defaultUser.png",UriKind.Relative));
        //}

        //void client_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
        //{
        //    var resInfo = new StreamResourceInfo(e.Result, null);
        //    var reader = new StreamReader(resInfo.Stream);
        //    using (BinaryReader bReader = new BinaryReader(reader.BaseStream))
        //    {
        //        contents = bReader.ReadBytes((int)reader.BaseStream.Length);
        //    }

        //}

        private void ContentPanel_Loaded(object sender, RoutedEventArgs e)
        {

            if (BoothLeadGlobalAccess.ScanVerifyLead != null)
            {
                txtFirstName.Text = BoothLeadGlobalAccess.ScanVerifyLead.Firstname;
                txtLastName.Text = BoothLeadGlobalAccess.ScanVerifyLead.LastName;
                txtCity.Text = BoothLeadGlobalAccess.ScanVerifyLead.City;
                txtCompany.Text = BoothLeadGlobalAccess.ScanVerifyLead.Company;
                txtEmail.Text = BoothLeadGlobalAccess.ScanVerifyLead.Email;
                txtPhonenumber.Text = BoothLeadGlobalAccess.ScanVerifyLead.PhoneNo;
                txtCountry.Text = BoothLeadGlobalAccess.ScanVerifyLead.country;
                txtState.Text = BoothLeadGlobalAccess.ScanVerifyLead.State;
                if (string.IsNullOrEmpty(BoothLeadGlobalAccess.ScanVerifyLead.ImageUrl))
                    userImage.Source = new BitmapImage { UriSource = new Uri("/Images/defaultUser.png", UriKind.Relative) };
                else
                    userImage.Source = new BitmapImage { UriSource = new Uri(BoothLeadGlobalAccess.ScanVerifyLead.ImageUrl) };

                BoothLeadGlobalAccess.ScanVerifyLead = null;
                btnSave.Visibility = System.Windows.Visibility.Collapsed;
                btnCancel.Visibility = System.Windows.Visibility.Collapsed;

            }
            else
            {
                LoadLeadDetails();
                btnSave.Visibility = System.Windows.Visibility.Visible;
                btnCancel.Visibility = System.Windows.Visibility.Visible;
            }
            //ReadFile();
        }

        private void LoadLeadDetails()
        {
            UsersDetails userDetail = BoothLeadGlobalAccess.BLUserDetails;
            txtFirstName.Text = userDetail.FirstName;
            txtLastName.Text = string.IsNullOrEmpty(userDetail.LastName) ? string.Empty : userDetail.LastName;
            txtCity.Text = string.IsNullOrEmpty(userDetail.City) ? string.Empty : userDetail.City;
            txtCompany.Text = string.IsNullOrEmpty(userDetail.Company) ? string.Empty : userDetail.Company;
            txtEmail.Text = string.IsNullOrEmpty(userDetail.Email) ? string.Empty : userDetail.Email;
            txtPhonenumber.Text = string.IsNullOrEmpty(userDetail.PhoneNo) ? string.Empty : userDetail.PhoneNo;
            txtState.Text = string.IsNullOrEmpty(userDetail.State) ? string.Empty : userDetail.State;
            txtCountry.Text = userDetail.Country;
            if (string.IsNullOrEmpty(userDetail.ImageUrl) || userDetail.ImageUrl == "null")
                userImage.Source = new BitmapImage { UriSource = new Uri("/Images/defaultUser.png", UriKind.Relative) };
            else
            {
                BitmapImage bitmapImage = new BitmapImage();
                byte[] imageBlob = Convert.FromBase64String(userDetail.ImageUrl);
                MemoryStream ms = new MemoryStream(Convert.FromBase64String(userDetail.ImageUrl));
                bitmapImage.SetSource(ms);
                userImage.Source = bitmapImage;
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string str64base = string.Empty;
            if (contents != null)
            {
                str64base = Convert.ToBase64String(contents);
            }
           

            UpdateUserProfile userprofile = new UpdateUserProfile();
            userprofile.City = txtCity.Text;
            userprofile.Company = txtCompany.Text;
            userprofile.Country = txtCountry.Text;
            userprofile.FirstName = txtFirstName.Text;
            userprofile.LastName = txtLastName.Text;
            userprofile.Phoneno = txtPhonenumber.Text;
            userprofile.State = txtState.Text;
            if (string.IsNullOrEmpty(BoothLeadGlobalAccess.BLUserDetails.ImageUrl) == false)
            {
                userprofile.ImageBlob = BoothLeadGlobalAccess.BLUserDetails.ImageUrl != "null" ? BoothLeadGlobalAccess.BLUserDetails.ImageUrl : "null";
            }
            
            WebClient wbClient = new WebClient();

            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(UpdateUserProfile));
            MemoryStream ms = new MemoryStream();
            serializer.WriteObject(ms, userprofile);

            string bodyJson = "[" + Encoding.UTF8.GetString(ms.ToArray(), 0, Convert.ToInt32(ms.Length)) + "]";

            string updateURL = string.Format(SalesForceServiceURL.SVC_SAVE_USER_PROFILE_URL, BoothLeadGlobalAccess.BLUserDetails.UserID);
            wbClient.UploadStringCompleted += new UploadStringCompletedEventHandler(wbClient_UploadStringCompleted);
            wbClient.Headers["Authorization"] = BoothLeadGlobalAccess.Access_Token;

            wbClient.UploadStringAsync(new Uri(updateURL), "POST", bodyJson);
        }

        void wbClient_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            Stream stream = new MemoryStream(Encoding.Unicode.GetBytes(e.Result));
            DataContractJsonSerializer obj = new DataContractJsonSerializer(typeof(ServiceResponse));
            ServiceResponse slResponse = (ServiceResponse)obj.ReadObject(stream);
            if (string.IsNullOrEmpty(slResponse.Message) == false)
                MessageBox.Show(slResponse.Message);
            else
                MessageBox.Show("Unable to update user profile");

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri(string.Format("/BoothLeads.xaml"), UriKind.Relative));
        }
    }
}