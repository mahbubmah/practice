<%@ Page Title="User Group" Language="C#" MasterPageFile="~/BookAdmin/OiiOMasterPage.Master" AutoEventWireup="true" CodeBehind="UserGrpWF.aspx.cs" Inherits="OB.Web.BookAdmin.UserGrpWF" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mainpageBody">
        <div class="container">
            <div class="row">
                <h2>User Group Info
                </h2>
            </div>
            <div class="row">
                <asp:Label ID="labelMessageUserGrp" runat="server" Text="..."></asp:Label>
            </div>
            <fieldset>
                <legend>Add New Category</legend>
                <div class="row">
                    <div class="form-group col-xs-4">
                        <div class="input-group">
                            <span class="input-group-addon">User Group Name
                            <asp:RequiredFieldValidator ID="rfvUserGrp" runat="server"
                                ControlToValidate="txtUserGrpName" ForeColor="Red"
                                ToolTip="*" Display="Dynamic" ValidationGroup="UserValidationGroup">*</asp:RequiredFieldValidator>
                            </span>
                            <asp:TextBox ID="txtUserGrpName" runat="server" class="form-control" placeholder="Enter User Group Name..."></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="form-group col-xs-4">
                        <div class="input-group">
                            <span class="input-group-addon">Select Type ID
                            <asp:RequiredFieldValidator ID="rfvTypeID" runat="server"
                                ControlToValidate="DropDownTypeID" InitialValue="-1" ForeColor="Red"
                                ToolTip="*" Display="Dynamic" ValidationGroup="UserValidationGroup">*</asp:RequiredFieldValidator>
                            </span>
                            <asp:DropDownList ID="DropDownTypeID" Width="100%" Height="32px" runat="server" class="form-control"></asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="form-group col-xs-4">
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
                                <asp:CheckBox ID="chkRemove" runat="server" Text=" &nbsp Is Remove" />
                            </div>
                        </div>
                    </div>

                <div class="row">
                    <div class="col-xs-4">
                        <div class="input-group pull-right">
                            <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="UserValidationGroup" CssClass="btn btn-primary" OnClick="btnSave_Click"></asp:Button>
                            <asp:Button ID="btnUpdate" runat="server" Text="Update" ValidationGroup="UserValidationGroup"
                                CssClass="btn btn-primary" OnClick="btnUpdate_Click" />
                            <asp:Button ID="btnDelete" runat="server" Text="Delete"
                                CssClass="btn btn-primary" OnClick="btnDelete_Click" />
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel"
                                CssClass="btn btn-primary" OnClick="btnCancel_Click" />
                            <asp:HiddenField runat="server" ID="hdUserGrpID" />
                            <asp:HiddenField runat="server" ID="hdIsEdit" />
                            <asp:HiddenField runat="server" ID="hdIsDelete" />
                            <asp:HiddenField runat="server" ID="hdSave" />
                        </div>
                        <asp:ValidationSummary
                            ShowMessageBox="true"
                            ShowSummary="false"
                            HeaderText="You have to fill the Marked fields:"
                            EnableClientScript="true"
                            runat="server" ValidationGroup="UserValidationGroup" />
                    </div>
                </div>
            </fieldset>


            <div class="fa-space-shuttle">
            </div>
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
                                          <th class="col-xs-1">Is Remove
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
                                    <asp:Label ID="lblUserGroupID" runat="server" Text='<%# Bind("IID") %>' Visible="false"></asp:Label>
                                    <asp:LinkButton ID="lnkBtnName" runat="server" CausesValidation="false" Text='<%#Bind("Name")%>'
                                        CommandArgument='<%# Bind("IID") %>' CommandName="EditUserGroup"></asp:LinkButton>
                                </td>
                                <td>
                                    <asp:Label ID="lblTypeID" runat="server" Text='<%# Enum.Parse(typeof(OB.Utilities.EnumCollection.UserGroupType), Eval("TypeID").ToString())  %>'></asp:Label>
                                </td>
                                   <td>
                                    <asp:CheckBox ID="chkIssRemoved" runat="server" Checked='<%# Bind("IsRemoved") %>' Enabled="false"></asp:CheckBox>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <AlternatingItemTemplate>

                            <tr class="bg-info" runat="server">
                                <td style="text-align: center">
                                    <%# Container.DataItemIndex + 1%>
                                </td>
                                <td style="text-align: left">
                                    <asp:Label ID="lblUserGroupID" runat="server" Text='<%# Bind("IID") %>' Visible="false"></asp:Label>
                                    <asp:LinkButton ID="lnkBtnName" runat="server" CausesValidation="false" Text='<%#Bind("Name")%>'
                                        CommandArgument='<%# Bind("IID") %>' CommandName="EditUserGroup"></asp:LinkButton>
                                </td>
                                <td>
                                    <asp:Label ID="lblTypeID" runat="server" Text='<%# Enum.Parse(typeof(OB.Utilities.EnumCollection.UserGroupType), Eval("TypeID").ToString()) %>'></asp:Label>
                                </td>
                                   <td>
                                    <asp:CheckBox ID="chkIssRemoved" runat="server" Checked='<%# Bind("IsRemoved") %>' Enabled="false"></asp:CheckBox>
                                </td>
                            </tr>
                        </AlternatingItemTemplate>
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
    </div>
</asp:Content>
