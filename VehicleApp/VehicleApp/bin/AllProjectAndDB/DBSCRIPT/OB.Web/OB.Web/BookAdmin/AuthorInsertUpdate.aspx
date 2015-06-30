<%@ Page Title="" Language="C#" MasterPageFile="~/BookAdmin/OiiOMasterPage.Master" AutoEventWireup="true" CodeBehind="AuthorInsertUpdate.aspx.cs" Inherits="OB.Web.BookAdmin.AuthorInsertUpdate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <br />
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
                                <legend>Add/Edit Author</legend>
                                
                                    <div class="col-xs-12">
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="lblAuthorName" runat="server" CssClass="control-label">Author Name</asp:Label>
                                                    <asp:TextBox ID="txtAuthorName" runat="server" CssClass="form-control"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rbfFirstName" runat="server" ControlToValidate="txtAuthorName" ForeColor="Red"
                                                        ErrorMessage="PLease enter Author name."
                                                        Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="lblAboutAuthor" runat="server" CssClass="control-label">About Author</asp:Label>
                                                    <asp:TextBox ID="txtAboutAuthor" runat="server" CssClass="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                       
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="lblFavQuote" runat="server" CssClass="control-label">Favorite Quotation</asp:Label>
                                                    <asp:TextBox ID="txtFavQuote" runat="server" CssClass="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="lblOriginCountryID" runat="server" CssClass="control-label"> Country</asp:Label>
                                                     <asp:DropDownList ID="dropdownCountry" runat="server" CssClass="sysTextBox"
                                                        Width="100%" Height="32px">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>

                                         <br />
                                          <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                     <asp:CheckBox ID="chkIsFeatured" runat="server" ></asp:CheckBox>
                                                    <asp:Label ID="lblIsFeatured" runat="server" CssClass="control-label">Is Featured</asp:Label>
                                                   
                                                </div>
                                            </div>
                                        </div>   
                                        <br/>    
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                     <asp:CheckBox ID="chkIsRemoved" runat="server" ></asp:CheckBox>
                                                    <asp:Label ID="lblIsRemoved" runat="server" CssClass="control-label">Is Removed</asp:Label>
                                                   
                                                </div>
                                            </div>
                                        </div>      
                                        <br/>                                                                                                   
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9 ">
                                                    <asp:Label ID="lblImageoUrl" runat="server" CssClass="control-label">Picture </asp:Label>
                                                   
                                                    <asp:FileUpload ID="ImageUpload" runat="server" class="form-control pull-right" />
                                                                                                                                               
                                             </div>
                                                    <div style="display: none">
                                                            <asp:TextBox ID="txtHoldImagePath" runat="server"></asp:TextBox>
                                                        </div>
                                            </div>
                                           
                                        </div>
                                        </div>
                                       
                                <div class="col-sm-12 col-md-12">
                                    <div class="row">
                                        <br />
                                        <div class="form-group">
                                            <div class="col-sm-3 col-md-3 pull-right">
                                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-danger" OnClick="btnCancel_Click" />

                                                <asp:Button ID="btn_CreateOrEdit" runat="server" class="btn btn-primary" Text="Submit"
                                                    OnClick="btn_CreateOrEdit_Click" ValidationGroup="gen"></asp:Button>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                            </fieldset>
                        </div>
                    </div>
                </div>
            </div>
        </div>
            </div>
    </section>
</asp:Content>
