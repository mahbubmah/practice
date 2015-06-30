<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.Master" AutoEventWireup="true" CodeBehind="UserInfoWF.aspx.cs" Inherits="OMart.Web.AdminPanel.UserInfoWF" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AdminHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AdminContentPlaceHolder" runat="server">
     <div class="container">
         <div class="row">
                <h2>
                    User Information 
                </h2>
        </div>

        <div class="row">
            <asp:Label ID="labelMessageUserInfo" runat="server" Text="....."></asp:Label>
        </div>

        <fieldset>
            <legend>Add New User</legend>
             <div class="row">
                <div class="form-group col-xs-5">
                    <div class="input-group">
                       <span class="input-group-addon">User Group
                            <asp:RequiredFieldValidator ID="groupName" runat="server" InitialValue="-1"
                                ControlToValidate="dropDownListGroupName" ForeColor="Red"
                                ToolTip="Select User Group" Display="Dynamic" ValidationGroup="cValidationGroup" ErrorMessage="Select User Group...">*</asp:RequiredFieldValidator>
                        </span>
                      <asp:DropDownList ID="dropDownListGroupName" class="form-control" Height="30px" runat="server"></asp:DropDownList>
                      
                    </div>
                </div>
            </div>

           <%-- /////////////////--%>
             <div class="row">
                <div class="form-group col-xs-5">
                    <div class="input-group">
                        <span class="input-group-addon">Login Email
                            <asp:RequiredFieldValidator ID="lblLoginName" runat="server"
                                ControlToValidate="txtLoginName" ForeColor="Red"
                                ToolTip="Enter Login Name..." Display="Dynamic" ValidationGroup="cValidationGroup" ErrorMessage="Login Name must entry...">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revLoginName" runat="server" ErrorMessage="Please enter a valid Email in Login field!" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="None" ControlToValidate="txtLoginName" ValidationGroup="cValidationGroup">
                            </asp:RegularExpressionValidator>
                        </span>
                       <asp:TextBox ID="txtLoginName" runat="server" Text="" class="form-control" placeholder="Enter Login Name..."></asp:TextBox>
                    </div>
                </div>
            </div>

          <%--  ////////////--%>
             <div class="row">
             <div class="form-group col-xs-5">
                 <div class="input-group">
                        <span class="input-group-addon">Login Password
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                ControlToValidate="txtLoginPassword" ForeColor="Red"
                                ToolTip="*" Display="Dynamic" ValidationGroup="cValidationGroup" ErrorMessage="Retype Login Password...">*</asp:RequiredFieldValidator>
                        </span>
                      <asp:TextBox ID="txtLoginPassword" runat="server" Text="" class="form-control" placeholder="Enter Login Password..."></asp:TextBox>
                 </div>
             </div>
            </div>
        <%--    ////////////--%>
            <div class="row">
             <div class="form-group col-xs-5">
                 <div class="input-group">
                        <span class="input-group-addon">Retype Password
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                ControlToValidate="txtRetypePassword" ForeColor="Red"
                                ToolTip="*" Display="Dynamic" ValidationGroup="cValidationGroup" ErrorMessage="Retype Login Password...">*</asp:RequiredFieldValidator>
                        </span>
                      <asp:TextBox ID="txtRetypePassword" runat="server" Text="" class="form-control" placeholder="Enter Retype Login Password..."></asp:TextBox>
                         <asp:CompareValidator ID="RequiredFieldValidator3" runat="server"
                                ControlToValidate="txtRetypePassword" ForeColor="Red" ControlToCompare="txtLoginPassword"
                                ToolTip="*" Display="Dynamic" ValidationGroup="cValidationGroup" ErrorMessage="Password missmatch!..">*</asp:CompareValidator>
                 </div>
             </div>
            </div>

        <%--    ////--%>
             <div class="row">
             <div class="form-group col-xs-5">
                 <div class="input-group">
                      <span class="input-group-addon">Salt
                        </span>
                      <asp:TextBox ID="txtSalt" runat="server" Text="" class="form-control" placeholder="Enter Salt..."></asp:TextBox>
                 </div>
             </div>
            </div>
            <%--//////--%>


             <div class="row">

             <div class="col-md-3">
                 <div class="input-group">
                       <asp:CheckBox ID="chkIsActive" Checked="false" runat="server"  AutoPostBack="true" /> Is Active    
                 </div>
             </div>
             
            </div>

<%--            ////////--%>

              <div class="row">
                <div class="col-xs-5 ">

                    <div class="input-group pull-right">

                         <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" CssClass="btn btn-primary"
                            ValidationGroup="cValidationGroup" ></asp:Button>
                        

                        <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click"
                            CssClass="btn btn-primary" ValidationGroup="cValidationGroup"/>

                       

                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click"
                            CssClass="btn btn-primary" />

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

        <div class="row">
        </div>
        <br />
        <fieldset>
            <legend>User Information List</legend>
             <asp:ListView ID="lvUserInfo" runat="server" DataKeyNames="IID"
                OnItemCommand="lvUserInfo_ItemCommand" OnPagePropertiesChanging="lvUserInfo_PagePropertiesChanging" OnPreRender="lvUserInfo_PreRender" OnSelectedIndexChanged="lvUserInfo_SelectedIndexChanged">
                <LayoutTemplate>
                    <table class="table table-bordered table-hover" style="margin-bottom: 0px;">
                        <thead>
                        <tr runat="server">
                            <th class="col-xs-1">SL #
                            </th>
                            <th class="col-xs-2">Group Name
                            </th>
                            <th class="col-xs-7">Login Name
                            </th>
                            <th class="col-xs-2">Password
                            </th>
                             <th class="col-xs-2">Is Active
                            </th>
                             
                            <th class="col-xs-2">Edit
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
                    <tr  runat="server">
                        <td style="text-align: center">
                            <%# Container.DataItemIndex + 1%>
                        </td>
                        <td style="text-align: left">
                           
                             <asp:Label ID="lnkBtnName" runat="server" Text='<%# Bind("groupName") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblCode" runat="server" Text='<%# Bind("LoginName") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("LoginPassword") %>'></asp:Label>
                        </td>
                         
                        
                        <td>
                        <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("IsActiveUser") %>' Enabled="false"></asp:CheckBox>
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
</asp:Content>
