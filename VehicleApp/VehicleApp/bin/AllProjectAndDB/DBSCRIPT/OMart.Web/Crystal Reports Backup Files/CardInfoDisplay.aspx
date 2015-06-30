﻿<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.Master" AutoEventWireup="true" CodeBehind="CardInfoDisplay.aspx.cs" Inherits="OMart.Web.AdminPanel.CardInfoDisplay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AdminHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AdminContentPlaceHolder" runat="server">
    <section>
        <div class="container">

            <br />
            <div class="row">
                <div class="col-sm-12">
                    <div class="pull-left">
                        <asp:Label ID="labelMessage" runat="server"></asp:Label>
                    </div>
                    <div class="pull-right">
                              <%--<asp:Button ID="btnPrint" runat="server" Text="Print" OnClick="btnPrint_Click" CssClass="btn btn-primary" />
                        &nbsp;--%>
                        <asp:Button ID="btnAdd" runat="server" Text="Add New" OnClick="btnAdd_Click" CssClass="btn btn-primary" />
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-sm-12">
                    <div class="manageAdd">
                        <div class="addPostMang">

                            <fieldset class="adminFieldset">
                                <legend>Card informaion List</legend>

                                <asp:ListView ID="lvCardInfo" runat="server" DataKeyNames="IID"
                                    OnPagePropertiesChanging="lvCardInfo_PagePropertiesChanging" OnPreRender="dataPagerCardInfo_PreRender">
                                    <LayoutTemplate>
                                        <table class="table  table-hover table-bordered">
                                            <thead>
                                                <tr runat="server">
                                                     <th class="col-xs-1">SL #
                                                    </th>
                                                    <th class="col-xs-1">Company name
                                                    </th>
                                                     <th class="col-xs-2">Description
                                                    </th>
                                                     <th class="col-xs-1">Name
                                                    </th>
                                                     <th class="col-xs-2">Card Logo
                                                    </th>
                                                     <th class="col-xs-1">APR
                                                    </th>
                                                     <th class="col-xs-1">Minimum limit amount
                                                    </th>
                                                     <th class="col-xs-1">Maximum limit amount
                                                    </th>
                                                     <th class="col-xs-1">Annual fee payment
                                                    </th>
                                                    <th class="col-xs-2">Post last display date
                                                    </th>
                                                   <%-- <th>Print
                                                    </th>--%>
                                                    <th>Edit
                                                    </th>
                                                    <th>Delete
                                                    </th>

                                                </tr>
                                            </thead>
                                            <tbody id="itemPlaceholder" runat="server">
                                            </tbody>
                                        </table>
                                    </LayoutTemplate>
                                    <ItemTemplate>
                                        <tr runat="server">
                                            <td style="text-align: center">
                                                <%# Container.DataItemIndex + 1%>
                                            </td>
                                             <td>
                                                <asp:Label ID="lblCardInfo" runat="server" Text='<%# Bind("CompanyName") %>'></asp:Label>
                                            </td>
                                              <td>
                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                                            </td>
                                             <td>
                                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                            </td>
                                             <td>
                                                 <asp:Image runat="server" ImageUrl='<%# Bind("CardLogoUrl") %>' ID="image" Width="150" Height="75"/>
                                            </td>
                                             <td style="text-align: right">
                                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("APR","{0:0.##}") %>'></asp:Label>
                                            </td>
                                            <td style="text-align: right">
                                                <asp:Label ID="Label5" runat="server" Text='<%# Bind("MinimumLimitAmt","{0:0.##}") %>'></asp:Label>
                                            </td>
                                            <td style="text-align: right">
                                                <asp:Label ID="Label6" runat="server" Text='<%# Bind("MaximumLimitAmt","{0:0.##}") %>'></asp:Label>
                                            </td>
                                             <td style="text-align: right">
                                                <asp:Label ID="Label7" runat="server" Text='<%# Bind("AnnualFeePayment","{0:0.##}") %>'></asp:Label>
                                            </td>
                                              <td style="text-align: center">
                                                <asp:Label ID="Label8" runat="server" Text='<%# Eval("PostLastDisplayDate","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                            </td>
                                            
                                            
                                            <%-- <td>
                                                <p data-placement="top" data-toggle="tooltip" title="Print">
                                                    <asp:LinkButton ID="lnkbPrint" runat="server" CausesValidation="false" class="btn btn-primary btn-xs" data-title="Edit"
                                                        CommandArgument='<%# Bind("IID") %>' OnClick="lnkbPrint_Click"><i class="fa fa-print"></i></asp:LinkButton>
                                                </p>
                                            </td>--%>
                                            <td>
                                                <p data-placement="top" data-toggle="tooltip" title="Edit">
                                                    <asp:LinkButton ID="lnkbEdit" runat="server" CausesValidation="false" class="btn btn-primary btn-xs" data-title="Edit"
                                                        CommandArgument='<%# Bind("IID") %>' OnClick="lnkbEdit_Click"><i class="fa fa-pencil-square-o"></i></asp:LinkButton>
                                                </p>
                                            </td>
                                            <td>
                                                <p data-placement="top" data-toggle="tooltip" title="Delete">
                                                    <asp:LinkButton ID="lnkbDelete" runat="server" CausesValidation="false" class="btn btn-danger btn-xs" data-title="Delete" OnClientClick="return confirm('Are you sure, do you want to delete?');"
                                                        CommandArgument='<%# Bind("IID") %>' OnClick="lnkbDelete_Click"><i class="fa fa-trash"></i></asp:LinkButton>
                                                </p>
                                            </td>


                                        </tr>
                                    </ItemTemplate>

                                    <EmptyDataTemplate>
                                        <tr>
                                            <td>Information is empty ...
                                            </td>
                                        </tr>
                                        </table>
                                    </EmptyDataTemplate>
                                </asp:ListView>
                                <asp:DataPager ID="dataPagerCardInfo" runat="server" PagedControlID="lvCardInfo"
                                    PageSize="10" OnPreRender="dataPagerCardInfo_PreRender">
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
                </div>
            </div>
        </div>
    </section>
</asp:Content>