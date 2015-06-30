<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultMaster.Master" AutoEventWireup="true" CodeBehind="OtherContentDetailPage.aspx.cs" Inherits="OH.Web.OtherContentDetailPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section>
        <nav class="navbar navbar-default menu2">
            <div class="container adminPagewrp">
                <!-- Brand and toggle get grouped for better mobile display -->
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
                        <span class="sr-only">Toggle navigation</span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>

                </div>

                <!-- Collect the nav links, forms, and other content for toggling -->
                <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                    <ul class="nav navbar-nav">
                        <li><a id="hrf_back_to_Destination" runat="server" class="backLink" ><span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span></a></li>
                        <li><a id="href_backToPrevious_Page_content" runat="server">Back</a></li>
                        <%--  <li><a href="#">United Kingdom</a></li>
                        <li><a href="#">England</a></li>
                        <li><a href="#">Manchester</a></li>
                        <li><a href="#">Longsight</a></li>
                        <li><a href="#">Motors</a></li>
                        <li><a href="#">Cars for Sale</a></li>
                        <li><a href="#">Used Vauxhall for sale</a></li>--%>
                    </ul>

                    <ul class="nav navbar-nav navbar-right socialIcon">
                        <li class="sharelbl">Share:</li>
                        <li><a href="#">
                            <img src="App_Themes/Default/images/interface/fbook1.png" alt="img" /></a></li>
                        <li><a href="#">
                            <img src="App_Themes/Default/images/interface/twitter2.png" alt="img" /></a></li>
                        <li><a href="#">
                            <img src="App_Themes/Default/images/interface/GPlus2.png" alt="img" /></a></li>
                        <li><a href="#">
                            <img src="App_Themes/Default/images/interface/pinter2.png" alt="img" /></a></li>
                        <li><a href="#">
                            <img src="App_Themes/Default/images/interface/mainlbox2.png" alt="img" /></a></li>
                    </ul>
                </div>
                <!-- /.navbar-collapse -->
            </div>
            <!-- /.container-fluid -->
        </nav>
        <div class="container">
            <div class="mainPgCnt">
                <div class="row">
                    <div class="col-sm-9 col-md-9 col-lg-9">
                        <div role="tabpanel" class="oiioTabpanel">
                            <!-- Nav tabs -->
                            <ul class="nav nav-tabs" role="tablist">
                                <li role="presentation" class="active"><a href="#Image" aria-controls="Image" role="tab" data-toggle="tab"><span class="glyphicon glyphicon-camera" aria-hidden="true"></span>&nbsp;Photo</a></li>
                                <li role="presentation"><a href="#Map" aria-controls="Map" role="tab" data-toggle="tab"><span class="glyphicon glyphicon-map-marker" aria-hidden="true"></span>&nbsp;Map </a></li>
                            </ul>
                            <!-- Tab panes -->
                            <div class="tab-content">
                                <div role="tabpanel" class="tab-pane active" id="Image">
                                    <h3>
                                        <asp:Label ID="lbl_txt_Title" runat="server"></asp:Label></h3>
                                    <p>
                                        <asp:Literal ID="lbl_Short_Description" runat="server">
                                        </asp:Literal>

                                    </p>
                                    <br />
                                    <div class="product_imgWrp">
                                        <div id="carousel-example-generic" class="carousel slide" data-ride="carousel">

                                            <div class="carousel-inner" role="listbox">
                                                <div class="item active">
                                                    <asp:Image runat="server" ID="img_OtherContentDetails" Width="970" Height="480" alt="Image" />
                                                </div>

                                            </div>

                                        </div>
                                    </div>
                                </div>
                                <div role="tabpanel" class="tab-pane" id="Map">
                                    content comming soon
                                </div>
                            </div>
                        </div>
                        <div class="row">
                        </div>
                        <div class="row productDecpart">
                            <div class="col-sm-12 col-md-12 col-lg-12">
                                <h3>Description</h3>
                                <p>
                                    <asp:Literal ID="ltr_Content_Detail_Description" runat="server">
                                    </asp:Literal>
                                </p>

                            </div>
                        </div>
                        <%-- <div role="tabpanel" class="oiioTabpanel2">

                            <!-- Nav tabs -->
                            <ul class="nav nav-tabs" role="tablist">
                                <li role="presentation" class="active"><a href="#carbuying" aria-controls="carbuying" role="tab" data-toggle="tab">Car Buying Tips</a></li>
                                <li role="presentation"><a href="#credithist" aria-controls="credithist" role="tab" data-toggle="tab">Credit History </a></li>
                                <li role="presentation"><a href="#carLoans" aria-controls="carLoans" role="tab" data-toggle="tab">Car Loans </a></li>

                            </ul>

                            <!-- Tab panes -->
                            <div class="tab-content">
                                <div role="tabpanel" class="tab-pane active" id="carbuying">
                                    <div class="col-sm-6 col-md-6 col-lg-6">
                                        <h4>A used car could cost you £3,500 a year to run.</h4>
                                        <p>Find out the best way to buy and afford a used car.</p>
                                        <input type="submit" class="btn btn-primary col-md-8 col-md-offset-2 findBtn" value="Find out more" />
                                    </div>
                                    <div class="col-sm-6 col-md-6 col-lg-6">
                                        <img src="App_Themes/Default/images/products/57.jpg" alt="img" />
                                    </div>
                                </div>

                                <div role="tabpanel" class="tab-pane" id="credithist">
                                    <div class="col-sm-6 col-md-6 col-lg-6">
                                        <h4>A used car could cost you £3,500 a year to run.</h4>
                                        <p>Find out the best way to buy and afford a used car.</p>
                                        <input type="submit" class="btn btn-primary col-md-8 col-md-offset-2 findBtn" value="Find out more" />
                                    </div>


                                </div>
                                <div role="tabpanel" class="tab-pane" id="carLoans">
                                    <div class="col-sm-6 col-md-6 col-lg-6">
                                        <img src="App_Themes/Default/images/products/57.jpg" alt="img" />
                                    </div>

                                </div>

                            </div>
                        </div>--%>

                        <%-- <div class="row productDecpart sponserLink">
                            <div class="col-sm-12 col-md-12 col-lg-12">
                                <h3>Sponsored Links</h3>
                                <img src="App_Themes/Default/images/interface/sponserlogo1.jpg" alt="img" />
                                <h4>Vauxhall Service?</h4>
                                <p>
                                    <a href="http://www.vauxhall.co.uk/Book_Service?">www.vauxhall.co.uk/Book_Service?</a><br />
                                    Find Your Nearest Vauxhall-Approved Garage & Book A Service Today!?
                                    <br />
                                    <a href="#">Repairs From £99? - Vauxhall Accessories?</a>
                                </p>

                            </div>
                        </div>--%>
                    </div>
                    <div class="col-sm-3 col-md-3 col-lg-3 sideBar">
                        <div class="postedInfo">
                            <div class="postedInfoInner contactBox">
                                <h3>Contact OiiO HaaT</h3>
                                <%--<p><span class="pull-right"><a href="#">See all ads</a></span></p>--%>
                                <h5><span class="glyphicon glyphicon-earphone">142102 34870</span> </h5>
                                <div class="form-group ">
                                    <button type="button" class="btn btn-default btn-md">
                                        <span class="glyphicon glyphicon-star" aria-hidden="true"></span>Rating
                                    </button>
                                    <a href="ReportingPage.aspx" class="btn btn-default btn-md pull-right">
                                        <span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span>
                                        Reporting
                                    </a>

                                </div>
                            </div>
                        </div>

                        <div id="carousel_oiio2" class="carousel slide saftyBox" data-ride="carousel">
                            <!-- Indicators -->
                            <!-- Wrapper for slides -->
                            <div class="carousel-inner" role="listbox">

                                <div class="item active">
                                    <div class="postedInfoInner stySafe">
                                        <h3 style="border-bottom: 1px solid #c6c6c6;">Safety Tips</h3>
                                        <%-- <img class="stayImg" src="App_Themes/Default/images/interface/img1.jpg" alt="img" />--%>
                                        <p>
                                            <i class="fa fa-check"></i>&nbsp;   Never include your personal information in the ad like your address.
                                        </p>

                                    </div>
                                </div>
                                <div class="item">
                                    <div class="postedInfoInner stySafe">
                                        <h3 style="border-bottom: 1px solid #c6c6c6;">Safety Tips</h3>
                                        <p>
                                            <i class="fa fa-check"></i>&nbsp;  It’s always better not to post your picture and also don’t post adult material or nude images that oppose our terms and conditions.
                                        </p>

                                    </div>
                                </div>
                                <div class="item">
                                    <div class="postedInfoInner stySafe">
                                        <h3 style="border-bottom: 1px solid #c6c6c6;">Safety Tips</h3>
                                        <p>
                                            <i class="fa fa-check"></i>&nbsp;  Talk to people on the phone and use your common sense before providing them information, like your address, and trust your instincts.
                                        </p>

                                    </div>
                                </div>
                                <div class="item">
                                    <div class="postedInfoInner stySafe">
                                        <h3 style="border-bottom: 1px solid #c6c6c6;">Safety Tips</h3>
                                        <p>
                                            <i class="fa fa-check"></i>&nbsp;  If someone is coming to check out the items you advertised, make sure you're not alone when they arrive.
                                        </p>

                                    </div>
                                </div>
                                <div class="item">
                                    <div class="postedInfoInner stySafe">
                                        <h3 style="border-bottom: 1px solid #c6c6c6;">Safety Tips</h3>
                                        <p>
                                            <i class="fa fa-check"></i>&nbsp; It’s always good to show items that are portable but expensive like digital camera in public places instead of your home.
                                        </p>

                                    </div>
                                </div>
                                <div class="item">
                                    <div class="postedInfoInner stySafe">
                                        <h3 style="border-bottom: 1px solid #c6c6c6;">Safety Tips</h3>
                                        <p>
                                            <i class="fa fa-check"></i>&nbsp; Take some one along with you when you meet the people personally.
                                        </p>

                                    </div>
                                </div>
                                <div class="form-group oiioCarControl">
                                    <span><a class="margin10px" href="#" data-toggle="modal" data-target="#oiioModal1">Read all safety tips</a></span>
                                    <div class="pull-right">
                                        <a class="left" href="#carousel_oiio2" role="button" data-slide="prev">
                                            <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
                                            <span class="sr-only">Previous</span>
                                        </a>
                                        <a class="right" href="#carousel_oiio2" role="button" data-slide="next">
                                            <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
                                            <span class="sr-only">Next</span>
                                        </a>
                                    </div>
                                </div>


                            </div>

                            <!-- Controls -->

                            <div class="clearfix"></div>
                        </div>

                        <!-- Small modal -->

                        <div class="modal fade" id="oiioModal1" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                            <div class="modal-dialog">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                        <h4 class="modal-title" id="myModalLabel">Safety Tips</h4>
                                    </div>
                                    <div class="modal-body">
                                        <p>
                                            We are interested and committed in creating a user friendly environment where it is easy for an user to post and reply ads without any concern. 
                                            There are many things which you should keep in mind to protect yourself and your privacy online. 
                                            The following are the few tips and techniques you should follow.
                                        </p>
                                        <h4 class="modal-title">Posting an Ad</h4>
                                        <p>
                                            Online advertising gives us an opportunity to reach people as many as possible those who are interested in purchasing the goods that we post in a quick and effective way.
                                           But be careful while posting an ad as you may not know the people who respond to your ad.
                                        </p>
                                        <ul class="safetytips">
                                            <li><i class="fa fa-check"></i>&nbsp; Never include your personal information in the ad like your address.
                                            </li>
                                            <li><i class="fa fa-check"></i>&nbsp; It’s always better not to post your picture and also don’t post adult material or nude images that oppose our terms and conditions.
                                            </li>
                                            <li><i class="fa fa-check"></i>&nbsp; Talk to people on the phone and use your common sense before providing them information, like your address, and trust your instincts.
                                            </li>
                                            <li><i class="fa fa-check"></i>&nbsp; If someone is coming to check out the items you advertised, make sure you're not alone when they arrive.
                                            </li>
                                            <li><i class="fa fa-check"></i>&nbsp; It’s always good to show items that are portable but expensive like digital camera in public places instead of your home.
                                            </li>
                                            <li><i class="fa fa-check"></i>&nbsp; Take some one along with you when you meet the people personally.
                                            </li>
                                            <li><i class="fa fa-check"></i>&nbsp; Meet people in a public place.
                                            </li>

                                        </ul>


                                        <h4 class="modal-title">Responding to an Ad</h4>
                                        <p>
                                            Online ad services gives us immense number of opportunities to find different types of items that we are interested in purchasing.
                                          But be careful while responding to an ad as you may not know the people who respond to your ad.
                                        </p>
                                        <ul class="safetytips">
                                            <li><i class="fa fa-check"></i>&nbsp;
                                                Avoid up-front payments via money order, wire transfer or moneygram before you see the item and meet the person personally.
                                            </li>
                                            <li>
                                                <i class="fa fa-check"></i>&nbsp;
                                                Use common sense and never provide your personnel information and trust your instincts
                                            </li>
                                            <li>
                                                <i class="fa fa-check"></i>&nbsp;
                                                Always meet people in a public place.
                                            </li>
                                            <li>
                                                <i class="fa fa-check"></i>&nbsp;
                                                When you go some ones house always bring a friend.
                                            </li>

                                        </ul>

                                    </div>
                                    <div class="modal-footer">
                                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
