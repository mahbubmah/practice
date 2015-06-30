<%@ Page Title="" Language="C#" MasterPageFile="~/OiiOMasterPage.Master" AutoEventWireup="true" CodeBehind="GuideLineMoreDetails.aspx.cs" Inherits="OMart.Web.GuideLineMoreDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="well searchPanel3">
            <div class="panel-body">
                <div class="tab-content">
                    <div class="tab-pane fade in active" id="tab1default">

                        <div class="row panelBodyTop">
                            <div class="col-md-4 col-sm-4 col-lg-4">
                                <h4>All Guides on <span>
                                    <asp:Literal ID="lblName" runat="server" Text='<%# Eval("Title") %>'></asp:Literal>
                                </span></h4>
                                <hr />
                            </div>
                            <div class="col-md-4 col-sm-4 col-lg-4 pull-right filterBox">
                            </div>
                        </div>

                        <div class="row">

                            <asp:ListView ID="lvAllGuides" runat="server" DataKeyNames="IID" OnPreRender="dataPagerAllGuides_PreRender">

                                <ItemTemplate>
                                    <div class="productRowWrp">
                                        <div class="productRow">
                                            <asp:Literal ID="lblGuideLineTypeName" runat="server" Text=' <%# Eval("Title") %>'></asp:Literal>
                                            <div class="col-xs-3">
                                                <div class="thumbnail productimg2">

                                                    <asp:Image ID="img_inner" runat="server" ImageUrl='<%# Eval("ImageUrl")%>' AlternateText="img" />

                                                </div>
                                            </div>
                                            <div class="col-xs-9 productDetails">

                                                <p>
                                                    <asp:Label ID="lblGuideTypeDescription" runat="server" Text='<%# Eval("Description") %>'></asp:Label>
                                                </p>

                                                <div class="productPostDate">
                                                </div>

                                            </div>
                                            <div class="clearfix"></div>
                                        </div>
                                    </div>
                                    <hr />
                                </ItemTemplate>
                                <EmptyDataTemplate>
                                    Information is Empty...
                                </EmptyDataTemplate>
                            </asp:ListView>

                            <div class="paginationPart">

                                <%--                               <asp:DataPager ID="dataPagerAllGuides" runat="server" PagedControlID="lvAllGuides" OnPagePropertiesChanging="lvAllGuides_PagePropertiesChanging"
                                    PageSize="10" OnPreRender="dataPagerAllGuides_PreRender">
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
                            </div>
                        </div>

                    </div>

                </div>

                <div class="clearfix">
                </div>
            </div>
        </div>
    </div>
</asp:Content>
