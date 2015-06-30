

<%@ Page Title="Best books" Language="C#" MasterPageFile="~/MasterPageInnerBest.master"AutoEventWireup="true" CodeBehind="BestBooks.aspx.cs" Inherits="OB.Web.BestBooks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderNews" runat="Server">
    <div class="ContentArea commonH3titel compotationPage">
        <div class="row">
            <div class="col-md-12">
                <div class="panel with-nav-tabs panel-success pnlTab">
                    <div class="panel-heading">
                        <ul class="nav nav-tabs linkitem tabCompotition">
                            <li class="active"><a href="#tabMostFav" data-toggle="tab">Recommended</a></li>
                            <li><a href="#tab2success" data-toggle="tab">Latest</a></li>
                            <li><a href="#tab3success" data-toggle="tab">Coming Soon</a></li>
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
                            <div class="tab-pane fade in active" id="tabMostFav">
                                <div id="products" class="row list-group glProducts">

                                    <asp:Repeater runat="server" ID="rptRecommendedBooks">
                                        <ItemTemplate>
                                            <div class="item  col-xs-4 col-md-4 col-lg-4">
                                                <div class="bookBox">
                                                    <h4>
                                                        <span>Open</span> the Book</h4>
                                                    <div class="thumbnail">
                                                        <a href="BookDetails?ID=<%# Eval("IID") %>">
                                                            <asp:Image runat="server" CssClass="group list-group-image" ImageUrl='<%# Eval("ImageUrl") %>'/>
                                                       
                                                        <h3><%# Eval("BookTitle") %></h3> </a>
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
                            <div class="tab-pane fade" id="tab2success">
                                <div id="Div1" class="row list-group glProducts">
                                    <asp:Repeater runat="server" ID="rptLatestBooks">
                                       <ItemTemplate>
                                            <div class="item  col-xs-4 col-md-4 col-lg-4">
                                                <div class="bookBox">
                                                    <h4>
                                                        <span>Open</span> the Book</h4>
                                                    <div class="thumbnail">
                                                        <a href="BookDetails?ID=<%# Eval("IID") %>">
                                                              <asp:Image runat="server" CssClass="group list-group-image" ImageUrl='<%# Eval("ImageUrl") %>'/>
                                                      
                                                        <h3><%# Eval("BookTitle") %></h3>  </a>
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
                            <div class="tab-pane fade" id="tab3success">
                                <div id="Div2" class="row list-group glProducts">
                                    <asp:Repeater runat="server" ID="rptComingSoonBooks">
                                         <ItemTemplate>
                                            <div class="item  col-xs-4 col-md-4 col-lg-4">
                                                <div class="bookBox">
                                                    <h4>
                                                        <span>Open</span> the Book</h4>
                                                    <div class="thumbnail">
                                                        <a href="BookDetails?ID=<%# Eval("IID") %>">
                                                              <asp:Image runat="server" CssClass="group list-group-image" ImageUrl='<%# Eval("ImageUrl") %>'/>
                                                       
                                                        <h3><%# Eval("BookTitle") %></h3> </a>
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
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

