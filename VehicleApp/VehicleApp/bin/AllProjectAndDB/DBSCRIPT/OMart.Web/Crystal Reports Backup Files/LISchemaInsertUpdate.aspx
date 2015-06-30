<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.Master" AutoEventWireup="true" CodeBehind="LISchemaInsertUpdate.aspx.cs" Inherits="OMart.Web.AdminPanel.LISchemaInsertUpdate" %>

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
                                <legend>Add/Edit Life Insurance Schema</legend>
                                <div class="col-xs-12">
                                    <div class="col-xs-6">
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="Label7" runat="server" CssClass="control-label">Number of Year</asp:Label>

                                                    <asp:TextBox ID="txtNoOfYr" TextMode="Number" runat="server" CssClass="form-control"></asp:TextBox>

                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtNoOfYr" ForeColor="Red"
                                                        ErrorMessage="PLease enter No. of year."
                                                        Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </div>

                                        <br />
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="Label9" runat="server" CssClass="control-label">Age Min</asp:Label>
                                                    <asp:TextBox ID="txtAgeMin" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtAgeMin" ForeColor="Red"
                                                        ErrorMessage="PLease enter Minimum Age."
                                                        Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="Label10" runat="server" CssClass="control-label">Age Max</asp:Label>
                                                    <asp:TextBox ID="txtAgeMax" TextMode="Number" runat="server" CssClass="form-control"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtAgeMax" ForeColor="Red"
                                                        ErrorMessage="PLease enter Maximum Age"
                                                        Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </div>
                                        <br />

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
                                    <div class="col-xs-6 align-right">

                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="Label14" runat="server" CssClass="control-label">Unit Return Amount</asp:Label>
                                                    <asp:TextBox ID="txtUnitReturnAmount" runat="server" CssClass="form-control"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtUnitReturnAmount" ForeColor="Red"
                                                        ErrorMessage="PLease enter Unit Return Amount."
                                                        Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                                    <ajaxConTK:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" TargetControlID="txtUnitReturnAmount" FilterType="Custom, Numbers" ValidChars="." />
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="Label15" runat="server" CssClass="control-label">Premium Policy ID</asp:Label>


                                                    <asp:DropDownList ID="dropDownComInfoID" runat="server" Height="100%" class="form-control">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator InitialValue="-1" ID="RequiredFieldValidator14" runat="server" ControlToValidate="dropDownComInfoID" ForeColor="Red"
                                                        ErrorMessage="Please select Premium Policy ID."
                                                        Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </div>

                                        <br />
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="Label11" runat="server" CssClass="control-label">Unit Amount</asp:Label>
                                                    <asp:TextBox ID="txtUnitAmount" runat="server" CssClass="form-control"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtUnitAmount" ForeColor="Red"
                                                        ErrorMessage="PLease enter Unit Amount."
                                                        Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                                    <ajaxConTK:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" TargetControlID="txtUnitAmount" FilterType="Custom, Numbers" ValidChars="." />
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="Label1" runat="server" CssClass="control-label">Multiple Factor</asp:Label>
                                                    <asp:TextBox ID="txtMultipleFactor" TextMode="Number" runat="server" CssClass="form-control"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtMultipleFactor" ForeColor="Red"
                                                        ErrorMessage="PLease enter Unit Amount."
                                                        Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>

                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="Label12" runat="server" CssClass="control-label">Unit Premium Amount</asp:Label>
                                                    <asp:TextBox ID="txtUnitPremiumAmount" runat="server" CssClass="form-control"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtUnitPremiumAmount" ForeColor="Red"
                                                        ErrorMessage="PLease enter Unit Premium Amount."
                                                        Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                                    <ajaxConTK:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" TargetControlID="txtUnitPremiumAmount" FilterType="Custom, Numbers" ValidChars="." />
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <%-- <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="lblIsRemoved1" runat="server" CssClass="control-label">Is Removed</asp:Label>
                                                    <asp:CheckBox ID="chkIsRemoved" runat="server" CssClass="form-control"></asp:CheckBox>
                                                </div>
                                            </div>
                                        </div>--%>
                                        <div class="row">
                                            <div class="col-md-9">
                                                <div class="input-group">
                                                    <asp:CheckBox ID="chkIsRemoved" runat="server" CssClass="form-control" Text="Is Removed" BorderStyle="None"></asp:CheckBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row" style="font-size: 16px">
                                        <div class="col-sm-6">
                                            <asp:Label ID="lblMessageFeature" runat="server"></asp:Label>
                                        </div>
                                    </div>

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
