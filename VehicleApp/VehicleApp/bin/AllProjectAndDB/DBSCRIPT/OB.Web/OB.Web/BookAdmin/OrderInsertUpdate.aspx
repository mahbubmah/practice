<%@ Page Title="" Language="C#" MasterPageFile="~/BookAdmin/OiiOMasterPage.Master" AutoEventWireup="true" CodeBehind="OrderInsertUpdate.aspx.cs" Inherits="OB.Web.BookAdmin.OrderInsertUpdate" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxConTK" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <section>
        <div class="mainpageBody">

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
                                    <legend>Add/Edit Order</legend>

                                    <div class="col-xs-6">
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="lblQuantity" runat="server" CssClass="control-label">Quantity</asp:Label>
                                                    <asp:TextBox ID="txtQuantity" runat="server" CssClass="form-control"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rbfQuantity" runat="server" ControlToValidate="txtQuantity" ForeColor="Red"
                                                        ErrorMessage="PLease enter Quantity number."
                                                        Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="lblPaymentType" runat="server" CssClass="control-label">Payment Type</asp:Label>
                                                    <asp:DropDownList ID="dropDownPaymentType" runat="server" CssClass="sysTextBox"
                                                        Width="100%" Height="32px">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                        <br />

                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="lblShippingAddress" runat="server" CssClass="control-label">Shipping Address</asp:Label>
                                                    <asp:TextBox ID="txtShippingAddress" runat="server" CssClass="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="lblStatus" runat="server" CssClass="control-label"> Order Status</asp:Label>
                                                    <asp:DropDownList ID="dropdownOrderStatus" runat="server" CssClass="sysTextBox"
                                                        Width="100%" Height="32px">
                                                    </asp:DropDownList>

                                                </div>
                                            </div>
                                        </div>

                                        <br />
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="lblShippingStatus" runat="server" CssClass="control-label"> Shipping Status</asp:Label>
                                                    <asp:DropDownList ID="dropdownShippingStatus" runat="server" CssClass="sysTextBox"
                                                        Width="100%" Height="32px">
                                                    </asp:DropDownList>

                                                </div>
                                            </div>
                                        </div>

                                        <br />
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="lblPaymentStatus" runat="server" CssClass="control-label"> Payment Status</asp:Label>
                                                    <asp:DropDownList ID="dropdownPStatus" runat="server" CssClass="sysTextBox"
                                                        Width="100%" Height="32px">
                                                    </asp:DropDownList>

                                                </div>
                                            </div>
                                        </div>

                                        <br />
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="lblAdditionalMobile" runat="server" CssClass="control-label">Additional Mobile</asp:Label>
                                                    <asp:TextBox ID="txtAdditionalMobile" runat="server" CssClass="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                    </div>
                                    <div class="col-xs-6">

                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="lblLocation" runat="server" CssClass="control-label">Location</asp:Label>
                                                    <asp:TextBox ID="txtLocation" runat="server" CssClass="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="lblOrderDate" runat="server" CssClass="control-label">Order date</asp:Label>
                                                    <asp:TextBox ID="txtOrderDate" runat="server" CssClass="form-control"></asp:TextBox>
                                                    <ajaxConTK:CalendarExtender ID="extDate2" runat="server" Enabled="True" TargetControlID="txtOrderDate" Format="dd/MM/yyyy"></ajaxConTK:CalendarExtender>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtOrderDate" ForeColor="Red"
                                                        ErrorMessage="Please enter OrderDate."
                                                        Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </div>
                                        <br />

                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="lblTotalPrice" runat="server" CssClass="control-label">Total Price</asp:Label>
                                                    <asp:TextBox ID="txtTotalPrice" runat="server" CssClass="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="lblShippingCosts" runat="server" CssClass="control-label">Shipping Costs</asp:Label>
                                                    <asp:TextBox ID="txtShippingCosts" runat="server" CssClass="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="lblUserComment" runat="server" CssClass="control-label">User Comments</asp:Label>
                                                    <asp:TextBox ID="txtUserComment" runat="server" CssClass="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="lblShippingDate" runat="server" CssClass="control-label">Shipping date</asp:Label>
                                                    <asp:TextBox ID="txtShippingDate" runat="server" CssClass="form-control"></asp:TextBox>
                                                    <ajaxConTK:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" TargetControlID="txtShippingDate" Format="dd/MM/yyyy"></ajaxConTK:CalendarExtender>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtShippingDate" ForeColor="Red"
                                                        ErrorMessage="Please enter OrderDate."
                                                        Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:CheckBox ID="chkIsRemoved" runat="server"></asp:CheckBox>
                                                    <asp:Label ID="lblIsRemoved" runat="server" CssClass="control-label">Is Removed</asp:Label>

                                                </div>
                                            </div>
                                        </div>
                                        <br />



                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9 ">
                                                    <asp:Button ID="btn_CreateOrEdit" runat="server" class="btn btn-primary pull-right" Text="Submit"
                                                        OnClick="btn_CreateOrEdit_Click" ValidationGroup="gen"></asp:Button>
                                                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-danger " OnClick="btnCancel_Click" />
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
        </div>
    </section>
</asp:Content>
