<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.master" AutoEventWireup="true" CodeBehind="UserGroupWF.aspx.cs" Inherits="OMart.Web.AdminPanel.UserGroupWF" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AdminHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AdminContentPlaceHolder" runat="server">
    <div class="container">
        <div class="row">
            <asp:Label ID="labelMessageUserGroup" runat="server" Text="..."></asp:Label>
        </div>

        <fieldset>
            <legend>Add User group</legend>

            <div class="row">
                <div class="form-group col-xs-5">
                    <div class="input-group">
                        <span class="input-group-addon">User Group Name
                            <asp:RequiredFieldValidator ID="rfvUserGrp" runat="server"
                                ControlToValidate="txtUserGrpName" ForeColor="Red"
                                ToolTip="*" Display="Dynamic" ValidationGroup="UserValidationGroup" ErrorMessage="Enter User Group Name...">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorUserName" ValidationGroup="UserValidationGroup" runat="server" ControlToValidate="txtUserGrpName" ErrorMessage="Enter Only Numeric and characters" ValidationExpression="^\b[0-9a-zA-Z\s_\-]{1,20}$">*</asp:RegularExpressionValidator>

                        </span>
                        <asp:TextBox ID="txtUserGrpName" runat="server" class="form-control" placeholder="Enter User Group Name..."></asp:TextBox>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="form-group col-xs-5">
                    <div class="input-group">
                        <span class="input-group-addon">Select Type ID
                            <asp:RequiredFieldValidator ID="rfvTypeID" runat="server"
                                ControlToValidate="DropDownTypeID" ForeColor="Red"
                                ToolTip="*" Display="Dynamic" ValidationGroup="UserValidationGroup" ErrorMessage="Select Type ID...">*</asp:RequiredFieldValidator>

                        </span>
                        <asp:DropDownList ID="DropDownTypeID" runat="server" class="form-control" ValidationGroup="UserValidationGroup">
                            <%--<asp:ListItem>Select Type ID</asp:ListItem>--%>
                        </asp:DropDownList>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="form-group col-xs-5">
                    <div class="input-group">
                        <span style="display: none">
                            <asp:TextBox ID="txtUsergrpID" runat="server"></asp:TextBox>
                        </span>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="form-group col-xs-5">
                    <div class="input-group">
                        <asp:CheckBox ID="chkUserGrpIsRemove" runat="server" Text=" &nbsp Is Remove" />
                    </div>
                </div>
            </div>



            <div class="row">
                <div class="col-xs-5">
                    <div class="input-group pull-right">
                        <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="UserValidationGroup" CssClass="btn btn-primary" OnClick="btnSave_Click"></asp:Button>
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" ValidationGroup="UserValidationGroup"
                            CssClass="btn btn-primary" OnClick="btnUpdate_Click" />
                        
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel"
                            CssClass="btn btn-primary" OnClick="btnCancel_Click" />
                        <asp:HiddenField runat="server" ID="hdUserGrpID" />
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
        <div>
            <fieldset>
                <legend>User Group Lists</legend>

                <asp:ListView ID="lvUserGroup" runat="server" DataKeyNames="IID" OnItemCommand="lvUserGroup_ItemCommand" OnPagePropertiesChanging="lvUserGroup_PagePropertiesChanging">
                    <LayoutTemplate>
                        <table class="table table-bordered table-hover" style="margin-bottom: 0px;">
                            <thead>
                                <tr runat="server">
                                    <th class="col-xs-4" style="text-align: center">SL #
                                    </th>
                                    <th class="col-xs-4">User Group Name
                                    </th>
                                    <th class="col-xs-4">Group Type Code
                                    </th>
                                    <th class="col-xs-4">Is Remove
                                    </th>
                                    <th class="col-xs-4">Edit
                                    </th>
                                    <th class="col-xs-2">Delete
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
                                
                                 <asp:Label ID="Label1" runat="server" Text='<%#Bind("Name")%>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblTypeID" runat="server" Text='<%# Enum.Parse(typeof(Utilities.EnumCollection.UserGrpType), Eval("TypeID").ToString())  %>'></asp:Label>
                            </td>
                            <td>
                                <asp:CheckBox ID="chkIsRemoved" runat="server" Checked='<%# Bind("IsRemoved") %>' Enabled="false"></asp:CheckBox>
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
                <asp:DataPager ID="dataPagerUserGroup" runat="server" PagedControlID="lvUserGroup"
                    PageSize="10" OnPreRender="dataPagerUserGroup_PreRender">
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

</asp:Content>
