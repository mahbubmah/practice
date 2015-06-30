﻿<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.Master" AutoEventWireup="true" CodeBehind="CarInsuranceParameterView.aspx.cs" Inherits="OMart.Web.AdminPanel.CarInsuranceParameterView" %>
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
                                <legend>Car Insurance Parameter Info  List</legend>

                                <asp:ListView ID="lvCarInsuranceParameter" runat="server" DataKeyNames="IID"
                                    OnPagePropertiesChanging="lvCarInsuranceParameter_PagePropertiesChanging" OnPreRender="dataPagerCarInsuranceParameter_PreRender">
                                    <LayoutTemplate>
                                        <table class="table  table-hover table-bordered">
                                            <thead>
                                                <tr runat="server">
                                                    <th class="col-xs-1">SL #
                                                    </th>
                                                    <th class="col-xs-2">Car Type
                                                    </th>
                                                    <th class="col-xs-2">Car Condition
                                                    </th>
                                                    <th class="col-xs-2">Min Run
                                                    </th>                                                    
                                                    
                                                    <th class="col-xs-2">Max Run
                                                    </th>
                                                     <th class="col-xs-2">Min Car Age
                                                    </th>
                                                    <th class="col-xs-2">MaxCarAge
                                                    </th>
                                                     <th class="col-xs-2">MinCarValueAmount
                                                    </th>
                                                     <th class="col-xs-2">Max Car Value Amount
                                                    </th>
                                                     <th class="col-xs-2">Premium Total Percent
                                                    </th>
                                                    <th class="col-xs-2">Duration
                                                    </th>
                                                    <th class="col-xs-2">Is Removed
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
                                                <asp:Label ID="lblCode" runat="server" Text='<%# Enum.Parse(typeof( Utilities.EnumCollection.CarType),Eval("CarTypeID").ToString()) %>' ></asp:Label>
                                            </td>
                                            
                                            <td>
                                                <asp:Label ID="lblISDCode" runat="server" Text='<%# Enum.Parse(typeof( Utilities.EnumCollection.CarCondition),Eval("CarConditionID").ToString()) %>'></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("MinRun") %>' ></asp:Label>
                                            </td>
                                            
                                            
                                            <td >
                                                <asp:Label ID="lblName" runat="server" Text='<%# Bind("MaxRun") %>'></asp:Label>
                                            </td>
                                            <td >
                                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("MinCarAge") %>'></asp:Label>
                                            </td>
                                            <td >
                                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("MaxCarAge") %>'></asp:Label>
                                            </td>
                                            <td >
                                                <asp:Label ID="Label5" runat="server" Text='<%# Bind("MinCarValueAmount") %>'></asp:Label>
                                            </td>
                                            <td >
                                                <asp:Label ID="Label6" runat="server" Text='<%# Bind("MaxCarValueAmount") %>'></asp:Label>
                                            </td>
                                            <td >
                                                <asp:Label ID="Label7" runat="server" Text='<%# Bind("PremiumTotalPercent") %>'></asp:Label>
                                            </td>
                                            <td >
                                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("Duration") %>'></asp:Label>
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="chkIsRemoved" runat="server" Checked='<%# Bind("IsRemoved") %>' Enabled="false"></asp:CheckBox>
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
                                <asp:DataPager ID="dataPagerCarInsuranceParameter" runat="server" PagedControlID="lvCarInsuranceParameter"
                                    PageSize="10" OnPreRender="dataPagerCarInsuranceParameter_PreRender">
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

