<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.Master" AutoEventWireup="true" CodeBehind="LifeInsuranceWF.aspx.cs" Inherits="OMart.Web.AdminPanel.LifeInsuranceWF" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AdminHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AdminContentPlaceHolder" runat="server">
    <section>
        <div class="container">

            <br />
            <div class="row">
                <div class="col-sm-12">
                    <div class="pull-left">
                        <asp:Label ID="labelMessage" runat="server"></asp:Label>
                    </div>
                    <div class="pull-right">

                        <asp:Button ID="btnAdd" runat="server" Text="Add New" OnClick="btnAdd_Click" CssClass="btn btn-primary" />
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-sm-12">
                    <div class="manageAdd">
                        <div class="addPostMang">

                            <fieldset class="adminFieldset">
                                <legend>Life Insurance  List</legend>

                                <asp:ListView ID="lvLiSchema" runat="server" DataKeyNames="IID"
                                    OnPagePropertiesChanging="lvLiSchema_PagePropertiesChanging" OnPreRender="dataPagerLiSchema_PreRender">
                                    <LayoutTemplate>
                                        <table class="table  table-hover table-bordered">
                                            <thead>
                                                <tr runat="server">
                                                    <th class="col-xs-1">SL #
                                                    </th>
                                                    <th class="col-xs-2">Company Name
                                                    </th>
                                                    <th class="col-xs-2">Number Of Year
                                                    </th>
                                                    <th class="col-xs-2">Package Name
                                                    </th>
                                                    
                                                    <th class="col-xs-2">Total Cover Amount
                                                    </th>
                                                    <th class="col-xs-2">Critical Iillness Cover Amount
                                                    </th>
                                                    <th class="col-xs-2">Claim Paid Percent

                                                    </th>
                                                    <th class="col-xs-2">IS Guranteed Premium

                                                    </th>
                                                    <th class="col-xs-2">Is Removed
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
                                                <asp:Label ID="lblCode" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                            </td>
                                            
                                            <td>
                                                <asp:Label ID="lblISDCode" runat="server" Text='<%# Bind("NumberOfYear") %>'></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("PackageName") %>'></asp:Label>
                                            </td>
                                            
                                            <td>
                                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("TotalCoverAmount") %>'></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblName" runat="server" Text='<%# Bind("CriticalillnessCoverAmount") %>'></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("ClaimsPaidPercent") %>'></asp:Label>
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="ChkBxISGuranteedPremium" runat="server" Checked='<%# Bind("ISGuranteedPremium") %>' Enabled="false"></asp:CheckBox>
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
                                <asp:DataPager ID="dataPagerLiSchema" runat="server" PagedControlID="lvLiSchema"
                                    PageSize="10" OnPreRender="dataPagerLiSchema_PreRender">
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
