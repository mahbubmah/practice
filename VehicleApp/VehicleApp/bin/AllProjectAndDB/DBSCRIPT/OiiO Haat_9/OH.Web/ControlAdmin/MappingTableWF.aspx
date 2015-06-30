<%@ Page Title="" Language="C#" MasterPageFile="~/ControlAdmin/ControlAdminMaster.Master" AutoEventWireup="true" CodeBehind="MappingTableWF.aspx.cs" Inherits="OH.Web.ControlAdmin.MappingTableWF" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headAdmin" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentAdminMain" runat="server">
    <div class="container">
        <div class="row">
            <h2>Mapping Information
            </h2>
        </div>
        <div class="row">
            <asp:Label ID="labelMessage" runat="server" Text=""></asp:Label>
        </div>
        <fieldset>
            <legend>Mapping New Category</legend>
            <div class="row">
                <div class="form-group col-xs-4">
                    <div class="input-group">
                        <span class="input-group-addon">Mapping Name
                            <asp:RequiredFieldValidator ID="rfvEmail" runat="server"
                                ControlToValidate="txtMappingName" ForeColor="Red"
                                ToolTip="*" Display="Dynamic" ValidationGroup="cValidationGroup" ErrorMessage="Here Mapping Name..">*</asp:RequiredFieldValidator>
                        </span>
                        <asp:TextBox ID="txtMappingName" runat="server" Text="" class="form-control" placeholder="Here Mapping Name..."></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="form-group col-xs-4">
                    <div class="input-group">
                        <span class="input-group-addon">Mapping Description

                        </span>

                        <asp:TextBox ID="txtMappingDescription" runat="server" Text="" class="form-control" placeholder="Description Here..."></asp:TextBox>
                    </div>
                </div>
            </div>

            <div class="clearfix">
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

                        <asp:HiddenField runat="server" ID="hdMappingID" />
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
            <legend>Mapping Lists</legend>

            <asp:ListView ID="lvMapping" runat="server" DataKeyNames="IID"
                OnItemCommand="lvMapping_ItemCommand" OnPagePropertiesChanging="lvMapping_PagePropertiesChanging" OnPreRender="dataPagerMapping_PreRender">
                <LayoutTemplate>
                    <table class="table table-bordered table-hover" style="margin-bottom: 0px;">
                        <thead>
                        <tr runat="server">
                            <th class="col-xs-1" >SL #
                            </th>
                            <th class="col-xs-5" >Mapping Name
                            </th>
                            <th class="col-xs-5">Mapping Description
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
                    <tr  runat="server">
                        <td style="text-align: center">
                            <%# Container.DataItemIndex + 1%>
                        </td>
                        <td style="text-align: left">
                            <asp:Label ID="lblMappingID" runat="server" Text='<%# Bind("IID") %>' Visible="false"></asp:Label>
                            <asp:LinkButton ID="lnkBtnName" runat="server" CausesValidation="false" Text='<%#Bind("Name")%>'
                                CommandArgument='<%# Bind("IID") %>' CommandName="EditMapping"></asp:LinkButton>
                        </td>
                        <td>
                            <asp:Label ID="lblDescription" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblIsRemoved" runat="server" Text='<%# Bind("IsRemoved") %>'></asp:Label>
                        </td>
                    </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>

                    <tr class="bg-info" runat="server">
                        <td style="text-align: center">
                            <%# Container.DataItemIndex + 1%>
                        </td>
                        <td style="text-align: left">
                            <asp:Label ID="lblMappingID" runat="server" Text='<%# Bind("IID") %>' Visible="false"></asp:Label>
                            <asp:LinkButton ID="lnkBtnName" runat="server" CausesValidation="false" Text='<%#Bind("Name")%>'
                                CommandArgument='<%# Bind("IID") %>' CommandName="EditMapping"></asp:LinkButton>
                        </td>
                        <td>
                            <asp:Label ID="lblDescription" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblIsRemoved" runat="server" Text='<%# Bind("IsRemoved") %>'></asp:Label>
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
            <asp:DataPager ID="dataPagerMapping" runat="server" PagedControlID="lvMapping"
                PageSize="10" OnPreRender="dataPagerMappingTable_PreRender">
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


