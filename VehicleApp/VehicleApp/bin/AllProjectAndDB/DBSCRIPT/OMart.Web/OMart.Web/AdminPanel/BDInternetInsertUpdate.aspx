<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.Master" AutoEventWireup="true" CodeBehind="BDInternetInsertUpdate.aspx.cs" Inherits="OMart.Web.AdminPanel.BDInternetInsertUpdate" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxConTK" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AdminHead" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $('#<%=lvChannel.ClientID%>_chkHeader').click(function (event) {  //on click 
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
                                <legend>Add/Edit BDInternet and Mapping Channel</legend>
                                <div class="col-xs-12">
                                    <div class="col-xs-6">
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="Label2" runat="server" CssClass="control-label">Provider Name</asp:Label>


                                                    <asp:DropDownList ID="DropDownProviderID" runat="server" Height="100%" class="form-control">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator InitialValue="-1" ID="RequiredFieldValidator2" runat="server" ControlToValidate="DropDownProviderID" ForeColor="Red"
                                                        ErrorMessage="Please select Company Type."
                                                        Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="Label19" runat="server" CssClass="control-label"> Type</asp:Label>


                                                    <asp:DropDownList ID="DropDownType" runat="server" Height="100%" class="form-control">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator InitialValue="-1" ID="RequiredFieldValidator11" runat="server" ControlToValidate="DropDownType" ForeColor="Red"
                                                        ErrorMessage="Please select Type."
                                                        Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="Label15" runat="server" CssClass="control-label">Net Speed Unit </asp:Label>


                                                    <asp:DropDownList ID="DropDownNetSpeedUnitID" runat="server" Height="100%" class="form-control">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator InitialValue="-1" ID="RequiredFieldValidator3" runat="server" ControlToValidate="DropDownNetSpeedUnitID" ForeColor="Red"
                                                        ErrorMessage="Please select Net Speed Unit."
                                                        Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="Label16" runat="server" CssClass="control-label">Download Speed Unit</asp:Label>


                                                    <asp:DropDownList ID="DropDownDownloadSpeedUnitID" runat="server" Height="100%" class="form-control">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator InitialValue="-1" ID="RequiredFieldValidator8" runat="server" ControlToValidate="DropDownDownloadSpeedUnitID" ForeColor="Red"
                                                        ErrorMessage="Please select Download Speed Unit."
                                                        Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="Label17" runat="server" CssClass="control-label">Network Generation Type</asp:Label>


                                                    <asp:DropDownList ID="DropDownNetGenerationID" runat="server" Height="100%" class="form-control">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator InitialValue="-1" ID="RequiredFieldValidator9" runat="server" ControlToValidate="DropDownNetGenerationID" ForeColor="Red"
                                                        ErrorMessage="Please select Net Generation Type."
                                                        Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="Label18" runat="server" CssClass="control-label">Charge Type</asp:Label>


                                                    <asp:DropDownList ID="DropDownChargeTypeID" runat="server" Height="100%" class="form-control">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator InitialValue="-1" ID="RequiredFieldValidator10" runat="server" ControlToValidate="DropDownChargeTypeID" ForeColor="Red"
                                                        ErrorMessage="Please select Charge Type."
                                                        Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </div>
                                        <br />

                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="Label20" runat="server" CssClass="control-label">Package Name</asp:Label>
                                                    <asp:TextBox ID="txtPackageName" runat="server" CssClass="form-control"></asp:TextBox>
                                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtMinimumLimitAmt" ForeColor="Red"
                                                    ErrorMessage="Please enter minimum limit amount."
                                                    Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                                <ajaxConTK:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" TargetControlID="txtMinimumLimitAmt" FilterType="Custom, Numbers" ValidChars="." />--%>
                                                </div>
                                            </div>
                                        </div>

                                        <br />
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="Label21" runat="server" CssClass="control-label">Package Image</asp:Label>
                                                    <asp:FileUpload ID="FileUploadImage" runat="server" class="form-control" />

                                                </div>
                                            </div>
                                        </div>

                                        <br />
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="Label22" runat="server" CssClass="control-label">Net Speed</asp:Label>
                                                    <asp:TextBox ID="txtNetSpeed" TextMode="Number" runat="server" CssClass="form-control"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txtNetSpeed" ForeColor="Red"
                                                        ErrorMessage="Please enter Net Speed."
                                                        Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>

                                                </div>
                                            </div>
                                        </div>

                                        <br />
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="Label23" runat="server" CssClass="control-label">Download Speed</asp:Label>
                                                    <asp:TextBox ID="txtDownloadSpeed" TextMode="Number" runat="server" CssClass="form-control"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="txtDownloadSpeed" ForeColor="Red"
                                                        ErrorMessage="Please enter Download Speed."
                                                        Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>

                                                </div>
                                            </div>
                                        </div>

                                        <br />
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="Label24" runat="server" CssClass="control-label">Data Amount</asp:Label>
                                                    <asp:TextBox ID="txtDataAmount" runat="server" CssClass="form-control"></asp:TextBox>


                                                </div>
                                            </div>
                                        </div>

                                        <br />

                                        <asp:HiddenField ID="hdCarInsuranceTypeID" runat="server" />
                                        <asp:HiddenField ID="hdCarParamChk" runat="server" />

                                        <br />


                                    </div>
                                    <div class="col-xs-6 align-right">

                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="lblContractDuration" runat="server" CssClass="control-label">Contract Dutaion</asp:Label>
                                                    <asp:TextBox ID="txtContractDuration" runat="server" CssClass="form-control"></asp:TextBox>
                                                    <ajaxConTK:FilteredTextBoxExtender ID="ftBoxExdrContractDuration" runat="server" TargetControlID="txtContractDuration" FilterType="Custom, Numbers" />
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="lblContractChargeType" runat="server" CssClass="control-label">Contract Charge Type</asp:Label>


                                                    <asp:DropDownList ID="ddlContractChargeType" runat="server" Height="100%" class="form-control">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator InitialValue="-1" ID="rfvContractChargeType" runat="server" ControlToValidate="ddlContractChargeType" ForeColor="Red"
                                                        ErrorMessage="Please Select Contract Charge Type."
                                                        Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="lblContractNote" runat="server" CssClass="control-label">Contract Note</asp:Label>
                                                    <asp:TextBox ID="txtContractNote" runat="server" CssClass="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="Label3" runat="server" CssClass="control-label">Charge Type Note</asp:Label>
                                                    <asp:TextBox ID="txtChargeTypeNote" runat="server" CssClass="form-control"></asp:TextBox>
                                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtMinimumLimitAmt" ForeColor="Red"
                                                    ErrorMessage="Please enter minimum limit amount."
                                                    Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                                <ajaxConTK:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" TargetControlID="txtMinimumLimitAmt" FilterType="Custom, Numbers" ValidChars="." />--%>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="Label7" runat="server" CssClass="control-label">Charge Amount</asp:Label>
                                                    <asp:TextBox ID="txtChargeAmount" runat="server" CssClass="form-control"></asp:TextBox>
                                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtMinimumLimitAmt" ForeColor="Red"
                                                    ErrorMessage="Please enter minimum limit amount."
                                                    Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>--%>
                                                    <ajaxConTK:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" TargetControlID="txtChargeAmount" FilterType="Custom, Numbers" ValidChars="." />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="Label25" runat="server" CssClass="control-label">Total Channel No</asp:Label>
                                                    <asp:TextBox ID="txtTotalChannelNo" TextMode="Number" runat="server" CssClass="form-control"></asp:TextBox>
                                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtMinimumLimitAmt" ForeColor="Red"
                                                    ErrorMessage="Please enter minimum limit amount."
                                                    Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                                <ajaxConTK:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" TargetControlID="txtMinimumLimitAmt" FilterType="Custom, Numbers" ValidChars="." />--%>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="Label26" runat="server" CssClass="control-label">Redirect Url</asp:Label>
                                                    <asp:TextBox ID="txtRedirectUrl" runat="server" CssClass="form-control"></asp:TextBox>
                                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtMinimumLimitAmt" ForeColor="Red"
                                                    ErrorMessage="Please enter minimum limit amount."
                                                    Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                                <ajaxConTK:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" TargetControlID="txtMinimumLimitAmt" FilterType="Custom, Numbers" ValidChars="." />--%>
                                                </div>
                                            </div>
                                        </div>

                                        <br />
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="lblIsRemoved1" runat="server" CssClass="control-label">Is Removed</asp:Label>
                                                    <asp:CheckBox ID="chkIsRemoved" runat="server" CssClass="form-control"></asp:CheckBox>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row" style="font-size: 16px">
                                            <div class="col-sm-12">
                                                <asp:Label ID="lblMessageFeature" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <br />
                                        <fieldset>
                                            <legend>Channel List</legend>
                                            <asp:ListView ID="lvChannel" runat="server" DataKeyNames="IID"
                                                OnPagePropertiesChanging="lvlvChannel_PagePropertiesChanging" OnItemDataBound="lvChannel_OnItemDataBound" OnPreRender="dataPagerChannel_PreRender">
                                                <LayoutTemplate>
                                                    <table class="table  table-hover table-bordered">
                                                        <thead>
                                                            <tr runat="server">
                                                                <th class="col-xs-2" style="text-align: center">
                                                                    <asp:CheckBox runat="server" ID="chkHeader" Text="SL #" />
                                                                </th>
                                                                <th class="col-xs-4">Serial No
                                                                </th>
                                                                <th class="col-xs-4">Channel Name
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
                                                            <asp:CheckBox runat="server" CssClass="childChkBox" ID="chkItem" Text=' ' />
                                                            <asp:HiddenField runat="server" Visible="false" ID="hdChannelId" Value='<%# Bind("IID") %>' />
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("SerialNo") %>'></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label11" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
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
                                            <%--<asp:DataPager ID="dataPagerChannel" runat="server" PagedControlID="lvChannel"
                                            PageSize="10" OnPreRender="dataPagerChannel_PreRender">
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
                                        </asp:DataPager>--%>
                                        </fieldset>
                                    </div>


                                </div>

                                <div class="col-sm-12 col-md-12">
                                    <div class="row">
                                        <br />
                                        <div class="form-group">
                                            <div class="col-sm-3 col-md-3 pull-right">
                                                <asp:Button ID="Button2" runat="server" Text="Cancel" CssClass="btn btn-danger" OnClick="btnCancel_Click" />

                                                <asp:Button ID="Button3" runat="server" class="btn btn-primary" Text="Submit"
                                                    ValidationGroup="gen" OnClick="btnCreateOrEdit_Click"></asp:Button>

                                                <asp:Button ID="btnPrint" runat="server" class="btn btn-primary" Text="Print"
                                                    OnClick="btnPrint_Click"></asp:Button>
                                                <asp:HiddenField ID="hdBDInternetID" runat="server" />
                                                <CR:CrystalReportViewer ID="CrystalReportViewer1" Height="900" Width="700" runat="server" AutoDataBind="true"/>

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

