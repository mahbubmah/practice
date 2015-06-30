<%@ Page Title="" Language="C#" MasterPageFile="~/OiiOMasterPage.Master" AutoEventWireup="true" CodeBehind="AllCommunityNewsDetails.aspx.cs" Inherits="OMart.Web.AllCommunityNewsDetails" %>

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
                                <asp:Literal ID="ltrType" runat="server"></asp:Literal>

                            </h3>

                            <h5>
                                <asp:Literal ID="ltrTitle" runat="server"></asp:Literal>
                            </h5>

                            <h6>
                                <asp:Literal ID="ltrDes" runat="server"></asp:Literal>
                            </h6>
                            <p class="datePost">
                                Updated On:
                                <asp:Literal ID="ltrDate" runat="server"></asp:Literal>

                            </p>
                        </div>
                        <div class="col-md-4 col-sm-4 col-lg-4">
                            <div id="image" class="thumbnail productimg2 ">
                                <asp:Image ID="img_Guide" runat="server" Height="300" Width="400" AlternateText="img" />
                            </div>
                          
                            <%-- <iframe id="video" width="160" height="180" src='<%#Eval("VideoLink")%>'></iframe>--%>
                        </div>
                    </div>
                </div>


                <br />
                <div class="panel-body">
                    <div class="tab-content">
                        <div class="tab-pane fade in active" id="tab1default">

                            <div class="row panelBodyTop">
                                <div class="col-md-4 col-sm-4 col-lg-4">
                                    <h4>All Community News on  <span>
                                        <asp:Literal ID="ltrNewsType" runat="server"></asp:Literal>
                                    </span></h4>
                                    <hr />
                                </div>
                                <div class="col-md-4 col-sm-4 col-lg-4 pull-right filterBox">
                                </div>
                            </div>

                            <div class="row">

                                <asp:ListView ID="lvAllCommunityNews" runat="server" DataKeyNames="IID" OnPreRender="dataPagerAllCommunityNews_PreRender">

                                    <ItemTemplate>
                                        <div class="productRowWrp">
                                            <div class="productRow">
                                                <h4>
                                                    <%--<a runat="server" href='<%#"GuideLineMoreDetails?ID="+Utilities.StringCipher.Encrypt(Eval("IID").ToString()) %>'>
                                                        <asp:Literal ID="lblGuideLineTypeName" runat="server" Text=' <%# Eval("Title") %>'></asp:Literal>
                                                    </a>--%>
                                                    <asp:Literal ID="ltrTitle" runat="server" Text='<%# Eval("Headline") %>'></asp:Literal>
                                                </h4>
                                                <div class="col-xs-3">
                                                    <div class="thumbnail productimg2">

                                                        <asp:Image ID="img_inner" runat="server" Width="100%" ImageUrl='<%# Eval("Image")%>' AlternateText="img" />

                                                    </div>
                                                    <a rel="canonical" href="<%# Eval("VideoLink") %>" target="_blank">
                                                        <p>
                                                            Video Link::
                                                            <%# Eval("VideoLink") %>
                                                        </p>
                                                    </a>
                                                </div>
                                                <div class="col-xs-9 productDetails">

                                                    <p>
                                                        <asp:Literal ID="ltrDes" runat="server" Text='<%# Eval("NewsDescription") %>'></asp:Literal>
                                                    </p>

                                                    <div class="productPostDate">
                                                        <%# Eval("PublishDate","{0:dd-MMM-yyyy}") %>
                                                    </div>

                                                </div>
                                                <%--    <iframe id="frmVideo" class="pull-right" width="120" height="80" runat="server"></iframe>--%>

                                                <div class="clearfix"></div>
                                            </div>
                                        </div>
                                        <hr />
                                    </ItemTemplate>

                                    <AlternatingItemTemplate>

                                        <div class="productRowWrp">
                                            <div class="productRow">

                                                <h4>
                                                    <%--<a runat="server" href='<%#"GuideLineMoreDetails?ID="+Utilities.StringCipher.Encrypt(Eval("IID").ToString()) %>'>
                                                        <asp:Literal ID="lblGuideLineTypeName" runat="server" Text=' <%# Eval("Title") %>'></asp:Literal>
                                                    </a>--%>
                                                    <asp:Literal ID="ltrTitle" runat="server" Text='<%# Eval("Headline") %>'></asp:Literal>
                                                </h4>

                                                <div class="col-xs-3">
                                                    <div class="thumbnail productimg2">

                                                        <asp:Image ID="img_inner" runat="server" Width="100%" ImageUrl='<%# Eval("Image")%>' AlternateText="img" />

                                                    </div>
                                                       <a rel="canonical" href="<%# Eval("VideoLink") %>" target="_blank">
                                                        <p>
                                                            Video Link::
                                                            <%# Eval("VideoLink") %>
                                                        </p>
                                                    </a>
                                                </div>
                                                <div class="col-xs-9 productDetails">

                                                    <p>
                                                        <asp:Literal ID="ltrDes" runat="server" Text='<%# Eval("NewsDescription") %>'></asp:Literal>
                                                    </p>

                                                    <div class="productPostDate">
                                                        <%# Eval("PublishDate","{0:dd-MMM-yyyy}") %>
                                                    </div>

                                                </div>
                                                <%--  <iframe id="frmVideo" class="pull-right" width="120" height="80" runat="server"></iframe>--%>

                                                <div class="clearfix"></div>
                                            </div>
                                        </div>
                                        <hr />
                                    </AlternatingItemTemplate>

                                </asp:ListView>

                                <div class="paginationPart">

                                    <asp:DataPager ID="dataPagerAllCommunityNews" runat="server" PagedControlID="lvAllCommunityNews" OnPagePropertiesChanging="lvAllCommunityNews_PagePropertiesChanging"
                                        PageSize="10" OnPreRender="dataPagerAllCommunityNews_PreRender">
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
