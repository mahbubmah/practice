<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.Master" AutoEventWireup="true" CodeBehind="MPType.aspx.cs" Inherits="OMart.Web.AdminPanel.MPType" %>
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
                                <legend>Add/Edit Mobile Phone Type</legend>
                                <div class="col-xs-6">
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="lblTypeName" runat="server" CssClass="control-label">Type Name</asp:Label>
                                                <asp:TextBox ID="txtTypeName" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                               <%-- <asp:Label ID="lblCompanyInfoID" runat="server" CssClass="control-label">Company Info</asp:Label>
                                                <asp:TextBox ID="txtCompanyInfoID" runat="server" CssClass="form-control"></asp:TextBox>--%>
                                                <asp:Label ID="lblCompanyInfoID" runat="server" CssClass="control-label">Company Info</asp:Label>
                                                <asp:DropDownList ID="dropDownCompanyInfoID" runat="server" CssClass="form-control"></asp:DropDownList>
                                               
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                   
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-danger" OnClick="btnCancel_Click"  />

                                                <asp:Button ID="btn_CreateOrEdit" runat="server" class="btn btn-primary  pull-right" Text="Submit"
                                                     ValidationGroup="gen" OnClick="btn_CreateOrEdit_Click"></asp:Button>
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
    </section>
</asp:Content>
