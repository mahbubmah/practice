﻿<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.Master" AutoEventWireup="true" CodeBehind="GasCylienderDisplay.aspx.cs" Inherits="OMart.Web.AdminPanel.GasCylienderDisplay" %>

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
                        <asp:Button ID="btnAdd" runat="server" Text="Add New" OnClick="btnAdd_Click" CssClass="btn btn-primary" />
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-sm-12">
                    <div class="manageAdd">
                        <div class="addPostMang">

                            <fieldset class="adminFieldset">
                                <legend>All gas cyliender List</legend>

                                <asp:ListView ID="lvGasCyliender" runat="server" DataKeyNames="IID"
                                    OnPagePropertiesChanging="lvGasCyliender_PagePropertiesChanging" OnPreRender="dataPagerGasCyliender_PreRender">
                                    <LayoutTemplate>
                                        <table class="table  table-hover table-bordered">
                                            <thead>
                                                <tr runat="server">
                                                    <th class="col-xs-1">SL #
                                                    </th>
                                                    <th class="col-xs-4">Company name
                                                    </th>
                                                    <th class="col-xs-2">Weight of gas
                                                    </th>
                                                    <th class="col-xs-2">Weight of container
                                                    </th>
                                                    <th class="col-xs-3">Retail price
                                                    </th>
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
                                                <asp:Label ID="lblCardInfo" runat="server" Text='<%# Bind("CompanyInfo.Name") %>'></asp:Label>
                                            </td>
                                            <td style="text-align: right">
                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("WeightOfGas","{0:0.##}") %>'></asp:Label>
                                            </td>

                                            <td style="text-align: right">
                                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("WeightOfContainer","{0:0.##}") %>'></asp:Label>
                                            </td>
                                            <td style="text-align: right">
                                                <asp:Label ID="Label5" runat="server" Text='<%# Bind("RetailPrice","{0:0.##}") %>'></asp:Label>
                                            </td>

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
                                <asp:DataPager ID="dataPagerGasCyliender" runat="server" PagedControlID="lvGasCyliender"
                                    PageSize="10" OnPreRender="dataPagerGasCyliender_PreRender">
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

