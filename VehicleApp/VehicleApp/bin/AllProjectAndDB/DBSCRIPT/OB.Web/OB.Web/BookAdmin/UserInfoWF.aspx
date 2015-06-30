<%@ Page Title="" Language="C#" MasterPageFile="~/BookAdmin/OiiOMasterPage.Master" AutoEventWireup="true" CodeBehind="UserInfoWF.aspx.cs" Inherits="OB.Web.BookAdmin.UserInfoWF" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mainpageBody">
    <div class="container">


        <div class="row">
            <h2>User Information
            </h2>
        </div>

        <div class="row">
            <asp:Label ID="labelMessage" runat="server" Text=""></asp:Label>
        </div>



        <fieldset>
            <legend>Add New User Information</legend>

            <div class="row">
                <div class="form-group col-xs-4">
                    <div class="input-group">
                        <span class="input-group-addon">User Group
                            <asp:RequiredFieldValidator ID="groupName" runat="server" InitialValue="-1"
                                ControlToValidate="dropDownListGroupName" ForeColor="Red"
                                ToolTip="*" Display="Dynamic" ValidationGroup="cValidationGroup" ErrorMessage="Select User Group...">*</asp:RequiredFieldValidator>
                        </span>
                        
                     <asp:DropDownList ID="dropDownListGroupName" class="form-control" Width="100%" Height="32px" runat="server"></asp:DropDownList></div>
                </div>
            </div>
            <div class="row">
                <div class="form-group col-xs-4">
                    <div class="input-group">
                        <span class="input-group-addon">Login Name
                            <asp:RequiredFieldValidator ID="lblLoginName" runat="server"
                                ControlToValidate="txtLoginName" ForeColor="Red"
                                ToolTip="*" Display="Dynamic" ValidationGroup="cValidationGroup" ErrorMessage="Login Name must entry...">*</asp:RequiredFieldValidator>
                        </span>
                        <asp:TextBox ID="txtLoginName" runat="server" Text="" class="form-control" placeholder="Enter Login Name..."></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="form-group col-xs-4">
                    <div class="input-group">
                        <span class="input-group-addon">Login Password

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                ControlToValidate="txtLoginPassword" ForeColor="Red"
                                ToolTip="*" Display="Dynamic" ValidationGroup="cValidationGroup" ErrorMessage="Enter Login Password...">*</asp:RequiredFieldValidator>
                        </span>

                        <asp:TextBox ID="txtLoginPassword" runat="server" Text="" class="form-control" placeholder="Enter Login Password..."></asp:TextBox>
                    </div>
                </div>
            </div>
                <div class="row">
                <div class="form-group col-xs-4">
                    <div class="input-group">
                        <span class="input-group-addon">Retype Login Password

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                ControlToValidate="txtLoginPassword" ForeColor="Red"
                                ToolTip="*" Display="Dynamic" ValidationGroup="cValidationGroup" ErrorMessage="Retype Login Password...">*</asp:RequiredFieldValidator>
                        </span>

                        <asp:TextBox ID="txtRetypePassword" runat="server" Text="" class="form-control" placeholder="Retype Login Password..."></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="form-group col-xs-4">
                    <div class="input-group">
                        <span class="input-group-addon">Salt
                        </span>
                        <asp:TextBox ID="txtSalt" runat="server" Text="" class="form-control" placeholder="Enter Salt..."></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="clearfix">
            </div>
            <div class="row">
                <div class="form-group col-xs-5">
                    <div class="input-group">
                         <asp:CheckBox ID="chkIsActive" Checked="false" runat="server" Text="Is Active"/>                
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-4 ">

                    <div class="input-group pull-right">

                         <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" CssClass="btn btn-primary"
                            ValidationGroup="cValidationGroup" ></asp:Button>
                        

                        <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click"
                            CssClass="btn btn-primary" ValidationGroup="cValidationGroup"/>

                        <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click"
                            CssClass="btn btn-primary" />

                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click"
                            CssClass="btn btn-primary" />
                        <asp:HiddenField runat="server" ID="hdSave" />
                        <asp:HiddenField runat="server" ID="hdUserInfoID" />
                        <asp:HiddenField runat="server" ID="hdIsEdit" />
                        <asp:HiddenField runat="server" ID="hdIsDelete" />

                        <asp:ValidationSummary
                            ShowMessageBox="true"
                            ShowSummary="false"
                            HeaderText="You must enter a value in the following fields:"
                            EnableClientScript="true"
                            runat="server" ValidationGroup="cValidationGroup" />

                    </div>
                   

                </div>
                
            </div>

        </fieldset>
        <div class="clearfix">
        </div>
        <br />
        <fieldset>
            <legend>User Information List</legend>

            <asp:ListView ID="lvUserInfo" runat="server" DataKeyNames="IID"
                OnItemCommand="lvUserInfo_ItemCommand" OnPagePropertiesChanging="lvUserInfo_PagePropertiesChanging" OnPreRender="lvUserInfo_PreRender">
                <LayoutTemplate>
                    <table class="table table-bordered table-hover" style="margin-bottom: 0px;">
                        <thead>
                        <tr runat="server">
                            <th class="col-xs-1">SL #
                            </th>
                            <th class="col-xs-2">Group Name
                            </th>
                            <th class="col-xs-2">Login Name
                            </th>
                            <th class="col-xs-2">Password
                            </th>
                             <th class="col-xs-2">Is User Active? 
                            </th>
                             <th class="col-xs-2">Is Removed
                            </th>
                        </tr>
                            </thead>
                        <tbody id="itemPlaceholder" runat="server">
                        </tbody>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr  runat="server">
                        <td style="text-align: center">
                            <%# Container.DataItemIndex + 1%>
                        </td>
                        <td style="text-align: left">
                            <asp:LinkButton ID="lnkBtnName" runat="server" CausesValidation="false" Text='<%#Bind("groupName")%>'
                                CommandArgument='<%# Bind("IID") %>' CommandName="EditUserInfo"></asp:LinkButton>
                        </td>
                        <td>
                            <asp:Label ID="lblCode" runat="server" Text='<%# Bind("LoginName") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("LoginPassword") %>'></asp:Label>
                        </td>
                         <td>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("IsActiveUser") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("IsRemoved") %>'></asp:Label>
                        </td>
                    </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>

                    <tr class="bg-info" runat="server">
                        <td style="text-align: center">
                            <%# Container.DataItemIndex + 1%>
                        </td>
                        <td style="text-align: left">
                            <asp:LinkButton ID="lnkBtnName" runat="server" CausesValidation="false" Text='<%#Bind("groupName")%>'
                                CommandArgument='<%# Bind("IID") %>' CommandName="EditUserInfo"></asp:LinkButton>
                        </td>
                        <td>
                            <asp:Label ID="lblCode" runat="server" Text='<%# Bind("LoginName") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("LoginPassword") %>'></asp:Label>
                        </td>
                         <td>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("IsActiveUser") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("IsRemoved") %>'></asp:Label>
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
            <asp:DataPager ID="dataPagerUserInfo" runat="server" PagedControlID="lvUserInfo"
                PageSize="10" OnPreRender="dataPagerUserInfo_PreRender">
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
    <br />
        </div>
</asp:Content>
