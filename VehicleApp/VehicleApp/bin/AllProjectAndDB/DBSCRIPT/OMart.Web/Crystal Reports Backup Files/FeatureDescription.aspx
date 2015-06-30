<%@ Page Title="" Language="C#" MasterPageFile="~/OiiOMasterPage.Master" AutoEventWireup="true" CodeBehind="FeatureDescription.aspx.cs" Inherits="OMart.Web.FeatureDescription" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
        <div class="container">
            <div class="well searchPanel3">

                <div class="row panelBodyTop">
                    <div class="col-md-12 col-sm-12 col-lg-12">
                        <div class="col-md-8 col-sm-8 col-lg-8">
                            <h3>
                                <asp:Literal ID="ltrtype" runat="server" Text=''></asp:Literal>
                            </h3>

                            <h5>
                                <asp:Literal ID="ltrTitle" runat="server" Text=''></asp:Literal>
                            </h5>

                            <h6>
                                <asp:Literal ID="ltrDes" runat="server" Text=''></asp:Literal>
                            </h6>
                        </div>
                        <div class="col-md-4 col-sm-4 col-lg-4">
                            <div class="thumbnail productimg2 ">
                                <asp:Image ID="img_Feature" runat="server" Height="300" Width="400"  AlternateText="img" />
                            </div>
                        </div>
                    </div>
                </div>


                <br />
                <div class="panel-body">
                    <div class="tab-content">
                        <div class="tab-pane fade in active" id="tab1default">

                            <div class="row panelBodyTop">
                                <div class="col-md-4 col-sm-4 col-lg-4">
                                    <h4>All Feature Details on <span>
                                        <asp:Literal ID="lblTypeName" runat="server" Text='<%# Eval("BussinessTypeName") %>'></asp:Literal>
                                    </span></h4>
                                    <hr />
                                </div>
                                <div class="col-md-4 col-sm-4 col-lg-4 pull-right filterBox">
                                </div>
                            </div>

                            <div class="row">

                                <asp:ListView ID="lvAllFeature" runat="server" DataKeyNames="IID">

                                    <ItemTemplate>
                                        <div class="productRowWrp">
                                            <div class="productRow">
                                                <h4>
                                                    <a runat="server" href='<%#"AllFeatureMoreDetails?ID="+Utilities.StringCipher.Encrypt(Eval("IID").ToString()) %>'>
                                                        <asp:Literal ID="lblTitleName" runat="server" Text=' <%# Eval("BusinessTypeBreakdownName") %>'></asp:Literal>
                                                    </a>
                                                </h4>
                                                <h4>
                                                    
                                                        <asp:Literal ID="Literal1" runat="server" Text=' <%# Eval("TitleName") %>'></asp:Literal>
                                                </h4>
                                                <div class="col-xs-3">
                                                    <div class="thumbnail productimg2">

                                                        <asp:Image ID="img_inner" runat="server" Width="245" Height="200" ImageUrl='<%# Eval("ImageUrl")%>' AlternateText="img" />

                                                    </div>
                                                </div>
                                                <div class="col-xs-9 productDetails">

                                                    <p>
                                                        <asp:Label ID="lblFeatureTypeDescription" runat="server" Text='<%# Eval("Description") %>'></asp:Label>
                                                    </p>

                                                    <div class="productPostDate">
                                                    </div>

                                                </div>
                                                <div class="clearfix"></div>
                                            </div>
                                        </div>
                                        <hr />
                                    </ItemTemplate>

                                    <%--<AlternatingItemTemplate>

                                        <div class="productRowWrp">
                                            <div class="productRow">

                                                <a runat="server" href='<%#"AllFeatureMoreDetails?ID="+Eval("IID") %>'>
                                                    <h4>
                                                        <asp:Literal ID="lblGuideLineTypeName" runat="server" Text=' <%# Eval("TitleName") %>'></asp:Literal>
                                                    </h4>
                                                </a>

                                                <div class="col-xs-3">
                                                    <div class="thumbnail productimg2">

                                                        <asp:Image ID="img_inner" runat="server" Width="100%" ImageUrl='<%# Eval("ImageUrl")%>' AlternateText="img" />

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
                                    </AlternatingItemTemplate>--%>

                                </asp:ListView>

                                <div class="paginationPart">

                                    <asp:DataPager ID="dataPagerAllGuides" runat="server" PagedControlID="lvAllFeature" PageSize="10" >
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
</asp:Content>
