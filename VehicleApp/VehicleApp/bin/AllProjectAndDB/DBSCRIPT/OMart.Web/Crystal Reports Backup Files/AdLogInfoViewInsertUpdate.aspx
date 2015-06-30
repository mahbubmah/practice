<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AdLogInfoViewInsertUpdate.aspx.cs" Inherits="OMart.Web.AdminPanel.AdLogInfoViewInsertUpdate" %>
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
                                <legend>Add/Edit Logo Info</legend>
                                <div class="col-xs-6">
                                    
                                    <br />
                                      <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="Label3" runat="server" CssClass="control-label">Name</asp:Label>
                                                <asp:TextBox ID="txtName"  runat="server"  CssClass="form-control"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtName"  ForeColor="Red"
                                                    ErrorMessage="PLease enter Starting Amount."
                                                    Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>                                                
                                                 </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="lblLiSchemaName" runat="server" CssClass="control-label">Bussiness Description</asp:Label>
                                                <asp:TextBox ID="txtBussinessDescription" TextMode="MultiLine" runat="server"  CssClass="form-control"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rbfFirstName" runat="server" ControlToValidate="txtBussinessDescription"  ForeColor="Red"
                                                    ErrorMessage="PLease enter Starting Amount."
                                                    Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                                
                                                 </div>
                                        </div>
                                    </div>
                                    <br />
                                     <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="lblCountry" runat="server" CssClass="control-label">Display On Page ID</asp:Label>
                                                <asp:DropDownList ID="ddlDisplayOnPageID" runat="server" CssClass="form-control"  AutoPostBack="true"></asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rfvCountry" runat="server" ControlToValidate="ddlDisplayOnPageID" ForeColor="Red"
                                                    ErrorMessage="Please select Display On Page ID." InitialValue=""
                                                    Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                   <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="Label7" runat="server" CssClass="control-label">Logo Image</asp:Label>
                                                <asp:FileUpload ID="FileUploadImage" runat="server" class="form-control"/>
                                                
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
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="Label6" runat="server" CssClass="control-label">Pay Amount</asp:Label>
                                                <asp:TextBox ID="txtPayAmount" TextMode="Number" runat="server"  CssClass="form-control"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPayAmount"  ForeColor="Red"
                                                    ErrorMessage="PLease enter Starting Amount."
                                                    Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                                
                                                 </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="Label8" runat="server" CssClass="control-label">Display Start Date</asp:Label>
                                                <asp:TextBox ID="txtDisplayStartDate"  runat="server"  CssClass="form-control"></asp:TextBox>
                                                <ajaxConTK:CalendarExtender ID="extDate2" runat="server" Enabled="True" TargetControlID="txtDisplayStartDate" Format="dd/MM/yyyy"></ajaxConTK:CalendarExtender>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDisplayStartDate"  ForeColor="Red"
                                                    ErrorMessage="PLease enter Starting Amount."
                                                    Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                                
                                                 </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="Label9" runat="server" CssClass="control-label">Display End Date</asp:Label>
                                                <asp:TextBox ID="txtDisplayEndDate" runat="server"  CssClass="form-control"></asp:TextBox>
                                                <ajaxConTK:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" TargetControlID="txtDisplayEndDate" Format="dd/MM/yyyy"></ajaxConTK:CalendarExtender>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtDisplayEndDate"  ForeColor="Red"
                                                    ErrorMessage="PLease enter Starting Amount."
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

