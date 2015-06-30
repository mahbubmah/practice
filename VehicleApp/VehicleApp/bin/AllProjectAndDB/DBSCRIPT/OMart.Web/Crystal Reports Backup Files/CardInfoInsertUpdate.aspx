<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.Master" AutoEventWireup="true" CodeBehind="CardInfoInsertUpdate.aspx.cs" Inherits="OMart.Web.AdminPanel.CardInfoInsertUpdate" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxConTK" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AdminHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AdminContentPlaceHolder" runat="server">
    <CR:CrystalReportViewer AutoDataBind="True" ID="crCardInfo" runat="server" />
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
                                <legend>Add/Edit Card Information</legend>
                                <div class="col-xs-6">
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="Label1" runat="server" CssClass="control-label">Name</asp:Label>
                                                <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName" ForeColor="Red"
                                                    ErrorMessage="Please enter name."
                                                    Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="lblCompanyInfo" runat="server" CssClass="control-label">Company</asp:Label>
                                                <asp:DropDownList runat="server" CssClass="form-control" ID="dropDownCompanyInfo" />
                                                <asp:RequiredFieldValidator InitialValue="-1" ID="RequiredFieldValidator4" runat="server" ControlToValidate="dropDownCompanyInfo" ForeColor="Red"
                                                    ErrorMessage="Please select Company."
                                                    Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="Label10" runat="server" CssClass="control-label">Card type</asp:Label>
                                                <asp:DropDownList runat="server" CssClass="form-control" ID="dropDownCardType" />
                                                <asp:RequiredFieldValidator InitialValue="-1" ID="RequiredFieldValidator6" runat="server" ControlToValidate="dropDownCardType" ForeColor="Red"
                                                    ErrorMessage="Please select card type."
                                                    Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="Label9" runat="server" CssClass="control-label">Balance type</asp:Label>
                                                <asp:DropDownList runat="server" CssClass="form-control" ID="dropDownBalanceType" />
                                                <asp:RequiredFieldValidator InitialValue="-1" ID="RequiredFieldValidator5" runat="server" ControlToValidate="dropDownBalanceType" ForeColor="Red"
                                                    ErrorMessage="Please select balance type."
                                                    Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="Label6" runat="server" CssClass="control-label">Minimum limit amount</asp:Label>
                                                <asp:TextBox ID="txtMinimumLimitAmt" runat="server" CssClass="form-control"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtMinimumLimitAmt" ForeColor="Red"
                                                    ErrorMessage="Please enter minimum limit amount."
                                                    Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                                <ajaxConTK:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtMinimumLimitAmt" FilterType="Custom, Numbers" ValidChars="." />
                                            </div>
                                        </div>
                                    </div>

                                    <br />
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="Label7" runat="server" CssClass="control-label">Maximum limit amount</asp:Label>
                                                <asp:TextBox ID="txtMaximumLimitAmt" runat="server" CssClass="form-control"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtMaximumLimitAmt" ForeColor="Red"
                                                    ErrorMessage="Please enter maximum limit amount."
                                                    Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                                <ajaxConTK:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtMaximumLimitAmt" FilterType="Custom, Numbers" ValidChars="." />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="Label4" runat="server" CssClass="control-label">APR</asp:Label>
                                                <asp:TextBox ID="txtAPR" runat="server" CssClass="form-control"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtAPR" ForeColor="Red"
                                                    ErrorMessage="Please enter APR."
                                                    Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                                <ajaxConTK:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txtApr" FilterType="Custom, Numbers" ValidChars="." />
                                            </div>
                                        </div>
                                    </div>
                                    <br />

                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="Label8" runat="server" CssClass="control-label">Annual fee payment</asp:Label>
                                                <asp:TextBox ID="txtAnnualFeePayment" runat="server" CssClass="form-control"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtAnnualFeePayment" ForeColor="Red"
                                                    ErrorMessage="Please enter APR."
                                                    Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                                <ajaxConTK:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" TargetControlID="txtAnnualFeePayment" FilterType="Custom, Numbers" ValidChars="." />
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="Label20" runat="server" CssClass="control-label" placeholder="example: http://www.example.com">Redirect url (Optional)</asp:Label>
                                                <asp:TextBox ID="txtRedirectUrl" runat="server" TextMode="Url" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="Label19" runat="server" CssClass="control-label">Payment Amount (Optional)</asp:Label>
                                                <asp:TextBox ID="txtPaymentAmt" TextMode="Number" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="Label3" runat="server" CssClass="control-label">Card logo (Optional)</asp:Label>
                                                <asp:FileUpload ID="fuCardInfo" runat="server" class="form-control" />
                                                <%-- <asp:TextBox TextMode="MultiLine" ID="txtCardLogoUrl" runat="server" CssClass="form-control"></asp:TextBox>--%>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="Label5" runat="server" CssClass="control-label">APR Description (Optional)</asp:Label>
                                                <asp:TextBox TextMode="MultiLine" ID="txtAprDescription" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>

                                    <br />


                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="Label11" runat="server" CssClass="control-label">Reward note (Optional)</asp:Label>
                                                <asp:TextBox TextMode="MultiLine" ID="txtRewardNote" runat="server" CssClass="form-control"></asp:TextBox>
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
                                </div>


                                <div class="col-xs-6">

                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="Label17" runat="server" CssClass="control-label">Post last display date</asp:Label>
                                                <asp:TextBox ID="txtPostLastDisplayDate" runat="server" CssClass="form-control"></asp:TextBox>
                                                <ajaxConTK:CalendarExtender ID="extDate2" runat="server" Enabled="True" TargetControlID="txtPostLastDisplayDate" Format="dd/MM/yyyy"></ajaxConTK:CalendarExtender>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtPostLastDisplayDate" ForeColor="Red"
                                                    ErrorMessage="Please enter post last display date."
                                                    Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="Label12" runat="server" CssClass="control-label">Reward company logo url (Optional)</asp:Label>
                                                <asp:TextBox TextMode="Url" ID="txtRewardCompanyLogoUrl" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="Label13" runat="server" CssClass="control-label">Cashback earned amount (Optional)</asp:Label>
                                                <asp:TextBox ID="txtCashbackEarnedAmt" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="Label14" runat="server" CssClass="control-label">Cashback earned note (Optional)</asp:Label>
                                                <asp:TextBox TextMode="MultiLine" ID="txtCashbackEarnedNote" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="Label15" runat="server" CssClass="control-label">Used remarked point (Optional)</asp:Label>
                                                <asp:TextBox ID="txtUsedRemarkedPoint" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="Label16" runat="server" CssClass="control-label">Whole world usage fee per (Optional)</asp:Label>
                                                <asp:TextBox ID="txtWholeWorldUsageFeePer" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="Label18" runat="server" CssClass="control-label">Is post ad exteded (Optional)</asp:Label>
                                                <asp:CheckBox ID="chkIsPostAdExtended" runat="server" CssClass="checkbox"></asp:CheckBox>
                                            </div>
                                        </div>
                                    </div>
                                    <br />

                                    <div class="col-lg-10">
                                        <asp:Panel ID="Panl1" runat="server" CssClass="Popup" align="center">
                                            <iframe style="width: 500px; height: 400px;" id="irm1" src="CardFeatureInsertPopupForCardInfo.aspx" runat="server"></iframe>
                                            <br />

                                        </asp:Panel>
                                    </div>
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9 ">
                                                <asp:Button ID="btn_CreateOrEdit" runat="server" class="btn btn-primary pull-right" Text="Submit"
                                                    OnClick="btn_CreateOrEdit_Click" ValidationGroup="gen"></asp:Button>
                                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-danger " OnClick="btnCancel_Click" />

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
