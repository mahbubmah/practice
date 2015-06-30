<%@ Page Title="" Language="C#" MasterPageFile="~/MortgageMasterPage.Master" AutoEventWireup="true" CodeBehind="MortgageDetails.aspx.cs" Inherits="OMart.Web.MortgageDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MortgagePlaceHolder" runat="server">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <section>
                <div class="container mortagageTabingWrp">
                    <div class="row">

                        <div role="tabpanel" class="mortagageTabing">

                            <div class="tab-content">
                                <div role="tabpanel" class="tab-pane active" id="Remortgage">

                                    <div class="row">

                                        <div class="col-sm-2">
                                            <br />
                                            Mortgage Type 
                                    <asp:DropDownList ID="ddlMortgageType" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlMortgageType_SelectedIndexChanged"></asp:DropDownList>
                                            <br />
                                            Rate Type 
                                    <asp:DropDownList ID="ddlRateType" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlRateType_SelectedIndexChanged"></asp:DropDownList>
                                            <br />
                                            Initial Period<asp:DropDownList ID="ddlInitialPeriod" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlInitialPeriod_SelectedIndexChanged"></asp:DropDownList>
                                            <br />

                                            Payment Type<asp:DropDownList ID="ddlPaymentType" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlPaymentType_SelectedIndexChanged"></asp:DropDownList>

                                        </div>



                                        <div class="col-sm-10">
                                            <asp:ObjectDataSource ID="odsMorgageTypeDetails" runat="server"
                                                TypeName="BLL.Basic.MortgageRT"
                                                SelectCountMethod="SelectMortgageCount"
                                                EnablePaging="True"
                                                MaximumRowsParameterName="noOfMaximumRows"
                                                StartRowIndexParameterName="noOfStartRowIndex"
                                                SelectMethod="SelectAllList"
                                                OnSelecting="odsMorgageTypeDetails_Selecting"></asp:ObjectDataSource>

                                            <table class="table tbLoan" id="task-table">
                                                <thead style="background-color: #EAE9E9;">
                                                    <tr>
                                                        <th></th>
                                                        <th>Initial Rate</th>

                                                        <th>Fees/Charge</th>
                                                        <th>APR</th>
                                                        <th>Monthly Installment Amount</th>
                                                        <th></th>
                                                    </tr>
                                                </thead>

                                                <asp:ListView AllowPaging="True"
                                                    AllowSorting="True"
                                                    EnableSortingAndPagingCallbacks="True"
                                                    AutoGenerateColumns="False"
                                                    DataSourceID="odsMorgageTypeDetails"
                                                    EmptyDataText="No rows to display."
                                                    runat="server"
                                                    ID="lvMortgageTypeDetails"
                                                    OnPagePropertiesChanging="lvMortgageTypeDetails_PagePropertiesChanging"
                                                    OnItemDataBound="lvMortgageTypeDetails_ItemDataBound">

                                                    <ItemTemplate>

                                                        <tbody>
                                                            <a href='<%# Eval("RedirectUrl") %>' target="_blank">

                                                                <tr>
                                                                    <td>
                                                                        <asp:HiddenField ID="hdMortgageIID" runat="server" Value='<%# Eval("IID") %>'></asp:HiddenField>
                                                                        <div class="productDescImg">
                                                                            <a href='<%# Eval("RedirectUrl") %>' target="_blank">
                                                                                <asp:Image CssClass="img-responsive" runat="server" Width="160px" Height="60" ImageUrl='<%# Eval("LogoUrl") %>' alt="img" />
                                                                            </a>
                                                                        </div>
                                                                    </td>
                                                                    <td>
                                                                        <div class="productDescription">
                                                                            <asp:Repeater ID="rptInterestRateType" runat="server"
                                                                                EnableViewState="False">
                                                                                <HeaderTemplate>
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <div>
                                                                                        <h4 style="float: left;">
                                                                                            <asp:Label ID="lblRate" runat="server"> <%# Eval("Rate","{0:#,##0.00}") %>%</asp:Label></h4>
                                                                                        <h4 style="float: left">
                                                                                            <asp:Label ID="lblNote" runat="server"> <%# Eval("Note") %>%</asp:Label></h4>
                                                                                    </div>
                                                                                </ItemTemplate>
                                                                                <FooterTemplate>
                                                                                </FooterTemplate>

                                                                            </asp:Repeater>
                                                                        </div>

                                                                    </td>
                                                                    <td>
                                                                        <div class="apr">
                                                                            <h4>
                                                                                <asp:Label ID="lblFees" runat="server"><%#(char)2547%><%# Eval("FeeOrCharge","{0:#,##0.00}") %></asp:Label></h4>
                                                                            <p>Representative</p>
                                                                        </div>
                                                                    </td>
                                                                    <td>
                                                                        <div class="ttlPay">
                                                                            <h4>
                                                                                <asp:Label ID="lblOverallCost" runat="server"><%# Eval("APR") %>%</asp:Label></h4>
                                                                        </div>
                                                                    </td>
                                                                    <td>
                                                                        <div class="repayble">
                                                                            <h4>
                                                                                <span>
                                                                                    <asp:Label ID="lblInitialMonthlyCost" runat="server"><%#(char)2547%><%# Eval("MonthlyInstallmentAmt","{0:#,##0.00}") %></asp:Label></span>
                                                                            </h4>
                                                                            <p>
                                                                                repayable 
per month
                                                                            </p>
                                                                        </div>
                                                                    </td>
                                                                    <td>
                                                                        <div class="applyBox">
                                                                            <a href='<%# Eval("RedirectUrl") %>' target="_blank" class="btn btn-danger">Apply <span class="glyphicon glyphicon-chevron-right oioCherRight2"></span></a>
                                                                            <a href='<%# Eval("RedirectUrl") %>' target="_blank" style="color: green; text-decoration: underline">more Info</a>
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                            </a>

                                                            <tr>

                                                                <td colspan="6">
                                                                    <a href='<%# Eval("RedirectUrl") %>' target="_blank">
                                                                        <div class="trfoter">
                                                                            <p class="text-left">

                                                                                <span>
                                                                                    <%# Eval("Description") %>
                                                                                </span>
                                                                            </p>
                                                                        </div>
                                                                    </a>

                                                                </td>

                                                            </tr>



                                                        </tbody>
                                                        </a>
                                                    </ItemTemplate>

                                                </asp:ListView>
                                            </table>
                                            <asp:DataPager ID="dataPagerMortgageTypeInfo" runat="server" PagedControlID="lvMortgageTypeDetails"
                                                PageSize="10">
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

                                        </div>

                                    </div>

                                </div>

                            </div>
                        </div>

                    </div>
                </div>
            </section>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
