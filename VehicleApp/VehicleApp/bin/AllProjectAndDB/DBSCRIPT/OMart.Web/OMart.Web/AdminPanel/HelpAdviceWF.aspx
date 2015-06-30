<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.Master" AutoEventWireup="true" CodeBehind="HelpAdviceWF.aspx.cs" Inherits="OMart.Web.AdminPanel.HelpAdviceWF" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AdminHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AdminContentPlaceHolder" runat="server">
    <div class="container adminPagewrp">
        <div class="row">
            <h2>Help Advice
            </h2>
        </div>
        <div>
            <asp:Label ID="labelMessage" runat="server" Text="..."></asp:Label>
        </div>
        <div class="formItemWrp">
            <fieldset>
                <legend>New Help Content</legend>
                <div class="row">
                    <div class="col-xs-5">
                        <div class="form-group">
                            <div class="input-group">
                                <span class="input-group-addon">Title                               
                                        <asp:RequiredFieldValidator ID="rfvHelpTitle" runat="server" ControlToValidate="txtHelpTitle" EnableClientScript="true"
                                            ForeColor="Red" ToolTip="*" Display="Dynamic" ValidationGroup="vG" ErrorMessage="Enter Title...">*</asp:RequiredFieldValidator>
                                    <%-- <asp:RegularExpressionValidator ID="RegularExpressionValidatoroiiocntnt" ValidationGroup="UserValidationGroup" runat="server" ControlToValidate="txtContentTitle" ErrorMessage="Enter Only Numeric and characters" ValidationExpression="^\b{1,20}$">*</asp:RegularExpressionValidator>--%>
                                </span>
                                <asp:TextBox ID="txtHelpTitle" runat="server" Text="" class="form-control" placeholder="Enter News Title..."></asp:TextBox>


                            </div>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-xs-8">
                        <div class="form-group">
                            <div class="input-group">
                                <span class="input-group-addon">Help Description
                                </span>
                                <asp:TextBox ID="txtHelpDescription" TextMode="MultiLine" runat="server" Columns="56" Rows="8"> </asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>

                <div style="display: none">
                    <asp:TextBox ID="txtHoldImagePath" runat="server"></asp:TextBox>
                </div>
                <div class="row">
                    <div class="form-group col-xs-5">
                        <div class="input-group">
                            <span class="input-group-addon">Upload Image
                         
                            </span>

                            <asp:FileUpload ID="FileUploadImage" runat="server" class="form-control" />
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-6">
                        <div class="input-group pull-right">
                            <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="vG" CssClass="btn btn-primary" OnClick="btnSave_Click"></asp:Button>
                            <asp:Button ID="btnUpdate" runat="server" Text="Update"
                                CssClass="btn btn-primary" OnClick="btnUpdate_Click" />
                            &nbsp;
                            <asp:Button ID="btnDelete" runat="server" Text="Delete"
                                CssClass="btn btn-primary" Visible="false" />
                            &nbsp;
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel"
                                CssClass="btn btn-primary" OnClick="btnCancel_Click" />
                            <asp:HiddenField runat="server" ID="hdHelpID" />
                            <asp:HiddenField runat="server" ID="hdIsEdit" />
                            <asp:HiddenField runat="server" ID="hdIsDelete" />
                            <asp:HiddenField runat="server" ID="hdSave" />
                            <asp:ValidationSummary
                                ShowMessageBox="true"
                                ShowSummary="false"
                                HeaderText="You must enter a value in the following fields:"
                                EnableClientScript="true"
                                runat="server" ValidationGroup="vG" />
                        </div>

                    </div>
                </div>
            </fieldset>


            <div>
                <fieldset>
                    <legend>Help Advice Information</legend>
                    <asp:ListView ID="lvHelpAdvice" runat="server" DataKeyNames="IID" OnItemCommand="lvHelpAdvice_ItemCommand"  OnPagePropertiesChanging="lvHelpAdvice_PagePropertiesChanging">
                        <LayoutTemplate>
                            <table class="table table-bordered table-hover" style="margin-bottom: 0px;">
                                <thead>
                                    <tr runat="server">
                                        <th class="col-xs-1">SL #
                                        </th>

                                        <th class="col-xs-1">News Title
                                        </th>
                                        <th class="col-xs-7">Help Description
                                        </th>

                                        <th class="col-xs-1">Image Url   

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
                                    <asp:Label ID="lblCMSID" runat="server" Text='<%# Bind("IID") %>' Visible="false"></asp:Label>
                                    <asp:LinkButton ID="lnkBtnName" runat="server" CausesValidation="false" Text='<%#Bind("Title")%>'
                                        CommandArgument='<%# Bind("IID") %>' CommandName="EditNews"></asp:LinkButton>
                                </td>
                                <td>
                                    <asp:Label ID="lblHelpDescription" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                                </td>
                                <td>
                                    <div class="thumbnail">
                                        <asp:Image runat="server" ID="OtherContentimg" Width="50" Height="50" ImageUrl='<%# Eval("Image") %>' alt="Image" />
                                    </div>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <EmptyDataTemplate>
                            <table>
                                <tr>
                                    <td>Information is empty ...
                                    </td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                    </asp:ListView>
                    <asp:DataPager ID="dataPagerHelpAdvice" runat="server" PagedControlID="lvHelpAdvice" OnPreRender="dataPagerHelpAdvice_PreRender"
                        PageSize="10">
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
