<%@ Page Title="Business Insurance Cover" Language="C#" MasterPageFile="~/OiiOMasterPage.master" AutoEventWireup="true" CodeFile="InsuranceBusinCover.aspx.cs" Inherits="InsuranceBusinCover" %>

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

            <nav role="navigation" class="navbar navbar-inverse oiioInsuranceFormMenu">
                <div class="container">
                    <!-- Brand and toggle get grouped for better mobile display -->
                    <div class="navbar-header">
                        <button data-target="#insFormMenu" data-toggle="collapse" class="navbar-toggle" type="button">
                            <span class="sr-only">Toggle navigation</span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                        </button>
                    </div>
                    <!-- Collect the nav links, forms, and other content for toggling -->
                    <div id="insFormMenu" class="collapse navbar-collapse">
                        <ul class="nav navbar-nav">

                            <li>
                                <a class="active" href="<%=this.ResolveUrl("~/InsuranceBusinCover.aspx?Type=pnlBuzInsAbout")%>"><span>1</span>Your business</a>
                            </li>
                            <li>
                                <a href="<%=this.ResolveUrl("~/InsuranceBusinCover.aspx?Type=buzInsCover")%>"><span>2</span>Your Cove</a>
                            </li>
                            <li>
                                <a href="<%=this.ResolveUrl("~/InsuranceBusinCover.aspx?Type=pnlBuzInsResult")%>"><span>3</span>Application</a>
                            </li>

                        </ul>
                    </div>
                    <!-- /.navbar-collapse -->
                </div>
                <!-- /.container -->
            </nav>

            <asp:Panel ID="pnlBuzInsAbout" runat="server">
                <div class="formTitel">
                    <div class=" container">
                        <div class="row">
                            <div class="col-md-12">
                                <h2>About Your Business</h2>
                            </div>
                        </div>
                    </div>

                </div>
                <div class="container">
                    <div class="row">
                        <div class="col-xs-12 col-sm-12 col-md-6 col-lg-6">
                            <h3>Which category describes your business best?</h3>
                            <select class="form-control txtBox_ofw">
                                <option>Please select</option>
                                <option>Please select</option>

                            </select>


                            <h3>What type of business do you want to insure?</h3>
                            <select class="form-control txtBox_ofw">
                                <option>Please select</option>
                                <option>Please select</option>

                            </select>

                            <h3>How many years have you been operating your business for? <span class="pull-right"><a href="#" title="Help">?</a></span></h3>
                            <select class="form-control txtBox_ofw">
                                <option>Please select</option>
                                <option>Please select</option>

                            </select>
                            <h3>Please confirm your business address</h3>
                            <input type="text" class="form-control txtBox_ofw" />
                            <p></p>
                            <p></p>

                        </div>
                    </div>
                </div>


                <div class="formTitel">
                    <div class=" container">
                        <div class="row">
                            <div class="col-md-12">
                                <h2>About you</h2>
                            </div>
                        </div>
                    </div>

                </div>
                <div class="container">
                    <div class="row">
                        <div class="col-xs-12 col-sm-12 col-md-6 col-lg-6">
                            <h3>What is your full name?</h3>

                            <div class="row">
                                <div class="col-sm-6">
                                    <input type="text" class="form-control txtBox_ofw" placeholder="First Name" />
                                </div>
                                <div class="col-sm-6">
                                    <input type="text" class="form-control txtBox_ofw" placeholder="Last Name" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">

                                    <h3>Your gender:</h3>

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
                            <h3>Your date of birth (dd/mm/yyyy):<span class="pull-right"><a href="#" title="Help">?</a></span></h3>

                            <div class="dateBox">
                                <asp:TextBox ID="txtbox1" runat="server" CssClass="dateBox_day" Text="DD"> </asp:TextBox>/
                            <asp:TextBox ID="TextBox1" runat="server" CssClass="dateBox_month" Text="MM"> </asp:TextBox>/
                            <asp:TextBox ID="TextBox2" runat="server" CssClass="dateBox_year" Text="YYY"> </asp:TextBox>
                            </div>


                        </div>
                    </div>
                </div>


                <div class="formTitel">
                    <div class=" container">
                        <div class="row">
                            <div class="col-md-12">
                                <h2>Your contact details</h2>
                            </div>
                        </div>
                    </div>

                </div>
                <div class="container">
                    <div class="row">
                        <div class="col-xs-12 col-sm-12 col-md-6 col-lg-6">
                             <h3>Your phone number::</h3>


                            <div class="row">
                                <div class="col-sm-6">
                                    <input type="text" class="form-control txtBox_ofw" />
                                </div>

                            </div>
                            <h3>Your email address:</h3>


                            <div class="row">
                                <div class="col-sm-6">
                                    <input type="text" class="form-control txtBox_ofw" />
                                </div>

                            </div>
                           

                              <h3>Your confirm email address:</h3>


                            <div class="row">
                                <div class="col-sm-6">
                                    <input type="text" class="form-control txtBox_ofw" />
                                </div>

                            </div>

                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <p>If you'd like to receive other money saving ideas by email, phone or text from MoneySuperMarket, tick the boxes below.</p>
                            <div class="checkbox multiCkbox">

                                <div class="btn-group" data-toggle="buttons">
                                    <label class="btn btn-default">
                                        <input type="checkbox" autocomplete="off" />
                                        <span class="glyphicon glyphicon-ok"></span>
                                    </label>
                                    Email
                                </div>
                                <div class="btn-group" data-toggle="buttons">
                                    <label class="btn btn-default">
                                        <input type="checkbox" autocomplete="off" />
                                        <span class="glyphicon glyphicon-ok"></span>
                                    </label>
                                    Phone
                                </div>
                                <div class="btn-group" data-toggle="buttons">
                                    <label class="btn btn-default">
                                        <input type="checkbox" autocomplete="off" />
                                        <span class="glyphicon glyphicon-ok"></span>
                                    </label>
                                    Text
                                </div>
                            </div>
                            <p>
                               You can untick any of the boxes if you'd rather not receive money saving ideas. But don't worry - you'll still receive your top quotes in an email and a phone call from LifeSearch if you've filled in your phone number.

                                
                            </p>
                            <div class="btn-group" data-toggle="buttons">
                                    <label class="btn btn-default">
                                        <input type="checkbox" autocomplete="off" />
                                        <span class="glyphicon glyphicon-ok"></span>
                                    </label> &nbsp;&nbsp;
                                    I agree to confirm my details fully with any insurer before purchasing any insurance policy from them and I have read and agree to the OiiO Mart.com terms & conditions and privacy  policy.
                                </div>

                        </div>
                    </div>
                </div>

                <div class="formTitel2">
                    <div class=" container">
                        <div class="row">
                            <div class="col-md-3 pull-right">
                                <a href="<%=this.ResolveUrl("~/InsuranceBusinCover.aspx?Type=buzInsCover")%>" class="btn btn-primary seeResultsBtn">Next step</a>
                            </div>
                        </div>
                    </div>

                </div>
            </asp:Panel>

            <asp:Panel ID="buzInsCover" runat="server">
                <div class="formTitel">
                    <div class=" container">
                        <div class="row">
                            <div class="col-md-12">
                                <h2>Your Cover</h2>
                            </div>
                        </div>
                    </div>

                </div>
                <div class="container">
                    <div class="row">
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                            <h3>Professional compemsation</h3>
                            <p>Cover if you make a mistake in your work that damages your customer's business.</p>
                            <select class="form-control txtBox_ofw">
                                <option>Please select</option>
                                <option>Please select</option>

                            </select>


                            <h3>Public liability</h3>
                            <p>Cover if you are blamed for an injury to a member of the public or damage to their property.</p>
                            <select class="form-control txtBox_ofw">
                                <option>Please select</option>
                                <option>Please select</option>

                            </select>

                            <h3>Employers' liability</h3>
                            <p>Cover for up to 10 employees for work-related illness or injury. This is a legal requirement if you have employees.</p>
                            <select class="form-control txtBox_ofw">
                                <option>Please select</option>
                                <option>Please select</option>

                            </select>
                            <h3>Office equipment</h3>
                            <p>Insurance for your office equipment that remains in your office; such as printers, fax machines and filing cabinets. Select how much it would cost to replace all of your office equipment.</p>
                            <select class="form-control txtBox_ofw">
                                <option>Please select</option>
                                <option>Please select</option>

                            </select>
                             <h3>Portable equipment</h3>
                            <p>Insurance for your equipment that you can take with you when you leave your office; such as laptops, mobile phones, cameras or tools. Select how much it would cost to replace all of your portable equipment.</p>
                            <select class="form-control txtBox_ofw">
                                <option>Please select</option>
                                <option>Please select</option>

                            </select>
                            <p></p>
                            <p></p>

                        </div>
                    </div>
                </div>


                
                


                
                

                <div class="formTitel2">
                    <div class=" container">
                        <div class="row">
                             <div class="col-md-3 pull-left">
                                <a href="<%=this.ResolveUrl("~/InsuranceBusinCover.aspx?Type=pnlBuzInsAbout")%>" class="btn btn-primary seeResultsBtn">Previous step</a>
                            </div>

                            <div class="col-md-3 pull-right">
                                <a href="<%=this.ResolveUrl("~/InsuranceBusinCover.aspx?Type=pnlBuzInsResult")%>" class="btn btn-primary seeResultsBtn">Next step</a>
                            </div>
                        </div>
                    </div>

                </div>
            </asp:Panel>

            <asp:Panel ID="pnlBuzInsResult" runat="server">
                <div class="formTitel">
                    <div class=" container">
                        <div class="row">
                            <div class="col-md-12">
                                <h2>Result Coming soon</h2>
                            </div>
                        </div>
                    </div>

                </div>
                


                
                


                
                

                
            </asp:Panel>
        </div>

    </section>

</asp:Content>

