<%@ Page Title="" Language="C#" MasterPageFile="~/OiiOInnerMasterPage.Master" AutoEventWireup="true" CodeBehind="AuthBiographyPage.aspx.cs" Inherits="OB.Web.AuthBiographyPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderInnerPage" runat="server">
    <div class="ContentArea commonH3titel bookDetailsWrp">

        <div class="row">
            <div class="col-xs-12">
                <div class="bookBox bookDetails">

                    <div class="thumbnail col-xs-4">
                        <h4><span>Meet</span> the Author</h4>
                     
                            <asp:Image CssClass="img-responsive" ID="imgAuthImage" alt="Slide11" runat="server" />

                    
                      
                        <br />

                        
                        <h5><asp:Label runat="server" ID="lbAuthName1"></asp:Label></h5>
                        <hr />
                        <ul class="ul socialMedia">
                            <li><a href="#">
                                <img alt="icon1" src="../images/Interfaces/icon1.png" /></a></li>
                            <li><a href="#">
                                <img alt="icon1" src="../images/Interfaces/icon2.png" /></a></li>
                        </ul>
                    </div>

                    <div class="col-xs-8">
                        <h3><b>
                            <asp:Label runat="server" ID="lbAuthName"></asp:Label></b></h3>

                        <p>
                            <asp:Label runat="server" ID="lbAboutAuthor"></asp:Label>

                        </p>
                        <h5 style="font-style: italic">
                            <asp:Label runat="server" ID="lbAuthWebsiteLink"></asp:Label></h5>

                    </div>

                </div>

            </div>


            <div class="bookBoxWrp">

                <div class="row byAuthbookList">
                    <div class="col-sm-12">
                        <h3><span>Other books by
                            <asp:Literal ID="ltrAuthorName" runat="server"></asp:Literal></span></h3>
                        <h5>
                            <asp:Literal ID="ltrCount" runat="server"></asp:Literal>
                            <asp:LinkButton ID="lbBrowseAuthorAllBooks" CssClass="pull-right" runat="server" OnClick="lbBrowseAuthorAllBooks_OnClick"></asp:LinkButton>
                        </h5>


                        <div class="well commonBg1">
                            <div class="row">

                                <asp:Repeater runat="server" ID="rptBook">
                                    <ItemTemplate>
                                        <div class="col-xs-3 col-sm-3 col-md-3  col-lg-3">

                                            <div class="bookBox">
                                                <h4><span>Open</span> the Book</h4>
                                                <div class="thumbnail">
                                                    <a href="BookDetails?ID=<%# Eval("IID") %>">
                                                        <asp:Image ID="img_Book" runat="server" CssClass="img-responsive" ImageUrl='<%# Eval("ImageUrl") %>' alt="Slide11" />
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
                        <h3>Other websites </h3>
                        <h5>Official Website :: <a runat="server" id="ancAuthWebLink" href="#" target="_blank"><asp:Label runat="server" ID="lbAuthWebsiteName"></asp:Label> </a> </h5>
                        <p>The OiiO Book is not responsible for the content of external websites</p>
                    </div>


                </div>

            </div>
        </div>
    </div>
</asp:Content>
