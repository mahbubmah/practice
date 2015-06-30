<%@ Page Title="" Language="C#" MasterPageFile="~/BookAdmin/OiiOMasterPage.Master" AutoEventWireup="true" CodeBehind="ProfessionInsertUpdate.aspx.cs" Inherits="OB.Web.BookAdmin.ProfessionInsertUpdate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <br />
    <section>
        <div class="container">
            <div class="row">
                <div class="col-sm-12">
                    <asp:Label ID="labelMessage" runat="server"></asp:Label>
                </div>
            </div>

            <div class="row">
                <div class="col-sm-12">
                    <div class="manageAdd">
                        <div class="addPostMang">
                            <fieldset class="adminFieldset">
                                <legend>Add/Edit Profession</legend>
                                <div class="col-xs-6">
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="lblCode" runat="server" CssClass="control-label">Type</asp:Label>

                                               <asp:DropDownList ID="DropDownType"  runat="server" Height="100%" class="form-control" 
                                                    ></asp:DropDownList>
                                                
                                                <asp:RequiredFieldValidator InitialValue="-1" ID="RequiredFieldValidator4" runat="server" ControlToValidate="DropDownType" ForeColor="Red"
                                                    ErrorMessage="Please select Type."
                                                    Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                                
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="lblLiSchemaName" runat="server" CssClass="control-label">Name</asp:Label>
                                                <asp:TextBox ID="txtName" runat="server"  CssClass="form-control"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rbfFirstName" runat="server" ControlToValidate="txtName"  ForeColor="Red"
                                                    ErrorMessage="PLease enter Name."
                                                    Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                                
                                                 </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="lblISDCode" runat="server" CssClass="control-label">Note</asp:Label>
                                                <asp:TextBox ID="txtNote"  runat="server" CssClass="form-control"></asp:TextBox>
                                                 
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    
                                    <div class="row login">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                               
                                                  <asp:CheckBox ID="chkIsRemoved" runat="server" CssClass=""></asp:CheckBox>
                                                <asp:Label ID="Label4" runat="server" CssClass="control-label">Is Removed</asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-danger" OnClick="btnCancel_Click" />

                                                <asp:Button ID="btn_CreateOrEdit" runat="server" class="btn btn-primary  pull-right" Text="Submit"
                                                    OnClick="btn_CreateOrEdit_Click" ValidationGroup="gen"></asp:Button>
                                            </div>
                                        </div>
                                    </div>



                                </div>
                            </fieldset>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
