<%@ Page Title="" ValidateRequest="true" Language="C#" MasterPageFile="~/ControlAdmin/ControlAdminMaster.Master" AutoEventWireup="true" CodeBehind="CountryWF.aspx.cs" Inherits="OH.Web.ControlAdmin.CountryWF" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headAdmin" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentAdminMain" runat="server">

    <div class="container adminPagewrp">


        <div class="row">
            <div class="col-md-12">
                <h2>Country Information
                </h2>
            </div>
        </div>

        <div class="row">
            <asp:Label ID="labelMessage" runat="server" Text=""></asp:Label>
        </div>


        <div class="row">
            <fieldset class="adminFieldset">
                <legend>Add New Country</legend>


                <div class="form-group">
                    <div class="input-group">
                        <span class="input-group-addon">Country Code
                            <asp:RequiredFieldValidator ID="rfvEmail" runat="server"
                                ControlToValidate="txtCode" ForeColor="Red"
                                ToolTip="*" Display="Dynamic" ValidationGroup="cValidationGroup" ErrorMessage="Enter country code...">*</asp:RequiredFieldValidator>
                        </span>
                        <asp:TextBox ID="txtCode" runat="server" Text="" class="form-control" placeholder="Enter country code..."></asp:TextBox>
                    </div>
                </div>


                <div class="form-group">
                    <div class="input-group">
                        <span class="input-group-addon">Country Name

                            <asp:RequiredFieldValidator ID="rfvCountry" runat="server"
                                ControlToValidate="txtName" ForeColor="Red"
                                ToolTip="*" Display="Dynamic" ValidationGroup="cValidationGroup" ErrorMessage="Enter country name...">*</asp:RequiredFieldValidator>
                        </span>

                        <asp:TextBox ID="txtName" runat="server" Text="" class="form-control" placeholder="Enter country name..."></asp:TextBox>
                    </div>
                </div>

                <div class="clearfix">
                    <asp:CheckBox ID="chkIsRemoved" runat="server" Text= " IsRemoved" />
                </div>
                <div class="form-group">
                    <div class="col-xs-5">



                        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" CssClass="btn btn-primary pull-right"
                            ValidationGroup="cValidationGroup"></asp:Button>


                        <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click"
                            CssClass="btn btn-primary pull-right" ValidationGroup="cValidationGroup" />

                        <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click"
                            CssClass="btn btn-primary pull-right"  Visible="false"/>

                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click"
                            CssClass="btn btn-primary pull-right" />

                        <asp:HiddenField runat="server" ID="hdCountryID" />
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

            </fieldset>
            <div class="clearfix">
            </div>
            </div>
            <div class="row">
                <fieldset class="adminFieldset">
                    <legend>Country Lists</legend>

                    <asp:ListView ID="lvCountry" runat="server" DataKeyNames="IID"
                        OnItemCommand="lvCountry_ItemCommand" OnPagePropertiesChanging="lvCountry_PagePropertiesChanging" OnPreRender="dataPagerCountry_PreRender">
                        <LayoutTemplate>
                            <table class="table table-bordered table-hover" style="margin-bottom: 0px;">
                                <thead>
                                    <tr runat="server">
                                        <th class="col-xs-1">SL #
                                        </th>
                                        <th class="col-xs-7">Country Name
                                        </th>
                                        <th class="col-xs-2">Country Code
                                        </th>
                                        <th class="col-xs-1">IsRemoved
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
                                    <asp:Label ID="lblCountryID" runat="server" Text='<%# Bind("IID") %>' Visible="false"></asp:Label>
                                    <asp:LinkButton ID="lnkBtnName" runat="server" CausesValidation="false" Text='<%#Bind("Name")%>'
                                        CommandArgument='<%# Bind("IID") %>' CommandName="EditCountry"></asp:LinkButton>
                                </td>
                                <td>
                                    <asp:Label ID="lblCode" runat="server" Text='<%# Bind("Code") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:CheckBox ID="chkIsRemoved" runat="server" Checked='<%# Bind("IsRemoved") %>' Enabled="false"></asp:CheckBox>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <AlternatingItemTemplate>

                            <tr class="bg-info" runat="server">
                                <td style="text-align: center">
                                    <%# Container.DataItemIndex + 1%>
                                </td>
                                <td style="text-align: left">
                                    <asp:Label ID="lblCountryID" runat="server" Text='<%# Bind("IID") %>' Visible="false"></asp:Label>
                                    <asp:LinkButton ID="lnkBtnName" runat="server" CausesValidation="false" Text='<%#Bind("Name")%>'
                                        CommandArgument='<%# Bind("IID") %>' CommandName="EditCountry"></asp:LinkButton>
                                </td>
                                <td>
                                    <asp:Label ID="lblCode" runat="server" Text='<%# Bind("Code") %>'></asp:Label>
                                </td>
                                <td>
                                 <%--   <asp:Label ID="lblIsActive" runat="server" Text='<%# Bind("IsRemoved") %>'></asp:Label>--%>
                                    <asp:CheckBox ID="chkIsRemoved"  runat="server" Checked='<%# Bind("IsRemoved") %>' Enabled="false"></asp:CheckBox>
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
                    <asp:DataPager ID="dataPagerCountry" runat="server" PagedControlID="lvCountry"
                        PageSize="10" OnPreRender="dataPagerCountry_PreRender">
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

