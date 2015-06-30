<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ChannelInfoInsertUpdate.aspx.cs" Inherits="OMart.Web.AdminPanel.ChannelInfoInsertUpdate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AdminHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AdminContentPlaceHolder" runat="server">
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
                                <legend>Add/Edit Channel Info</legend>
                                <div class="col-xs-6">
                                    
                                    <br />
                                      <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="Label3" runat="server" CssClass="control-label">Serial No</asp:Label>
                                                <asp:TextBox ID="txtSerialNo" TextMode="Number" runat="server"  CssClass="form-control"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtSerialNo"  ForeColor="Red"
                                                    ErrorMessage="PLease enter Serial No."
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
                                                 <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNote" ForeColor="Red"
                                                    ErrorMessage="PLease enter Ending Amount"
                                                    Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>--%>
                                               
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="Label1" runat="server" CssClass="control-label">Contact Phone NO.</asp:Label>
                                                <asp:TextBox ID="txtContractPhone"  runat="server" CssClass="form-control"></asp:TextBox>
                                                 <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtContractPhone" ForeColor="Red"
                                                    ErrorMessage="PLease enter Duration."
                                                    Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>--%>
                                                
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="Label2" runat="server" CssClass="control-label">Address</asp:Label>
                                                <asp:TextBox ID="txtAddress"  runat="server" CssClass="form-control"></asp:TextBox>
                                                 <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtAddress" ForeColor="Red"
                                                    ErrorMessage="PLease enter APR."
                                                    Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>--%>
                                                 
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                   <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="Label5" runat="server" CssClass="control-label">Web Address</asp:Label>
                                                <asp:TextBox ID="txtWebAddress"  runat="server" CssClass="form-control"></asp:TextBox>
                                                 <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtWebAddress" ForeColor="Red"
                                                    ErrorMessage="PLease enter APR."
                                                    Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>--%>
                                                 
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

