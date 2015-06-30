<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.Master" AutoEventWireup="true" CodeBehind="CompanyInfoInsertUpdate.aspx.cs" Inherits="OMart.Web.AdminPanel.CompanyInfoInsertUpdate" %>

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
                                <legend>Add/Edit Company</legend>
                                <div class="col-xs-12">
                                    <div class="col-xs-6">
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="lblCompanyInfoName" runat="server" CssClass="control-label">Company Name</asp:Label>
                                                    <asp:TextBox ID="txtCompanyInfoName" runat="server" CssClass="form-control"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rbfFirstName" runat="server" ControlToValidate="txtCompanyInfoName" ForeColor="Red"
                                                        ErrorMessage="PLease enter Company name."
                                                        Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="lblBussDescription" runat="server" CssClass="control-label">Business Description</asp:Label>
                                                    <asp:TextBox ID="txtBussDescription" runat="server" CssClass="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="lblAddress" runat="server" CssClass="control-label">Address</asp:Label>
                                                    <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="lblWebAddress" runat="server" CssClass="control-label">Web Address</asp:Label>
                                                    <asp:TextBox ID="txtWebAddress" runat="server" CssClass="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="lblOriginCountryID" runat="server" CssClass="control-label">Origin Country</asp:Label>
                                                     <asp:DropDownList ID="dropdownCountry" runat="server" CssClass="sysTextBox"
                                                        Width="100%" Height="32px">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"  ControlToValidate="dropdownCountry" ForeColor="Red"
                                                        ErrorMessage="PLease enter Country... " InitialValue="-1"
                                                        Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </div>

                                         <br />
                                         
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                     <asp:CheckBox ID="chkIsRemoved" runat="server" ></asp:CheckBox>
                                                    <asp:Label ID="lblIsRemoved" runat="server" CssClass="control-label">Is Removed</asp:Label>
                                                   
                                                </div>
                                            </div>
                                        </div>



                                    </div>
                                    <div class="col-xs-6 align-right">

                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="lblEstablishedYear" runat="server" CssClass="control-label">Established Year</asp:Label>
                                                    <asp:TextBox ID="txtEstablishedYear" runat="server" CssClass="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="lblTotalCountryBussCover" runat="server" CssClass="control-label">Total Country Bussiness Cover</asp:Label>
                                                    <asp:TextBox ID="txtTotalCountryBussCover" runat="server" CssClass="form-control"></asp:TextBox>
                                                      <asp:RequiredFieldValidator ID="rfvTotalCountryBussCover" runat="server"  ControlToValidate="txtTotalCountryBussCover" ForeColor="Red"
                                                        ErrorMessage="PLease enter Total Country Bussiness Cover. " 
                                                        Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="lblBussinessTypeID" runat="server" CssClass="control-label">Bussiness Type</asp:Label>
                                                    <asp:DropDownList ID="dropDownBussinessTypeID" runat="server" CssClass="sysTextBox"
                                                        Width="100%" Height="32px">
                                                    </asp:DropDownList>
                                                     <asp:RequiredFieldValidator ID="rfvdropDownBussinessTypeID" runat="server"  ControlToValidate="dropDownBussinessTypeID" ForeColor="Red" InitialValue ="-1"
                                                        ErrorMessage="PLease enter Bussiness Type. " 
                                                        Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9 ">
                                                    <asp:Label ID="lblLogoUrl" runat="server" CssClass="control-label">Logo Url</asp:Label>
                                                   
                                                    <asp:FileUpload ID="LogoUpload" runat="server" class="form-control pull-right" />
                                                   
                                                                                            
                                             </div>
                                                     <%--  <div>
                                                <asp:DataList ID="datalistTempLogoImage" runat="server" RepeatColumns="1">
                                                    <ItemTemplate>
                                                        <asp:Image ID="imgLogoTempImage" runat="server" Width="200" Height="100" BorderColor="Red" ImageUrl='<%#Bind("ImageUrlTemp") %>' />
                                                    </ItemTemplate>
                                                </asp:DataList>
                                            </div>--%>
                                            </div>
                                           
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="lblContactPhoneNo" runat="server" CssClass="control-label">Contact PhoneNo</asp:Label>
                                                    <asp:TextBox ID="txtContactPhoneNo" runat="server" CssClass="form-control"></asp:TextBox>
                                                </div>
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
    </section>
</asp:Content>
