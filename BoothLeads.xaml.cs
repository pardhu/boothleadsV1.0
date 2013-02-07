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
using System.Runtime.Serialization.Json;
using System.Text;
using BoothLeads.ServiceClient.DataContracts;
using System.Windows.Media.Imaging;

namespace BoothLeads
{
    public partial class BoothLeads : PhoneApplicationPage
    {
        private List<LeadDetail> eventLeadsGlobal = null;
        public BoothLeads()
        {
            InitializeComponent();
            boothLeadsHeader boothLead = new boothLeadsHeader();
            boothLead.HeaderText = "Leads";
            boothLead.PreviousPage = "mainpage";
            TitlePanel.Children.Add(boothLead);

            
        }

        private void ContentPanel_Loaded(object sender, RoutedEventArgs e)
        {
            LoadEvenLeads();
        }

        private void LoadEvenLeads()
        {
            WebClient wbClient = new WebClient();
            string leadURL = string.Format(SalesForceServiceURL.SVC_GETLEADS_URL, null, BoothLeadGlobalAccess.BLUserDetails.UserID);
            wbClient.UploadStringCompleted += new UploadStringCompletedEventHandler(wbClient_UploadStringCompleted);
            wbClient.Headers["Authorization"] = BoothLeadGlobalAccess.Access_Token;
            wbClient.UploadStringAsync(new Uri(leadURL), "POST", string.Empty);
        }

        void wbClient_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            Stream stream = new MemoryStream(Encoding.Unicode.GetBytes(e.Result));
            DataContractJsonSerializer obj = new DataContractJsonSerializer(typeof(List<LeadDetail>));
            eventLeadsGlobal = (List<LeadDetail>)obj.ReadObject(stream);
            LoadListView(eventLeadsGlobal,null);
            ProxyLeadList.Leads = eventLeadsGlobal;
        }

        private void LoadListView(List<LeadDetail> evenLeads, string selectedButton)
        {
            List<ListViewLeadItem> eventLeads = new List<ListViewLeadItem>();
            byte[] imageBlob = null;
            string imagePath = string.Empty;
            string strBase64string = string.Empty;

            BitmapImage bitmapImage = null;
            MemoryStream ms = null;
            string userid = string.Empty;
            ListViewLeadItem addItem = null;
            foreach (LeadDetail lead in evenLeads)
            {
                bitmapImage = new BitmapImage();
                if (lead.ImageBlob != null)
                {
                    imageBlob = Convert.FromBase64String(lead.ImageBlob);
                    ms = new MemoryStream(Convert.FromBase64String(lead.ImageBlob));
                    bitmapImage.SetSource(ms);
                }
                else
                {
                    bitmapImage.UriSource = new Uri("/Images/defaultUser.png", UriKind.Relative);
                }

                addItem = new ListViewLeadItem();
                addItem.CompanyName = lead.Company;
                addItem.LeadName = lead.Firstname + " " + lead.Lastname;
                addItem.ImageSource = bitmapImage;
                addItem.Barcodeid = lead.Barcodeid;
                if (string.IsNullOrEmpty(lead.leadRating))
                    lead.leadRating = "0";
                switch (Convert.ToInt32(lead.leadRating))
                {
                    case 0:
                        break;
                    case 1:
                        addItem.Rating1 = new BitmapImage { UriSource = new Uri("/Images/RatingStart.png", UriKind.Relative) };
                        break;
                    case 2:
                        addItem.Rating1 = new BitmapImage { UriSource = new Uri("/Images/RatingStart.png", UriKind.Relative) };
                        addItem.Rating2 = new BitmapImage { UriSource = new Uri("/Images/RatingStart.png", UriKind.Relative) };
                        break;
                    case 3:
                        addItem.Rating1 = new BitmapImage { UriSource = new Uri("/Images/RatingStart.png", UriKind.Relative) };
                        addItem.Rating2 = new BitmapImage { UriSource = new Uri("/Images/RatingStart.png", UriKind.Relative) };
                        addItem.Rating3 = new BitmapImage { UriSource = new Uri("/Images/RatingStart.png", UriKind.Relative) };
                        break;
                    case 4:
                        addItem.Rating1 = new BitmapImage { UriSource = new Uri("/Images/RatingStart.png", UriKind.Relative) };
                        addItem.Rating2 = new BitmapImage { UriSource = new Uri("/Images/RatingStart.png", UriKind.Relative) };
                        addItem.Rating3 = new BitmapImage { UriSource = new Uri("/Images/RatingStart.png", UriKind.Relative) };
                        addItem.Rating4 = new BitmapImage { UriSource = new Uri("/Images/RatingStart.png", UriKind.Relative) };
                        break;
                    case 5:
                        addItem.Rating1 = new BitmapImage { UriSource = new Uri("/Images/RatingStart.png", UriKind.Relative) };
                        addItem.Rating2 = new BitmapImage { UriSource = new Uri("/Images/RatingStart.png", UriKind.Relative) };
                        addItem.Rating3 = new BitmapImage { UriSource = new Uri("/Images/RatingStart.png", UriKind.Relative) };
                        addItem.Rating4 = new BitmapImage { UriSource = new Uri("/Images/RatingStart.png", UriKind.Relative) };
                        addItem.Rating5 = new BitmapImage { UriSource = new Uri("/Images/RatingStart.png", UriKind.Relative) };
                        break;
                }
                eventLeads.Add(addItem);
                //eventLeads.Add(new ListViewLeadItem { CompanyName = lead.Company, LeadName = lead.Firstname + " " + lead.Lastname, ImageSource = bitmapImage, Rating = lead.leadRating, UserId = userid, EventId = lead.EventId, Rating1 = new BitmapImage { UriSource = new Uri("/Images/RatingStart.png", UriKind.Relative) }, Rating2 = new BitmapImage { UriSource = new Uri("/Images/RatingStart.png", UriKind.Relative) } });
            }
            lstView.ItemsSource = eventLeads;

            if (string.IsNullOrEmpty(selectedButton) == false)
            {
                List<string> buttonList = new List<string> {"COMPANY","DATE","NAME","RATING" };
                ImageBrush imgCompany = null;
                foreach (string buttonName in buttonList)
                {
                    imgCompany = new ImageBrush();
                    if (buttonName.ToUpper() == selectedButton.ToUpper())
                        imgCompany.ImageSource = new BitmapImage(new Uri("/BoothLeads;component/Images/btnAfterclick.png", UriKind.Relative));
                    else
                        imgCompany.ImageSource = new BitmapImage(new Uri("/BoothLeads;component/Images/btnBeforeClick.png", UriKind.Relative));

                    imgCompanyAfter = imgCompany;
                    switch (buttonName.ToUpper())
                    {
                        case "COMPANY":
                            btnCompany.Background = imgCompanyAfter;
                            break;
                        case "DATE":
                            btnDate.Background = imgCompanyAfter;
                            break;
                        case "NAME":
                            btnName.Background = imgCompanyAfter;
                            break;
                        case "RATING":
                            btnRating.Background = imgCompanyAfter;
                            break;
                    }
                }
               
            }
            
           
            
            
        }



        private void btnCompany_Click(object sender, RoutedEventArgs e)
        {
            List<LeadDetail> leadsComp = new List<LeadDetail>();
            IEnumerable<LeadDetail> companylist = eventLeadsGlobal.OrderBy(comp => comp.Company);
            foreach (LeadDetail company in companylist)
            {
                if (string.IsNullOrEmpty(company.Company) == false)
                    leadsComp.Add(company);
            }

            

            LoadListView(leadsComp,"Company");
        }

        private void btnName_Click(object sender, RoutedEventArgs e)
        {
            List<LeadDetail> leadsName = new List<LeadDetail>();
            IEnumerable<LeadDetail> nameList = eventLeadsGlobal.OrderBy(comp => comp.Firstname);
            foreach (LeadDetail fname in nameList)
            {
                if (string.IsNullOrEmpty(fname.Firstname) == false)
                    leadsName.Add(fname);
            }

            LoadListView(leadsName,"Name");
        }

        private void btnDate_Click(object sender, RoutedEventArgs e)
        {
            List<LeadDetail> leadsDate = new List<LeadDetail>();
            IEnumerable<LeadDetail> companylist = eventLeadsGlobal.OrderBy(nextfollow => nextfollow.NextFollowUpdate);
            foreach (LeadDetail dates in eventLeadsGlobal)
            {
                if (string.IsNullOrEmpty(dates.ScanTime) == false)
                    leadsDate.Add(dates);
            }
            LoadListView(leadsDate,"Date");
        }

        private void btnRating_Click(object sender, RoutedEventArgs e)
        {
            List<LeadDetail> leadsRating = new List<LeadDetail>();
            IEnumerable<LeadDetail> ratingsort = eventLeadsGlobal.OrderByDescending(rat => rat.leadRating);
            foreach (LeadDetail rating in ratingsort)
            {
                if (string.IsNullOrEmpty(rating.leadRating) == false)
                    leadsRating.Add(rating);
            }

            LoadListView(leadsRating,"Rating");
        }


        private void lstView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstView.SelectedIndex == -1)
                return;

             ListViewLeadItem selectedItem = (ListViewLeadItem)lstView.SelectedValue;
             if (selectedItem != null)
             {
                 NavigationService.Navigate(new Uri("/blLeadDetails.xaml?selecteduser=" + selectedItem.Barcodeid, UriKind.Relative));
             }

            lstView.SelectedIndex = -1;
        }

       
       


    }
}