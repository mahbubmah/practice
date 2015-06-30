<%@ Page Title="" Language="C#" MasterPageFile="~/OiiOinnerMasterPage.master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="OB.Web.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderInnerPage" runat="server">
  <div class="mainpageBody">

        <div class="container">
            <div class="row">
                <div class="col-sm-6 col-md-6 col-lg-6">
                    <div class="row">
                        <div class="col-md-12">
                            <img class="img-responsive" src="Images/Interfaces/1.png" alt="img" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="publComp">
                            <div class="col-sm-2 col-md-2 col-lg-2">
                                <img class="img-responsive" src="Images/Interfaces/2.png" alt="img" />
                            </div>
                            <div class="col-sm-2 col-md-2 col-lg-2">
                                <img class="img-responsive" src="Images/Interfaces/2_a.png" alt="img" />
                            </div>
                            <div class="col-sm-2 col-md-2 col-lg-2">
                                <img class="img-responsive" src="Images/Interfaces/2_b.png" alt="img" />
                            </div>
                            <div class="col-sm-2 col-md-2 col-lg-2">
                                <img class="img-responsive" src="Images/Interfaces/2_c.png" alt="img" />
                            </div>
                            <div class="col-sm-2 col-md-2 col-lg-2">
                                <img class="img-responsive" src="Images/Interfaces/2_d.png" alt="img" />
                            </div>
                            <div class="col-sm-2 col-md-2 col-lg-2">
                                <img class="img-responsive" src="Images/Interfaces/2_a.png" alt="img" />
                            </div>
                            <div class=" clearfix"></div>
                        </div>
                    </div>
                    <div class="row">

                        <div role="tabpanel" class="tabingPart">

                            <!-- Nav tabs -->
                            <ul class="nav nav-tabs" role="tablist">
                                <li role="presentation" class="active"><a href="#home" aria-controls="home" role="tab" data-toggle="tab">In the mood...</a></li>
                                <li role="presentation"><a href="#profile" aria-controls="profile" role="tab" data-toggle="tab">New titles</a></li>
                                <li role="presentation"><a href="#messages" aria-controls="messages" role="tab" data-toggle="tab">Most viewed</a></li>
                            </ul>

                            <!-- Tab panes -->
                            <div class="tab-content">
                                <div role="tabpanel" class="tab-pane active" id="home">
                                    <div id="myCarousel2" class="carousel slide">
                                        <div class="controlPart">
                                            <div class="carouselPart">
                                                <a class="left carousel-control lefCaro" href="#myCarousel2" data-slide="prev"><i class="fa fa-chevron-left fa-2x"></i></a>
                                                <a class="right carousel-control rightCaro" href="#myCarousel2" data-slide="next"><i class="fa fa-chevron-right fa-2x"></i></a>
                                            </div>
                                        </div>

                                        <div class="carousel-inner">
                                            <div class="item active">
                                                <div class="col-md-6">
                                                    <div class="thumbnail productBox2">

                                                        <img src="images/interfaces/10.png" alt="Slide11" />
                                                        <h3>Lorem ipsum </h3>
                                                        <p>Ipsum is simply typesetting industry.Ipsum is simply typesetting industry.</p>
                                                        <h4>$200.00</h4>
                                                        <p><a class="btn btn-success" href="#">Add to card</a></p>
                                                    </div>
                                                </div>
                                                <div class="col-md-6">
                                                    <div class="thumbnail productBox2">

                                                        <img src="images/interfaces/11.png" alt="Slide11" />
                                                        <h3>Lorem ipsum </h3>
                                                        <p>Ipsum is simply typesetting industry.Ipsum is simply typesetting industry.</p>
                                                        <h4>$200.00</h4>
                                                        <p><a class="btn btn-success" href="#">Add to card</a></p>
                                                    </div>
                                                </div>

                                            </div>
                                            <div class="item">
                                                <div class="col-md-6">
                                                    <div class="thumbnail productBox2">

                                                        <img src="images/interfaces/10.png" alt="Slide11" />
                                                        <h3>Lorem ipsum </h3>
                                                        <p>Ipsum is simply typesetting industry.Ipsum is simply typesetting industry.</p>
                                                        <h4>$200.00</h4>
                                                        <p><a class="btn btn-success" href="#">Add to card</a></p>
                                                    </div>
                                                </div>
                                                <div class="col-md-6">
                                                    <div class="thumbnail productBox2">

                                                        <img src="images/interfaces/11.png" alt="Slide11" />
                                                        <h3>Lorem ipsum </h3>
                                                        <p>Ipsum is simply typesetting industry.Ipsum is simply typesetting industry.</p>
                                                        <h4>$200.00</h4>
                                                        <p><a class="btn btn-success" href="#">Add to card</a></p>
                                                    </div>
                                                </div>

                                            </div>

                                        </div>

                                    </div>


                                </div>
                                <div role="tabpanel" class="tab-pane" id="profile">content comming soon</div>
                                <div role="tabpanel" class="tab-pane" id="messages">content comming soon</div>
                                <div role="tabpanel" class="tab-pane" id="settings">content comming soon</div>
                            </div>

                        </div>
                    </div>
                   
                </div>
                <div class="col-sm-6 col-md-6 col-lg-6">
                    
                       <div class="col-sm-12 col-md-6 col-lg-6">
                           <div class="contentPart">
                           <div class="linkitem">
                               <a href="#">Best sellers</a>
                               <a href="#">Pre Orders</a>
                               <a href="#">Best sellers</a>
                           </div>
                           <h3>OiiO TV</h3>
                           <p>Lorem Ipsum is simply dummy</p>
                               <div class="videoPart">
                                   <img class="img-responsive" src="Images/Interfaces/12.png" alt="img" />
                               </div>
                               <p>Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's since the 1500s, </p>
                               <p class="text-danger text-right"><a href="#"> Readmore</a></p>
                               </div>
                       </div>
                        <div class="col-sm-12 col-md-6 col-lg-6">
                            <div class="contentPart">
                                <h3>Welcome to OiiO Book</h3>
                                <p>Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard...</p>
                                <div class="imgPart">
                                    <a href="#">Biography</a>
                                    <img class="img-responsive" src="Images/Interfaces/14.png" alt="img" />
                                </div>
                                <div class="imgPart">
                                    <a href="#">Business</a>
                                    <img class="img-responsive" src="Images/Interfaces/15.png" alt="img" />
                                </div>
                                <p class="text-danger text-right"><a href="#"> View all</a></p>
                                <h3>newsletter</h3>
                                <input type="text" class="form-control" placeholder="Enter your E-mail" />
                                <p><a href="#">Unsubscribe</a><a class="btn btn-success pull-right" href="#">subscribe</a></p>
                                <h3>OiiO Radio</h3>
                                <img class="img-responsive" src="Images/Interfaces/13.png" alt="img" />
                                <p>Lorem Ipsum is simply dummy text of the printing and typese...</p>
                                <p class="text-danger text-right"><a href="#"> Readmore</a></p>
                                </div>
                       </div>
                        
                   
                </div>
            </div>
        </div>
    </div>

</asp:Content>

