<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultMaster.Master" AutoEventWireup="true" CodeBehind="ReportingPage.aspx.cs" Inherits="OH.Web.ReportingPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section>
        <div class="container">
            <fieldset style="margin: 10px auto;">
                <legend>Have any issue ?</legend>
                <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                <div class="row">
                    <div class="col-sm-5 col-md-5 col-lg-5">
                        <div class="form-group">
                            <div class="input-group">
                                <span class="input-group-addon">Cause
                                      <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCauses"
                                          CssClass="text-danger" ErrorMessage="*" ValidationGroup="vGSubmit" />
                                </span>
                                <asp:TextBox ID="txtCauses" runat="server" Text="" class="form-control"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="input-group">
                                <span class="input-group-addon">Your email
                                             <asp:RequiredFieldValidator runat="server" ControlToValidate="txtEmail" CssClass="text-danger" ErrorMessage="*" ValidationGroup="vGSubmit" />
                                </span>
                                <asp:TextBox ID="txtEmail" runat="server" Text="" class="form-control" placeholder="Your email..."></asp:TextBox>
                                <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidatorForEmail"
                                    SetFocusOnError="true" Text="Example: username@gmail.com" ControlToValidate="txtEmail"
                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic"
                                    ValidationGroup="vGSubmit" /><br />


                            </div>
                        </div>

                        <div class="form-group">
                            <div class="input-group">
                                <span class="input-group-addon">Comments
                                          <asp:RequiredFieldValidator runat="server" ControlToValidate="txtComments" CssClass="text-danger" ErrorMessage="*" ValidationGroup="vGSubmit" />
                                </span>
                                <asp:TextBox ID="txtComments" runat="server" Text="" TextMode="MultiLine" class="form-control" Height="55px" placeholder="Comments..."></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group pull-right">
                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" CssClass="btn btn-primary" ValidationGroup="vGSubmit"></asp:Button>
                            <asp:ValidationSummary
                                ShowMessageBox="true"
                                ShowSummary="false"
                                HeaderText="You must enter a value in the following fields:"
                                EnableClientScript="true"
                                runat="server" ValidationGroup="vGSubmit" />
                        </div>
                    </div>
                </div>
            </fieldset>
        </div>
    </section>
</asp:Content>
