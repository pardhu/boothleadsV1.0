﻿#pragma checksum "C:\Users\user\Documents\GitHub\boothleadsW\EventDetails.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "584E39485E8BCDC37415C2F97BCFA227"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.225
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using Microsoft.Phone.Controls.Maps;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace BoothLeads {
    
    
    public partial class EventDetails : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.StackPanel TitlePanel;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal Microsoft.Phone.Controls.Maps.Map bngMapname;
        
        internal System.Windows.Controls.Image eventImage;
        
        internal System.Windows.Controls.TextBlock txtBleventName;
        
        internal System.Windows.Controls.TextBlock txtBlkDescription;
        
        internal System.Windows.Controls.TextBlock txtblkDescription;
        
        internal System.Windows.Controls.TextBlock txtBlockEventTime;
        
        internal System.Windows.Controls.Button btnExhibitors;
        
        internal System.Windows.Controls.Button btnSchedule;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/BoothLeads;component/EventDetails.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.TitlePanel = ((System.Windows.Controls.StackPanel)(this.FindName("TitlePanel")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.bngMapname = ((Microsoft.Phone.Controls.Maps.Map)(this.FindName("bngMapname")));
            this.eventImage = ((System.Windows.Controls.Image)(this.FindName("eventImage")));
            this.txtBleventName = ((System.Windows.Controls.TextBlock)(this.FindName("txtBleventName")));
            this.txtBlkDescription = ((System.Windows.Controls.TextBlock)(this.FindName("txtBlkDescription")));
            this.txtblkDescription = ((System.Windows.Controls.TextBlock)(this.FindName("txtblkDescription")));
            this.txtBlockEventTime = ((System.Windows.Controls.TextBlock)(this.FindName("txtBlockEventTime")));
            this.btnExhibitors = ((System.Windows.Controls.Button)(this.FindName("btnExhibitors")));
            this.btnSchedule = ((System.Windows.Controls.Button)(this.FindName("btnSchedule")));
        }
    }
}

