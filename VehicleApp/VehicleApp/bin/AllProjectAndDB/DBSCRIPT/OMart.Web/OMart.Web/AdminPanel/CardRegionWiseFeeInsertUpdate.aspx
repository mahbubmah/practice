<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.Master" AutoEventWireup="true" CodeBehind="CardRegionWiseFeeInsertUpdate.aspx.cs" Inherits="OMart.Web.AdminPanel.CardRegionWiseFeeInsertUpdate" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxConTK" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AdminHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AdminContentPlaceHolder" runat="server">
    <div class="container">
         <div class="row">
            <asp:Label ID="labelMessageCardRegionWiseFeeInsertUpdate" runat="server" Text="..."></asp:Label>
        </div>

        <fieldset>
            <legend>Card Region Wise Fee Setup</legend>
        </fieldset>
        <div class="row">
                <div class="form-group col-xs-5">
                    <div class="input-group">
                        <span class="input-group-addon">Card Name
                            <asp:RequiredFieldValidator ID="rfvCardName" runat="server"
                                ControlToValidate="ddCardName" ForeColor="Red"
                                ToolTip="*" Display="Dynamic" ValidationGroup="UserValidationGroup" ErrorMessage="Enter Card Name...">*</asp:RequiredFieldValidator>
                       <%-- <asp:RegularExpressionValidator ID="RegularExpressionValidatorCardName" ValidationGroup="UserValidationGroup" runat="server" ControlToValidate="ddCardName" ErrorMessage="Enter Only Numeric and characters" ValidationExpression="^\b[0-9a-zA-Z\s_\-]{1,20}$">*</asp:RegularExpressionValidator>--%>
                        
                        </span>
                        <asp:DropDownList ID="ddCardName" runat="server" class="form-control" ></asp:DropDownList>
                        
                    </div>
                </div>
            </div>

         <div class="row">
                <div class="form-group col-xs-5">
                    <div class="input-group">
                        <span class="input-group-addon">Region
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                ControlToValidate="ddRegionName" ForeColor="Red"
                                ToolTip="*" Display="Dynamic" ValidationGroup="UserValidationGroup" ErrorMessage="Enter Region Name...">*</asp:RequiredFieldValidator>
                       <%-- <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ValidationGroup="UserValidationGroup" runat="server" ControlToValidate="ddRegionName" ErrorMessage="Enter Only Numeric and characters" ValidationExpression="^\b[0-9a-zA-Z\s_\-]{1,20}$">*</asp:RegularExpressionValidator>--%>
                        
                        </span>
                        <asp:DropDownList ID="ddRegionName" runat="server" class="form-control" ></asp:DropDownList>
                        
                    </div>
                </div>
            </div>

        <div class="row">
                <div class="form-group col-xs-5">
                    <div class="input-group">
                        <span class="input-group-addon">Note 
                        </span>
                        <asp:TextBox ID="txtNote" runat="server" class="form-control"></asp:TextBox>
                    </div>
                </div>
            </div>

        <div class="row">
                <div class="form-group col-xs-5">
                    <div class="input-group">
                        <span class="input-group-addon">Usage Fee Percent
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                ControlToValidate="txtUsageFeePercent" ForeColor="Red"
                                ToolTip="*" Display="Dynamic" ValidationGroup="UserValidationGroup" ErrorMessage="Enter Usage Fee Percent">*</asp:RequiredFieldValidator>
                        <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator2" ValidationGroup="UserValidationGroup" runat="server" ControlToValidate="txtUsageFeePercent" ErrorMessage="Enter Only Numeric and characters" ValidationExpression="^\b[0-9a-zA-Z\s_\-]{1,20}$">*</asp:RegularExpressionValidator>--%>
                        
                        </span>
                        <asp:TextBox ID="txtUsageFeePercent"  runat="server" class="form-control" placeholder="Enter Usage Fee Percent"></asp:TextBox>
                        <ajaxConTK:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtUsageFeePercent" FilterType="Custom, Numbers" ValidChars="." />
                    </div>
                </div>
            </div>

         <div class="row">
                <div class="col-xs-5">
                    <div class="input-group pull-right">
                        <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="UserValidationGroup" CssClass="btn btn-primary" OnClick="btnSave_Click"></asp:Button>
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" ValidationGroup="UserValidationGroup"
                            CssClass="btn btn-primary" OnClick="btnUpdate_Click" />
                        <asp:Button ID="btnDelete" runat="server" Text="Delete"
                            CssClass="btn btn-primary" OnClick="btnDelete_Click" Visible="true"/>
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel"
                            CssClass="btn btn-primary" OnClick="btnCancel_Click" />
                        <asp:HiddenField runat="server" ID="hdCardRegionWiseFeeInsertUpdateID" />
                        <asp:HiddenField runat="server" ID="hdIsEdit" />
                        <asp:HiddenField runat="server" ID="hdIsDelete" />
                        <asp:HiddenField ID="hdSave" runat="server" />
                        <asp:ValidationSummary
                            ShowMessageBox="true"
                            ShowSummary="false"
                            HeaderText="You must enter a value in the following fields:"
                            EnableClientScript="true"
                            runat="server" ValidationGroup="UserValidationGroup" />

                    </div>
                </div>
            </div>
    </div>
</asp:Content>

