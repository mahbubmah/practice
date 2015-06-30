<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AllFeatureInsertUpdate.aspx.cs" Inherits="OMart.Web.AdminPanel.AllFeatureInsertUpdate" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxConTK" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AdminHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AdminContentPlaceHolder" runat="server">
    <br />
    <section>
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
                                <legend>Add/Edit Features</legend>
                                <div class="col-xs-6">

                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="lblCompanyInfo" runat="server" CssClass="control-label">Business type</asp:Label>
                                                <asp:DropDownList runat="server" OnSelectedIndexChanged="dropDownBusinessType_SelectedIndexChanged" AutoPostBack="True" CssClass="form-control" ID="dropDownBusinessType" />
                                                <asp:RequiredFieldValidator InitialValue="-1" ID="RequiredFieldValidator4" runat="server" ControlToValidate="dropDownBusinessType" ForeColor="Red"
                                                    ErrorMessage="Please select business type."
                                                    Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="Label10" runat="server" CssClass="control-label">Business type breakdown</asp:Label>
                                                <asp:DropDownList runat="server" CssClass="form-control" ID="dropDownBusinessTypeBreakdown" />

                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="Label1" runat="server" CssClass="control-label">Title name</asp:Label>
                                                <asp:TextBox ID="txtTitleName" runat="server" CssClass="form-control"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTitleName" ForeColor="Red"
                                                    ErrorMessage="Please enter Title."
                                                    Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="Label7" runat="server" CssClass="control-label">Image Url</asp:Label>
                                                <asp:FileUpload ID="parentPictureFileUpload" runat="server" class="fa-file-image-o" />
                                                <asp:Button runat="server" ID="btnParentPictureUpload" Text="Upload Logo" Visible="false" OnClick="btnParentPictureUpload_Click" class="btn btn-primary" />
                                            </div>
                                        </div>
                                    </div>
                                    <br />

                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="Label2" runat="server" CssClass="control-label">Description</asp:Label>
                                                <asp:TextBox ID="txtDescription" TextMode="MultiLine" runat="server" CssClass="form-control"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDescription" ForeColor="Red"
                                                    ErrorMessage="Please enter Description."
                                                    Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9 ">
                                                <asp:Button ID="btnCreateOrEdit" runat="server" class="btn btn-primary pull-right" Text="Submit"
                                                    OnClick="btnCreateOrEdit_Click" ValidationGroup="gen"></asp:Button>
                                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-danger " OnClick="btnCancel_Click" />
                                            </div>
                                        </div>
                                    </div>
                                </div>


                                <div class="col-xs-6">
                                    <fieldset>
                                        <legend>Add/Edit Feature Deatils</legend>
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="Label3" runat="server" CssClass="control-label">Title name</asp:Label>
                                                    <asp:TextBox ID="txtDetailTitleName" runat="server" CssClass="form-control"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtDetailTitleName" ForeColor="Red"
                                                        ErrorMessage="Please enter Title."
                                                        Display="Dynamic" ValidationGroup="child"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="lbl11" runat="server" CssClass="control-label">Image Url</asp:Label>
                                                    <asp:FileUpload ID="childPictureUpload" runat="server" class="fa-file-image-o" />
                                                    <asp:Button runat="server" ID="btndeChildPictureUpload" Text="Upload Logo" Visible="false" OnClick="btndeChildPictureUpload_Click" class="btn btn-primary" />
                                                </div>
                                            </div>
                                        </div>
                                        <br />

                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="Label5" runat="server" CssClass="control-label">Description</asp:Label>
                                                    <asp:TextBox ID="txtDetailDescription" TextMode="MultiLine" runat="server" CssClass="form-control"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtDetailDescription" ForeColor="Red"
                                                        ErrorMessage="Please enter Description."
                                                        Display="Dynamic" ValidationGroup="child"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9 ">
                                                    <asp:Button ID="btnCreateOrEditAllFeatureDetail" runat="server" class="btn btn-primary pull-right" Text="Add"
                                                        OnClick="btnCreateOrEditAllFeatureDetail_Click" ValidationGroup="child"></asp:Button>
                                                    <asp:Button ID="btnCancelAllNewsDetail" runat="server" Text="Cancel" CssClass="btn btn-danger " OnClick="btnCancelAllNewsDetail_Click" />
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <asp:ListView ID="lvAllFeatureDetails" runat="server" DataKeyNames="IID"
                                            OnPagePropertiesChanging="lvAllFeatureDetails_PagePropertiesChanging">
                                            <LayoutTemplate>
                                                <table class="table  table-hover table-bordered">
                                                    <thead>
                                                        <tr runat="server">
                                                            <th class="col-xs-1">SL #
                                                            </th>
                                                            <th class="col-xs-4">Title
                                                            </th>
                                                            <th class="col-xs-4">Description
                                                            </th>
                                                            <th class="col-xs-4">Image url
                                                            </th>
                                                            
                                                            <th>Delete
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
                                                    <td >
                                                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("TitleName") %>'></asp:Label>
                                                    </td>
                                                     <td >
                                                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Image runat="server" ID="img" ImageUrl='<%# Bind("ImageUrl") %>' Width="50" Height="50" />
                                                        <%--<asp:Label ID="Label6" runat="server" Text='<%# Bind("ImageUrl") %>'></asp:Label>--%>
                                                    </td>
                                                   

                                                    <td>
                                                        <p data-placement="top" data-toggle="tooltip" title="Delete">
                                                            <asp:LinkButton ID="lnkbDelete" runat="server" CausesValidation="false" class="btn btn-danger btn-xs" data-title="Delete"
                                                                CommandArgument='<%# Bind("TitleName") %>' OnClick="lnkbDelete_Click"><i class="fa fa-trash"></i></asp:LinkButton>
                                                        </p>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:ListView>
                                    </fieldset>

                                </div>
                            </fieldset>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
