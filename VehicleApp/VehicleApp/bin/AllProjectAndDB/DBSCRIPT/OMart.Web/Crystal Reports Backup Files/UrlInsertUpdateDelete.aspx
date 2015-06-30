<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.Master" AutoEventWireup="true" CodeBehind="UrlInsertUpdateDelete.aspx.cs" Inherits="OMart.Web.AdminPanel.UrlInsertUpdateDelete" %>
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
                                <legend>Add/Edit Url List</legend>
                                <div class="col-xs-6">
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="lblCode" runat="server" CssClass="control-label">Module Name</asp:Label>
                                                <asp:DropDownList ID="dropDownModuleName" AutoPostBack="true" runat="server" Height="1%" class="form-control" OnSelectedIndexChanged="dropDownModuleName_SelectedIndexChanged1"></asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="groupName" runat="server" InitialValue="--Select Module Name--"
                                                 ControlToValidate="dropDownModuleName" ForeColor="Red"
                                                 ToolTip="*" Display="Dynamic" ValidationGroup="cValidationGroup" ErrorMessage="Select Module Name...">*</asp:RequiredFieldValidator>
                                                
                                                
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="lblCountryName" runat="server" CssClass="control-label">Module Serial No</asp:Label>
                                                 <asp:TextBox ID="txtModuleSerialNo" runat="server" ReadOnly="true" Height="1%" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                
                                                <asp:Label ID="lblISDCode" runat="server" CssClass="control-label">Url Name</asp:Label>
                                                 <asp:TextBox ID="txtUrlName" runat="server" ReadOnly="true" Height="1%" class="form-control"></asp:TextBox>
                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                                    ControlToValidate="txtUrlWFName" ForeColor="Red" 
                                                    ToolTip="*" Display="Dynamic" ValidationGroup="cValidationGroup" ErrorMessage="Enter Url Name...">*</asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                
                                                <asp:Label ID="Label1" runat="server" CssClass="control-label">Url Serial No</asp:Label>
                                                 <asp:TextBox ID="txtUrlWFSerialNo" runat="server" Height="1%" class="form-control"></asp:TextBox>
                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                                    ControlToValidate="txtUrlWFSerialNo" ForeColor="Red"
                                                    ToolTip="*" Display="Dynamic" ValidationGroup="cValidationGroup" ErrorMessage="Enter Url Serial No...">*</asp:RequiredFieldValidator>
                                                 </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                
                                                <asp:Label ID="Label2" runat="server" CssClass="control-label">Url Display Name</asp:Label>
                                                 <asp:TextBox ID="txtUrlWFDisplayName" runat="server" Height="1%" class="form-control"></asp:TextBox>
                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                                    ControlToValidate="txtUrlWFDisplayName" ForeColor="Red" 
                                                    ToolTip="*" Display="Dynamic" ValidationGroup="cValidationGroup" ErrorMessage="Enter Url Serial No...">*</asp:RequiredFieldValidator>
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
                                <asp:HiddenField runat="server" ID="hdUrlListID" />
                                <asp:HiddenField runat="server" ID="hdIsEdit" />
                                <asp:HiddenField runat="server" ID="hdIsDelete" />
                            </fieldset>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
