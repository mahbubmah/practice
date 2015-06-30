<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.Master" AutoEventWireup="true" CodeBehind="DistrictWF.aspx.cs" Inherits="OMart.Web.ControlAdmin.DistrictWF" %>

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
                                <legend>Add/Edit District</legend>
                                <div class="col-xs-6">
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="lblCountry" runat="server" CssClass="control-label">Country</asp:Label>
                                                <asp:DropDownList ID="ddlCountry" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rfvCountry" runat="server" ControlToValidate="ddlCountry" ForeColor="Red"
                                                    ErrorMessage="Please select Country."
                                                    Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="lblDivOrState" runat="server" CssClass="control-label">Division Or State</asp:Label>
                                                <asp:DropDownList ID="ddlDivisionOrState" runat="server" CssClass="form-control"></asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rfvDivOrState" runat="server" ControlToValidate="ddlDivisionOrState" ForeColor="Red"
                                                    ErrorMessage="Please select Division Or State."
                                                    Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="lblDistrictCode" runat="server" CssClass="control-label">District Code</asp:Label>
                                                <asp:TextBox ID="txtCode" runat="server" CssClass="form-control"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvCode" runat="server" ControlToValidate="txtCode" ForeColor="Red"
                                                    ErrorMessage="Please enter District code."
                                                    Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="lblDistrictName" runat="server" CssClass="control-label">District Name</asp:Label>
                                                <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName" ForeColor="Red"
                                                    ErrorMessage="Please enter Division Or State name."
                                                    Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="clearfix">
                                            <asp:CheckBox ID="chkIsRemovedDistrict" runat="server" CssClass="checkbox" Text=" IsRemoved" />
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-danger" OnClick="btnCancel_Click" />

                                                <asp:Button ID="btn_CreateOrEdit" runat="server" class="btn btn-primary  pull-right" Text="Submit"
                                                    OnClick="btn_CreateOrEdit_Click" ValidationGroup="gen"></asp:Button>
                                                <asp:HiddenField ID="hdDistrictID" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </fieldset>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-sm-12">
                    <div class="manageAdd">
                        <div class="addPostMang">

                            <fieldset class="adminFieldset">
                                <legend>District Lists</legend>

                                <asp:ListView ID="lvDistrict" runat="server" DataKeyNames="IID"
                                    OnPagePropertiesChanging="lvDistrict_PagePropertiesChanging" OnPreRender="dataPagerDistrict_PreRender">
                                    <LayoutTemplate>
                                        <table class="table  table-hover table-bordered">
                                            <thead>
                                                <tr runat="server">
                                                    <th class="col-xs-1">SL #
                                                    </th>
                                                    <th class="col-xs-2">Country 
                                                    </th>
                                                    <th class="col-xs-3">DivisionOrState 
                                                    </th>
                                                    <th class="col-xs-2">District Code
                                                    </th>
                                                    <th class="col-xs-2">District Name
                                                    </th>
                                                    <th class="col-xs-1">Is Removed
                                                    </th>
                                                    <th>Edit
                                                    </th>
                                                    <th>Delete
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
                                                <asp:Label ID="lblCountry" runat="server" Text='<%# Bind("CountryName") %>'></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblDivisionOrState" runat="server" Text='<%# Bind("DivisionOrState") %>'></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblCode" runat="server" Text='<%# Bind("Code") %>'></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblName" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="chkIsRemoved" runat="server" Checked='<%# Bind("IsRemoved") %>' Enabled="false"></asp:CheckBox>
                                            </td>

                                            <td>
                                                <p data-placement="top" data-toggle="tooltip" title="Edit">
                                                    <asp:LinkButton ID="lnkbEdit" runat="server" CausesValidation="false" class="btn btn-primary btn-xs" data-title="Edit"
                                                        CommandArgument='<%# Bind("IID") %>' OnClick="lnkbEdit_Click"><i class="fa fa-pencil-square-o"></i></asp:LinkButton>

                                                </p>
                                            </td>
                                            <td>
                                                <p data-placement="top" data-toggle="tooltip" title="Delete">
                                                    <asp:LinkButton ID="lnkbDelete" runat="server" CausesValidation="false" class="btn btn-danger btn-xs" data-title="Delete" OnClientClick="return confirm('Are you sure, do you want to delete?');"
                                                        CommandArgument='<%# Bind("IID") %>' OnClick="lnkbDelete_Click"><i class="fa fa-trash"></i></asp:LinkButton>
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
                                <asp:DataPager ID="dataPagerDistrict" runat="server" PagedControlID="lvDistrict"
                                    PageSize="10" OnPreRender="dataPagerDistrict_PreRender">
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


        </div>
    </section>
</asp:Content>
