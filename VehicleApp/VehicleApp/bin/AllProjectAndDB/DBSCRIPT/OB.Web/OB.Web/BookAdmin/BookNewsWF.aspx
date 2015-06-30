<%@ Page Title="" Language="C#" MasterPageFile="~/BookAdmin/OiiOMasterPage.Master" AutoEventWireup="true" CodeBehind="BookNewsWF.aspx.cs" Inherits="OB.Web.BookAdmin.BookNewsWF" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxConTK" %>
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
                                    <legend>Add/Edit Book News Details</legend>
                                    <div class="col-xs-12">
                                        <div class="col-xs-9">
                                            <div class="row">
                                                <div class="form-group">
                                                    <div class="col-sm-8 col-md-8">
                                                        <asp:Label ID="lblNewsHeadLine" runat="server" CssClass="control-label">Book News HeadLine</asp:Label>
                                                        <asp:TextBox ID="txtNewsHeadLine" runat="server" CssClass="form-control"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rbfGiudeLineDetailTitle" runat="server" ControlToValidate="txtNewsHeadLine" ForeColor="Red"
                                                            ErrorMessage="PLease enter Book News HeadLine"
                                                            Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                            </div>

                                          
                                            <div class="row">
                                                <div class="form-group">
                                                    <div class="col-sm-8 col-md-8">
                                                        <asp:Label ID="lblDescription" runat="server" CssClass="control-label">Book Description</asp:Label>
                                                        <CKEditor:CKEditorControl ID="txtBookDescription" BasePath="/ckeditor/" runat="server" placeholder="Enter Book Description..." Height="100px"></CKEditor:CKEditorControl>
                                                        <asp:RequiredFieldValidator ID="rfvDescription" runat="server" ControlToValidate="txtBookDescription" ForeColor="Red"
                                                            ErrorMessage="PLease enter Book Detail."
                                                            Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                            </div>
                                           
                                            <div class="row">
                                                <div class="form-group">
                                                    <div class="col-sm-8 col-md-8">
                                                        <asp:Label ID="lblPublishDate" runat="server" CssClass="control-label">Book Publish Date</asp:Label>
                                                        <asp:TextBox ID="txtPublishDate" runat="server" CssClass="form-control" ></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvPublishDate" runat="server" ControlToValidate="txtPublishDate" ForeColor="Red"
                                                            ErrorMessage="PLease enter Book Publish Date."
                                                            Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                                        <ajaxConTK:CalendarExtender runat="server" ID="BookPublicationdate" TargetControlID="txtPublishDate" Format="MM/dd/yyyy" ></ajaxConTK:CalendarExtender>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="form-group">
                                                    <div class="col-sm-8 col-md-8">
                                                        <asp:Label ID="lblAudio" runat="server" CssClass="control-label">Audio Tutorial Link (Optional)</asp:Label>
                                                        <asp:TextBox ID="txtAudio" runat="server" CssClass="form-control" TextMode="Url" placeholder="Example: http://www.oiiobooks.com/"></asp:TextBox>
                                                      <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAudio" ForeColor="Red"
                                                            ErrorMessage="PLease enter Book Detail."
                                                            Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>--%>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="form-group">
                                                    <div class="col-sm-8 col-md-8">
                                                        <asp:Label ID="iblVideo" runat="server" CssClass="control-label">Video Tutorial Link (Optional)</asp:Label>
                                                        <asp:TextBox ID="txtVideo" runat="server" CssClass="form-control" TextMode="Url" placeholder="Example: http://www.oiiobooks.com/"></asp:TextBox>
                                                       <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtVideo" ForeColor="Red"
                                                            ErrorMessage="PLease enter Book Detail."
                                                            Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>--%>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="form-group">
                                                    <div class="col-sm-8 col-md-8">
                                                        <asp:Label ID="lblImageUpload" runat="server" CssClass="control-label">Upload Image For BookNews (Optional)</asp:Label>
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
                                                        <asp:CheckBox ID="chkRemove" runat="server" Text=" &nbsp Is Remove" />
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
                                <legend>Book News lists</legend>

                                <asp:ListView ID="lvBookNews" runat="server" DataKeyNames="IID" OnPagePropertiesChanging="lvABookNews_PagePropertiesChanging">
                                    <LayoutTemplate>
                                        <table class="table  table-hover table-bordered">
                                            <thead>
                                                <tr runat="server">
                                                    <th class="col-xs-1">SL #
                                                    </th>
                                                    <th class="col-xs-2">News Head Line
                                                    </th>
                                                   <%-- <th class="col-xs-2">Description 
                                                    </th>--%>
                                                    <th class="col-xs-2">Image
                                                    </th>
                                                     <th class="col-xs-2">Audio Link
                                                    </th>
                                                    <th class="col-xs-2">Video Link
                                                    </th>
                                                     <th class="col-xs-1">Publication Date
                                                    </th>
                                                     <th class="col-xs-2">Is Removed
                                                    </th>
                                                    <th>Edit
                                                    </th>
                                                  <%--  <th>Delete
                                                    </th>--%>

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
                                                <asp:Label ID="lblName" runat="server" Text='<%# Bind("HeadLine") %>'></asp:Label>
                                            </td>
                                            <td>
                                                <div class="thumbnail">
                                                    <asp:Image runat="server" ID="OtherContentimg" Width="102" Height="60" ImageUrl='<%# Eval("ImageUrl") %>' alt="Image" />
                                                </div>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblFavQoute" runat="server" Text='<%# Bind("Audio") %>'></asp:Label>
                                            </td>
                                              <td>
                                                <asp:Label ID="lblCountry" runat="server" Text='<%# Bind("VideoLink") %>'></asp:Label>
                                            </td>
                                             <td>
                                               
                                                  <asp:Label ID="Label1" runat="server" Text='<%# Bind("PublishDate") %>'></asp:Label>
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="chkIssRemoved" runat="server" Checked='<%# Bind("IsRemoved") %>' Enabled="false"></asp:CheckBox>
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
                                <asp:DataPager ID="dataPagerBookNews" runat="server" PagedControlID="lvBookNews"
                                    PageSize="10" OnPreRender="dataPagerBookNews_PreRender" >
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
