<%@ Page Title="" Language="C#" MasterPageFile="~/OiiOMasterPage.master" AutoEventWireup="true" CodeBehind="BankingInformation.aspx.cs" Inherits="OMart.Web.BankingInformation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
        <div class="container-fluid bannerWrp mortagesPage">
           <%-- <nav role="navigation" class="navbar navbar-inverse oiioMainMenu">
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
                    <div id="bs-example-navbar-collapse-1" class="collapse navbar-collapse">
                        <ul class="nav navbar-nav">
                            <li>
                                <a class="active" href="Index.aspx">Home</a>
                            </li>
                            <li class="dropdown oiioBrand">
                                <a class="dropdown-toggle" data-toggle="dropdown" href="#">Energy</a>
                                <ul class="dropdown-menu">
                                    <li><a href="Shopping.aspx">Compare gas and electricity</a></li>
                                    <li><a href="#">Compare electricitys</a></li>
                                    <li><a href="#">Compare gas</a></li>
                                    <li><a href="#">Solar power</a></li>
                                    <li><a href="#">Business energy</a></li>
                                    <li><a href="#">Energy price changes</a></li>
                                    <li><a href="#">Prepayment meters</a></li>
                                </ul>
                            </li>
                            <li class="dropdown oiioBrand">
                                <a class="dropdown-toggle" data-toggle="dropdown" href="#">Money</a>
                                <ul class="dropdown-menu">
                                    <li><a href="CurrentAccount.aspx">Current accounts</a></li>
                                    <li><a href="Money.aspx">Cradit cards</a></li>
                                    <li><a href="Money.aspx">Loans</a></li>
                                    <li><a href="Mortgages.aspx">Mortgages</a></li>
                                    <li><a href="BankingNews.aspx">Banking news</a></li>
                                </ul>
                            </li>
                            <li class="dropdown oiioBrand">
                                <a class="dropdown-toggle" data-toggle="dropdown" href="#">Travel</a>
                                <ul class="dropdown-menu">
                                    <li><a href="Travel.aspx">Holidays</a></li>
                                    <li><a href="#">Flights</a></li>
                                    <li><a href="#">Hotels</a></li>
                                    <li><a href="#">Travel Insurance</a></li>
                                    <li><a href="#">Travel Extras</a></li>

                                </ul>
                            </li>

                            <li class="dropdown oiioBrand">
                                <a class="dropdown-toggle" data-toggle="dropdown" href="#">Insurance</a>
                                <ul class="dropdown-menu">
                                    <li><a href="InsuranceNews.aspx">Car insurance</a></li>
                                    <li><a href="#">Motorbike insurance</a></li>
                                    <li><a href="#">Travel insurance</a></li>
                                    <li><a href="#">Life insurance</a></li>
                                    <li><a href="#">Home insurance</a></li>
                                    <li><a href="#">Business insurance</a></li>
                                </ul>
                            </li>
                            <li class="dropdown oiioBrand">
                                <a class=" dropdown-toggle" data-toggle="dropdown" href="#">Shopping</a>
                                <ul class="dropdown-menu">
                                    <li><a href="Shopping.aspx">Health & beauty</a></li>
                                    <li><a href="#">Office supplies</a></li>
                                    <li><a href="#">Cameras</a></li>
                                    <li><a href="#">Televisions</a></li>
                                    <li><a href="#">Computers</a></li>
                                    <li><a href="#">Fashion</a></li>
                                    <li><a href="#">Furniture</a></li>
                                </ul>
                            </li>
                            <li class="dropdown oiioBrand">
                                <a class="dropdown-toggle" data-toggle="dropdown" href="">Mobile Phones </a>
                                <ul class="dropdown-menu">
                                    <li><a href="MobilePhones.aspx">Mobile phone deals</a></li>
                                    <li><a href="#">SIM only deals</a></li>
                                    <li><a href="#">iPhone deals</a></li>
                                    <li><a href="#">iPad deals</a></li>
                                    <li><a href="#">Pay as you go phones</a></li>
                                    <li><a href="#">Mobile news</a></li>
                                </ul>
                            </li>
                            <li class="dropdown oiioBrand">
                                <a class="dropdown-toggle" data-toggle="dropdown" href="">Broadband</a>
                                <ul class="dropdown-menu">
                                    <li><a href="Broadband.aspx">Broadband deals</a></li>
                                    <li><a href="#">Mobile broadband</a></li>
                                    <li><a href="#">Broadband packages</a></li>
                                    <li><a href="#">Broadband and tv</a></li>
                                    <li><a href="#">Broadband and phone</a></li>
                                    <li><a href="#">Broadband, tv and phone</a></li>
                                </ul>
                            </li>
                            <li class="dropdown oiioBrand">
                                <a class="dropdown-toggle" data-toggle="dropdown" href="#">Vouchers</a>
                                <ul class="dropdown-menu">
                                    <li><a href="Vouchers.aspx">Vouchers</a></li>
                                </ul>
                            </li>
                            <li>
                                <a href="News.aspx">News & Community</a>
                            </li>

                        </ul>
                    </div>
                    <!-- /.navbar-collapse -->
                </div>
                <!-- /.container -->
            </nav>--%>
            <div class="carousel fade-carousel slide oiioFadeBanner oiioInsBanner " data-ride="carousel" data-interval="4000" id="bs-carousel">
               
                <div class="carousel-inner">
                    <div class="item slides active">
                        <div class="slideinsur1">
                        </div>
                        <div class="insBannerCntWrp">
                            <div class="insBannerCnt">


                                <div class="row">

                                    <div class="col-sm-6">
                                        <div class="bannerMortagesCnt">
                                            <h3>Loan</h3>
                                            <p>
                                                <asp:Label ID="lblLoanDes" runat="server" Text=' <%# Eval("LoanDescription") %>'></asp:Label>
                                            </p>
                                        </div>
                                    </div>
                                    <div class="col-xs-5 col-sm-5 col-md-5 col-lg-5 col-sm-offset-1 col-md-offset-1 col-lg-offset-1">
                                        <div class="promotionBox">
                                            <h4>Promotion</h4>

                                        </div>

                                        <div class="loanapplyBox">

                                            <div class="row">
                                                <div class="col-xs-8">
                                                    <h2>
                                                        <asp:Repeater ID="rpLoanName" runat="server" OnItemDataBound="rpLoanName_OnItemDataBound">
                                                            <ItemTemplate>
                                                                <a runat="server" href='<%#"LoanDescriptionDetails?ID="+Eval("IID") %>'>
                                                                    <asp:Literal ID="lblLoanTypeName" runat="server" Text=' <%# Eval("LoanTypeName") %>'></asp:Literal>
                                                                </a>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </h2>
                                                    <ul>
                                                        <asp:Repeater ID="rpLoanFeature" runat="server" OnItemDataBound="rpLoanFeature_OnItemDataBound">
                                                            <ItemTemplate>
                                                                <li>
                                                                    <span class="glyphicon glyphicon-ok"></span></span>
                                                    <asp:Literal ID="ltlLoanFeature" runat="server" Text=' <%# Eval("LoanFeature") %>'></asp:Literal>
                                                                </li>
                                                            </ItemTemplate>
                                                        </asp:Repeater>

                                                    </ul>
                                                </div>
                                                <div class="col-xs-4">
                                                    <h5>LENDING</h5>
                                                    <h6>Works</h6>
                                                    <asp:LinkButton ID="LinkButtonLoanApply" runat="server" CssClass="btn btn-primary applyBtn">Apply</asp:LinkButton>
                                                </div>
                                            </div>
                                            <div class="clearfix"></div>
                                        </div>
                                    </div>

                                </div>




                            </div>
                        </div>
                    </div>
                    <div class="item slides ">
                        <div class="slideinsur1">
                        </div>
                        <div class="insBannerCntWrp">
                            <div class="insBannerCnt">


                                <div class="row">

                                    <div class="col-sm-6">
                                        <div class="bannerMortagesCnt">
                                            <h3>Credit Card</h3>
                                            <p>
                                                <asp:Label ID="lblCardDes" runat="server"></asp:Label>
                                            </p>
                                        </div>
                                    </div>
                                    <div class="col-xs-5 col-sm-5 col-md-5 col-lg-5 col-sm-offset-1 col-md-offset-1 col-lg-offset-1">
                                        <div class="promotionBox">
                                            <h4>Promotion</h4>

                                        </div>

                                        <div class="loanapplyBox">

                                            <div class="row">
                                                <div class="col-xs-8">
                                                    <h2>
                                                        <asp:Repeater ID="rpCardName" runat="server" OnItemDataBound="rpCardName_OnItemDataBound">
                                                            <ItemTemplate>
                                                                <a runat="server" href='<%#"CardDetailPage?ID="+Eval("IID") %>'>
                                                                    <asp:Literal ID="lblCardTypeName" runat="server" Text=' <%# Eval("CardName") %>'></asp:Literal>
                                                                </a>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </h2>
                                                    <ul>

                                                        <asp:Repeater ID="rpCardFeature" runat="server" OnItemDataBound="rpCardFeature_OnItemDataBound">
                                                            <ItemTemplate>
                                                                <li>
                                                                    <span class="glyphicon glyphicon-ok">
                                                                        <asp:Literal ID="ltlCardFeature" runat="server" Text=' <%# Eval("cardFeature") %>'></asp:Literal>
                                                                </li>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </ul>
                                                </div>
                                                <div class="col-xs-4">
                                                    <h5>LENDING</h5>
                                                    <h6>Works</h6>
                                                    <asp:LinkButton ID="lnkbtnCardApply" runat="server" CssClass="btn btn-primary applyBtn">Apply</asp:LinkButton>
                                                </div>
                                            </div>
                                            <div class="clearfix"></div>
                                        </div>
                                    </div>

                                </div>




                            </div>
                        </div>
                    </div>
                    <div class="item slides ">
                        <div class="slideinsur1">
                        </div>
                        <div class="insBannerCntWrp">
                            <div class="insBannerCnt">


                                <div class="row">

                                    <div class="col-sm-6">
                                        <div class="bannerMortagesCnt">
                                            <h3>Mortgage</h3>
                                            <p>
                                                <asp:Label ID="lblMortgage" runat="server"></asp:Label>
                                            </p>
                                        </div>
                                    </div>
                                    <div class="col-xs-5 col-sm-5 col-md-5 col-lg-5 col-sm-offset-1 col-md-offset-1 col-lg-offset-1">
                                        <div class="promotionBox">
                                            <h4>Promotion</h4>

                                        </div>

                                        <div class="loanapplyBox">

                                            <div class="row">
                                                <div class="col-xs-8">
                                                    <h2>
                                                        <asp:Repeater ID="rpMortgageName" runat="server" OnItemDataBound="rpMortgageName_OnItemDataBound">
                                                            <ItemTemplate>
                                                                <a runat="server" href='<%#"MortgageDetailPage?ID="+Eval("IID") %>'>
                                                                    <asp:Literal ID="lblMortTypeName" runat="server" Text=' <%# Eval("MortgageTypeName") %>'></asp:Literal>
                                                                </a>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </h2>
                                                    <ul>

                                                        <asp:Repeater ID="rpMortgage" runat="server" OnItemDataBound="rpMortgage_OnItemDataBound">
                                                            <ItemTemplate>
                                                                <li>
                                                                    <span class="glyphicon glyphicon-ok">
                                                                        <asp:Label ID="lblMortgageApr" runat="server" Text="APR in %::"></asp:Label>
                                                                        <asp:Literal ID="ltlmortgageAPR" runat="server" Text=' <%# Eval("mortgageAPR") %>'></asp:Literal>
                                                                </li>
                                                                <li>
                                                                    <span class="glyphicon glyphicon-ok">
                                                                        <asp:Label ID="Label1" runat="server" Text="Fee/Charge::"></asp:Label>
                                                                        <asp:Literal ID="ltlmortgageFeeCharge" runat="server" Text=' <%# Eval("mortgageFeeCharge") %>'></asp:Literal>
                                                                </li>
                                                                <li>
                                                                    <span class="glyphicon glyphicon-ok">
                                                                        <asp:Label ID="Label2" runat="server" Text="Other Detail::"></asp:Label>
                                                                        <asp:Literal ID="ltlmortgageDes" runat="server" Text=' <%# Eval("mortgageDes") %>'></asp:Literal>
                                                                </li>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
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
                            <h5><span class="bbandProdHead_bg1 pull-left"></span>Credit cards<span class="bbandProdHead_bg2 pull-right"></span></h5>
                            <div class="bBrandproductCnt compLoans">
                                <ul class="insBannerLink">
                                    <a runat="server" href="~/CreditCardsDetail.aspx">
                                        <li>Compare All Cards</li>
                                    </a>
                                    <asp:Repeater ID="rpCards" runat="server" OnItemDataBound="rpCards_OnItemDataBound">
                                        <ItemTemplate>
                                            <li><a runat="server" href='<%#"CreditCardsDetail?ID="+Eval("IID") %>'>
                                                <asp:Literal ID="lbCardTypeID" runat="server" Text=' <%# Eval("CardName") %>'></asp:Literal>
                                                <span class="glyphicon glyphicon-chevron-right oioCherRight2"></span></a></li>
                                        </ItemTemplate>
                                    </asp:Repeater>
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
                                    <a runat="server" href="~/LoanInformationDisplay.aspx">
                                        <li>Compare All Loans</li>
                                    </a>
                                    <asp:Repeater ID="rpLoans" runat="server" OnItemDataBound="rpLoans_OnItemDataBound">
                                        <ItemTemplate>
                                            <li><a runat="server" href='<%#"LoanDesciptionDetails?ID="+Eval("IID") %>'>
                                                <asp:Literal ID="lblLoanTypeID" runat="server" Text=' <%# Eval("LoanTypeName") %>'></asp:Literal>
                                                <span class="glyphicon glyphicon-chevron-right oioCherRight2"></span></a></li>
                                        </ItemTemplate>
                                    </asp:Repeater>
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
                                    <a runat="server" href="~/MortgageDescription.aspx">
                                        <li>Compare All Motgages</li>
                                    </a>
                                    <asp:Repeater ID="rpMortgages" runat="server" OnItemDataBound="rpMortgages_OnItemDataBound">
                                        <ItemTemplate>
                                            <li><a runat="server" href='<%#"MortgageDetails?ID="+Eval("IID") %>'>
                                                <asp:Literal ID="lblMortgageTypeID" runat="server" Text=' <%# Eval("MortageType") %>'></asp:Literal>
                                                <span class="glyphicon glyphicon-chevron-right oioCherRight2"></span></a></li>
                                        </ItemTemplate>
                                    </asp:Repeater>
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
                        <a href="GuideLineDetails.aspx?ID=2">Banking Guides</a>
                        <a href="BankingNews.aspx">Banking news</a>
                    </div>
                </div>
            </div>
            <div class="clearfix"></div>
        </div>
        <div class="providerIem3">
            <div class="container">
                <div class="row">
                    <div class="col-md-2">
                        <a runat="server" href="CreditCardsDetail.aspx">
                            <img src="Images/products/96.png" alt="img" />

                        </a>
                    </div>
                    <div class="col-md-6">
                         <a runat="server" href="CreditCardsDetail.aspx">
                        <h4>Find the card</h4> </a>
                        <p>We've launched a new campaign calling for changes to the credit reporting system. We think credit reports should be free, fairer, and easier to understand, but to change the law we need your help.</p>
                    </div>
                    <div class="col-md-3 pull-right">
                        <a class="btn btnFindMore" href="CreditCardsDetail.aspx">Find out more</a>
                    </div>
                </div>
            </div>
            <div class="clearfix"></div>
        </div>
    </section>
</asp:Content>
