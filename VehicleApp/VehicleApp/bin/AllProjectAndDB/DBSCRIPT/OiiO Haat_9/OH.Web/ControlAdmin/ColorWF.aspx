
<%@ Page Title="" Language="C#" MasterPageFile="~/ControlAdmin/ControlAdminMaster.Master" AutoEventWireup="true" CodeBehind="ColorWF.aspx.cs" Inherits="OH.Web.ControlAdmin.ColorWF" %>


<asp:Content ID="Content1" ContentPlaceHolderID="headAdmin" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentAdminMain" runat="server">

    <div class="container adminPagewrp">
        <div class="row">
            <div class="col=ms-12">
            <h2>Color Info
            </h2>
                </div>
        </div>
   
        <asp:Label ID="labelMessage" runat="server" Text="..."></asp:Label>
    
   
        <div class="row">
        <fieldset class="adminFieldset">
            <legend>Add New Color</legend>
           <div class="row">
                <div class="form-group col-xs-5">
                    <div class="input-group">
                        <span class="input-group-addon">Code
                            <asp:RequiredFieldValidator ID="rfvBrand" runat="server"
                                ControlToValidate="txtCode" ForeColor="Red"
                                ToolTip="*" Display="Dynamic" ValidationGroup="brandValidationGroup">*</asp:RequiredFieldValidator>
                        </span>
                        <asp:TextBox ID="txtCode" runat="server" Text=""  class="form-controlWebSer" placeholder="Enter Code..."></asp:TextBox>
                    </div>
                </div>
          </div>
              <div class="row">
                <div class="form-group col-xs-5">
                    <div class="input-group">
                        <span class="input-group-addon">Name
                            <asp:RequiredFieldValidator ID="rfvOrigin" runat="server"
                                ControlToValidate="txtName" ForeColor="Red"
                                ToolTip="*" Display="Dynamic" ValidationGroup="brandValidationGroup">*</asp:RequiredFieldValidator>
                        </span>
                        <asp:TextBox ID="txtName" runat="server" Text=""  class="form-controlWebSer" placeholder="Enter Name..."></asp:TextBox>
                    </div>
                </div>
                </div>
                    <asp:TextBox ID="txtOriginID" Visible="false" runat="server" Text=""></asp:TextBox>
                
            
            <div class="clearfix">
            </div>
                  <div class="form-group">
                    <div class="col-xs-5">
                  

                        <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="brandValidationGroup" OnClick="btnSave_Click" CssClass="btn btn-primary pull-right"></asp:Button>
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" ValidationGroup="brandValidationGroup" OnClick="btnUpdate_Click"
                            CssClass="btn btn-primary" />
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click"
                            CssClass="btn btn-primary" />
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click"
                            CssClass="btn btn-primary" />
                        <asp:HiddenField runat="server" ID="hdColorID" />
                        <asp:HiddenField runat="server" ID="hdIsEdit" />
                        <asp:HiddenField runat="server" ID="hdIsDelete" />

                        <asp:ValidationSummary
                            ShowMessageBox="true"
                            ShowSummary="false"
                            HeaderText="You must enter a value in the following fields:"
                            EnableClientScript="true"
                            runat="server" ValidationGroup="brandValidationGroup" />

                    </div>

                
            </div>

        </fieldset>
            </div>

        <div class="clearfix">
        </div>
        <div class="row">
            
            <fieldset>
            <legend>Color List</legend>
            <asp:ListView ID="lvColor" runat="server" DataKeyNames="IID"
                OnItemCommand="lvColor_ItemCommand" OnPagePropertiesChanging="lvColor_PagePropertiesChanging">
                <LayoutTemplate>
                    <table class="table table-bordered table-hover" style="margin-bottom: 0px;">
                        <thead>
                            <tr runat="server">
                                <th class="col-xs-1">SL #
                                </th>
                                <th class="col-xs-2">Code
                                </th>
                                <th class="col-xs-1">Name 
                                </th>
                            </tr>
                        </thead>
                        <tbody id="itemPlaceholder" runat="server">
                        </tbody>
                    </table>
                </LayoutTemplate>
                
                <ItemTemplate>
                    <tr id="trBody" runat="server" class="dGridRowClass">
                        <td style="text-align: left">
                            <%# Container.DataItemIndex + 1%>
                        </td>
                        <td style="text-align: left">
                            
                            <asp:LinkButton ID="lnkBtnName" runat="server" CausesValidation="false" Text='<%#Bind("Name")%>'
                                CommandArgument='<%# Bind("IID") %>' CommandName="EditColor"></asp:LinkButton>
                        </td>
                        <td style="text-align: left">
                            <asp:Label ID="lblCode" runat="server" Text='<%# Bind("Code") %>'></asp:Label>
                        </td>
                    </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <tr id="trBody"  runat="server" class="bg-info">
                        <td style="text-align: left">
                            <%# Container.DataItemIndex + 1%>
                        </td>
                        <td style="text-align: left">
                            
                            <asp:LinkButton ID="lnkBtnName" runat="server" CausesValidation="false" Text='<%#Bind("Name")%>'
                                CommandArgument='<%# Bind("IID") %>' CommandName="EditColor"></asp:LinkButton>
                        </td>
                        <td style="text-align: left">
                            <asp:Label ID="lblCode" runat="server" Text='<%# Bind("Code") %>'></asp:Label>
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
            <asp:DataPager ID="dataPagerColor" runat="server" PagedControlID="lvColor"
                PageSize="10" OnPreRender="dataPagerColor_PreRender">
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


