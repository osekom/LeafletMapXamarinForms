using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using LeafletMap.CustomRender;
using Xamarin.Forms;

[assembly: Dependency(typeof(LeafletMap.Droid.CustomRender.BaseUrl))]
namespace LeafletMap.Droid.CustomRender
{
    public class BaseUrl : IBaseUrl
    {
        public string Get() { return "file:///android_asset/"; }
    }
}