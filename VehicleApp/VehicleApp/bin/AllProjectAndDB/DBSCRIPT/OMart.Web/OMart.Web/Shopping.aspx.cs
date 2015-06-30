using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using BLL.Basic;


namespace OMart.Web
{
    public partial class Shopping : System.Web.UI.Page
    {
        private readonly AllNewsRT _allNewsRT;
        public Shopping()
        {
            _allNewsRT = new AllNewsRT();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadAllShoppingNews();
            }
        }

        private void loadAllShoppingNews()
        {
            try
            {
                rptshoppingNews.DataSource = _allNewsRT.GetAllShoppingNews();
                rptshoppingNews.DataBind();

            }
            catch (Exception ex)
            {
                
            }
        }
    }
}