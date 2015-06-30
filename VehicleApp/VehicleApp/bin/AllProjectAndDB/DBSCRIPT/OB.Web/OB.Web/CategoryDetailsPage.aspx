<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageInnerBest.Master" AutoEventWireup="true" CodeBehind="CategoryDetailsPage.aspx.cs" Inherits="OB.Web.CategoryDetailsPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderNews" runat="server">
    
    <div class="ContentArea commonH3titel compotationPage">
        <div class="row">
        <div class="col-md-12">
            <br/>
            <h3 style="color:green;">Category Type(Art & Music)</h3>
              <br/>
            <p>
                Show on page:   
                    <asp:LinkButton runat="server" ID="LinkButton2"> All items || 10 items|| 20 items ||50 items || 100 items </asp:LinkButton>
            </p>
        </div>
    </div>
        <div class="row">
            <div class="col-md-12">
                <p>
                    Showing 1 - 20 of 96 results
                    <asp:LinkButton runat="server" CssClass="pull-right" ID="pagination">« prev 1 2 3 4 5 next »</asp:LinkButton>

                </p>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <div class="panel with-nav-tabs panel-success pnlTab">
                    <%-- <div class="panel-heading">
                        <ul class="nav nav-tabs linkitem tabCompotition">
                            <li class="active"><a href="#tab1success" data-toggle="tab">Best Sellers</a></li>
                            <li><a href="#tab2success" data-toggle="tab">Best Offers</a></li>
                            <li><a href="#tab3success" data-toggle="tab">Best Authors</a></li>
                        </ul>
                    </div>--%>
                    <div class="panel-body">
                        <div class="tab-content">
                            <div class="tab-pane fade in active" id="tab1success">
                                <div class="row">
                                    <div class="col-md-8">
                                        <p>
                                            Sort by:    Most Recent
                                            <asp:LinkButton runat="server" ID="booktitle"> Title (A-Z)</asp:LinkButton>
                                            <asp:LinkButton runat="server" ID="bookAuthor">Author (A-Z)</asp:LinkButton>

                                        </p>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="btn-group pull-right">
                                            <a href="#" id="grid" class="glGrid  btn btn-default btn-sm"><span class="glyphicon glyphicon-th"></span>Grid</a> <a href="#" id="list" class="glList btn btn-default btn-sm"><span
                                                class="glyphicon glyphicon-th-list"></span>List</a>
                                        </div>
                                    </div>
                                </div>
                                <div id="products" class="row list-group glProducts">
                                    <div class="item  col-xs-4 col-md-4 col-lg-4">
                                        <div class="bookBox">
                                            <h4>
                                                <span>Open</span> the Book</h4>
                                            <div class="thumbnail">
                                                <a href="<%=this.ResolveUrl("~/BookDetails.aspx?Type=BookDetails") %>">
                                                    <img class="group list-group-image" src="images/interfaces/54.jpg" alt="Slide11" />
                                                </a>
                                                <h3>Charlotte Street</h3>
                                                <p>
                                                    Danny Wallace
                                                </p>
                                                <p>
                                                    Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem
                                                    Ipsum has....
                                                </p>
                                                <p>
                                                    <a class="readMore12" href="#">Read More</a>
                                                </p>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="item  col-xs-4 col-md-4 col-lg-4">
                                        <div class="bookBox">
                                            <h4>
                                                <span>Open</span> the Book</h4>
                                            <div class="thumbnail">
                                                <a href="<%=this.ResolveUrl("~/BookDetails.aspx?Type=BookDetails") %>">
                                                    <img class="group list-group-image" src="images/interfaces/55.jpg" alt="Slide11" />
                                                </a>
                                                <h3>Charlotte Street</h3>
                                                <p>
                                                    Danny Wallace
                                                </p>
                                                <p>
                                                    Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem
                                                    Ipsum has....
                                                </p>
                                                <p>
                                                    <a class="readMore12" href="#">Read More</a>
                                                </p>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="item  col-xs-4 col-md-4 col-lg-4">
                                        <div class="bookBox">
                                            <h4>
                                                <span>Open</span> the Book</h4>
                                            <div class="thumbnail">
                                                <a href="<%=this.ResolveUrl("~/BookDetails.aspx?Type=BookDetails") %>">
                                                    <img class="group list-group-image" src="images/interfaces/56.jpg" alt="Slide11" />
                                                </a>
                                                <h3>Charlotte Street</h3>
                                                <p>
                                                    Danny Wallace
                                                </p>
                                                <p>
                                                    Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem
                                                    Ipsum has....
                                                </p>
                                                <p>
                                                    <a class="readMore12" href="#">Read More</a>
                                                </p>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="item  col-xs-4 col-md-4 col-lg-4">
                                        <div class="bookBox">
                                            <h4>
                                                <span>Open</span> the Book</h4>
                                            <div class="thumbnail">
                                                <a href="<%=this.ResolveUrl("~/BookDetails.aspx?Type=BookDetails") %>">
                                                    <img class="group list-group-image" src="images/interfaces/54.jpg" alt="Slide11" />
                                                </a>
                                                <h3>Charlotte Street</h3>
                                                <p>
                                                    Danny Wallace
                                                </p>
                                                <p>
                                                    Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem
                                                    Ipsum has....
                                                </p>
                                                <p>
                                                    <a class="readMore12" href="#">Read More</a>
                                                </p>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="item  col-xs-4 col-md-4 col-lg-4">
                                        <div class="bookBox">
                                            <h4>
                                                <span>Open</span> the Book</h4>
                                            <div class="thumbnail">
                                                <a href="<%=this.ResolveUrl("~/BookDetails.aspx?Type=BookDetails") %>">
                                                    <img class="group list-group-image" src="images/interfaces/55.jpg" alt="Slide11" />
                                                </a>
                                                <h3>Charlotte Street</h3>
                                                <p>
                                                    Danny Wallace
                                                </p>
                                                <p>
                                                    Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem
                                                    Ipsum has....
                                                </p>
                                                <p>
                                                    <a class="readMore12" href="#">Read More</a>
                                                </p>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="item  col-xs-4 col-md-4 col-lg-4">
                                        <div class="bookBox">
                                            <h4>
                                                <span>Open</span> the Book</h4>
                                            <div class="thumbnail">
                                                <a href="<%=this.ResolveUrl("~/BookDetails.aspx?Type=BookDetails") %>">
                                                    <img class="group list-group-image" src="images/interfaces/56.jpg" alt="Slide11" />
                                                </a>
                                                <h3>Charlotte Street</h3>
                                                <p>
                                                    Danny Wallace
                                                </p>
                                                <p>
                                                    Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem
                                                    Ipsum has....
                                                </p>
                                                <p>
                                                    <a class="readMore12" href="#">Read More</a>
                                                </p>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="tab-pane fade" id="tab2success">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="btn-group pull-right">
                                            <a href="#" id="A1" class="glGrid  btn btn-default btn-sm"><span class="glyphicon glyphicon-th"></span>Grid</a> <a href="#" id="A2" class="glList btn btn-default btn-sm"><span class="glyphicon glyphicon-th-list"></span>List</a>
                                        </div>
                                    </div>
                                </div>
                                <div id="Div1" class="row list-group glProducts">
                                    <div class="item  col-xs-4 col-md-4 col-lg-4">
                                        <div class="bookBox">
                                            <h4>
                                                <span>Open</span> the Book</h4>
                                            <div class="thumbnail">
                                                <a href="<%=this.ResolveUrl("~/BookDetails.aspx?Type=BookDetails") %>">
                                                    <img class="group list-group-image" src="images/interfaces/54.jpg" alt="Slide11" />
                                                </a>
                                                <h3>Charlotte Street</h3>
                                                <p>
                                                    Danny Wallace
                                                </p>
                                                <p>
                                                    Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem
                                                    Ipsum has....
                                                </p>
                                                <p>
                                                    <a class="readMore12" href="#">Read More</a>
                                                </p>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="item  col-xs-4 col-md-4 col-lg-4">
                                        <div class="bookBox">
                                            <h4>
                                                <span>Open</span> the Book</h4>
                                            <div class="thumbnail">
                                                <a href="<%=this.ResolveUrl("~/BookDetails.aspx?Type=BookDetails") %>">
                                                    <img class="group list-group-image" src="images/interfaces/55.jpg" alt="Slide11" />
                                                </a>
                                                <h3>Charlotte Street</h3>
                                                <p>
                                                    Danny Wallace
                                                </p>
                                                <p>
                                                    Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem
                                                    Ipsum has....
                                                </p>
                                                <p>
                                                    <a class="readMore12" href="#">Read More</a>
                                                </p>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="item  col-xs-4 col-md-4 col-lg-4">
                                        <div class="bookBox">
                                            <h4>
                                                <span>Open</span> the Book</h4>
                                            <div class="thumbnail">
                                                <a href="<%=this.ResolveUrl("~/BookDetails.aspx?Type=BookDetails") %>">
                                                    <img class="group list-group-image" src="images/interfaces/56.jpg" alt="Slide11" />
                                                </a>
                                                <h3>Charlotte Street</h3>
                                                <p>
                                                    Danny Wallace
                                                </p>
                                                <p>
                                                    Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem
                                                    Ipsum has....
                                                </p>
                                                <p>
                                                    <a class="readMore12" href="#">Read More</a>
                                                </p>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="item  col-xs-4 col-md-4 col-lg-4">
                                        <div class="bookBox">
                                            <h4>
                                                <span>Open</span> the Book</h4>
                                            <div class="thumbnail">
                                                <a href="<%=this.ResolveUrl("~/BookDetails.aspx?Type=BookDetails") %>">
                                                    <img class="group list-group-image" src="images/interfaces/54.jpg" alt="Slide11" />
                                                </a>
                                                <h3>Charlotte Street</h3>
                                                <p>
                                                    Danny Wallace
                                                </p>
                                                <p>
                                                    Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem
                                                    Ipsum has....
                                                </p>
                                                <p>
                                                    <a class="readMore12" href="#">Read More</a>
                                                </p>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="item  col-xs-4 col-md-4 col-lg-4">
                                        <div class="bookBox">
                                            <h4>
                                                <span>Open</span> the Book</h4>
                                            <div class="thumbnail">
                                                <a href="<%=this.ResolveUrl("~/BookDetails.aspx?Type=BookDetails") %>">
                                                    <img class="group list-group-image" src="images/interfaces/55.jpg" alt="Slide11" />
                                                </a>
                                                <h3>Charlotte Street</h3>
                                                <p>
                                                    Danny Wallace
                                                </p>
                                                <p>
                                                    Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem
                                                    Ipsum has....
                                                </p>
                                                <p>
                                                    <a class="readMore12" href="#">Read More</a>
                                                </p>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="item  col-xs-4 col-md-4 col-lg-4">
                                        <div class="bookBox">
                                            <h4>
                                                <span>Open</span> the Book</h4>
                                            <div class="thumbnail">
                                                <a href="<%=this.ResolveUrl("~/BookDetails.aspx?Type=BookDetails") %>">
                                                    <img class="group list-group-image" src="images/interfaces/56.jpg" alt="Slide11" />
                                                </a>
                                                <h3>Charlotte Street</h3>
                                                <p>
                                                    Danny Wallace
                                                </p>
                                                <p>
                                                    Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem
                                                    Ipsum has....
                                                </p>
                                                <p>
                                                    <a class="readMore12" href="#">Read More</a>
                                                </p>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="tab-pane fade" id="tab3success">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="btn-group pull-right">
                                            <a href="#" id="A3" class="glGrid  btn btn-default btn-sm"><span class="glyphicon glyphicon-th"></span>Grid</a> <a href="#" id="A4" class="glList btn btn-default btn-sm"><span class="glyphicon glyphicon-th-list"></span>List</a>
                                        </div>
                                    </div>
                                </div>
                                <div id="Div2" class="row list-group glProducts">
                                    <div class="item  col-xs-4 col-md-4 col-lg-4">
                                        <div class="bookBox">
                                            <h4>
                                                <span>Open</span> the Book</h4>
                                            <div class="thumbnail">
                                                <a href="<%=this.ResolveUrl("~/BookDetails.aspx?Type=BookDetails") %>">
                                                    <img class="group list-group-image" src="images/interfaces/54.jpg" alt="Slide11" />
                                                </a>
                                                <h3>Charlotte Street</h3>
                                                <p>
                                                    Danny Wallace
                                                </p>
                                                <p>
                                                    Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem
                                                    Ipsum has....
                                                </p>
                                                <p>
                                                    <a class="readMore12" href="#">Read More</a>
                                                </p>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="item  col-xs-4 col-md-4 col-lg-4">
                                        <div class="bookBox">
                                            <h4>
                                                <span>Open</span> the Book</h4>
                                            <div class="thumbnail">
                                                <a href="<%=this.ResolveUrl("~/BookDetails.aspx?Type=BookDetails") %>">
                                                    <img class="group list-group-image" src="images/interfaces/55.jpg" alt="Slide11" />
                                                </a>
                                                <h3>Charlotte Street</h3>
                                                <p>
                                                    Danny Wallace
                                                </p>
                                                <p>
                                                    Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem
                                                    Ipsum has....
                                                </p>
                                                <p>
                                                    <a class="readMore12" href="#">Read More</a>
                                                </p>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="item  col-xs-4 col-md-4 col-lg-4">
                                        <div class="bookBox">
                                            <h4>
                                                <span>Open</span> the Book</h4>
                                            <div class="thumbnail">
                                                <a href="<%=this.ResolveUrl("~/BookDetails.aspx?Type=BookDetails") %>">
                                                    <img class="group list-group-image" src="images/interfaces/56.jpg" alt="Slide11" />
                                                </a>
                                                <h3>Charlotte Street</h3>
                                                <p>
                                                    Danny Wallace
                                                </p>
                                                <p>
                                                    Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem
                                                    Ipsum has....
                                                </p>
                                                <p>
                                                    <a class="readMore12" href="#">Read More</a>
                                                </p>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="item  col-xs-4 col-md-4 col-lg-4">
                                        <div class="bookBox">
                                            <h4>
                                                <span>Open</span> the Book</h4>
                                            <div class="thumbnail">
                                                <a href="<%=this.ResolveUrl("~/BookDetails.aspx?Type=BookDetails") %>">
                                                    <img class="group list-group-image" src="images/interfaces/54.jpg" alt="Slide11" />
                                                </a>
                                                <h3>Charlotte Street</h3>
                                                <p>
                                                    Danny Wallace
                                                </p>
                                                <p>
                                                    Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem
                                                    Ipsum has....
                                                </p>
                                                <p>
                                                    <a class="readMore12" href="#">Read More</a>
                                                </p>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="item  col-xs-4 col-md-4 col-lg-4">
                                        <div class="bookBox">
                                            <h4>
                                                <span>Open</span> the Book</h4>
                                            <div class="thumbnail">
                                                <a href="<%=this.ResolveUrl("~/BookDetails.aspx?Type=BookDetails") %>">
                                                    <img class="group list-group-image" src="images/interfaces/55.jpg" alt="Slide11" />
                                                </a>
                                                <h3>Charlotte Street</h3>
                                                <p>
                                                    Danny Wallace
                                                </p>
                                                <p>
                                                    Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem
                                                    Ipsum has....
                                                </p>
                                                <p>
                                                    <a class="readMore12" href="#">Read More</a>
                                                </p>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="item  col-xs-4 col-md-4 col-lg-4">
                                        <div class="bookBox">
                                            <h4>
                                                <span>Open</span> the Book</h4>
                                            <div class="thumbnail">
                                                <a href="<%=this.ResolveUrl("~/BookDetails.aspx?Type=BookDetails") %>">
                                                    <img class="group list-group-image" src="images/interfaces/56.jpg" alt="Slide11" />
                                                </a>
                                                <h3>Charlotte Street</h3>
                                                <p>
                                                    Danny Wallace
                                                </p>
                                                <p>
                                                    Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem
                                                    Ipsum has....
                                                </p>
                                                <p>
                                                    <a class="readMore12" href="#">Read More</a>
                                                </p>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-md-12">
                <p>
                    Showing 1 - 20 of 96 results
                    <asp:LinkButton runat="server" CssClass="pull-right" ID="LinkButton1">« prev 1 2 3 4 5 next »</asp:LinkButton>

                </p>
            </div>
        </div>
    </div>
</asp:Content>
