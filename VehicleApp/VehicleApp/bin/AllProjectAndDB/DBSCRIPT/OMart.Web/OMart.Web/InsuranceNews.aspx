<%@ Page Title="" Language="C#" MasterPageFile="~/OiiOMasterPage.master" AutoEventWireup="true" CodeBehind="InsuranceNews.aspx.cs" Inherits="InsuranceNews" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section>
        <div class="container-fluid bannerWrp">
            <nav role="navigation" class="navbar navbar-inverse oiioMainMenu menuInsurance">
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
                                <a href="Index.aspx">Home</a>
                            </li>
                           
                            <li class="dropdown oiioBrand">
                                <a class="dropdown-toggle" data-toggle="dropdown" href="Shopping.aspx">Energy</a>
                                <ul class="dropdown-menu">
                                     <li><a href="#">Compare gas and electricity</a></li>
                                    <li><a href="#">Compare electricitys</a></li>
                                    <li><a href="#">Compare gas</a></li>
                                    <li><a href="#">Solar power</a></li>
                                    <li><a href="#">Business energy</a></li>
                                    <li><a href="#">Energy price changes</a></li>
                                    <li><a href="#">Prepayment meters</a></li>
                                </ul>
                            </li>
                             <li class="dropdown oiioBrand">
                                <a class="  dropdown-toggle" data-toggle="dropdown" href="Money.aspx">Money</a>
                                <ul class="dropdown-menu">
                                     <li><a href="CurrentAccount.aspx">Current accounts</a></li>
                                    <li><a href="#">Cradit cards</a></li>
                                    <li><a href="Money.aspx">Loans</a></li>
                                    <li><a href="Mortgages.aspx">Mortgages</a></li>
                                    <li><a href="BankingNews.aspx">Banking news</a></li>
                                </ul>
                            </li>
                            <li class="dropdown oiioBrand">
                                <a class="dropdown-toggle" data-toggle="dropdown" href="Travel.aspx">Travel</a>
                                <ul class="dropdown-menu">
                                     
                                    <li><a href="#">Holidays</a></li>
                                     <li><a href="#">Flights</a></li>
                                     <li><a href="#">Hotels</a></li>
                                     <li><a href="#">Travel Insurance</a></li>
                                     <li><a href="#">Travel Extras</a></li>
                                    
                                </ul>
                            </li>
                           
                            <li class="dropdown oiioBrand">
                                <a class=" active dropdown-toggle" data-toggle="dropdown" href="InsuranceNews.aspx">Insurance</a>
                                <ul class="dropdown-menu">
                                     
                                   <li><a href="#">Car insurance</a></li>
                                    <li><a href="#">Motorbike insurance</a></li>
                                    <li><a href="#">Travel insurance</a></li>
                                    <li><a href="#">Life insurance</a></li>
                                    <li><a href="#">Home insurance</a></li>
                                    <li><a href="#">Business insurance</a></li>
                                </ul>
                            </li>
                            
                            <li class="dropdown oiioBrand">
                                <a class=" dropdown-toggle" data-toggle="dropdown" href="Shopping.aspx">Shopping</a>
                                <ul class="dropdown-menu">
                                     <li><a href="#">Health & beauty</a></li>
                                                <li><a href="#">Office supplies</a></li>
                                                <li><a href="#">Cameras</a></li>
                                                <li><a href="#">Televisions</a></li>
                                                <li><a href="#">Computers</a></li>
                                                <li><a href="#">Fashion</a></li>
                                                <li><a href="#">Furniture</a></li>

                                </ul>
                            </li>
                             <li class="dropdown oiioBrand">
                                <a class="dropdown-toggle" data-toggle="dropdown" href="MobilePhones.aspx">Mobile Phones </a>
                                <ul class="dropdown-menu">
                                    <li><a href="#">Mobile phone deals</a></li>
                                    <li><a href="#">SIM only deals</a></li>
                                    <li><a href="#">iPhone deals</a></li>
                                    <li><a href="#">iPad deals</a></li>
                                    <li><a href="#">Pay as you go phones</a></li>
                                    <li><a href="#">Mobile news</a></li>

                                </ul>
                            </li>
                             <li class="dropdown oiioBrand">
                                <a class="dropdown-toggle" data-toggle="dropdown" href="Broadband.aspx">Broadband</a>
                                <ul class="dropdown-menu">
                                   <li><a href="#">Broadband deals</a></li>
                                    <li><a href="#">Mobile broadband</a></li>
                                    <li><a href="#">Broadband packages</a></li>
                                    <li><a href="#">Broadband and tv</a></li>
                                    <li><a href="#">Broadband and phone</a></li>
                                    <li><a href="#">Broadband, tv and phone</a></li>

                                </ul>
                            </li>

                             <li class="dropdown oiioBrand">
                                <a class="dropdown-toggle" data-toggle="dropdown" href="Vouchers.aspx">Vouchers</a>
                                <ul class="dropdown-menu">
                                    <li><a href="#">content comming soon</a></li>

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
            </nav>






            <div class="carousel fade-carousel slide oiioFadeBanner oiioInsBanner BroadBandBanner" data-ride="carousel" data-interval="4000" id="bs-carousel">
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

                                <p><a class="bantxtTitel" href="#">Car insurance</a><span class="glyphicon glyphicon-chevron-right oioCherRight"></span></p>
                                <h4>Our service is simple and speedy - compare <span class="text-danger">car insurance </span>in a few minutes.</h4>
                                <div class="row">
                                    <div class="col-sm-4">
                                        <ul class="insBannerLink">
                                            <li><a href="#">The cheapest cars to insure <span class="glyphicon glyphicon-chevron-right oioCherRight2"></span></a></li>
                                            <li><a href="#">Car insurance for young drivers <span class="glyphicon glyphicon-chevron-right oioCherRight2"></span></a></li>
                                            <li><a href="#">Car insurance for women <span class="glyphicon glyphicon-chevron-right oioCherRight2"></span></a></li>

                                        </ul>
                                        <p><a class="btn btn-primary " href="#">Contact Us</a></p>
                                    </div>
                                </div>

                                <div class="hero2">
                                    <img class="img-responsive" src="Images/banner/carImg.png" alt="img" />
                                </div>

                            </div>
                        </div>
                    </div>
                    <div class="item slides">
                        <div class="slideinsur2"></div>
                        <div class="insBannerCntWrp">
                            <div class="insBannerCnt">

                                <p><a class="bantxtTitel" href="#">Car insurance</a><span class="glyphicon glyphicon-chevron-right oioCherRight"></span></p>
                                <h4>Our service is simple and speedy - compare <span class="text-danger">car insurance </span>in a few minutes.</h4>
                                <div class="row">
                                    <div class="col-sm-4">
                                        <ul class="insBannerLink">
                                            <li><a href="#">The cheapest cars to insure <span class="glyphicon glyphicon-chevron-right oioCherRight2"></span></a></li>
                                            <li><a href="#">Car insurance for young drivers <span class="glyphicon glyphicon-chevron-right oioCherRight2"></span></a></li>
                                            <li><a href="#">Car insurance for women <span class="glyphicon glyphicon-chevron-right oioCherRight2"></span></a></li>

                                        </ul>
                                        <p><a class="btn btn-primary " href="#">Contact Us</a></p>
                                    </div>
                                </div>

                                <div class="hero2">
                                    <img class="img-responsive" src="Images/banner/carImg2.png" alt="img" />
                                </div>

                            </div>
                        </div>
                    </div>
                    <div class="item slides">
                        <div class="slideinsur3"></div>
                        <div class="insBannerCntWrp">
                            <div class="insBannerCnt">

                                <p><a class="bantxtTitel" href="#">Car insurance</a><span class="glyphicon glyphicon-chevron-right oioCherRight"></span></p>
                                <h4>Our service is simple and speedy - compare <span class="text-danger">car insurance </span>in a few minutes.</h4>
                                <div class="row">
                                </div>

                                <div class="hero2">
                                    <img class="img-responsive" src="Images/banner/carImg.png" alt="img" />
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </section>
    <section>
        <div class="container insServ">
            <div class="row">
                <div class="servBoxWrp insServInner commBoxTitel">

                    <div class="row">

                        <div class="col-sm-3 col-md-3 col-lg-3">
                            <div class="productBox2Wrp">
                                <div class="productBox2">
                                    <a href="#">
                                        <div class="productBoxInner2">
                                            <h4>Car insurance</h4>
                                            <p>
                                                Our service is simple and
                                                <br />
                                                speedy
                                            </p>
                                            <img class="img-responsive" src="Images/products/10.jpg" alt="img" />
                                        </div>
                                    </a>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-3 col-md-3 col-lg-3">
                            <div class="productBox2Wrp">
                                <div class="productBox2">
                                    <a href="#">
                                        <div class="productBoxInner2">
                                            <h4>Travel insurance</h4>
                                            <p>
                                                Find out which service could be best 
for you
                                            </p>
                                            <img class="img-responsive" src="Images/products/11.jpg" alt="img" />
                                        </div>
                                    </a>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-3 col-md-3 col-lg-3">
                            <div class="productBox2Wrp">
                                <div class="productBox2">
                                    <a href="#">
                                        <div class="productBoxInner2">
                                            <h4>Life insurance</h4>
                                            <p>All the information you need to find the phone for you</p>
                                            <img class="img-responsive" src="Images/products/12.jpg" alt="img" />
                                        </div>
                                    </a>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-3 col-md-3 col-lg-3">
                            <div class="productBox2Wrp">
                                <div class="productBox2">
                                    <a href="#">
                                        <div class="productBoxInner2">
                                            <h4>Business insurance</h4>
                                            <p>Simple straight talking advice to help you manage your money.</p>
                                            <img class="img-responsive" src="Images/products/13.jpg" alt="img" />
                                        </div>
                                    </a>
                                </div>
                            </div>
                        </div>
                    </div>
                   
                    <div class="clearfix"></div>
                </div>
            </div>
            <div class="row">
                <div class="servBoxWrp insServInner insGuide commBoxTitel2">
                    <div class="row">
                        <div class="col-sm-12">
                            <h3>Insurance guides <span class="pull-right"><a href="#" class="btn btn-primary viewAll">View all</a></span></h3>
                        </div>
                    </div>
                    <div class="row">

                        
                        <div class="col-sm-4 col-md-4 col-lg-4">
                            <div class="productBox2Wrp">
                                <div class="productBox2">
                                    

                                        <img class="img-responsive" src="Images/products/14.jpg" alt="img" />
                                        <h5>Car insurance guides</h5>
                                        
                                    <p>
                                            Read our car insurance advice guides for the facts <br />
on why you need car insurance, the types of cover <br />
available, and tips on how to make a claim.
                                        </p>


                                    <a class="btn btn-primary btnReadMore" href="#">Read More</a>
                            </div>
                        </div>
                       </div>
                        <div class="col-sm-4 col-md-4 col-lg-4">
                            <div class="productBox2Wrp">
                                <div class="productBox2">
                                    

                                        <img class="img-responsive" src="Images/products/15.jpg" alt="img" />
                                        <h5>Home insurance guides</h5>
                                        <p>
                                            Read our car insurance advice guides for the facts<br />
on why you need car insurance, the types of cover<br />
available, and tips on how to make a claim.
                                        </p>


                                    <a class="btn btn-primary btnReadMore" href="#">Read More</a>
                            </div>
                        </div>
                       </div>
                        <div class="col-sm-4 col-md-4 col-lg-4">
                            <div class="productBox2Wrp">
                                <div class="productBox2">
                                    

                                        <img class="img-responsive" src="Images/products/16.jpg" alt="img" />
                                        <h5>Home insurance guides</h5>
                                        <p>
                                            Read our car insurance advice guides for the facts<br />
on why you need car insurance, the types of cover<br />
available, and tips on how to make a claim.
                                        </p>


                                    <a class="btn btn-primary btnReadMore" href="#">Read More</a>
                            </div>
                        </div>
                       </div>
                    </div>
                    <div class="clearfix"></div>
                </div>
            </div>
            <div class="row">
                <div class="servBoxWrp insServInner insGuide commBoxTitel2">
                    <div class="row">
                        <div class="col-sm-12">
                            <h3>Insurance news <span class="pull-right"><a href="#" class="btn btn-primary viewAll">View all</a></span></h3>
                        </div>
                    </div>
                    <div class="row">

                        
                        <div class="col-sm-3 col-md-3 col-lg-3">
                            <div class="productBox2Wrp">
                                <div class="productBox2">
                                    

                                        <img class="img-responsive" src="Images/products/17.jpg" alt="img" />
                                       <div class="productCnt">
                                           <h6><span class="productCntHead pull-left">Car insurance </span><span class="postDate pull-right">10 Mar 2015
</span></h6>
                                           <p class="productCntDesc">Motorists in favour of ‘bad 
driver’ warnings</p>

                                       </div>


                                    <a class="btn btn-primary btnReadMore2" href="#">More Car Insurance <span class="glyphicon glyphicon-chevron-right oioCherRight2"></span></a>
                            </div>
                        </div>
                       </div>
                        <div class="col-sm-3 col-md-3 col-lg-3">
                            <div class="productBox2Wrp">
                                <div class="productBox2">
                                    

                                        <img class="img-responsive" src="Images/products/18.jpg" alt="img" />
                                       <div class="productCnt">
                                           <h6><span class="productCntHead pull-left">Car insurance </span><span class="postDate pull-right">10 Mar 2015
</span></h6>
                                           <p class="productCntDesc">Half a million motorists 
caught using mobile 
phones at the wheel</p>

                                       </div>


                                    <a class="btn btn-primary btnReadMore2" href="#">More Car Insurance <span class="glyphicon glyphicon-chevron-right oioCherRight2"></span></a>
                            </div>
                        </div>
                       </div>
                        <div class="col-sm-3 col-md-3 col-lg-3">
                            <div class="productBox2Wrp">
                                <div class="productBox2">
                                    

                                        <img class="img-responsive" src="Images/products/19.jpg" alt="img" />
                                       <div class="productCnt">
                                           <h6><span class="productCntHead pull-left">Car insurance </span><span class="postDate pull-right">10 Mar 2015
</span></h6>
                                           <p class="productCntDesc">Research finds cars are 
rarely stored in garages</p>

                                       </div>


                                    <a class="btn btn-primary btnReadMore2" href="#">More Car Insurance <span class="glyphicon glyphicon-chevron-right oioCherRight2"></span></a>
                            </div>
                        </div>
                       </div>
                        <div class="col-sm-3 col-md-3 col-lg-3">
                            <div class="productBox2Wrp">
                                <div class="productBox2">
                                    

                                        <img class="img-responsive" src="Images/products/20.jpg" alt="img" />
                                       <div class="productCnt">
                                           <h6><span class="productCntHead pull-left">Car insurance </span><span class="postDate pull-right">10 Mar 2015
</span></h6>
                                           <p class="productCntDesc">Women more likely to 
speed but less likely to 
crash</p>

                                       </div>


                                    <a class="btn btn-primary btnReadMore2" href="#">More Car Insurance <span class="glyphicon glyphicon-chevron-right oioCherRight2"></span></a>
                            </div>
                        </div>
                       </div>
                        
                        
                    </div>
                    <div class="clearfix"></div>
                </div>
            </div>
        </div>
    </section>

</asp:Content>

