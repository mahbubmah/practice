<%@ Page Title="" Language="C#" MasterPageFile="~/InsuranceMaster.Master" AutoEventWireup="true" CodeBehind="InsuranceCarQuoteDetails.aspx.cs" Inherits="OMart.Web.InsuranceCarQuoteDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                                    <a class="active" href="InsuranceCarQuoteDetails.aspx"><span>2</span>Your details</a>
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
                            <h3>Your details</h3>

                            <div class="row">

                                <div class="col-xs-3">
                                    <p>First name</p>
                                    <input type="text" class="form-control txtBox_ofw" placeholder="" />

                                </div>
                                <div class="col-xs-3">
                                    <p>
                                        Surname <span><a href="#" title="Help">
                                            <img src="Images/Interfaces/questionIocn.png" alt="img" /></a></span>
                                    </p>
                                    <input type="text" class="form-control txtBox_ofw" placeholder="" />
                                </div>

                            </div>
                            <div class="row">
                                <div class="col-xs-3">
                                    <h4>What is your gender? <span><a href="#" title="Help">
                                        <img src="Images/Interfaces/questionIocn.png" alt="img" /></a></span></h4>


                                    <label>
                                        <input type="radio" name="optionsRadios" id="optionsRadios1" value="option1" />
                                        Male
                                    </label>
                                    <label>
                                        <input type="radio" name="optionsRadios" id="optionsRadios2" value="option1" />
                                        Female
                                    </label>

                                </div>
                            </div>

                            <div class="row">

                                <div class="col-xs-12">
                                    <h4>Date of birth (dd/mm/yyyy) </h4>
                                    <input type="text" class="form-control txtBox_ofw" placeholder="DD/MM/YYYY" />
                                    <p>For example:  30/10/1984  or  21.9.82  or  19 Mar 1978</p>
                                </div>


                            </div>
                            <div class="row">
                                <div class="col-xs-4">
                                    <h4>Marital status<span><a href="#" title="Help">
                                        <img src="Images/Interfaces/questionIocn.png" alt="img" /></a></span></h4>
                                    <select class="form-control">
                                        <option>-- Please Select --</option>
                                        <option>1</option>

                                        <option>1</option>
                                    </select>
                                </div>
                            </div>


                            <div class="row">
                                <div class="col-xs-8">
                                    <h4>How many children under 16 do you have? <span><a href="#" title="Help">
                                        <img src="Images/Interfaces/questionIocn.png" alt="img" /></a></span></h4>
                                    <input type="text" class="form-control txtBox_ofw" />

                                </div>
                            </div>

                            <div class="row">
                                <div class="col-xs-8">
                                    <h4>What do you do for a living? <span><a href="#" title="Help">
                                        <img src="Images/Interfaces/questionIocn.png" alt="img" /></a></span></h4>
                                    <input type="text" class="form-control txtBox_ofw" />
                                    <p>For example: Teacher, Receptionist, Retired, Student, etc</p>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-xs-8">
                                    <h4>What's your employer's business type?  <span><a href="#" title="Help">
                                        <img src="Images/Interfaces/questionIocn.png" alt="img" /></a></span></h4>
                                    <input type="text" class="form-control txtBox_ofw" />
                                    <p>For example: Education, Food Manufacturing, Retailing, etc</p>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-xs-8">
                                    <h4>Do you have an additional job?  <span><a href="#" title="Help">
                                        <img src="Images/Interfaces/questionIocn.png" alt="img" /></a></span></h4>
                                    <input type="text" class="form-control txtBox_ofw" />


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
                            <h4>How long have you lived in the UK? <span><a href="#" title="Help">
                                <img src="Images/Interfaces/questionIocn.png" alt="img" /></a></span></h4>


                            <div class="row">


                                <div class="col-xs-3">
                                    <label>
                                        <input type="radio" />
                                        From birth   or since
                                    </label>
                                    <p></p>
                                </div>
                                <div class="col-xs-3">
                                    <select class="form-control">
                                        <option>---Month---</option>
                                    </select>
                                </div>
                                <div class="col-xs-3">
                                    <input type="text" class="form-control" />

                                </div>
                            </div>

                            <h4>To receive a guaranteed discount on your Tesco Bank Car Insurance, please tell us your Tesco Clubcard number. <span><a href="#" title="Help">
                                <img src="Images/Interfaces/questionIocn.png" alt="img" /></a></span></h4>


                            <div class="row">


                                <div class="col-xs-6">
                                    <input type="text" class="form-control" />

                                </div>
                            </div>






                        </div>
                        <div class="well oiioForm_a oiioForm_fcon">
                            <h3>Address</h3>

                            <div class="row">

                                <div class="col-xs-3">
                                    <p>House number or name</p>
                                    <input type="text" class="form-control txtBox_ofw" placeholder="" />

                                </div>
                                <div class="col-xs-3">
                                    <p>
                                        Postcode <span><a href="#" title="Help">
                                            <img src="Images/Interfaces/questionIocn.png" alt="img" /></a></span>
                                    </p>
                                    <input type="text" class="form-control txtBox_ofw" placeholder="" />
                                </div>
                                <div class="col-xs-3">
                                    <p>
                                        <br />
                                    </p>
                                    <a class="btn btn-primary" href="#">Find Address</a>
                                </div>

                            </div>
                            <div class="row">
                                <div class="col-xs-12">
                                    <h4>Are you a homeowner?<span><a href="#" title="Help">
                                        <img src="Images/Interfaces/questionIocn.png" alt="img" /></a></span></h4>


                                    <label>
                                        <input type="radio" name="optionsRadios" id="optionsRadios34" value="option1" />
                                        Yes
                                    </label>
                                    <label>
                                        <input type="radio" name="optionsRadios" id="optionsRadios33" value="option1" />
                                        No
                                    </label>

                                </div>
                            </div>







                        </div>

                        <div class="well oiioForm_a oiioForm_fcon">
                            <h3>Claims, incidents and offences</h3>


                            <div class="row">
                                <div class="col-xs-12">
                                    <h4>Has the driver had any motor insurance claims or incidents in the last five years (regardless of blame)?<span><a href="#" title="Help">
                                        <img src="Images/Interfaces/questionIocn.png" alt="img" /></a></span></h4>


                                    <label>
                                        <input type="radio" name="optionsRadios" id="optionsRadios34S" value="option1" />
                                        Yes
                                    </label>
                                    <label>
                                        <input type="radio" name="optionsRadios" id="optionsRadios3S3" value="option1" />
                                        No
                                    </label>

                                </div>
                            </div>
                            <div class="row">
                                <div class="col-xs-12">
                                    <h4>Has the driver committed any motoring offences or had any fixed penalty notices in the previous five years?<span><a href="#" title="Help">
                                        <img src="Images/Interfaces/questionIocn.png" alt="img" /></a></span></h4>


                                    <label>
                                        <input type="radio" name="optionsRadios" id="optionSsRadios34S" value="option1" />
                                        Yes
                                    </label>
                                    <label>
                                        <input type="radio" name="optionsRadios" id="optionsRSadios3S3" value="option1" />
                                        No
                                    </label>

                                </div>
                            </div>

                            <div class="row">
                                <div class="col-xs-12">
                                    <h4>Do you have any non-motoring convictions?<span><a href="#" title="Help">
                                        <img src="Images/Interfaces/questionIocn.png" alt="img" /></a></span></h4>


                                    <label>
                                        <input type="radio" name="optionsRadios" id="optionSsRadios3Z4S" value="option1" />
                                        Yes
                                    </label>
                                    <label>
                                        <input type="radio" name="optionsRadios" id="optionsRSadiosZ3S3" value="option1" />
                                        No
                                    </label>

                                </div>
                            </div>





                        </div>

                        <div class="well oiioForm_a oiioForm_fcon">
                            <h3>About your driving</h3>

                            <div class="row">

                                <div class="col-xs-8">
                                    <p>When do you want your insurance policy to start (within 30 days)?</p>

                                    <input type="text" class="form-control txtBox_ofw width200" placeholder="" />
                                    <p>For example:  30/05/2013  or  01.03.2013  or  12-07-2013</p>
                                </div>


                            </div>
                            <div class="row">
                                <div class="col-xs-6">
                                    <h4>What type of driving licence do you hold?<span><a href="#" title="Help">
                                        <img src="Images/Interfaces/questionIocn.png" alt="img" /></a></span></h4>

                                    <select class="form-control txtBox_ofw width200">
                                        <option>-- Please Select --</option>
                                        <option>123</option>
                                    </select>

                                </div>
                            </div>
                            <div class="row">
                                <div class="col-xs-6">
                                    <h4>How long have you held this licence?<span><a href="#" title="Help">
                                        <img src="Images/Interfaces/questionIocn.png" alt="img" /></a></span></h4>

                                    <select class="form-control txtBox_ofw width200">
                                        <option>-- Please Select --</option>
                                        <option>123</option>
                                    </select>
                                    <span>Years</span>

                                </div>
                            </div>

                            <div class="row">
                                <div class="col-xs-7">
                                    <h4>How many years no claims discount do you have?<span><a href="#" title="Help">
                                        <img src="Images/Interfaces/questionIocn.png" alt="img" /></a></span></h4>

                                    <select class="form-control txtBox_ofw width200">
                                        <option>-- Please Select --</option>
                                        <option>123</option>
                                    </select>

                                </div>
                            </div>
                            <div class="row">
                                <div class="col-xs-8">
                                    <h4>Do you have any medical conditions that affect your driving?<span><a href="#" title="Help">
                                        <img src="Images/Interfaces/questionIocn.png" alt="img" /></a></span></h4>

                                    <select class="form-control txtBox_ofw width200">
                                        <option>-- Please Select --</option>
                                        <option>123</option>
                                    </select>

                                </div>
                            </div>

                            <div class="row">
                                <div class="col-xs-8">
                                    <h4>Has anyone on the policy ever been declined insurance?<span><a href="#" title="Help">
                                        <img src="Images/Interfaces/questionIocn.png" alt="img" /></a></span></h4>

                                    <label>
                                        <input type="radio" name="optionsRadios" id="optionsRadios34Ss" value="option1" />
                                        Yes
                                    </label>
                                    <label>
                                        <input type="radio" name="optionsRadios" id="optionsRadios3Sw3" value="option1" />
                                        No
                                    </label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-xs-8">
                                    <h4>Do you drive any other cars?<span><a href="#" title="Help">
                                        <img src="Images/Interfaces/questionIocn.png" alt="img" /></a></span></h4>

                                    <select class="form-control txtBox_ofw width200">
                                        <option>-- Please Select --</option>
                                        <option>123</option>
                                    </select>

                                </div>
                            </div>
                            <div class="row">
                                <div class="col-xs-8">
                                    <h4>How would you prefer to pay for your car insurance? <span><a href="#" title="Help">
                                        <img src="Images/Interfaces/questionIocn.png" alt="img" /></a></span></h4>

                                    <label>
                                        <input type="radio" name="optionsRadios" id="optionsRadios34Sss" value="option1" />
                                        Annually
                                    </label>
                                    <label>
                                        <input type="radio" name="optionsRadios" id="optionsRadios3Ssw3" value="option1" />
                                        Monthly
                                    </label>
                                </div>
                            </div>
                        </div>
                        <div class="well oiioForm_a oiioForm_fcon">
                            <h3>Additional Drivers</h3>
                            <h4>Would you like to add additional drivers (up to 3 maximum)?</h4>
                            <a href="#" class="btn btn-primary pull-right">Add a driver</a>
                            <div class="clearfix"></div>
                        </div>
                        <div class="well oiioForm_a oiioForm_fcon">
                            <h3>Your account</h3>

                            <ul class="listItemfRM">
                                <li>We'll save all of your quotes automatically</li>
                                <li>Fill in your details once and use them again and again</li>
                                <li>Your details will be kept safe and secure</li>

                            </ul>
                            <div class="row">
                                <div class="col-xs-8">
                                    <p>Email address</p>
                                    <input type="text" class="form-control txtBox_ofw width200" placeholder="" />

                                </div>
                            </div>
                            <div class="row">
                                <div class="col-xs-8">
                                    <p>Create a moneysupermarket.com password (minimum of 6 characters)</p>
                                    <input type="text" class="form-control txtBox_ofw width200" placeholder="" />

                                </div>
                            </div>
                            <div class="row">
                                <div class="col-xs-12">
                                <label>
                                        <input type="checkbox" name="optionsRadios" id="optionsRadios34sa" value="option1" />
                                        Remember me on this computer for 90 days <span><a href="#" title="Help">
                                        <img src="Images/Interfaces/questionIocn.png" alt="img" /></a></span>
                                    </label>
                                    <p>If you use a public or shared computer, we recommend you untick this box</p>
                                    <p>In addition to receiving an instant email when I get my quotes, I agree to let moneysupermarket.com and their carefully 
chosen partners contact me with money saving tips and offers
                                        <label>
                                        <input type="checkbox" name="optionsRadios" id="sa" value="option1" />
                                       by email 
                                    </label>
                                         <label>
                                        <input type="checkbox" name="optionsRadios" id="sa" value="option1" />
                                       by phone  
                                    </label>
                                        <label>
                                        <input type="checkbox" name="optionsRadios" id="sa" value="option1" />
                                       by text 
                                    </label>
                                    </p>
                                    <p>As part of our service to help you find the best deal on your car insurance, we have authorised the insurers who provide 
your two cheapest quotes to contact you to discuss them and answer any questions you might have. Do you wish to use 
this service?  <label>
                                        <input type="checkbox" name="optionsRadios" id="sa" value="option1" />
                                      Yes please
                                    </label></p>
                                    <p>You can untick the boxes if you don't wish to be contacted.</p>
                                    </div>
                            </div>

                            <div class="row">
                                <div class="col-xs-2">
                                    <a href="InsuranceCarQuote.aspx" class="btn btn-primary">Back</a>
                                </div>
                                <div class="col-xs-7">
                                    <p class="text-right">By clicking "Get Quotes", you are agreeing to 
our terms & conditions</p>
                                </div>
                                 <div class="col-xs-3 pull-right">
                                    <a href="InsuranceCarResult.aspx" class="btn btn-primary">Get quotes >></a>
                                </div>
                            </div>

                            <div class="clearfix"></div>
                        </div>
                    </div>
                    <div class="col-sm-3 col-md-3 col-lg-3">
                        <div class="rightSidebar">
                            <p>Please make sure you read every question carefully. If you don’t answer the questions correctly, your policy may be cancelled, or your claim rejected or not fully paid.</p>
                            <h3>Service you can trust</h3>
                            <p>Our site is protected by VeriSign</p>
                            <img src="Images/Interfaces/norton.jpg" alt="" />
                            <p>Powered by Symantec</p>
                            <p><a href="#">>> Learn more</a></p>
                            <h3>FAQs</h3>
                            <ul class="rightSideListItem">
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
