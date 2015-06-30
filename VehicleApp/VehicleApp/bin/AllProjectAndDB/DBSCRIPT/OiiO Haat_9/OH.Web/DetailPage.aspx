<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultMaster.Master" AutoEventWireup="true" CodeBehind="DetailPage.aspx.cs" Inherits="OH.Web.DetailPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">




    <style type="text/css">
        body {
            margin: 0px;
            padding: 0px;
            font-family: Arial;
        }

        a img, :link img, :visited img {
            border: none;
        }

        table {
            border-collapse: collapse;
            border-spacing: 0;
        }

        :focus {
            outline: none;
        }

        * {
            margin: 0;
            padding: 0;
        }

        p, blockquote, dd, dt {
            margin: 0 0 8px 0;
            line-height: 1.5em;
        }

        fieldset {
            padding: 0px;
            padding-left: 7px;
            padding-right: 7px;
            padding-bottom: 7px;
        }

            fieldset legend {
                margin-left: 15px;
                padding-left: 3px;
                padding-right: 3px;
                color: #333;
            }

        dl dd {
            margin: 0px;
        }

        dl dt {
        }

        .clearfix:after {
            clear: both;
            content: ".";
            display: block;
            font-size: 0;
            height: 0;
            line-height: 0;
            visibility: hidden;
        }

        .clearfix {
            display: block;
            zoom: 1;
        }


        ul#thumblist {
            display: block;
        }

            ul#thumblist li {
                float: left;
                margin-right: 2px;
                list-style: none;
            }

                ul#thumblist li a {
                    display: block;
                    border: 1px solid #CCC;
                }

                    ul#thumblist li a.zoomThumbActive {
                        border: 1px solid red;
                    }

        .jqzoom {
            text-decoration: none;
            float: left;
        }
    </style>


    <script type="text/javascript">
        //$(function () 
 {

        //    $.noConflict();

        //    $(".trigger").on('click', function (event) {
        //        event.preventDefault();
        //        if ($(this).attr('href') == '#Map') {
        //            GoogleMap();
        //        }
        //    });
        //});
     function GoogleMap() {


         var mapOptions = {
             center: new google.maps.LatLng(markers[0][0].lat, markers[0][0].lng),
             zoom: 15,
             mapTypeId: google.maps.MapTypeId.ROADMAP
         };
         var infoWindow = new google.maps.InfoWindow();

         var map = new google.maps.Map(document.getElementById("map_canvas"), mapOptions);

         var center = map.getCenter();
         google.maps.event.trigger(map, "resize");
         map.setCenter(center);

         for (i = 0; i < markers[0].length; i++) {
             var data = markers[0][i];
             var marker = new google.maps.Marker({
                 position: new google.maps.LatLng(data.lat, data.lng),
                 map: map
             });
             (function (marker, data) {
                 google.maps.event.addListener(marker, "click", function (e) {
                     infoWindow.setContent(data.description);
                     infoWindow.open(map, marker);
                 });
             })(marker, data);
         }
     }
        }
   
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <section>
        <nav class="navbar navbar-default menu2">
            <div class="container">
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
                        <li><a class="backLink" id="btnLnk_back" runat="server"><span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span></a></li>
                        <li><a id="href_backToPrevious_Page" runat="server">Back</a></li>

                    </ul>

                    <ul class="nav navbar-nav navbar-right socialIcon">
                        <li class="sharelbl">Share:</li>
                        <li><a href="http://www.facebook.com/" target="_blank">
                            <img src="App_Themes/Default/images/interface/fbook1.png" alt="img" /></a></li>
                        <li><a href="https://twitter.com/" target="_blank">
                            <img src="App_Themes/Default/images/interface/twitter2.png" alt="img" /></a></li>
                        <li><a href="https://plus.google.com/" target="_blank">
                            <img src="App_Themes/Default/images/interface/GPlus2.png" alt="img" /></a></li>
                        <li><a href="https://www.pinterest.com/" target="_blank">
                            <img src="App_Themes/Default/images/interface/pinter2.png" alt="img" /></a></li>
                        <li><a href="http://www.mailboxapp.com/" target="_blank">
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
                    <div class="col-sm-6 col-md-6 col-lg-6">

                        <div role="tabpanel" class="oiioTabpanel ">

                            <!-- Nav tabs -->
                            <ul class="nav nav-tabs" role="tablist">
                                <li role="presentation" class="active" style="width: 100%"><a href="#Image" aria-controls="Image" role="tab" data-toggle="tab"><span class="glyphicon glyphicon-camera" aria-hidden="true"></span>&nbsp;Photo</a></li>
                                <div style="display: none">
                                    <li role="presentation"><a href="#Map" class="trigger" aria-controls="Map" role="tab" data-toggle="tab"><span class="glyphicon glyphicon-map-marker" aria-hidden="true"></span>&nbsp;Map </a></li>
                                </div>
                            </ul>

                            <!-- Tab panes -->
                            <div class="tab-content">

                                <div role="tabpanel" class="tab-pane active" id="Image">
                                    <h3>
                                        <asp:Label ID="lbl_txt_Title" runat="server"></asp:Label></h3>
                                    <p>
                                        <asp:Label ID="lbl_Min_Description" runat="server"></asp:Label>
                                        <span class="pull-right">
                                            <strong>TK. </strong>
                                            <asp:Label ID="lbl_Price_Text" runat="server"></asp:Label></span>
                                    </p>
                                    <br />
                                    <%--     <div class="product_imgWrp">--%>
                                    <%--                                  <div id="carousel-example-generic" class="carousel slide" data-ride="carousel">
                                         
                                            <div id="image" class="carousel-inner" role="listbox">
                                                <div class="item active">
                                                    <asp:Image runat="server" ID="img_AdDetails" Width="970" Height="480" alt="Image" />
                                                </div>
                                                <asp:Repeater ID="rp_DetailPictures" runat="server">
                                                    <ItemTemplate>
                                                        <div class="item">
                                                            <asp:Image runat="server" ID="img_AdDetails" Width="970" Height="480" ImageUrl='<%# Eval("UrlAddress") %>' alt="Image" CssClass="img-responsive" />
                                                       
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:Repeater>

                                            </div>

                                           
                                            <a class="left carousel-control" href="#carousel-example-generic" role="button" data-slide="prev">

                                                <span class="sr-only">Previous</span>
                                            </a>
                                            <a class="right carousel-control" href="#carousel-example-generic" role="button" data-slide="next">

                                                <span class="sr-only">Next</span>
                                            </a>
                                        </div>--%>


                                      <asp:UpdatePanel runat="server">
                                        <ContentTemplate>
                                    <div class="clearfix" id="content" style="margin-top: 0; margin-left: 0; height: auto; width: 550px;">
                                        <div class="clearfix">
                                            <div class="item active">
                                                <a id="hrefImage2" runat="server" class="jqzoom"  title="OiiOHaaT">
                                                    <asp:Image runat="server" ID="img_AdDetailsup" Width="520px" Height="350px" alt="Image" />
                                                </a>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="clearfix">
                                            <ul id="thumblist" class="clearfix ">
                                                <asp:Repeater ID="rp_DetailPictures" runat="server">
                                                    <ItemTemplate>
                                                        <div class="item ">
                                                            <li style="width: 100px; margin-right: -1px; border: solid 1px black">
                                                                <asp:LinkButton ID="lnk_btn_Category_Inner" runat="server" CommandArgument='<%# Eval("IID") %>' OnClick="lnk_btn_Category_Inner_Click" CssClass="list-group-item">
                                                                    <asp:Image runat="server" ID="img_AdDetails" Width="100px" Height="75px" ImageUrl='<%# Eval("UrlAddress") %>' alt="Image" CssClass="img-responsive" />
                                                                </asp:LinkButton>
                                                            </li>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </ul>
                                        </div>
                                    </div>
                                   </ContentTemplate>
                                </asp:UpdatePanel>


                                    <%-- </div>--%>
                                </div>



                            </div>

                        </div>

                        <%-- <div role="tabpanel" class="tab-pane" id="Map">
                                    <div class="item active">
                                       <div id="map_canvas" style="border-top: none; width: 100%;height: 480px; background-color: #FAFAFA;">
                                        </div>
                                    </div>
                                </div>--%>

                        <div class="row">

                            <%-- <div class="col-sm-6 col-md-6 col-lg-6">
                                <div class="form-groupA">
                                    <label class="pull-left">Make</label>
                                    <label class="pull-right">Vauxhall</label>
                                </div>
                            </div>

                            <div class="col-sm-6 col-md-6 col-lg-6">
                                <div class="form-groupA">
                                    <label class="pull-left">Fuel type</label>
                                    <label class="pull-right">Petrol</label>
                                </div>
                            </div>--%>
                        </div>
                    </div>

                    <div class="col-sm-3 col-md-3 col-lg-3">
                        <p>
                            <strong>Ad Code: </strong><span>
                                <asp:Label ID="lbl_ID_Ads" runat="server"></asp:Label></span>
                        </p>
                        <p>
                            <strong>Location: </strong>&nbsp;<span>
                        <asp:Label ID="lblLocation" runat="server" Text=""></asp:Label></span>
                        </p>
                        <p>
                             <strong>
                                 <asp:Label ID="lblWebsiteLink" runat="server" Text=""></asp:Label></strong>&nbsp;<span>
                         <a id="hrefwebUrl" runat="server" target="_blank">
                        <asp:Label ID="lblwebUrl" runat="server" Text=""></asp:Label>
                        </a></span></p>
                       <p> <span>
                             <strong>
                                 <asp:Label ID="lblYoutubelink" runat="server" Text=""></asp:Label> </strong>&nbsp;
                         <a id="hrefyouTubeUrl" runat="server" target="_blank">
                           
                        <asp:Label ID="lblyoutube" runat="server" Text=""></asp:Label>
                        </a></span></p>
                    </div>

                    <div class="col-sm-3 col-md-3 col-lg-3 sideBar pull-right">

                        <div class="postedInfo">

                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>

                                    <div class="postedInfoInner contactBox">
                                        <h3>Contact with Ad Giver</h3>
                                        <h5>
                                            <asp:LinkButton ID="lnkContact" runat="server" class="glyphicon glyphicon-earphone" CommandArgument="" CommandName="ContactInfo" OnCommand="lnkContact_Command" Text=""> Click Here For Show Contact</asp:LinkButton><br>
                                            <span id="show">
                                                <asp:Label ID="lblContactNumber" runat="server" Text=""></asp:Label><br>
                                                <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label>
                                            </span>
                                        </h5>

                                        <asp:HiddenField ID="hdContactInfo" runat="server" />

                                        <div class="form-group ">
                                            <asp:HiddenField ID="hdfvrt" runat="server" />
                                            <asp:Button ID="btnFvrt" runat="server" Text="Favourites" class="btn btn-default btn-md glyphicon glyphicon-star" OnClick="btnFvrt_Click" />
                                            <a href="ReportingPage" class="btn btn-default btn-md pull-right">
                                                <span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span>
                                                Reporting
                                            </a>

                                        </div>
                                        <asp:Label ID="lblFvrt" runat="server" Text=""></asp:Label>
                                    </div>

                                </ContentTemplate>
                            </asp:UpdatePanel>
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
                        <!-- Indicators -->
                        <!-- Wrapper for slides -->
                        <div class="carousel-inner saftyBox " style="border: 1px solid green; margin-top: 2%; height: 268px">

                            <div role="tabpanel" class="tab-pane" id="Map">

                                <div class="item active" id="map_canvas" style="border-top: none; width: 100%; height: 480px; background-color: #FAFAFA;">
                                </div>
                            </div>









                        </div>
                        <div class="clearfix"></div>
                        <!-- Controls -->

                    </div>



                    <div class="row productDecpart">
                        <div class="col-sm-8 col-md-8 col-lg-8">
                            <h3>Description</h3>
                            <p>
                                <asp:Literal ID="ltr_Description_Ads" runat="server">
                                </asp:Literal>
                            </p>

                        </div>
                    </div>

                </div>
            </div>




            <div class="row similarProductWrp">
                <h3>You may also choose the right more …</h3>
                <div class="row">
                    <asp:Repeater ID="rp_all_relateds" runat="server">
                        <ItemTemplate>

                            <div class="col-xs-4 col-md-2 col-lg-2">
                                <div class="similarProduct">
                                    <div class="img-thumbnail">
                                        <%--<a runat="server" href='<%#"DetailPage?ID="+Eval("IID") %>'>--%>
                                        <a href='<%#"DetailPage?option="+OH.Utilities.StringCipher.Encrypt(Eval("IID").ToString()) %>'>
                                            <asp:Image class="img-responsive" runat="server" ID="img_AdDetails" Width="170" Height="180" ImageUrl='<%# Eval("ImageUrl") %>' alt="Image" />
                                        </a>
                                        <span class="pricePart2"><%#(char)2547%><%# Eval("Price", "{0:0.00}") %></span>
                                    </div>
                                    <p>
                                        <a href='<%#"DetailPage?option="+OH.Utilities.StringCipher.Encrypt(Eval("IID").ToString()) %>'><%# Eval("TitleName") %></a>
                                    </p>
                                    <p><%# Eval("CurrentLocation") %></p>
                                    <p><%#Eval("AdDate") %></p>
                                </div>
                            </div>

                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>

    </section>
    <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?key=AIzaSyD4IuRFVcMjWo1qWvBrS3v4uvDXcCiq_c4&sensor=false"></script>
    
    <script type="text/javascript">
        $(document).ready(function () {
            $.noConflict();
            $('.jqzoom').jqzoom({
                zoomType: 'standard',
                lens: true,
                preloadImages: false,
                alwaysOn: false
            });
        });
    </script>
</asp:Content>
