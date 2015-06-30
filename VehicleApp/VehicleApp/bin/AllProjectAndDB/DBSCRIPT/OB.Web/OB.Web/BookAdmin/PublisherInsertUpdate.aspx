<%@ Page Title="" Language="C#" MasterPageFile="~/BookAdmin/OiiOMasterPage.Master" AutoEventWireup="true" CodeBehind="PublisherInsertUpdate.aspx.cs" Inherits="OB.Web.BookAdmin.PublisherInsertUpdate" %>

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
                                    <legend>Add/Edit Publisher</legend>

                                    <div class="col-xs-12">
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="lblPublisherName" runat="server" CssClass="control-label">Publisher Name</asp:Label>
                                                    <asp:TextBox ID="txtPublisherName" runat="server" CssClass="form-control"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rbfFirstName" runat="server" ControlToValidate="txtPublisherName" ForeColor="Red"
                                                        ErrorMessage="PLease enter Publisher name."
                                                        Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="lblAboutPublisher" runat="server" CssClass="control-label">About Publisher</asp:Label>
                                                    <asp:TextBox ID="txtAboutPublisher" runat="server" CssClass="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <br />

                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="lblAwardAchieved" runat="server" CssClass="control-label">Award Achieved</asp:Label>
                                                    <asp:TextBox ID="txtAwardAchieved" runat="server" CssClass="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <br />

                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:CheckBox ID="chkIsRemoved" runat="server"></asp:CheckBox>
                                                    <asp:Label ID="lblIsRemoved" runat="server" CssClass="control-label">Is Removed</asp:Label>

                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9 ">
                                                    <asp:Label ID="lblLogoUrl" runat="server" CssClass="control-label">Logo Url </asp:Label>

                                                    <asp:FileUpload ID="ImageUpload" runat="server" class="form-control pull-right" />
                                                    
                                                     <div style="display: none">
                                                            <asp:TextBox ID="txtHoldImagePath" runat="server"></asp:TextBox>
                                                        </div>
                                                </div>
                                                <div>
                                                    <asp:DataList ID="datalistTempLogoImage" runat="server" RepeatColumns="1">
                                                        <ItemTemplate>
                                                            <asp:Image ID="imgLogoTempImage" runat="server" Width="200" Height="100" BorderColor="Red" ImageUrl='<%#Bind("ImageUrlTemp") %>' />
                                                        </ItemTemplate>
                                                    </asp:DataList>
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
