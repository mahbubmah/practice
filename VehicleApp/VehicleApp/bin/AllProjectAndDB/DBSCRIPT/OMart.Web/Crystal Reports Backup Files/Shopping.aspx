<%@ Page Title="" Language="C#" MasterPageFile="~/ShoppingMaster.Master" AutoEventWireup="true" CodeBehind="Shopping.aspx.cs" Inherits="OMart.Web.Shopping" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="shoppingPlaceholder" runat="server">
    <section>
        <div class="container-fluid bannerWrp">


            <div class="carousel fade-carousel slide oiioFadeBanner BroadBandBanner" data-ride="carousel" data-interval="4000" id="bs-carousel">
                <!-- Overlay -->


                <!-- Indicators -->
                <%-- <ol class="carousel-indicators">
    <li data-target="#bs-carousel" data-slide-to="0" class="active"></li>
    <li data-target="#bs-carousel" data-slide-to="1"></li>
    <li data-target="#bs-carousel" data-slide-to="2"></li>
  </ol>--%>

                <!-- Wrapper for slides -->
                <div class="carousel-inner">
                    <div class="item slides active">
                        <div class="insBannerCntWrp broadBandPage">
                            <div class="container">
                                <div class="row">
                                    <div class="col-sm-3 col-md-3 col-lg-3">
                                        <div class="brodBandLink">
                                            <ul>
                                                <li><a href="#">Health & beauty</a></li>
                                                <li><a href="#">Office supplies</a></li>
                                                <li><a href="#">Cameras</a></li>
                                                <li><a href="#">Televisions</a></li>
                                                <li><a href="#">Computers</a></li>
                                                <li><a href="#">Fashion</a></li>
                                                <li><a href="#">Furniture</a></li>

                                            </ul>
                                            <p>
                                                <a class="brodBandLinkControl prevlink" href="#"><span class="glyphicon glyphicon-chevron-up"></span></a>
                                                <a class="brodBandLinkControl nextlink" href="#"><span class="glyphicon glyphicon-chevron-down"></span></a>
                                            </p>
                                        </div>

                                    </div>
                                    <div class="col-sm-9 col-md-9 col-lg-9">

                                        <div class="insBannerCnt">

                                            <h4>Top 10 mobile phones</h4>
                                            <h3>Samsung Galaxy S5 16GB</h3>
                                            <p>
                                                A great camera, superfast 4G, a Full HD 5" Super  
                                                <br />
                                                AMOLED screen add up to the best Galaxy S  
                                                <br />
                                                smartphone so far. And it's water-resistant too.
                                              
                                                
                                            </p>
                                            <p>FREE from 4200 Tk per month</p>
                                            <p><a class="btn btn-primary compareBtn " href="#">Compare deals <span class="glyphicon glyphicon-chevron-right oioCherRight2"></span></a></p>

                                            <div class="hero2">
                                                <img class="img-responsive" src="Images/banner/bannner10.png" alt="img" />
                                            </div>

                                        </div>

                                    </div>
                                </div>
                            </div>


                        </div>
                    </div>
                    <div class="item slides">
                        <div class="slideinsur2"></div>
                        <div class="insBannerCntWrp broadBandPage">
                            <div class="container">
                                <div class="row">
                                    <div class="col-sm-3 col-md-3 col-lg-3">
                                        <div class="brodBandLink">
                                            <ul>
                                                <li><a href="#">Apple iphone</a></li>
                                                <li><a href="#">Samsung galaxy</a></li>
                                                <li><a href="#">Black berry</a></li>
                                                <li><a href="#">Sony</a></li>
                                                <li><a href="#">Max</a></li>
                                                <li><a href="#">Nokia</a></li>
                                                <li><a href="#">Symphony</a></li>

                                            </ul>
                                            <p>
                                                <a class="brodBandLinkControl prevlink" href="#"><span class="glyphicon glyphicon-chevron-up"></span></a>
                                                <a class="brodBandLinkControl nextlink" href="#"><span class="glyphicon glyphicon-chevron-down"></span></a>
                                            </p>
                                        </div>

                                    </div>
                                    <div class="col-sm-9 col-md-9 col-lg-9">

                                        <div class="insBannerCnt">

                                            <h4>Top 10 mobile phones</h4>
                                            <h3>Samsung Galaxy S5 16GB</h3>
                                            <p>
                                                A great camera, superfast 4G, a Full HD 5" Super  
                                                <br />
                                                AMOLED screen add up to the best Galaxy S  
                                                <br />
                                                smartphone so far. And it's water-resistant too.
                                              
                                                
                                            </p>
                                            <p>FREE from 4200 Tk per month</p>
                                            <p><a class="btn btn-primary compareBtn " href="#">Compare deals <span class="glyphicon glyphicon-chevron-right oioCherRight2"></span></a></p>

                                            <div class="hero2">
                                                <img class="img-responsive" src="Images/banner/bannner10.png" alt="img" />
                                            </div>

                                        </div>

                                    </div>
                                </div>
                            </div>


                        </div>
                    </div>
                    <div class="item slides">
                        <div class="slideinsur3"></div>
                        <div class="insBannerCntWrp broadBandPage">
                            <div class="container">
                                <div class="row">
                                    <div class="col-sm-3 col-md-3 col-lg-3">
                                        <div class="brodBandLink">
                                            <ul>
                                                <li><a href="#">Apple iphone</a></li>
                                                <li><a href="#">Samsung galaxy</a></li>
                                                <li><a href="#">Black berry</a></li>
                                                <li><a href="#">Sony</a></li>
                                                <li><a href="#">Max</a></li>
                                                <li><a href="#">Nokia</a></li>
                                                <li><a href="#">Symphony</a></li>

                                            </ul>
                                            <p>
                                                <a class="brodBandLinkControl prevlink" href="#"><span class="glyphicon glyphicon-chevron-up"></span></a>
                                                <a class="brodBandLinkControl nextlink" href="#"><span class="glyphicon glyphicon-chevron-down"></span></a>
                                            </p>
                                        </div>

                                    </div>
                                    <div class="col-sm-9 col-md-9 col-lg-9">

                                        <div class="insBannerCnt">

                                            <h4>Top 10 mobile phones</h4>
                                            <h3>Samsung Galaxy S5 16GB</h3>
                                            <p>
                                                A great camera, superfast 4G, a Full HD 5" Super  
                                                <br />
                                                AMOLED screen add up to the best Galaxy S  
                                                <br />
                                                smartphone so far. And it's water-resistant too.
                                              
                                                
                                            </p>
                                            <p>FREE from 4200 Tk per month</p>
                                            <p><a class="btn btn-primary compareBtn " href="#">Compare deals <span class="glyphicon glyphicon-chevron-right oioCherRight2"></span></a></p>

                                            <div class="hero2">
                                                <img class="img-responsive" src="Images/banner/bannner10.png" alt="img" />
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
    </section>

    <section>
        <div class="container">
            <div class="row">
                <div class="servBoxWrp insServInner insGuide commBoxTitel2 dealMfgFinerWrp">
                    <div class="row">


                        <div class="col-sm-3 col-md-3 col-lg-3">
                            <div class="bBrandproductBox2Wrp">


                                <div class="img-thumbnail">
                                    <img class="img-responsive" src="Images/products/85.jpg" alt="img" />
                                </div>
                                <h5><span class="bbandProdHead_bg1 pull-left"></span>Health & beauty<span class="bbandProdHead_bg2 pull-right"></span></h5>
                                <div class="bBrandproductCnt">
                                    <p>
                                        Lorem dummy text ever since the 1500s, when an unknown printer took a galley of  type specimen book.
                                    </p>


                                    <a class="btn btn-primary btnReadMore3" href="#">Read More</a>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-3 col-md-3 col-lg-3">
                            <div class="bBrandproductBox2Wrp">


                                <div class="img-thumbnail">
                                    <img class="img-responsive" src="Images/products/86.jpg" alt="img" />
                                </div>
                                <h5><span class="bbandProdHead_bg1 pull-left"></span>Camera<span class="bbandProdHead_bg2 pull-right"></span></h5>
                                <div class="bBrandproductCnt">
                                    <p>
                                        Lorem dummy text ever since the 1500s, when an unknown printer took a galley of  type specimen book.
                                    </p>


                                    <a class="btn btn-primary btnReadMore3" href="#">Read More</a>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-3 col-md-3 col-lg-3">
                            <div class="bBrandproductBox2Wrp">


                                <div class="img-thumbnail">
                                    <img class="img-responsive" src="Images/products/87.jpg" alt="img" />
                                </div>
                                <h5><span class="bbandProdHead_bg1 pull-left"></span>Fashion<span class="bbandProdHead_bg2 pull-right"></span></h5>
                                <div class="bBrandproductCnt">
                                    <p>
                                        Lorem dummy text ever since the 1500s, when an unknown printer took a galley of  type specimen book.
                                    </p>


                                    <a class="btn btn-primary btnReadMore3" href="#">Read More</a>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-3 col-md-3 col-lg-3">
                            <div class="bBrandproductBox2Wrp">


                                <div class="img-thumbnail">
                                    <img class="img-responsive" src="Images/products/66.jpg" alt="img" />
                                </div>
                                <h5><span class="bbandProdHead_bg1 pull-left"></span>Furniture<span class="bbandProdHead_bg2 pull-right"></span></h5>
                                <div class="bBrandproductCnt">
                                    <p>
                                        Lorem dummy text ever since the 1500s, when an unknown printer took a galley of  type specimen book.
                                    </p>


                                    <a class="btn btn-primary btnReadMore3" href="#">Read More</a>
                                </div>
                            </div>
                        </div>




                    </div>
                    <%--<div class="row">
                    <div class="col-sm-3 pull-right">
                    <a href="#" class="btn btn-primary viewAll pull-right ">View all</a>
                        </div>
                </div>--%>
                    <div class="clearfix"></div>
                </div>
            </div>

            <div class="latestPhone">
                <div class="row">
                    <h3>Latest news for shopping</h3>

                    <div class="row">
                        <asp:Repeater ID="rptshoppingNews" runat="server">
                            <ItemTemplate>
                                <div class="col-sm-4 col-md-4 col-lg-4">
                                    <div class="latestProductBox">

                                        <legend>
                                           <asp:Label ID="lblDate" runat="server" Text='<%# Eval("date", "{0:dd/MM/yyyy}") %>'></asp:Label>

                                        </legend>
                                        <div class="imgBox">
                                            <asp:Image ID="imgImageUrl" CssClass="img-responsive" runat="server" ImageUrl='<%# Bind("ImageUrl")%>' AlternateText="img" Width="250" Height="170" />
                                        </div>
                                        <h5>Shopping</h5>
                                        <asp:Label ID="lblShoppingType" runat="server" Text='<%#Enum.Parse(typeof(Utilities.EnumCollection.BusinessShoppingType), Eval("BusinessTypeBreakdownID").ToString()) %>'>'></asp:Label>
                                        <p><a class="readstory" href="#">Read story </a></p>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>


                </div>
            </div>

        </div>

    </section>
</asp:Content>
