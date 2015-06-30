<%@ Page Title="" Language="C#" MasterPageFile="~/BookHomeMaster.Master" ValidateRequest="true" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="OB.Web.Default" %>

<%@ Import Namespace="OB.Utilities" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="mainpageBody">
        
        <div class="container">
            <div class="row">
                <div class="col-sm-6 col-md-6 col-lg-6">
                    <div class="row">
                        <div id="bannerSlide" style="border-radius: 10px; background: #520C0C; width: 560px; height: 270px; margin-left: 10px;" class="carousel slide" data-ride="carousel">
                            <div class="carousel-inner">
                                 
                                <div class="item active">
                                    <div class="col-md-12">
                                        <div class="col-lg-8" style="color: white">
                                            <h2>
                                                <b>BEST SELLERS</b>
                                              
                                            </h2>
                                            <h3 style="font-style: italic">Special offers!
                                            </h3>
                                            <a runat="server" id="ancBsActiveBookName" href="#" target="_blank">
                                                <h4>
                                                    <asp:Label runat="server" ID="lblBsActiveBookName"></asp:Label>
                                                </h4>
                                            </a>
                                            <h5>

                                                <b>By:</b>
                                                <a runat="server" id="ancBsActiveAuthorLink" href="#" target="_blank">
                                                    <asp:Label runat="server" ID="lblBsActiveAuthorName" />
                                                </a>

                                            </h5>

                                            <p>
                                                <asp:Label runat="server" ID="lblBsActiveAbstruct"></asp:Label>
                                            </p>
                                        </div>
                                        <div class="col-lg-4 pull-right" style="margin-top: 25px">
                                            <a runat="server" id="ancBsActiveBookLink1" href="#" target="_blank">
                                                <asp:Image runat="server" ID="imgBsActiveBookImage" Width="180" Height="220" CssClass="img-responsive" /></a>
                                        </div>
                                    </div>
                                </div>


                                <asp:Repeater runat="server" ID="rptBsBookSlide">
                                    <ItemTemplate>
                                        <div class="item">
                                            <div class="col-md-12">
                                                <div class="col-lg-8" style="color: white">
                                                    <h2>
                                                        <b>BEST SELLERS</b>
                                                    </h2>
                                                    <h3 style="font-style: italic">Special offers!
                                                    </h3>
                                                    <h4>
                                                        <a target="_blank" runat="server" href='<%#"BookDetails?ID="+Eval("IID") %>'>
                                                            <%# Eval("BookTitle") %>
                                                        </a>
                                                    </h4>
                                                    <h5>

                                                        <b>By:</b> <a target="_blank" href="AuthBiographyPage?ID=<%# Eval("AuthorID") %>"><%# Eval("AuthorName") %> </a>
                                                    </h5>
                                                    <p>
                                                        <%# Eval("Abstract") %>
                                                    </p>
                                                </div>
                                                <div class="col-lg-4 pull-right" style="margin-top: 25px">
                                                    <a target="_blank" runat="server" href='<%#"BookDetails?ID="+Eval("IID") %>'>
                                                        <asp:Image runat="server" CssClass="img-responsive" Width="180" Height="220" ImageUrl='<%# Eval("ImageUrl") %>' /></a>
                                                </div>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>


                            </div>
                            <a class="left carousel-control" style="background-image: none" href="#bannerSlide" role="button" data-slide="prev">
                                <span class="glyphicon glyphicon-chevron-left" style="left: 10%;" aria-hidden="true"></span>
                                <span class="sr-only">Previous</span>
                            </a>
                            <a class="right carousel-control" style="background-image: none" href="#bannerSlide" role="button" data-slide="next">
                                <span class="glyphicon glyphicon-chevron-right" style="right: 10%" aria-hidden="true"></span>
                                <span class="sr-only">Next</span>
                            </a>
                        </div>
                    </div>


                    <div class="row">
                        <div class="publComp">
                            <asp:Repeater ID="rpPublisher" runat="server" OnItemDataBound="rpPublisher_OnItemDataBound">
                                <ItemTemplate>


                                    <div class="col-sm-3 col-md-3 col-lg-3">
                                        <div class="img-responsive">
                                            <a runat="server" href='<%#"PublisherDetailPage?ID="+Eval("IID") %>'>
                                                <asp:Image runat="server" ID="img_PublisherLogo" CssClass="img-responsive" ImageUrl='<%# Eval("ImageUrl") %>' alt="Image" />

                                            </a>
                                            <%-- <p>
                                                <asp:Literal ID="ltrPublisherName" runat="server" Text=' <%# Eval("PublisherName") %>'></asp:Literal>
                                            </p>--%>
                                        </div>

                                    </div>

                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>

                    <div class="row">
                        <div role="tabpanel" class="tabingPart">
                            <!-- Nav tabs -->
                            <ul class="nav nav-tabs" role="tablist">
                                <li role="presentation" class="active"><a href="#comingSoon" aria-controls="comingSoon" role="tab" data-toggle="tab">Coming soon...</a></li>
                                <li role="presentation"><a href="#latest" aria-controls="latest" role="tab" data-toggle="tab">Latest</a></li>
                                <li role="presentation"><a href="#favourite" aria-controls="favourite" role="tab" data-toggle="tab">Most favourite</a></li>
                            </ul>
                            <!-- Tab panes -->
                            <div class="tab-content">
                                <div role="tabpanel" class="tab-pane active" id="comingSoon">
                                    <div id="myCarousel2" class="carousel slide" style="width: 560px; margin-left: 10px" data-ride="carousel">
                                        <%--<div class="controlPart">
                                            <div class="carouselPart">
                                                <a class="left carousel-control lefCaro" href="#myCarousel2" data-slide="prev"><i class="fa fa-chevron-left fa-2x"></i></a>
                                                <a class="right carousel-control rightCaro" href="#myCarousel2" data-slide="next"><i class="fa fa-chevron-right fa-2x"></i></a>
                                            </div>
                                        </div>--%>

                                        <div class="carousel-inner">
                                            <div class="item active">
                                                <asp:Repeater runat="server" ID="rptComingSoonActiveSlide">
                                                    <ItemTemplate>
                                                        <div class="col-md-6">
                                                            <div class="thumbnail productBox2">
                                                                 <a runat="server" href='<%#"BookDetails?ID="+Eval("IID") %>'>
                                                                <asp:Image runat="server" Height="165" Width="150" ImageUrl='<%# Eval("ImageUrl") %>' />
                                                               
                                                                    <h4><%# Eval("BookTitle") %></h4>
                                                                </a>
                                                                <p><%# Eval("Abstract") %></p>
                                                            </div>
                                                            <h5>TK <%# Eval("Price","{0:0.##}") %></h5>
                                                            <input id="input-id" type="number" readonly="readonly" value='<%# Eval("AvgRating") %>' class="rating" min="0" max="5" step="0.1" data-size="xs" />
                                                            <%# Eval("NumberOfUsersRate") %> Vote(s)
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </div>
                                            <div class="item">
                                                <asp:Repeater runat="server" ID="rptComingSoonSlide">
                                                    <ItemTemplate>
                                                        <div class="col-md-6">
                                                            <div class="thumbnail productBox2">
                                                                 <a runat="server" href='<%#"BookDetails?ID="+Eval("IID") %>'>
                                                                <asp:Image runat="server" Height="165" Width="150" ImageUrl='<%# Eval("ImageUrl") %>' />
                                                               
                                                                    <h4><%# Eval("BookTitle") %></h4>
                                                                </a>
                                                                <p><%# Eval("Abstract") %></p>
                                                            </div>
                                                            <h5>TK <%# Eval("Price","{0:0.##}") %></h5>
                                                            <input id="input-id" type="number" readonly="readonly" value='<%# Eval("AvgRating") %>' class="rating" min="0" max="5" step="0.1" data-size="xs" />
                                                            <%# Eval("NumberOfUsersRate") %> Vote(s)
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:Repeater>

                                            </div>


                                        </div>
                                        <a class="left carousel-control" href="#myCarousel2" role="button" data-slide="prev">
                                            <span class="glyphicon glyphicon-chevron-left" style="left: 10%" aria-hidden="true"></span>
                                            <span class="sr-only">Previous</span>
                                        </a>
                                        <a class="right carousel-control" href="#myCarousel2" role="button" data-slide="next">
                                            <span class="glyphicon glyphicon-chevron-right" style="right: 10%" aria-hidden="true"></span>
                                            <span class="sr-only">Next</span>
                                        </a>
                                    </div>

                                    <!-- Controls -->

                                </div>

                                <div role="tabpanel" class="tab-pane" id="latest">
                                    <div id="myCarousel3" class="carousel slide" style="width: 560px; margin-left: 10px" data-ride="carousel">
                                        <div class="carousel-inner">
                                            <div class="item active">
                                                <asp:Repeater runat="server" ID="rptLatestActiveSlide">
                                                    <ItemTemplate>
                                                        <div class="col-md-6">
                                                            <div class="thumbnail productBox2">
                                                                <a runat="server" href='<%#"BookDetails?ID="+Eval("IID") %>'>
                                                                <asp:Image runat="server" Height="165" Width="150" ImageUrl='<%# Eval("ImageUrl") %>' />
                                                                
                                                                    <h4><%# Eval("BookTitle") %></h4>
                                                                </a>
                                                                <p><%# Eval("Abstract") %></p>
                                                            </div>
                                                            <h5>TK <%# Eval("Price","{0:0.##}") %></h5>
                                                            <input id="input-id" type="number" readonly="readonly" value='<%# Eval("AvgRating") %>' class="rating" min="0" max="5" step="0.1" data-size="xs" />
                                                            <%# Eval("NumberOfUsersRate") %> Vote(s)
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </div>
                                            <div class="item">
                                                <asp:Repeater runat="server" ID="rptLatestSlide">
                                                    <ItemTemplate>
                                                        <div class="col-md-6">
                                                            <div class="thumbnail productBox2">
                                                                     <a runat="server" href='<%#"BookDetails?ID="+Eval("IID") %>'>
                                                                <asp:Image runat="server" Height="165" Width="150" ImageUrl='<%# Eval("ImageUrl") %>' />
                                                           
                                                                    <h4><%# Eval("BookTitle") %></h4>
                                                                </a>
                                                                <p><%# Eval("Abstract") %></p>
                                                            </div>
                                                            <h5>TK <%# Eval("Price","{0:0.##}") %></h5>
                                                            <input id="input-id" type="number" readonly="readonly" value='<%# Eval("AvgRating") %>' class="rating" min="0" max="5" step="0.1" data-size="xs" />
                                                            <%# Eval("NumberOfUsersRate") %> Vote(s)
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:Repeater>

                                            </div>

                                        </div>
                                        <a class="left carousel-control" href="#myCarousel3" role="button" data-slide="prev">
                                            <span class="glyphicon glyphicon-chevron-left" style="left: 10%" aria-hidden="true"></span>
                                            <span class="sr-only">Previous</span>
                                        </a>
                                        <a class="right carousel-control" href="#myCarousel3" role="button" data-slide="next">
                                            <span class="glyphicon glyphicon-chevron-right" style="right: 10%" aria-hidden="true"></span>
                                            <span class="sr-only">Next</span>
                                        </a>
                                    </div>
                                </div>

                                <div role="tabpanel" class="tab-pane" id="favourite">
                                    <div id="myCarousel4" class="carousel slide" style="width: 560px; margin-left: 10px" data-ride="carousel">
                                        <div class="carousel-inner">
                                            <div class="item active">
                                                <asp:Repeater runat="server" ID="rptFavouriteActiveSlide">
                                                    <ItemTemplate>
                                                        <div class="col-md-6">
                                                            <div class="thumbnail productBox2">
                                                                 <a runat="server" href='<%#"BookDetails?ID="+Eval("IID") %>'>
                                                                <asp:Image runat="server" Height="165" Width="150" ImageUrl='<%# Eval("ImageUrl") %>' />
                                                               
                                                                    <h4><%# Eval("BookTitle") %></h4>
                                                                </a>
                                                                <p><%# Eval("Abstract") %></p>
                                                            </div>
                                                            <h5>TK <%# Eval("Price","{0:0.##}") %></h5>
                                                            <input id="input-id" type="number" readonly="readonly" value='<%# Eval("AvgRating") %>' class="rating" min="0" max="5" step="0.1" data-size="xs" />
                                                            <%# Eval("NumberOfUsersRate") %> Vote(s)
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </div>

                                            <div class="item">
                                                <asp:Repeater runat="server" ID="rptFavouriteSlide">
                                                    <ItemTemplate>
                                                        <div class="col-md-6">
                                                            <div class="thumbnail productBox2">
                                                                 <a runat="server" target="_blank" href='<%#"BookDetails?ID="+Eval("IID") %>'>
                                                                <asp:Image runat="server" Height="165" Width="150" ImageUrl='<%# Eval("ImageUrl") %>' />
                                                               
                                                                    <h4><%# Eval("BookTitle") %></h4>
                                                                </a>
                                                                <p><%# Eval("Abstract") %></p>
                                                            </div>
                                                            <h5>TK <%# Eval("Price","{0:0.##}") %></h5>
                                                            <input id="input-id" type="number" readonly="readonly" value='<%# Eval("AvgRating") %>' class="rating" min="0" max="5" step="0.1" data-size="xs" />
                                                            <%# Eval("NumberOfUsersRate") %> Vote(s)
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </div>


                                        </div>
                                        <a class="left carousel-control" href="#myCarousel4" role="button" data-slide="prev">
                                            <span class="glyphicon glyphicon-chevron-left" style="left: 10%" aria-hidden="true"></span>
                                            <span class="sr-only">Previous</span>
                                        </a>
                                        <a class="right carousel-control" href="#myCarousel4" role="button" data-slide="next">
                                            <span class="glyphicon glyphicon-chevron-right" style="right: 10%" aria-hidden="true"></span>
                                            <span class="sr-only">Next</span>
                                        </a>
                                    </div>
                                </div>

                            </div>

                            <br />
                            <div class="col-xs-12">
                                <p class="text-danger text-right"><a href="TopBooks">View all</a></p>
                             
                            </div>

                        </div>
                    </div>

                </div>
                <div class="col-sm-6 col-md-6 col-lg-6">

                    <div class="col-sm-12 col-md-6 col-lg-6">
                        <div class="contentPart">


                            <div class="row">
                                <div class="linkitem"><a href="TopBooks.aspx">Top Chart</a></div>
                                <div class="col-xs-12" style="margin-left: 25px">
                                    <ol>
                                        <asp:Repeater runat="server" ID="rptBookTopChart">
                                            <ItemTemplate>
                                                <li>
                                                    <a target="_blank" href="BookDetails?ID=<%# Eval("IID") %>">
                                                        <%# Eval("BookTitle") %> 
                                                    </a>by <a target="_blank" href="AuthBiographyPage?ID=<%# Eval("AuthorID") %>"><%# Eval("BookAuthor.AuthorName") %></a>
                                                </li>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ol>
                                </div>
                            </div>

                            <div class="row">
                                <div class="linkitem"><a href="TopBooks.aspx">Best Offer</a></div>
                                <div class="col-xs-12" style="margin-left: 25px">
                                    <ol>
                                        <asp:Repeater runat="server" ID="rptBestOfferTopFive">
                                            <ItemTemplate>
                                                <li>
                                                    <a target="_blank" href="BookDetails?ID=<%# Eval("IID") %>">
                                                        <%# Eval("BookTitle") %> 
                                                    </a>by <a target="_blank" href="AuthBiographyPage?ID=<%# Eval("AuthorID") %>"><%# Eval("BookAuthor.AuthorName") %></a>
                                                </li>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ol>
                                </div>
                            </div>

                            <div class="row">
                                <div class="linkitem"><a href="TopBooks.aspx">Most Viewed</a></div>
                                <div class="col-xs-12" style="margin-left: 25px">
                                    <ol>
                                        <asp:Repeater runat="server" ID="rptMostViewedTopFive">
                                            <ItemTemplate>
                                                <li>
                                                    <a target="_blank" href="BookDetails?ID=<%# Eval("IID") %>">
                                                        <%# Eval("BookTitle") %> 
                                                    </a>by <a target="_blank" href="AuthBiographyPage?ID=<%# Eval("AuthorID") %>"><%# Eval("BookAuthor.AuthorName") %></a>
                                                </li>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ol>
                                </div>
                            </div>


                            <%--<h3>OiiO Radio</h3>
                            <img class="img-responsive" src="../Images/Interfaces/13.png" alt="img" />
                            <p>Lorem Ipsum is simply dummy text of the printing and typese...</p>
                            <p class="text-danger text-right"><a href="#">Readmore</a></p>--%>
                            <%-- <h3>OiiO TV</h3>
                            <p>Lorem Ipsum is simply dummy</p>
                            <div class="videoPart">
                                <img class="img-responsive" src="../Images/Interfaces/12.png" alt="img" />
                            </div>
                            <p>Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's since the 1500s, </p>
                            <p class="text-danger text-right"><a href="#">Readmore</a></p>--%>
                        </div>
                    </div>

                    <div class="col-sm-12 col-md-6 col-lg-6">
                        <div class="contentPart">
                            <h3>Welcome to OiiO Book</h3>
                            <p>OiiO Bookshop is a large collection of the latest bestsellers, fiction, non-fiction, children's books, revision guides etc...</p>

                            <asp:Repeater runat="server" ID="rptBookCategoryAside">
                                <ItemTemplate>

                                    <div class="imgPart">
                                        <a href="<%# Eval("catLink")%><%# StringCipher.Encrypt(Eval("IID").ToString())%>">
                                            &nbsp;<%# Eval("CategoryName")%>
                                        </a>
                                        <asp:Image runat="server" CssClass="img-responsive" ImageUrl='<%# Eval("ImageUrl")%>' />
                                    </div>

                                </ItemTemplate>
                            </asp:Repeater>
                            <%--   <p class="text-danger text-right"><a href="#">View all</a></p>--%>

                            <div class="newsLatter">
                                <h3>Newsletter</h3>
                                <%--   <input type="text" class="form-control" placeholder="Enter your E-mail">--%>
                                <asp:TextBox ID="txtEmailAdd" runat="server" class="form-control" placeholder="Enter your E-mail"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rbfEmail" runat="server" ControlToValidate="txtEmailAdd"
                                    ForeColor="Red" ToolTip="Please enter your email" ErrorMessage="Please enter your email" Display="Dynamic" ValidationGroup="vG">*
                                </asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="rxvEmail" runat="server" Display="Dynamic"
                                    ErrorMessage="Please Enter Valid E-mail" ControlToValidate="txtEmailAdd"
                                    ValidationExpression="[-0-9a-zA-Z.+_]+@[-0-9a-zA-Z.+_]+\.[a-zA-Z]{2,4}" ForeColor="Red" ValidationGroup="vG">
                                </asp:RegularExpressionValidator>
                                <asp:HiddenField ID="hdIsDelete" runat="server" />
                                <asp:HiddenField ID="hdIsEdit" runat="server" />
                                <asp:HiddenField ID="hdEmailID" runat="server" />
                                <p>
                                    <%-- <a href="#" class="pull-left">Unsubscribe</a>--%>
                                    <%--   <input type="submit" class="btn btn-default oiioBtn pull-right" value="subscribe">--%>

                                    <asp:Button ID="btn_subscribe" runat="server" Text="subscribe" ValidationGroup="vG" class="btn btn-default  pull-right" ForeColor="Red" OnClick="btn_subscribe_Click" />
                                </p>
                                <asp:Label ID="lblEmailSubscribe" runat="server" Text=""></asp:Label>
                                <asp:ValidationSummary
                                    ShowMessageBox="true"
                                    ShowSummary="false"
                                    HeaderText="You must enter a value in the following fields:"
                                    EnableClientScript="true"
                                    runat="server" ValidationGroup="vG" />

                            </div>
                        </div>

                    </div>


                </div>
            </div>
        </div>
    </div>

</asp:Content>

