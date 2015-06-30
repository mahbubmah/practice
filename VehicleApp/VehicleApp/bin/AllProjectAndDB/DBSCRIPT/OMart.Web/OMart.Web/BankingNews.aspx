<%@ Page Title="BankingNews" Language="C#" MasterPageFile="~/OiiOMasterPage.master" AutoEventWireup="true" CodeBehind="BankingNews.aspx.cs" Inherits="BankingNews" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section>
        <div class="container-fluid bannerWrp mortagesPage">
                     <div class="carousel fade-carousel slide oiioFadeBanner oiioInsBanner " data-ride="carousel" data-interval="4000" id="bs-carousel">
                <!-- Overlay -->


                <!-- Indicators -->
                <%-- <ol class="carousel-indicators">
    <li data-target="#bs-carousel" data-slide-to="0" class="active"></li>
    <li data-target="#bs-carousel" data-slide-to="1"></li>
    <li data-target="#bs-carousel" data-slide-to="2"></li>
  </ol>--%>

                <!-- Wrapper for slides -->
                <div class="carousel-inner">
                    <div class="item slides active">
                        <div class="slideinsur1">
                        </div>
                        <div class="insBannerCntWrp">
                            <div class="insBannerCnt">


                                <div class="row">

                                    <div class="col-sm-6">
                                        <div class="bannerMortagesCnt">
                                            <h3>Banking</h3>
                                            <p>Looking for a personal loan, compare credit cards, or trying to find the best current account for you? Compare a wide range of personal finance products and find the latest rates and best deals.</p>
                                        </div>
                                    </div>
                                    <div class="col-xs-5 col-sm-5 col-md-5 col-lg-5 col-sm-offset-1 col-md-offset-1 col-lg-offset-1">
                                        <div class="promotionBox">
                                            <h4>Promotion</h4>

                                        </div>

                                        <div class="loanapplyBox">

                                            <div class="row">
                                                <div class="col-xs-8">
                                                    <h2>Lending Works Personal loan</h2>
                                                    <ul>
                                                        <li><span class="glyphicon glyphicon-ok"></span>Quick decision: funds available in 24 
hours</li>
                                                        <li><span class="glyphicon glyphicon-ok"></span>Peer-to-peer lender: borrow from other 
people
                                                        </li>
                                                        <li><span class="glyphicon glyphicon-ok"></span>Low APR and no fees for early repayment</li>
                                                    </ul>
                                                </div>
                                                <div class="col-xs-4">
                                                    <h5>LENDING</h5>
                                                    <h6>Works</h6>
                                                    <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-primary applyBtn">Apply</asp:LinkButton>
                                                </div>
                                            </div>
                                            <div class="clearfix"></div>
                                        </div>
                                    </div>

                                </div>




                            </div>
                        </div>
                    </div>
                    <div class="item slides">
                        <div class="slideinsur2"></div>
                        <div class="insBannerCntWrp">
                            <div class="insBannerCnt">


                                <div class="row">

                                    <div class="col-sm-6">
                                        <div class="bannerMortagesCnt">
                                            <h3>Banking</h3>
                                            <p>Looking for a personal loan, compare credit cards, or trying to find the best current account for you? Compare a wide range of personal finance products and find the latest rates and best deals.</p>
                                        </div>
                                    </div>
                                    <div class="col-sm-6">
                                        <h4>Promotion</h4>

                                    </div>
                                </div>

                                <div class="hero2">
                                    <div class="loanapplyBox">
                                        <a href="#">
                                            <img class="img-responsive" src="Images/Interfaces/bannerImg12.jpg" alt="img" /></a>

                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                    <div class="item slides">
                        <div class="slideinsur3"></div>
                        <div class="insBannerCntWrp">
                            <div class="insBannerCnt">


                                <div class="row">

                                    <div class="col-sm-6">
                                        <div class="bannerMortagesCnt">
                                            <h3>Banking</h3>
                                            <p>Looking for a personal loan, compare credit cards, or trying to find the best current account for you? Compare a wide range of personal finance products and find the latest rates and best deals.</p>
                                        </div>
                                    </div>
                                    <div class="col-sm-6">
                                        <h4>Promotion</h4>

                                    </div>
                                </div>

                                <div class="hero2">
                                    <div class="loanapplyBox">
                                        <a href="#">
                                            <img class="img-responsive" src="Images/Interfaces/bannerImg12.jpg" alt="img" /></a>

                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </section>
    <section>

        <div class="container brodBandServ commBoxTitelLoan mortagesPage">

            <div class="row">

                <div class="servBoxWrp insServInner insGuide commBoxTitel2">

                    <div class="col-sm-3 col-md-3 col-lg-3">
                        <div class="bBrandproductBox2Wrp">


                            <div class="img-thumbnail">
                                <img class="img-responsive" src="Images/products/97.jpg" alt="img" />
                            </div>
                            <h5><span class="bbandProdHead_bg1 pull-left"></span>Current accounts<span class="bbandProdHead_bg2 pull-right"></span></h5>
                            <div class="bBrandproductCnt compLoans">
                                <ul class="insBannerLink">
                                    <li>Compare accounts</li>
                                    <li><a href="#">High interest <span class="glyphicon glyphicon-chevron-right oioCherRight2"></span></a></li>
                                    <li><a href="#">Cashback<span class="glyphicon glyphicon-chevron-right oioCherRight2"></span></a></li>
                                    <li><a href="#">Packaged<span class="glyphicon glyphicon-chevron-right oioCherRight2"></span></a></li>

                                </ul>



                            </div>
                        </div>
                    </div>
                    <div class="col-sm-3 col-md-3 col-lg-3">
                        <div class="bBrandproductBox2Wrp">


                            <div class="img-thumbnail">
                                <img class="img-responsive" src="Images/products/98.jpg" alt="img" />
                            </div>
                            <h5><span class="bbandProdHead_bg1 pull-left"></span>Cradit cards<span class="bbandProdHead_bg2 pull-right"></span></h5>
                            <div class="bBrandproductCnt compLoans">
                                <ul class="insBannerLink">
                                    <li>Compare all cards</li>
                                    <li><a href="#">0% balance transfer<span class="glyphicon glyphicon-chevron-right oioCherRight2"></span></a></li>
                                    <li><a href="#">0% purchase cards<span class="glyphicon glyphicon-chevron-right oioCherRight2"></span></a></li>
                                    <li><a href="#">Cards for bad credit <span class="glyphicon glyphicon-chevron-right oioCherRight2"></span></a></li>

                                </ul>



                            </div>
                        </div>
                    </div>
                    <div class="col-sm-3 col-md-3 col-lg-3">
                        <div class="bBrandproductBox2Wrp">


                            <div class="img-thumbnail">
                                <img class="img-responsive" src="Images/products/99.jpg" alt="img" />
                            </div>
                            <h5><span class="bbandProdHead_bg1 pull-left"></span>Loans<span class="bbandProdHead_bg2 pull-right"></span></h5>
                            <div class="bBrandproductCnt compLoans">
                                <ul class="insBannerLink">
                                    <li>Compare loans</li>
                                    <li><a href="#">Personal loans<span class="glyphicon glyphicon-chevron-right oioCherRight2"></span></a></li>
                                    <li><a href="#">Car loans<span class="glyphicon glyphicon-chevron-right oioCherRight2"></span></a></li>
                                    <li><a href="#">Secured loans<span class="glyphicon glyphicon-chevron-right oioCherRight2"></span></a></li>

                                </ul>



                            </div>
                        </div>
                    </div>
                    <div class="col-sm-3 col-md-3 col-lg-3">
                        <div class="bBrandproductBox2Wrp">


                            <div class="img-thumbnail">
                                <img class="img-responsive" src="Images/products/100.jpg" alt="img" />
                            </div>
                            <h5><span class="bbandProdHead_bg1 pull-left"></span>Mortgages<span class="bbandProdHead_bg2 pull-right"></span></h5>
                            <div class="bBrandproductCnt compLoans">
                                <ul class="insBannerLink">
                                    <li>Compare motgages</li>
                                    <li><a href="#">Remortgage <span class="glyphicon glyphicon-chevron-right oioCherRight2"></span></a></li>
                                    <li><a href="#">First time buyer<span class="glyphicon glyphicon-chevron-right oioCherRight2"></span></a></li>
                                    <li><a href="#">Moving home<span class="glyphicon glyphicon-chevron-right oioCherRight2"></span></a></li>

                                </ul>



                            </div>
                        </div>
                    </div>

                </div>

                <div class="clearfix"></div>
            </div>
            <div class="row">
                <div class="col-sm-3 pull-right">
                    <a href="#" class="btn btn-primary viewAll pull-right ">View all</a>
                </div>
            </div>




        </div>


        <div class="providerIem2">
            <div class="container">
                <div class="row">
                    <div class="col-md-12">
                        <a href="#">Banking guides
                        </a>
                        <a href="#">Banking news</a>
                    </div>
                </div>
            </div>
            <div class="clearfix"></div>
        </div>
        <div class="providerIem3">
            <div class="container">
                <div class="row">
                    <div class="col-md-2">
                        <img src="Images/products/96.png" alt="img" />

                    </div>
                    <div class="col-md-6">

                        <h4>Find the card</h4>
                        <p>We've launched a new campaign calling for changes to the credit reporting system. We think credit reports should be free, fairer, and easier to understand, but to change the law we need your help.</p>


                    </div>
                    <div class="col-md-3 pull-right">
                        <a class="btn btnFindMore" href="#">Find out more</a>
                    </div>
                </div>
            </div>
            <div class="clearfix"></div>
        </div>
    </section>

</asp:Content>

