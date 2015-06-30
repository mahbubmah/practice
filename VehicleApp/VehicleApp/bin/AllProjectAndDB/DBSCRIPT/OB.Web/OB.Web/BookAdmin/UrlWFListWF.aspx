<%@ Page Title="" Language="C#" MasterPageFile="~/BookAdmin/OiiOMasterPage.Master" AutoEventWireup="true" CodeBehind="UrlWFListWF.aspx.cs" Inherits="OB.Web.BookAdmin.UrlWFListWF" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mainpageBody">
         <div class="container">
       <div class="row">
        <h2>
            Url List
        </h2>
    </div>
    <div class="row">
        <asp:Label ID="labelMessage" runat="server" Text="..."></asp:Label>
    </div>
    <div>
        <fieldset>
            <legend>Add New Url</legend>
            <div class="row">
                <div class="form-group col-xs-4">
                    <div class="input-group">
                        <span class="input-group-addon">Module Name
                            <asp:RequiredFieldValidator ID="groupName" runat="server" InitialValue="-1"
                                ControlToValidate="dropDownModuleName" ForeColor="Red"
                                ToolTip="*" Display="Dynamic" ValidationGroup="cValidationGroup" ErrorMessage="Select Module Name...">*</asp:RequiredFieldValidator>
                        </span>
                          <asp:DropDownList ID="dropDownModuleName" runat="server" class="form-control" Width="100%" Height="32px"
                          AutoPostBack="true" InitialValue="-1" ValidationGroup="cValidationGroup"
                            onselectedindexchanged="dropDownModuleName_SelectedIndexChanged">
                        </asp:DropDownList>
                   </div>
                </div>
            </div>
              <div class="row">
                <div class="form-group col-xs-4">
                    <div class="input-group">
                        <span class="input-group-addon">Module Serial No.
                           <%-- <asp:RequiredFieldValidator ID="lblLoginName" runat="server"
                                ControlToValidate="txtModuleSerialNo" ForeColor="Red"
                                ToolTip="*" Display="Dynamic" ValidationGroup="cValidationGroup" ErrorMessage="Login Name must entry...">*</asp:RequiredFieldValidator>--%>
                        </span>
                         <asp:TextBox ID="txtModuleSerialNo" runat="server" Text="" class="form-control"  ReadOnly="true" ></asp:TextBox>
                        
                    </div>
                </div>
            </div>
              <div class="row">
                <div class="form-group col-xs-4">
                    <div class="input-group">
                        <span class="input-group-addon"> UrlWF Name
                            <asp:RequiredFieldValidator ID="lblLoginName" runat="server"
                                ControlToValidate="txtUrlWFName" ForeColor="Red"
                                ToolTip="*" Display="Dynamic" ValidationGroup="cValidationGroup" ErrorMessage="Enter UrlWF Name...">*</asp:RequiredFieldValidator>
                        </span>
                          <asp:TextBox ID="txtUrlWFName" runat="server" Text="" class="form-control" placeholder="Enter UrlWF Name..."></asp:TextBox>
                       
                    </div>
                </div>
            </div>
              <div class="row">
                <div class="form-group col-xs-4">
                    <div class="input-group">
                        <span class="input-group-addon"> UrlWF Serial NO.
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                ControlToValidate="txtUrlWFSerialNo" ForeColor="Red"
                                ToolTip="*" Display="Dynamic" ValidationGroup="cValidationGroup" ErrorMessage="Enter  UrlWF Serial NO...">*</asp:RequiredFieldValidator>
                        </span>
                        <asp:TextBox ID="txtUrlWFSerialNo" runat="server" Text="" class="form-control" placeholder="Enter  UrlWF Serial NO...."></asp:TextBox>
                    </div>
                </div>
            </div>
              <div class="row">
                <div class="form-group col-xs-4">
                    <div class="input-group">
                        <span class="input-group-addon">UrlWF Display Name
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                ControlToValidate="txtUrlWFDisplayName" ForeColor="Red"
                                ToolTip="*" Display="Dynamic" ValidationGroup="cValidationGroup" ErrorMessage="Enter UrlWF Display Name...">*</asp:RequiredFieldValidator>
                        </span>
                        <asp:TextBox ID="txtUrlWFDisplayName" runat="server" Text="" class="form-control" placeholder="Enter UrlWF Display Name..."></asp:TextBox>
                    </div>
                </div>
            </div>
            
            <div class="row">
                <div class="col-xs-4 ">

                    <div class="input-group pull-right">
                        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click"    CssClass="btn btn-primary"
                            ValidationGroup="cValidationGroup" />
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" 
                         CssClass="btn btn-primary" ValidationGroup="cValidationGroup" onclick="btnUpdate_Click" />
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" 
                            CssClass="btn btn-primary"  onclick="btnDelete_Click"  />
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" 
                              CssClass="btn btn-primary" onclick="btnCancel_Click" />
                        <asp:HiddenField runat="server" ID="hdUrlListID"/>
                        <asp:HiddenField runat="server" ID="hdIsEdit" />
                        <asp:HiddenField runat="server" ID="hdIsDelete" />
           </div>
                        <asp:ValidationSummary
                            ShowMessageBox="true"
                            ShowSummary="false"
                            HeaderText="You must enter a value in the following fields:"
                            EnableClientScript="true"
                            runat="server" ValidationGroup="cValidationGroup" />
                    </div>
                </div>
        </fieldset>
    </div>
                  <div class="clearfix">
        </div>
        <br />
    <div>
        <fieldset>
            <legend>Url Information</legend>
            <asp:ListView ID="lvUrlWFList" runat="server" DataKeyNames="IID" 
                OnItemCommand="lvUrlWFList_ItemCommand" OnPagePropertiesChanging="lvUrlWFList_PagePropertiesChanging">
                <LayoutTemplate>
                  <table class="table table-bordered table-hover" style="margin-bottom: 0px;">
                      <thead>
                      <tr runat="server">
                            <th class="col-xs-1">
                                SL #
                            </th>
                            <th class="col-xs-1">
                                Module Name
                            </th>
                            <th class="col-xs-1">
                                MOdule Serial NO
                            </th>
                            <th class="col-xs-1">
                                UrlWF Name
                            </th>
                            <th class="col-xs-1">
                                UrlWF Display Name
                            </th>
                            <th class="col-xs-1">
                                UrlWF Serial No
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
                        <td >
                            
                            <asp:LinkButton ID="lnkBtnName" runat="server" CausesValidation="false" Text='<%#Bind("ModuleName")%>'
                                CommandArgument='<%# Bind("IID") %>' CommandName="EditUrlWFList"> </asp:LinkButton>
                        </td>
                        <td >
                            <asp:Label ID="lblCode" runat="server" Text='<%# Bind("ModuleSerialNo") %>'></asp:Label>
                        </td>
                        <td >
                            <asp:Label ID="lblDescription" runat="server" Text='<%# Bind("UrlWFName") %>'></asp:Label>
                        </td>
                        <td >
                            <asp:Label ID="lblApplicableCountryID" runat="server" Text='<%# Bind("UrlWFDisplayName") %>'></asp:Label>
                        </td>
                        <td >
                            <asp:Label ID="lblUrlSerialNo" runat="server" Text='<%# Bind("UrlWFSerialNO") %>'></asp:Label>
                        </td>
                    </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <tr class="bg-info" runat="server">
                        <td style="text-align: center">
                            <%# Container.DataItemIndex + 1%>
                        </td>
                        <td >
                              <asp:LinkButton ID="lnkBtnName" runat="server" CausesValidation="false" Text='<%#Bind("ModuleName")%>'
                                CommandArgument='<%# Bind("IID") %>' CommandName="EditUrlWFList"></asp:LinkButton>
                        </td>
                        <td>
                            <asp:Label ID="lblCode" runat="server" Text='<%# Bind("ModuleSerialNo") %>'></asp:Label>
                        </td>
                        <td >
                            <asp:Label ID="lblDescription" runat="server" Text='<%# Bind("UrlWFName") %>'></asp:Label>
                        </td>
                        <td >
                            <asp:Label ID="lblApplicableCountryID" runat="server" Text='<%# Bind("UrlWFDisplayName") %>'></asp:Label>
                        </td>
                        <td >
                            <asp:Label ID="lblUrlSerialNo" runat="server" Text='<%# Bind("UrlWFSerialNO") %>'></asp:Label>
                        </td>
                    </tr>
                </AlternatingItemTemplate>
                <EmptyDataTemplate>
                    <table>
                        <tr>
                            <td>
                                Information is empty ...
                            </td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
            </asp:ListView>
            <asp:DataPager ID="dataPagerUrlWFList" runat="server" PagedControlID="lvUrlWFList"
                PageSize="10" OnPreRender="dataPagerUrlWFList_PreRender">
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

