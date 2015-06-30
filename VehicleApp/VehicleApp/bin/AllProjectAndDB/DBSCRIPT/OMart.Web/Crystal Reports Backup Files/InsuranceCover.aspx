<%@ Page Title="" Language="C#" MasterPageFile="~/InsuranceMaster.Master" AutoEventWireup="true" CodeBehind="InsuranceCover.aspx.cs" Inherits="OMart.Web.InsuranceCover" %>

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
                                <a class="active" href="InsuranceCover.aspx"><span>1</span>Cover required</a>
                            </li>
                            <li>
                                <a href="#"><span>2</span>Your  quotes</a>
                            </li>
                            <li>
                                <a href="#"><span>3</span>Application</a>
                            </li>
                            <li>
                                <a href="#"><span>4</span>Confirmation</a>
                            </li>

                        </ul>
                    </div>
                    <!-- /.navbar-collapse -->
                </div>
                <!-- /.container -->
            </nav>

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
                            <h3>How much cover do you need?<span class="pull-right"><a href="#" title="Help">?</a></span></h3>
                            <p>This is the amount the policy will pay out in the event of a claim.</p>


                            <asp:TextBox runat="server" TextMode="Number" ID="txtCoverMoney" CssClass="form-control txtBox_ofw" placeholder="Enter amount"></asp:TextBox>


                            <asp:RequiredFieldValidator ID="rfvCoverMoney" runat="server" ControlToValidate="txtCoverMoney" ForeColor="Red"
                                ErrorMessage="Please enter cover money."
                                Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                        </div>


                        <div class="row">
                            <h3>How long do you need your policy to last?<span class="pull-right"><a href="#" title="Help">?</a></span></h3>
                            <p>This is the number of years you will be protected by the policy.</p>


                            <asp:TextBox runat="server" TextMode="Number" ID="txtNumberOfYear" CssClass="form-control txtBox_ofw" placeholder="Enter no. of years"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvNumberOfYear" runat="server" ControlToValidate="txtNumberOfYear" ForeColor="Red"
                                ErrorMessage="Please enter no. of year."
                                Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                        </div>

                        <div class="row">
                            <h3>Do you want to include critical illness cover?<span class="pull-right"><a href="#" title="Help">?</a></span></h3>


                            <asp:RadioButtonList CssClass="radio" ID="rdCrIll" runat="server">
                                <asp:ListItem Value="1" Text="Yes"></asp:ListItem>
                                <asp:ListItem Value="0" Text="No" Selected="True"></asp:ListItem>
                            </asp:RadioButtonList>
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
                                <asp:TextBox placeholder="Select your date of birth..." runat="server"  ID="txtDateOfBirth" CssClass="form-control txtBox_ofw"> </asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator ID="rfvDateOfBirth" runat="server" ControlToValidate="txtDateOfBirth" ForeColor="Red"
                                ErrorMessage="Please enter your date of birth."
                                Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                        </div>


                        <div class="row">
                            <h3>Your profession</h3>
                            <div>
                                <asp:DropDownList CssClass="form-control txtBox_ofw" runat="server" ID="dropDownProfession" />
                                <asp:RequiredFieldValidator InitialValue="-1" ID="rfvProfession" runat="server" ControlToValidate="dropDownProfession" ForeColor="Red"
                                    ErrorMessage="Please select your profession."
                                    Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="row">
                            <h3>Do you have additional job ?</h3>
                            <asp:RadioButtonList CssClass="radio" ID="rdHaveAdditionalJob" runat="server">
                                <asp:ListItem Value="1" Text="Yes"></asp:ListItem>
                                <asp:ListItem Value="0" Text="No" Selected="True"></asp:ListItem>
                            </asp:RadioButtonList>
                        </div>




                        <div class="row">
                            <h3>Do you smoke?<span class="pull-right"><a href="#" title="Help">?</a></span></h3>

                            <asp:DropDownList CssClass="form-control txtBox_ofw" runat="server" ID="dropDownIsSmoke" />
                            <asp:RequiredFieldValidator InitialValue="-1" ID="rfvSmokerType" runat="server" ControlToValidate="dropDownIsSmoke" ForeColor="Red"
                                ErrorMessage="This field is required"
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

                        <asp:TextBox placeholder="Enter your email...."  runat="server" ID="txtEmail" CssClass="form-control txtBox_ofw"></asp:TextBox>
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
                    </div>
                </div>
            </div>

            <div class="formTitel2">
                <div class=" container">
                    <div class="row">
                        <div class="col-md-3 pull-right">
                            <asp:Button runat="server" ValidationGroup="gen" CssClass="btn btn-primary seeResultsBtn" Text="See Results" ID="btnShowResult" OnClick="btnShowResult_OnClick" />
                            <%-- <a href="InsuranceQuotes.aspx" class="btn btn-primary seeResultsBtn">See Results</a>--%>
                        </div>
                    </div>
                </div>

            </div>
        </div>

    </section>

</asp:Content>

