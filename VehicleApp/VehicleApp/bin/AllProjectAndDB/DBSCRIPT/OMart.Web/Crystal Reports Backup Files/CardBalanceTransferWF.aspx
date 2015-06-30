<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.Master" AutoEventWireup="true" CodeBehind="CardBalanceTransferWF.aspx.cs" Inherits="OMart.Web.AdminPanel.CardBalanceTransferWF" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxConTK" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AdminHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AdminContentPlaceHolder" runat="server">
    <div class="container">
        <div class="row">
            <asp:Label ID="labelMessageBalance" runat="server" Text="...."></asp:Label>
        </div>

        <fieldset>
            <legend>Card Balance Transfer</legend>

            <div class="row">
                <div class="form-group col-xs-5">
                    <div class="input-group">
                        <span class="input-group-addon">Card Name
                            <asp:RequiredFieldValidator ID="rfvCardName" runat="server"
                                ControlToValidate="ddCardName" ForeColor="Red"
                                ToolTip="*" Display="Dynamic" ValidationGroup="UserValidationGroup" ErrorMessage="Enter Card Name...">*</asp:RequiredFieldValidator>
                          <%--  <asp:RegularExpressionValidator ID="RegularExpressionValidatorCardName" ValidationGroup="UserValidationGroup" runat="server" ControlToValidate="ddCardName" ErrorMessage="Enter Only Numeric and characters" ValidationExpression="^\b[0-9a-zA-Z\s_\-]{1,20}$">*</asp:RegularExpressionValidator>--%>

                        </span>
                        <asp:DropDownList ID="ddCardName" runat="server" class="form-control"></asp:DropDownList>

                    </div>
                </div>
            </div>

            <div class="row">
                <div class="form-group col-xs-5">
                    <div class="input-group">
                        <span class="input-group-addon">Month Number
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                ControlToValidate="txtMonthNumber" ForeColor="Red"
                                ToolTip="*" Display="Dynamic" ValidationGroup="UserValidationGroup" ErrorMessage="Enter Month Number">*</asp:RequiredFieldValidator>
                          <%--  <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ValidationGroup="UserValidationGroup" runat="server" ControlToValidate="txtMonthNumber" ErrorMessage="Enter Only Numeric and characters" ValidationExpression="^\b[0-9a-zA-Z\s_\-]{1,20}$">*</asp:RegularExpressionValidator>--%>

                        </span>
                        <asp:TextBox ID="txtMonthNumber" TextMode="Number" runat="server" class="form-control" placeholder="Enter Month Number"></asp:TextBox>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="form-group col-xs-5">
                    <div class="input-group">
                        <span class="input-group-addon">Transfer Fee Percent
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                ControlToValidate="txtTransferPercentFee" ForeColor="Red"
                                ToolTip="*" Display="Dynamic" ValidationGroup="UserValidationGroup" ErrorMessage="Enter Transfer Fee Percent">*</asp:RequiredFieldValidator>
                           <%-- <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ValidationGroup="UserValidationGroup" runat="server" ControlToValidate="txtTransferPercentFee" ErrorMessage="Enter Only Numeric and characters" ValidationExpression="^\b[0-9a-zA-Z\s_\-]{1,20}$">*</asp:RegularExpressionValidator>--%>

                        </span>
                        <asp:TextBox ID="txtTransferPercentFee"  runat="server" class="form-control" placeholder="Enter Transfer Percent Fee"></asp:TextBox>
                        <ajaxConTK:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"  TargetControlID="txtTransferPercentFee" FilterType="Custom, Numbers" ValidChars="." />
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="form-group col-xs-5">
                    <div class="input-group">
                        <span class="input-group-addon">Note
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                ControlToValidate="txtNote" ForeColor="Red"
                                ToolTip="*" Display="Dynamic" ValidationGroup="UserValidationGroup" ErrorMessage="Enter Note">*</asp:RequiredFieldValidator>
                          <%--  <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ValidationGroup="UserValidationGroup" runat="server" ControlToValidate="txtNote" ErrorMessage="Enter Only Numeric and characters" ValidationExpression="^\b[0-9a-zA-Z\s_\-]{1,20}$">*</asp:RegularExpressionValidator--%>

                        </span>
                        <asp:TextBox ID="txtNote" runat="server" class="form-control" placeholder="Please Enter Note"></asp:TextBox>
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
                            CssClass="btn btn-primary" OnClick="btnDelete_Click" Visible="true" />
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel"
                            CssClass="btn btn-primary" OnClick="btnCancel_Click" />
                        <asp:HiddenField runat="server" ID="hdCardBalanceTransferID" />
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
        </fieldset>
        <br />

        <div class="row">
            <div class="col-sm-12">
                <div class="manageAdd">
                    <div class="addPostMang">
                        <fieldset class="adminFieldset">
                            <legend>Card Balance Transfer List</legend>
                            <asp:ListView ID="lv_CardBalanceTransfer" runat="server" DataKeyNames="IID" OnPagePropertiesChanging="lv_CardBalanceTransfer_PagePropertiesChanging" OnPreRender="dataPagerlv_CardBalanceTransfer_PreRender" OnItemCommand="lv_CardBalanceTransfer_ItemCommand">
                                <LayoutTemplate>
                                    <table class="table  table-hover table-bordered">
                                        <thead>
                                            <tr runat="server">
                                                <th class="col-xs-1">SL #
                                                </th>
                                                <th class="col-xs-2">Card Name
                                                </th>
                                                <th class="col-xs-6">Month Number
                                                </th>
                                                <th class="col-xs-2">Transfer Percent Fee
                                                </th>
                                                <th class="col-xs-2">Note
                                                </th>
                                                <th class="col-xs-2">IsRemoved
                                                </th>
                                                <th>Edit
                                                </th>
                                                <th>Delete
                                                </th>
                                            </tr>
                                        </thead>
                                        <tbody id="itemPlaceholder" runat="server">
                                        </tbody>
                                    </table>
                                </LayoutTemplate>
                                <ItemTemplate>
                                    <tr runat="server">
                                        <td style="text-align: center">
                                            <%# Container.DataItemIndex + 1%>
                                        </td>
                                        <td style="text-align: left">
                                            <%--<asp:Label ID="lblCardID" runat="server" Text='<%# Bind("IID") %>' Visible="false"></asp:Label>--%>
                                            <asp:LinkButton ID="lnkBtnName" runat="server" CausesValidation="false" Text='<%#Bind("CardName")%>'
                                                 CommandArgument='<%# Bind("IID") %>' CommandName="EditCard"></asp:LinkButton>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblCode" runat="server" Text='<%# Bind("MonthNumber") %>'></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("TransferFeePercent") %>'></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("Note") %>'></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("IsRemoved") %>'></asp:Label>
                                        </td>
                                        <td>
                                            <p data-placement="top" data-toggle="tooltip" title="Edit">
                                                <asp:LinkButton ID="lnkbEdit" runat="server" CausesValidation="false" class="btn btn-primary btn-xs" data-title="Edit"
                                                   CommandArgument='<%# Bind("IID") %>' OnClick="lnkbEdit_Click"><i class="fa fa-pencil-square-o"></i></asp:LinkButton>
                                            </p>
                                        </td>
                                        <td>
                                            <p data-placement="top" data-toggle="tooltip" title="Delete">
                                                <asp:LinkButton ID="lnkbDelete" runat="server" CausesValidation="false" class="btn btn-danger btn-xs" data-title="Delete" OnClientClick="return confirm('Are you sure, do you want to delete?');"
                                                     CommandArgument='<%# Bind("IID") %>' OnClick="lnkbDelete_Click"><i class="fa fa-trash"></i></asp:LinkButton>
                                            </p>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <EmptyDataTemplate>
                                    <tr>
                                        <td>Information is empty ...
                                        </td>
                                    </tr>
                                    </table>
                                </EmptyDataTemplate>

                            </asp:ListView>

                            <asp:DataPager ID="dataPagerCardWiseFeeDisplay" runat="server" PagedControlID="lv_CardBalanceTransfer"
                                PageSize="10" OnPreRender="dataPagerlv_CardBalanceTransfer_PreRender">
                                <Fields>
                                    <asp:NextPreviousPagerField FirstPageText="First" ButtonCssClass="BornoCss" PreviousPageText="Previous"
                                        ShowNextPageButton="False" ShowFirstPageButton="False" />
                                    <asp:NumericPagerField PreviousPageText="..." CurrentPageLabelCssClass="BornoCss"
                                        NumericButtonCssClass="BornoCss" NextPreviousButtonCssClass="BornoCss" RenderNonBreakingSpacesBetweenControls="True"
                                        ButtonType="Link" />
                                    <asp:NextPreviousPagerField FirstPageText="First" ButtonCssClass="BornoCss" LastPageText="Last"
                                        NextPageText="Next" PreviousPageText="Previous" ShowPreviousPageButton="False"
                                        ShowLastPageButton="False" />
                                </Fields>
                            </asp:DataPager>

                        </fieldset>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
