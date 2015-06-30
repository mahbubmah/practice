<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.Master" AutoEventWireup="true" CodeBehind="CarInsuranceParameterInsertUpdate.aspx.cs" Inherits="OMart.Web.AdminPanel.CarInsuranceParameterInsertUpdate" %>
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
                                <legend>Add/Edit Car Insurance Parameter </legend>
                                <div class="col-xs-6">
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="lblCountry" runat="server" CssClass="control-label">Car Type</asp:Label>
                                                <asp:DropDownList ID="ddlCarType" runat="server" CssClass="form-control"  AutoPostBack="true"></asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rfvCountry" runat="server" ControlToValidate="ddlCarType" ForeColor="Red"
                                                    ErrorMessage="Please select Car Type." InitialValue=""
                                                    Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="Label10" runat="server" CssClass="control-label">Car Condition</asp:Label>
                                                <asp:DropDownList ID="ddlCarCondition" runat="server" CssClass="form-control"  AutoPostBack="true"></asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlCarCondition" ForeColor="Red"
                                                    ErrorMessage="Please select Car Condition." InitialValue=""
                                                    Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    
                                    <br />
                                      <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="Label3" runat="server" CssClass="control-label">MinRun</asp:Label>
                                                <asp:TextBox ID="txtMinRun"  runat="server"  CssClass="form-control"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtMinRun"  ForeColor="Red"
                                                    ErrorMessage="PLease enter Min Run."
                                                    Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>                                                
                                                 </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="lblLiSchemaName" runat="server" CssClass="control-label">Max Run</asp:Label>
                                                <asp:TextBox ID="txtMaxRun" runat="server"  CssClass="form-control"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rbfFirstName" runat="server" ControlToValidate="txtMaxRun"  ForeColor="Red"
                                                    ErrorMessage="PLease enter Max Run."
                                                    Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                                
                                                 </div>
                                        </div>
                                    </div>
                                   
                                    
                                    <br />
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="Label1" runat="server" CssClass="control-label">Min Car Age</asp:Label>
                                                <asp:TextBox ID="txtMinCarAge"  runat="server" CssClass="form-control"></asp:TextBox>
                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator" runat="server" ControlToValidate="txtMinCarAge" ForeColor="Red"
                                                    ErrorMessage="PLease enter Min Car Age."
                                                    Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                                
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="Label2" runat="server" CssClass="control-label">Max Car Age</asp:Label>
                                                <asp:TextBox ID="txtMaxCarAge"  runat="server" CssClass="form-control"></asp:TextBox>
                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtMaxCarAge" ForeColor="Red"
                                                    ErrorMessage="PLease enter Max Car Age."
                                                    Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                                 
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                   <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="Label5" runat="server" CssClass="control-label">Min Car Value Amount</asp:Label>
                                                <asp:TextBox ID="txtMinCarValueAmount"  runat="server" CssClass="form-control"></asp:TextBox>
                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtMinCarValueAmount" ForeColor="Red"
                                                    ErrorMessage="PLease enter Min Car Value Amount."
                                                    Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                                 
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="Label6" runat="server" CssClass="control-label">Max Car Value Amount</asp:Label>
                                                <asp:TextBox ID="txtMaxCarValueAmount" runat="server"  CssClass="form-control"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtMaxCarValueAmount"  ForeColor="Red"
                                                    ErrorMessage="PLease enter Starting Max Car Value Amount."
                                                    Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                                
                                                 </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="Label8" runat="server" CssClass="control-label">Premium Total Percent</asp:Label>
                                                <asp:TextBox ID="txtPremiumTotalPercent"  runat="server"  CssClass="form-control"></asp:TextBox>
                                                
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPremiumTotalPercent"  ForeColor="Red"
                                                    ErrorMessage="PLease enter Premium Total Percent."
                                                    Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                                
                                                 </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="Label9" runat="server" CssClass="control-label">Duration</asp:Label>
                                                <asp:TextBox ID="txtDuration" runat="server"  CssClass="form-control"></asp:TextBox>
                                                
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtDuration"  ForeColor="Red"
                                                    ErrorMessage="PLease enter Duration."
                                                    Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                                
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
                                    <div style="display:none">
                                    <asp:TextBox ID="txtHoldImagePath" runat="server"></asp:TextBox>
                                    </div>
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

