<%@ Page Title="Insurance Car Quote" Language="C#" MasterPageFile="~/OiiOMasterPage.master" AutoEventWireup="true" CodeFile="InsuranceCarQuote.aspx.cs" Inherits="InsuranceCarQuote" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section>
        <div class="container-fluid">
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
                    <div id="bs-example-navbar-collapse-1" class="collapse navbar-collapse">
                        <ul class="nav navbar-nav">
                            <li>
                                <a class="active" href="Index.aspx">Home</a>
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
                                <a class="dropdown-toggle" data-toggle="dropdown" href="Money.aspx">Money</a>
                                <ul class="dropdown-menu">
                                    <li><a href="CurrentAccount.aspx">Current accounts</a></li>
                                    <li><a href="CreditCards.aspx">Cradit cards</a></li>
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
                                <a class="dropdown-toggle" data-toggle="dropdown" href="InsuranceNews.aspx">Insurance</a>
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
                                    <li><a href="payasyou.aspx">Pay as you go phones</a></li>
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
        </div>
    </section>
    <section>
        <div class=" oiioInsuranceFormWrp">
            <div class="container">
                <div class="row">
                    <nav role="navigation" class="navbar navbar-inverse oiioInsuranceFormMenu2">

                        <!-- Brand and toggle get grouped for better mobile display -->
                        <div class="navbar-header">
                            <button data-target="#insFormMenu2" data-toggle="collapse" class="navbar-toggle" type="button">
                                <span class="sr-only">Toggle navigation</span>
                                <span class="icon-bar"></span>
                                <span class="icon-bar"></span>
                                <span class="icon-bar"></span>
                            </button>
                        </div>
                        <!-- Collect the nav links, forms, and other content for toggling -->
                        <div id="insFormMenu2" class="collapse navbar-collapse">
                            <ul class="nav navbar-nav">
                                <li>
                                    <a class="active" href="InsuranceCarQuote.aspx"><span>1</span>Your vehicle</a>
                                </li>
                                <li>
                                    <a href="InsuranceCarQuoteDetails.aspx"><span>2</span>Your details</a>
                                </li>
                                <li>
                                    <a href="#"><span>3</span>Result</a>
                                </li>


                            </ul>
                        </div>
                        <!-- /.navbar-collapse -->

                    </nav>
                </div>
                <div class="row">
                    <div class="col-sm-9 col-md-9 col-lg-9">
                        <div class="well oiioForm_a oiioForm_fcon">
                            <h3>Your vehicle</h3>
                            <h5>This is the amount the policy will pay out in the event of a claim. <span class=""><a href="#" title="Help">?</a></span></h5>
                            <div class="radio">
                                <label class="col-xs-1">
                                    <input type="radio" />
                                    Yes
                                </label>
                                <input type="text" class="col-xs-8 form-control txtBox_ofw" />
                                <input type="submit" class="col-xs-1 btn btn-primary" value="confirm" />

                            </div>
                            <div class="radio">
                                <label class="col-xs-8">
                                    <input type="radio" />
                                    No &nbsp; &nbsp; &nbsp;

                                    Help me find the car by make and model
                                </label>
                                <div class="clearfix"></div>
                            </div>
                            <div class="row_A carApplyForm">
                                <p>
                                    <strong>The Car :</strong>
                                    <img src="Images/Interfaces/car1.png" alt="icon" />
                                    SEAT LEON 2009-2015 Petrol 1.6L Manual 5 doors S EMOCION Not the right car?
                                </p>
                                <h5>Based on this, we think the car:</h5>
                                <ul>
                                    <li>Is right hand drive</li>
                                    <li>Has 5 seats</li>
                                    <li>Has no tracker device fitted</li>
                                    <li>Has a Thatcham 1 alarm</li>
                                    <li>Is not imported</li>

                                </ul>
                            </div>
                            <p>
                                Important: Ensure that the details of the car above are correct in order to get the right cover. 
I want to change these details
                            </p>
                            <h4>Has the car been modified in any way e.g. alloy wheels, tow bar added etc? <span><a href="#" title="Help">
                                <img src="Images/Interfaces/questionIocn.png" alt="img" /></a></span></h4>
                            <div class="row_A">

                                <label>
                                    <input type="radio" name="optionsRadios" id="optionsRadios1" value="option1" />
                                    Yes
                                </label>
                                <label>
                                    <input type="radio" name="optionsRadios" id="optionsRadios2" value="option1" />
                                    No
                                </label>


                            </div>
                            <h4>When did you start driving this car? <span><a href="#" title="Help">
                                <img src="Images/Interfaces/questionIocn.png" alt="img" /></a></span></h4>




                            <div class="row">
                                <div class="col-xs-1">
                                    <label style="line-height: 34px;">Form</label>
                                </div>
                                <div class="col-xs-3">
                                    <select class="form-control">
                                        <option>one</option>
                                        <option>one</option>

                                        <option>one</option>


                                    </select>
                                </div>
                                <div class="col-xs-3">
                                    <input type="text" class="form-control txtBox_ofw" placeholder="" />
                                </div>
                                <div class="col-xs-5">

                                    <div class="">
                                        <label>
                                            <input type="checkbox" />
                                            I don't have the car yet
                                        </label>
                                        <div class="clearfix"></div>
                                    </div>
                                </div>
                            </div>


                            <h4>Are you the owner and the registered keeper of the car?<span><a href="#" title="Help">
                                <img src="Images/Interfaces/questionIocn.png" alt="img" /></a></span></h4>
                            <div class="row_A">

                                <label>
                                    <input type="radio" name="optionsRadios" id="optionsRadios1" value="option1" />
                                    Yes
                                </label>
                                <label>
                                    <input type="radio" name="optionsRadios" id="optionsRadios2" value="option1" />
                                    No
                                </label>


                            </div>




                        </div>


                        <div class="well oiioForm_a oiioForm_fcon">
                            <h3>Using the car</h3>
                            <h5>What do you use the car for?  <span class=""><a href="#" title="Help">
                                <img src="Images/Interfaces/questionIocn.png" alt="img" /></a></span></h5>
                            <div class="row_A">
                                <div class="col-xs-6">
                                <select class="form-control">
                                    <option>a</option>
                                    <option>a</option>

                                </select>

                                    </div>
                                <div class="clearfix"></div>
                            </div>

                            <h5>Roughly how many personal miles does the car cover in a year? <span class=""><a href="#" title="Help">
                                <img src="Images/Interfaces/questionIocn.png" alt="img" /></a></span></h5>




                            <div class="row_A">
                                <div class="col-xs-2">
                                    <input type="text" class="form-control" />
                                </div>
                                <div class="col-xs-10">
                                    <p>miles - I'm not sure. Help me decide</p>

                                </div>

                                <div class="clearfix"></div>

                            </div>
                            <p>Note: Our providers will assume that you drive up to 1000 miles per year</p>




                            <h4>Roughly how many business miles does the car cover in a year?<span><a href="#" title="Help">
                                <img src="Images/Interfaces/questionIocn.png" alt="img" /></a></span></h4>
                            <div class="row_A">
                                <div class="col-xs-2">
                                    <input type="text" class="form-control" />
                                </div>
                                <div class="col-xs-10">
                                    <p>miles </p>

                                </div>

                                <div class="clearfix"></div>

                            </div>

                            <p>Note: Our providers will assume that you drive up to 500 miles per year</p>




                            <h4>Where is the car usually kept over night? <span><a href="#" title="Help">
                                <img src="Images/Interfaces/questionIocn.png" alt="img" /></a></span></h4>




                            <div class="row">
                                <div class="col-xs-4">
                                   <select class="form-control">
                                       <option>123</option>
                                   </select>
                                </div>
                            </div>
                             <h4>Where is the car usually kept during the day?  <span><a href="#" title="Help">
                                <img src="Images/Interfaces/questionIocn.png" alt="img" /></a></span></h4>




                            <div class="row">
                                <div class="col-xs-4">
                                   <select class="form-control">
                                       <option>123</option>
                                   </select>
                                </div>
                            </div>

                             <h4>Total number of cars in your household (including this one) <span><a href="#" title="Help">
                                <img src="Images/Interfaces/questionIocn.png" alt="img" /></a></span></h4>




                            <div class="row">
                                <div class="col-xs-4">
                                   <select class="form-control">
                                       <option>123</option>
                                   </select>
                                </div>
                            </div>



                            <div class="row">
                                <div class="col-sm-2 pull-right">
                                    <a href="InsuranceCarQuoteDetails.aspx" class="btn btn-primary">Next Step >>
                                    </a>
                                </div>
                            </div>








                        </div>
                    </div>
                    <div class="col-sm-3 col-md-3 col-lg-3">
                        <div class="rightSidebar">
                            <p>Please make sure you read every question carefully. If you don’t answer the questions correctly, your policy may be cancelled, or your claim rejected or not fully paid.</p>
                            <h3>Service you can trust</h3>
                            <p>Our site is protected by VeriSign</p>

                            <p>Powered by Symantec</p>
                            <p><a href="#">>> Learn more</a></p>
                            <h3>FAQs</h3>
                            <ul>
                                <li><a href="#">My car is not listed</a></li>
                                <li><a href="#">My car details are incorrect</a></li>
                                <li><a href="#">What is a modification?</a></li>
                                <li><a href="#">I want to insure my vehicle for business cover</a></li>

                            </ul>
                            <p><a href="#">>> Read more FAQs</a></p>
                        </div>
                    </div>
                    
                </div>
            </div>


        </div>

    </section>

</asp:Content>

