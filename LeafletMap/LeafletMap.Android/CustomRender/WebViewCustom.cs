using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Webkit;
using Android.Widget;
using LeafletMap.CustomRender;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(IWebViewCustom), typeof(LeafletMap.Droid.CustomRender.WebViewCustom))]
namespace LeafletMap.Droid.CustomRender
{
#pragma warning disable CS0618 // El tipo o el miembro están obsoletos
    public class WebViewCustom : WebViewRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.WebView> e)
        {
            base.OnElementChanged(e);
            Control.Settings.JavaScriptEnabled = true;
            Control.Settings.UseWideViewPort = true;
            Control.Settings.LoadWithOverviewMode = true;
            Control.Settings.SaveFormData = true;
            Control.Settings.SetRenderPriority(WebSettings.RenderPriority.High);
            Control.SetLayerType(LayerType.Hardware, null);
            //Control.SetLayerType(LayerType.Software, null);
            Control.SetWebChromeClient(new MyWebClient());
        }

        public class MyWebClient : WebChromeClient
        {

        }
    }
}