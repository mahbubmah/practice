<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.Master" AutoEventWireup="true" CodeBehind="BIAmountRangeInsertUpdate.aspx.cs" Inherits="OMart.Web.AdminPanel.BIAmountRangeInsertUpdate" %>

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
                                <legend>Add/Edit Business amount range</legend>
                                <div class="col-xs-6">
                                      <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="lblAmountTypeId" runat="server" CssClass="control-label">Business type</asp:Label>
                                                <asp:DropDownList runat="server" CssClass="form-control" ID="ddlType" />
                                                <asp:RequiredFieldValidator InitialValue="-1" ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlType" ForeColor="Red"
                                                    ErrorMessage="Please select amount type.."
                                                    Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="lblAgeInterval" runat="server" CssClass="control-label">Minimum amount (Optional)</asp:Label>
                                                <asp:TextBox ID="txtStartAmount" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                      <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="Label2" runat="server" CssClass="control-label">Maximum amount</asp:Label>
                                                <asp:TextBox ID="txtEndAmount" runat="server" CssClass="form-control"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEndAmount" ForeColor="Red"
                                                    ErrorMessage="Please enter maximum amount."
                                                    Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="Label1" runat="server" CssClass="control-label">Note (Optional)</asp:Label>
                                                <asp:TextBox ID="txtNote" TextMode="MultiLine" runat="server" CssClass="form-control"></asp:TextBox>

                                            </div>
                                        </div>
                                    </div>

                                    <br />
                                       <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9 ">
                                                    <asp:Button ID="btnCreateOrEdit" runat="server" class="btn btn-primary pull-right" Text="Submit"
                                                        OnClick="btnCreateOrEdit_OnClick" ValidationGroup="gen"></asp:Button>
                                                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-danger " OnClick="btnCancel_OnClick" />
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                </div>
                            </fieldset>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
