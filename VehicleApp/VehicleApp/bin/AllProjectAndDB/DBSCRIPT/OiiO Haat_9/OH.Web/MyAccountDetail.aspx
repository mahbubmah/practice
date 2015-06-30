<%@ Page Title="My account details" Language="C#" MasterPageFile="~/InnerMasterPage.Master" AutoEventWireup="true" CodeBehind="MyAccountDetail.aspx.cs" Inherits="OH.Web.MyAccountDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headInner" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentInnerMain" runat="server">
    <section>
        <div class="container postanAD">
            <div class="row">
                <div class="col-md-12">
                    <div class="formHeadBorder">
                        <asp:Label ID="lblAccountdetails" runat="server" Text=""></asp:Label>
                        <div class="form-group">
                            <h3>My account details</h3>
                        </div>

                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-12">
                    <div class="manageAdd accountDetails">
                        <div class="panel-group" id="accordion">
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <h3 class="panel-title">
                                        <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href="#collapseOne">
                                            <span class="glyphicon glyphicon-minus pull-right "></span>
                                            Update contact details
                                        </a>
                                    </h3>
                                </div>
                                <div id="collapseOne" class="panel-collapse collapse in">
                                    <div class="panel-body">
                                        <div class="form-group">
                                            <div class="col-xs-3">
                                                <span> <label for="fName">First name: </label>
                                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                                        ControlToValidate="txtfName" ForeColor="Red"
                                                        ToolTip="*" Display="Dynamic" ValidationGroup="accName" ErrorMessage="Enter First Name...">*</asp:RequiredFieldValidator>
                                                </span>
                                                <asp:TextBox ID="txtfName" runat="server" placeholder="First Name" class="form-control"></asp:TextBox>
                                                
                                                <span>  <label for="fName">Contact number: </label>
                                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                                        ControlToValidate="txtpNo" ForeColor="Red"
                                                        ToolTip="*" Display="Dynamic" ValidationGroup="accName" ErrorMessage="Enter Phone No...">*</asp:RequiredFieldValidator>
                                                </span>
                                                <asp:TextBox ID="txtpNo" runat="server" placeholder="017xx xxxxxx" class="form-control" ValidationGroup="accName"></asp:TextBox>
                                            </div>
                                            <div class="col-xs-3">
                                                <span> <label for="lName">Last name: </label>
                                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                                                        ControlToValidate="txtlName" ForeColor="Red"
                                                        ToolTip="*" Display="Dynamic" ValidationGroup="accName" ErrorMessage="Enter Last Name...">*</asp:RequiredFieldValidator>
                                                </span>
                                                
                                              
                                                <asp:TextBox ID="txtlName" runat="server" placeholder="Last Name" class="form-control" ValidationGroup="accName"></asp:TextBox>
                                            </div>
                                            <div class="clearfix"></div>
                                        </div>
                                        <div class="col-xs-3">
                                         
                                            <asp:Button ID="btnSaveChanges" runat="server" Text="Save changes" ValidationGroup="accName" class="btn btn-primary form-control sbtBtn" OnClick="btnSaveChanges_Click" />
                                        </div>


                                    </div>
                                </div>
                                 <asp:ValidationSummary
                                        ShowMessageBox="true"
                                        ShowSummary="false"
                                        HeaderText="You must enter a value in the following fields:"
                                        EnableClientScript="true"
                                        runat="server" ValidationGroup="accName" />
                            </div>
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <h3 class="panel-title">
                                        <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href="#collapseTwo">
                                            <span class="glyphicon glyphicon-plus pull-right "></span>
                                            Change password
                                        </a>
                                    </h3>
                                </div>
                                <div id="collapseTwo" class="panel-collapse collapse">
                                    <div class="panel-body">

                                        <div class="form-group">
                                            <div class="col-xs-3">
                                                <span>
                                                    <label for="fName">Current password: </label>
                                                    <asp:RequiredFieldValidator ID="rfvCurrentPass" runat="server"
                                                        ControlToValidate="txtCurrentPass" ForeColor="Red"
                                                        ToolTip="*" Display="Dynamic" ValidationGroup="accPass" ErrorMessage="Enter Current Password...">*</asp:RequiredFieldValidator>
                                                </span>

                                               
                                                <asp:TextBox ID="txtCurrentPass" runat="server" placeholder="Current password" class="form-control" TextMode="Password"></asp:TextBox>

                                            </div>

                                            <div class="clearfix"></div>
                                        </div>
                                        <div class="form-group">
                                            <div class="col-xs-3">
                                                <span>
                                                    <label for="pwd">New password: </label>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                                        ControlToValidate="txtNewPass" ForeColor="Red"
                                                        ToolTip="*" Display="Dynamic" ValidationGroup="accPass" ErrorMessage="Enter New Password...">*</asp:RequiredFieldValidator>
                                                </span>

                                               
                                                <asp:TextBox ID="txtNewPass" runat="server" placeholder="New password" class="form-control" TextMode="Password"></asp:TextBox>

                                            </div>

                                            <div class="col-xs-3">
                                                <span>
                                                    <label for="fName">Confirm password: </label>

                                                 
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                                        ControlToValidate="txtConfirmPassword" ForeColor="Red"
                                                        ToolTip="*" Display="Dynamic" ValidationGroup="accPass" ErrorMessage="Enter Password Again...">*</asp:RequiredFieldValidator>
                                                  
                                                </span>


                                                <asp:TextBox ID="txtConfirmPassword" runat="server" placeholder="Confirm password" class="form-control" ValidationGroup="accPass" TextMode="Password"></asp:TextBox>
                                                  <asp:CompareValidator ID="cmpPass" runat="server" ForeColor="Red" ErrorMessage="Password Do not Match" ControlToValidate="txtConfirmPassword" ControlToCompare="txtNewPass" ValidationGroup="accPass"></asp:CompareValidator>
                                            </div>
                                            <div class="clearfix"></div>
                                        </div>
                                        <div class="col-xs-3">
                                            
                                            <asp:Button ID="btnChngPass" runat="server" Text="Save changes" ValidationGroup="accPass" class="btn btn-primary form-control sbtBtn" OnClick="btnChngPass_Click" />
                                        </div>
                                    </div>
                                    <asp:ValidationSummary
                                        ShowMessageBox="true"
                                        ShowSummary="false"
                                        HeaderText="You must enter a value in the following fields:"
                                        EnableClientScript="true"
                                        runat="server" ValidationGroup="accPass" />
                                </div>
                            </div>
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <h3 class="panel-title">
                                        <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href="#collapseThree">
                                            <span class="glyphicon glyphicon-plus pull-right "></span>
                                            Deactivate account
                                        </a>
                                    </h3>
                                </div>
                                <div id="collapseThree" class="panel-collapse collapse">
                                    <div class="panel-body">
                                        <h4>Please don’t leave us!</h4>
                                        <p>Every time an account is deactivated, one of the team cries and it takes hours to get them talking again :(</p>
                                        <p>If you ‘re really sure...</p>
                                        <p>Please help us improve OiiO haat by letting us know why you’re leaving:</p>

                                        <div class="form-group">
                                            <asp:DropDownList ID="ddlLeavingCause" runat="server" CssClass="form-control">
                                            </asp:DropDownList>
                                        </div>
                                        <div class="form-group">
                                            <label for="fName">Comments</label>
                                            <asp:TextBox ID="txtComment" runat="server" class="col-sm-6 form-control" rows="3" TextMode="MultiLine"></asp:TextBox>
                                            <span><asp:RequiredFieldValidator ID="RequiredFieldValidatoComment" runat="server"
                                                        ControlToValidate="txtComment" ForeColor="Red"
                                                        ToolTip="*" Display="Dynamic"  ErrorMessage="Leave a Comment" ValidationGroup="accDeactive">*</asp:RequiredFieldValidator></span>
                                        <asp:ValidationSummary
                                        ShowMessageBox="true"
                                        ShowSummary="false"
                                        HeaderText="You must enter a value in the following fields:"
                                        EnableClientScript="true"
                                        runat="server" ValidationGroup="accDeactive" />
                                        <div class="clearfix"></div>
                                        </div>
                                        <asp:Button ID="btnDeactive" runat="server" Text="Deactivate My Account" class="btn btn-primary sbtBtn" ValidationGroup="accDeactive" OnClick="btnDeactive_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>



                    </div>
                </div>
            </div>


        </div>
    </section>
</asp:Content>
