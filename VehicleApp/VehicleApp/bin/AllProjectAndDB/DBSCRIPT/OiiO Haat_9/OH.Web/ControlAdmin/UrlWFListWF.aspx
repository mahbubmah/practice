<%@ Page Title="" Language="C#" MasterPageFile="~/ControlAdmin/ControlAdminMaster.Master" AutoEventWireup="true" CodeBehind="UrlWFListWF.aspx.cs" Inherits="OH.Web.ControlAdmin.UrlWFListWF" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headAdmin" runat="server">
     <script type="text/javascript">
         $(function () {
             var txtQtyOfPro = $("#<%=txtUrlWFSerialNo.ClientID %>");
             $(txtQtyOfPro).keydown(function (event) {
                 if (event.keyCode == 46 || event.keyCode == 8 || event.keyCode == 9 || event.keyCode == 27 || (event.keyCode == 65 && event.ctrlKey === true) || (event.keyCode >= 35 && event.keyCode <= 39)) {
                     return;
                 }
                 else {
                     if ((event.keyCode < 48 || event.keyCode > 57) && (event.keyCode < 96 || event.keyCode > 105)) {
                         event.preventDefault();
                     }
                 }
             });
         });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentAdminMain" runat="server">
     <div class="container adminPagewrp">
         <div class="row">
                <h2>
                    Url List Information
                </h2>
         </div>
    
        <div class="row">
            <asp:Label ID="labelMessage" runat="server" Text="..."></asp:Label>
        </div>
   
        <fieldset>
            <legend>Add New Url</legend>

            <div class="row">
                <div class="form-group col-xs-5">
                    <div class="input-group">
                        <span class="input-group-addon">Module Name
                         
                         <asp:RequiredFieldValidator ID="groupName" runat="server" InitialValue="--Select Module Name--"
                                ControlToValidate="dropDownModuleName" ForeColor="Red"
                                ToolTip="*" Display="Dynamic" ValidationGroup="cValidationGroup" ErrorMessage="Select Module Name...">*</asp:RequiredFieldValidator>
                        </span>
                        <asp:DropDownList ID="dropDownModuleName" AutoPostBack="true" runat="server" Height="1%" class="form-control" OnSelectedIndexChanged="dropDownModuleName_SelectedIndexChanged1"></asp:DropDownList>
                   </div>              
                    
                </div>
            </div>
           
              <div class="row">
                <div class="form-group col-xs-5">
                    <div class="input-group">
                        <span class="input-group-addon">Module Serial No

                         </span>

                        <asp:TextBox ID="txtModuleSerialNo" runat="server" ReadOnly="true" Height="1%" class="form-control"></asp:TextBox>
                     </div>
                   </div>
                </div>
             <div class="row">
                <div class="form-group col-xs-5">
                    <div class="input-group">
                        <span class="input-group-addon">Url Name
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                ControlToValidate="txtUrlWFName" ForeColor="Red" 
                                ToolTip="*" Display="Dynamic" ValidationGroup="cValidationGroup" ErrorMessage="Enter Url Name...">*</asp:RequiredFieldValidator>
                        </span>
                        <asp:TextBox ID="txtUrlWFName" runat="server" Height="1%" class="form-control" ></asp:TextBox>
                     </div>                      
                   </div>
                </div>

             <div class="row">
                <div class="form-group col-xs-5">
                    <div class="input-group">
                        <span class="input-group-addon">Url Serial No
                            
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                ControlToValidate="txtUrlWFSerialNo" ForeColor="Red"
                                ToolTip="*" Display="Dynamic" ValidationGroup="cValidationGroup" ErrorMessage="Enter Url Serial No...">*</asp:RequiredFieldValidator>
                        </span>
                         <asp:TextBox ID="txtUrlWFSerialNo" runat="server" Height="1%" class="form-control"></asp:TextBox>
                      </div> 
                    </div>
                </div>
                   
                <div class="row">
                  <div class="form-group col-xs-5">
                    <div class="input-group">
                        <span class="input-group-addon">Url Display Name
                            
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                ControlToValidate="txtUrlWFDisplayName" ForeColor="Red" 
                                ToolTip="*" Display="Dynamic" ValidationGroup="cValidationGroup" ErrorMessage="Enter Url Serial No...">*</asp:RequiredFieldValidator>
                        </span>
                        <asp:TextBox ID="txtUrlWFDisplayName" runat="server" Height="1%" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                </div>
            
                 <div class="clearfix">
                 </div>
            <div class="row">
                <div class="col-xs-5 ">

                    <div class="input-group pull-right">

                         <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" CssClass="btn btn-primary"
                            ValidationGroup="cValidationGroup" ></asp:Button>
                        

                        <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click"
                            CssClass="btn btn-primary" ValidationGroup="cValidationGroup"/>

                        <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click"
                            CssClass="btn btn-primary" />

                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click"
                            CssClass="btn btn-primary" />

                        <asp:HiddenField runat="server" ID="hdUrlListID" />
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
                            <th class="col-xs-2">
                                Module Name
                            </th>
                            <th class="col-xs-2">
                                Module Serial No
                            </th>
                            <th class="col-xs-3">
                                UrlWF Name
                            </th>
                            <th class="col-xs-2">
                                UrlWF Display Name
                            </th>
                            <th class="col-xs-2">
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
                        <td style="text-align: left">
                            
                            <asp:LinkButton ID="lnkBtnName" runat="server" CausesValidation="false" Text='<%#Bind("ModuleName")%>'
                                CommandArgument='<%# Bind("IID") %>' CommandName="EditUrlWFList"> </asp:LinkButton>
                        </td>
                        <td style="text-align: right">
                            <asp:Label ID="lblCode" runat="server" Text='<%# Bind("ModuleSerialNo") %>'></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:Label ID="lblDescription" runat="server" Text='<%# Bind("UrlWFName") %>'></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:Label ID="lblApplicableCountryID" runat="server" Text='<%# Bind("UrlWFDisplayName") %>'></asp:Label>
                        </td>
                        <td style="text-align: right">
                            <asp:Label ID="lblUrlSerialNo" runat="server" Text='<%# Bind("UrlWFSerialNO") %>'></asp:Label>
                        </td>
                    </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <tr id="trBody" runat="server" class="bg-info">
                        <td style="text-align: center">
                            <%# Container.DataItemIndex + 1%>
                        </td>
                        <td style="text-align: left">
                              <asp:LinkButton ID="lnkBtnName" runat="server" CausesValidation="false" Text='<%#Bind("ModuleName")%>'
                                CommandArgument='<%# Bind("IID") %>' CommandName="EditUrlWFList"></asp:LinkButton>
                        </td>
                        <td style="text-align: right">
                            <asp:Label ID="lblCode" runat="server" Text='<%# Bind("ModuleSerialNo") %>'></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:Label ID="lblDescription" runat="server" Text='<%# Bind("UrlWFName") %>'></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:Label ID="lblApplicableCountryID" runat="server" Text='<%# Bind("UrlWFDisplayName") %>'></asp:Label>
                        </td>
                         <td style="text-align: right">
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
             <p> <br /> <br /></p> 
        </fieldset>
      </div>
    </div>
</asp:Content>

