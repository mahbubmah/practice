<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.Master" AutoEventWireup="true" CodeBehind="LifeInsuranceInsertUpdate.aspx.cs" Inherits="OMart.Web.AdminPanel.LifeInsuranceInsertUpdate" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxConTK" %>
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
                                <legend>Add/Edit Life Insurance</legend>
                                <div class="col-xs-6">
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="lblCode" runat="server" CssClass="control-label">Company Info ID</asp:Label>

                                               <asp:DropDownList ID="DropDownComInfoID"  runat="server" Height="100%" class="form-control" 
                                                    ></asp:DropDownList>
                                                  <asp:RequiredFieldValidator InitialValue="-1" ID="RequiredFieldValidator4" runat="server" ControlToValidate="DropDownComInfoID" ForeColor="Red"
                                                    ErrorMessage="Please select company."
                                                    Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                                
                                               
                                                
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                     <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="Label6" runat="server" CssClass="control-label">LISchema ID</asp:Label>

                                               <asp:DropDownList ID="DropDownLISchemaID"  runat="server" Height="100%" class="form-control" 
                                                    ></asp:DropDownList>
                                                  <asp:RequiredFieldValidator InitialValue="-1" ID="RequiredFieldValidator7" runat="server" ControlToValidate="DropDownLISchemaID" ForeColor="Red"
                                                    ErrorMessage="Please select company."
                                                    Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>                     
                                                
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="lblLiSchemaName" runat="server" CssClass="control-label">Package Name</asp:Label>
                                                <asp:TextBox ID="txtPackageName" runat="server"  CssClass="form-control"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rbfFirstName" runat="server" ControlToValidate="txtPackageName"  ForeColor="Red"
                                                    ErrorMessage="PLease enter Starting Amount."
                                                    Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                                
                                                 </div>
                                        </div>
                                    </div>
                                    <br />
                                     
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="lblISDCode" runat="server" CssClass="control-label">Total Cover Amount</asp:Label>
                                                <asp:TextBox ID="txtTotalCoverAmount"  runat="server" CssClass="form-control"></asp:TextBox>
                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTotalCoverAmount" ForeColor="Red"
                                                    ErrorMessage="PLease enter Ending Amount"
                                                    Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                                <ajaxConTK:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtTotalCoverAmount" FilterType="Custom, Numbers" ValidChars="." />
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="Label1" runat="server" CssClass="control-label">Critical illness Cover Amount</asp:Label>
                                                <asp:TextBox ID="txtCriticalillnessCoverAmount"  runat="server" CssClass="form-control"></asp:TextBox>
                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCriticalillnessCoverAmount" ForeColor="Red"
                                                    ErrorMessage="PLease enter Duration."
                                                    Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                                <ajaxConTK:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtCriticalillnessCoverAmount" FilterType="Custom, Numbers" ValidChars="." />
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="Label2" runat="server" CssClass="control-label">Claims Paid Percent</asp:Label>
                                                <asp:TextBox ID="txtClaimsPaidPercent"  runat="server" CssClass="form-control"></asp:TextBox>
                                                <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtClaimsPaidPercent" ForeColor="Red"
                                                    ErrorMessage="PLease enter APR."
                                                    Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>--%>
                                                 <ajaxConTK:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txtClaimsPaidPercent" FilterType="Custom, Numbers" ValidChars="." />
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                   
                                   
                                     <div class="row login">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                               
                                                  <asp:CheckBox ID="CheckBoxISGuranteedPremium" runat="server" CssClass=""></asp:CheckBox>
                                                <asp:Label ID="Label8" runat="server" CssClass="control-label">IS Guranteed Premium</asp:Label>
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

