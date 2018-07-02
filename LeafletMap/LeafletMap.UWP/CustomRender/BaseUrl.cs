using LeafletMap.CustomRender;
using LeafletMap.UWP.CustomRender;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(BaseUrl))]
namespace LeafletMap.UWP.CustomRender
{
    public class BaseUrl : IBaseUrl
    {
        public string Get()
        {
            return "ms-appx-web:///";
        }
    }
}
