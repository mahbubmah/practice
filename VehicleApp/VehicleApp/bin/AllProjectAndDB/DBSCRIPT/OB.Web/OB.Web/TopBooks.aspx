<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPageInnerBest.master" CodeBehind="TopBooks.aspx.cs" Inherits="OB.Web.TopBooks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderNews" runat="Server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="ContentArea commonH3titel compotationPage">
                <div class="row">
                    <div class="col-md-12">
                        <div class="panel with-nav-tabs panel-success pnlTab">
                            <div class="panel-heading">
                                <ul class="nav nav-tabs linkitem tabCompotition">
                                    <li class="active" runat="server" id="liTabMostFav"><a href="#tabMostFavourite" data-toggle="tab">Most Favourite</a></li>
                                    <li runat="server" id="liTabBestOffer"><a href="#tabBestOffers" data-toggle="tab">Best Offers</a></li>
                                    <li runat="server" id="liTabBestAuthors"><a href="#tabBestAuthors" data-toggle="tab">Best Authors</a></li>
                                </ul>
                            </div>
                            <div class="panel-body">
                                <div class="tab-content">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="btn-group pull-right">
                                                <a href="#" id="grid" class="glGrid  btn btn-default btn-sm"><span class="glyphicon glyphicon-th"></span>Grid</a> <a href="#" id="list" class="glList btn btn-default btn-sm"><span
                                                    class="glyphicon glyphicon-th-list"></span>List</a>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="tab-pane fade in active" id="tabMostFavourite">
                                        <div id="products" class="row list-group glProducts">

                                            <asp:Repeater runat="server" ID="rptBestSellerBooks">
                                                <ItemTemplate>
                                                    <div class="item  col-xs-4 col-md-4 col-lg-4">
                                                        <div class="bookBox">
                                                            <h4>
                                                                <span>Open</span> the Book</h4>
                                                            <div class="thumbnail">
                                                                <a href="BookDetails?ID=<%# Eval("IID") %>">
                                                                    <asp:Image runat="server" CssClass="group list-group-image" ImageUrl='<%# Eval("ImageUrl") %>' />

                                                                    <h3><%# Eval("BookTitle") %></h3>
                                                                </a>
                                                                <p>
                                                                    <a href="AuthBiographyPage?ID=<%# Eval("AuthorID") %>">
                                                                        <%# Eval("AuthorName") %>
                                                                    </a>
                                                                </p>
                                                                <p>
                                                                    <%# Eval("Abstract") %>
                                                                </p>
                                                                <p>
                                                                    <a class="readMore12" href="BookDetails?ID=<%# Eval("IID") %>">Read More</a>
                                                                </p>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </div>
                                    </div>
                                    <div class="tab-pane fade" id="tabBestOffers">
                                        <div id="Div1" class="row list-group glProducts">
                                            <asp:Repeater runat="server" ID="rptBestOfferBooks">
                                                <ItemTemplate>
                                                    <div class="item  col-xs-4 col-md-4 col-lg-4">
                                                        <div class="bookBox">
                                                            <h4>
                                                                <span>Open</span> the Book</h4>
                                                            <div class="thumbnail">
                                                                <a href="BookDetails?ID=<%# Eval("IID") %>">
                                                                    <asp:Image runat="server" CssClass="group list-group-image" ImageUrl='<%# Eval("ImageUrl") %>' />

                                                                    <h3><%# Eval("BookTitle") %></h3>
                                                                </a>
                                                                <p>
                                                                    <a href="AuthBiographyPage?ID=<%# Eval("AuthorID") %>">
                                                                        <%# Eval("AuthorName") %>
                                                                    </a>
                                                                </p>
                                                                <p>
                                                                    <%# Eval("Abstract") %>
                                                                </p>
                                                                <p>
                                                                    <a class="readMore12" href="BookDetails?ID=<%# Eval("IID") %>">Read More</a>
                                                                </p>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </div>
                                    </div>
                                    <div class="tab-pane fade" id="tabBestAuthors">
                                        <div id="Div2" class="row list-group glProducts">
                                            <asp:Repeater runat="server" ID="rptBestAuthors">
                                                <ItemTemplate>
                                                    <div class="item  col-xs-4 col-md-4 col-lg-4">
                                                        <div class="bookBox">
                                                            <h4>
                                                                <span>Meet</span> this author</h4>
                                                            <div class="thumbnail">
                                                                <a href="AuthBiographyPage?ID=<%# Eval("IID") %>">
                                                                    <asp:Image runat="server" CssClass="group list-group-image" ImageUrl='<%# Eval("Picture") %>' />

                                                                    <h3><%# Eval("AuthorName") %></h3>
                                                                </a>

                                                                <h5>
                                                                    <%# Eval("CountryName") %>
                                                                </h5>
                                                                <p>
                                                                    <%# Eval("AboutAuthor") %>
                                                                </p>
                                                                <p>
                                                                    <a class="readMore12" target="_blank" href="#">Read More</a>
                                                                </p>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </ItemTemplate>

                                            </asp:Repeater>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
