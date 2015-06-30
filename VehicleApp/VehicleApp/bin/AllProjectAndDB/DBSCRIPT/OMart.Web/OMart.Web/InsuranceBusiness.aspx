<%@ Page Title="Business Insurance" Language="C#" MasterPageFile="~/OiiOMasterPage.master" AutoEventWireup="true" CodeFile="InsuranceBusiness.aspx.cs" Inherits="InsuranceBusiness" %>

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

                                <p><a class="bantxtTitel" href="#">Business insurance</a><span class="glyphicon glyphicon-chevron-right oioCherRight"></span></p>
                                <h4>Our service is simple and speedy - compare  <span class="text-danger">Business insurance </span>in a few minutes.</h4>
                                <div class="row">
                                    <div class="col-sm-4">
                                        <ul class="insBannerLink">
                                            <li><a href="#">Find affordable business insurance<span class="glyphicon glyphicon-chevron-right oioCherRight2"></span></a></li>

                                        </ul>
                                        <%--                                        <p><a class="btn btn-primary " href="#">Contact Us</a></p>--%>
                                    </div>
                                </div>

                                <div class="hero2">
                                    <img class="img-responsive" src="Images/banner/0429_1.png" alt="img" />
                                </div>

                            </div>
                        </div>
                    </div>
                    <div class="item slides">
                        <div class="slideinsur2">
                        </div>
                        <div class="insBannerCntWrp">
                            <div class="insBannerCnt">

                                <p><a class="bantxtTitel" href="#">Car insurance</a><span class="glyphicon glyphicon-chevron-right oioCherRight"></span></p>
                                <h4>Our service is simple and speedy - compare  <span class="text-danger">Car insurance</span>in a few minutes.</h4>
                                <div class="row">
                                    <div class="col-sm-4">
                                        <ul class="insBannerLink">
                                            <li><a href="#">The cheapest cars to insure<span class="glyphicon glyphicon-chevron-right oioCherRight2"></span></a></li>

                                        </ul>
                                        <%--                                        <p><a class="btn btn-primary " href="#">Contact Us</a></p>--%>
                                    </div>
                                </div>

                                <div class="hero2">
                                    <img class="img-responsive" src="Images/banner/0419_1.png" alt="img" />
                                </div>

                            </div>
                        </div>
                    </div>

                </div>
            </div>

        </div>
    </section>
    <section>
        <div class="container insServ lifeInsr">
            <div class="row">
                <div class="col-sm-8 col-md-8 col-lg-8">
                    <div class="lifeInsr_compPart">
                        <img src="Images/products/0429_10.png" class="img-responsive" alt="img" />
                        <h4>Let's compare business insurance</h4>
                        <a class="btn btn-default btnQuote" href="<%=this.ResolveUrl("~/InsuranceBusinCover.aspx?Type=pnlBuzInsAbout")%>">Start a new quote</a>
                        <p>
                           We bring you some great deals on your business insurance from our 
panel of providers. 
                        </p>
                        <p>
                            You can call a Business Search advisor to discuss your cover; they'll 
answer questions and provide advice to help you decide.
                        </p>

                        <div class="clearfix"></div>
                    </div>

                </div>
                <div class="col-sm-4 col-md-4 col-lg-4">
                    <div class="lifeInsr_compPart text-center">
                        <h4>Already a customer?</h4>
                        <a class="btn btn-default btnQuote" href="Insurance_Cover.aspx">Retrieve quotes</a>

                        <p>
                           Sign in to view or edit a previous 
quote, activate your OiiO news 
membership, 
                        </p>

                        <div class="clearfix"></div>
                    </div>

                </div>
            </div>
            <div class="row">
                <div class="lifeIsr_BoxWrp">
                    <div class="col-sm-7 col-md-7 col-lg-7">
                        <div class="lifeIsr_BoxA">
                            <div class="row">
                                <div class="col-sm-6 col-md-6 col-lg-6 ">
                                    <h3>Customer ratings</h3>
                                    <img src="Images/Interfaces/0417_2.png" alt="img" />
                                    <h3>4.7/5</h3>
                                    <p>
                                        Our customers rate us 4.7/5 
based on 13587 customer 
reviews
                                    </p>
                                </div>
                                <div class="col-sm-6 col-md-6 col-lg-6 divider2">
                                    <h3>Wsmith 3 Mar 2015</h3>
                                    <img src="Images/Interfaces/0417_2.png" alt="img" />
                                    <h3>4.7/5</h3>
                                    <p>
                                        Found some great deals with just what I 
needed. Would recommend to anyone as 
so easy to do.s
                                    </p>
                                    <p><a href="#">Read all reviews</a></p>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-5 col-md-5 col-lg-5">
                        <div class="lifeIsr_BoxA">
                            <h3>We also quote for</h3>
                            <img class="quoteImg quoteImg2" src="Images/products/0429_11.png" alt="img" />
                            

                            <ul class="nav">
                                <li><a href="#">Car insurance</a></li>
                                <li><a href="#">Travel insurance</a></li>
                                <li><a href="#">Life insurance</a></li>
                            </ul>
                        </div>
                    </div>
                    <div class="clearfix"></div>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-3 col-md-3 col-lg-3">
                    <div class="sidebar">
                        <div class="leftsidebar_ins">
                            <img class="img-responsive" src="Images/products/0429_15.jpg" alt="img" />
                            <div class="leftsidebar_insInnr">
                                <h3>Business insurance guide</h3>

                                <p>Learn all about home insurance and find the policy for you</p>
                                <p><a href="#">Read more</a></p>
                            </div>
                        </div>
                        <div class="leftsidebar_ins">
                            <img class="img-responsive" src="Images/products/0429_16.jpg" alt="img" />
                            <div class="leftsidebar_insInnr">
                                <h3>Business insurance – the 
basics</h3>

                                <p>Read our list of frequently asked business insurance questions for the facts on why you need business insurance, the types of cover, excesses and more</p>
                                <p><a href="#">Read more</a></p>
                            </div>
                        </div>

                        <div class="leftsidebar_ins">
                            <img class="img-responsive" src="Images/products/0429_17.jpg" alt="img" />
                            <div class="leftsidebar_insInnr">
                                <h3>Types of business insurance</h3>

                                <p>It may be tempting to opt for the cheapest policy available, but sacrificing quality of cover for a low price tag might give you an unwelcome and expensive shock later on.</p>
                                <p><a href="#">Read more</a></p>
                            </div>
                        </div>

                    </div>
                </div>
                <div class="col-sm-6 col-md-6 col-lg-6">
                    <div class="contentArea_ins">
                        <h3>Why compare business insurance with us?</h3>
                        <p>
                                        Here at OiiO Mart.com we know how important it is to make 
sure your business is covered. This is why the business insurance 
comparison service available through OiiO Mart.com allows you to 
compare leading UK business insurance providers that you and your 
business can trust. If you let a property, you can compare landlord 
insurance and choose your coverage level including; buildings cover, rental 
income cover, employers liability insurance and legal expenses cover. Our 
tradesman insurance comparison tool allows you to select options including 
employers liability insurance, public liability insurance, tool cover and 
business interruption. If you own or run a shop, pub, hotel, restaurant, cafe, 
office or surgery we also have specialist business insurance comparison 
services.
                        </p>
                        <p>
                                         We compare a selection of specialist insurance providers that are tailored 
to suit almost all businesses. Every person and every company is different, 
we at OiiO Mart.com recognise this and it is here, where you can 
compare business insurance quotes in minutes. All you need to do is 
complete our quick enquiry form, compare business insurance quotes, 
select which provider is best for your company’s needs and click through to 
that provider to buy online.
                        </p>
                        <p>         Ensure the co ntinued success of your business and have a look at 
what OiiO Mart.com can do for you, compare business insurance 
today.</p>
                        <h3>Who needs public liability insurance?</h3>
                        <p>
                                        Businesses most at risk from public liability claims are those who have 
visiting clients or suppliers, even if the business is run from home. If you will 
be working at a customer's property or premises, you will also be liable for 
any damage or injury arising as a result of your work for them. Having a 
public liability policy in place is not a legal requirement per se, but certain 
professions will need to have one in order to trade. 
                        </p>
                        <p>     If you own a shop, pub or office, work in the plumbing trade or any of the 
other trades which require you to enter a customer's premises, then you 
should seriously consider taking out public liability insurance to make sure 
you are covered in the event of a claim. If you want to find out more about a 
business insurance policy specifically tailored for tradesmen, then visit our 
tradesman insurance page, likewise, you can find our self employed public 
liability insurance page here. 
                        </p>
                        <p>            Sometimes, no matter how hard we try, accidents are unavoidable so it’s 
imperative you take out adequate cover. Many small businesses would find 
it difficult to foot the bill for expensive legal costs and compensation 
payments arising from an accident or damage to a customer's property, so 
purchasing a comprehensive business insurance policy can really be a 
lifeline.</p>
                       
                       
                    </div>
                </div>
                <div class="col-sm-3 col-md-3 col-lg-3">
                    <div class="right_sidebar_ins">
                        <div class="rightSidebarA">
                            <h3>Shop</h3>
                            <p>Need more information about business insurance? Don't worry, we have a list of business insurance shop which may help with your query.</p>
                            <div class="clearfix"></div>
                        </div>

                        <div class="rightSidebarA">
                            <h3>Office</h3>
                            <p>Find the best critical illness cover and start saving money today with OiiO Mart.com. </p>
                            <div class="clearfix"></div>
                        </div>

                        <div class="rightSidebarA">
                            <h3>Hotel</h3>
                            <p>Find the best over 50s life insurance policy for you, quickly and easily, here at OiiO Mart.com.</p>
                            <div class="clearfix"></div>
                        </div>
 <div class="rightSidebarA">
                            <h3>Pub</h3>
                            <p>Find the best over 50s life insurance policy for you, quickly and easily, here at OiiO Mart.com.</p>
                            <div class="clearfix"></div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row topLeadIns">
                    <div class="col-xs-2 col-sm-2">
                        <h4>We compare quotes 
from these leading 
BD insurers and 
more...</h4>
                    </div>
                    <div class="col-xs-10 col-sm-10">

                        <img class="img-thumbnail img-responsive" src="Images/Interfaces/0417_8.png" alt="img" />
                         <img class="img-thumbnail img-responsive" src="Images/Interfaces/0417_9.png" alt="img" />
                         <img  class="img-thumbnail img-responsive" src="Images/Interfaces/0417_10.png" alt="img" />
                          <img class="img-thumbnail img-responsive" src="Images/Interfaces/0417_12.png" alt="img" />

                         <img  class="img-thumbnail img-responsive" src="Images/Interfaces/0417_11.png" alt="img" />

                       

                         <img class="img-thumbnail img-responsive" src="Images/Interfaces/0417_13.png" alt="img" />

                         <img class="img-thumbnail img-responsive" src="Images/Interfaces/0417_14.png" alt="img" />

                         <img class="img-thumbnail img-responsive" src="Images/Interfaces/0417_15.png" alt="img" />

                        
                    </div>
            </div>
          
        </div>
    </section>

</asp:Content>

