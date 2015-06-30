using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.IO;
using System.Web;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Specialized;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OH.Utilities
{
  public  class AspxPageReader
    {
      //private void AspxPageRead()
      //{
      //    string result = null;
      //    WebResponse response = null;
      //    StreamReader reader = null;

      //    try
      //    {


      //        string webRootPath = Server.MapPath("~"); //docPath = Path.GetFullPath(Path.Combine(path, "../~"));
      //        DirectoryInfo Dir = new DirectoryInfo(webRootPath);
      //        FileInfo[] FileList = Dir.GetFiles("*.aspx", SearchOption.TopDirectoryOnly);
      //        List<string> urlpath = new List<string>();
      //        foreach (FileInfo FI in FileList)
      //        {
      //            try
      //            {
      //                // Console.WriteLine(FI.FullName);// http://localhost:32681/Default
      //                SearchUrlforRead = "http://" + HttpContext.Current.Request.Url.Authority + "/" + FI.Name.Replace(".aspx", string.Empty);
      //                string path = SearchUrlforRead;
      //                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(path);
      //                request.Method = "GET";
      //                response = request.GetResponse();
      //                reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
      //                result = reader.ReadToEnd();
      //                string plainText = Regex.Replace(result, @"<script\b[^>]*>(.*?)<\/script>", ""); //remove javascript

      //                plainText = Regex.Replace(plainText, "<[^>]+?>", ""); //remove HTML


      //                if (plainText.Contains(txtSearch.Text))
      //                {
      //                    urlpath.Add(path);
      //                    //Request.QueryString[];
      //                }




      //            }
      //            catch (Exception ex)
      //            {


      //            }
      //        }

      //    }
      //    catch (Exception ex)
      //    {
      //        // LogFileWritten(ex.Message, ex.StackTrace);
      //    }

      //    finally
      //    {
      //        if (reader != null)
      //            reader.Close();
      //        if (response != null)
      //            response.Close();
      //    }
      //}

    }
}
