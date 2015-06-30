<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.Master" AutoEventWireup="true" CodeBehind="GasInsertUpdate.aspx.cs" Inherits="OMart.Web.AdminPanel.GasInsertUpdate" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxConTK" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AdminHead" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $('#<%=lvGasDealer.ClientID%>_chkHeader').click(function (event) {  //on click 
                if (this.checked) { // check select status
                    $('.childChkBox').each(function () { //loop through each checkbox
                        this.checked = true;  //select all checkboxes with class "childChkBox"               
                    });
                } else {
                    $('.childChkBox').each(function () { //loop through each checkbox
                        this.checked = false; //deselect all checkboxes with class "childChkBox"                       
                    });
                }
            });

        });
    </script>
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
                                <legend>Add/Edit Gas cyliender</legend>
                                <div class="col-xs-6">
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <div class="row">
                                                <div class="form-group">
                                                    <div class="col-sm-9 col-md-9">
                                                        <asp:Label ID="Label3" runat="server" CssClass="control-label">Company</asp:Label>
                                                        <asp:DropDownList OnSelectedIndexChanged="dropDownCompanyInfo_OnSelectedIndexChanged" AutoPostBack="True" runat="server" CssClass="form-control" ID="dropDownCompanyInfo" />
                                                        <asp:RequiredFieldValidator InitialValue="-1" ID="RequiredFieldValidator3" runat="server" ControlToValidate="dropDownCompanyInfo" ForeColor="Red"
                                                            ErrorMessage="Please select Company."
                                                            Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <br />

                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="Label1" runat="server" CssClass="control-label">Weight of gas</asp:Label>
                                                <asp:TextBox ID="txtWeightOfGas" runat="server" CssClass="form-control"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtWeightOfGas" ForeColor="Red"
                                                    ErrorMessage="Please enter weight of gas."
                                                    Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="Label5" runat="server" CssClass="control-label">Weight of container</asp:Label>
                                                <asp:TextBox ID="txtWeightOfContainer" runat="server" CssClass="form-control"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtWeightOfContainer" ForeColor="Red"
                                                    ErrorMessage="Please enter weight of container."
                                                    Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="Label8" runat="server" CssClass="control-label">Retail price</asp:Label>
                                                <asp:TextBox ID="txtRetailPrice" runat="server" CssClass="form-control"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtRetailPrice" ForeColor="Red"
                                                    ErrorMessage="Please enter retail price."
                                                    Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="Label7" runat="server" CssClass="control-label">Upload image (Optional)</asp:Label>
                                                <asp:FileUpload ID="fuGasCyliender" runat="server" class="form-control" />
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="Label2" runat="server" CssClass="control-label">Area informaiton (Optional)</asp:Label>
                                                <asp:TextBox ID="txtAreaInfo" TextMode="MultiLine" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="Label9" runat="server" CssClass="control-label">Redirect url (Optional)</asp:Label>
                                                <asp:TextBox ID="txtRedirectUrl" TextMode="Url" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="Label10" runat="server" CssClass="control-label">Price note (Optional)</asp:Label>
                                                <asp:TextBox ID="txtPriceNote" TextMode="MultiLine" runat="server" CssClass="form-control"></asp:TextBox>
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
                                        <legend>Gas dealer information</legend>
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
                                                <asp:ListView ID="lvGasDealer" runat="server" DataKeyNames="IID"
                                                    OnPagePropertiesChanging="lvlvGasDealer_PagePropertiesChanging" OnItemDataBound="lvGasDealer_OnItemDataBound" OnPreRender="dataPagerGasDealer_PreRender">
                                                    <LayoutTemplate>
                                                        <table class="table  table-hover table-bordered">
                                                            <thead>
                                                                <tr runat="server">
                                                                    <th class="col-xs-2" style="text-align: center">
                                                                        <asp:CheckBox runat="server" ID="chkHeader" Text="SL #" />
                                                                    </th>
                                                                    <th class="col-xs-4">Trade name
                                                                    </th>
                                                                    <th class="col-xs-4">Dealer name
                                                                    </th>
                                                                    <th class="col-xs-2">District
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
                                                                <asp:CheckBox runat="server" CssClass="childChkBox" ID="chkItem" Text='<%# Container.DataItemIndex + 1%>' />
                                                                <asp:HiddenField runat="server" ID="hdGasDealerId" Value='<%# Bind("IID") %>' />
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("TradeName") %>'></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label11" runat="server" Text='<%# Bind("DealerName") %>'></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label6" runat="server" Text='<%# Bind("District") %>'></asp:Label>
                                                            </td>

                                                        </tr>
                                                    </ItemTemplate>
                                                    <EmptyDataTemplate>
                                                        <tr>
                                                            <td>Information is empty....
                                                        <br />
                                                            </td>
                                                            <td>Please select company to see the dealer information....
                                                      <br />
                                                            </td>
                                                        </tr>
                                                        </table>
                                                    </EmptyDataTemplate>
                                                </asp:ListView>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>

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

