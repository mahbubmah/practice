<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.Master" AutoEventWireup="true" CodeBehind="BICategoryInsertUpdate.aspx.cs" Inherits="OMart.Web.AdminPanel.BICategoryInsertUpdate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AdminHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AdminContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>


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
                                        <legend>Add/Edit Category</legend>
                                        <div class="col-xs-6">
                                            <div class="row">
                                                <div class="form-group">
                                                    <div class="col-sm-9 col-md-9">
                                                        <asp:Label ID="Label1" runat="server" CssClass="control-label">Name</asp:Label>
                                                        <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName" ForeColor="Red"
                                                            ErrorMessage="Please enter Name..."
                                                            Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                            </div>
                                            <br />

                                            <div class="row">
                                                <div class="form-group">
                                                    <div class="col-sm-9 col-md-9">
                                                        <asp:Label ID="Label2" runat="server" CssClass="control-label">Note (Optional)</asp:Label>
                                                        <asp:TextBox ID="txtNote" TextMode="MultiLine" runat="server" CssClass="form-control"></asp:TextBox>
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
                                                <legend>Add/Edit Child Category </legend>
                                                <div class="row">
                                                    <div class="col-sm-12">
                                                        <asp:Label ID="lblMessageChild" runat="server"></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="form-group">
                                                        <div class="col-sm-9 col-md-9">
                                                            <asp:Label ID="Label3" runat="server" CssClass="control-label">Name</asp:Label>
                                                            <asp:TextBox ID="txtNameChild" runat="server" CssClass="form-control"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNameChild" ForeColor="Red"
                                                                ErrorMessage="Please enter Name..."
                                                                Display="Dynamic" ValidationGroup="child"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                                <br />
                                              
                                                <div class="row">
                                                    <div class="form-group">
                                                        <div class="col-sm-9 col-md-9">
                                                            <asp:Label ID="Label5" runat="server" CssClass="control-label">Note (Optional)</asp:Label>
                                                            <asp:TextBox ID="txtNoteChild" TextMode="MultiLine" runat="server" CssClass="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <br />
                                                <div class="row">
                                                    <div class="form-group">
                                                        <div class="col-sm-9 col-md-9 ">
                                                            <asp:Button ID="btnCreateOrEditBiCategoryChild" runat="server" class="btn btn-primary pull-right" Text="Add"
                                                                OnClick="btnCreateOrEditBiCategoryChild_OnClick" ValidationGroup="child"></asp:Button>
                                                            <asp:Button ID="btnCancelBiCategoryChild" runat="server" Text="Cancel" CssClass="btn btn-danger " OnClick="btnCancelBiCategoryChild_Click" />
                                                        </div>
                                                    </div>
                                                </div>
                                                <br />
                                                <asp:ListView ID="lvBiCategoryChild" runat="server" DataKeyNames="IID">
                                                    <LayoutTemplate>
                                                        <table class="table  table-hover table-bordered">
                                                            <thead>
                                                                <tr runat="server">
                                                                    <th class="col-xs-1">SL #
                                                                    </th>

                                                                    <th class="col-xs-5">Name
                                                                    </th>
                                                                 
                                                                    <th class="col-xs-5">Note
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
                                                            <td>
                                                                <asp:Label ID="Label6" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                                            </td>
                                                       
                                                            <td>
                                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("Note") %>'></asp:Label>
                                                            </td>

                                                            <td>
                                                                <p data-placement="top" data-toggle="tooltip" title="Delete">
                                                                    <asp:LinkButton ID="lnkbDelete" runat="server" CausesValidation="false" class="btn btn-danger btn-xs" data-title="Delete"
                                                                        CommandArgument='<%# Bind("Name") %>' OnClick="lnkbDelete_Click"><i class="fa fa-trash"></i></asp:LinkButton>
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
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
