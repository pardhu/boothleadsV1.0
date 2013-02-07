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
    public class SFEventSchedule
    {
        public string StartTime { get; set; }
        public string StartDate { get; set; }
        public string ProgramName { get; set; }
        public string Presenter { get; set; }
        public string Message { get; set; }
        public string Location { get; set; }
        public string EndTime { get; set; }
        public string EndDate { get; set; }
        public string Description { get; set; }

    }
}
