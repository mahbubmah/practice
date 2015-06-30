<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.Master" AutoEventWireup="true" CodeBehind="MortgageDisplay.aspx.cs" Inherits="OMart.Web.AdminPanel.MortgageDisplay" %>

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
                                <legend>Mortgage List</legend>

                                <asp:ListView ID="lvMortgage" runat="server" DataKeyNames="IID"
                                    OnPagePropertiesChanging="lvMortgage_PagePropertiesChanging" OnPreRender="dataPagerMortgage_PreRender">
                                    <LayoutTemplate>
                                        <table class="table  table-hover table-bordered">
                                            <thead>
                                                <tr runat="server">
                                                    <th>SL #
                                                    </th>
                                                    <th class="col-xs-1">Company name
                                                    </th>
                                                    <th class="col-xs-1">Mortgage type
                                                    </th>
                                                    <%--<th class="col-xs-1">Interest rate type
                                                    </th>--%>
                                                     <th class="col-xs-1">Mortgege term year
                                                    </th>
                                                     <th class="col-xs-2">Payment type
                                                    </th>
                                                     <th class="col-xs-1">Fee/Charge
                                                    </th>
                                                    <th class="col-xs-1">Annual Percentage Rate(APR)
                                                    </th>
                                                     <th class="col-xs-2">Post add date
                                                    </th>
                                                     <th class="col-xs-2">Post last display date
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
                                            <td style="text-align: right">
                                                <%# Container.DataItemIndex + 1%>
                                            </td>
                                             <td style="text-align: left">
                                                <asp:Label ID="lblMortgage" runat="server" Text='<%# Bind("CompanyName") %>'></asp:Label>
                                            </td>
                                              <td style="text-align: left">
                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("MortageType") %>'></asp:Label>
                                            </td>
                                              <%--<td>
                                                <asp:Label ID="lblISDCode" runat="server" Text='<%# Bind("InterestRateType") %>'></asp:Label>
                                            </td>--%>
                                             <td style="text-align: right">
                                                <asp:Label ID="lblName" runat="server" Text='<%# Bind("MortgageTermYear") %>'></asp:Label>
                                            </td>
                                             <td style="text-align: left">
                                                <asp:Label ID="lblLocation" runat="server" Text='<%# Bind("PaymentType") %>'></asp:Label>
                                            </td>
                                            <td style="text-align: right">
                                                <asp:Label ID="lblCode" runat="server" Text='<%# Bind("FeeOrCharge") %>'></asp:Label>
                                            </td>
                                            
                                             <td style="text-align: right">
                                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("APR") %>'></asp:Label>
                                            </td>
                                             <td style="text-align: center">
                                                <asp:Label ID="Label3" runat="server" Text='<%# Eval("PostAdDate","{0:dd-MMM-yyyy}") %>'> </asp:Label>
                                            </td>
                                             <td style="text-align: center">
                                                <asp:Label ID="Label4" runat="server" Text='<%# Eval("PostLastDisplayDate","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                            </td>

                                            <td style="text-align: center">
                                                <p data-placement="top" data-toggle="tooltip" title="Edit">
                                                    <asp:LinkButton ID="lnkbEdit" runat="server" CausesValidation="false" class="btn btn-primary btn-xs" data-title="Edit"
                                                        CommandArgument='<%# Bind("IID") %>' OnClick="lnkbEdit_Click"><i class="fa fa-pencil-square-o"></i></asp:LinkButton>

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
                                <asp:DataPager ID="dataPagerMortgage" runat="server" PagedControlID="lvMortgage"
                                    PageSize="10" OnPreRender="dataPagerMortgage_PreRender">
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

