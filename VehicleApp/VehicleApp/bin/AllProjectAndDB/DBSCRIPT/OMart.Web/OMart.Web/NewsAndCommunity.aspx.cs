using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Basic;
using BLL;
using DAL;

namespace OMart.Web
{
    public partial class NewsAndCommunity : System.Web.UI.Page
    {
        private const string sessNewsLetterSubscribe = "seEmailSubscribe";
        private Int64 IID = default(Int64);
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    GettingCurrentUrl();

                    LoadAllNews();
                    LoadAllVideos();
                    LoadAllSports();
                    LoadAllEducation();
                    LoadAllRecreation();
                    LoadAllGuide();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        
        private void GettingCurrentUrl()
        {
            string currentURL = HttpContext.Current.Request.Url.AbsoluteUri;
            Session["backURL"] = currentURL;
        }

        #region News Repeater
        private void LoadAllNews()
        {
            try
            {
                CommunityNewsRT _CommunityNewsRT = new CommunityNewsRT();
                var objNews = _CommunityNewsRT.GetAllCommunityNews().Take(3).ToList();
                if (objNews.Count > 0)
                {
                    rpNews.DataSource = objNews;
                    rpNews.DataBind();

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        protected void rpNews_OnItemDataBound(object source, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    Literal objltrHeadline = (Literal)e.Item.FindControl("lblHeadline");
                    if (objltrHeadline.Text.Length > 50)
                    {
                        var text = objltrHeadline.Text.Substring(0, 50);
                        objltrHeadline.Text = text + "...";
                    }
                    else
                    {
                        objltrHeadline.Text = objltrHeadline.Text.Trim() + ".";
                    }
                 
                    Literal objltrNewsDescription = (Literal)e.Item.FindControl("lblNewsDescription");
                    if (objltrNewsDescription.Text.Length > 125)
                    {
                        var text = objltrNewsDescription.Text.Substring(0, 125);
                        objltrNewsDescription.Text = text + "...";
                    }
                    else
                    {
                        objltrNewsDescription.Text = objltrNewsDescription.Text.Trim()+".";
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        #endregion News Repeater

        #region Video Repeater
        private void LoadAllVideos()
        {
            try
            {
                CommunityNewsRT _CommunityNewsRT = new CommunityNewsRT();
                var objNews = _CommunityNewsRT.GetAllCommunityVideos().Take(3).ToList();
                if (objNews.Count > 0)
                {
                    rpVideo.DataSource = objNews;
                    rpVideo.DataBind();

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        protected void rpVideo_OnItemDataBound(object source, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    Literal objltrHeadline = (Literal)e.Item.FindControl("lblHeadline");
                    if (objltrHeadline.Text.Length > 50)
                    {
                        var text = objltrHeadline.Text.Substring(0, 50);
                        objltrHeadline.Text = text + "...";
                    }
                    else
                    {
                        objltrHeadline.Text = objltrHeadline.Text.Trim() + ".";
                    }

                    Literal objltrNewsDescription = (Literal)e.Item.FindControl("lblNewsDescription");
                    if (objltrNewsDescription.Text.Length > 100)
                    {
                        var text = objltrNewsDescription.Text.Substring(0, 100);
                        objltrNewsDescription.Text = text + "...";
                    }
                    else
                    {
                        objltrNewsDescription.Text = objltrNewsDescription.Text.Trim() + ".";
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        #endregion Video Repeater

       
        #region Sports Repeater
        private void LoadAllSports()
        {
            try
            {
                CommunityNewsRT _CommunityNewsRT = new CommunityNewsRT();
                var objNews = _CommunityNewsRT.GetAllCommunitySportsNews().Take(3).ToList();
                if (objNews.Count > 0)
                {
                    rpSports.DataSource = objNews;
                    rpSports.DataBind();

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        protected void rpSports_OnItemDataBound(object source, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    Literal objltrHeadline = (Literal)e.Item.FindControl("lblHeadline");
                    if (objltrHeadline.Text.Length > 60)
                    {
                        var text = objltrHeadline.Text.Substring(0, 60);
                        objltrHeadline.Text = text + "...";
                    }
                    else
                    {
                        objltrHeadline.Text = objltrHeadline.Text.Trim() + ".";
                    }

                    Literal objltrNewsDescription = (Literal)e.Item.FindControl("lblNewsDescription");
                    if (objltrNewsDescription.Text.Length > 50)
                    {
                        var text = objltrNewsDescription.Text.Substring(0, 50);
                        objltrNewsDescription.Text = text + "...";
                    }
                    else
                    {
                        objltrNewsDescription.Text = objltrNewsDescription.Text.Trim() + ".";
                    }
               }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        #endregion Sports Repeater

        #region Education Repeater
        private void LoadAllEducation()
        {
            try
            {
                CommunityNewsRT _CommunityNewsRT = new CommunityNewsRT();
                var objNews = _CommunityNewsRT.GetAllCommunityEducations().Take(3).ToList();
                if (objNews.Count > 0)
                {
                    rpEducation.DataSource = objNews;
                    rpEducation.DataBind();

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        protected void rpEducation_OnItemDataBound(object source, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    Literal objltrHeadline = (Literal)e.Item.FindControl("lblHeadline");
                    if (objltrHeadline.Text.Length > 50)
                    {
                        var text = objltrHeadline.Text.Substring(0, 50);
                        objltrHeadline.Text = text + "...";
                    }
                    else
                    {
                        objltrHeadline.Text = objltrHeadline.Text.Trim() + ".";
                    }

                    Literal objltrNewsDescription = (Literal)e.Item.FindControl("lblNewsDescription");
                    if (objltrNewsDescription.Text.Length > 115)
                    {
                        var text = objltrNewsDescription.Text.Substring(0, 115);
                        objltrNewsDescription.Text = text + "...";
                    }
                    else
                    {
                        objltrNewsDescription.Text = objltrNewsDescription.Text.Trim() + ".";
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        #endregion Education Repeater

        #region Recreation Repeater
        private void LoadAllRecreation()
        {
            try
            {
                CommunityNewsRT _CommunityNewsRT = new CommunityNewsRT();
                var objNews = _CommunityNewsRT.GetAllCommunityRecreation().Take(3).ToList();
                if (objNews.Count > 0)
                {
                    rpRecreation.DataSource = objNews;
                    rpRecreation.DataBind();

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        protected void rpRecreation_OnItemDataBound(object source, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    Literal objltrHeadline = (Literal)e.Item.FindControl("lblHeadline");
                    if (objltrHeadline.Text.Length > 50)
                    {
                        var text = objltrHeadline.Text.Substring(0, 50);
                        objltrHeadline.Text = text + "...";
                    }
                    else
                    {
                        objltrHeadline.Text = objltrHeadline.Text.Trim() + ".";
                    }

                    Literal objltrNewsDescription = (Literal)e.Item.FindControl("lblNewsDescription");
                    if (objltrNewsDescription.Text.Length > 190)
                    {
                        var text = objltrNewsDescription.Text.Substring(0, 190);
                        objltrNewsDescription.Text = text + "...";
                    }
                    else
                    {
                        objltrNewsDescription.Text = objltrNewsDescription.Text.Trim() + ".";
                    }
                    //Image objiimg_inner = (Image)e.Item.FindControl("img_inner");
                    //objiimg_inner.ImageUrl = objiimg_inner.ImageUrl;

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        #endregion Recreation Repeater

        #region MostPopular Repeater
        private void LoadAllGuide()
        {
            try
            {
                CommunityNewsRT _CommunityNewsRT = new CommunityNewsRT();
                var objNews = _CommunityNewsRT.GetAllCommunityMostPopularGuide().Take(3).ToList();
                if (objNews.Count > 0)
                {
                    rpMostPopular.DataSource = objNews;
                    rpMostPopular.DataBind();

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        protected void rpMostPopular_OnItemDataBound(object source, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    Literal objltrHeadline = (Literal)e.Item.FindControl("lblHeadline");
                    if (objltrHeadline.Text.Length > 50)
                    {
                        var text = objltrHeadline.Text.Substring(0, 50);
                        objltrHeadline.Text = text + "...";
                    }
                    else
                    {
                        objltrHeadline.Text = objltrHeadline.Text.Trim() + ".";
                    }

                    Literal objltrNewsDescription = (Literal)e.Item.FindControl("lblNewsDescription");
                    if (objltrNewsDescription.Text.Length > 158)
                    {
                        var text = objltrNewsDescription.Text.Substring(0, 158);
                        objltrNewsDescription.Text = text + "...";
                    }
                    else
                    {
                        objltrNewsDescription.Text = objltrNewsDescription.Text.Trim() + ".";
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        #endregion MostPopular Repeater

        //#region NewsType Repeater
        //private void LoadAllNewsType()
        //{
        //    try
        //    {
        //        CommunityNewsRT _CommunityNewsRT = new CommunityNewsRT();
        //        var objNews = _CommunityNewsRT.GetAllCommunityNewsType().Take(3).ToList();
        //        if (objNews.Count > 0)
        //        {
        //            rpNewsType.DataSource = objNews;
        //            rpNewsType.DataBind();

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message, ex);
        //    }
        //}

        //protected void rpNewsType_OnItemDataBound(object source, RepeaterItemEventArgs e)
        //{
        //    try
        //    {
        //        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        //        {
        //            Literal objltrHeadline = (Literal)e.Item.FindControl("ltrHeadline");
        //            objltrHeadline.Text = objltrHeadline.Text.Trim();

        //            Literal objltrNewsDescription = (Literal)e.Item.FindControl("lblNewsDescription");
        //            if (objltrNewsDescription.Text.Length > 150)
        //            {
        //                var text = objltrNewsDescription.Text.Substring(0, 150);
        //                objltrNewsDescription.Text = text + "...";
        //            }
        //            else
        //            {
        //                objltrNewsDescription.Text = objltrNewsDescription.Text.Trim() + ".";
        //            }

        //            Literal objlblNewsType = (Literal)e.Item.FindControl("lblNewsType");
        //            objlblNewsType.Text = objlblNewsType.Text.Trim();            

        //            Image objiimg_inner = (Image)e.Item.FindControl("img_inner");
        //            objiimg_inner.ImageUrl = objiimg_inner.ImageUrl;

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message, ex);
        //    }
        //}

        //#endregion NewsType Repeater

        private NewsLetterSubscribe CreateNewsLetter()
        {
            Session["UserID"] = "1";
            NewsLetterSubscribe newsLetter = new NewsLetterSubscribe();
            try
            {
                if (hdIsEdit.Value == "true")
                {
                    //uniteLetter.IID = Convert.ToInt32(hdEmailID.Value.ToString());
                    NewsLetterRT receiverTransfer = new NewsLetterRT();
                    NewsLetterSubscribe emailSubscription = receiverTransfer.GetEmailSubscribrIDByEmail(txtEmailAdd.Text);
                    Session[sessNewsLetterSubscribe] = emailSubscription;
                    // OiiONewsLetter EmailSubscribe = (OiiONewsLetter)Session[sessEmailSubscribe];
                    newsLetter.IID = emailSubscription.IID;
                }
                newsLetter.UserEmail = txtEmailAdd.Text.Trim();
                newsLetter.SubscribeDate = DateTime.Now;

                if (newsLetter.IID <= 0)
                {
                    newsLetter.CreatedBy = Convert.ToInt64(Session["UserID"]);
                    newsLetter.CreatedDate = GlobalRT.GetServerDateTime();
                }
                else
                {
                    //OiiOOther Oiioother = (OiiOOther)Session[sessOtherContent];
                    NewsLetterSubscribe letter = (NewsLetterSubscribe)Session[sessNewsLetterSubscribe];
                    newsLetter.CreatedBy = letter.CreatedBy; ;
                    newsLetter.CreatedDate = letter.CreatedDate;
                    newsLetter.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                    newsLetter.ModifiedDate = GlobalRT.GetServerDateTime();
                }
                if (hdIsEdit.Value != "true")
                {
                    newsLetter.IsSubscribe = true;
                }
                else
                {
                    newsLetter.IsSubscribe = false;
                }
            }
            catch (Exception ex)
            {
                lblEmailSubscribe.Text = "Error : " + ex.Message;
                lblEmailSubscribe.ForeColor = System.Drawing.Color.Red;
            }
            return newsLetter;

        }

        protected void btn_subscribe_Click(object sender, EventArgs e)
        {
            try
            {
                lblEmailSubscribe.Text = string.Empty;

                using (NewsLetterRT receiverTransfer = new NewsLetterRT())
                {
                    List<NewsLetterSubscribe> uniteList = new List<NewsLetterSubscribe>();
                    uniteList = receiverTransfer.GetLetterListByEmail(txtEmailAdd.Text);
                    if (uniteList != null && uniteList.Count > 0)
                    {
                        string msg = "Email::" + txtEmailAdd.Text + " Already Exists!";
                        lblEmailSubscribe.Text = msg;
                        lblEmailSubscribe.ForeColor = System.Drawing.Color.Red;
                        return;
                    }

                    //hdSave.Value = "true";
                    NewsLetterSubscribe letter = CreateNewsLetter();
                    receiverTransfer.AddNewsLetterSubscribe(letter);
                    if (letter.IID > 0)
                    {
                        lblEmailSubscribe.Text = "User successfully subscribed...";
                        lblEmailSubscribe.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        lblEmailSubscribe.Text = "User successfully not subscribed...";
                        lblEmailSubscribe.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
            catch (Exception ex)
            {
                lblEmailSubscribe.Text = "Error : " + ex.Message;
                lblEmailSubscribe.ForeColor = System.Drawing.Color.White;
            }

        }

    }
}