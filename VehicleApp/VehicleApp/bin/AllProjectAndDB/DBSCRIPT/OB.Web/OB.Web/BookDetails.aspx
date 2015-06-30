<%@ Page Title="" Language="C#" MasterPageFile="~/OiiOBookDetailsInnerMasterPage.Master" AutoEventWireup="true" CodeBehind="BookDetails.aspx.cs" Inherits="OB.Web.BookDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <style type="text/css">
        .imgthumb {
            display: block;
            height: auto;
            max-width: 100%;
        }

        .imgdiv {
            background-color: White;
            margin-left: auto;
            margin-right: auto;
            padding: 10px;
            border: solid 1px #c6cfe1;
            height: 500px;
            width: 450px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderInnerPage" runat="Server">


    <div class="ContentArea commonH3titel bookDetailsWrp">

        <div class="row">
            <div class="col-xs-12">
                <div class="bookBox bookDetails">
                    <h4><span>Open</span> the Book</h4>
                    <div class="thumbnail col-xs-4">
                        <a data-toggle="modal" data-target="#myModalbook">
                            <asp:Image runat="server" ID="img_Book" Class="img-responsive" alt="Image" />
                        </a>

                        <!-- Button trigger modal -->
                        <a data-toggle="modal" data-target="#myModalbook">(Enlarge Image)
                        </a>

                        <!-- Modal book detail-->
                        <div class="modal fade" id="myModalbook" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                            <div class="modal-dialog">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                        <h4 class="modal-title " id="myModalLabel">
                                            <asp:Literal ID="modalLtr" runat="server"></asp:Literal>
                                        </h4>
                                        <p style="text-align: center;">
                                            <a runat="server" href="#" target="_blank" id="ancAuthLink1">
                                                <asp:Literal ID="modalAuth" runat="server"></asp:Literal></a>
                                        </p>
                                    </div>
                                    <div class="modal-body center-block">
                                        <div style="margin: 0 auto; width: 90%;">
                                            <asp:Image runat="server" ID="large_Image" Class="img-responsive" alt="Image" />
                                        </div>

                                    </div>
                                    <div class="clearfix"></div>
                                    <h5 style="text-align: center;">Published by
                            <asp:Literal ID="modalPub" runat="server"></asp:Literal>
                                    </h5>
                                    <div class="modal-footer">

                                        <button type="button" class="btn btn-default pull-right" data-dismiss="modal">Close</button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <h3>
                        <asp:Literal ID="ltrBookTitle" runat="server"></asp:Literal></h3>
                    <p>
                        <a runat="server" href="#" target="_blank" id="ancAuthLink2">
                            <asp:Literal ID="ltrAuthorName" runat="server"></asp:Literal>
                        </a>

                    </p>
                    <h2>Published by
                            <asp:Literal ID="ltrPublisherName" runat="server"></asp:Literal>
                    </h2>
                    <p>
                        Click below to buy direct from us or from 
a selection of other retailers
                    </p>


                    <p><a class="btn btn-success buyingBtn" data-toggle="modal" data-target="#modalBuying"><i class="fa fa-share"></i>Buying options</a></p>
                    <!--modal buying-->
                    <div class="modal fade" id="modalBuying" tabindex="-1" role="dialog" aria-labelledby="myModalLabelbuying" aria-hidden="true">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>

                                    <h2 style="text-align: center; color: green; font-style: normal; font-size: 300%" id="myModalLabelbuying">
                                        <b>Buy It Now</b>
                                    </h2>
                                </div>
                                <div class="modal-body center-block">
                                    <div class="row">
                                        <div class="col-xs-12">
                                            <div class="col-xs-7">
                                                <h5>Author: <a href="#"><asp:Label runat="server" ID="lbModalAuthorName"></asp:Label> </a></h5>
                                                <p>
                                                    Format: <asp:Label runat="server" ID="lbModalBookAvailableFormat"></asp:Label>
                                                </p>
                                                <p>
                                                    EAN: <asp:Label runat="server" ID="lbModalBookEanNo"></asp:Label>
                                                </p>
                                                <br />
                                                <h3 style="color: black">
                                                    <b>Tk. <asp:Label runat="server" ID="lbModalBookPrice"></asp:Label> </b>
                                                </h3>
                                                <hr />
                                                <asp:Button runat="server" CssClass="btn btn-success buyingBtn" Text="Buy from Random House"></asp:Button>
                                            </div>
                                            <div class="col-xs-5">
                                                 <asp:Image runat="server" ID="imgModalBookImage" CssClass="img-responsive" style="min-height: 210px"/>
                                            </div>
                                        </div>
                                    </div>
                                   
                                    <br />
                                    <div class="row">
                                        <div class="col-xs-12">
                                            <h4><b>Buy from other stores:</b> </h4>
                                            <br />
                                            <div class="col-xs-6">
                                                <ul style="margin-left: 10%">
                                                    <asp:Repeater runat="server" ID="rptOthorStoreLink1">
                                                        <ItemTemplate>
                                                            <li><a target="_blank" href="<%# Eval("Description") %>"><%# Eval("Name") %></a>
                                                            </li>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </ul>
                                            </div>
                                            <div class="col-xs-6">
                                                <ul>
                                                    <asp:Repeater runat="server" ID="rptOthorStoreLink2">
                                                        <ItemTemplate>
                                                            <li><a target="_blank" href="<%# Eval("Description") %>"><%# Eval("Name") %></a>
                                                            </li>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </ul>
                                            </div>
                                        </div>
                                    </div>
                                    <hr />
                                    <div class="row">
                                        <div class="col-xs-12">
                                            <h3><b>Find a local store</b> </h3>
                                            <br />
                                            <div class="col-sm-7">
                                                <asp:TextBox runat="server" CssClass="form-control" placeholder="Enter location.." ID="txtLocaton"></asp:TextBox>
                                            </div>
                                            &nbsp;
                                      
                                          <asp:Button runat="server" Text="Submit" CssClass="btn btn-danger" ID="btnLoation" ValidationGroup="gen" OnClick="btnLoation_OnClick" />
                                        </div>
                                    </div>
                                </div>
                                <div class="clearfix"></div>


                                <div class="modal-footer">
                                    <button type="button" class="btn btn-default pull-right" data-dismiss="modal">Close</button>
                                </div>

                            </div>
                        </div>
                    </div>

                    <h5>
                        <asp:Literal ID="ltrBookName" runat="server" Text=' <%# Eval("BookTitle") %>'></asp:Literal>
                        is also available as:</h5>

                    <h6 class="bookrefLink pull-right"><a href="#"><i class="fa fa-book "></i>
                        <asp:Literal ID="ltrwishtype" runat="server" Text=' <%# Eval("BookWishType") %>'></asp:Literal></a> <a href="#"><span class="glyphicon glyphicon-book"></span>Paperback</a> <a href="#"><i class="fa fa-headphones"></i>Audiobook</a></h6>

                </div>
                <hr />

            </div>

            <div class="col-md-12">
                <div class="panel with-nav-tabs panel-success pnlTab">
                    <div class="panel-heading">
                        <ul class="nav nav-tabs linkitem tabCompotition">
                            <li class="active"><a href="#tab1success" data-toggle="tab">About the book</a></li>
                            <li><a href="#tab2success" data-toggle="tab">Media reviews</a></li>

                        </ul>
                    </div>
                    <div class="panel-body">
                        <div class="tab-content">
                            <div class="tab-pane fade in active" id="tab1success">

                                <div id="products" class="row list-group glProducts">

                                    <div class="col-xs-12">
                                        <h4><b>Synopsis</b></h4>
                                        <br />
                                        <p>
                                            <asp:Label runat="server" ID="lblBookAbstruct"></asp:Label>

                                        </p>

                                    </div>



                                </div>
                            </div>
                            <div class="tab-pane fade" id="tab2success">

                                <div id="Div1" class="row list-group glProducts">
                                    <div class="col-xs-12">
                                        <br />
                                        <h4><b>What the critics say..</b> </h4>
                                        <br />
                                        <asp:Repeater runat="server" ID="rptMediaReviews">
                                            <ItemTemplate>
                                                <p>
                                                    <%# Eval("MediaComments") %>
                                                </p>
                                                <p>
                                                    <b>- <%# Eval("MediaName") %>
                                                    </b>
                                                </p>
                                                <br />
                                            </ItemTemplate>
                                        </asp:Repeater>

                                    </div>

                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>

            <div class="bookBoxWrp">

                <div class="row byAuthbookList">
                    <div class="col-sm-12">
                        <h3><span>By this author</span></h3>
                        <div class="well commonBg1">
                            <div class="row">

                                <asp:Repeater ID="rpByAuthor" runat="server" OnItemDataBound="rpByAuthor_OnItemDataBound">
                                    <ItemTemplate>
                                        <div class="col-xs-3 col-sm-3 col-md-3  col-lg-3">
                                            <div class="bookBox">
                                                <h4><span>Open</span> the Book</h4>
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

                            </div>
                        </div>
                    </div>

                </div>
                <%--     <div class="row authTestimonialWrp">
                    <div class="col-md-12">
                        <h3>Related Videos</h3>
                        <p>Trailers, Interviews and more</p>
                    </div>
                    <div class="col-md-12 ">
                        <div class="well">
                            <img src="Images/Interfaces/62.jpg" alt="img" />
                        </div>
                        <div class=" clearfix"></div>
                    </div>

                </div>--%>
            </div>
        </div>
    </div>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderRight" runat="Server">

    <asp:Panel ID="pnlsideRightBookDetails" runat="server">
        <div class="well commonBg1 paperbackPart">
            <h3><span class="glyphicon glyphicon-book"></span>Paperback</h3>
            <h4>Availability</h4>
            <p>
                Available for dispatch within 1-2 
                                                        working days
            </p>
            <h4>Details</h4>
            <p>EAN: 9780091919078 </p>
            <p>Published: 25 Apr 2013</p>
        </div>
        <h3>About
                                                    <asp:Literal ID="ltrAuthorNameRight" runat="server"></asp:Literal>
        </h3>
        <br />
        <asp:Image runat="server" ID="img_Book_Authr" Class="img-responsive" alt="Image" />
        <br />
        <p>
            <asp:Literal ID="ltrAbout" runat="server"></asp:Literal>
        </p>
        <p>
            <a id="lnkAuthorMore" runat="server" class="btn btn-success ">More</a>
        </p>
    </asp:Panel>
</asp:Content>

