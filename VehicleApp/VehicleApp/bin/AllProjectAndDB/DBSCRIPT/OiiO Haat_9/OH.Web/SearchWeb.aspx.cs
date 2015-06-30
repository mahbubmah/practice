using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OH.BLL.Basic;
using OH.DAL;
using OH.Utilities;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Text;



namespace OH.Web
{
    /// <summary>
    /// Author:Asiful Islam
    /// date:09.04.2015
    /// </summary>
    public partial class SearchWeb : System.Web.UI.Page
    {
        private readonly VisitorIPMACAddress _visitorIPMACAddress;
        public int lvRowCount { get; set; }
        public int currentPage { get; set; }
        protected string SearchUrlforRead
        {
            get { return (string)ViewState["SearchUrlforRead"] ?? String.Empty; }
            private set { ViewState["SearchUrlforRead"] = value; }
        }
        public SearchWeb()
        {
           
            this._visitorIPMACAddress = new VisitorIPMACAddress();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                   

                     dataPagerStaticSearch.Visible = false;
                   
                  
                    GettingCurrentUrl();
                    LoadListViewForSearch();
                    //Like_Button_Iframe_Count_Button = FacebookHelper.Get_Like_Button_Iframe_Count_Button("http://www.oiiohaat.com", "80");


                }
                catch (Exception ex)
                {
                  //  throw new Exception(ex.Message, ex);
                    LogFileWritten(ex.Message, ex.StackTrace);
                }
            }
        }

        private void LoadListViewForSearch()
        {
            try
            {
                int dynamicItemCount;
                int staticItemCount;
                if (Session["SearchWeb"] != null)
                {                   
                    
                    string search = Session["SearchWeb"].ToString();
                    using (OtherContentRT receiverTransfer = new OtherContentRT())
                    {
                        lvSearch.DataSource = receiverTransfer.GetSearchResultForListView(search);
                        lvSearch.DataBind();
                        dynamicItemCount=lvSearch.Items.Count;
                    }

                    lvStaticView.DataSource = AspxPageRead(search);
                    lvStaticView.DataBind();
                    staticItemCount = lvStaticView.Items.Count;
                    lblSearchCount.Text = (dynamicItemCount + staticItemCount) + " Search Result From OiiO HaaT";
                }
               
            }
            catch (Exception ex)
            {
                lblSearchWholeweb.Text = "Error : " + ex.Message;
                lblSearchWholeweb.ForeColor = System.Drawing.Color.Red;
               // throw new Exception(ex.Message, ex);
            }
        }

        private void GettingCurrentUrl()
        {
            string currentURL = HttpContext.Current.Request.Url.AbsoluteUri;
            Session["backURL"] = currentURL;
        }

        protected void lvSearch_PreRender(object sender, EventArgs e)
        {

        }

        protected void dataPagerSearch_PreRender(object sender, EventArgs e)
        {
            try
            {
                lvRowCount = currentPage * 7;
                if (IsPostBack)
                {
                    LoadListViewForSearch();
                }
            }
            catch (Exception ex)
            {
                //labelMessage.Text = "Error : " + ex.Message;
                //labelMessage.ForeColor = System.Drawing.Color.Red;
                throw new Exception(ex.Message, ex);
            }
        }

        protected void lvSearch_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            currentPage = (e.StartRowIndex / e.MaximumRows) + 0;
        }
        public class SearchResult
        {
            public string UrlName { get; set; }
            public string FindString { get; set; }
            public string RelatedString { get; set; }
        }
        public List<SearchResult> AspxPageRead(string SearchByKeyWord)
        {          
            
                string result = null;
                WebResponse response = null;
                StreamReader reader = null;

                string webRootPath = Server.MapPath("~"); //docPath = Path.GetFullPath(Path.Combine(path, "../~"));
                DirectoryInfo Dir = new DirectoryInfo(webRootPath);
                FileInfo[] FileList = Dir.GetFiles("*.aspx", SearchOption.TopDirectoryOnly);
                List<SearchResult> searchReasultList = new List<SearchResult>();

                string Sentances = string.Empty;
                List<string> listOfSentance = new List<string>();
                foreach (FileInfo FI in FileList)
                {
                    try
                    {
                        // Console.WriteLine(FI.FullName);// http://localhost:32681/Default
                        SearchUrlforRead = "http://" + HttpContext.Current.Request.Url.Authority + "/" + FI.Name.Replace(".aspx", string.Empty);
                        string path = SearchUrlforRead;
                        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(path);
                        request.Method = "GET";
                        response = request.GetResponse();
                        reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                        result = reader.ReadToEnd();
                        string plainText = Regex.Replace(result, "<script.*?</script>", "", RegexOptions.Singleline | RegexOptions.IgnoreCase); //remove javascript Regex.Replace(result, "`<script.*?>`.*?`</script>`", "", RegexOptions.Singleline);
                       string PLainText = Regex.Replace(plainText, "<[^>]+?>", ""); //remove HTML
                       plainText = Regex.Replace(PLainText, "`<style.*?>`(.| )*?`</style>`", "", RegexOptions.Singleline | RegexOptions.IgnoreCase);   //remove CSS
                       plainText = plainText.Replace("\r", "").Replace("\n", "").Replace("\t", "").Replace("&nbsp", "").Replace(",", "").Replace(";", "").Replace("hrfRegister", "").Replace("loginname", "").Replace("Submit", "").Replace("submit", "");
                       if (plainText.Contains(SearchByKeyWord))
                        {
                            listOfSentance=ListOfSentance(SearchByKeyWord, plainText);
                            for (int i = 0; i < listOfSentance.Count;i++ )
                            {
                                if (i >= 2) { break; }
                                Sentances += listOfSentance[i].ToString() + "......";
                            }
                            SearchResult aSearchResult = new SearchResult();
                            aSearchResult.FindString = Sentances;
                            aSearchResult.UrlName = path;                           
                            searchReasultList.Add(aSearchResult);
                            Sentances = string.Empty;
                        }                        
                    }
                    catch (Exception ex)
                    {
                        LogFileWritten(ex.Message, ex.StackTrace);
                    }
                }
                return searchReasultList;
        }

        protected void lvStaticView_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            currentPage = (e.StartRowIndex / e.MaximumRows) + 0;
        }


        private void LogFileWritten(string mssge, string stackTrace)
        {
            try
            {
                string path = Server.MapPath("~/Resources/WebsiteSearchlogFileWriting.txt");
                if (!File.Exists(path))
                {
                    File.Create(path).Dispose();
                    using (TextWriter tw = new StreamWriter(path))
                    {
                        var text = DateTime.Now.ToString() + "   " + _visitorIPMACAddress.GetVisitorIPAddress() + "   " + mssge + "   " + stackTrace;
                        tw.WriteLine(text);

                        tw.Flush();
                        tw.Close();
                    }
                }
                else if (File.Exists(path))
                {
                    using (var tw = File.AppendText(path))
                    {
                        var text = DateTime.Now.ToString() + "   " + _visitorIPMACAddress.GetVisitorIPAddress() + "   " + mssge + "   " + stackTrace;
                        tw.WriteLine(text);
                        tw.Flush();
                        tw.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                mssge = ex.Message.ToString();
                stackTrace = ex.StackTrace.ToString();
            }
        }

       public List<string> ListOfSentance(string searchKeyWord,string plainText)
        {
            List<string> listOfSentance = new List<string>();
            Regex UselessPunctionRegex = new Regex(@"'(?!(s|t|re|m)( |$))|\.$|\. |\.{2,}|©|`|~|!|@|#|\$|%|\^|\*|\(|\)|(^|[^\w])-+|-+($|[^\w])|_|=|\+|\[|\]|\{|\}|<|>|\\|\||/|;|:|""|•|–|,|\?|×|！|·|…|—|（|）|、|：|；|‘|’|“|”|《|》|，|。|？");
                //(@"'(?!(s|t|re|m)( |$))|\.$|\. |\.{2,}|©|`|~|!|@|#|\$|%|\^|\*|\(|\)|(^|[^\w])-+|-+($|[^\w])|_|=|\+|\[|\]|\{|\}|<|>|\\|\||/|;|:|""|•|–|,|\?|×|！|·|…|—|（|）|、|：|；|‘|’|“|”|《|》|，|。|？");
            MatchCollection mc = UselessPunctionRegex.Matches(plainText);
            int start = 0;
            foreach (Match m in mc)
            {
                string tempSentance = plainText.Substring(start, m.Index - start) + m.Value;// +"<br/>";
                if (tempSentance.Contains(searchKeyWord))
                {
                    listOfSentance.Add(tempSentance);
                    
                }
                start = m.Index + 1;
            }

            return listOfSentance;
        }

       protected void dataPagerStaticSearch_PreRender(object sender, EventArgs e)
       {
           try
           {
               lvRowCount = currentPage * 3;
               if (IsPostBack)
               {
                   string search = Session["SearchWeb"].ToString();
                   lvStaticView.DataSource = AspxPageRead(search);
                   lvStaticView.DataBind();
               }
           }
           catch (Exception ex)
           {
               //labelMessage.Text = "Error : " + ex.Message;
               //labelMessage.ForeColor = System.Drawing.Color.Red;
               throw new Exception(ex.Message, ex);
           }
       }
            
    }
}