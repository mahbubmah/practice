<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.Master" AutoEventWireup="true" CodeBehind="LoanInfoInsertUpdate.aspx.cs" Inherits="OMart.Web.AdminPanel.LoanInfoInsertUpdate" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxConTK" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AdminHead" runat="server">

    <script type="text/javascript">
        function isNumberKeyWithDotOnlyOne(evt) {
            //evt = (evt) ? evt : event;
            //var charCode = (evt.charCode) ? evt.charCode : ((evt.keyCode) ? evt.keyCode : ((evt.which) ? evt.which : 0));
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57) && charCode != 46) {
                return false;
            }
            else {
                var len = document.getElementById("txtTotalAmount").value.length;
                var index = document.getElementById("txtTotalAmount").value.indexOf('.');
                //alert(len);
                if (index > 0 && charCode == 46) {
                    return false;
                }
            }
            return true;
        }
    </script>

    <script type="text/Javascript">
        function isNumberKeyWithoutDot(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31
              && (charCode < 48 || charCode > 57))
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
                                <legend>Add/Edit Loan Information</legend>
                                <div class="col-xs-12">
                                    <div class="col-xs-6">
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="lblCompanyInfoName" runat="server" CssClass="control-label">Company Name</asp:Label>
                                                    <asp:DropDownList ID="ddlCompanyName" runat="server" CssClass="form-control"></asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="rfvTypeID" runat="server"
                                                        ControlToValidate="ddlCompanyName" ForeColor="Red" InitialValue="-1"
                                                        ToolTip="*" Display="Dynamic" ValidationGroup="UserValidationGroup" ErrorMessage="Select Company...">*</asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </div>

                                        <br />
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="lblLoanAmtYearSchedule" runat="server" CssClass="control-label">Total Amount</asp:Label>
                                                    <asp:TextBox ID="txtTotalAmount" runat="server" CssClass="form-control" onkeypress="return isNumberKeyWithDotOnlyOne(event)"></asp:TextBox>
                                                    <%--<ajaxConTK:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txtTotalAmount" FilterType="Custom, Numbers" ValidChars="." />--%>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="lblMonthlyReturnAmount" runat="server" CssClass="control-label">Monthly Return Amount</asp:Label>
                                                    <asp:TextBox ID="txtMonthlyReturnAmount" runat="server" CssClass="form-control" onkeypress="return isNumberKeyWithDotOnlyOne(event)"></asp:TextBox>
                                                    <ajaxConTK:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtMonthlyReturnAmount" FilterType="Custom, Numbers" ValidChars="." />
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="lblDescription" runat="server" CssClass="control-label">Description </asp:Label>
                                                    <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="lblPostLastDisplayDate" runat="server" CssClass="control-label">Post Last Display Day</asp:Label>
                                                    <asp:TextBox ID="txtPostLastDisplayDate" runat="server" CssClass="sysTextBox"
                                                        Width="100%" Height="32px" onkeypress="return isNumberKeyWithoutDot(event)">   
                                                    </asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                                        ControlToValidate="txtPostLastDisplayDate" ForeColor="Red"
                                                        ToolTip="*" Display="Dynamic" ValidationGroup="UserValidationGroup" ErrorMessage="Type Post Last Days...">*</asp:RequiredFieldValidator>
                                                    <ajaxConTK:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtPostLastDisplayDate" FilterType="Custom, Numbers" ValidChars="." />
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <%--  <div class="row">
                                           
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="lblIsVerified" runat="server" CssClass="control-label">Is Verified</asp:Label>
                                                    
                                             
                                            </div>
                                        </div>--%>

                                        <div class="row">
                                            <div class="col-sm-9 col-md-9">
                                                <div class="input-group">
                                                    <asp:CheckBox ID="chkIsverified" runat="server" CssClass="form-control" BorderColor="WhiteSmoke"
                                                         Text=" Is Varified"></asp:CheckBox>
                                                </div>
                                            </div>
                                        </div>

                                        <br />
                                  
                                         <div class="row">
                                            <div class="col-sm-9 col-md-9">
                                                <div class="input-group">
                                                     <asp:CheckBox ID="chkIsPostAdExtended" runat="server" CssClass="form-control"
                                                      BorderColor="WhiteSmoke" Text="Is Post AdExtended" Width="100%" Height="32px"></asp:CheckBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-xs-6 align-right">

                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="lblEstablishedYear" runat="server" CssClass="control-label">Loan Type</asp:Label>
                                                    <asp:DropDownList ID="ddlLoanType" runat="server" CssClass="form-control"></asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                                        ControlToValidate="ddlLoanType" ForeColor="Red" InitialValue="-1"
                                                        ToolTip="*" Display="Dynamic" ValidationGroup="UserValidationGroup" ErrorMessage="Select Loan Type...">*</asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="lblPaymentAmt" runat="server" CssClass="control-label">Payment Amount</asp:Label>
                                                    <asp:TextBox ID="txtTotalPaymentAmount" runat="server" CssClass="form-control" onkeypress="return isNumberKeyWithDotOnlyOne(event)"></asp:TextBox>
                                                    <ajaxConTK:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" TargetControlID="txtTotalPaymentAmount" FilterType="Custom, Numbers" ValidChars="." />
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="lblTotalReturnAmountt" runat="server" CssClass="control-label"> Total Return Amount</asp:Label>
                                                    <asp:TextBox ID="txtTotalReturnAmount" runat="server" CssClass="sysTextBox"
                                                        Width="100%" Height="32px" onkeypress="return isNumberKeyWithDotOnlyOne(event)">
                                                    </asp:TextBox>
                                                    <ajaxConTK:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" TargetControlID="txtTotalReturnAmount" FilterType="Custom, Numbers" ValidChars="." />
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="lblTotalInstallmentNo" runat="server" CssClass="control-label">Total Installment No</asp:Label>
                                                    <asp:TextBox ID="txtTotalInstallmentNo" runat="server" class="form-control bottom-right" onkeypress="return isNumberKeyWithoutDot(event)"></asp:TextBox>
                                                    <ajaxConTK:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" TargetControlID="txtTotalInstallmentNo" FilterType="Custom, Numbers" ValidChars="." />
                                                </div>
                                            </div>

                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="lblLoanAmtYearScheduleID" runat="server" CssClass="control-label">Loan Amount Year Schedule</asp:Label>
                                                    <asp:DropDownList ID="ddlLoanAmtYearScheduleID" runat="server" class="form-control bottom-right"></asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                                        ControlToValidate="ddlLoanAmtYearScheduleID" ForeColor="Red" InitialValue="-1"
                                                        ToolTip="*" Display="Dynamic" ValidationGroup="UserValidationGroup" ErrorMessage="Select Loan Year Schedule...">*</asp:RequiredFieldValidator>
                                                </div>
                                            </div>

                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="lblRedirectUrl" runat="server" CssClass="control-label">Redirect Url</asp:Label>
                                                    <asp:TextBox ID="txtRedirectUrl" runat="server" CssClass="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                     <%--   <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="lblIsRemoved" runat="server" CssClass="control-label">Is Removed</asp:Label>
                                                    <asp:CheckBox ID="chkIsRemoved" runat="server" CssClass="form-control"></asp:CheckBox>
                                                </div>
                                            </div>
                                        </div>--%>
                                         <div class="row">
                                            <div class="col-sm-9 col-md-9">
                                                <div class="input-group">
                                                    <asp:CheckBox ID="chkIsRemoved" runat="server" CssClass="form-control"
                                                      BorderColor="WhiteSmoke" Text="Is Removed" Width="100%" Height="32px"></asp:CheckBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row" style="font-size: 16px">
                                        <div class="col-sm-12">
                                            <asp:Label ID="lblMessageFeature" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                    <fieldset class="adminFieldset" style="width: 400px; border: 1px solid #808080">
                                        <legend>Feature of Loan</legend>
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-12">
                                                    <span style="float: left; margin-right: 20px">
                                                        <asp:Label ID="Label2" runat="server" CssClass="control-label">Description</asp:Label></span>
                                                    <span style="float: left; margin-right: 20px">
                                                        <asp:TextBox ID="txtDesFeature" TextMode="MultiLine" runat="server" CssClass="form-control"></asp:TextBox></span>
                                                </div>
                                            </div>
                                        </div>


                                        <br />
                                        <div class="row align-right">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Button ID="btnAddFeature" runat="server" Text="Add Feature" CssClass="btn btn-primary" OnClick="btnAddFeature_Click" />
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="col-sm-12">
                                                <div class="manageAdd">
                                                    <div class="addPostMang">

                                                        <fieldset class="adminFieldset">
                                                            <legend>Feature Lists</legend>

                                                            <asp:ListView ID="lvFeature" runat="server" DataKeyNames="IID" OnItemCommand="lvFeature_ItemCommand" OnPagePropertiesChanging="lvFeature_PagePropertiesChanging" OnPreRender="lvFeature_PreRender">
                                                                <LayoutTemplate>
                                                                    <table class="table  table-hover table-bordered">
                                                                        <thead>
                                                                            <tr runat="server">
                                                                                <th class="col-xs-1">SL #
                                                                                </th>
                                                                                <th class="col-xs-6">Description
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
                                                                            <asp:Label ID="lblCode" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                                                                        </td>
                                                                        <%--<td>
                                                                    <asp:CheckBox ID="chkIsRemoved" runat="server" Checked='<%# Bind("IsRemoved") %>' Enabled="false"></asp:CheckBox>
                                                                </td>--%>
                                                                        <td>
                                                                            <p data-placement="top" data-toggle="tooltip" title="Delete">
                                                                                <asp:LinkButton ID="lnkbDelete" runat="server" CausesValidation="false" class="btn btn-danger btn-xs" data-title="Delete" OnClientClick="return confirm('Are you sure, do you want to delete?');"
                                                                                    CommandName="DeleteInfo" CommandArgument='<%# Bind("Description") %>'><i class="fa fa-trash"></i></asp:LinkButton>
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
                                                            <asp:DataPager ID="dataPagerFeature" runat="server" PagedControlID="lvFeature"
                                                                PageSize="5" OnPreRender="dataPagerFeature_PreRender">
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

                                <div class="col-sm-12 col-md-12">
                                    <div class="row">
                                        <br />
                                        <div class="form-group">
                                            <div class="col-sm-3 col-md-3 pull-right">
                                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-danger" OnClick="btnCancel_Click" />

                                                <asp:Button ID="btn_CreateOrEdit" runat="server" class="btn btn-primary" Text="Submit"
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
