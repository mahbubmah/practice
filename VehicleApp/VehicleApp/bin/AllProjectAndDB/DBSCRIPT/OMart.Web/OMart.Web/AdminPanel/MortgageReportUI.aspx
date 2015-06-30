<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.Master" AutoEventWireup="true" CodeBehind="MortgageReportUI.aspx.cs" Inherits="OMart.Web.AdminPanel.MortgageReportUI" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AdminHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AdminContentPlaceHolder" runat="server">
     <div class="container">
        <CR:CrystalReportViewer ID="crv" runat="server" AutoDataBind="True" Height="50px" Width="350px"  ToolPanelView="None" ToolPanelWidth="200px" HasCrystalLogo="False" HasToggleGroupTreeButton="False" />
    </div>
</asp:Content>
