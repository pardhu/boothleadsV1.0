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

namespace BoothLeads
{
    public abstract class GoogleMapsTileSourceBase : Microsoft.Phone.Controls.Maps.TileSource
    {
        public GoogleMapsTileSourceBase(string uriFormat)
            : base(uriFormat)
        {
        }

        public override System.Uri GetUri(int x, int y, int zoomLevel)
        {
            return new Uri(string.Format(this.UriFormat, new Random().Next() % 4, x, y, zoomLevel));
        }
    }

    public class GoogleMapsRoadTileSource : GoogleMapsTileSourceBase
    {
        public GoogleMapsRoadTileSource()
            : base("http://mt{0}.google.com/vt/lyrs=m@128&hl=en&x={1}&y={2}&z={3}&s=Galileo")
        {
        }
    }
}
