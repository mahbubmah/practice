<%@ Page Title="" Language="C#" MasterPageFile="~/BookAdmin/OiiOMasterPage.Master" AutoEventWireup="true" CodeBehind="OiiOBookWF.aspx.cs" Inherits="OB.Web.BookAdmin.OiiOBookWF" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
        <div class="mainpageBody">
            <div class="container">
                <div class="row">
                    <h2>OiiO Book Info
                    </h2>
                </div>
                <div>
                    <asp:Label ID="labelMessage" runat="server" Text="..."></asp:Label>
                </div>
                <div class="row">
                    <div class="col-sm-12">
                        <div class="manageAdd">
                            <div class="addPostMang">
                                <fieldset class="adminFieldset">
                                    <legend>New Content</legend>
                                    <div class="row">
                                        <div class="form-group col-xs-5">
                                            <div class="input-group">
                                                <span class="input-group-addon">Company Name
                            <asp:RequiredFieldValidator ID="rfvCompanyName" runat="server"
                                ControlToValidate="txtCompanyName" ForeColor="Red"
                                ToolTip="*" Display="Dynamic" ValidationGroup="ContentTitleValidationGroup"
                                ErrorMessage="Enter Company Name...">*</asp:RequiredFieldValidator>
                                                </span>
                                                <asp:TextBox ID="txtCompanyName" runat="server" Text="" class="form-control" placeholder="Enter Company Name..."></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="form-group col-xs-5">
                                            <div class="input-group">
                                                <span class="input-group-addon">Email
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail" runat="server"
                                ControlToValidate="txtEmail" ForeColor="Red"
                                ToolTip="*" Display="Dynamic" ValidationGroup="ContentTitleValidationGroup"
                                ErrorMessage="Enter Email...">*</asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="revLoginName" runat="server" ErrorMessage="Please enter a valid Email!" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="None" ControlToValidate="txtEmail" ValidationGroup="ContentTitleValidationGroup">
                                                    </asp:RegularExpressionValidator>
                                                </span>
                                                <asp:TextBox ID="txtEmail" runat="server" Text="" class="form-control" placeholder="Enter Email..."></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="form-group col-xs-5">
                                            <div class="input-group">
                                                <span class="input-group-addon">Address
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorAddress" runat="server"
                                ControlToValidate="txtAddress" ForeColor="Red"
                                ToolTip="*" Display="Dynamic" ValidationGroup="ContentTitleValidationGroup"
                                ErrorMessage="Enter Address...">*</asp:RequiredFieldValidator>
                                                </span>
                                                <asp:TextBox ID="txtAddress" TextMode="MultiLine" runat="server" Text="" class="form-control" placeholder="Enter Address..."></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="form-group col-xs-5">
                                            <div class="input-group">
                                                <span class="input-group-addon">Phone
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorPhone" runat="server"
                                ControlToValidate="txtPhone" ForeColor="Red"
                                ToolTip="*" Display="Dynamic" ValidationGroup="ContentTitleValidationGroup"
                                ErrorMessage="Enter Phone...">*</asp:RequiredFieldValidator>
                                                </span>
                                                <asp:TextBox ID="txtPhone" TextMode="Number" runat="server" Text="" class="form-control" placeholder="Enter Phone..."></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="form-group col-xs-5">
                                            <div class="input-group">
                                                <span class="input-group-addon">Note
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorNote" runat="server"
                                ControlToValidate="txtNote" ForeColor="Red"
                                ToolTip="*" Display="Dynamic" ValidationGroup="ContentTitleValidationGroup"
                                ErrorMessage="Enter Note...">*</asp:RequiredFieldValidator>
                                                </span>
                                                <asp:TextBox ID="txtNote" runat="server" Text="" class="form-control" placeholder="Enter Note..."></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div style="display: none">
                                        <asp:TextBox ID="txtHoldImagePath" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="row">
                                        <div class="form-group col-xs-5">
                                            <div class="input-group">
                                                <span class="input-group-addon">Upload OiiOBook Logo
                                                </span>
                                                <asp:FileUpload ID="FileUploadImage" runat="server" class="form-control" />
                                            </div>
                                        </div>
                                    </div>

                                    <div style="display: none">
                                        <asp:TextBox ID="txtHoldImagePathForLoginLogo" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="row">
                                        <div class="form-group col-xs-5">
                                            <div class="input-group">
                                                <span class="input-group-addon">Upload OiiOBook Login Logo
                                                </span>
                                                <asp:FileUpload ID="FileUploadImageForLoginLogo" runat="server" class="form-control" />
                                            </div>
                                        </div>
                                    </div>


                                    <div class="row">
                                        <div class="form-group col-xs-5">
                                            <div class="input-group">
                                                <asp:CheckBox ID="chkOiiObookActv" runat="server" Text=" &nbsp Is Active" />
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-xs-6">
                                            <div class="input-group pull-right">
                                                <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="ContentTitleValidationGroup" CssClass="btn btn-primary" OnClick="btnSave_Click"></asp:Button>
                                                &nbsp;
                              <asp:Button ID="btnUpdate" runat="server" Text="Update" ValidationGroup="ContentTitleValidationGroup"
                                  CssClass="btn btn-primary" OnClick="btnUpdate_Click" />
                                                &nbsp;
                            <asp:Button ID="btnDelete" runat="server" Text="Delete"
                                CssClass="btn btn-primary" Visible="false" />
                                                &nbsp;
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel"
                                CssClass="btn btn-primary" OnClick="btnCancel_Click" />
                                                <asp:HiddenField runat="server" ID="hdContentID" />
                                                <asp:HiddenField runat="server" ID="hdIsEdit" />
                                                <asp:HiddenField runat="server" ID="hdIsDelete" />
                                                <asp:HiddenField ID="hdSave" runat="server" />
                                                <asp:ValidationSummary
                                                    ShowMessageBox="true"
                                                    ShowSummary="false"
                                                    HeaderText="You must enter a value in the following fields:"
                                                    EnableClientScript="true"
                                                    runat="server" ValidationGroup="ContentTitleValidationGroup" />
                                            </div>

                                        </div>
                                    </div>

                                </fieldset>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-sm-12">
                        <div class="manageAdd">
                            <div class="addPostMang">

                                <fieldset class="adminFieldset">
                                    <legend>OiiOBook Content Information</legend>
                                    <asp:ListView ID="lvOiiObook" runat="server" DataKeyNames="IID" OnItemCommand="lvOiiObook_ItemCommand" OnPagePropertiesChanging="lvOiiObook_PagePropertiesChanging">
                                        <LayoutTemplate>
                                            <table class="table table-bordered table-hover" style="margin-bottom: 0px;">
                                                <thead>
                                                    <tr runat="server">
                                                        <th class="col-xs-1">SL #
                                                        </th>
                                                        <th class="col-xs-1">Company Name
                                                        </th>
                                                        <th class="col-xs-1">Email
                                                        </th>
                                                        <th class="col-xs-1">Logo
                                                        </th>
                                                        <th class="col-xs-1">Login Logo
                                                        </th>
                                                        <th class="col-xs-1">Address 
                                                        </th>
                                                        <th class="col-xs-1">Phone No. 
                                                        </th>
                                                        <th class="col-xs-1">Is Active
                                                        </th>

                                                    </tr>
                                                </thead>
                                                <tbody id="itemPlaceholder" runat="server">
                                                </tbody>
                                            </table>
                                        </LayoutTemplate>
                                        <ItemTemplate>
                                            <tr id="trBody" runat="server">
                                                <td style="text-align: center">
                                                    <%# Container.DataItemIndex + 1%>
                                                </td>
                                                <td style="text-align: left">
                                                    <asp:Label ID="lblOiiObookID" runat="server" Text='<%# Bind("IID") %>' Visible="false"></asp:Label>
                                                    <asp:LinkButton ID="lnkBtnName" runat="server" CausesValidation="false" Text='<%#Bind("CompanyName")%>'
                                                        CommandArgument='<%# Bind("IID") %>' CommandName="EditOiiObook"></asp:LinkButton>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblShortDescription" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
                                                </td>
                                                <td>
                                                    <div class="thumbnail">
                                                        <asp:Image runat="server" ID="OtherContentimg" Width="172" Height="80" ImageUrl='<%# Eval("Logo") %>' alt="Image" />

                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="thumbnail">
                                                        <asp:Image runat="server" ID="Image2" Width="172" Height="80" ImageUrl='<%# Eval("LoginLogo") %>' alt="Image" />

                                                    </div>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Address") %>'></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("Phone") %>'></asp:Label>
                                                </td>

                                                <td>
                                                    <asp:CheckBox ID="chkIsActive" runat="server" Checked='<%# Bind("IsActive") %>' Enabled="false" />
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                        <AlternatingItemTemplate>
                                            <tr class="bg-info" runat="server">
                                                <td style="text-align: center">
                                                    <%# Container.DataItemIndex + 1%>
                                                </td>
                                                <td style="text-align: left">
                                                    <asp:Label ID="lblHaaTContentID" runat="server" Text='<%# Bind("IID") %>' Visible="false"></asp:Label>
                                                    <asp:LinkButton ID="lnkBtnName" runat="server" CausesValidation="false" Text='<%#Bind("CompanyName")%>'
                                                        CommandArgument='<%# Bind("IID") %>' CommandName="EditOiiObook"></asp:LinkButton>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblShortDescription" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
                                                </td>
                                                <td>
                                                    <div class="thumbnail">
                                                        <asp:Image runat="server" ID="Image1" Width="172" Height="80" ImageUrl='<%# Eval("Logo") %>' alt="Image" />
                                                        <%--<asp:Label ID="lblImageUrl" runat="server" Text='<%# Bind("ImageUrl") %>'></asp:Label>--%>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="thumbnail">
                                                        <asp:Image runat="server" ID="Image2" Width="172" Height="80" ImageUrl='<%# Eval("LoginLogo") %>' alt="Image" />
                                                        <%--<asp:Label ID="lblImageUrl" runat="server" Text='<%# Bind("ImageUrl") %>'></asp:Label>--%>
                                                    </div>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("Address") %>'></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("Phone") %>'></asp:Label>
                                                </td>

                                                <td>
                                                    <asp:CheckBox ID="chkIsActive" runat="server" Checked='<%# Bind("IsActive") %>' Enabled="false" />
                                                </td>
                                            </tr>
                                        </AlternatingItemTemplate>
                                        <EmptyDataTemplate>
                                            <table>
                                                <tr>
                                                    <td>Information is empty ...
                                                    </td>
                                                </tr>
                                            </table>
                                        </EmptyDataTemplate>
                                    </asp:ListView>
                                    <asp:DataPager ID="dataPagerContent" runat="server" PagedControlID="lvOiiObook"
                                        PageSize="10" OnPreRender="dataPagerContent_PreRender">
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
        </div>

    </section>
</asp:Content>
