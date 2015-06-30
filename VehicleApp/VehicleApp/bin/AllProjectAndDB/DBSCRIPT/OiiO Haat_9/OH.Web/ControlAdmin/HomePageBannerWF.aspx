<%@ Page Title="" Language="C#" MasterPageFile="~/ControlAdmin/ControlAdminMaster.Master" AutoEventWireup="true" CodeBehind="HomePageBannerWF.aspx.cs" Inherits="OH.Web.ControlAdmin.HomePageBannerWF" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headAdmin" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentAdminMain" runat="server">
     <section>
    <div class="container adminPagewrp">
          <div class="row">
            <h2>OiiO HaaT Info
            </h2>
        </div>
          <div>
            <asp:Label ID="labelMessageBanner" runat="server" Text="..."></asp:Label>
        </div>
            <div>
            <fieldset>
                <legend>New Home Page Banner</legend>
                  <div class="row">
                    <div class="form-group col-xs-5">
                        <div class="input-group">
                            <span class="input-group-addon">Title
                            <asp:RequiredFieldValidator ID="rfvTitle" runat="server"
                                ControlToValidate="txtTitle" ForeColor="Red"
                                ToolTip="*" Display="Dynamic" ValidationGroup="ContentTitleValidationGroup" 
                                ErrorMessage="Enter Title...">*</asp:RequiredFieldValidator>
                            </span>
                            <asp:TextBox ID="txtTitle" runat="server" Text="" class="form-controlWebSer" placeholder="Enter Title..."></asp:TextBox>
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
                            <asp:TextBox ID="txtNote" runat="server" Text="" class="form-controlWebSer" placeholder="Enter Note..."></asp:TextBox>
                        </div>
                    </div>
                </div>
                  <div style="display:none">
                <asp:TextBox ID="txtHoldImagePath" runat="server"></asp:TextBox>
                </div>
                    <div class="row">
                    <div class="form-group col-xs-5">
                        <div class="input-group">
                            <span class="input-group-addon">Upload Banners
                            </span>
                            <asp:FileUpload ID="FileUploadImage" runat="server" AllowMultiple="True" class="form-controlWebSer"/>
                        </div>
                    </div>
                </div>
                 <div class="row">
                    <div class="form-group col-xs-5">
                        <div class="input-group">
                            <asp:CheckBox ID="chkBannerActv" runat="server" Text=" &nbsp Is Active"/>
                        </div>
                    </div>
                </div>
                 <div class="row">
                    <div class="col-xs-6">
                        <div class="input-group pull-right">
                            <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="ContentTitleValidationGroup" CssClass="btn btn-primary" OnClick="btnSave_Click" ></asp:Button>
                          &nbsp;
                              <asp:Button ID="btnUpdate" runat="server" Text="Update" ValidationGroup="ContentTitleValidationGroup"
                                CssClass="btn btn-primary" OnClick="btnUpdate_Click"  />
                            &nbsp;
                            <asp:Button ID="btnDelete" runat="server" Text="Delete"
                                CssClass="btn btn-primary"  Visible="false"/>
                            &nbsp;
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel"
                                CssClass="btn btn-primary" OnClick="btnCancel_Click"   />
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

          <div>
            <fieldset>
                <legend>HaaT Content Information</legend>
                <asp:ListView ID="lvBanner" runat="server" DataKeyNames="IID" OnItemCommand="lvBanner_ItemCommand" OnPagePropertiesChanging="lvBanner_PagePropertiesChanging" >
                    <LayoutTemplate>
                        <table class="table table-bordered table-hover" style="margin-bottom: 0px;">
                            <thead>
                                <tr runat="server">
                                    <th class="col-xs-1">Serial No
                                    </th>
                                    <th class="col-xs-1">Title
                                    </th>
                                    <th class="col-xs-1">Note
                                    </th>
                                    <th class="col-xs-1">Banner
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
                                <asp:Label ID="lblBannerID" runat="server" Text='<%# Bind("IID") %>' Visible="false"></asp:Label>
                                <asp:LinkButton ID="lnkBtnName" runat="server" CausesValidation="false" Text='<%#Bind("Title")%>'
                                 CommandArgument='<%# Bind("IID") %>' CommandName="EditBanner"></asp:LinkButton>
                            </td>
                            <td>
                                <asp:Label ID="lblShortDescription" runat="server" Text='<%# Bind("Note") %>'></asp:Label>
                            </td>
                           <td>
                             <div class="thumbnail">
                             <asp:Image runat="server" ID="OtherContentimg" Width="172" Height="80" ImageUrl='<%# Eval("Image") %>' alt="Image" />
                             <%--<asp:Label ID="lblImageUrl" runat="server" Text='<%# Bind("ImageUrl") %>'></asp:Label>--%>
                             </div>
                           </td>
                             
                           
                             <td>
                               <asp:CheckBox ID="chkIsActive" runat="server" Checked='<%# Bind("IsActive") %>' Enabled="false"/>
                             </td>
                        </tr>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <tr class="bg-info" runat="server">
                            <td style="text-align: center">
                                <%# Container.DataItemIndex + 1%>
                            </td>
                            <td style="text-align: left">
                                <asp:Label ID="lblBannerID" runat="server" Text='<%# Bind("IID") %>' Visible="false"></asp:Label>
                                <asp:LinkButton ID="lnkBtnName" runat="server" CausesValidation="false" Text='<%#Bind("Title")%>'
                                    CommandArgument='<%# Bind("IID") %>' CommandName="EditBanner"></asp:LinkButton>
                            </td>
                            <td>
                                <asp:Label ID="lblShortDescription" runat="server" Text='<%# Bind("Note") %>'></asp:Label>
                            </td>
                           <td>
                             <div class="thumbnail">
                             <asp:Image runat="server" ID="Image1" Width="172" Height="80" ImageUrl='<%# Eval("Image") %>' alt="Image" />
                             <%--<asp:Label ID="lblImageUrl" runat="server" Text='<%# Bind("ImageUrl") %>'></asp:Label>--%>
                             </div>
                           </td>
                              
                          
                            <td>
                               <asp:CheckBox ID="chkIsActive" runat="server" Checked='<%# Bind("IsActive") %>' Enabled="false"/>
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
                <asp:DataPager ID="dataPagerBanner" runat="server" PagedControlID="lvBanner"
                    PageSize="10" OnPreRender="dataPagerBanner_PreRender" >
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
         </section>
</asp:Content>
