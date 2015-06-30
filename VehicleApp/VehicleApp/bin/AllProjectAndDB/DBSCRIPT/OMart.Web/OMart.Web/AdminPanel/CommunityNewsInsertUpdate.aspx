<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.Master" AutoEventWireup="true" CodeBehind="CommunityNewsInsertUpdate.aspx.cs" Inherits="OMart.Web.AdminPanel.CommunityNewsInsertUpdate" %>

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
                                <legend>Add/Edit Community News</legend>
                                <div class="col-xs-12">

                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-7 col-md-7">
                                                <asp:Label ID="lblNewsType" runat="server" CssClass="control-label">News Type</asp:Label>
                                                <asp:DropDownList ID="dropdownNewsType" runat="server" CssClass="form-control"
                                                    Width="100%" Height="32px">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rfvNewsType" runat="server" ControlToValidate="dropdownNewsType" ForeColor="Red"
                                                    ErrorMessage="PLease enter News Type."
                                                    Display="Dynamic" ValidationGroup="gen">*</asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>

                                    <br />
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-7 col-md-7">
                                                <asp:Label ID="lblHeadLine" runat="server" CssClass="control-label">News Headings</asp:Label>
                                                <asp:TextBox ID="txtHeadLine" runat="server" CssClass="form-control" placeholder="Enter Head Lines."></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-7 col-md-7">
                                                <asp:Label ID="lblNewsDescription" runat="server" CssClass="control-label">News Description</asp:Label>
                                                <asp:TextBox ID="txtNewsDescription" runat="server" TextMode="MultiLine" CssClass="form-control" placeholder="Enter News Description.."></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-7 col-md-7">
                                                <asp:Label ID="lblRedirectUrl" runat="server" CssClass="control-label">Video Embeded Url</asp:Label>
                                                <asp:TextBox ID="txtRedirectUrl" runat="server" CssClass="form-control" placeholder="Video Embeded Url..."></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-7 col-md-7">
                                                <asp:Label ID="lblPicUrl" runat="server" CssClass="control-label">Image Url</asp:Label>

                                                <asp:FileUpload ID="PictureUpload" CssClass="form-control" runat="server"  />


                                            </div>
                                            <div>
                                            </div>
                                        </div>

                                    </div>
                                    <br />
                                    


                                </div>


                                <br />
                                <div class="row">
                                    <div class="form-group">
                                        <div class="col-sm-3 col-md-3 pull-right">
                                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-danger" OnClick="btnCancel_Click" />
                                            <asp:Button ID="btn_CreateOrEdit" runat="server" class="btn btn-primary" Text="Save"
                                                OnClick="btn_CreateOrEdit_Click" ValidationGroup="gen"></asp:Button>
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
