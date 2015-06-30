<%@ Page Title="" Language="C#" MasterPageFile="~/ControlAdmin/ControlAdminMaster.Master" AutoEventWireup="true" CodeBehind="VisitorsInfoWF.aspx.cs" Inherits="OH.Web.ControlAdmin.VisitorsInfoWF" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headAdmin" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentAdminMain" runat="server">
     <div class="container adminPagewrp">
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
