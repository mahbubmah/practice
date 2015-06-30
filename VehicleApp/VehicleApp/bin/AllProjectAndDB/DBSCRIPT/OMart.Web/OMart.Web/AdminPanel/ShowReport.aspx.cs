using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Utilities;

namespace OMart.Web.AdminPanel
{
    public partial class ShowReport : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session[CrHelper.SessReportFormStr] != null)
                {
                    ReportDocument rDoc = (ReportDocument)Session[CrHelper.SessReportFormStr];
                    CrHelper.SetLoginInfo(rDoc);
                   
                    if (Session[CrHelper.SessParamListStr] != null)
                    {
                        List<CrParameter> crPramList = (List<CrParameter>)Session[CrHelper.SessParamListStr];
                        foreach (var crParameter in crPramList)
                        {
                            SetParameter(rDoc, crParameter);
                        }
                        Session[CrHelper.SessParamStr] = null;
                    }
                    else if (Session[CrHelper.SessParamStr] != null)
                    {
                        CrParameter crParameter = (CrParameter)Session[CrHelper.SessParamStr];
                        SetParameter(rDoc, crParameter);
                    }

                    crViewerForAll.ReportSource = rDoc;
                }//end if
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
        }

        private void SetParameter(ReportDocument rDoc, CrParameter crParameter)
        {
            try
            {
                ParameterFieldDefinitions crParameterFieldDefinitions;
                ParameterFieldDefinition crParameterFieldDefinition;
                ParameterValues crParameterValues = new ParameterValues();
                ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();

                crParameterDiscreteValue.Value = crParameter.Value;
                crParameterFieldDefinitions = rDoc.DataDefinition.ParameterFields;
                crParameterFieldDefinition = crParameterFieldDefinitions[crParameter.Name];
                crParameterValues = crParameterFieldDefinition.CurrentValues;


                crParameterValues.Add(crParameterDiscreteValue);
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
        }
    }
}