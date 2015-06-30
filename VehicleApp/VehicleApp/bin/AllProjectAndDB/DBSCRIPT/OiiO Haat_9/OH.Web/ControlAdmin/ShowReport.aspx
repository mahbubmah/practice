<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowReport.aspx.cs" Inherits="OH.Web.ControlAdmin.ShowReport" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Content/jquery-ui.css" rel="stylesheet" />
    <script src="../Scripts/jquery-1.10.2.js"></script>
    <script src="../Scripts/jquery-ui.js"></script>
</head>
<body>
    <form id="form1" runat="server">
         <asp:ScriptManager ID="sManager" runat="server">
        </asp:ScriptManager>
    <div>
    
        <CR:CrystalReportViewer ID="crystalReportViewerForAll" runat="server" AutoDataBind="true"   Height="100%"
        Width = "100%"/>
    
    </div>
    </form>
</body>
</html>
