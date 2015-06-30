using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OH.Web
{
    public partial class lifecycletest : System.Web.UI.Page
    {
       
         protected void Page_PreInit(object sender, EventArgs e)   
         {        //  Use this event for the following: 
             //  Check the IsPostBack property to determine whether this is the first time the page is being processed.
             //  Create or re-create dynamic controls.      
             //  Set a master page dynamically.      
             //  Set the Theme property dynamically.        
             Label1.Text = "Page_PreInit";
         }
         protected override void OnPreLoad(EventArgs e)
         {
             // Use this event if you need to perform processing on your page or control before the  Load event.   
             // Before the Page instance raises this event, it loads view state for itself and all controls, and then processes any postback data included with the Request instance.
             Label4.Text = "OnPreLoad";
         }
     
      
      

        protected void Page_InitComplete(object sender, EventArgs e)
        {
            // Raised by the  Page object. Use this event for processing tasks that require all initialization be complete.
            Label3.Text = "Page_InitComplete";
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            // Raised after all controls have been initialized and any skin settings have been applied.
            //Use this event to read or initialize control properties.
            Label2.Text = "Page_Init";
        }
         //protected void Button1_Click(object sender, EventArgs e)

         //{       
            
         //}
         protected override void OnSaveStateComplete(EventArgs e)
         {
             // Before this event occurs,  ViewState has been saved for the page and for all controls. Any changes to the page or controls at this point will be ignored.   
             // Use this event perform tasks that require view state to be saved, but that do not make any changes to controls.
             Label9.Text = "OnSaveStateComplete";
         }
       
        protected override void OnPreRender(EventArgs e)

        {        
            // Each data bound control whose DataSourceID property is set calls its DataBind method.    
            // The PreRender event occurs for each control on the page. Use the event to make final changes to the contents of the page or its controls.
            Label8.Text = "OnPreRender";
        }
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            // Use this event for tasks that require that all other controls on the page be loaded.
            Label7.Text = "Page_LoadComplete";
        }
       
        protected void Page_Load(object sender, EventArgs e)
        {
            Label5.Text = "Page_Load";
       
        }
        protected void Page_UnLoad(object sender, EventArgs e)   

        {    
            // This event occurs for each control and then for the page. In controls, use this event to do final cleanup for specific controls, such as closing control-specific database connections.   
            // During the unload stage, the page and its controls have been rendered, so you cannot make further changes to the response stream.           //If you attempt to call a method such as the Response.Write method, the page will throw an exception.  
            Label10.Text = "Destroy everything";
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            // This is just an example of control event.. Here it is button click event that caused the postback
            Label6.Text = "Button1_Click";
        }
    }
}