<%@ Page Title="" Language="C#" MasterPageFile="~/InsuranceMaster.Master" AutoEventWireup="true" CodeBehind="HomeInsuranceCover.aspx.cs" Inherits="OMart.Web.HomeInsuranceCover" %>

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
            $("#<%=txtConsDate.ClientID%>").datepicker({
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
                                <a class="active" runat="server" id="ancCover" href="HomeInsuranceCover.aspx?Type=pnlHomeInsCover"><span>1</span>Cover required</a>
                            </li>
                            <li>
                                <a href="#" runat="server" id="ancResult"><span>2</span>Result</a>
                            </li>
                        </ul>
                    </div>
                    <!-- /.navbar-collapse -->
                </div>
                <!-- /.container -->
            </nav>

            <asp:Panel ID="pnlHomeInsCover" runat="server">
                <div class="formTitel">
                    <div class=" container">
                        <div class="row">
                            <div class="col-md-12">
                                <h2>Your cover</h2>
                            </div>
                        </div>
                    </div>
                </div>
                <asp:Label runat="server" ID="lblMessage"></asp:Label>
                <div class="container">
                    <div class="row">
                        <div class="col-xs-12 col-sm-12 col-md-6 col-lg-6">
                            <div class="row">

                                <h3>Number of floor<span class="pull-right"><a href="#" title="Help">?</a></span></h3>
                                <asp:TextBox runat="server" TextMode="Number" ID="txtNumberOfFloor" CssClass="form-control txtBox_ofw" placeholder="Enter number of floor"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvCoverMoney" runat="server" ControlToValidate="txtNumberOfFloor" ForeColor="Red"
                                    ErrorMessage="Please enter total number of floor"
                                    Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                            </div>
                            <div class="row">
                                <h3>Floor size<span class="pull-right"><a href="#" title="Help">?</a></span></h3>
                                <asp:TextBox runat="server" TextMode="Number" ID="txtFloorSize" CssClass="form-control txtBox_ofw" placeholder="Enter floor size"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFloorSize" ForeColor="Red"
                                    ErrorMessage="Please enter floor size."
                                    Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                <asp:DropDownList CssClass="form-control txtBox_ofw" runat="server" ID="ddlFloorSizeUnit" />
                            </div>
                            <div class="row">
                                <h3>Parking space size (Optional)</h3>
                                <asp:TextBox runat="server" TextMode="Number" ID="txtParkingSpaceSize" CssClass="form-control txtBox_ofw" placeholder="Enter parking space size"></asp:TextBox>

                                <asp:DropDownList CssClass="form-control txtBox_ofw" runat="server" ID="ddlParkingSpageSizeUnit" />
                            </div>
                            <div class="row">
                                <h3>Number of room per floor (Optional)</h3>
                                <asp:TextBox runat="server" TextMode="Number" ID="txtNumberOfRoomPerFloor" CssClass="form-control txtBox_ofw" placeholder="Enter number of floor"></asp:TextBox>

                            </div>
                            <div class="row">
                                <h3>Address of building</h3>
                                <asp:TextBox runat="server" TextMode="MultiLine" CssClass="form-control txtBox_ofw" ID="txtAddressOfBuilding" placeholder="Enter Address of building"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtAddressOfBuilding" ForeColor="Red"
                                    ErrorMessage="Please enter parking space size."
                                    Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                            </div>
                            <div class="row">
                                <h3>Power supply type (Optional)</h3>
                                <asp:DropDownList runat="server" ID="ddlPowerSupplyType" CssClass="form-control txtBox_ofw" />
                            </div>
                            <div class="row">
                                <h3>Gas supply type (Optional)</h3>
                                <asp:DropDownList runat="server" ID="ddlGasSupplyType" CssClass="form-control txtBox_ofw" />
                            </div>
                            <div class="row">
                                <h3>Water supply type (Optional)</h3>
                                <asp:DropDownList runat="server" ID="ddlWaterSupplyType" CssClass="form-control txtBox_ofw" />
                            </div>
                            <div class="row">
                                <h3>Construction date</h3>
                                <asp:TextBox runat="server" ID="txtConsDate" CssClass="form-control txtBox_ofw" placeholder="Enter construction finishing year" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtConsDate" ForeColor="Red"
                                    ErrorMessage="Please enter construction finishing year"
                                    Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                            </div>
                            <div class="row">
                                <h3>Estimated price (Optional)</h3>
                                <asp:TextBox runat="server" TextMode="Number" ID="txtEstimatedPrice" CssClass="form-control txtBox_ofw" placeholder="Enter an estimated price"></asp:TextBox>
                            </div>
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
                                <div class="dateBox">
                                    <asp:TextBox placeholder="Select your date of birth..." runat="server" ID="txtDateOfBirth" CssClass="form-control txtBox_ofw"> </asp:TextBox>
                                </div>
                                <asp:RequiredFieldValidator ID="rfvDateOfBirth" runat="server" ControlToValidate="txtDateOfBirth" ForeColor="Red"
                                    ErrorMessage="Please enter your date of birth."
                                    Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
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
                            <asp:TextBox placeholder="Enter your email...." runat="server" ID="txtEmail" CssClass="form-control txtBox_ofw"></asp:TextBox>
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
                                <asp:Button runat="server" ValidationGroup="gen" CssClass="btn btn-primary seeResultsBtn" Text="See Results" ID="btnShowResult" OnClick="btnShowResult_OnClick" />

                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>
            <asp:Panel runat="server" ID="pnlHomeInsResult">
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

