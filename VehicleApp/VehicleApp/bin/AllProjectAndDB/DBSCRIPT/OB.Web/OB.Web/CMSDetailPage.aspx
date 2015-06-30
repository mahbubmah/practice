<%@ Page Title="" Language="C#" MasterPageFile="~/OiiOBookDetailsInnerMasterPage.Master" AutoEventWireup="true" CodeBehind="CMSDetailPage.aspx.cs" Inherits="OB.Web.CMSDetailPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderInnerPage" runat="server">

 <div class="container">
        
        <div>
            <div class="col-lg-1"></div>
            <div class="">
                <fieldset style="width: 95%; margin-left: 0%; visibility: hidden">
                    <%-- <legend></legend>--%>
                    <div class="row" style="visibility: visible">
                        <div class="form-group col-xs-12">
                            <div class="input-group col-xs-6">
                                <h1 style="color: blue; font-weight: bold; font-family: 'Times New Roman'">
                                    <asp:Literal ID="ltrlTitle" runat="server" ></asp:Literal>
                                </h1>
                                <div style="text-align:justify">
                                    <asp:Image ID="imgCMS" runat="server"  CssClass="pull-right " Width="150" Height="100" />
                                <asp:Literal ID="ltrlDesceiption" runat="server" ></asp:Literal>
                            </div>
                                </div>
                        </div>
                    </div>
                </fieldset>
            </div>
        </div>
    </div>

</asp:Content>
