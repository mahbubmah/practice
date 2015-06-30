<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.Master" AutoEventWireup="true" CodeBehind="MortgageTermYear.aspx.cs" Inherits="OMart.Web.AdminPanel.MorgageTermYear" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AdminHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AdminContentPlaceHolder" runat="server">

    <div class="container">
        <div class="row">
            <asp:Label ID="labelMorgage" runat="server" Text="...." ></asp:Label>
        </div>

        <%--<fieldset>--%>
            <%--<legend>Mortgage Term Year</legend>--%>

            <div class="row">
                <div class="row">
                <div class="col-sm-12">
                    <div class="manageAdd">
                        <div class="addPostMang">
                            <fieldset class="adminFieldset">
                                <legend>Mortgage Term Year</legend>
                                <div class="col-xs-6">
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="lblCode" runat="server" CssClass="control-label">Number of Year</asp:Label>
                                                <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ControlToValidate="txtNoYear"
                                                     ErrorMessage=" is a required field." ForeColor="Red"></asp:RequiredFieldValidator>
                                                <asp:TextBox ID="txtNoYear" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="lblCountryName" runat="server" CssClass="control-label">Description</asp:Label>
                                                <asp:TextBox ID="txtCountryName" runat="server" CssClass="form-control"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rbfFirstName" runat="server" ControlToValidate="txtCountryName" ForeColor="Red"
                                                    ErrorMessage="PLease enter country name."
                                                    Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
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
                                    <br />
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <%--<asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-danger" OnClick="btnCancel_Click" />--%>

                                                <%--<asp:Button ID="btn_CreateOrEdit" runat="server" class="btn btn-primary  pull-right" Text="Submit"
                                                    OnClick="btn_CreateOrEdit_Click" ValidationGroup="gen"></asp:Button>--%>
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
        <%--</fieldset>--%>
        
    </div>


</asp:Content>
