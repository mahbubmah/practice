<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.Master" AutoEventWireup="true" CodeBehind="OiiOMartContent.aspx.cs" Inherits="OMart.Web.AdminPanel.OiiOMartContent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AdminHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AdminContentPlaceHolder" runat="server">

    <section>
        <div class="container adminPagewrp">
            <div class="row">
                <h2>OiiO Mart Info
                </h2>
            </div>
            <div>
                <asp:Label ID="labelMessageOiiOMart" runat="server" Text="..."></asp:Label>
            </div>

            <div class="row">
                <div class="col-xs-12">
                    <div class="well signpPageLeft">
                        <div class="addPostMang">
                            <fieldset class="adminFieldset">
                                <legend>New Content</legend>
                                <div class="row">
                                    <div class="form-group">
                                        <div class="col-sm-5 col-md-5">
                                            <asp:Label ID="lblTitle" runat="server" CssClass="control-label"> Company Name</asp:Label>
                                            <asp:RequiredFieldValidator ID="rfvCompanyName" runat="server"
                                                ControlToValidate="txtCompanyName" ForeColor="Red"
                                                ToolTip="*" Display="Dynamic" ValidationGroup="ContentTitleValidationGroup"
                                                ErrorMessage="Enter Company Name...">*</asp:RequiredFieldValidator>
                                            <asp:TextBox ID="txtCompanyName" runat="server" Text="" class=" form-control" placeholder="Enter Company Name..."></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="form-group">
                                        <div class="col-sm-5 col-md-5">
                                            <asp:Label ID="Email" runat="server" CssClass="control-label"> Email</asp:Label>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail" runat="server"
                                                ControlToValidate="txtEmail" ForeColor="Red"
                                                ToolTip="*" Display="Dynamic" ValidationGroup="ContentTitleValidationGroup"
                                                ErrorMessage="Enter Email...">*</asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="revLoginName" runat="server" ErrorMessage="Please enter a valid Email!" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="None" ControlToValidate="txtEmail" ValidationGroup="ContentTitleValidationGroup">
                                            </asp:RegularExpressionValidator>
                                            <asp:TextBox ID="txtEmail" runat="server" Text="" class="form-control" placeholder="Enter Email..."></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <div class="col-sm-5 col-md-5">
                                            <asp:Label ID="Address" runat="server" CssClass="control-label"> Address</asp:Label>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorAddress" runat="server"
                                                ControlToValidate="txtAddress" ForeColor="Red"
                                                ToolTip="*" Display="Dynamic" ValidationGroup="ContentTitleValidationGroup"
                                                ErrorMessage="Enter Address...">*</asp:RequiredFieldValidator>
                                            <asp:TextBox ID="txtAddress" TextMode="MultiLine" runat="server" Text="" class="form-control" placeholder="Enter Address..."></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <div class="col-sm-5 col-md-5">
                                            <asp:Label ID="Label5" runat="server" CssClass="control-label"> Phone</asp:Label>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorPhone" runat="server"
                                                ControlToValidate="txtPhone" ForeColor="Red"
                                                ToolTip="*" Display="Dynamic" ValidationGroup="ContentTitleValidationGroup"
                                                ErrorMessage="Enter Phone...">*</asp:RequiredFieldValidator>
                                            <asp:TextBox ID="txtPhone" TextMode="Number" runat="server" Text="" class="form-control" placeholder="Enter Phone..."></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <div class="col-sm-5 col-md-5">
                                            <asp:Label ID="Label6" runat="server" CssClass="control-label"> Note</asp:Label>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorNote" runat="server"
                                                ControlToValidate="txtNote" ForeColor="Red"
                                                ToolTip="*" Display="Dynamic" ValidationGroup="ContentTitleValidationGroup"
                                                ErrorMessage="Enter Note...">*</asp:RequiredFieldValidator>
                                            <asp:TextBox ID="txtNote" runat="server" Text="" class=" form-control" placeholder="Enter Note..."></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div style="display: none">
                                    <asp:TextBox ID="txtHoldImagePath" runat="server"></asp:TextBox>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <div class="col-sm-5 col-md-5">
                                            <span class="control-label">Upload Logo
                                            </span>
                                            <asp:FileUpload ID="FileUploadImage" runat="server" class="form-control-static" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group col-xs-5">
                                        <div class="input-group">
                                            <asp:CheckBox ID="chkOiiOmartActv" runat="server" Text=" &nbsp Is Active" />
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
                <div class="col-xs-12">
                    <div class="well signpPageLeft">
                        <div class="addPostMang">
                            <fieldset class="adminFieldset">
                <legend>HaaT Content Information</legend>
                <asp:ListView ID="lvMartContent" runat="server" DataKeyNames="IID" OnItemCommand="lvMartContent_ItemCommand" OnPagePropertiesChanging="lvMartContent_PagePropertiesChanging">
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
                                <asp:Label ID="lblMartContentID" runat="server" Text='<%# Bind("IID") %>' Visible="false"></asp:Label>
                                <asp:LinkButton ID="lnkBtnName" runat="server" CausesValidation="false" Text='<%#Bind("CompanyName")%>'
                                    CommandArgument='<%# Bind("IID") %>' CommandName="EditMartContent"></asp:LinkButton>
                            </td>
                            <td>
                                <asp:Label ID="lblShortDescription" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
                            </td>
                            <td>
                                <div class="thumbnail">
                                    <asp:Image runat="server" ID="OtherContentimg" Width="172" Height="80" ImageUrl='<%# Eval("Logo") %>' alt="Image" />
                                    <%--<asp:Label ID="lblImageUrl" runat="server" Text='<%# Bind("ImageUrl") %>'></asp:Label>--%>
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
                                <asp:Label ID="lblMartContentID" runat="server" Text='<%# Bind("IID") %>' Visible="false"></asp:Label>
                                <asp:LinkButton ID="lnkBtnName" runat="server" CausesValidation="false" Text='<%#Bind("CompanyName")%>'
                                    CommandArgument='<%# Bind("IID") %>' CommandName="EditMartContent"></asp:LinkButton>
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
                <asp:DataPager ID="dataPagerMartContent" runat="server" PagedControlID="lvMartContent"
                    PageSize="10" OnPreRender="dataPagerMartContent_PreRender">
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
    </section>


</asp:Content>
