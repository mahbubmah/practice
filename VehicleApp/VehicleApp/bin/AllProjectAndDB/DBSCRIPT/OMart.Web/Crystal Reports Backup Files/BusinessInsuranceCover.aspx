<%@ Page Title="Business Insurance Cover" Language="C#" MasterPageFile="~/InsuranceMaster.master" AutoEventWireup="true" CodeBehind="BusinessInsuranceCover.aspx.cs" Inherits="OMart.Web.BusinessInsuranceCover" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .hasDatepicker {
            position: relative;
            float: left;
            bottom: 10px;
        }
    </style>
    <script type="text/javascript">
        $(function () {
            $.noConflict();
            $("#<%=txtDateOfBirth.ClientID%>").datepicker({
                showOn: 'both',
                buttonImage: 'Scripts/jquery-ui-1.11.4/images/datepickerImage.png',
                dateFormat: 'dd-M-yy',
                changeMonth: true,
                changeYear: true,
                yearRange: "-100:+0"
            });

        });
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label runat="server" ID="lblMessage"></asp:Label>
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
                                <a class="active" runat="server" id="ancAboutYou" href="~/BusinessInsuranceCover.aspx?Type=pnlBuzInsAbout"><span>1</span>Your business</a>
                            </li>
                            <li>
                                <a id="ancYourCover" runat="server" href="~/BusinessInsuranceCover.aspx?Type=pnlBuzInsCover"><span>2</span>Your Cover</a>
                            </li>
                            <li>
                                <%-- href="~/BusinessInsuranceCover.aspx?Type=pnlBuzInsResult" --%>
                                <a id="ancResult" runat="server"><span>3</span>Application</a>
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
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <h3>Which category describes your business best?</h3>
                                    <asp:DropDownList runat="server" CssClass="form-control txtBox_ofw" AutoPostBack="True" ID="ddlBICategory" OnSelectedIndexChanged="ddlBusinessType_OnSelectedIndexChanged" />


                                    <h3>What type of business do you want to insure?</h3>
                                    <asp:DropDownList runat="server" CssClass="form-control txtBox_ofw" ID="ddlBiCategoryDetail" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" InitialValue="-1" ControlToValidate="ddlBiCategoryDetail" ForeColor="Red"
                                        ErrorMessage="Please select your business category detail."
                                        Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>

                                    <h3>How many years have you been operating your business for? <span class="pull-right"><a href="#" title="Help">?</a></span></h3>
                                    <asp:DropDownList runat="server" ID="ddlBusinessAge" CssClass="form-control txtBox_ofw" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" InitialValue="-1" ControlToValidate="ddlBusinessAge" ForeColor="Red"
                                        ErrorMessage="Please select your business age."
                                        Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>

                                    <h3>Year wise turn over amount</h3>
                                    <asp:TextBox placeholder="Enter year wise turn over amount" TextMode="Number" runat="server" ID="txtYearWiseTurnOverAmt" CssClass="form-control txtBox_ofw"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtYearWiseTurnOverAmt" ForeColor="Red"
                                        ErrorMessage="Please enter year wise turn over amount."
                                        Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                    <%--  <h3>Please confirm your business address</h3>
                                    <asp:TextBox placeholder="Enter your business address" runat="server" ID="txtBusnessAddress" CssClass="form-control txtBox_ofw"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtBusnessAddress" ForeColor="Red"
                                        ErrorMessage="Please enter your business address."
                                        Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>--%>
                                    <p></p>
                                    <p></p>
                                </ContentTemplate>
                            </asp:UpdatePanel>
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
                            <div class="row">
                                <h3>What is your full name?</h3>
                                <div class="col-sm-6">
                                    <asp:TextBox placeholder="First Name" runat="server" ID="txtFirstName" CssClass="form-control txtBox_ofw"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ControlToValidate="txtFirstName" ForeColor="Red"
                                        ErrorMessage="Please enter your first name."
                                        Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-6">
                                    <asp:TextBox placeholder="Last Name" runat="server" ID="txtLastName" CssClass="form-control txtBox_ofw"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvLastName" runat="server" ControlToValidate="txtLastName" ForeColor="Red"
                                        ErrorMessage="Please enter your last name."
                                        Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div class="row">
                                <h3>Your gender:</h3>
                                <asp:RadioButtonList CssClass="radio" ID="rdGender" runat="server">
                                    <asp:ListItem Value="1" Text="Male" Selected="True"></asp:ListItem>
                                    <asp:ListItem Value="2" Text="Female"></asp:ListItem>
                                    <asp:ListItem Value="3" Text="Other"></asp:ListItem>
                                </asp:RadioButtonList>
                            </div>

                            <div class="row">
                                <h3>Your date of birth:<span class="pull-right"><a href="#" title="Help">?</a></span></h3>
                                <asp:RequiredFieldValidator ID="rfvDateOfBirth" runat="server" ControlToValidate="txtDateOfBirth" ForeColor="Red"
                                    ErrorMessage="Please enter your date of birth."
                                    Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                <div class="dateBox">
                                    <asp:TextBox placeholder="Select your date of birth..." runat="server" ID="txtDateOfBirth" CssClass="form-control txtBox_ofw"> </asp:TextBox>
                                </div>
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
                            <h3>Your email address:<span class="pull-right"><a href="#" title="Help">?</a></span></h3>
                            <asp:TextBox placeholder="Enter your email...." TextMode="Email" runat="server" ID="txtEmail" CssClass="form-control txtBox_ofw"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" ForeColor="Red"
                                ErrorMessage="Please enter your email."
                                Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                            <h3>Your phone number : (Optional)<span class="pull-right"><a href="#" title="Help">?</a></span></h3>
                            <asp:TextBox placeholder="Enter your phone no...." TextMode="Phone" runat="server" ID="txtPhoneNo" CssClass="form-control txtBox_ofw"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <p>If you'd like to receive other money saving ideas by email, phone or text from MoneySuperMarket, tick the boxes below.</p>
                            <div class="checkbox multiCkbox">
                                <div class="btn-group" data-toggle="buttons">
                                    <label class="btn btn-default" runat="server">
                                        <asp:CheckBox ID="chkConfByEmail" runat="server" />
                                        <span class="glyphicon glyphicon-ok"></span>
                                    </label>
                                    Email
                                </div>
                                <div class="btn-group" data-toggle="buttons">
                                    <label class="btn btn-default" runat="server">
                                        <asp:CheckBox ID="chkConfByPhone" runat="server" />
                                        <span class="glyphicon glyphicon-ok"></span>
                                    </label>
                                    Phone
                                </div>
                                <div class="btn-group" data-toggle="buttons">
                                    <label class="btn btn-default" runat="server">
                                        <asp:CheckBox ID="chkConfByText" runat="server" />
                                        <span class="glyphicon glyphicon-ok"></span>
                                    </label>
                                    Text
                                </div>
                            </div>
                            <p>
                                You can untick any of the boxes if you'd rather not receive money saving ideas. But don't worry - you'll still receive your top quotes in an email and a phone 
call from LifeSearch if you've filled in your phone number.
                            </p>
                            <asp:Label runat="server" ID="lblMessageTermsAndCondition"></asp:Label>
                            <div class="checkbox multiCkbox">
                                <div class="btn-group" data-toggle="buttons">
                                    <label class="btn btn-default" runat="server">
                                        <asp:CheckBox ID="chkTermsAndCondition" runat="server" />
                                        <span class="glyphicon glyphicon-ok"></span>
                                    </label>
                                    I agree to confirm my details fully with any insurer before purchasing any insurance policy from them and 
I have read and agree to the OiiO Mart.com terms & conditions and privacy  policy.
                                </div>
                            </div>

                            <br />
                        </div>
                    </div>
                </div>
                <div class="formTitel2">
                    <div class=" container">
                        <div class="row">
                            <div class="col-md-3 pull-right">
                                <asp:Button runat="server" CssClass="btn btn-primary seeResultsBtn" ID="btnAboutNextPage" ValidationGroup="gen" OnClick="btnAboutNextPage_OnClick" Text="Next step" />

                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>
            <asp:Panel ID="pnlBuzInsCover" runat="server">
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
                            <asp:DropDownList runat="server" ID="ddlIndemnityAmount" CssClass="form-control txtBox_ofw" />
                            <h3>Public liability</h3>
                            <p>Cover if you are blamed for an injury to a member of the public or damage to their property.</p>
                            <asp:DropDownList runat="server" ID="ddlPublicLiability" CssClass="form-control txtBox_ofw" />

                            <h3>Employers' liability</h3>
                            <p>Cover for up to 10 employees for work-related illness or injury. This is a legal requirement if you have employees.</p>
                            <asp:DropDownList runat="server" ID="ddlEmployerLiability" CssClass="form-control txtBox_ofw" />
                            <h3>Office equipment</h3>
                            <p>Insurance for your office equipment that remains in your office; such as printers, fax machines and filing cabinets. Select how much it would cost to replace all of your office equipment.</p>
                            <asp:DropDownList runat="server" ID="ddlOfficeEquipment" CssClass="form-control txtBox_ofw" />
                            <h3>Portable equipment</h3>
                            <p>
                                Insurance for your equipment that you can take with you when you leave your office; such as laptops, 
mobile phones, cameras or tools. Select how much it would cost to replace all of your portable equipment.
                            </p>
                            <asp:DropDownList runat="server" ID="ddlPortableEquipment" CssClass="form-control txtBox_ofw" />
                            <p></p>
                            <p></p>

                        </div>
                    </div>
                </div>

                <div class="formTitel2">
                    <div class=" container">
                        <div class="row">
                            <div class="col-md-3 pull-left">
                                <%--   <a href="<%=this.ResolveUrl("~/BusinessInsuranceCover.aspx?Type=pnlBuzInsAbout")%>" class="btn btn-primary seeResultsBtn">Next step</a>--%>
                                <asp:Button runat="server" CssClass="btn btn-primary seeResultsBtn" ID="btnCoverPreviousPage" OnClick="btnCoverPreviousPage_OnClick" Text="Previous step" />
                            </div>

                            <div class="col-md-3 pull-right">

                                <asp:Button runat="server" CssClass="btn btn-primary seeResultsBtn" ID="btnCoverNextPage" ValidationGroup="gen" OnClick="btnCoverNextPage_OnClick" Text="Next step" />
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>

            <asp:Panel ID="pnlBuzInsResult" runat="server">
                <div class="formTitel">
                    <div class=" container">
                        <div class="row">
                            <div class="col-md-12" style="text-align: center;">
                                <h2>Information received successfully</h2>
                                <h3>According to your provided information, insurance companies will contact with you shortly.</h3>
                                <h2>Thank you
                                </h2>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>
        </div>

    </section>


</asp:Content>

