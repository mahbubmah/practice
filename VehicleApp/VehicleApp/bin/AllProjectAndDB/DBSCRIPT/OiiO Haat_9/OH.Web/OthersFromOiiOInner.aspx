<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultMaster.Master" AutoEventWireup="true" CodeBehind="OthersFromOiiOInner.aspx.cs" Inherits="OH.Web.OthersFromOiiOInner" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="mainBodyWrp">
        <section>
            <div class="container">
                <div class="well searchPanel3">
                    <div class="col-sm-4 col-md-4 col-lg-4">

                        <div class="selectWant">
                        </div>
                    </div>
                    <br />
                    <div class="panel-body">
                        <div class="tab-content">
                            <div class="tab-pane fade in active" id="tab1default">

                                <div class="row panelBodyTop">
                                    <div class="col-md-4 col-sm-4 col-lg-4">
                                        <h4>All Services <span>From OiiO</span></h4>
                                    </div>
                                    <div class="col-md-4 col-sm-4 col-lg-4 pull-right filterBox">
                                    </div>
                                </div>

                                <div class="row">

                                    <asp:ListView ID="lvOthersFormOiiO" runat="server" DataKeyNames="IID" OnPreRender="dataPagerOthersFormOiiO_PreRender">

                                        <ItemTemplate>
                                            <div class="productRowWrp">
                                                <div class="productRow">
                                                    <div>
                                                        <asp:Label ID="lblOthersFormOiiOID" runat="server" Text='<%# Eval("IID") %>' Visible="false"></asp:Label>
                                                    </div>
                                                    <div class="col-xs-3">
                                                        <div class="thumbnail productimg2">
                                                            <a href="<%#"OtherContentDetailPage?option="+OH.Utilities.StringCipher.Encrypt(Eval("IID").ToString()) %>">
                                                                <asp:Image ID="img_inner" runat="server" ImageUrl='<%# Eval("ImageUrl")%>' AlternateText="img" />
                                                            </a>
                                                        </div>
                                                    </div>
                                                    <div class="col-xs-9 productDetails">
                                                        <a href="<%#"OtherContentDetailPage?option="+OH.Utilities.StringCipher.Encrypt(Eval("IID").ToString()) %>">
                                                            <asp:Label ID="lblBrandName" runat="server">  <h5 class="product-name"><%# Eval("Title")%></h5> </asp:Label>
                                                        </a>
                                                        <p>
                                                            <asp:Label ID="lblDescription" runat="server" Text='<%# Eval("ShortDescription") %>'></asp:Label>
                                                        </p>

                                                        <div class="productPostDate">
                                                            <%=Like_Button_Iframe_Count_Button%>
                                                        </div>

                                                    </div>

                                                    <div class="clearfix"></div>
                                                </div>
                                            </div>
                                        </ItemTemplate>
                                        <AlternatingItemTemplate>

                                            <div class="productRowWrp">
                                                <div class="productRow">
                                                    <div>
                                                        <asp:Label ID="lblMaterialID" runat="server" Text='<%# Eval("IID") %>' Visible="false"></asp:Label>
                                                    </div>
                                                    <div class="col-xs-3">
                                                        <div class="thumbnail productimg2">
                                                            <a href="<%#"OtherContentDetailPage?option="+OH.Utilities.StringCipher.Encrypt(Eval("IID").ToString()) %>">
                                                                <asp:Image ID="img_inner" runat="server" ImageUrl='<%# Eval("ImageUrl")%>' AlternateText="img" />
                                                            </a>
                                                        </div>
                                                    </div>
                                                    <div class="col-xs-9 productDetails">
                                                        <a href="<%#"OtherContentDetailPage?option="+OH.Utilities.StringCipher.Encrypt(Eval("IID").ToString()) %>">
                                                            <asp:Label ID="lblBrandName" runat="server">  <h5 class="product-name"><%# Eval("Title")%></h5> </asp:Label>
                                                        </a>
                                                        <p>
                                                            <asp:Label ID="lblDescription" runat="server" Text='<%# Eval("ShortDescription") %>'></asp:Label>
                                                        </p>
                                                        <div class="productPostDate">
                                                            <%=Like_Button_Iframe_Count_Button%>
                                                        </div>
                                                    </div>

                                                    <div class="clearfix"></div>
                                                </div>
                                            </div>

                                        </AlternatingItemTemplate>

                                    </asp:ListView>

                                    <div class="paginationPart">

                                        <asp:DataPager ID="dataPagerOthersFormOiiO" runat="server" PagedControlID="lvOthersFormOiiO" OnPagePropertiesChanging="lvOthersFormOiiO_PagePropertiesChanging"
                                            PageSize="10" OnPreRender="dataPagerOthersFormOiiO_PreRender">
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
                                </div>

                            </div>

                        </div>

                        <div class="clearfix">
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </div>
</asp:Content>
