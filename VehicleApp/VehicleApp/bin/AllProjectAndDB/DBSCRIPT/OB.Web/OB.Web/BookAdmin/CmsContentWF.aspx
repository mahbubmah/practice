<%@ Page Title="" Language="C#" MasterPageFile="~/BookAdmin/OiiOMasterPage.Master" AutoEventWireup="true" CodeBehind="CmsContentWF.aspx.cs" Inherits="OB.Web.BookAdmin.CmsContentWF" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <section>
        <div class="mainpageBody">
            <div class="container">
                <div class="row">
                    <div class="col-sm-12">
                        <asp:Label ID="labelMessage" runat="server"></asp:Label>
                    </div>
                </div>
                 <div class="row">
                    <div class="col-sm-12">
                        <div class="manageAdd">
                            <div class="addPostMang">
                                <fieldset class="adminFieldset">
                                    <legend>Add/Edit Book CMS Details</legend>
                                    <div class="col-xs-12">
                                        <div class="col-xs-9">

                                            <div class="row">
                                                <div class="form-group">
                                                    <div class="col-sm-8 col-md-8">
                                                        <asp:Label ID="Label1" runat="server" CssClass="control-label">Select CMS type</asp:Label>
                                                       <asp:DropDownList ID="ddlCMSType" runat="server" CssClass="dropdown"  Width="100%" Height="32px">
                                                    </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" InitialValue="-1" runat="server" ControlToValidate="ddlCMSType" ForeColor="Red"
                                                            ErrorMessage="PLease enter Book CMS type"
                                                            Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                            </div>


                                            <div class="row">
                                                <div class="form-group">
                                                    <div class="col-sm-8 col-md-8">
                                                        <asp:Label ID="lblCMSTitle" runat="server" CssClass="control-label">Book CMS Title</asp:Label>
                                                        <asp:TextBox ID="txtCMSTitle" runat="server" CssClass="form-control"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rbfGiudeLineDetailTitle" runat="server" ControlToValidate="txtCMSTitle" ForeColor="Red"
                                                            ErrorMessage="PLease enter Book CMS Title"
                                                            Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                            </div>

                                          
                                            <div class="row">
                                                <div class="form-group">
                                                    <div class="col-sm-8 col-md-8">
                                                        <asp:Label ID="lblCMSDescription" runat="server" CssClass="control-label">Book CMS Description</asp:Label>
                                                        <CKEditor:CKEditorControl ID="txtBookCMSDescription" Visible="true" BasePath="/ckeditor/" runat="server" placeholder="Enter Book Description..." Height="100px"></CKEditor:CKEditorControl>
                                                        <asp:RequiredFieldValidator ID="rfvCMSDescription" runat="server" ControlToValidate="txtBookCMSDescription" ForeColor="Red"
                                                            ErrorMessage="PLease enter Book Detail."
                                                            Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                            </div>
                                           
                                        
                                         
                                           
                                            <div class="row">
                                                <div class="form-group">
                                                    <div class="col-sm-8 col-md-8">
                                                        <asp:Label ID="lblImageUpload" runat="server" CssClass="control-label">Upload Image For CMS (Optional)</asp:Label>
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
                                                        <asp:CheckBox ID="chkIsActive" runat="server" Text=" &nbsp Is Active" />
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-xs-8">
                                                    <div class="input-group pull-right">
                                                        <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="gen" CssClass="btn btn-primary" OnClick="btnSave_Click" ></asp:Button>
                                                        &nbsp;
                          
                            &nbsp;
                            <asp:Button ID="btnUpdate" runat="server" Text="Update" ValidationGroup="gen"
                                CssClass="btn btn-primary" OnClick="btnUpdate_Click"  />
                                                        &nbsp;
                          
                            &nbsp;
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel"
                                CssClass="btn btn-primary" OnClick="btnCancel_Click"  />
                                                        <asp:HiddenField runat="server" ID="hdContentID" />
                                                        <asp:HiddenField runat="server" ID="hdIsEdit" />
                                                        <%--<asp:HiddenField runat="server" ID="hdIsDelete" />--%>
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

                                        </div>
                                    </div>
                                  

                                </fieldset>
                            </div>
                        </div>
                    </div>
                </div>



      <div class="row">
                <div class="col-sm-12">
                    <div class="manageAdd">
                        <div class="addPostMang">

                            <fieldset class="adminFieldset">
                                <legend>Book News CMS lists</legend>

                                <asp:ListView ID="lvBookCMSContent" runat="server" DataKeyNames="IID" OnPagePropertiesChanging="lvBookCMSContent_PagePropertiesChanging">
                                    <LayoutTemplate>
                                        <table class="table  table-hover table-bordered">
                                            <thead>
                                                <tr runat="server">
                                                    <th class="col-xs-1">SL #
                                                    </th>
                                                    <th class="col-xs-2">News CMS Type
                                                    </th>
                                                   <th class="col-xs-2">News CMS Title
                                                    </th>
                                                     <th class="col-xs-4">News CMS Description
                                                    </th>
                                                    <th class="col-xs-2">Image
                                                    </th>
                                                
                                                     <th class="col-xs-1">Is Removed
                                                    </th>
                                                    <th>Edit
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
                                                <asp:Label ID="lblName" runat="server" Text='<%#Enum.Parse(typeof(OB.Utilities.EnumCollection.CMSType), Eval("CMSTypeID").ToString()).ToString().Replace("_"," ")%>'></asp:Label>
                                            </td>
                                         
                                            <td>
                                                <asp:Label ID="lblFavQoute" runat="server" Text='<%# Bind("Title") %>'></asp:Label>
                                            </td>
                                           
                                              <td>
                                                   <div style="height:65px;overflow:hidden">
                                                <asp:Label ID="lblCountry" runat="server" Text='<%# Bind("CMSDescription") %>'></asp:Label>
                                             </div>
                                                         </td>
                                             
                                             
                                               <td>
                                                <div class="thumbnail">
                                                    <asp:Image runat="server" ID="OtherContentimg" Width="110" Height="60" ImageUrl='<%# Eval("ImageUrl") %>' alt="Image" />
                                                </div>
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="chkIssRemoved" runat="server" Checked='<%# Bind("IsActive") %>' Enabled="false"></asp:CheckBox>
                                            </td>

                                            <td>
                                                <p data-placement="top" data-toggle="tooltip" title="Edit">
                                                    <asp:LinkButton ID="lnkbEdit" runat="server" CausesValidation="false" class="btn btn-primary btn-xs" data-title="Edit"
                                                        CommandArgument='<%# Bind("IID") %>' OnClick="lnkbEdit_Click"><i class="fa fa-pencil-square-o"></i></asp:LinkButton>

                                                </p>
                                            </td>
                                          <%--  <td>
                                                <p data-placement="top" data-toggle="tooltip" title="Delete">
                                                    <asp:LinkButton ID="lnkbDelete" runat="server" CausesValidation="false" class="btn btn-danger btn-xs" data-title="Delete" OnClientClick="return confirm('Are you sure, do you want to delete?');"
                                                        CommandArgument='<%# Bind("IID") %>' OnClick="lnkbDelete_Click"><i class="fa fa-trash"></i></asp:LinkButton>
                                                </p>
                                            </td>--%>


                                        </tr>
                                    </ItemTemplate>

                                    <EmptyDataTemplate>
                                        <tr>
                                            <td>Information is empty ...
                                            </td>
                                        </tr>
                                        </table>
                                    </EmptyDataTemplate>
                                </asp:ListView>
                                <asp:DataPager ID="dataPagerBookCMSContent" runat="server" PagedControlID="lvBookCMSContent"
                                    PageSize="10" OnPreRender="dataPagerBookCMSContent_PreRender" >
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
            </div>
           </section>
</asp:Content>
