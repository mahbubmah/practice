<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/AdminPanel/AdminMaster.Master" CodeBehind="DefaultReportViewer.aspx.cs" Inherits="OMart.Web.AdminPanel.DefaultReportViewer" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AdminHead" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="AdminContentPlaceHolder" runat="server">
    <br />
    <section>
        <div> <asp:Label runat="server" ID="lblMessage"></asp:Label></div>
    <div> 
        <CR:CrystalReportViewer ID="crystalRptViewer" Height="900" Width="700" runat="server" AutoDataBind="true" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" HasCrystalLogo="False" />
    
    </div>
    </section>
</asp:Content>


<%--<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DefaultReportViewer.aspx.cs" Inherits="OMart.Web.AdminPanel.DefaultReportViewer" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxConTK" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />

    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta http-equiv="X-UA-Compatible" content="IE=9,chrome=1" /> 
    <asp:PlaceHolder runat="server">
        <%: Scripts.Render("~/bundles/modernizr") %>
    </asp:PlaceHolder>

    <title>OiiO Mart</title>
</head>
<body>
    <form id="frm" runat="server">
        <asp:ScriptManager runat="server">
            <Scripts>
                <asp:ScriptReference Name="jquery" />
                <asp:ScriptReference Name="WebUIValidation.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebUIValidation.js" />
            </Scripts>
        </asp:ScriptManager>


  
            <br />
            <section>
                <div> <asp:Label runat="server" ID="lblMessage"></asp:Label></div>
            <div> 
                <CR:CrystalReportViewer ID="crystalRptViewer" Height="900" Width="700" runat="server" AutoDataBind="true" EnableDatabaseLogonPrompt="False" />
    
            </div>
            </section>


        <footer>
            <div class="footerWerp">
                <div class="container">

                    <div class="row footerBottom">
                        <div class="col-md-8 copyright">

                            <p>All contents copyright © <span>OiiO Mart</span> 2015. All rights reserved Website Design,Development and SEO by <span>-Oiio International.com</span></p>
                        </div>

                    </div>
                </div>
            </div>
        </footer>


    </form>
</body>
</html>--%>



