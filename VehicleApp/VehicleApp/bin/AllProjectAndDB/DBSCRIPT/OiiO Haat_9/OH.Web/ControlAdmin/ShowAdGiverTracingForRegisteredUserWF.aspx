<%@ Page Title="" Language="C#" MasterPageFile="~/ControlAdmin/ControlAdminMaster.Master" AutoEventWireup="true" CodeBehind="ShowAdGiverTracingForRegisteredUserWF.aspx.cs" Inherits="OH.Web.ControlAdmin.ShowAdGiverTracingForRegisteredUserWF" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headAdmin" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentAdminMain" runat="server">
    <div class="container adminPagewrp">
        <div class="row">
            <h2>Show Registered User's Add Giver Tracing</h2>
        </div>
        <div>
            <asp:Label ID="labelMessageRegisteredUserAddGiverTracing" runat="server" Text="..."></asp:Label>
        </div>
         <div>
            <h3><asp:Label ID="labelDisplayName" runat="server" Text="" ForeColor="Blue"></asp:Label></h3>
        </div>
         <div>
            <asp:Label ID="labelDisplayEmail" runat="server" Text="" ForeColor="Blue"></asp:Label>
        </div>
        

        <div>
             <fieldset>
                 <legend> <asp:Label ID="labellistview" runat="server" Text=""></asp:Label></legend>
                <asp:ListView ID="lvRegisteredUserAddGiverTracing" runat="server" DataKeyNames="IID" >
                     <LayoutTemplate>
                    <table class="table table-bordered table-hover">
                        <thead>
                        <tr runat="server">
                            <th class="col-xs-1" style="text-align: center">SL #
                            </th>
                          
                            <th class="col-xs-1" style="text-align: center">Material Code
                            </th>
                             <th class="col-xs-1" style="text-align: left">IP Address
                            </th>
                            <th class="col-xs-1" style="text-align: left">MAC Address
                            </th>
                             <th class="col-xs-1" style="text-align: left">Browser Name
                            </th>
                            <th class="col-xs-1" style="text-align: right">Browsing Time Duration
                            </th>
                        </tr>
                            </thead>
                        <tbody id="itemPlaceholder" runat="server">
                        </tbody>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr  runat="server">
                        <td style="text-align: center">
                            <%# Container.DataItemIndex + 1%>
                        </td>
                      <%--  <td style="text-align: right">
                            <asp:Label ID="lblRegisteredUserAddGiverTracingID" runat="server" Text='<%# Bind("IID") %>' Visible="false"></asp:Label>
                           
                        </td>--%>
                       <td style="text-align: center">
                            <asp:Label ID="Label5" runat="server" Text='<%#Bind("MaterialCode")%>'></asp:Label>
                        </td>
                          <td style="text-align: left">
                            <asp:Label ID="Label1" runat="server" Text='<%#Bind("IPAddress")%>'></asp:Label>
                        </td>
                         <td style="text-align: left">
                            <asp:Label ID="Label2" runat="server" Text='<%#Bind("MACAddress")%>'></asp:Label>
                        </td>
                         <td style="text-align: left">
                            <asp:Label ID="Label3" runat="server" Text='<%# Enum.Parse(typeof(OH.Utilities.EnumCollection.Browsers), Eval("BrowserNameID").ToString())%>'></asp:Label>
                        </td>
                         <td style="text-align: right">
                            <asp:Label ID="Label4" runat="server" Text='<%#Bind("BrowsingTimeDuration")%>'></asp:Label>
                        </td>
                    </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>

                    <tr class="bg-info" runat="server">
                        <td style="text-align: center">
                            <%# Container.DataItemIndex + 1%>
                        </td>
                       <%-- <td style="text-align: right">
                            <asp:Label ID="lblRegisteredUserAddGiverTracingID" runat="server" Text='<%# Bind("IID") %>' Visible="false"></asp:Label>
                           
                        </td>--%>
                         <td style="text-align: center">
                            <asp:Label ID="Label6" runat="server" Text='<%#Bind("MaterialCode")%>'></asp:Label>
                        </td>
                          <td style="text-align: left">
                            <asp:Label ID="Label1" runat="server" Text='<%#Bind("IPAddress")%>'></asp:Label>
                        </td>
                         <td style="text-align: left">
                            <asp:Label ID="Label2" runat="server" Text='<%#Bind("MACAddress")%>'></asp:Label>
                        </td>
                         <td style="text-align: left">
                            <asp:Label ID="Label3" runat="server" Text='<%#Enum.Parse(typeof(OH.Utilities.EnumCollection.Browsers), Eval("BrowserNameID").ToString())%>'></asp:Label>
                        </td>
                         <td style="text-align: right">
                            <asp:Label ID="Label4" runat="server" Text='<%#Bind("BrowsingTimeDuration")%>'></asp:Label>
                        </td>
                    </tr>
                </AlternatingItemTemplate>
                <EmptyDataTemplate>

                    <tr>
                        <td>Information is empty ...
                        </td>
                    </tr>
                    </table>
                </EmptyDataTemplate>
            </asp:ListView>
            <asp:DataPager ID="dataPagerRegisteredUserAddGiverTracing" runat="server" PagedControlID="lvRegisteredUserAddGiverTracing"
                PageSize="10" >
                <Fields>
                    <asp:NextPreviousPagerField FirstPageText="First" ButtonCssClass="BornoCss" PreviousPageText="Previous"
                        ShowNextPageButton="False" ShowFirstPageButton="False" />
                    <asp:NumericPagerField PreviousPageText="..." CurrentPageLabelCssClass="BornoCss"
                        NumericButtonCssClass="BornoCss" NextPreviousButtonCssClass="BornoCss" RenderNonBreakingSpacesBetweenControls="True"
                        ButtonType="Link" />
                    <asp:NextPreviousPagerField FirstPageText="First" ButtonCssClass="BornoCss" LastPageText="Last"
                        NextPageText="Next" PreviousPageText="Previous" ShowPreviousPageButton="False"
                        ShowLastPageButton="False" />
                </Fields>
            </asp:DataPager>
        </fieldset>
         </div>



        </div>
</asp:Content>
