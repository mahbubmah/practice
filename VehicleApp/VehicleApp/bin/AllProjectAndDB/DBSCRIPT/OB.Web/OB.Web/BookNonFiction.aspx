<%@ Page Title="" Language="C#" MasterPageFile="~/OiiOInnerMasterPage.Master" AutoEventWireup="true" CodeBehind="BookNonFiction.aspx.cs" Inherits="OB.Web.BookNonFiction" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderInnerPage" runat="Server">


    <div class="ContentArea commonH3titel">
        <div class="row">
            <div class="contArea">
                <h3><asp:Literal ID="ltrFictionTypeName" runat="server"></asp:Literal></h3>
                <p>
                    <asp:Literal ID="ltrDes" runat="server" Text=' <%# Eval("CategoryDescription") %>'></asp:Literal>
                </p>
                <p><a class=" btn btn-success pull-right" href="<%=this.ResolveUrl("~/BookInnerDetails.aspx?Type="+Convert.ToInt32 (OB.Utilities.EnumCollection.ParentCategory.Non_Fiction)) %>">View all Non-Fiction</a></p>
            </div> 
        </div>
        <div class="row">
            <h3>Recommended Reading</h3>
            <p>Books you'll love</p>
            <div class="bookBoxWrp">
                <div class="row">
                    <asp:Repeater ID="rpNonFictionBook" runat="server" OnItemDataBound="rpNonFictionBook_OnItemDataBound">
                        <ItemTemplate>
                            <div class="col-xs-4 col-sm-4 col-md-4  col-lg-4">
                                <div class="bookBox">
                                    <h4><span>Open</span> the Book</h4>
                                    <div class="thumbnail">
                                       <%-- <a href="<%=this.ResolveUrl("~/BookDetails.aspx?Type=BookDetails") %>">--%>
                                         <a runat="server" href='<%#"BookDetails?ID="+Eval("IID") %>'>
                                            <asp:Image runat="server" ID="img_Book" Class="img-responsive" ImageUrl='<%# Eval("ImageUrl") %>' alt="Image" />


                                            <h3>
                                                <asp:Literal ID="ltrBookTitle" runat="server" Text=' <%# Eval("BookTitle") %>'></asp:Literal></h3>

                                        </a>
                                        <p>
                                              <a href="AuthBiographyPage?ID=<%# Eval("AuthorID") %>">
                                            <asp:Literal ID="ltrAuthorName" runat="server" Text=' <%# Eval("AuthorName") %>'></asp:Literal>
                                      </a>
                                                   </p>

                                    </div>
                                </div>
                            </div>

                        </ItemTemplate>
                    </asp:Repeater>

                </div>
                <div class="row">
                    <div class="col-sm-12">
                        <h3>Latest Releases</h3>
                        <p>Published in the last 90 days</p>
                    </div>
                    <asp:Repeater ID="rpLatest" runat="server" OnItemDataBound="rpLatest_OnItemDataBound">
                        <ItemTemplate>
                            <div class="col-xs-3 col-sm-3 col-md-3  col-lg-3">

                                <div class="bookBox">
                                    <div class="thumbnail">
                                    <%--    <a href="<%=this.ResolveUrl("~/BookDetails.aspx?ID=") %>">--%>
                                         <a runat="server" href='<%#"BookDetails?ID="+Eval("IID") %>'>
                                            <asp:Image runat="server" ID="img_Book" Class="img-responsive" ImageUrl='<%# Eval("ImageUrl") %>' alt="Image" />


                                            <h3>
                                                <asp:Literal ID="ltrBookTitle" runat="server" Text=' <%# Eval("BookTitle") %>'></asp:Literal></h3>

                                        </a>
                                        <p>
                                              <a href="AuthBiographyPage?ID=<%# Eval("AuthorID") %>">
                                            <asp:Literal ID="ltrAuthorName" runat="server" Text=' <%# Eval("AuthorName") %>'></asp:Literal>
                                      </a>
                                                     </p>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <div class="row authTestimonialWrp">
                    <div class="col-md-12">
                        <h3>Featured Author</h3>
                    </div>
                    <asp:Repeater ID="rpFAuthor" runat="server" OnItemDataBound="rpFAuthor_OnItemDataBound">
                        <ItemTemplate>
                            <div class="col-md-12">
                                <div class="authTestimonial">
                                <a href="AuthBiographyPage?ID=<%# Eval("IID") %>">
                                        <asp:Image runat="server" ID="img_Book" Class="img-responsive" Width="180" Height="190" ImageUrl='<%# Eval("Picture") %>' alt="Image" />

                                        <h4>
                                            <asp:Literal ID="ltrAuthorName" runat="server" Text=' <%# Eval("AuthorName") %>'></asp:Literal></h4>
                                    </a>
                                    <p>
                                        <asp:Literal ID="ltrFavQuote" runat="server" Text=' <%# Eval("FavouriteQuote") %>'></asp:Literal>
                                    </p>
                                    <h4><a href="AuthBiographyPage?ID=<%# Eval("IID") %>" class="btn btn-success pull-right">More about
                                <asp:Literal ID="ltrAuthor" runat="server" Text=' <%# Eval("AuthorName") %>'></asp:Literal>

                                    </a></h4>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>

                </div>
                <br />
                <div class="row">
                    <div class="col-md-12">
                        <h3>Coming Soon</h3>

                        <div class="well bookBoxWrp2">
                            <asp:Repeater ID="rpComingSoon" runat="server" OnItemDataBound="rpComingSoon_OnItemDataBound">
                                <ItemTemplate>
                                    <div class="col-xs-3 col-sm-3 col-md-3  col-lg-3">
                                        <div class="bookBox">
                                            <div class="thumbnail">
                                                <%--  <img class="img-responsive" src="images/interfaces/57.jpg" alt="Slide11" />--%>
                                                <a runat="server" href='<%#"BookDetails?ID="+Eval("IID") %>'>

                                                    <asp:Image runat="server" ID="img_Book" Class="img-responsive" ImageUrl='<%# Eval("ImageUrl") %>' alt="Image" />
                                                </a>

                                            </div>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                            <div class="clearfix"></div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


</asp:Content>
