<%@ Page Title="Car Insurance Quote" Language="C#" MasterPageFile="~/InsuranceMaster.Master" AutoEventWireup="true" CodeBehind="CarInsuranceQuote.aspx.cs" Inherits="OMart.Web.CarInsuranceQuote" %>

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
                            <br />
                            <div class="row">
                                <div class="form-group">
                                    <div class="col-sm-9 col-md-4">
                                        <asp:Label ID="lblCarType" runat="server" Text="Car Type">
                                            <asp:DropDownList ID="ddlCarType" runat="server" CssClass="form-control" AutoPostBack="true"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfvCountry" runat="server" ControlToValidate="ddlCarType" ForeColor="Red"
                                                ErrorMessage="Please select Car Type." InitialValue=""
                                                Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                        </asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group">
                                    <div class="col-sm-9 col-md-4">
                                        <asp:Label ID="lblCarCondition" runat="server" Text="Car Condition">
                                            <asp:DropDownList ID="ddlCarCondition" runat="server" CssClass="form-control" AutoPostBack="true"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlCarCondition" ForeColor="Red"
                                                ErrorMessage="Please select Car Condition." InitialValue=""
                                                Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                        </asp:Label>
                                    </div>
                                </div>
                            </div>

                        </div>


                        <div class="well oiioForm_a oiioForm_fcon">
                            <h3>Car Information</h3>
                            <div class="row">
                                <div class="form-group">
                                    <div class="col-sm-9 col-md-4">
                                        <asp:Label ID="lblCarRun" runat="server" Text="Car Run">
                                            <asp:TextBox ID="txtCarRun" runat="server" CssClass="form-control"></asp:TextBox>
                                        </asp:Label>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="form-group">
                                    <div class="col-sm-9 col-md-4">
                                        <asp:Label ID="lblCarAge" runat="server" Text="Car Age">
                                            <asp:TextBox ID="txtCarAge" runat="server" CssClass="form-control"></asp:TextBox>
                                        </asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group">
                                    <div class="col-sm-9 col-md-4">
                                        <asp:Label ID="lblCarValueAmount" runat="server" Text="Car Value Amount">
                                            <asp:TextBox ID="txtCarValueAmount" runat="server" CssClass="form-control"></asp:TextBox>
                                        </asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group">
                                    <div class="col-sm-9 col-md-4">
                                        <asp:Label ID="lblPremiumTotalPercent" runat="server" Text="Premium Total Percent">
                                            <asp:TextBox ID="txtPremiumTotalPercent" runat="server" CssClass="form-control"></asp:TextBox>
                                        </asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group">
                                    <div class="col-sm-9 col-md-4">
                                        <asp:Label ID="lbDuration" runat="server" Text="Duration">
                                            <asp:TextBox ID="txtDuration" runat="server" CssClass="form-control"></asp:TextBox>
                                        </asp:Label>
                                    </div>
                                </div>
                            </div>

                            <br />
                            <div class="row">
                                <div class="col-sm-2 pull-left">
                                    <asp:Button ID="btnFind" runat="server" Text="Find" CssClass="btn btn-primary" OnClick="btnFind_Click" />
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
