<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.Master" AutoEventWireup="true" CodeBehind="PostOfficeInsertUpdate.aspx.cs" Inherits="OMart.Web.AdminPanel.PostOfficeInsertUpdate" %>

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
                                <legend>Add/Edit Post Office</legend>
                                <div class="col-xs-6">
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="lblCountry" runat="server" CssClass="control-label">Country</asp:Label>
                                                <asp:TextBox ID="txtCountry" ReadOnly="True" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                            <asp:HiddenField runat="server" ID="hdCountryID"/>
                                        </div>
                                    </div>
                                    <br />
                                    
                                    
                                       <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="Label1" runat="server" CssClass="control-label">Division or state</asp:Label>
                                                <asp:DropDownList runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="dropDownDivisionOrState_SelectedIndexChanged" ID="dropDownDivisionOrState"/>
                                                <asp:RequiredFieldValidator InitialValue="-1" ID="rfvDivisionOrState" runat="server" ControlToValidate="dropDownDivisionOrState" ForeColor="Red"
                                                    ErrorMessage="Please select Division or state."
                                                    Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <br />

                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="lblDistrict" runat="server" CssClass="control-label">District</asp:Label>
                                                <asp:DropDownList runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="dropDownDistrict_SelectedIndexChanged" ID="dropDownDistrict"/>
                                               <%-- <asp:TextBox ID="txtDistrict" runat="server" CssClass="form-control"></asp:TextBox>--%>
                                                <asp:RequiredFieldValidator InitialValue="-1" ID="rfvDistrict" runat="server" ControlToValidate="dropDownDistrict" ForeColor="Red"
                                                    ErrorMessage="Please select district."
                                                    Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    

                                 <%--   <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="lblSubDistrict" runat="server" CssClass="control-label">Sub district (Optional)</asp:Label>
                                                <asp:TextBox ID="txtSubDistrict" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <br />--%>
                                    
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="lblPoliceStation" runat="server" CssClass="control-label">Police station (Optional)</asp:Label>
                                             <asp:DropDownList runat="server" CssClass="form-control" ID="dropDownPoliceStation"/>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    
                                    
                                      <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="Label2" runat="server" CssClass="control-label">Post code</asp:Label>
                                                  <asp:TextBox ID="txtPostCode" runat="server" CssClass="form-control"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvPostCode" runat="server" ControlToValidate="txtPostCode" ForeColor="Red"
                                                    ErrorMessage="Please enter post code."
                                                    Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    
                                      <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="lblPostOffice" runat="server" CssClass="control-label">Post office name</asp:Label>
                                                  <asp:TextBox ID="txtPostOffice" runat="server" CssClass="form-control"></asp:TextBox>
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
