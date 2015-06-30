<%@ Page Title="CurrentAccount" Language="C#" MasterPageFile="~/OiiOMasterPage.master" AutoEventWireup="true" CodeBehind="CurrentAccount.aspx.cs" Inherits="CurrentAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section>
        <div class="container-fluid bannerWrp mortagesPage">
            

            <div class="carousel fade-carousel slide oiioFadeBanner BroadBandBanner loanBannerpart" data-ride="carousel" data-interval="4000" id="bs-carousel">
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
                                            <h3>Current Accounts</h3>
                                            <p>Compare our top current account deals to see if you could earn extra cash in credit interest and cashback, or save hundreds of pounds in overdraft charges.</p>
                                            <p><a href="#">Want to know more? Read our expert guides </a></p>
                                        </div>
                                    </div>
                                    <div class="col-sm-6">
                                    </div>
                                </div>

                                <div class="hero2">

                                    <img class="img-responsive" src="Images/banner/bannner15.png" alt="img" />
                                </div>

                            </div>
                        </div>
                    </div>
                    <div class="item slides">
                        <div class="slideloan2"></div>
                        <div class="insBannerCntWrp">
                            <div class="insBannerCnt">


                                <div class="row">

                                    <div class="col-sm-6">
                                        <div class="bannerMortagesCnt">
                                            <h3>Current Accounts</h3>
                                            <p>Compare our top current account deals to see if you could earn extra cash in credit interest and cashback, or save hundreds of pounds in overdraft charges.</p>
                                            <p><a href="#">Want to know more? Read our expert guides </a></p>
                                        </div>
                                    </div>
                                    <div class="col-sm-6">
                                    </div>
                                </div>

                                <div class="hero2">

                                    <img class="img-responsive" src="Images/banner/bannner15.png" alt="img" />
                                </div>

                            </div>
                        </div>
                    </div>
                    <div class="item slides">
                        <div class="slideloan3"></div>
                        <div class="insBannerCntWrp">
                            <div class="insBannerCnt">


                                <div class="row">

                                    <div class="col-sm-6">
                                        <div class="bannerMortagesCnt">
                                            <h3>Current Accounts</h3>
                                            <p>Compare our top current account deals to see if you could earn extra cash in credit interest and cashback, or save hundreds of pounds in overdraft charges.</p>
                                            <p><a href="#">Want to know more? Read our expert guides </a></p>
                                        </div>
                                    </div>
                                    <div class="col-sm-6">
                                    </div>
                                </div>

                                <div class="hero2">

                                    <img class="img-responsive" src="Images/banner/bannner15.png" alt="img" />
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </section>
    <section>
        <div class="descpageMenu">
            <div class="container">
                <div class="row">
                    <nav role="navigation" class="navbar navbar-inverse oiioMainMenu">
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
                                        <a class="active" href="Index.aspx">Most Popular </a>
                                    </li>
                                    <li>
                                        <a href="#">Packaged</a>
                                    </li>
                                    <li>
                                        <a href="#">Standard</a>
                                    </li>
                                    <li>
                                        <a href="#">High interest </a>
                                    </li>
                                    <li>
                                        <a href="#">Cashback</a>
                                    </li>
                                    <li>
                                        <a href="#">Bad credit  </a>
                                    </li>
                                    <li>
                                        <a href="#">International</a>
                                    </li>

                                </ul>
                            </div>
                        </div>
                    </nav>
                </div>

            </div>
        </div>
        <div class="container descriptionPage">



            <div class="row">




                <table class="table tbLoan tbLoanAccount" id="task-table">
                    <thead>
                        <tr>
                            <th>Most Popular </th>
                            <th></th>

                            <th>Overdraft rate
 (EAR)</th>
                            <th>Interest rate 
(AER)</th>
                            <th>Account fee</th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>
                                <div class="productDescImg">
                                    <img src="Images/products/52.jpg" width="168px" height="78px" alt="img" />
                                </div>
                            </td>
                            <td>
                                <div class="productDescription">
                                    <h4>M&S Monthly Saver</h4>
                                    <ul>
                                        <li><a href="#">Access to a 6% AER for 12 months</a></li>
                                        <li><a href="#">£500 overdraft at account opening (first £100 interest free)</a></li>
                                        <li><a href="#">Earn 1 point for every £1 spent in M&S</a></li>
                                        <li><a href="#">£100 M&S Gift card when you switch</a></li>
                                    </ul>
                                    <p><a class="moreInformation" href="#">More Info</a></p>
                                </div>

                            </td>
                            <td>
                                <div class="apr">
                                    <h4>3.9% arp</h4>
                                    <p>Representative</p>
                                </div>
                            </td>
                            <td>
                                <div class="ttlPay">
                                    <h4>6.0%
AER (variable)</h4>
                                </div>
                            </td>
                            <td>
                                <div class="repayble">
                                    <label>None</label>
                                </div>
                            </td>
                            <td>
                                <div class="applyBox">
                                    <a href="#" class="btn btn-danger">Apply <span class="glyphicon glyphicon-chevron-right oioCherRight2"></span></a>
                                </div>
                            </td>
                        </tr>


                        <tr>
                            <td>
                                <div class="productDescImg">
                                    <img src="Images/products/108.jpg" width="168px" height="78px" alt="img" />
                                    <span class="btn btn-primary awWinner">AWARD WINNER</span>
                                </div>
                            </td>
                            <td>
                                <div class="productDescription">
                                    <h4>Nationwide FlexDirect</h4>
                                    <ul>
                                        <li><a href="#">5% interest on up to £2,500</a></li>
                                        <li><a href="#">12 month fee-free overdraft</a></li>
                                        <li><a href="#">Access to exclusive customer offers</a></li>
                                        <li><a href="#">Telephone banking and free text alerts</a></li>
                                    </ul>
                                    <p><a class="moreInformation" href="#">More Info</a></p>
                                </div>

                            </td>
                            <td>
                                <div class="apr">
                                    <h4>3.9% arp</h4>
                                    <p>Representative</p>
                                </div>
                            </td>
                            <td>
                                <div class="ttlPay">
                                    <h4>£7,951.32</h4>
                                </div>
                            </td>
                            <td>
                                <div class="repayble">
                                    <label>None</label>
                                </div>
                            </td>
                            <td>
                                <div class="applyBox">
                                    <a href="#" class="btn btn-danger">Apply <span class="glyphicon glyphicon-chevron-right oioCherRight2"></span></a>
                                </div>
                            </td>
                        </tr>

                        <tr>
                            <td>
                                <div class="productDescImg">
                                    <img src="Images/products/52.jpg" width="168px" height="78px" alt="img" />
                                </div>
                            </td>
                            <td>
                                <div class="productDescription">
                                    <h4>M&S Monthly Saver</h4>
                                    <ul>
                                        <li><a href="#">Access to a 6% AER for 12 months</a></li>
                                        <li><a href="#">£500 overdraft at account opening (first £100 interest free)</a></li>
                                        <li><a href="#">Earn 1 point for every £1 spent in M&S</a></li>
                                        <li><a href="#">£100 M&S Gift card when you switch</a></li>
                                    </ul>
                                    <p><a class="moreInformation" href="#">More Info</a></p>
                                </div>

                            </td>
                            <td>
                                <div class="apr">
                                    <h4>3.9% arp</h4>
                                    <p>Representative</p>
                                </div>
                            </td>
                            <td>
                                <div class="ttlPay">
                                    <h4>6.0%
AER (variable)</h4>
                                </div>
                            </td>
                            <td>
                                <div class="repayble">
                                    <label>None</label>
                                </div>
                            </td>
                            <td>
                                <div class="applyBox">
                                    <a href="#" class="btn btn-danger">Apply <span class="glyphicon glyphicon-chevron-right oioCherRight2"></span></a>
                                </div>
                            </td>
                        </tr>


                        <tr>
                            <td>
                                <div class="productDescImg">
                                    <img src="Images/products/108.jpg" width="168px" height="78px" alt="img" />
                                    <span class="btn btn-primary awWinner">AWARD WINNER</span>
                                </div>
                            </td>
                            <td>
                                <div class="productDescription">
                                    <h4>Nationwide FlexDirect</h4>
                                    <ul>
                                        <li><a href="#">5% interest on up to £2,500</a></li>
                                        <li><a href="#">12 month fee-free overdraft</a></li>
                                        <li><a href="#">Access to exclusive customer offers</a></li>
                                        <li><a href="#">Telephone banking and free text alerts</a></li>
                                    </ul>
                                    <p><a class="moreInformation" href="#">More Info</a></p>
                                </div>

                            </td>
                            <td>
                                <div class="apr">
                                    <h4>3.9% arp</h4>
                                    <p>Representative</p>
                                </div>
                            </td>
                            <td>
                                <div class="ttlPay">
                                    <h4>£7,951.32</h4>
                                </div>
                            </td>
                            <td>
                                <div class="repayble">
                                    <label>None</label>
                                </div>
                            </td>
                            <td>
                                <div class="applyBox">
                                    <a href="#" class="btn btn-danger">Apply <span class="glyphicon glyphicon-chevron-right oioCherRight2"></span></a>
                                </div>
                            </td>
                        </tr>

                        <tr>
                            <td>
                                <div class="productDescImg">
                                    <img src="Images/products/52.jpg" width="168px" height="78px" alt="img" />
                                </div>
                            </td>
                            <td>
                                <div class="productDescription">
                                    <h4>M&S Monthly Saver</h4>
                                    <ul>
                                        <li><a href="#">Access to a 6% AER for 12 months</a></li>
                                        <li><a href="#">£500 overdraft at account opening (first £100 interest free)</a></li>
                                        <li><a href="#">Earn 1 point for every £1 spent in M&S</a></li>
                                        <li><a href="#">£100 M&S Gift card when you switch</a></li>
                                    </ul>
                                    <p><a class="moreInformation" href="#">More Info</a></p>
                                </div>

                            </td>
                            <td>
                                <div class="apr">
                                    <h4>3.9% arp</h4>
                                    <p>Representative</p>
                                </div>
                            </td>
                            <td>
                                <div class="ttlPay">
                                    <h4>6.0%
AER (variable)</h4>
                                </div>
                            </td>
                            <td>
                                <div class="repayble">
                                    <label>None</label>
                                </div>
                            </td>
                            <td>
                                <div class="applyBox">
                                    <a href="#" class="btn btn-danger">Apply <span class="glyphicon glyphicon-chevron-right oioCherRight2"></span></a>
                                </div>
                            </td>
                        </tr>


                        <tr>
                            <td>
                                <div class="productDescImg">
                                    <img src="Images/products/108.jpg" width="168px" height="78px" alt="img" />
                                    <span class="btn btn-primary awWinner">AWARD WINNER</span>
                                </div>
                            </td>
                            <td>
                                <div class="productDescription">
                                    <h4>Nationwide FlexDirect</h4>
                                    <ul>
                                        <li><a href="#">5% interest on up to £2,500</a></li>
                                        <li><a href="#">12 month fee-free overdraft</a></li>
                                        <li><a href="#">Access to exclusive customer offers</a></li>
                                        <li><a href="#">Telephone banking and free text alerts</a></li>
                                    </ul>
                                    <p><a class="moreInformation" href="#">More Info</a></p>
                                </div>

                            </td>
                            <td>
                                <div class="apr">
                                    <h4>3.9% arp</h4>
                                    <p>Representative</p>
                                </div>
                            </td>
                            <td>
                                <div class="ttlPay">
                                    <h4>£7,951.32</h4>
                                </div>
                            </td>
                            <td>
                                <div class="repayble">
                                    <label>None</label>
                                </div>
                            </td>
                            <td>
                                <div class="applyBox">
                                    <a href="#" class="btn btn-danger">Apply <span class="glyphicon glyphicon-chevron-right oioCherRight2"></span></a>
                                </div>
                            </td>
                        </tr>














                    </tbody>
                </table>

            </div>

        </div>
    </section>

</asp:Content>

