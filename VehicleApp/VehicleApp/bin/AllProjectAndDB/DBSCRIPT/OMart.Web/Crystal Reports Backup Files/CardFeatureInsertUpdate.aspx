<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.Master" AutoEventWireup="true" CodeBehind="CardFeatureInsertUpdate.aspx.cs" Inherits="OMart.Web.AdminPanel.CardFeatureInsertUpdate" %>

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
                                <legend>Add/Edit card feature</legend>
                                <div class="col-xs-6">
                             
                                     <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="Label10" runat="server" CssClass="control-label">Card information</asp:Label>
                                                <asp:DropDownList runat="server" CssClass="form-control" ID="dropDownCardInfo" />
                                                <asp:RequiredFieldValidator InitialValue="-1" ID="RequiredFieldValidator6" runat="server" ControlToValidate="dropDownCardInfo" ForeColor="Red"
                                                    ErrorMessage="Please select card information."
                                                    Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                 
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="Label2" runat="server" CssClass="control-label">Description (Optional)</asp:Label>
                                                <asp:TextBox TextMode="MultiLine" ID="txtDescription" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                      <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9 ">
                                                <asp:Button ID="Button1" runat="server" class="btn btn-primary pull-right" Text="Submit"
                                                    OnClick="btn_CreateOrEdit_Click" ValidationGroup="gen"></asp:Button>
                                                <asp:Button ID="Button2" runat="server" Text="Cancel" CssClass="btn btn-danger " OnClick="btnCancel_Click" />
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
