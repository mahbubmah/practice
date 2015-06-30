<%@ Page Title="" Language="C#" MasterPageFile="~/ControlAdmin/ControlAdminMaster.Master" AutoEventWireup="true" CodeBehind="OiiOOtherContentWF.aspx.cs" Inherits="OH.Web.ControlAdmin.OiiOOtherContentWF" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headAdmin" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentAdminMain" runat="server">

     <div class="container adminPagewrp">
        <div class="row">
            <h2>Other Content Info
            </h2>
        </div>
        <div>
            <asp:Label ID="labelMessageOtherContent" runat="server" Text="..."></asp:Label>
        </div>
         <div>
            <fieldset>
                <legend>New Content</legend>
                 <div class="row">
                    <div class="form-group col-xs-5">
                        <div class="input-group">
                            <span class="input-group-addon">Content Title
                            <asp:RequiredFieldValidator ID="rfvContentTitle" runat="server"
                                ControlToValidate="txtContentTitle" ForeColor="Red"
                                ToolTip="*" Display="Dynamic" ValidationGroup="ContentTitleValidationGroup" ErrorMessage="Enter Content Title...">*</asp:RequiredFieldValidator>
                         <%-- <asp:RegularExpressionValidator ID="RegularExpressionValidatoroiiocntnt" ValidationGroup="UserValidationGroup" runat="server" ControlToValidate="txtContentTitle" ErrorMessage="Enter Only Numeric and characters" ValidationExpression="^\b{1,20}$">*</asp:RegularExpressionValidator>--%>
                                  </span>
                            <asp:TextBox ID="txtContentTitle" runat="server" Text="" MaxLength="30" class="form-controlWebSer" placeholder="Enter Content Title..."></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="form-group col-xs-5">
                        <div class="input-group">
                            <span class="input-group-addon">Short Discription of Content
                            <asp:RequiredFieldValidator ID="rfvShortDiscription" runat="server"
                                ControlToValidate="txtShortDiscription" ForeColor="Red"
                                ToolTip="*" Display="Dynamic" ValidationGroup="ContentTitleValidationGroup" 
                                ErrorMessage="Enter Short Discription...">*</asp:RequiredFieldValidator>
                            </span>
                            <asp:TextBox ID="txtShortDiscription" runat="server" Text="" class="form-controlWebSer" placeholder="Enter Short Discription..."></asp:TextBox>
                        </div>
                    </div>
                </div>
                
                <div style="display:none">
                <asp:TextBox ID="txtHoldImagePath" runat="server"></asp:TextBox>
                </div>
                    <div class="row">
                    <div class="form-group col-xs-5">
                        <div class="input-group">
                            <span class="input-group-addon">Upload Image For Content
                          <%--  <asp:RequiredFieldValidator ID="rfvImage" runat="server"
                                ControlToValidate="FileUploadImage" ForeColor="Red"
                                ToolTip="*" Display="Dynamic" ValidationGroup="ContentTitleValidationGroup" 
                                ErrorMessage="Upload Image...">*</asp:RequiredFieldValidator>--%>
                            </span>

                            <asp:FileUpload ID="FileUploadImage" runat="server" class="form-controlWebSer"/>
                          <%--  <asp:TextBox ID="TextBox2" runat="server" Text="" class="form-control" placeholder="Enter Post Office Name..."></asp:TextBox>--%>
                        </div>
                    </div>
                </div>

                 <div class="row">
                    <div class="form-group col-xs-5">
                        <div class="input-group">
                            <span class="input-group-addon">Details Discription of Content
                            <asp:RequiredFieldValidator ID="rfvDetailsDiscription" runat="server"
                                ControlToValidate="txtDetailsDiscription" ForeColor="Red"
                                ToolTip="*" Display="Dynamic" ValidationGroup="ContentTitleValidationGroup" ErrorMessage="Enter Details Discription...">*</asp:RequiredFieldValidator>
                            </span>
                            <asp:TextBox ID="txtDetailsDiscription" runat="server" Text="" class="form-controlWebSer" placeholder="Enter Details Discription..." TextMode="MultiLine" Height="150px"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="form-group col-xs-5">
                        <div class="input-group">
                          
                            <asp:CheckBox ID="chkOtherContentActv" runat="server" Text=" &nbsp Is Active"/>
                        </div>
                    </div>
                </div>

                 <div class="row">
                    <div class="col-xs-6">
                        <div class="input-group pull-right">
                            <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="ContentTitleValidationGroup" CssClass="btn btn-primary" OnClick="btnSave_Click"  ></asp:Button>
                            <asp:Button ID="btnUpdate" runat="server" Text="Update" ValidationGroup="ContentTitleValidationGroup"
                                CssClass="btn btn-primary" OnClick="btnUpdate_Click" />
                            &nbsp;
                            <asp:Button ID="btnDelete" runat="server" Text="Delete"
                                CssClass="btn btn-primary" OnClick="btnDelete_Click" Visible="false"/>
                            &nbsp;
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel"
                                CssClass="btn btn-primary" OnClick="btnCancel_Click"  />
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
                <legend>Other Content Information</legend>
                <asp:ListView ID="lvContent" runat="server" DataKeyNames="IID" OnItemCommand="lvContent_ItemCommand" OnPagePropertiesChanged="lvContent_PagePropertiesChanged" OnPagePropertiesChanging="lvContent_PagePropertiesChanging" >
                    <LayoutTemplate>
                        <table class="table table-bordered table-hover" style="margin-bottom: 0px;">
                            <thead>
                                <tr runat="server">
                                    <th class="col-xs-1">SL #
                                    </th>
                                    <th class="col-xs-1">Title
                                    </th>
                                    <th class="col-xs-1">Short Discription
                                    </th>
                                    <th class="col-xs-1">Detail Discription
                                    </th>
                                    <th class="col-xs-1">Image Url  
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
                                <asp:Label ID="lblPostOfficeID" runat="server" Text='<%# Bind("IID") %>' Visible="false"></asp:Label>
                                <asp:LinkButton ID="lnkBtnName" runat="server" CausesValidation="false" Text='<%#Bind("Title")%>'
                                    CommandArgument='<%# Bind("IID") %>' CommandName="EditContent"></asp:LinkButton>
                            </td>
                            <td>
                                <asp:Label ID="lblShortDescription" runat="server" Text='<%# Bind("ShortDescription") %>'></asp:Label>
                            </td>
                            <td >
                             <p style="width: 200px;height:156px;overflow:hidden ">
                                 <asp:Label ID="lblDetailDescription" runat="server" Text='<%# Bind("DetailDescription") %>'></asp:Label>
                           </p>                            
                            </td>
                            <td>
                             <div class="thumbnail">
                             <asp:Image runat="server" ID="OtherContentimg" Width="172" Height="130" ImageUrl='<%# Eval("ImageUrl") %>' alt="Image" />
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
                                <asp:Label ID="lblPostOfficeID" runat="server" Text='<%# Bind("IID") %>' Visible="false"></asp:Label>
                                <asp:LinkButton ID="lnkBtnName" runat="server" CausesValidation="false" Text='<%#Bind("Title")%>'
                                    CommandArgument='<%# Bind("IID") %>' CommandName="EditContent"></asp:LinkButton>
                            </td>
                            <td>
                                <asp:Label ID="lblShortDescription" runat="server" Text='<%# Bind("ShortDescription") %>'></asp:Label>
                            </td>
                            <td >
                                <p style="width: 200px;height:156px;overflow:hidden ">
                                <asp:Label ID="lblDetailDescription" runat="server" Text='<%# Bind("DetailDescription") %>'></asp:Label>
                           </p>
                             </td>
                            <td>
                             <div class="thumbnail">
                             <asp:Image runat="server" ID="OtherContentimg" Width="172" Height="130" ImageUrl='<%# Eval("ImageUrl") %>' alt="Image" />
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
                <asp:DataPager ID="dataPagerContent" runat="server" PagedControlID="lvContent"
                    PageSize="10" OnPreRender="dataPagerContent_PreRender" >
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
