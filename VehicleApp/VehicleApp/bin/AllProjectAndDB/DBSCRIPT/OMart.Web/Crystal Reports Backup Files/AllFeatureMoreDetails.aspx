<%@ Page Title="" Language="C#" MasterPageFile="~/OiiOMasterPage.Master" AutoEventWireup="true" CodeBehind="AllFeatureMoreDetails.aspx.cs" Inherits="OMart.Web.AllFeatureMoreDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="well searchPanel3">
            <div class="panel-body">
                <div class="tab-content">
                    <div class="tab-pane fade in active" id="tab1default">

                        <div class="row panelBodyTop">
                            <div class="col-xs-4 col-sm-4 col-lg-4">
                                <h4><asp:Label ID="BussinessTypeBrName" runat="server" style="color:#0094ff;font-size:20px" > Details </asp:Label><span>
                                    <%--<asp:Literal ID="lblName" runat="server" Text='<%# Eval("Title") %>'></asp:Literal>--%>
                                </span></h4>
                                <hr />
                            </div>
                            <div class="col-md-4 col-sm-4 col-lg-4 pull-right filterBox">
                            </div>
                        </div>

                        <div class="row">

                            <asp:ListView ID="lvAllFeatures" runat="server" DataKeyNames="IID" OnPagePropertiesChanging="lvAllFeatures_PagePropertiesChanging">

                                <ItemTemplate>
                                    <div class="productRowWrp">
                                        <div class="productRow">
                                            <p style="color:#0094ff;font-size:16px">
                                                <asp:Literal ID="lblTitleName" runat="server" Text=' <%# Eval("TitleName") %>'></asp:Literal>
                                            </p>
                                            <hr />
                                            <div class="col-xs-3">
                                                <div class="thumbnail productimg2">

                                                    <asp:Image ID="img_inner" runat="server" Width="240" Height="200" ImageUrl='<%# Eval("ImageUrl")%>' AlternateText="img" />

                                                </div>
                                            </div>
                                            <hr />
                                            <div class="col-xs-9 productDetails">
                                                <p>
                                                    <asp:Label ID="lblDescription" runat="server" Text='<%# Eval("Description") %>'></asp:Label>
                                                </p>

                                                <div class="productPostDate">
                                                </div>

                                            </div>
                                            <%--                    <asp:Repeater ID="childRepeater" runat="server"
                                                EnableViewState="False">
                                                <HeaderTemplate>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <div class="col-xs-3">
                                                        <div class="productDetails" style="text-decoration:underline">

                                                            <asp:Label ID="lblBussinessBrID" runat="server" Text='<%# Eval("BusinessTypeBreakdownName")%>' AlternateText="img" />

                                                        </div>
                                                    </div>
                                                     <div class="col-xs-3">
                                                        <div class="productDetails">

                                                            <asp:Label ID="lblBussinessype" runat="server" Text='<%# Eval("TitleName")%>' AlternateText="img" />

                                                        </div>
                                                    </div>
                                                    <div class="col-xs-3">
                                                        <div class="thumbnail productimg2">

                                                            <asp:Image ID="img_inner" runat="server" Width="100px" Height="100px" ImageUrl='<%# Eval("ImageUrl")%>' AlternateText="img" />

                                                        </div>
                                                    </div>
                                                    <div class="col-xs-9 productDetails">

                                                        <p>
                                                            <asp:Label ID="lblDescription" runat="server" Text='<%# Eval("Description") %>'></asp:Label>
                                                        </p>

                                                        <div class="productPostDate">
                                                        </div>

                                                    </div>
                                                    <div class="clearfix"></div>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                </FooterTemplate>
                                            </asp:Repeater>--%>
                                        </div>
                                    </div>
                                    <hr />
                                </ItemTemplate>


                            </asp:ListView>

                            <%--<div class="paginationPart">

                                <asp:DataPager ID="dataPagerAllFeature" runat="server" PagedControlID="lvAllFeatures" PageSize="10" OnPreRender="dataPagerAllFeature_PreRender">
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
                            </div>--%>
                        </div>

                    </div>

                </div>

                <div class="clearfix">
                </div>
            </div>
        </div>
    </div>
</asp:Content>
