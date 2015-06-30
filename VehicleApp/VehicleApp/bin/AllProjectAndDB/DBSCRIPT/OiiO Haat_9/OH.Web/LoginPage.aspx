<%@ Page Title="Log in" Language="C#" MasterPageFile="~/DefaultMaster.Master" AutoEventWireup="true"
    CodeBehind="LoginPage.aspx.cs" Inherits="OH.Web.LoginPage" Async="true" %>



<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

    <style type="text/css">
        .panel-heading {
            padding: 5px 15px;
        }

        .panel-footer {
            padding: 1px 15px;
            color: #A0A0A0;
        }

        .profile-img {
            width: 96px;
            height: 96px;
            margin: 0 auto 10px;
            display: block;
            -moz-border-radius: 50%;
            -webkit-border-radius: 50%;
            border-radius: 50%;
        }
    </style>

    <div class="container" style="margin-top: 40px">

        <div class="row">
            <div class="col-sm-6 col-md-4 col-md-offset-4">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <strong>Sign in to continue</strong>
                    </div>
                    <div class="panel-body">
                        <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                            <p class="text-danger">
                                <asp:Literal runat="server" ID="FailureText" />
                            </p>
                        </asp:PlaceHolder>
                        <asp:Panel runat="server" DefaultButton="btnlogin">
                        <fieldset>
                            <div class="row">
                                <div class="center-block">
                                   <%-- <img  runat="server" id=""
                                        src="fonts/LoginLogo.jpg" alt="" />--%>
                                    <asp:Image ID="loginLogoImg" runat="server" class="profile-img"/>
                                </div>
                            </div>
                            <div class="row">


                                <div class="col-sm-12 col-md-10  col-md-offset-1 ">
                                    <div class="form-group">
                                        <div class="input-group">
                                            <span class="input-group-addon">
                                                <i class="glyphicon glyphicon-user"></i>

                                                <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName"
                                                    CssClass="text-danger" ErrorMessage="*" />
                                            </span>
                                            <asp:TextBox ID="UserName" runat="server" class="form-control" ValidationGroup="enter" placeholder="Username" name="loginname" type="text" autofocus="autofocus" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="input-group">
                                            <span class="input-group-addon">
                                                <i class="glyphicon glyphicon-lock"></i>

                                                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="text-danger" ErrorMessage="*" />
                                            </span>
                                            <asp:TextBox ID="Password" runat="server"  class="form-control" ValidationGroup="enter" placeholder="Password" name="password"  type="password" value=""  AutoComplete="off" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="checkbox">
                                            <label>
                                                <asp:CheckBox runat="server" ID="RememberMe" />
                                                <asp:Label runat="server" AssociatedControlID="RememberMe">Remember me?</asp:Label>
                                            </label>
                                        </div>
                                        <!-- /.checkbox -->
                                    </div>
                                    <div class="form-group">                                        
                                        <asp:Button ID="btnlogin" runat="server" OnClick="LogIn" Text="Log in" ValidationGroup="enter"  CssClass="btn btn-lg btn-primary btn-block" />
                                    </div>
                                </div>


                            </div>
                        </fieldset>
                            </asp:Panel>

                    </div>
                    <div class="panel-footer ">
                        <p>
                           <%-- <asp:HyperLink runat="server" ID="RegisterHyperLink" ViewStateMode="Enabled">Register</asp:HyperLink>--%>
                            <a runat="server" id="hrfRegister" style="color:red;" href="UserRegistrationPage">Register</a>
                            if you don't have an account.
                        </p>
                    </div>
                </div>
            </div>
           
        </div>
    </div>
</asp:Content>
