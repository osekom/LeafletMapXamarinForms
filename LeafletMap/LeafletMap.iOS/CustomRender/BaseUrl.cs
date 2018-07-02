using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using LeafletMap.CustomRender;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(LeafletMap.iOS.CustomRender.BaseUrl))]
namespace LeafletMap.iOS.CustomRender
{
    public class BaseUrl : IBaseUrl
    {
        public string Get() { return NSBundle.MainBundle.BundlePath; }
    }
}