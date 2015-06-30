<%@ Page Title="" Language="C#" MasterPageFile="~/OiiOInnerMasterPage.Master" AutoEventWireup="true" CodeBehind="CompetitionRegistrationPage.aspx.cs" Inherits="OB.Web.CompetitionRegistrationPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderInnerPage" runat="server">
    <section>
        <div class="row">



            <div class="row">
                <div class="col-xs-8">
                    <h2 style="font-family: 'Brush Script MT'; font-style: italic; text-align: left; font-variant: normal; color: #009900;">Be Registered for the Competition..!!</h2>
                </div>

                <div class="col-xs-4">
                    <br />
                    &nbsp; <a class="btn btn-danger" href="LoginPage">Registered Login</a>
                </div>

            </div>
            <br />
            <div class="row">
                <div class="form-group">
                    <asp:Label ID="lblUserRegistration" runat="server"></asp:Label>

                </div>
            </div>
            <br />

            <div class="row col-xs-12">

                <div runat="server" id="divUserDetails" class="well signpPageLeft">
                    <div class="formHeadBorder">
                        <div class="form-group">
                            <label class="oiioLbl" style="color: green;">Your Details</label>
                        </div>
                    </div>
                    <div style="margin-left: 10%">

                        <div class="row form-group">
                            <asp:Label runat="server" ID="lbContestantName"></asp:Label>
                        </div>
                        <div class="row form-group ">
                            <asp:Label runat="server" ID="lbContestantEmail"></asp:Label>
                        </div>
                        <div class="row form-group">
                            <asp:Label runat="server" ID="lbContestantProfession"></asp:Label>
                        </div>
                        <div class="row form-group ">
                            <asp:Label runat="server" ID="lbContestantPhoneNo"></asp:Label>
                        </div>
                    </div>


                </div>

                <div runat="server" id="divUserSignUpForm" class="well signpPageLeft">
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
                                <span class="">First Name(Optional)</span>
                                <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control oiioFcnt"></asp:TextBox>
                                <%-- <asp:RequiredFieldValidator ID="rbfFirstName" runat="server" ControlToValidate="txtFirstName" ForeColor="Red"
                                                ErrorMessage="Please enter your first name."
                                                Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                            <asp:Label ID="lblFirstName" runat="server"></asp:Label>--%>
                            </div>

                        </div>

                        <div class="col-sm-6 col-md-6">
                            <div class="form-group">
                                <span class="">Last Name(Optional)</span>
                                <asp:TextBox ID="txtLastname" runat="server" CssClass="form-control oiioFcnt"></asp:TextBox>
                                <%--<asp:RequiredFieldValidator ID="rbfLastName" runat="server" ControlToValidate="txtLastname" ForeColor="Red"
                                                ToolTip="Please enter your last name." ErrorMessage="Please enter your last name.." Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                            <asp:Label ID="lblLastName" runat="server"></asp:Label>--%>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group">
                            <div class="col-sm-9 col-md-9">
                                <asp:Label ID="lblCode" runat="server" CssClass="control-label">Profession</asp:Label>

                                <asp:DropDownList ID="DropDownProfessionType" runat="server" Height="100%" class="form-control">
                                </asp:DropDownList>

                                <asp:RequiredFieldValidator InitialValue="-1" ID="RequiredFieldValidator4" runat="server" ControlToValidate="DropDownProfessionType" ForeColor="Red"
                                    ErrorMessage="Please select Profession."
                                    Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>

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
                                <asp:Label ID="lblMobileNo" runat="server" CssClass="control-label">Phone Number(Optional)</asp:Label>
                                <asp:TextBox ID="txtContactNo" runat="server" CssClass="form-control"></asp:TextBox>

                                <asp:Label ID="lblMoile" runat="server"></asp:Label>
                                <span class="help-block"></span>
                            </div>
                        </div>
                    </div>

                    <%--

                                <div class="checkbox multiCkbox">
                                    <p class="help-block">(if any promotion, please check any of the following.)</p>
                                    <div class="btn-group" data-toggle="buttons">
                                        <label class="btn btn-default" runat="server">
                                            <asp:CheckBox ID="chkEmail" runat="server" />
                                            <span class="glyphicon glyphicon-ok"></span>
                                        </label>
                                        Email
                                    </div>
                                </div>--%>



                    <div class="row">
                        <p class="help-block">(if any promotion, please check any of the following.)</p>
                        <div class="form-group">
                            <div class="col-sm-9 col-md-9">
                                <asp:CheckBox ID="chkEmail" runat="server" />
                                <label class="" runat="server">
                                    Email
                                </label>
                            </div>
                        </div>
                    </div>



                </div>

                <div class="well signpPageLeft">
                    <div class="formHeadBorder">
                        <div class="form-group">
                            <label class="oiioLbl" style="color: green;">Competetion Registration</label>

                            <label class="oiioLbl pull-right">Required*</label>
                        </div>
                        <asp:HiddenField runat="server" ID="HiddenField1" />
                    </div>
                    <div class="row">
                        <div class="form-group">
                            <div class="col-sm-9 col-md-9">
                                <asp:Label ID="Label8" runat="server" CssClass="control-label">Upload file</asp:Label>
                                <asp:FileUpload ID="fuCompContestantFile" runat="server" CssClass="form-control"></asp:FileUpload>
                            </div>
                        </div>
                    </div>
                    <hr />
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-danger" OnClick="btnCancel_Click" />

                    <asp:Button ID="btn_CreateAccountAndRegisterCompetetion" runat="server" class="btn btn-primary  pull-right" Text="Create account and complete registration"
                        ValidationGroup="gen" OnClick="btn_CreateAccountAndRegisterCompetetion_Click"></asp:Button>

                </div>
                <div>
                    <asp:Label ID="lblMessage" runat="server"></asp:Label>
                </div>
            </div>


        </div>
    </section>
</asp:Content>
