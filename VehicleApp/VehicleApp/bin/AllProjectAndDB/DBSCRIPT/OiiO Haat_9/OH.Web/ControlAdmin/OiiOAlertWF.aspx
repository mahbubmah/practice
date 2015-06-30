<%@ Page Title="" Language="C#" MasterPageFile="~/ControlAdmin/ControlAdminMaster.Master" AutoEventWireup="true" CodeBehind="OiiOAlertWF.aspx.cs" Inherits="OH.Web.ControlAdmin.OiiOAlertWF" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headAdmin" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentAdminMain" runat="server">

      <section>
        <div class="container signpPage">
             <div class="row">
                <div class="col-sm-9">
                    <asp:Label ID="lblMassageAlert" runat="server" Font-Size="Medium"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12">
                    <div class="well signpPageLeft">
                        <div class="addPostMang">
                            <fieldset class="adminFieldset">
                                <legend>Add/Edit Alert Details</legend>
                       
                                     <div class="row">
                                    <div class="form-group">
                                        <div class="col-sm-9 col-md-9">
                                            <asp:Label ID="lblTitle" runat="server" CssClass="control-label">Alert Title</asp:Label>
                                            <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rbfGiudeLineDetailTitle" runat="server" ControlToValidate="txtTitle" ForeColor="Red"
                                                ErrorMessage="PLease enter Alert Title"
                                                Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                   <div class="row">
                                    <div class="form-group">
                                        <div class="col-sm-9 col-md-9 col-lg-9">
                                            <asp:Label ID="lblDescription" runat="server" CssClass="control-label"> Description</asp:Label>
                                            <CKEditor:CKEditorControl ID="txtDescription" BasePath="/ckeditor/" runat="server" placeholder="Enter Description..." Height="100px"></CKEditor:CKEditorControl>
                                            <asp:RequiredFieldValidator ID="rfvDescription" runat="server" ControlToValidate="txtDescription" ForeColor="Red"
                                                ErrorMessage="PLease enter Description."
                                                Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                 <div class="row">
                                    <div class="form-group">
                                        <div class="col-sm-9 col-md-9">
                                            <asp:Label ID="lblImageUpload" runat="server" CssClass="control-label">Upload Image For Alert (Optional)</asp:Label>
                                            <div style="display: none">
                                                <asp:TextBox ID="txtHoldImagePath" runat="server"></asp:TextBox>
                                            </div>
                                            <asp:FileUpload ID="FileUploadImage" runat="server" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                                  <div class="row">
                                    <div class="form-group col-xs-5">
                                        <div class="input-group">
                                            <asp:CheckBox ID="chkActv" runat="server" Text=" &nbsp Is Active" />
                                        </div>
                                    </div>
                                </div>
                                                 <div class="row">
                                    <div class="col-xs-9">
                                        <div class="input-group pull-right">
                                            <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="gen" CssClass="btn btn-primary" OnClick="btnSave_Click"  ></asp:Button>
                                            &nbsp;
                          
                            &nbsp;
                            <asp:Button ID="btnUpdate" runat="server" Text="Update" ValidationGroup="gen"
                                CssClass="btn btn-primary" OnClick="btnUpdate_Click" />
                                            &nbsp;
                          
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
                                                runat="server" ValidationGroup="gen" />
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
                                <legend>Alert List</legend>
                                  <asp:ListView ID="lvAlert" runat="server" DataKeyNames="IID" OnPagePropertiesChanging="lvAlert_PagePropertiesChanging" >
                    <LayoutTemplate>
                        <table class="table table-bordered table-hover" style="margin-bottom: 0px;">
                            <thead>
                                <tr runat="server">
                                    <th class="col-xs-1">SL #
                                    </th>
                                    <th class="col-xs-1">Title
                                    </th>
                                
                                    <th class="col-xs-1">Image Url  
                                    </th>
                                     <th class="col-xs-1">Is Active
                                    </th>
                                    <th class="col-xs-1">Edit
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
                                            <td>
                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("Title") %>'></asp:Label>
                                            </td>
                               
                                           
                                            <td>
                                                <div class="thumbnail">
                                                    <asp:Image runat="server" ID="OtherContentimg" Width="82" Height="60" ImageUrl='<%# Eval("Image") %>' alt="Image" />
                                                  
                                                </div>
                                            </td>
                                            <td>
                                                   <asp:CheckBox ID="chkIsActive" runat="server" Checked='<%# Bind("IsActive") %>' Enabled="false"></asp:CheckBox>
                                                 </td>
                                             <td>
                                                <p data-placement="top" data-toggle="tooltip" title="Edit">
                                                      <asp:Label ID="lblhelpSupportID" runat="server" Text='<%# Bind("IID") %>' Visible="false"></asp:Label>
                                                    <asp:LinkButton ID="lnkbEdit" runat="server" CausesValidation="false" class="btn btn-primary btn-xs" data-title="Edit"
                                                        CommandArgument='<%# Bind("IID") %>' OnClick="lnkbEdit_Click"><i class="fa fa-pencil-square-o"></i></asp:LinkButton>
                                                </p>
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
                <asp:DataPager ID="dataPagerAlert" runat="server" PagedControlID="lvAlert"
                    PageSize="10" OnPreRender="dataPagerAlert_PreRender"    >
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
