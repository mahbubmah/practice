<%@ Page Title="Car Insurance" Language="C#" MasterPageFile="~/InsuranceMaster.Master" AutoEventWireup="true" CodeFile="InsuranceCares.aspx.cs" Inherits="InsuranceCares" %>

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
                        <img src="Images/products/0419_2.png" class="img-responsive" alt="img" />
                        <h4>Let's compare car insurance</h4>
                        <a class="btn btn-default btnQuote" href="InsuranceCarQuote.aspx">Start a new quote</a>
                        <p>
                            We bring you some great deals on your life insurance from our 
panel of providers.
                        </p>
                        <p>
                            You can call a LifeSearch advisor to discuss your cover; they'll 
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
membership, or get your 2 
for 1 cinema voucher code.
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
                                    <img src="Images/Interfaces/0419_3.png" alt="img" />
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
                            <img class="quoteImg" src="Images/products/0419_3.png" alt="img" />
                            <h3>We also quote for</h3>

                            <ul class="nav">
                                <li><a href="#">Van insurance</a></li>
                                <li><a href="#">Motorbike insurance</a></li>
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
                            <img class="img-responsive" src="Images/products/0419_4.jpg" alt="img" />
                            <div class="leftsidebar_insInnr">
                                <h3>Cheapest cars to insure</h3>

                                <p>Every car on the market belongs to one of 50 car insurance groups – find out which ones are the cheapest to insure</p>
                                <p><a href="#">Read more</a></p>
                            </div>
                        </div>
                        <div class="leftsidebar_ins">
                            <img class="img-responsive" src="Images/products/0419_4.jpg" alt="img" />
                            <div class="leftsidebar_insInnr">
                                <h3>Car insurance – the basics</h3>

                                <p>Learn all about life insurance and find the policy for you</p>
                                <p><a href="#">Read more</a></p>
                            </div>
                        </div>

                        <div class="leftsidebar_ins">
                            <img class="img-responsive" src="Images/products/0419_5.jpg" alt="img" />
                            <div class="leftsidebar_insInnr">
                                <h3>Types of Car insurance</h3>

                                <p>It may be tempting to opt for the cheapest policy available, but sacrificing quality of cover for a low price tag might give you an unwelcome and expensive shock later on.</p>
                                <p><a href="#">Read more</a></p>
                            </div>
                        </div>

                    </div>
                </div>
                <div class="col-sm-6 col-md-6 col-lg-6">
                    <div class="contentArea_ins">
                        <h3>Why compare car insurance with us?</h3>
                        <p>
                                At OiiO Mart.com we provide insurance quotes for a wide range of cars. 
So whether you drive an Alfa or a Volvo – or most motors in between – take
a look at the links below and start your journey to insuring your car. We try 
to provide car insurance for as many manufacturers as possible. If the car 
you own isn’t listed here, don’t worry: get in contact with us, tell us how you
roll and we’ll see what we can do.
                        </p>
                        <p>
                                 Whether you’re looking for fully comprehensive motor insurance to third 
party only, we could help you save money - it could be up to Tk 4234 (50% of 
consumers could achieve this saving with OiiO Mart.com Motor 
Insurance)^.28% of consumers achieved an average saving of £461 with 
OiiO Mart.com Motor Insurance.^
                        </p>
                        <h3>See how much you can save on your car 
insurance with OiiO Mart.com!</h3>
                        <p>
                                Here at OiiO Mart.com, we want to make it as quick and easy for you to 
find a great deal on insuring your vehicle. It’s really easy and only takes a 
few minutes. You only need to enter your information once into our simple 
form, just a little information about yourself, your driving history and 
vehicle itself and you can check quotes from some of the BD’s top providers 
almost instantly.
                        </p>
                        <p>
                                 We understand getting a renewal on your insurance can be frustrating, 
but if you want to save money it’s always important to shop around. We can 
help you reduce the time this takes by making the process as easy as 
possible and listing your best quotes from our trusted panel of insurers in 
one place.
                        </p>
                        <p>     So, whether you’re looking to beat your current provider’s renewal quote, 
or you’re looking to insure a new vehicle, our easy to use comparison 
service could save you time and help you find a better deal.</p>
                        <p>     Perhaps you’re looking for auto insurance quotes that are more precisely 
tailored to you, such as young driver cover or insurance for students. Don’t 
worry, we can help you with that too.</p>
                        <p>   Start now and see how much you could save money on your annual policy.</p>

                        <h3>What is the minimum policy duration for car insurance?</h3>
                        <p>
                            Life insurance comes in a variety of forms. At its simplest, it pays out an 
agreed amount, either as a lump sum or as a regular income, if you die 
within a specified period – known as the ‘term’. Hence its name: term 
insurance.
                        </p>
                   
                        <h3>What is the minimum policy duration for car insurance?</h3>

                        <p>
                                Standard policies last for 1 year, with the option to pay the annual fee up 
front or as monthly payments.
                        </p>
                        <p>
                               Once you've found an auto insurance deal that's right for you just pick the 
provider and simply complete the process.
                        </p>
                       
                    </div>
                </div>
                <div class="col-sm-3 col-md-3 col-lg-3">
                    <div class="right_sidebar_ins">
                        <div class="rightSidebarA">
                            <h3>Car FAQs</h3>
                            <p>Need more information about life insurance? Don't worry, we have a list of life insurance FAQs which may help with your query.</p>
                            <div class="clearfix"></div>
                        </div>

                        <div class="rightSidebarA">
                            <h3>Young drivers' 
insurance</h3>
                            <p>If you are looking for a cheaper young drivers car insurance policy, let us take away the hard work by comparing quotes across a range of providers.</p>
                            <div class="clearfix"></div>
                        </div>

                        <div class="rightSidebarA">
                            <h3>Women's car insurance</h3>
                            <p>Compare women’s car insurance quotes with just a few clicks and you could be saving money in no time at all!</p>
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

