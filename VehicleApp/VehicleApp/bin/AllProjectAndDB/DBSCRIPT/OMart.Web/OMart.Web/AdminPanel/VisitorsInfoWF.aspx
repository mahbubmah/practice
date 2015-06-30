<%@ Page Title="Visitor Information" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.Master" AutoEventWireup="true" CodeBehind="VisitorsInfoWF.aspx.cs" Inherits="OMart.Web.AdminPanel.VisitorsInfoWF" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AdminHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AdminContentPlaceHolder" runat="server">

    <div class="container">
    <div class="row">
        <h3>
            Visitor Information
        </h3>
    </div>
        <div>
        <asp:Label ID="labelMessageIPType" runat="server" Text="..."></asp:Label>
             <asp:Label ID="labelMessageVisitorInfo" runat="server" Text=""></asp:Label>
            <asp:Label ID="labelMessageIP" runat="server" Text=""></asp:Label>
            <asp:Label ID="labelMessageDateTime" runat="server" Text=""></asp:Label>
    </div>

         </div>
</asp:Content>
