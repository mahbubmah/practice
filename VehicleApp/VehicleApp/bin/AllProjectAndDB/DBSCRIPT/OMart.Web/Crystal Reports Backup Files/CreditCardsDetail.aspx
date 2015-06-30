<%@ Page Title="" Language="C#" MasterPageFile="~/OiiOMasterPage.master" AutoEventWireup="true" CodeBehind="CreditCardsDetail.aspx.cs" Inherits="OMart.Web.CreditCardsDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <section>
                <div class="container-fluid bannerWrp mortagesPage">

                    <div class="carousel fade-carousel slide oiioFadeBanner BroadBandBanner creditCardspage" data-ride="carousel" data-interval="4000" id="bs-carousel">
                        <!-- Overlay -->

                        <!-- Wrapper for slides -->
                        <div class="carousel-inner">
                            <div class="item slides active">
                                <div class="slideinsur1">
                                </div>
                                <div class="insBannerCntWrp">
                                    <div class="insBannerCnt">
                                        <div class="col-sm-8">
                                            <div class="row">
                                                <div class="col-sm-6">
                                                    <div class="bannerMortagesCnt">
                                                        <h3>
                                                            <asp:Label runat="server" ID="lblCardSlideActiveCardTypeName"></asp:Label>
                                                        </h3>
                                                        <h4>
                                                            <asp:Label runat="server" ID="lblCardSlideActiveCardInfoName"></asp:Label></h4>
                                                        <p>
                                                            <asp:Label runat="server" ID="lblCardSlideActiveCardInfoDescription"></asp:Label>
                                                        </p>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-4">
                                            <div class="hero2">
                                                <asp:Image ID="imgCardSlideActiveCardTypeImage" CssClass="img-responsive" runat="server" Height="250" Width="400" />

                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <asp:Repeater runat="server" ID="repCardTypeSlideDisplay">
                                <ItemTemplate>
                                    <div class="item slides">
                                        <div class="slideinsur1">
                                        </div>
                                        <div class="insBannerCntWrp">
                                            <div class="insBannerCnt">
                                                <div class="col-sm-8">
                                                    <div class="row">
                                                        <div class="bannerMortagesCnt">
                                                            <h3><%# Eval("Name") %> </h3>
                                                            <h4><%# Eval("CardInfoName") %></h4>
                                                            <p><%# Eval("Description") %></p>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-sm-4">
                                                    <div class="hero2">
                                                        <asp:Image ImageUrl='<%# Eval("CardLogoUrl") %>' CssClass="img-responsive" runat="server" Height="250" Width="400" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>


                        </div>


                    </div>

                </div>
            </section>
            <section>
                <div class="descpageMenu">
                    <div class="container">
                        <div class="row">
                            <nav role="navigation" class="navbar navbar-inverse oiioMainMenu oiioMainMenuCredit">
                                <div class="container">
                                    <!-- Brand and toggle get grouped for better mobile display -->
                                    <div class="navbar-header">
                                        <button data-target="#bs-example-navbar-collapse-1" data-toggle="collapse" class="navbar-toggle" type="button">
                                            <span class="sr-only">Toggle navigation</span>
                                            <span class="icon-bar"></span>
                                            <span class="icon-bar"></span>
                                            <span class="icon-bar"></span>
                                        </button>
                                    </div>
                                    <!-- Collect the nav links, forms, and other content for toggling -->
                                    <div id="bs-example-navbar-collapse-2" class="collapse navbar-collapse">
                                        <ul class="nav navbar-nav">
                                            <li>
                                                <a class="active">
                                                    <asp:LinkButton ID="lbSortMostPopular" OnClick="lbSortMostPopular_OnClick" CommandArgument="" runat="server">Most Popular </asp:LinkButton>
                                                </a>
                                            </li>
                                            <li>
                                                <a>
                                                    <asp:LinkButton ID="lbSortZeroBalanceTranceferRate" OnClick="zeroBalanceTranceferRate_OnClick" CommandName="0%BalanceTrancefer" CommandArgument="0%BalanceTrancefer" runat="server">0% balance transfer </asp:LinkButton>
                                                </a>
                                            </li>
                                            <li>
                                                <a>
                                                    <asp:LinkButton ID="lbSortZeropPercentPurchase" OnClick="zropPercentPurchase_OnClick" CommandArgument="0%Purchase" runat="server">0% purchase </asp:LinkButton>
                                                </a>
                                            </li>
                                            <li>
                                                <a>
                                                    <asp:LinkButton ID="lbSortLowApr" OnClick="lbSortLowApr_OnClick_OnClick" CommandArgument="LowAPR" runat="server">Low APR  </asp:LinkButton>
                                                </a>
                                            </li>
                                            <%--   <li>
                                        <a href="#">Bad credit</a>
                                    </li>
                                    <li>
                                        <a href="#">Reward</a>
                                    </li>
                                    <li>
                                        <a href="#">Bad credit  </a>
                                    </li>
                                    <li>
                                        <a href="#">Credit building </a>
                                    </li>
                                    <li>
                                        <a href="#">Cashback</a>
                                    </li>
                                    <li>
                                        <a href="#">Travel abroad</a>
                                    </li>--%>
                                        </ul>
                                    </div>
                                </div>
                            </nav>
                        </div>
                    </div>
                </div>
                <asp:Label runat="server" ID="lblMessage"></asp:Label>
                <asp:ObjectDataSource ID="objDsCardInfo" runat="server"
                    SortParameterName="sSortType"
                    EnablePaging="true"
                    SelectCountMethod="SelectCardInfoCount"
                    SelectMethod="SelectAllList"
                    MaximumRowsParameterName="iMaximumRows"
                    StartRowIndexParameterName="iBeginRowIndex"
                    TypeName="BLL.Basic.CardInfoRT"></asp:ObjectDataSource>

                <div class="container descriptionPage creditDesPage">
                    <table class="table tbLoan tbLoanAccount" id="task-table">

                        <asp:ListView AllowPaging="True"
                            AllowSorting="True"
                            EnableSortingAndPagingCallbacks="True"
                            AutoGenerateColumns="False"
                            DataSourceID="objDsCardInfo"
                            EmptyDataText="No rows to display." runat="server" ID="lvCardInfo" OnItemDataBound="repCardInfo_OnItemDataBound">
                            <LayoutTemplate>
                                <thead style="text-align: center; font-size: 15px">
                                    <tr>
                                        <th>Sort by popularity </th>
                                        <th></th>
                                        <th style="text-align: center">APR
                                        </th>
                                        <th style="text-align: center">Balance<br />
                                            transfer</th>
                                        <th style="text-align: center">Purchases</th>
                                        <th></th>
                                    </tr>
                                </thead>
                                <tbody id="itemPlaceholder" runat="server">
                                </tbody>
                            </LayoutTemplate>
                            <ItemTemplate>
                                <tbody>
                                    <tr>
                                        <td>
                                            <asp:HiddenField ID="hdCardInfoId" runat="server" Value='<%# Eval("IID") %>' />
                                            <asp:Image ImageUrl='<%# Eval("CardLogoUrl") %>' Width="171px" Height="108px" runat="server" />
                                          <%--  <ul class="creditList">
                                                <li><a href="#">Most Popular</a></li>
                                                <li><a href="#">Bad Credit</a></li>
                                                <li><a href="#">Credit Building</a></li>
                                            </ul>--%>
                                        </td>
                                        <td>
                                            <div class="productDescription">
                                                <h4><%# Eval("Name") %>
                                                    <br />
                                                    Features</h4>
                                                <ul>
                                                    <asp:Repeater runat="server" ID="repCardFeature">
                                                        <ItemTemplate>
                                                            <li>
                                                                <asp:LinkButton ID="lnk_btn_CardFeature" runat="server" CommandArgument='<%# Eval("IID") %>'>
                                                            <%# Eval("Description") %> 
                                                                </asp:LinkButton>
                                                            </li>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </ul>
                                                <p><a class="moreInformation" href="#">More Info</a></p>
                                            </div>
                                        </td>
                                        <td>
                                            <div class="apr" style="text-align: center">
                                                <h5><strong style="font-size: 20px"><%# Eval("APR" ,"{0:0.##}") %></strong>%</h5>
                                                <br />
                                                <h5>
                                                    <%# Eval("APRDescription") %>
                                                </h5>
                                            </div>
                                        </td>
                                        <td>
                                            <div class="ttlPay" style="text-align: center">
                                                <asp:Repeater runat="server" ID="repCardBalanceTransfer" OnItemDataBound="repCardBalanceTransfer_OnItemDataBound">
                                                    <ItemTemplate>
                                                        <h5>
                                                            <strong style="font-size: 20px">
                                                                <asp:Label runat="server"><%# Eval("MonthNumber") %> </asp:Label></strong>
                                                            months
                                                        </h5>
                                                        <h5>
                                                            <asp:Label runat="server"><%# Eval("TransferFeePercent","{0:0.##}") %> </asp:Label>% interest on
                                                        </h5>
                                                        <h5>transfers</h5>
                                                        <br />
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <h2>
                                                            <asp:Label ID="lblEmptyDataBalanceTransfer" Text="-" runat="server" Visible="false"></asp:Label></h2>
                                                    </FooterTemplate>
                                                </asp:Repeater>
                                            </div>
                                        </td>
                                        <td>
                                            <div class="ttlPay" style="text-align: center">
                                                <asp:Repeater runat="server" ID="repCardPurchase" OnItemDataBound="repCardPurchase_OnItemDataBound">
                                                    <ItemTemplate>
                                                        <h5><strong style="font-size: 20px"><%# Eval("MonthNumber") %></strong> months </h5>
                                                        <h5>
                                                            <%# Eval("RateOnPurchase" ,"{0:0.##}") %> % interest on
                                                        </h5>
                                                        <h5>purchases
                                                        </h5>
                                                        <br />
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <h2>
                                                            <asp:Label ID="lblEmptyDataPurchase" Text="-" runat="server" Visible="false"></asp:Label></h2>
                                                    </FooterTemplate>
                                                </asp:Repeater>

                                            </div>
                                        </td>
                                        <td>
                                            <div class="applyBox">
                                                <a href="<%# Eval("RedirectUrl") %>" target="_blank" class="btn btn-danger">Apply <span class="glyphicon glyphicon-chevron-right oioCherRight2"></span></a>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="6">
                                            <div class="trfoter">
                                                <p><%# Eval("Description") %></p>
                                            </div>

                                        </td>
                                    </tr>
                                </tbody>

                            </ItemTemplate>
                        </asp:ListView>

                    </table>


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



                </div>

                <div class="providerIem2 providerIem0403">
                    <div class="container">
                        <div class="row">
                            <div class="col-md-12">
                                <%--<a href="#" id="hrefCreditCardGuide" runat="server" onclick="Click_CreditCardGuideLine">Credit card guides</a>--%>
                               <%-- <asp:LinkButton runat="server" ID="creditCardGuide" OnClick="creditCardGuide_Click">Credit card guides</asp:LinkButton>--%>
                                <asp:LinkButton runat="server" ID="lBtncreditCardNews" OnClick="creditCardNews_Click">Credit card news</asp:LinkButton>
                                <%--<a  href="#" id="hrefCreditCardNews" runat="server" onclick="Click_CreditCardNews">Credit card news</a>--%>
                            </div>
                        </div>
                    </div>
                    <div class="clearfix"></div>
                </div>
            </section>
        </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>

