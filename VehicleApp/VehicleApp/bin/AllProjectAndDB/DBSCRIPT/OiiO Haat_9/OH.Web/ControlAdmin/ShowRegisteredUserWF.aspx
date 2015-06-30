<%@ Page Title="" Language="C#" MasterPageFile="~/ControlAdmin/ControlAdminMaster.Master" AutoEventWireup="true" CodeBehind="ShowRegisteredUserWF.aspx.cs" Inherits="OH.Web.ControlAdmin.ShowRegisteredUserWF" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxConTK" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headAdmin" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentAdminMain" runat="server">
     <div class="container adminPagewrp">
        <div class="row">
            <h2>Show Registered User</h2>
        </div>
        <div>
            <asp:Label ID="labelMessageRegisteredUser" runat="server" Text="..."></asp:Label>
        </div>
           <div>
            <fieldset>
                <legend>Search Registered User</legend>
                 <div class="row">
                    <div class="form-group col-xs-5">
                        <div class="input-group">
                            <span class="input-group-addon">Search By User ID(Email)
                            </span>
                            <asp:TextBox ID="txtSearchByUserID" runat="server" Text="" class="form-controlWebSer" placeholder="Enter User ID..."></asp:TextBox>
                        </div>
                    </div>
                </div>

                 <div class="row">
                    <div class="form-group col-xs-5">
                        <div class="input-group">
                            <span class="input-group-addon">Search From Date
                            </span>
                             <ajaxConTK:CalendarExtender ID="extSearchFromDate" runat="server" Enabled="True" TargetControlID="txtSearchFromDate"  Format="yyyy-MM-dd"></ajaxConTK:CalendarExtender>
                            <asp:TextBox ID="txtSearchFromDate" runat="server" Text="" class="form-controlWebSer" placeholder="Enter from Which date You Want to search..."></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="form-group col-xs-5">
                        <div class="input-group">
                            <span class="input-group-addon">Search To Date
                            </span>
                            <ajaxConTK:CalendarExtender ID="extSearchToDate" runat="server" Enabled="True" TargetControlID="txtSearchToDate"  Format="yyyy-MM-dd"></ajaxConTK:CalendarExtender>
                            <asp:TextBox ID="txtSearchToDate" runat="server" Text="" class="form-controlWebSer" placeholder="Enter To Which date You Want to search..."></asp:TextBox>
                        </div>
                    </div>
                </div>

                 <div class="row">
                    <div class="col-xs-5">
                        <div class="input-group pull-right">
                            <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary"></asp:Button>
                            <asp:HiddenField runat="server" ID="hdShowRegisteredUserID" />
                            <asp:HiddenField runat="server" ID="hdIsEdit" />
                            <asp:HiddenField runat="server" ID="hdIsDelete" />
                        </div>
                    </div>
                </div>
                </fieldset>
               </div>

         <div>
             <fieldset>
                 <legend>Registered User Information</legend>
                <asp:ListView ID="lvRegisteredUser" runat="server" DataKeyNames="IID" OnPagePropertiesChanging="lvRegisteredUser_PagePropertiesChanging" OnItemCommand="lvRegisteredUser_ItemCommand">
                    <LayoutTemplate>
                        <table class="table table-bordered table-hover" style="margin-bottom: 0px;">
                            <thead>
                                <tr runat="server">
                                    <th class="col-xs-1">SL #
                                    </th>
                                    <th class="col-xs-1">User Name
                                    </th>
                                    <th class="col-xs-1">User ID
                                    </th>
                                    <th class="col-xs-1">Registered From
                                    </th>
                                    <th class="col-xs-1">Active
                                    </th>
                                   
                                </tr>
                            </thead>
                            <tbody id="itemPlaceholder" runat="server">
                            </tbody>
                        </table>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr id="trBody" runat="server">
                            <td style="text-align: center">
                                <%# Container.DataItemIndex + 1%>
                            </td>
                            <td style="text-align: left">
                                <asp:Label ID="lblRegisteredUserID" runat="server" Text='<%# Bind("IID") %>' Visible="false"></asp:Label>
                                <asp:LinkButton ID="lnkBtnName" runat="server" CausesValidation="false" Text='<%#Bind("Name")%>'
                                    CommandArgument='<%# Bind("IID") %>' CommandName="EditRegisteredUser"></asp:LinkButton>
                            </td>
                            <td>
                                <asp:Label ID="lblEmailID" runat="server" Text='<%# Bind("EmailID") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblCreatedDateID" runat="server" Text='<%# Bind("CreatedDate") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblIsVerifiedID" runat="server" Text='<%# Bind("IsVerified") %>'></asp:Label>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <tr class="bg-info" runat="server">
                            <td style="text-align: center">
                                <%# Container.DataItemIndex + 1%>
                            </td>
                            <td style="text-align: left">
                                <asp:Label ID="lblRegisteredUserID" runat="server" Text='<%# Bind("IID") %>' Visible="false"></asp:Label>
                                <asp:LinkButton ID="lnkBtnName" runat="server" CausesValidation="false" Text='<%#Bind("Name")%>'
                                    CommandArgument='<%# Bind("IID") %>' CommandName="EditRegisteredUser"></asp:LinkButton>
                            </td>
                            <td>
                                <asp:Label ID="lblEmailID" runat="server" Text='<%# Bind("EmailID") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblCreatedDateID" runat="server" Text='<%# Bind("CreatedDate") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblIsVerifiedID" runat="server" Text='<%# Bind("IsVerified") %>'></asp:Label>
                            </td>
                        </tr>
                    </AlternatingItemTemplate>
                    <EmptyDataTemplate>
                        <table>
                            <tr>
                                <td>Information is empty ...
                                </td>
                            </tr>
                        </table>
                    </EmptyDataTemplate>
                </asp:ListView>
                <asp:DataPager ID="dataPagerRegisteredUser" runat="server" PagedControlID="lvRegisteredUser"
                    PageSize="10" OnPreRender="dataPagerRegisteredUser_PreRender">
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
                 <br />
                 <br />
             </fieldset>
             </div>

         </div>
</asp:Content>
