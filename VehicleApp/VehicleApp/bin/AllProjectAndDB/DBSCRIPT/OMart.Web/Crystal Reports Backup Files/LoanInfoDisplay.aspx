<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.Master" AutoEventWireup="true" CodeBehind="LoanInfoDisplay.aspx.cs" Inherits="OMart.Web.AdminPanel.LoanInfoDisplay" %>
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
                                <legend>Loan Information</legend>

                                <asp:ListView ID="lvLoanInfo" runat="server" DataKeyNames="IID" OnPagePropertiesChanging="lvLoanInfo_PagePropertiesChanging" OnPreRender="lvLoanInfo_PreRender">
                                    <LayoutTemplate>
                                        <table class="table  table-hover table-bordered">
                                            <thead>
                                                <tr runat="server">
                                                    <th class="col-xs-1">SL #
                                                    </th>
                                                    <th class="col-xs-4">Company Name
                                                    </th>
                                                    <th class="col-xs-2">Loan Type
                                                    </th>
                                                    <th class="col-xs-2">Total Amount
                                                    </th>
                                                    <th class="col-xs-2">Payment Amount
                                                    </th>
                                                    <th class="col-xs-6">Post Date
                                                    </th>
                                                    <th class="col-xs-6">PostLast Display Date
                                                    </th>
                                                    <th class="col-xs-1">Is Verified
                                                    </th>
                                                     <th class="col-xs-1">Is Removed
                                                    </th>
                                                    <th class="col-xs-1">Edit
                                                    </th>
                                                    <th class="col-xs-1">Delete
                                                    </th>

                                                </tr>
                                            </thead>
                                            <tbody id="itemPlaceholder" runat="server">
                                            </tbody>
                                        </table>
                                    </LayoutTemplate>
                                    <ItemTemplate>
                                        <tr runat="server">
                                            <td style="text-align: right">
                                                <%# Container.DataItemIndex + 1%>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblCode" runat="server" Text='<%# Bind("cName") %>'></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblName" runat="server" Text='<%# Enum.Parse(typeof( Utilities.EnumCollection.LoanType),Eval("lType").ToString()) %>'></asp:Label>
                                            </td>
                                            
                                            <td style="text-align:right">
                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("totalAmount") %>'></asp:Label>
                                            </td>
                                            <td style="text-align: right">
                                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("paymentAmount") %>'></asp:Label>
                                            </td>
                                            <td style="text-align:center">
                                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("postDate") %>'></asp:Label>
                                            </td>
                                            <td style="text-align: center">
                                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("postLastDisplayDate") %>'></asp:Label>
                                            </td>
                                            <td style="text-align: center">
                                                <asp:Label ID="Label5" runat="server" Text='<%# Bind("IsVerified") %>'></asp:Label>
                                            </td>
                                            <td style="text-align: center">
                                                <asp:Label ID="lblIsRemoved" runat="server" Text='<%# Bind("IsRemoved") %>' Enabled="false"></asp:Label>
                                            </td>

                                            <td style="text-align: center">
                                                <p data-placement="top" data-toggle="tooltip" title="Edit">
                                                    <asp:LinkButton ID="lnkbEdit" runat="server" CausesValidation="false" class="btn btn-primary btn-xs" data-title="Edit"
                                                        CommandArgument='<%# Bind("IID") %>' OnClick="lnkbEdit_Click" ><i class="fa fa-pencil-square-o"></i></asp:LinkButton>

                                                </p>
                                            </td>
                                            <td style="text-align: center">
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
                                <asp:DataPager ID="dataPagerLoanInfo" runat="server" PagedControlID="lvLoanInfo"
                                    PageSize="10" OnPreRender="dataPagerLoanInfo_PreRender">
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
