<%@ Page Title="" Language="C#" MasterPageFile="~/MobileMasterPage.Master" AutoEventWireup="true" CodeBehind="PayAsYouGoWF.aspx.cs" Inherits="OMart.Web.PayAsYouGoWF" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MobilePlaceHolder" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="container payasuDesc">
                <div class="row">
                    <div class="col-sm-3 col-md-3 col-lg-3">

                        <div class="panelSearchSidebar">
                            <asp:Label runat="server" ID="lblMessage"></asp:Label>
                            <h4>SELECT A MANUFACTURER</h4>
                            <div class="selectAllmfg">
                                <asp:DropDownList ID="ddlMobileCompany" AutoPostBack="true" runat="server" class="form-control" OnSelectedIndexChanged="ddlMobileCompany_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                            <h4>SELECT A MODEL</h4>
                            <div class="selectAllmfg">
                                <asp:DropDownList ID="ddlMobileTypeAndModel" AutoPostBack="true" runat="server" class="form-control" OnSelectedIndexChanged="ddlMobileTypeAndModel_OnSelectedIndexChanged">
                                </asp:DropDownList>
                            </div>

                            <div class="chooseNetwork">
                                <h4>CHOOSE A NETWORK</h4>

                                <asp:Repeater runat="server" ID="repNetworkImage" OnItemCommand="repNetworkImage_OnItemCommand">
                                    <HeaderTemplate>
                                        <asp:LinkButton ID="allNetwork" runat="server" CssClass="activeNetwork" Text="All networks" CommandArgument="-1"></asp:LinkButton>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="Network5" runat="server" CommandArgument='<%# Eval("IID") %>'><asp:Image runat="server" ImageUrl='<%# Eval("LogoUrl") %>' Width="45" Height="40"/></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:Repeater>

                                <div class="clearfix"></div>
                            </div>
                            <h4>SELECT YOUR PERFECT DEAL</h4>
                            <div>
                                <ul style="list-style-type: none;">
                                    <li>
                                        <asp:DropDownList ID="ddTotalTalkTime" AutoPostBack="true" runat="server" class="form-control" OnSelectedIndexChanged="ddTotalTalkTime_OnSelectedIndexChanged">
                                        </asp:DropDownList>
                                    </li>
                                    <br />
                                    <li>
                                        <asp:DropDownList ID="ddUsableData" AutoPostBack="true" runat="server" class="form-control" OnSelectedIndexChanged="ddUsableData_OnSelectedIndexChanged">
                                        </asp:DropDownList>
                                    </li>
                                    <br />
                                    <li>

                                        <asp:DropDownList ID="ddMonthlyInstallment" AutoPostBack="true" runat="server" class="form-control" OnSelectedIndexChanged="ddMonthlyInstallment_OnSelectedIndexChanged">
                                        </asp:DropDownList>
                                    </li>
                                </ul>
                                <div class="clearfix"></div>
                            </div>
                            <%-- <h4>SORT BY</h4>
                            <div class="soryBy">
                                <!-- Nav tabs -->
                                <ul class="nav nav-tabs" role="tablist">
                                    <li role="presentation" class="active"><a href="#home" aria-controls="home" role="tab" data-toggle="tab">Featured deals</a></li>
                                    <li role="presentation"><a href="#profile" aria-controls="profile" role="tab" data-toggle="tab">Monthly cost</a></li>
                                </ul>
                            </div>--%>
                        </div>

                    </div>
                    <div class="col-sm-9 col-md-9 col-lg-9">

                        <asp:ListView ID="lv_PayAsYouGo" runat="server" DataKeyNames="IID" OnPreRender="dataPagerPayAsYouGo_OnPreRender" OnPagePropertiesChanging="lv_PayAsYouGo_OnPagePropertiesChanging">
                            <LayoutTemplate>
                                <table class="table payasuDescTb table-hover" id="task-table">
                                    <thead>
                                        <tr runat="server">
                                            <th class="sl_th"></th>
                                            <th class="img_th sort_th ">sort by:</th>
                                            <th class="sort_th"><span class="btn btn-danger">Bestsellers</span> </th>
                                            <th class="cont_th">Contract</th>
                                            <th class="mint_th">Minutes</th>
                                            <th class="text_th">Texts</th>
                                            <th class="date_th">Data</th>
                                            <th class="montCst_th col-xs-2">Cost/Month</th>
                                            <th></th>
                                        </tr>

                                    </thead>
                                    <tbody id="itemPlaceholder" runat="server">
                                    </tbody>
                                </table>
                            </LayoutTemplate>
                            <ItemTemplate>
                                <tr runat="server" class="sl_th">
                                    <td style="text-align: center">
                                        <%# Container.DataItemIndex + 1%>
                                    </td>
                                    <td class="img_td">
                                        <asp:Image runat="server" ID="image" ImageUrl='<%# Bind("PictureUrl") %>' Width="150" Height="75" />
                                    </td>
                                    <td class="productDescription">
                                        <asp:Label ID="lblproductDescription" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                    </td>
                                    <td class="cont_th">
                                        <asp:Label ID="lblNote" runat="server" Text='<%# Bind("TotalTalkTime") %>'></asp:Label>
                                    </td>
                                    <td class="mint_th">
                                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("TotalTalkTime")+" "+ Enum.Parse(typeof(Utilities.EnumCollection.TalkTimeUnit), Eval("TalkTimeUnitID").ToString()) %>'></asp:Label>

                                    </td>
                                    <td class="text_th">
                                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("TotalTextMessage") %>'></asp:Label>

                                    </td>
                                    <td class="date_th">
                                        <asp:Label ID="Label11" runat="server" Text='<%# Eval("TotalUsableData")+" "+ Enum.Parse(typeof(Utilities.EnumCollection.UsableDataUnit), Eval("UsableDataUnitID").ToString()) %>'></asp:Label>
                                    </td>
                                    <td class="montCst_th">
                                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("MonthlyInstallmentAmt","{0:0.##}")+" TK" %>'></asp:Label>
                                    </td>

                                    <td>
                                        <td>
                                            <div class="applyBox">
                                                <%--   <img src="Images/products/0403_6.jpg" alt="img" />--%>
                                                <a runat="server" href='<%# Eval("RedirectUrl") %>' class="btn btn-seeDeal" target="_blank">See deal<span class="glyphicon glyphicon-chevron-right oioCherRight2"></span></a>
                                            </div>
                                        </td>
                                    </td>
                                </tr>

                            </ItemTemplate>
                            <EmptyDataTemplate>
                                <tr>
                                    <td>
                                        <h3 style="color: red; text-align: center">No match found ...
                                        </h3>
                                    </td>
                                </tr>
                            </EmptyDataTemplate>
                        </asp:ListView>
                        <div class="pull-right">
                            <asp:DataPager ID="dataPagerPayAsYouGo" runat="server" PagedControlID="lv_PayAsYouGo"
                                PageSize="10" OnPreRender="dataPagerPayAsYouGo_OnPreRender">
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
                        </div>


                        <%--   <tr style="margin-top: 10px;">
                            <td>
                                <div class="text-center">
                                    <p><a href="#" class="btn btn-info">Show all deals</a></p>
                                </div>

                            </td>
                        </tr>--%>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
