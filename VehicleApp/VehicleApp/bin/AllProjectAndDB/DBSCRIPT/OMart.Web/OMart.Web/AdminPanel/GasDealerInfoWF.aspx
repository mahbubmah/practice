<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.Master" AutoEventWireup="true" CodeBehind="GasDealerInfoWF.aspx.cs" Inherits="OMart.Web.GasDealerInfoWF" %>

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
                <div class="row">
                    <div class="col-sm-12">
                        <div class="manageAdd">
                            <div class="addPostMang">
                                <fieldset class="adminFieldset">
                                    <legend>Add Gas Dealer Info</legend>
                                    <div class="col-xs-6">

                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="lblCompanyName" runat="server" CssClass="control-label">Company Name</asp:Label>
                                                    <asp:DropDownList ID="ddCompanyName" runat="server" CssClass="form-control"></asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>

                                         <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="lblTradeName" runat="server" CssClass="control-label">Trade Name</asp:Label>
                                                    <asp:TextBox ID="txtTradeName" runat="server" CssClass="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>


                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="lblDealerName" runat="server" CssClass="control-label">Dealer Name</asp:Label>
                                                    <asp:TextBox ID="txtDealerName" runat="server" CssClass="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="lblPhoneNo" runat="server" CssClass="control-label">Phone No</asp:Label>
                                                    <asp:TextBox ID="txtPhoneNo" runat="server" CssClass="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="lblAddress" runat="server" CssClass="control-label">Address</asp:Label>
                                                    <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="lblDistrict" runat="server" CssClass="control-label">District Name</asp:Label>
                                                    <asp:DropDownList ID="ddDistrict" runat="server" CssClass="form-control">

                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                        <br />


                                       <%-- <div class="row">
                                            <div class="clearfix">
                                                <asp:CheckBox ID="chkIsRemoveGasDealer" runat="server" CssClass="checkbox" Text=" IsRemoved" />
                                            </div>
                                        </div>--%>

                                        <br />

                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-danger" OnClick="btnCancel_Click" />

                                                    <asp:Button ID="btn_CreateOrEdit" runat="server" class="btn btn-primary  pull-right" Text="Submit"
                                                        OnClick="btn_CreateOrEdit_Click" ValidationGroup="gen"></asp:Button>
                                                    <asp:HiddenField ID="hdGasDealerInfoID" runat="server" />
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
