using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI.WebControls;
namespace OH.Utilities
{
    public static class FacebookHelper
    {
        public static string Get_Like_Button_Iframe_Standard(string URL, string iFrame_Width)
        {
            return "<iframe src='//www.facebook.com/plugins/like.php?href=" + URL + "&amp;send=false&amp;layout=standard&amp;width=" + iFrame_Width + "&amp;show_faces=true&amp;action=like&amp;colorscheme=light&amp;font&amp;height=80' scrolling='no' frameborder='0' style='border:none; overflow:hidden; width:" + iFrame_Width + "px; height:80px;' allowTransparency='true'></iframe>";
        }

        public static string Get_Like_Button_Iframe_Standard(string iFrame_Width)
        {
            return Get_Like_Button_Iframe_Standard(HttpContext.Current.Request.Url.ToString().ToLower(), iFrame_Width);
        }


        public static string Get_Like_Button_Iframe_Count_Button(string URL, string iFrame_Width)
        {
            return "<iframe src='//www.facebook.com/plugins/like.php?href=" + URL + "&amp;send=false&amp;layout=button_count&amp;width=" + iFrame_Width + "&amp;show_faces=true&amp;action=like&amp;colorscheme=light&amp;font&amp;height=21' scrolling='no' frameborder='0' style='border:none; overflow:hidden; width:" + iFrame_Width + "px; height:21px;' allowTransparency='true'></iframe>";
        }

        public static string Get_Like_Button_Iframe_Count_Button(string iFrame_Width)
        {
            return Get_Like_Button_Iframe_Count_Button(HttpContext.Current.Request.Url.ToString().ToLower(), iFrame_Width);
        }
    }
}
