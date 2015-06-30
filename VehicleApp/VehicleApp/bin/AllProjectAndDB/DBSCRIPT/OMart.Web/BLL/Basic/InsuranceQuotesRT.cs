using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL.Basic
{
    public class InsuranceQuotesRT : IDisposable
    {
        public class InsuranceQuotesSearchReasultDisplay
        {
            public string ProviderLogoUrl { get; set; }
            public string PremiumAmount { get; set; }
            public string CoverAmount { get; set; }
            public string CriticalIllnessHtmlString { get; set; }
            public string IsGuaranteedPremiumHtmlString { get; set; }
            public string PolicyTerm { get; set; }
            public string ClaimsPaidPercent { get; set; }
            public string RedirectUrl { get; set; }
        }

        private readonly OiiOMartDBDataContext _oiioMartDbContext;
        public InsuranceQuotesRT()
        {
            _oiioMartDbContext = DatabaseHelper.GetDataModelDataContext();
        }

        public List<InsuranceQuotesSearchReasultDisplay> SearchedResult(decimal criticalIllnessCoverAmount, decimal coverAmount, int noOfYear)
        {
            try
            {
                var searchResultList = _oiioMartDbContext.SP_GetDataForLifeInsuranceQuotesSearchReasultDisplay(criticalIllnessCoverAmount, coverAmount, noOfYear).ToList();
                var aDisplayList=new List<InsuranceQuotesSearchReasultDisplay>();
                foreach (var aResult in searchResultList)
                {
                    var aDisplay=new InsuranceQuotesSearchReasultDisplay();
                    aDisplay.ClaimsPaidPercent = aResult.ClaimsPaidPercent+"%";
                    aDisplay.CoverAmount = aResult.TotalCoverAmount.ToString("0.##");


                    if (criticalIllnessCoverAmount > 0 ||criticalIllnessCoverAmount==-1)//-1 for get all value of critical illness amount
                    {
                        if (aResult.CriticalillnessCoverAmount!=null)
                        {
                            aDisplay.CriticalIllnessHtmlString = "Tk " + Convert.ToDecimal(aResult.CriticalillnessCoverAmount).ToString("0.##");
                        }
                    }
                    else
                    {
                        aDisplay.CriticalIllnessHtmlString = @"<span class='glyphicon glyphicon-remove text-danger'></span>";
                    }

                    aDisplay.IsGuaranteedPremiumHtmlString = aResult.IsGuranteedPremium ? @"<span class='glyphicon glyphicon-ok text-success'></span>" : @"<span class='glyphicon glyphicon-remove text-danger'></span>";
                    aDisplay.PolicyTerm = aResult.PolicyTerm + " years";
                    aDisplay.ProviderLogoUrl = aResult.LogoUrl;
                  
                    switch (aResult.PremiumPolicyID)
                    {
                        case 1:
                            aDisplay.PremiumAmount =@"<h4>Tk "+ aResult.UnitPremiumAmount.ToString("0.##") + @" </h4><p>per month</p>";
                            break;
                        case 2:
                            aDisplay.PremiumAmount = @"<h4>Tk " + aResult.UnitPremiumAmount.ToString("0.##") + @" </h4><p>per three month</p>";
                            break;
                        case 3:
                            aDisplay.PremiumAmount = @"<h4>Tk " + aResult.UnitPremiumAmount.ToString("0.##") + @" </h4><p>per six month</p>";
                            break;
                        case 4:
                            aDisplay.PremiumAmount = @"<h4>Tk " + aResult.UnitPremiumAmount.ToString("0.##") + @" </h4><p>per year</p>";
                            break;
                    }
                    aDisplay.RedirectUrl = aResult.WebAddress;
                    aDisplayList.Add(aDisplay);
                }
                return aDisplayList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message,ex);
            }
            
        }

        #region IDisposable Members
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable Members



        public Applicant GetApplicantByIid(long iid)
        {
            try
            {
                var applicant = _oiioMartDbContext.Applicant.SingleOrDefault(x => x.IID == iid);
                return applicant;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public List<SP_GetAllLiSchemaNoOfYearForListViewResult> GetLiSchemaNoOfYearForDropDown()
        {
            try
            {
                var liSchemaNoOfYearListResult=new List<SP_GetAllLiSchemaNoOfYearForListViewResult>();
                var liSchemaNoOfYearList = _oiioMartDbContext.SP_GetAllLiSchemaNoOfYearForListView().ToList();
                if (liSchemaNoOfYearList.Any())
                {
                    int numberOfYear = 0;
                    foreach (var lsNoOfYear in liSchemaNoOfYearList)
                    {
                        if (lsNoOfYear.Value != numberOfYear)
                        {
                            liSchemaNoOfYearListResult.Add(lsNoOfYear);
                        }
                        numberOfYear= lsNoOfYear.Value;
                    }
                }
                return liSchemaNoOfYearListResult;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
