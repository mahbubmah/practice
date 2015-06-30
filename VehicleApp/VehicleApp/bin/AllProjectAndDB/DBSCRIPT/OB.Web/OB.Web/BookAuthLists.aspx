<%@ Page Title="" Language="C#" MasterPageFile="~/OiiOInnerMasterPage.Master" AutoEventWireup="true" CodeBehind="BookAuthLists.aspx.cs" Inherits="OB.Web.BookAuthLists" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderInnerPage" runat="Server">


    <div class="ContentArea commonH3titel">
        <div class="row">
            <div class="contArea">
                <h3>Authors: A - Z</h3>
                <p>Find the author you're looking for</p>
                <p class="filListCher">
                    <asp:Repeater ID="rpAuthorSearch" runat="server">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkAlphabet" OnClick="lnkAlphabet_Click" CommandArgument='<%# Eval("Alphabet") %>' runat="server" class=" btn btn-success"><%# Eval("Alphabet") %></asp:LinkButton>
                        </ItemTemplate>
                    </asp:Repeater>
                </p>
            </div>
        </div>


        <div class="row">
            <asp:Panel ID="pnlAuthorSearchResult" runat="server">
                <div class="bookBoxWrp">

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
                                        <a rel="canonical" href="http://<%# Eval("WebsiteLink") %>" target="_blank">
                                            <p>
                                                <%# Eval("WebsiteLink") %>
                                            </p>
                                        </a>
                                        <h4><a runat="server" class="btn btn-success pull-right" href='<%#"AuthBiographyPage.aspx?ID="+Eval("IID") %>'>More about
                                <asp:Literal ID="ltrAuthor" runat="server" Text=' <%# Eval("AuthorName") %>'></asp:Literal>

                                        </a></h4>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>

                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <h3>Authors publishing this month</h3>

                            <div class="well bookBoxWrp2">

                                <asp:Repeater ID="rpBookPublishThisMonth" runat="server">
                                    <ItemTemplate>
                                        <div class="col-xs-4 col-sm-4 col-md-4  col-lg-4">
                                            <div class="bookBox">
                                               <%-- <h4 style="text-align: left;"><span>Meet</span> the Author</h4>--%>
                                                <a href='<%#"AuthBiographyPage.aspx?ID="+Eval("IID") %>'>
                                                    <div class="thumbnail">
                                                        <asp:Image runat="server" ID="img_Book" Class="img-responsive" Width="150" Height="160" ImageUrl='<%# Eval("Picture") %>' alt="Image" />
                                                    </div>

                                                    <asp:Literal ID="ltrAuthorName" runat="server" Text=' <%# Eval("AuthorName") %>'></asp:Literal>
                                                </a>
                                            </div>
                                        </div>
                                    </ItemTemplate>

                                </asp:Repeater>

                                <div class="clearfix"></div>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>
        </div>
        <asp:Panel ID="pnlSearchedAuthor" runat="server">
            <div class="bookBoxWrp">

                <div class="row authTestimonialWrp">

                    <h3>View All Authors </h3>

                    <asp:Repeater ID="rpAllAuthor" runat="server" OnItemDataBound="rpAllAuthor_OnItemDataBound">
                        <ItemTemplate>
                            <div class="col-md-12">
                                <div class="authTestimonial">
                                    <div class="col-md-4">
                                        <div class="bookBox">
                                            <h4 style="text-align: left;"><span>Meet</span> the Author</h4>
                                            <div class="thumbnail">
                                                <a runat="server" href='<%#"AuthBiographyPage?ID="+Eval("IID") %>'>
                                                    <asp:Image runat="server" ID="img_Author" Class="img-responsive" Width="180" Height="190" Style="text-align: left;" ImageUrl='<%# Eval("Picture") %>' alt="Image" />


                                                </a>
                                            </div>
                                        </div>
                                        <p style="padding-right: 1px;">
                                            <a rel="canonical" href="http://<%# Eval("WebsiteLink") %>" target="_blank">
                                                <p>
                                                    <%# Eval("WebsiteLink") %>
                                                </p>
                                            </a>
                                        </p>
                                    </div>
                                    <div class="col-md-8">
                                        <p>
                                            <a runat="server" href='<%#"AuthBiographyPage?ID="+Eval("IID") %>'>&nbsp;
                                           <h3>
                                               <asp:Literal ID="ltrAuthorName" runat="server" Text=' <%# Eval("AuthorName") %>'></asp:Literal></h3>
                                            </a>
                                        </p>
                                        <p>
                                            &nbsp;  &nbsp; 
                                        <asp:Literal ID="ltrAbout" runat="server" Text=' <%# Eval("AboutAuthor") %>'></asp:Literal>
                                        </p>


                                    </div>

                                </div>

                                <a runat="server" class="btn btn-success pull-right" href='<%#"AuthBiographyPage.aspx?ID="+Eval("IID") %>'>More about
                                <asp:Literal ID="ltrAuthor" runat="server" Text=' <%# Eval("AuthorName") %>'></asp:Literal>

                                </a>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>

                </div>

            </div>
        </asp:Panel>

    </div>


</asp:Content>

