<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageInnerBest.Master" AutoEventWireup="true" CodeBehind="PublisherDetailPage.aspx.cs" Inherits="OB.Web.PublisherDetailPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderNews" runat="server">
    <div class="ContentArea commonH3titel bookDetailsWrp">

        <div class="row">
            <div class="col-xs-12">
                <div class="bookBox bookDetails">

                    <div class="col-md-12">
                        <h3>
                            <asp:Label runat="server" ID="lbPublisherTitle1"></asp:Label>
                        </h3>
                        <hr />

                        <div class="authTestimonial">
                            <asp:Image runat="server" ID="imgPublisherLogo" CssClass="img-responsive pull-right" Height="190" Width="180" />
                            <p>
                                <a runat="server" class="btn btn-success " href='<%#"BookInnerBest.aspx?ID="+Eval("IID") %>'>View all books from
                                    <asp:Label runat="server" ID="lbPublisherTitle2"></asp:Label>
                                    <asp:Literal ID="ltrAuthor" runat="server" Text=' <%# Eval("PublisherName") %>'></asp:Literal>
                                </a>
                            </p>
                            <p>
                                About Publisher:
                            <asp:Label runat="server" ID="lbAboutPublisher"></asp:Label>

                            </p>
                            <h3>Award Achieved:
                                <asp:Label runat="server" ID="lbPublisherAward"></asp:Label>
                            </h3>
                            <h5><a runat="server" href="#" id="ancPublisherWebSiteLink">
                                <asp:Label runat="server" ID="lbPublisherWebsite"></asp:Label>
                            </a></h5>

                        </div>

                    </div>
                </div>
            </div>


            <div class="bookBoxWrp">

                <div class="row byAuthbookList">
                    <div class="col-sm-12">
                        <h3><span>Latest Releases</span></h3>
                        <h5>
                            <asp:Literal ID="ltrPublisherName" runat="server"></asp:Literal>
                            has published <b><asp:Literal ID="ltrBookCount" runat="server"></asp:Literal></b> books in the last <b>60</b> days
                             <asp:LinkButton ID="linkToBookDetails" class="pull-right" runat="server" OnClick="linkToBookDetails_OnClick">Browse all books of
                                 <asp:Label runat="server" ID="lbPublisherTitle3"></asp:Label>
                             </asp:LinkButton>

                        </h5>


                        <div class="well commonBg1">
                            <div class="row">

                                <asp:Repeater runat="server" ID="rptLatestBooks">
                                    <ItemTemplate>
                                        <div class="col-xs-3 col-sm-3 col-md-3  col-lg-3">
                                            <div class="bookBox">
                                                <h4><span>Open</span> the Book</h4>
                                                <div class="thumbnail">
                                                      <a href="BookDetails?ID=<%# Eval("IID") %>" target="_blank">
                                                        <asp:Image runat="server" ImageUrl='<%# Eval("ImageUrl") %>' CssClass="img-responsive" />
                                                    </a>

                                                </div>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>



                            </div>
                        </div>
                    </div>

                </div>

                <div class="row byAuthbookList">
                    <div class="col-sm-12">
                        <h3><span>Coming Soon</span></h3>
                       <h5>
                            <asp:Literal ID="ltrPublisherName1" runat="server"></asp:Literal>
                            has published <b><asp:Literal ID="ltrBookCount1" runat="server"></asp:Literal></b> books in the last <b>60</b> days
                             <asp:LinkButton ID="linkToBookDetails1" class="pull-right" runat="server" OnClick="linkToBookDetails_OnClick">Browse all books of
                                 <asp:Label runat="server" ID="lbPublisherTitle4"></asp:Label>
                             </asp:LinkButton>

                        </h5>


                        <div class="well commonBg1">
                            <div class="row">
                                    <asp:Repeater runat="server" ID="rptComingSoonBooks">
                                    <ItemTemplate>
                                        <div class="col-xs-3 col-sm-3 col-md-3  col-lg-3">
                                            <div class="bookBox">
                                                <h4><span>Open</span> the Book</h4>
                                                <div class="thumbnail">
                                                    <a href="BookDetails?ID=<%# Eval("IID") %>" target="_blank">
                                                        <asp:Image runat="server" ImageUrl='<%# Eval("ImageUrl") %>' CssClass="img-responsive" />
                                                    </a>

                                                </div>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>


                            </div>
                        </div>
                    </div>

                </div>
                <div class="row authTestimonialWrp">
                    <div class="col-md-12">
                        <h3>Latest News & Videos: </h3>
                        <img class="img-responsive" src="image/Compitition/dota.jpg" alt="Slide11" />
                        <h5>Official Website :: www.dannywalece.com</h5>
                        <h5>published books also available:: (Book Available url) www.dannywalece.com</h5>
                        <p>The OiiO Book is not responsible for the content of external websites</p>
                    </div>


                </div>

            </div>
        </div>
    </div>
</asp:Content>
