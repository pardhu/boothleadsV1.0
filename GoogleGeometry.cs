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

namespace BoothLeads
{

    public class GeoResponse
    {
        public string status { get; set; }
        public CResult[] results { get; set; }

        public class CResult
        {
            public CGeometry geometry { get; set; }

            public class CGeometry
            {
                public CLocation location { get; set; }

                public class CLocation
                {
                    public double lat { get; set; }
                    public double lng { get; set; }
                }
            }
        }

        public GeoResponse()
        { }
    }
}
