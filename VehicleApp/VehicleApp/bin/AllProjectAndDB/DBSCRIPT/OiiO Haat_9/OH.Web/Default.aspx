<%@ Page Title="" Language="C#" ValidateRequest="true" MasterPageFile="~/DefaultMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="OH.Web.Default" Trace="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section>
        <div class="bannerWrp">
            <div class="container-fluid">
                <div class="row">


                    <div id="carousel-example-generic" class="carousel slide" data-ride="carousel">


                        <!-- Wrapper for slides -->
                        <div class="carousel-inner" role="listbox">

                            <div class="item active">
                                <asp:Image runat="server" ImageUrl='<%# Eval("Image") %>' ID="img_banner" Width="100%" Height="300" alt="Image" />
                            </div>
                            <asp:Repeater ID="rp_BannerPictures" runat="server">
                                <ItemTemplate>
                                    <div class="item">
                                        <asp:Image runat="server" ID="img_banner" Width="100%" Height="300" ImageUrl='<%# Eval("Image") %>' alt="Image" CssClass="img-responsive" />

                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>

                        <!-- Controls -->
                        <a class="left carousel-control" href="#carousel-example-generic" role="button" data-slide="prev">
                            <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
                            <span class="sr-only">Previous</span>
                        </a>
                        <a class="right carousel-control" href="#carousel-example-generic" role="button" data-slide="next">
                            <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
                            <span class="sr-only">Next</span>
                        </a>
                    </div>

                </div>

            </div>
            <div class="clearfix"></div>
        </div>
        <div class="mainMenuWrp">

            <nav class="navbar navbar-default" role="navigation">
                <div class="container">
                    <div class="row mainMenu">
                        <div class="navbar-header">
                            <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#main-menu">
                                <span class="sr-only">Toggle navigation</span>
                                <span class="icon-bar"></span>
                                <span class="icon-bar"></span>
                                <span class="icon-bar"></span>
                            </button>
                            <a class="navbar-brand hidden-md hidden-lg" href="#">Menu</a>
                        </div>

                        <div class="collapse navbar-collapse" id="main-menu">
                            <ul class="nav navbar-nav">

                                <asp:Repeater ID="rptNavMenu" runat="server">
                                    <ItemTemplate>
                                        <li>
                                            <a runat="server" href='<%#"DefaultInner?tp="+OH.Utilities.StringCipher.Encrypt(Eval("Name").ToString()) %>'>
                                                <asp:Label ID="lblTypeID" runat="server" Text='<%#Eval("Name")%>'></asp:Label>
                                            </a>
                                        </li>
                                    </ItemTemplate>
                                </asp:Repeater>

                            </ul>
                        </div>
                    </div>
                </div>
            </nav>

            <div class="clearfix"></div>
        </div>
        <div class="container">
            <div class="mainPgCnt">
                <div class="row">
                    <div class="col-sm-9 col-md-9 col-lg-9">
                        <div class="latestAdd">
                            <div class="well">
                                <!-- Carousel
                        ================================================== -->

                                <div class="controlPart">
                                    <h3>Latest Ads </h3>
                                    <div class="carouselPart">
                                        <a href="#" class="left carousel-control lefCaro jcarousel-control-prev"><i class="fa fa-chevron-left fa-2x"></i></a>
                                        <a href="#" class="right carousel-control rightCaro jcarousel-control-next"><i class="fa fa-chevron-right fa-2x"></i></a>
                                    </div>
                                </div>

                                <div class="jcarousel-wrapper latestAddInner">
                                    <div class="jcarousel">
                                        <ul>
                                            <asp:Repeater ID="rpGetLatestFirstAds" runat="server" OnItemDataBound="rpGetLatestFirstAds_OnItemDataBound">
                                                <ItemTemplate>
                                                    <li>
                                                        <div class="thumbnail">
                                                            <a runat="server" href='<%#"DetailPage?option="+OH.Utilities.StringCipher.Encrypt(Eval("IID").ToString()) %>'>
                                                                <asp:Image runat="server" ID="img_Ads" Width="272" Height="230" ImageUrl='<%# Eval("ImageUrl") %>' alt="Image" />
                                                            </a>
                                                            <div class="caption">
                                                                <h3>
                                                                    <%--   <%# Eval("TitleName") %>--%>

                                                                    <asp:Literal ID="ltrLatestFirstAds" runat="server" Text=' <%# Eval("TitleName") %>'></asp:Literal>

                                                                </h3>
                                                               <%-- <p>
                                                                    <asp:Literal ID="ltrDescription" runat="server" Text=' <%# Eval("Description") %>'></asp:Literal>
                                                                </p>--%>
                                                                <p>
                                                                    <a role="button" class="btn btn-default readMore" href="<%#"DetailPage?option="+OH.Utilities.StringCipher.Encrypt(Eval("IID").ToString()) %>">Read more</a>
                                                                </p>
                                                            </div>
                                                        </div>
                                                    </li>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </ul>
                                    </div>
                                </div>
                            </div>

                        </div>
                        <div class="latestAdd">

                            <div class="well">
                                <!-- Carousel
                        ================================================== -->
                                <div class="controlPart">
                                    <h3>Latest Ad in For sell</h3>
                                    <div class="carouselPart">

                                        <a href="#" class="left carousel-control lefCaro jcarousel-control-prev"><i class="fa fa-chevron-left fa-2x"></i></a>
                                        <a href="#" class="right carousel-control rightCaro jcarousel-control-next"><i class="fa fa-chevron-right fa-2x"></i></a>
                                    </div>
                                </div>

                                <div class="jcarousel-wrapper latestAddInner latestAddInnerSale">
                                    <div class="jcarousel jcarousel2">
                                        <ul>
                                            <asp:Repeater ID="rpLatestForSale" runat="server" OnItemDataBound="rpLatestForSale_OnItemDataBound">
                                                <ItemTemplate>

                                                    <li>
                                                        <div class="thumbnail">
                                                            <a runat="server" href='<%#"DetailPage?option="+OH.Utilities.StringCipher.Encrypt(Eval("IID").ToString()) %>'>
                                                                <asp:Image runat="server" ID="img_AdForSales" Width="272" Height="230" ImageUrl='<%# Eval("ImageUrl") %>' alt="Image" />
                                                            </a>
                                                            <div class="caption">
                                                                <h3><%--<%# Eval("TitleName") %>--%>
                                                                    <asp:Literal ID="ltrForSaleTitle" runat="server" Text=' <%# Eval("TitleName") %>'></asp:Literal>
                                                                </h3>
                                                               <%-- <p>
                                                                    <asp:Literal ID="ltrForSaleDescription" runat="server" Text=' <%# Eval("Description") %>'></asp:Literal>
                                                                </p>--%>

                                                                <div class="addtoCartPart">
                                                                    <a href="<%#"DetailPage?option="+OH.Utilities.StringCipher.Encrypt(Eval("IID").ToString()) %>"><span class="fa fa-angle-double-right pull-right"></span></a>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </li>

                                                </ItemTemplate>
                                            </asp:Repeater>

                                        </ul>
                                    </div>


                                </div>

                            </div>

                        </div>


                    </div>
                    <div class="col-sm-3 col-md-3 col-lg-3 sideBar">

                        <div class="sidebarPar">
                            <a class="clickhere3add" href="#">Ads</a>

                            <a class="clickhere" href="http://www.oiiointernational.com" rel="canonical" target="_blank">Click to here </a>

                            <a class="clickhere2" href="http://www.oiiounite.com" rel="canonical" target="_blank">Us for one
                                <br />
                                one for us</a>

                        </div>
                        <div class="sidebarPar2">
                            <a href="https://www.facebook.com/" target="_blank">
                                <img class="img-responsive" src="App_Themes/Default/images/interface/facebook.png" alt="img" /></a>
                        </div>

                    </div>
                </div>
            </div>
        </div>

    </section>
    <section>
        <div class="pagePart2 welcomeNote">
            <div class="container">
                <div class="row">
                    <div class="col-xs-8">
                        <h3>Latest spotlight ads</h3>
                    </div>
                    <div class="col-xs-3 pull-right text-right">
                        <h3>
                            <a id="ViewAll" runat="server" class="viewAllLink">View all <span class="fa fa-angle-double-right pull-right"></span>
                            </a>

                        </h3>
                    </div>

                </div>
                <div class="row">
                    <asp:Repeater ID="rpGetLatestSpotLightAds" runat="server" OnItemDataBound="rpGetLatestSpotLightAds_OnItemDataBound">
                        <ItemTemplate>

                            <div class="col-md-3">
                                <div class="thumbnail">
                                    <a runat="server" href='<%#"DetailPage?option="+OH.Utilities.StringCipher.Encrypt(Eval("IID").ToString()) %>'>
                                        <asp:Image runat="server" ID="img_SpotLight" ImageUrl='<%#Eval("UrlAddress") %>' Width="263" Height="252" alt="image" />
                                    </a>
                                    <div class="captart2">
                                        <p style="text-align: left;">

                                            <asp:Literal ID="ltrTitleName" runat="server" Text=' <%# Eval("TitleName") %>'></asp:Literal>
                                        </p>
                                    </div>
                                    <div class="readmore2">
                                        <a role="button" href="<%#"DetailPage?option="+OH.Utilities.StringCipher.Encrypt(Eval("IID").ToString()) %>">Read more</a>
                                    </div>
                                </div>
                            </div>

                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </section>
    <section>
        <div class="container">
            <div class="row">
                <div class="pagePart3">

                    <div class="controlPart">
                        <h3>Others from oiio <span class="pull-right" style="margin-right: 5px;"><a class="viewAllLink" href="OthersFromOiiOInner?tp=Others From OiiO">View all <span class="fa fa-angle-double-right"></span></a></span></h3>

                    </div>

                    <div class="pagePart3Inner">

                        <asp:Repeater ID="rp_OtherContent" runat="server" OnItemDataBound="rp_OtherContent_ItemDataBound">
                            <ItemTemplate>

                                <div class="col-md-4">
                                    <div class="thumbnail">
                                        <h4>
                                            <a runat="server" href='<%#"OtherContentDetailPage?option="+ OH.Utilities.StringCipher.Encrypt(Eval("IID").ToString()) %>'>
                                                <%#Eval("Title") %>
                                            </a>
                                        </h4>
                                        <p style="text-align: left;">
                                            <asp:Literal ID="ltrShortDescription" runat="server" Text=' <%# Eval("ShortDescription") %>'></asp:Literal>
                                        </p>
                                        <a runat="server" href='<%#"OtherContentDetailPage?option="+ OH.Utilities.StringCipher.Encrypt(Eval("IID").ToString()) %>'>
                                            <asp:Image ID="img_Others" runat="server" class=" img-circle" ImageUrl='<%#Eval("ImageUrl") %>' Width="300" Height="300" />
                                        </a>
                                        <div class="caption">
                                            <p style="text-align: left;">

                                                <asp:Literal ID="ltrDetailDescription" runat="server" Text=' <%# Eval("DetailDescription") %>'></asp:Literal>
                                            </p>
                                            <p><a role="button" class="btn btn-default readMore" href="<%#"OtherContentDetailPage?option="+ OH.Utilities.StringCipher.Encrypt(Eval("IID").ToString()) %>">Read More</a></p>
                                        </div>
                                    </div>
                                </div>

                            </ItemTemplate>
                        </asp:Repeater>

                    </div>


                </div>
            </div>
            <%-- <div class="row oiioCollection">
                <div class="col-sm-6 col-md-6 col-lg-6">
                    <div class="oiioBoxA">
                        <a href="#">Top Location</a>
                    </div>
                </div>
                <div class="col-sm-6 col-md-6 col-lg-6">
                    <div class="oiioBoxB">

                        <a href="#">Top Searches</a>
                    </div>
                </div>
            </div>--%>
        </div>
    </section>

</asp:Content>
