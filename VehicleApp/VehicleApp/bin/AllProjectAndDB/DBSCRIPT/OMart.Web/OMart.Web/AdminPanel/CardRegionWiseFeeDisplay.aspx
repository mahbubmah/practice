<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.Master" AutoEventWireup="true" CodeBehind="CardRegionWiseFeeDisplay.aspx.cs" Inherits="OMart.Web.AdminPanel.CardRegionWiseFeeDisplay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AdminHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AdminContentPlaceHolder" runat="server">
    <section>
        <div class="container">
            <br />
            <div class="row">
                <div class="col-sm-12">
                    <div class="pull-left">
                        <asp:Label ID="labelMessageCardRegionWiseFeeDisplay" runat="server"></asp:Label>
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
                                <legend>Card RegionWise Fee List</legend>
                                <asp:ListView ID="lv_CardRegionWiseFee" runat="server" DataKeyNames="IID" OnPagePropertiesChanging="lv_CardRegionWiseFee_PagePropertiesChanging" OnPreRender="dataPagerlv_CardRegionWiseFee_PreRender" OnItemCommand="lv_CardRegionWiseFee_ItemCommand">
                                    <LayoutTemplate>
                                        <table class="table  table-hover table-bordered">
                                            <thead>
                                                <tr runat="server">
                                                    <th class="col-xs-1">SL #
                                                    </th>
                                                    <th class="col-xs-2">Card Name
                                                    </th>
                                                    <th class="col-xs-6">Region
                                                    </th>
                                                    <th class="col-xs-2">Note
                                                    </th>
                                                    <th class="col-xs-2">Usage Fee Percent
                                                    </th>
                                                    <th class="col-xs-2">IsRemoved
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
                                            <td style="text-align: left">
                                                <asp:Label ID="lblCardName" runat="server" Text='<%#Bind("CardName")%>'>
                                                </asp:Label>
                                                
                                                
                                            </td>
                                            <td>
                                                <asp:Label ID="lblCode" runat="server" Text='<%# Enum.Parse(typeof(Utilities.EnumCollection.RegionType), Eval("RegionID").ToString()) %>'></asp:Label>

                                            </td>
                                            <td>
                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("Note") %>'></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("UsageFeePercent") %>'></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("IsRemoved") %>'></asp:Label>
                                            </td>


                                            <%-- <td>
                                         <asp:Label ID="lblTypeID" runat="server" Text='<%# Enum.Parse(typeof(Utilities.EnumCollection.UserGrpType), Eval("TypeID").ToString())  %>'></asp:Label>
                                      </td>
                                        <td>
                                       <%-- <asp:Label ID="lblCountryID" runat="server" Text='<%# Bind("CounrtyName") %>'></asp:Label>--%>
                                            <%-- <asp:CheckBox ID="chkIsRemove" runat="server" Checked='<%# Bind("IsRemoved") %>' Enabled="true"/>--%>
                                            <%-- <asp:Label ID="lblIsRemoved" runat="server" Text='<%# Bind("IsRemoved") %>'></asp:Label>
                                        </td>----%<%-->%>--%>
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

                                <asp:DataPager ID="dataPagerCardWiseFeeDisplay" runat="server" PagedControlID="lv_CardRegionWiseFee"
                                    PageSize="10" OnPreRender="dataPagerlv_CardRegionWiseFee_PreRender">
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
