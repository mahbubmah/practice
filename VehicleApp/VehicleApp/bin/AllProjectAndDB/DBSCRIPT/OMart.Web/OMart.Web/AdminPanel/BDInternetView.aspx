<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.Master" AutoEventWireup="true" CodeBehind="BDInternetView.aspx.cs" Inherits="OMart.Web.AdminPanel.BDInternetView" %>
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
                                <legend>BD Internet List</legend>

                                <asp:ListView ID="lvBDInternet" runat="server" DataKeyNames="IID"
                                    OnPagePropertiesChanging="lvBDInternet_PagePropertiesChanging" OnPreRender="dataPagerBDInternet_PreRender">
                                    <LayoutTemplate>
                                        <table class="table  table-hover table-bordered">
                                            <thead>
                                                <tr runat="server">
                                                    <th class="col-xs-1">SL #
                                                    </th>
                                                    <th class="col-xs-2">Provider Name
                                                    </th>
                                                    <th class="col-xs-2">Type Name
                                                    </th>
                                                    <th class="col-xs-2">Package Name
                                                    </th>
                                                    
                                                    <th class="col-xs-2">Net Speed
                                                    </th>
                                                    <th class="col-xs-2">Net Speed Unit
                                                    </th>
                                                    <th class="col-xs-2">Download Speed
                                                    </th>
                                                    
                                                    <th class="col-xs-2">Download Speed Unit

                                                    </th>
                                                    <th class="col-xs-2">DataAmount

                                                    </th>
                                                       <th class="col-xs-2">Net Generation Type
                                                    </th>
                                                    <th class="col-xs-2">Charge Type
                                                    </th>
                                                    <th class="col-xs-2">Charge Type Note
                                                    </th>
                                                    
                                                    <th class="col-xs-2">Charge Amount

                                                    </th>
                                                    <th class="col-xs-2">TotalChannelNo

                                                    </th>
                                                    <th class="col-xs-2">Redirect Url

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
                                                <asp:Label ID="lblCode" runat="server" Text= '<%# Bind("interCompanyName") %>'  ></asp:Label>
                                            </td>
                                            
                                            <td>
                                                <asp:Label ID="lblISDCode" runat="server" Text='<%# Enum.Parse(typeof( Utilities.EnumCollection.Type),Eval("TypeID").ToString()) %>' ></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label1" runat="server" Text= '<%# Bind("PackageName") %>'></asp:Label>
                                            </td>
                                            
                                            <td>
                                                <asp:Label ID="Label5" runat="server" Text='<%# Bind("NetSpeed") %>'></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label3" runat="server" Text='<%# Enum.Parse(typeof( Utilities.EnumCollection.UsableDataUnit),Eval("NetSpeedUnitID").ToString()) %>'></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblName" runat="server" Text='<%# Bind("DownloadSpeed") %>'></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="Label6" runat="server" Text='<%# Enum.Parse(typeof( Utilities.EnumCollection.UsableDataUnit),Eval("DownloadSpeedUnitID").ToString()) %>' ></asp:Label>
                                            </td>
                                            
                                            <td style="text-align: left">
                                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("DataAmount") %>'></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label7" runat="server" Text='<%# Enum.Parse(typeof( Utilities.EnumCollection.ConnectionType),Eval("NetGenerationID").ToString()) %>' ></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label8" runat="server" Text='<%# Enum.Parse(typeof( Utilities.EnumCollection.PremiumPolicy),Eval("ChargeTypeID").ToString()) %>'> </asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="Label9" runat="server" Text='<%# Bind("ChargeTypeNote") %>'></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="Label10" runat="server" Text='<%# Bind("ChargeAmount") %>'></asp:Label>
                                            </td>
                                            
                                            <td style="text-align: left">
                                                <asp:Label ID="Label11" runat="server" Text='<%# Bind("TotalChannelNo") %>'></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="Label12" runat="server" Text='<%# Bind("RedirectUrl") %>'></asp:Label>
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
                                <asp:DataPager ID="dataPagerBDInternet" runat="server" PagedControlID="lvBDInternet"
                                    PageSize="10" OnPreRender="dataPagerBDInternet_PreRender">
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


