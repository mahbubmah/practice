using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OMart.Web.AdminPanel
{
    public partial class DefaultReportViewer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ReportDocument cryRpt = new ReportDocument();
                DataHelper dHelper = new DataHelper();
                string rportPath = Session["ReportPath"].ToString();
                List<string> pNameList =(List<string>) Session["ParamName"];
                List<string > pValueList=(List<string>) Session["ParamValue"];
                //if(!IsPostBack)
                //{
                    foreach(var pName in pNameList)
                    {
                        foreach( var pValue in pValueList)
                        {                   
                            cryRpt.Load(Server.MapPath("~") + rportPath);
                            cryRpt.SetDatabaseLogon(dHelper.GetUserID(),dHelper.GetPassword(),dHelper.GetServer(),dHelper.GetDataBase()) ;

                            ParameterFieldDefinitions crParameterFieldDefinitions;
                            ParameterFieldDefinition crParameterFieldDefinition;
                            ParameterValues crParameterValues = new ParameterValues();
                            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();

                            crParameterDiscreteValue.Value = pValue;
                            crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields;
                            crParameterFieldDefinition = crParameterFieldDefinitions[pName];
                            crParameterValues = crParameterFieldDefinition.CurrentValues;


                            crParameterValues.Add(crParameterDiscreteValue);
                            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);
                        }
                    }
            
                    crystalRptViewer.ReportSource = cryRpt;
                    crystalRptViewer.EnableDatabaseLogonPrompt = false;
                   // ReleaseReportSession();
                //}

            }
            catch(Exception ex)
            {
                lblMessage.Text = "Please Try Again";

            }

        }

        private void ReleaseReportSession()
        {
            Session["ReportPath"] = null;
            Session["ParamName"] = null;
            Session["ParamValue"] = null;
        }
    }
}