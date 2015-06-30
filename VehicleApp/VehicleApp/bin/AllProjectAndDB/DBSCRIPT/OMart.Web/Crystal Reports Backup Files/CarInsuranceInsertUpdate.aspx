<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.Master" AutoEventWireup="true" CodeBehind="CarInsuranceInsertUpdate.aspx.cs" Inherits="OMart.Web.AdminPanel.CarInsuranceInsertUpdate" %>

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
                                <legend>Add/Edit Car Insurance and Feature</legend>
                                <div class="col-xs-12">
                                    <div class="col-xs-6">
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="Label2" runat="server" CssClass="control-label">Company Type</asp:Label>


                                                    <asp:DropDownList ID="DropDownCompanyInfoID" runat="server" Height="100%" class="form-control">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator InitialValue="-1" ID="RequiredFieldValidator2" runat="server" ControlToValidate="DropDownCompanyInfoID" ForeColor="Red"
                                                        ErrorMessage="Please select Company Type."
                                                        Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <asp:HiddenField ID="hdCarInsuranceTypeID" runat="server" />
                                        <asp:HiddenField ID="hdCarParamChk" runat="server" />
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="Label7" runat="server" CssClass="control-label">Car Insurance Parameter Type ID</asp:Label>

                                                    <asp:TextBox ID="txtCarInsuranceParameterID" ReadOnly="true" runat="server" CssClass="form-control"></asp:TextBox>

                                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtNoOfYr" ForeColor="Red"
                                                    ErrorMessage="PLease enter No. of year."
                                                    Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>--%>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row align-right">
                                            <div class="form-group">

                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Button ID="btnShowCarInsParDiv" runat="server" Text="View Searching Option" CssClass="btn btn-primary" OnClick="btnShowCarInsParDiv_Click" />
                                                </div>

                                            </div>
                                        </div>

                                        <div id="DivShowCarInsParDiv" runat="server">
                                            <div class="row">
                                                <div class="form-group">
                                                    <div class="col-sm-9 col-md-9">
                                                        <asp:Label ID="lblCountry" runat="server" CssClass="control-label">Car Type</asp:Label>
                                                        <asp:DropDownList ID="ddlCarType" runat="server" CssClass="form-control" AutoPostBack="true"></asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="rfvCountry" runat="server" ControlToValidate="ddlCarType" ForeColor="Red"
                                                            ErrorMessage="Please select Car Type." InitialValue=""
                                                            Display="Dynamic" ValidationGroup="gon"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                            </div>
                                            <br />
                                            <div class="row">
                                                <div class="form-group">
                                                    <div class="col-sm-9 col-md-9">
                                                        <asp:Label ID="Label3" runat="server" CssClass="control-label">Car Condition</asp:Label>
                                                        <asp:DropDownList ID="ddlCarCondition" runat="server" CssClass="form-control" AutoPostBack="true"></asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlCarCondition" ForeColor="Red"
                                                            ErrorMessage="Please select Car Condition." InitialValue=""
                                                            Display="Dynamic" ValidationGroup="gon"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                            </div>
                                            <br />
                                            <div class="row">
                                                <div class="form-group">
                                                    <div class="col-sm-9 col-md-9">
                                                        <asp:Label ID="Label5" runat="server" CssClass="control-label">Min Car Value Amount</asp:Label>
                                                        <asp:TextBox ID="txtMinCarValueAmount" runat="server" CssClass="form-control"></asp:TextBox>
                                                        <ajaxConTK:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" runat="server" TargetControlID="txtMinCarValueAmount" FilterType="Custom, Numbers" ValidChars="." />
                                                    </div>
                                                </div>
                                            </div>
                                            <br />

                                            <div class="row">
                                                <div class="form-group">
                                                    <div class="col-sm-9 col-md-9">
                                                        <asp:Label ID="Label6" runat="server" CssClass="control-label">Max Car Value Amount</asp:Label>
                                                        <asp:TextBox ID="txtMaxCarValueAmount" runat="server" CssClass="form-control"></asp:TextBox>
                                                        <ajaxConTK:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server" TargetControlID="txtMaxCarValueAmount" FilterType="Custom, Numbers" ValidChars="." />
                                                    </div>
                                                </div>
                                            </div>
                                            <br />
                                            <div class="row align-right">
                                                <div class="form-group">
                                                    <div class="col-sm-9 col-md-9">
                                                        <asp:Button ID="btnSearchParameter" ValidationGroup="gon" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="btnSearchParameter_Click" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <fieldset class="adminFieldset">
                                            <legend>Car Insurance Parameter Lists</legend>

                                            <asp:ListView ID="lvInsuranceParameter" runat="server" DataKeyNames="IID" OnItemCommand="lvInsuranceParameter_ItemCommand" OnPagePropertiesChanging="lvInsuranceParameter_PagePropertiesChanging" OnPreRender="lvInsuranceParameter_PreRender">
                                                <LayoutTemplate>
                                                    <table class="table  table-hover table-bordered">
                                                        <thead>
                                                            <tr runat="server">
                                                                <th class="col-xs-1">SL #
                                                                </th>
                                                                <th class="col-xs-6">Car Type
                                                                </th>

                                                                <th class="col-xs-1">Car Condition
                                                                </th>
                                                                <th class="col-xs-1">Min Car Value Amount
                                                                </th>
                                                                <th class="col-xs-1">Max Car Value Amount
                                                                </th>
                                                                <th class="col-xs-1">Select
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
                                                            <asp:Label ID="lblCode" runat="server" Text='<%# Enum.Parse(typeof( Utilities.EnumCollection.CarType),Eval("CarTypeID").ToString()) %>'></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label13" runat="server" Text='<%# Enum.Parse(typeof( Utilities.EnumCollection.CarCondition),Eval("CarConditionID").ToString()) %>'></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label5" runat="server" Text='<%# Bind("MinCarValueAmount") %>'></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label6" runat="server" Text='<%# Bind("MaxCarValueAmount") %>'></asp:Label>
                                                        </td>

                                                        <%--<td>
                                                                    <asp:CheckBox ID="chkIsRemoved" runat="server" Checked='<%# Bind("IsRemoved") %>' Enabled="false"></asp:CheckBox>
                                                                </td>--%>
                                                        <td>
                                                            <p data-placement="top" data-toggle="tooltip" title="Edit">
                                                                <asp:LinkButton ID="lnkbEdit" runat="server" CausesValidation="false" class="btn btn-primary btn-xs" data-title="Edit"
                                                                    CommandArgument='<%# Bind("IID") %>' OnClick="lnkbSelect_Click"><i class="fa fa-pencil-square-o"></i></asp:LinkButton>

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
                                            <asp:DataPager ID="dataPager1" runat="server" PagedControlID="lvInsuranceParameter"
                                                PageSize="5" OnPreRender="dataPagerInsuranceParameter_PreRender">
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
                                    <div class="col-xs-6 align-right">
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="Label9" runat="server" CssClass="control-label">Car Value Amount</asp:Label>
                                                    <asp:TextBox ID="txtCarValueAmount" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
                                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtCarValueAmount" ForeColor="Red"
                                                        ErrorMessage="PLease enter Car Value Amount."
                                                        Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>--%>
                                                    <ajaxConTK:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server" TargetControlID="txtCarValueAmount" FilterType="Custom, Numbers" ValidChars="." />
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="Label10" runat="server" CssClass="control-label">Fixed Total Amount</asp:Label>
                                                    <asp:TextBox ID="txtFixedTotalAmount" TextMode="Number" runat="server" CssClass="form-control"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtFixedTotalAmount" ForeColor="Red"
                                                        ErrorMessage="PLease enter Maximum Age"
                                                        Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                                    <ajaxConTK:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txtFixedTotalAmount" FilterType="Custom, Numbers" ValidChars="." />
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="Label14" runat="server" CssClass="control-label">Fixed Voluntary Amount</asp:Label>
                                                    <asp:TextBox ID="txtFixedVoluntaryAmount" runat="server" CssClass="form-control"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtFixedVoluntaryAmount" ForeColor="Red"
                                                        ErrorMessage="PLease enter Unit Return Amount."
                                                        Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                                    <ajaxConTK:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" TargetControlID="txtFixedVoluntaryAmount" FilterType="Custom, Numbers" ValidChars="." />
                                                </div>
                                            </div>
                                        </div>

                                        <br />
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="Label11" runat="server" CssClass="control-label">Fixed Compulsory Amount</asp:Label>
                                                    <asp:TextBox ID="txtFixedCompulsoryAmount" runat="server" CssClass="form-control"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtFixedCompulsoryAmount" ForeColor="Red"
                                                        ErrorMessage="PLease enter Unit Amount."
                                                        Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                                    <ajaxConTK:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" TargetControlID="txtFixedCompulsoryAmount" FilterType="Custom, Numbers" ValidChars="." />
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="Label1" runat="server" CssClass="control-label">Annually Gross Amount</asp:Label>
                                                    <asp:TextBox ID="txtAnnuallyGrossAmount" TextMode="Number" runat="server" CssClass="form-control"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAnnuallyGrossAmount" ForeColor="Red"
                                                        ErrorMessage="PLease enter Unit Amount."
                                                        Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                                    <ajaxConTK:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtAnnuallyGrossAmount" FilterType="Custom, Numbers" ValidChars="." />
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="Label12" runat="server" CssClass="control-label">Total Month</asp:Label>
                                                    <asp:TextBox ID="txtTotalMonth" TextMode="Number" runat="server" CssClass="form-control"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtTotalMonth" ForeColor="Red"
                                                        ErrorMessage="PLease enter Unit Premium Amount."
                                                        Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>

                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="Label4" runat="server" CssClass="control-label">Installment Amount</asp:Label>
                                                    <asp:TextBox ID="txtInstallmentAmount" runat="server" CssClass="form-control"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtInstallmentAmount" ForeColor="Red"
                                                        ErrorMessage="PLease enter Unit Premium Amount."
                                                        Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                                    <ajaxConTK:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtInstallmentAmount" FilterType="Custom, Numbers" ValidChars="." />
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                    
                                    </div>

                                    <div class="row" style="font-size: 16px">
                                        <div class="col-sm-12">
                                            <asp:Label ID="lblMessageFeature" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                    <fieldset class="adminFieldset" style="width: 400px;">
                                        <legend>Feature of Life Insurance</legend>
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-12">
                                                    <span style="float: left; margin-right: 20px">
                                                        <asp:Label ID="Label8" runat="server" CssClass="control-label">Description</asp:Label></span>
                                                    <span style="float: left; margin-right: 20px">
                                                        <asp:TextBox ID="txtDesFeature" TextMode="MultiLine" runat="server" CssClass="form-control"></asp:TextBox></span>
                                                </div>
                                            </div>
                                        </div>


                                        <br />
                                        <div class="row align-right">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Button ID="Button1" runat="server" Text="Add Feature" CssClass="btn btn-primary" OnClick="btnAddFeature_Click" />
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
                                                <asp:Button ID="Button2" runat="server" Text="Cancel" CssClass="btn btn-danger" OnClick="btnCancel_Click" />

                                                <asp:Button ID="Button3" runat="server" class="btn btn-primary" Text="Submit"
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
