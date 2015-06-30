<%@ Page Title="" Language="C#" MasterPageFile="~/LoginMaster.Master" AutoEventWireup="true" CodeBehind="UserRegistrationPage.aspx.cs" Inherits="OB.Web.UserRegistrationPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AdminHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
        <div class="row">
            <br />
            <br />
            <div class="mainpageBody">
                <div class="container signpPage">
                    <div class="row">
                        <div class="col-md-12">
                            <h2 style="font-family: 'Brush Script MT'; font-style: italic; text-align: center; font-variant: normal; color: #009900;">Create an Account</h2>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="form-group">
                            <asp:Label ID="lblUserRegistration" runat="server"></asp:Label>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-xs-6">
                            <div class="well signpPageLeft">
                                <div class="formHeadBorder">
                                    <div class="form-group">
                                        <label class="oiioLbl" style="color: green;">Your Details</label>

                                        <label class="oiioLbl pull-right">Required*</label>
                                    </div>
                                    <asp:HiddenField runat="server" ID="hdUserRegitrationID" />
                                </div>

                                <div class="row">
                                    <div class="col-sm-6 col-md-6">
                                        <div class="form-group">
                                            <span class="">First Name*</span>
                                            <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control oiioFcnt"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rbfFirstName" runat="server" ControlToValidate="txtFirstName" ForeColor="Red"
                                                ErrorMessage="PLease enter your first name."
                                                Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                            <asp:Label ID="lblFirstName" runat="server"></asp:Label>
                                        </div>

                                    </div>

                                    <div class="col-sm-6 col-md-6">
                                        <div class="form-group">
                                            <span class="">Last Name*</span>
                                            <asp:TextBox ID="txtLastname" runat="server" CssClass="form-control oiioFcnt"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rbfLastName" runat="server" ControlToValidate="txtLastname" ForeColor="Red"
                                                ToolTip="PLease enter your last name." ErrorMessage="PLease enter your last name.." Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                            <asp:Label ID="lblLastName" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                </div>

                                <br />
                                <div class="row">
                                    <div class="form-group">
                                        <div class="col-sm-9 col-md-9">
                                            <asp:Label ID="lblEmailAdd" runat="server" class="control-label">Email Address*</asp:Label>
                                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="example@gmail.com"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rbfEmail" runat="server" ControlToValidate="txtEmail"
                                                ForeColor="Red" ToolTip="Please enter your email" ErrorMessage="Please enter your email." Display="Dynamic" ValidationGroup="gen">
                                            </asp:RequiredFieldValidator>

                                            <asp:Label ID="lblEmail" runat="server">
                                                <asp:RegularExpressionValidator ID="rxvEmail" runat="server"
                                                    ErrorMessage="Please enter valid email." ControlToValidate="txtEmail" Display="Dynamic"
                                                    ValidationExpression="[-0-9a-zA-Z.+_]+@[-0-9a-zA-Z.+_]+\.[a-zA-Z]{2,4}"
                                                    ForeColor="Red" ValidationGroup="gen">
                                                </asp:RegularExpressionValidator>
                                            </asp:Label>
                                            <span class="help-block"></span>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <div class="col-sm-9 col-md-9">
                                            <asp:Label ID="lblConEmailAdd" runat="server" class="control-label">Confirm Email Address*</asp:Label>
                                            <asp:TextBox ID="txtConEmailAdd" runat="server" CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvConfirmEmail" runat="server" ControlToValidate="txtConEmailAdd"
                                                ForeColor="Red" ToolTip="Please confirm your email" Display="Dynamic" ErrorMessage="Please confirm your email"
                                                ValidationGroup="gen"></asp:RequiredFieldValidator>

                                            <asp:Label ID="lblConfirmEmail" runat="server">
                                                <asp:CompareValidator ID="cvConfirmEmail" runat="server" ErrorMessage="E-mail do not match!"
                                                    ControlToValidate="txtConEmailAdd" ControlToCompare="txtEmail"
                                                    Display="Dynamic" ForeColor="Red" ValidationGroup="gen"></asp:CompareValidator>
                                            </asp:Label>

                                            <span class="help-block"></span>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="form-group">
                                        <div class="col-sm-9 col-md-9">
                                            <asp:Label ID="lblPassword" runat="server" CssClass="control-label">Password*</asp:Label>
                                            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rbfPassword" runat="server" ControlToValidate="txtPassword"
                                                ErrorMessage="Please enter your password" ForeColor="Red" ToolTip="Please enter your password" Display="Dynamic"
                                                ValidationGroup="gen"></asp:RequiredFieldValidator>
                                            <asp:Label ID="lblPass" runat="server"></asp:Label>
                                            <span class="help-block"></span>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <div class="col-sm-9 col-md-9">
                                            <asp:Label ID="lblConfirmpassword" runat="server" CssClass="control-label">Confirm Password*</asp:Label>
                                            <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>

                                            <asp:RequiredFieldValidator ID="rbfConfirmPassword" runat="server" ControlToValidate="txtConfirmPassword"
                                                ForeColor="Red" ErrorMessage="Please enter your confirm password" ToolTip="Please enter your confirm password"
                                                Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>


                                            <asp:Label ID="lblConPass" runat="server">
                                                <asp:CompareValidator ID="cvConfirmPassword" runat="server" ErrorMessage="Password do not match!"
                                                    ControlToValidate="txtConfirmPassword" ControlToCompare="txtPassword"
                                                    Display="Dynamic" ForeColor="Red" ValidationGroup="gen"></asp:CompareValidator>
                                            </asp:Label>
                                            <span class="help-block"></span>
                                        </div>
                                    </div>
                                </div>
                                <br />

                                <div class="row">
                                    <div class="form-group">
                                        <div class="col-sm-9 col-md-9">
                                            <asp:Label ID="lblMobileNo" runat="server" CssClass="control-label">Phone Number</asp:Label>
                                            <asp:TextBox ID="txtContactNo" runat="server" CssClass="form-control"></asp:TextBox>

                                            <asp:Label ID="lblMoile" runat="server"></asp:Label>
                                            <span class="help-block"></span>
                                        </div>
                                    </div>
                                </div>
                                <div class="checkbox multiCkbox">
                                    <div class="btn-group" data-toggle="buttons">
                                        <label class="btn btn-default" runat="server">
                                            <asp:CheckBox ID="chkConfByEmail" runat="server" />
                                            <span class="glyphicon glyphicon-ok"></span>
                                        </label>
                                        Email
                                    </div>

                                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-danger" OnClick="btnCancel_Click" />

                                    <asp:Button ID="btn_CreateAccount" runat="server" class="btn btn-primary  pull-right" Text="Create An Account"
                                        ValidationGroup="gen" OnClick="btn_CreateAccount_Click"></asp:Button>

                                </div>
                                <div>
                                    <asp:Label ID="lblMessage" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="col-xs-6">
                                <div class="well signpPageRight">
                                    <p class="lead">Get the most form your  <span style="color: green;">OiiO Book </span>account</p>
                                    <ul class="list-unstyled" style="line-height: 2">
                                        <li><span class="fa fa-folder-open text-danger1"></span>With a OiiO Book account, you can manage all your ads in one place.</li>
                                        <li><span class="fa fa-pencil-square-o text-danger1"></span>Posting ads is faster and easier with pre-filled contact information.</li>
                                        <li><span class="fa fa-signal text-danger1"></span>Ad stats show you how many people have viewed and replied to your ads.</li>

                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
    </section>
</asp:Content>
