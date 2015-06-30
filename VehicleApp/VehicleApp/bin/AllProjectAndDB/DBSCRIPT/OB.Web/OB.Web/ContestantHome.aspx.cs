using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OB.BLL.Basic;
using Utilities;

namespace OB.Web
{
    public partial class ContestantHome : System.Web.UI.Page
    {
        private readonly CompetitionInfoRT _competitionInfoRt;
        private readonly string _visitorLogPath;
        private string _pageLogPath;
        public ContestantHome()
        {
            this._visitorLogPath = Server.MapPath("~/Log file/VisitorlogFileWriting.txt");
            _competitionInfoRt=new CompetitionInfoRT();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string pageName = Path.GetFileName(Request.PhysicalPath);
                _pageLogPath = Server.MapPath("~/Log file/" + pageName + ".txt");
                if (!IsPostBack)
                {
                    LogFileHelper.VisitorLogFileWritten(_visitorLogPath);

                    LoadContestantCompetitions();
                   
                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        private void LoadContestantCompetitions()
        {
            try
            {
                if (Session["ContestantID"]!=null)
                {
                    var competitionList = _competitionInfoRt.GetAllUpComingCompetitionListByContestantId(Convert.ToInt64(Session["ContestantID"]));
                    if (competitionList.Count>0)
                    {
                        lvContestantCompetitionDetails.DataSource = competitionList;
                        lvContestantCompetitionDetails.DataBind();
                        LoadPageCounter();
                    }
                    else
                    {
                        lblResultPageCounter.Text = "You have no upcoming competition";
                    }
                }
                else
                {
                    Response.Redirect("LoginPage",false);
                    Context.ApplicationInstance.CompleteRequest();
                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        protected void lvContestantCompetitionDetails_OnItemDataBound(object sender, ListViewItemEventArgs e)
        {
                
        }

        protected void lvCompetitionDetails_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            try
            {
                LoadPageCounter();
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }
        private void LoadPageCounter()
        {
            try
            {
                int starIndex = dataPagerCompetitionInfo.StartRowIndex;
                int endIndex = starIndex + dataPagerCompetitionInfo.MaximumRows;
                int totalRow  = _competitionInfoRt.GetAllUpComingCompetitionListByContestantId(Convert.ToInt64(Session["ContestantID"])).Count;
                if (totalRow < endIndex)
                {
                    endIndex = totalRow;
                }

                lblResultPageCounter.Text = string.Format("Showing {0} - {1} of {2}", starIndex + 1, endIndex, totalRow);
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }

        }
    }
}