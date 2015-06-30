<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.Master" AutoEventWireup="true" CodeBehind="MortgageInsertUpdate.aspx.cs" Inherits="OMart.Web.AdminPanel.MortgageInsertUpdate" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxConTK" %>


<asp:Content ID="Content1" ContentPlaceHolderID="AdminHead" runat="server">
    <script type="text/Javascript">
        function isNumberKeyWithDotOnlyOne(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            var part = evt.srcElement.value.split('.');
            if (charCode != 46 && charCode > 31
              && (charCode < 48 || charCode > 57) || (part.length > 1 && charCode == 46))
                return false;

            return true;
        }
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
                                <legend>Add/Edit Mortgage</legend>
                                <div class="col-xs-6">


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
                                                <asp:Label ID="Label9" runat="server" CssClass="control-label">Oparetion type</asp:Label>
                                                <asp:DropDownList runat="server" CssClass="form-control" ID="dropDownOparationType" />
                                                <asp:RequiredFieldValidator InitialValue="-1" ID="RequiredFieldValidator5" runat="server" ControlToValidate="dropDownOparationType" ForeColor="Red"
                                                    ErrorMessage="Please select oparation type."
                                                    Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <br />


                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="Label10" runat="server" CssClass="control-label">Mortgage type</asp:Label>
                                                <asp:DropDownList runat="server" CssClass="form-control" ID="dropDownMortgageType" />
                                                <asp:RequiredFieldValidator InitialValue="-1" ID="RequiredFieldValidator6" runat="server" ControlToValidate="dropDownMortgageType" ForeColor="Red"
                                                    ErrorMessage="Please select mortgage type."
                                                    Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <br />



                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="Label17" runat="server" CssClass="control-label">Post last display days</asp:Label>
                                                <asp:TextBox ID="txtPostLastDisplayDate" runat="server" CssClass="form-control"></asp:TextBox>
                                                <ajaxConTK:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtPostLastDisplayDate" FilterType="Custom, Numbers" ValidChars="." />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPostLastDisplayDate" ForeColor="Red"
                                                    ErrorMessage="Please enter post last display days."
                                                    Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <br />


                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="Label12" runat="server" CssClass="control-label">Term year (Optional)</asp:Label>
                                                <asp:DropDownList runat="server" CssClass="form-control" ID="dropDownTermYear" />
                                            </div>
                                        </div>
                                    </div>
                                    <br />

                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="Label13" runat="server" CssClass="control-label">Payment type</asp:Label>
                                                <asp:DropDownList runat="server" CssClass="form-control" ID="dropDownPaymentType" />
                                                <asp:RequiredFieldValidator InitialValue="-1" ID="RequiredFieldValidator8" runat="server" ControlToValidate="dropDownPaymentType" ForeColor="Red"
                                                    ErrorMessage="Please select payment type."
                                                    Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <br />

                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="Label14" runat="server" CssClass="control-label">Fee/Charage (Optional)</asp:Label>
                                                <asp:TextBox ID="txtFeeOrCharge" runat="server" CssClass="form-control" onkeypress="return isNumberKeyWithDotOnlyOne(event)"></asp:TextBox>
                                                <ajaxConTK:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtFeeOrCharge" FilterType="Custom, Numbers" ValidChars="." />
                                            </div>
                                        </div>
                                    </div>
                                    <br />




                                    <fieldset class="addPostMang" style="border: 1px solid  #808080">
                                        <legend>Morgate Interest Rate</legend>
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="Label11" runat="server" CssClass="control-label">Select Interest rate type</asp:Label>
                                                    <asp:DropDownList runat="server" CssClass="form-control" ID="ddlInterestRateType" />
                                                    <asp:RequiredFieldValidator InitialValue="-1" ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlInterestRateType" ForeColor="Red"
                                                        ErrorMessage="Please select interest rate type." Display="Dynamic" ValidationGroup="child"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="Label8" runat="server" CssClass="control-label" placeholder="Enter Interest Rate.">Interest Rate</asp:Label>
                                                    <asp:TextBox runat="server" CssClass="form-control" ID="txtInterestRate" onkeypress="return isNumberKeyWithDotOnlyOne(event)"></asp:TextBox>
                                                    <%--<ajaxConTK:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtInterestRate" FilterType="Custom, Numbers" ValidChars="." />--%>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="lblUpToYear" runat="server" CssClass="control-label" placeholder="Enter Up to Year">Up to Year</asp:Label>
                                                    <asp:TextBox runat="server" CssClass="form-control" ID="txtUptoYear" onkeypress="return isNumberKeyWithDotOnlyOne(event)"></asp:TextBox>
                                                    <%--<ajaxConTK:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txtInterestRate" FilterType="Custom, Numbers" ValidChars="." />--%>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="Label15" runat="server" CssClass="control-label">Note</asp:Label>
                                                    <asp:TextBox runat="server" CssClass="form-control" ID="txtNote" TextMode="MultiLine"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <br />

                                        <div class="row align-right">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Button ID="btnAddFeature" runat="server" Text="Add Interest Rate" CssClass="btn btn-primary" ValidationGroup="child" OnClick="btnAddFeature_Click" />
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="col-sm-12">
                                                <div class="manageAdd">
                                                    <div class="addPostMang">

                                                        <fieldset class="adminFieldset">
                                                            <legend>Mortgage Interest Rate Lists</legend>

                                                            <asp:ListView ID="lvMortgageInterestRate" runat="server" DataKeyNames="IID" OnItemCommand="lvMortgageInterestRate_ItemCommand" OnPagePropertiesChanging="lvMortgageInterestRate_PagePropertiesChanging" OnPreRender="lvMortgageInterestRate_PreRender">
                                                                <LayoutTemplate>
                                                                    <table class="table  table-hover table-bordered">
                                                                        <thead>
                                                                            <tr runat="server">
                                                                                <th class="col-xs-1">SL #
                                                                                </th>
                                                                                <th class="col-xs-2">Interest Rate Type
                                                                                </th>
                                                                                <th class="col-xs-2">Rate 
                                                                                </th>
                                                                                <th class="col-xs-3">Up To Year 
                                                                                </th>
                                                                                <th class="col-xs-3">Note
                                                                                </th>
                                                                                <th class="col-xs-1">Delete
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
                                                                            <asp:Label ID="lblInterestRateTypeID" runat="server" Text='<%# Bind("InterestRateTypeID") %>'></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblRate" runat="server" Text='<%# Bind("Rate") %>'></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="Label16" runat="server" Text='<%# Bind("UptoYear") %>'></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblNote" runat="server" Text='<%# Bind("Note") %>'></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <p data-placement="top" data-toggle="tooltip" title="Delete">
                                                                                <asp:LinkButton ID="lnkbDelete" runat="server" CausesValidation="false" class="btn btn-danger btn-xs" data-title="Delete" OnClientClick="return confirm('Are you sure, do you want to delete?');"
                                                                                    CommandName="DeleteInfo"><i class="fa fa-trash"></i></asp:LinkButton>
                                                                            </p>
                                                                        </td>
                                                                    </tr>
                                                                </ItemTemplate>

                                                                <EmptyDataTemplate>
                                                                    <tr>
                                                                        <td>Information is empty ...
                                                                        </td>
                                                                    </tr>
                                                                    </table>
                                                                </EmptyDataTemplate>
                                                            </asp:ListView>
                                                            <asp:DataPager ID="dpMortgageInterestRate" runat="server" PagedControlID="lvMortgageInterestRate"
                                                                PageSize="5" OnPreRender="dpMortgageInterestRate_PreRender">
                                                                <Fields>
                                                                    <asp:NextPreviousPagerField FirstPageText="First" ButtonCssClass="BornoCss" PreviousPageText="Previous"
                                                                        ShowNextPageButton="False" ShowFirstPageButton="False" />
                                                                    <asp:NumericPagerField PreviousPageText="..." CurrentPageLabelCssClass="BornoCss"
                                                                        NumericButtonCssClass="BornoCss" NextPreviousButtonCssClass="BornoCss" RenderNonBreakingSpacesBetweenControls="True"
                                                                        ButtonType="Link" />
                                                                    <asp:NextPreviousPagerField FirstPageText="First" ButtonCssClass="BornoCss" LastPageText="Last"
                                                                        NextPageText="Next" PreviousPageText="Previous" ShowPreviousPageButton="False"
                                                                        ShowLastPageButton="False" />
                                                                </Fields>
                                                            </asp:DataPager>
                                                        </fieldset>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </fieldset>


                                </div>



                                <div class="col-xs-6">

                                    <%-- Saad --%>
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="Label2" runat="server" CssClass="control-label">Description (Optional)</asp:Label>
                                                <asp:TextBox TextMode="MultiLine" ID="txtDescription" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <br />

                                    <br />





                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="Label1" runat="server" CssClass="control-label">Annual Percentage Rate-APR (Optional)</asp:Label>
                                                <asp:TextBox ID="txtAPR" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <br />


                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="Label3" runat="server" CssClass="control-label">Loan to value-LTV (Optional)</asp:Label>
                                                <asp:TextBox ID="txtLTV" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <br />

                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="Label4" runat="server" CssClass="control-label">Property value amount-Minimum (Optional)</asp:Label>
                                                <asp:TextBox ID="txtPropertyValuMinAmt" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <br />

                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="Label5" runat="server" CssClass="control-label">Property value amount-Maximum (Optional)</asp:Label>
                                                <asp:TextBox ID="txtPropertyValuMaxAmt" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <br />

                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="Label6" runat="server" CssClass="control-label">Monthly installment amount (Optional)</asp:Label>
                                                <asp:TextBox ID="txtMonthlyInstallmentAmount" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <br />


                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="Label7" runat="server" CssClass="control-label">Is post ad exteded (Optional)</asp:Label>
                                                <asp:CheckBox ID="chkIsPostAdExtended" runat="server" CssClass="form-control"></asp:CheckBox>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="Label18" runat="server" CssClass="control-label">Redirect Url (Optional)</asp:Label>
                                                <asp:TextBox ID="txtRedirectUrl" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <br />

                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Button ID="btn_CreateOrEdit" runat="server" class="btn btn-primary pull-right" Text="Submit"
                                                    OnClick="btn_CreateOrEdit_Click" ValidationGroup="gen"></asp:Button>

                                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-danger " OnClick="btnCancel_Click" />
                                                <asp:Button ID="btnReport" runat="server" Text="Show Report" CssClass="btn btn-primary " OnClick="btnReport_Click" Enabled="False" />


                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">

                                                <CR:CrystalReportViewer ID="crv" runat="server" AutoDataBind="True" Height="50px" Width="350px"  ToolPanelView="None" ToolPanelWidth="200px" />

                                                

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
