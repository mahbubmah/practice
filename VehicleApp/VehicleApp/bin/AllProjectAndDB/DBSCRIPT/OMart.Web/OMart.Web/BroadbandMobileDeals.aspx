﻿<%@ Page Title="" Language="C#" MasterPageFile="~/BroadbandMaster.Master" AutoEventWireup="true" CodeBehind="BroadbandMobileDeals.aspx.cs" Inherits="OMart.Web.BroadbandMobileDeals" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section>
        <div class="container-fluid bannerWrp mortagesPage">
            <div class="carousel fade-carousel slide oiioFadeBanner payasyouBanner" data-ride="carousel" data-interval="4000" id="bs-carousel">
                <!-- Overlay -->
                <!-- Indicators -->
                <br />               
                <br />
                <br />
                <!-- Wrapper for slides -->
                <div class="carousel-inner">
   
                    <div class="item slides active">
                        <div class="slide20">
                        </div>
                        <div class="container brodBandServ commBoxTitelLoan">
                            <div class="insBannerCntWrp broadBandPage"> 
                                <div class="row">
                                    <div class="col-sm-4">
                                        <div class="bannerMortagesCnt">
                                            <h3>Top 10 broandbands</h3>
                                            <h4>Top 10 Mobile Broadband Deals</h4>
                                            <p>Enter your UK postc ode to check which mobile broadband deals are available in your area:</p>

                                            <a href="#" class="btn btn-primary compareBtn ">Compare deals <span class="glyphicon glyphicon-chevron-right oioCherRight2"></span></a>


                                        </div>
                                    </div>
                                    <div class="hero2">
                                        <img class="img-responsive" src="Images/banner/0420_1.png" alt="img" />
                                    </div>
                                </div>


                            </div>
                        </div>
                    </div>
                    <div class="item slides">
                        <div class="slide21">
                        </div>
                      <div class="insBannerCntWrp">
                            <div class="insBannerCnt">


                                <div class="row">

                                    <div class="col-sm-4">
                                        <div class="bannerMortagesCnt">
                                            <h3>Top 10 broandbands</h3>
                                            <h4>Top 10 Mobile Broadband Deals</h4>
                                            <p>Enter your UK postc ode to check which mobile broadband deals are available in your area:</p>

                                            <a href="#" class="btn btn-primary compareBtn ">Compare deals <span class="glyphicon glyphicon-chevron-right oioCherRight2"></span></a>


                                        </div>
                                    </div>
                                    <div class="hero2">
                                        <img class="img-responsive" src="Images/banner/0420_1.png" alt="img" />
                                    </div>
                                </div>


                            </div>
                        </div>
                    </div>

                </div>
            </div>
            </div>
    </section>
   <br />
    <br />
    <section>
        <div class="broadBandToppage">
            <div class="container">
                <div class="row">
                    <div class="col-sm-12">
                        <h3>Your best mobile broadband deals here</h3>
                    </div>
                </div>
            </div>
        </div>
        <div class="container payasuDesc broadbandDeals">

            <asp:ObjectDataSource ID="objDataSourceBDInternetDeals" runat="server"
                EnablePaging="true"
                OnSelecting="objDataSourceBDInternetDeals_Selecting"
                TypeName="BLL.Basic.BDInternetRT"
                SelectMethod="GetAllBDInternetDealsByTypeID"
                SelectCountMethod="CountAllBDInternetDealsByTypeID"
                MaximumRowsParameterName="maxRowNumber"
                StartRowIndexParameterName="startRowIndex"></asp:ObjectDataSource>
            <div class="row">

                <table class="table payasuDescTb table-hover" id="task-table">
                    <thead>
                        <tr>
                            <th class="same_th">PROVIDER</th>
                            <th class="same_th">OFFER</th>
                            <th class="same_th">PACKAGE</th>
                            <th class="same_th">USAGE</th>
                            <th class="same_th">SPEED</th>
                            <th class="same_th">CONTRACT</th>
                            <th class="same_th">PAYMENT</th>
                            <th class="same_th">POPULARITY</th>
                        </tr>

                    </thead>

                    <asp:ListView ID="lvBroadBandMobileDeals" runat="server" DataSourceID="objDataSourceBDInternetDeals">
                        <ItemTemplate>

                            <tbody>
                                <tr>
                                    <td class="sl_th">
                                        <asp:Image ID="imgProvider" runat="server" ImageUrl='<%# Eval("PROVIDER")%>' AlternateText="img" Width="168px" Height="78px" />
                                    </td>
                                    <td class="sl_th">
                                        <asp:Image ID="imgOffer" runat="server" ImageUrl='<%# Eval("OFFER")%>' AlternateText="img" Width="168px" Height="78px" />
                                    </td>
                                    <td class="same_td same_td_1">
                                        <h4><%# Eval("PACKAGE") %></h4>
                                    </td>
                                    <td class="same_td same_td_2">
                                        <h4><%# Eval("USAGE") %></h4>
                                    </td>
                                    <td class="same_td same_td_3">
                                        <h4><%# Eval("SPEED") %></h4>

                                    </td>
                                    <td class="same_td same_td_4">
                                        <h4><%# Eval("CONTRACT") %></h4>


                                    </td>
                                    <td class="same_td same_td_5 applyBox">

                                        <h4><%# Eval("PAYMENT") %></h4>
                                        <p><%# Eval("PAYMENTSCHEDULE") %></p>
                                        <a href='<%# Eval("REDIRECTURL") %>' class="btn btn-infor">More info<span class="glyphicon glyphicon-chevron-down oioCherRight3"></span></a>

                                    </td>
                                    <td>
                                        <div class="same_td same_td_6 applyBox">
                                            <a href='<%# Eval("REDIRECTURL") %>' class="btn btn-sucess1">Go to site<span class="glyphicon glyphicon-chevron-right oioCherRight3"></span></a>

                                        </div>
                                    </td>
                                </tr>

                            </tbody>
                        </ItemTemplate>

                        <EmptyDataTemplate>
                            <table>
                                <tr>
                                    <td>Information is empty ... 
                                    </td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>

                    </asp:ListView>
                </table>
                <asp:DataPager ID="dataPagerBroadBandMobileDeals" runat="server" PagedControlID="lvBroadBandMobileDeals"
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
            <%--            <div class="row providerIem0403_A providerIem0403_B">
                <div class="col-md-12">

                    <a href="#">Load next 10 results <span class="glyphicon glyphicon-plus oioCherRight2"></span></a>
                </div>
            </div>--%>
        </div>
    </section>

</asp:Content>
