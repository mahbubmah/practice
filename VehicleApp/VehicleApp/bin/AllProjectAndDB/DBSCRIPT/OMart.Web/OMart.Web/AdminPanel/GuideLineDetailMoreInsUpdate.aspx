<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.Master" AutoEventWireup="true" CodeBehind="GuideLineDetailMoreInsUpdate.aspx.cs" Inherits="OMart.Web.AdminPanel.GuideLineDetailMoreInsUpdate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AdminHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AdminContentPlaceHolder" runat="server">
    <section>
        <div class="container signpPage">
            <div class="row">
                <div class="col-sm-6">
                    <asp:Label ID="lblMassageGuideLineDetailMore" runat="server" Font-Size="Medium"></asp:Label>
                </div>
            </div>

            <div class="row">
                <div class="col-xs-6">
                    <div class="well signpPageLeft">
                        <div class="addPostMang">
                            <fieldset class="adminFieldset">
                                <legend>Add/Edit Guide Line Details</legend>
                                <div class="col-xs-12">
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="lblGiudeLine" runat="server" CssClass="control-label">Guide Line Title</asp:Label>
                                                <asp:DropDownList ID="ddlGiudeLineID" runat="server" Height="100%" class="form-control"></asp:DropDownList>
                                                 <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" InitialValue="-1" runat="server" ErrorMessage="Please select Guide Line Title"   ControlToValidate="ddlGiudeLineID" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                            </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="lblGiudeLineDetailTitle" runat="server" CssClass="control-label">Giude Line Detail Title</asp:Label>
                                                <asp:TextBox ID="txtGiudeLineDetailTitle" runat="server" CssClass="form-control"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rbfGiudeLineDetailTitle" runat="server" ControlToValidate="txtGiudeLineDetailTitle" ForeColor="Red"
                                                    ErrorMessage="PLease enter Giude Line Detail Title."
                                                    Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="lblGuideLineDetailsDescription" runat="server" CssClass="control-label">Giude Line Detail Description</asp:Label>
                                                <asp:TextBox ID="txtGuideLineDetailsDescription" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvGuideLineDetailsDescription" runat="server" ControlToValidate="txtGuideLineDetailsDescription" ForeColor="Red"
                                                    ErrorMessage="PLease enter Starting Giude Line Detail Title."
                                                    Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="lblGuideLineDetailsUploadImage" runat="server" CssClass="control-label">Giude Line Detail's Upload Image</asp:Label>
                                                <div style="display: none">
                                                    <asp:TextBox ID="txtGuideLineDetailsHoldImagePath" runat="server"></asp:TextBox>
                                                </div>
                                                <asp:FileUpload ID="FileUploadImageGuideLineDetails" runat="server" class="form-control" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row marginTop30px">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:CheckBox ID="chkIsRemovedForGuideLineDetails" runat="server" CssClass="checkbox-inline" Text="Is Removed"></asp:CheckBox>
                                                <%--  <asp:Label ID="Label4" runat="server" CssClass="control-label">Is Removed</asp:Label>--%>
                                            </div>
                                        </div>
                                    </div>
                             
                            </fieldset>
                               </div>


                        </div>
                    </div>
                


                <div class="col-xs-6">
                    <div class="well signpPageRight">
                        <div class="addPostMang">
                            <fieldset class="adminFieldset">
                                <legend>Add/Delete Guide Line Details More</legend>
                                <div class="col-xs-12">
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="lblGuideLineDetails" runat="server" CssClass="control-label">Guide Line Detail Title</asp:Label>
                                                <asp:DropDownList ID="ddlGuideLineDetails" runat="server" Height="100%" class="form-control"></asp:DropDownList>
                                                 <%-- <asp:RequiredFieldValidator InitialValue="-1" ID="rfvGiudeLineID" runat="server"
                                                    ControlToValidate="ddlGiudeLineID" ForeColor="Red"ErrorMessage="Please select Guide Line Title."
                                                    Display="Dynamic" ValidationGroup="GuideLineDetailsMore"></asp:RequiredFieldValidator>--%>
                                               <%-- <asp:RequiredFieldValidator ID="rfvGiudeLineDetailID" InitialValue="-1" runat="server" ErrorMessage="Please select Guide Line Title"   ControlToValidate="ddlGuideLineDetails" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="lblGuideLineDetailsMore" runat="server" CssClass="control-label">Giude Line Detail More Title</asp:Label>
                                                <asp:TextBox ID="txtGuideLineDetailsMoreTitle" runat="server" CssClass="form-control"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvGuideLineDetailsMore" runat="server" ControlToValidate="txtGuideLineDetailsMoreTitle" ForeColor="Red"
                                                    ErrorMessage="PLease enter Giude Line Detail More Title."
                                                    Display="Dynamic" ValidationGroup="GuideLineDetailsMore"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="lblGuideLineDetailsMoreDescription" runat="server" CssClass="control-label">Giude Line Detail More Description</asp:Label>
                                                <asp:TextBox ID="txtGuideLineDetailsMoreDescription" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvGuideLineDetailsMoreDescription" runat="server" ControlToValidate="txtGuideLineDetailsMoreDescription" ForeColor="Red"
                                                    ErrorMessage="PLease enter Giude Line Detail Description."
                                                    Display="Dynamic" ValidationGroup="GuideLineDetailsMore"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="lblGuideLineDetailsMoreUploadImage" runat="server" CssClass="control-label">Giude Line Detail's More Image Upload </asp:Label>
                                                <div style="display: none">
                                                    <asp:TextBox ID="txtGuideLineDetailsMoreHoldImagePath" runat="server"></asp:TextBox>
                                                </div>
                                                <asp:FileUpload ID="FileUploadImageGuideLineDetailsMore" runat="server" class="form-control" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row marginTop30px">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:CheckBox ID="chkIsRemovedForGuideLineDetailMore" runat="server" CssClass="checkbox-inline" Text="Is Removed"></asp:CheckBox>
                                                <%--  <asp:Label ID="Label4" runat="server" CssClass="control-label">Is Removed</asp:Label>--%>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row align-right">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Button ID="btnAddGuideLineDetailMore" runat="server" Text="Add Guide Line Detail More" CssClass="btn btn-primary" ValidationGroup="GuideLineDetailsMore" OnClick="btnAddGuideLineDetailMore_Click" />
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
                <div class="col-xs-12">
                    <div class="well signpPageLeft">
                        <div class="addPostMang">
                            <fieldset class="adminFieldset">
                                <legend>Guide Line Details More List</legend>
                                <asp:ListView ID="lvGuideLineDetailMore" runat="server" DataKeyNames="IID" OnPagePropertiesChanging="lvGuideLineDetailMore_PagePropertiesChanging" OnPreRender="lvGuideLineDetailMore_PreRender" OnItemCommand="lvGuideLineDetailMore_ItemCommand" >
                                    <LayoutTemplate>
                                        <table class="table  table-hover table-bordered">
                                            <thead>
                                                <tr runat="server">
                                                    <th class="col-xs-1" >SL #
                                                    </th>
                                                    <th class="col-xs-1">Title
                                                    </th>
                                                    <th class="col-xs-2">Description
                                                    </th>
                                                    <th class="col-xs-1">Image
                                                    </th>
                                                    <th class="col-xs-1">Is Remove
                                                    </th>
                                                    <th class="col-xs-1">Delete
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
                                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                                            </td>
                                           
                                            <td>
                                                <div class="thumbnail">
                                                    <asp:Image runat="server" ID="OtherContentimg" Width="102" Height="60" ImageUrl='<%# Eval("ImageUrl") %>' alt="Image" />
                                                  
                                                </div>
                                            </td>
                                            <td>
                                                   <asp:CheckBox ID="chkIsRemoved" runat="server" Checked='<%# Bind("IsRemoved") %>' Enabled="false"></asp:CheckBox>
                                                 </td>
                                            <td>
                                                <p data-placement="top" data-toggle="tooltip" title="Delete">
                                                    <asp:LinkButton ID="lnkbDelete" runat="server" CausesValidation="false" class="btn btn-danger btn-xs" data-title="Delete" OnClientClick="return confirm('Are you sure, do you want to delete?');"
                                                        CommandName="DeleteInfo" CommandArgument='<%# Bind("Title") %>'><i class="fa fa-trash"></i></asp:LinkButton>
                                                </p>
                                            </td>
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
                                <asp:DataPager ID="dataPagerGuideLineDetailMore" runat="server" PagedControlID="lvGuideLineDetailMore"
                                    PageSize="5" OnPreRender="dataPagerGuideLineDetailMore_PreRender" >
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
                                 <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-12">
                                                <asp:Button ID="btnCancel" runat="server" BorderWidth="5px" BorderColor="WhiteSmoke" Text="Cancel" CssClass="btn btn-danger pull-right" OnClick="btnCancel_Click"  />
                                                <asp:Button ID="btn_CreateOrEdit" runat="server" class="btn btn-primary  pull-right" Text="Submit"
                                                    ValidationGroup="gen" OnClick="btn_CreateOrEdit_Click" BorderWidth="5px" BorderColor="WhiteSmoke"></asp:Button>
                                            </div>
                                        </div>
                                    </div>
                            </fieldset>
                            
                        </div>
                    </div>
                    
                </div>
            </div>

       </div>
    </section>
</asp:Content>
