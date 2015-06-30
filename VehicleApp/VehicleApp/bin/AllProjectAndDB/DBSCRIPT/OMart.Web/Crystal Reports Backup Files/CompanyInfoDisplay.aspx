<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.Master" AutoEventWireup="true" CodeBehind="CompanyInfoDisplay.aspx.cs" Inherits="OMart.Web.AdminPanel.CompanyInfoDisplay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AdminHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AdminContentPlaceHolder" runat="server">
    <section>
        <div class="container">

            <br />
            <div class="row">
                <div class="col-sm-12">
                    <div class="pull-left">
                        <asp:Label ID="lblMessage" runat="server"></asp:Label>
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
                                <legend>CompanyInfo Lists</legend>

                                <asp:ListView ID="lvCompanyInfoDisplay" runat="server" DataKeyNames="IID"
                                    OnPagePropertiesChanging="lvCompanyInfoDisplay_PagePropertiesChanging" OnPreRender="dataPagerCompanyInfoDisplay_PreRender" >
                                    <LayoutTemplate>
                                        <table class="table  table-hover table-bordered">
                                            <thead>
                                                <tr runat="server">

                                                    <th class="col-xs-1">SL #
                                                    </th>
                                                    <th class="col-xs-1">Company Name
                                                    </th>
                                                    <th class="col-xs-3">Bussiness Description
                                                    </th>
                                                    <th class="col-xs-2">Address
                                                    </th>
                                                    <th class="col-xs-1">Web Address
                                                    </th>
                                                    <th class="col-xs-1">Origin Country
                                                    </th>
                                                    <th class="col-xs-1">Bussiness Type
                                                    </th>
                                                    <th class="col-xs-1">Total Country Bussiness
                                                    </th>
                                                     <th >IsRemoved
                                                    </th>
                                                    <th >Edit
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
                                           
                                            <td style="text-align: left">
                                                <asp:Label ID="lblName" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                            </td>
                                             <td>
                                                <asp:Label ID="lblBussDescription" runat="server" Text='<%# Bind("BussinessDescription") %>'></asp:Label>
                                            </td>
                                             <td>
                                                <asp:Label ID="lblAddress" runat="server" Text='<%# Bind("Address") %>'></asp:Label>
                                            </td>
                                             <td>
                                                <asp:Label ID="lblWebAddress" runat="server" Text='<%# Bind("WebAddress") %>'></asp:Label>
                                            </td>
                                             <td>
                                                <asp:Label ID="lblOriginCountryID" runat="server" Text='<%# Bind("OriginCountryName") %>'></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblBussType" runat="server" Text='<%# Enum.Parse(typeof( Utilities.EnumCollection.BussinessType),Eval("BussinessTypeID").ToString()) %>'></asp:Label>
                                            </td>
                                             <td>
                                                <asp:Label ID="lblTotalCountry" runat="server" Text='<%# Bind("TotalCountryBussCover") %>'></asp:Label>
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
                                <asp:DataPager ID="dataPagerCompanyInfoDisplay" runat="server" PagedControlID="lvCompanyInfoDisplay"
                                    PageSize="10" OnPreRender="dataPagerCompanyInfoDisplay_PreRender">
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
