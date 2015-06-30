<%@ Page Title="" Language="C#" MasterPageFile="~/OiiOMasterPage.Master" AutoEventWireup="true" CodeBehind="NewsAndCommunity.aspx.cs" Inherits="OMart.Web.NewsAndCommunity" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="DefaultPageSlide" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <section>
        <div class="container-fluid bannerWrp mortagesPage">
            <div class="container">
                <div class="row">
                    <div class="col-sm-8 col-md-8 col-lg-8">
                        <div class="bannerLeftWrp">
                            <img src="Images/banner/8.jpg" height="352" alt="img" />
                            <div class="bannerNewsComm">

                                <h1>
                                    <span>News</span>
                                    <span>&</span>
                                    <span>Community</span>
                                </h1>
                                <div class="newsBox">
                                    <p style="color: darkblue;">
                                        What it NEEDS to be - helping other people, plain and simple. Stop and think honestly for a moment. When you volunteer for community service, are you really volunteering to serve the community?
                                         Or are you just serving yourself? Let's stand together and make a change - not in the things we do, but in why we do them.
                                    </p>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-4 col-md-4 col-lg-4">
                        <div class="bannerRight">
                           <%--  <div class="banRbox">
                                <h3>Newsletter</h3>
                                <input type="text" class="form-control" placeholder="Enter your E-mail" />
                                <p>
                                    <span>
                                        <a href="UnSubscribe" class="pull-left">Unsubscribe</a>

                                    </span>
                                    <span style="color:white;">
                                        <a href="#" class="btn btn-success pull-right">Subscribe</a>

                                    </span>
                                </p>
                            </div>--%>
                                    <div class="banRbox">
                                        <h3>Newsletter</h3>
                                        <%--   <input type="text" class="form-control" placeholder="Enter your E-mail">--%>
                                        <asp:TextBox ID="txtEmailAdd" runat="server" class="form-control" placeholder="Enter your E-mail"></asp:TextBox>

                                        <asp:RequiredFieldValidator ID="rbfEmail" runat="server" ControlToValidate="txtEmailAdd"
                                            ForeColor="Red" ToolTip="Please enter your email" ErrorMessage="Please enter your email" Display="Dynamic" ValidationGroup="vG">
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
                                    <div class="banRbox">
                                        <h4>Share this page:</h4>
                                        <a href="#">
                                            <img src="Images/Interfaces/icon11.png" alt="img" /></a>
                                        <a href="#">
                                            <img src="Images/Interfaces/icon12.png" alt="img" /></a>

                                        <a href="#">
                                            <img src="Images/Interfaces/icon13.png" alt="img" /></a>

                                        <a href="#">
                                            <img src="Images/Interfaces/icon14.png" alt="img" /></a>

                                        <a href="#">
                                            <img src="Images/Interfaces/icon15.png" alt="img" /></a>


                                    </div>
                                    <div class="banRbox commUnity">
                                        <h4>OiiO Mart in the community</h4>
                                        <img src="Images/Interfaces/0426.png" alt="img" />
                                        <p>OiiO Mart.com supports local charities through fundraising events and activities.</p>
                                        <p><a class="pull-right" href="#">Read more </a></p>
                                    </div>
                            </div>
                        </div>
                    </div>
                </div>




            </div>
    </section>
    <section>
        <div class=" container">
            <%--<div class="row newsMenupart">
                <div class="col-xs-2">
                    <a href="#">
                        <img src="Images/Interfaces/icon16.png" alt="img" />
                        <span>Money Fonum</span>
                    </a>
                </div>
                <div class="col-xs-2">
                    <a href="#">
                        <img src="Images/Interfaces/icon17.png" alt="img" />
                        <span>Money Fonum</span>
                    </a>
                </div>
                <div class="col-xs-2">
                    <a href="#">
                        <img src="Images/Interfaces/icon18.png" alt="img" />
                        <span>Fonum Home</span>
                    </a>
                </div>
                <div class="col-xs-2">
                    <a href="#">
                        <img src="Images/Interfaces/icon19.png" alt="img" />
                        <span>Mobile Phone Fonum </span>
                    </a>
                </div>
                <div class="col-xs-2">
                    <a href="#">
                        <img src="Images/Interfaces/icon20.png" alt="img" />
                        <span>Insurance Fonum </span>
                    </a>
                </div>
                <div class="col-xs-2">
                    <a href="#">
                        <img src="Images/Interfaces/icon21.png" alt="img" />
                        <span>Broadband Fonum </span>
                    </a>
                </div>
            </div>--%>
            <div class="row">

                <%--  <a runat="server" href='<%#"LoanDescriptionDetails?ID="+Eval("IID") %>'>
                            <asp:Literal ID="lblNewsType" runat="server" Text=' <%# Eval("NewsType") %>'></asp:Literal>
                           <asp:Image ID="img_inner" runat="server" Width="100%" ImageUrl='<%# Eval("ImageUrl")%>' AlternateText="img" />

                        </a>--%>

                <div class="col-sm-4 col-md-4 col-lg-4">
                    <div class="newsItem">
                        <h3>News</h3>

                        <asp:Repeater ID="rpNews" runat="server" OnItemDataBound="rpNews_OnItemDataBound">
                            <ItemTemplate>

                                <div class="newsItemInner">
                                    <div class="col-xs-2">
                                        <asp:Image ID="img_inner" runat="server" Width="50px" Height="45" ImageUrl='<%# Eval("Image")%>' AlternateText="img" />

                                    </div>
                                    <div class="col-xs-10 newsItemPart">

                                        <h4>
                                            <asp:Literal ID="lblHeadline" runat="server" Text=' <%# Eval("HeadLine") %>'></asp:Literal></h4>

                                        <p>
                                            <asp:Literal ID="lblNewsDescription" runat="server" Text=' <%# Eval("NewsDescription").ToString().Substring(0,100) %>'></asp:Literal>
                                            <a runat="server" href='<%#"AllCommunityNewsDetails?ID="+Utilities.StringCipher.Encrypt(Eval("IID").ToString())%>'>Read more</a>
                                        </p>
                                        <p>
                                            <%# Eval("NewsType") %>
                                            <%-- <asp:Literal ID="lblNewsType" runat="server" Text=' <%# Eval("NewsType") %>'></asp:Literal>--%>
                                        </p>
                                        <p>
                                            Updated On:<%# Eval("PublishDate","{0:dd-MMM-yyyy}") %><%--<asp:Literal ID="lblPublishDate" runat="server" Text='<%# Eval("PublishDate","{0:dd-MMM-yyyy}") %>'> </asp:Literal>
                                            --%></p>
                                    </div>
                                    <div class="clearfix"></div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>

                        <%--  <a class="showAllNews" runat="server" href="AllCommunityNewsDetails.aspx">Show all News</a>
                        <div class="clearfix"></div>--%>
                    </div>
                </div>

                <div class="col-sm-4 col-md-4 col-lg-4">
                    <div class="newsItem">
                        <h3>Videos</h3>
                        <asp:Repeater ID="rpVideo" runat="server" OnItemDataBound="rpVideo_OnItemDataBound">
                            <ItemTemplate>
                                <div class="newsItemInner videoPart">
                                    <h4>
                                        <asp:Literal ID="lblHeadline" runat="server" Text=' <%# Eval("HeadLine") %>'></asp:Literal></h4>

                                    <iframe width="160" height="80" src='<%#Eval("VideoLink")%>'></iframe>

                                    <p class="datePost">
                                        <%# Eval("PublishDate","{0:dd-MMM-yyyy}") %>
                                        <%--  <asp:Label ID="lblPublishDate" runat="server" Text='<%# Eval("PublishDate","{0:dd-MMM-yyyy}") %>'> </asp:Label>--%>
                                    </p>
                                    <p>
                                        <asp:Literal ID="lblNewsDescription" runat="server" Text=' <%# Eval("NewsDescription").ToString().Substring(0,90) %>'></asp:Literal>
                                        <a class="text-danger" runat="server" href='<%#"AllCommunityNewsDetails?ID="+Utilities.StringCipher.Encrypt(Eval("IID").ToString())%>'>Read more</a>
                                    </p>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                        <%--  <a class="showAllNews" runat="server" href="AllVideosDetails.aspx">Show all videos</a>
                        <div class="clearfix"></div>--%>
                    </div>
                </div>

                <div class="col-sm-4 col-md-4 col-lg-4">
                    <div class="newsItem">
                        <h3>Sports</h3>
                        <asp:Repeater ID="rpSports" runat="server" OnItemDataBound="rpSports_OnItemDataBound">
                            <ItemTemplate>
                                <div class="newsItemInner videoPart">
                                    <asp:Image ID="img_inner" runat="server" Width="339px" Height="73px" ImageUrl='<%# Eval("Image")%>' AlternateText="img" />


                                    <h4>
                                        <asp:Literal ID="lblHeadline" runat="server" Text=' <%# Eval("HeadLine") %>'></asp:Literal>

                                        &nbsp; &nbsp;&nbsp;(Date: <%# Eval("PublishDate","{0:dd-MMM-yyyy}") %>)
                                    </h4>

                                    <%--   <p class="datePost">
                                       
                                           <%# Eval("PublishDate","{0:dd-MMM-yyyy}") %>
                                    </p>--%>
                                    <p>
                                        <asp:Literal ID="lblNewsDescription" runat="server" Text=' <%# Eval("NewsDescription").ToString().Substring(0,45) %>'></asp:Literal>
                                        <a class="text-danger" runat="server" href='<%#"AllCommunityNewsDetails?ID="+Utilities.StringCipher.Encrypt(Eval("IID").ToString())%>'>Read more</a>
                                    </p>
                                </div>

                            </ItemTemplate>
                        </asp:Repeater>
                        <%-- <a class="showAllNews" runat="server" href='<%#"AllNewsDetails?ID="+Utilities.EnumCollection.NewsType.Sports.ToString() %>'>Show all Sports</a>--%>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="newsItem2">
                    <%--  <asp:Repeater ID="rpNewsType" runat="server" OnItemDataBound="rpNewsType_OnItemDataBound">
                        <ItemTemplate>
                            <div class="col-sm-4 col-sm-4 col-lg-4">
                                <h3> <asp:Literal ID="ltrNewsType" runat="server" Text=' <%# Eval("NewsType") %>'></asp:Literal></h4>
                             </h3>
                                <div class="newsItem2Inner">

                                   <asp:Image ID="img_inner" runat="server" Width="100%" ImageUrl='<%# Eval("Image")%>' AlternateText="img" />

                                    <h4> <asp:Literal ID="ltrHeadline" runat="server" Text=' <%# Eval("HeadLine") %>'></asp:Literal></h4>
                              </h4>
                                    <asp:Literal ID="lblNewsDescription" runat="server" Text=' <%# Eval("NewsDescription") %>'></asp:Literal>
                                    <a class="text-danger" runat="server" href='<%#"VideosDetails?ID="+Eval("IID") %>'>Read more</a>

                                    <div class="clearfix"></div>
                                </div>


                            </div>
                        </ItemTemplate>
                    </asp:Repeater>--%>
                    <div class="col-sm-4 col-sm-4 col-lg-4">
                        <h3>Education</h3>
                        <asp:Repeater ID="rpEducation" runat="server" OnItemDataBound="rpEducation_OnItemDataBound">
                            <ItemTemplate>
                                <div class="newsItem2Inner">

                                    <asp:Image ID="img_inner" runat="server" Width="140" Height="96" ImageUrl='<%# Eval("Image")%>' AlternateText="img" />

                                    <h4>
                                        <asp:Literal ID="lblHeadline" runat="server" Text=' <%# Eval("HeadLine") %>'></asp:Literal></h4>
                                    </h4>
                                      <p>
                                          <asp:Literal ID="lblNewsDescription" runat="server" Text=' <%# Eval("NewsDescription") %>'></asp:Literal>

                                      </p>
                                    <a class="text-danger" runat="server" href='<%#"AllCommunityNewsDetails?ID="+Utilities.StringCipher.Encrypt(Eval("IID").ToString())%>'>Read more</a>
                                    <div class="clearfix"></div>
                                </div>

                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <div class="col-sm-4 col-sm-4 col-lg-4 recreation">
                        <h3>Recreation</h3>
                        <asp:Repeater ID="rpRecreation" runat="server" OnItemDataBound="rpRecreation_OnItemDataBound">
                            <ItemTemplate>
                                <div class="newsItem2Inner">

                                    <%-- <asp:Image ID="img_inner" runat="server" Width="100%" ImageUrl='<%# Eval("Image")%>' AlternateText="img" />--%>

                                    <h4>
                                        <asp:Literal ID="lblHeadline" runat="server" Text=' <%# Eval("HeadLine") %>'></asp:Literal></h4>
                                    </h4>
                                      <p>
                                          <asp:Literal ID="lblNewsDescription" runat="server" Text=' <%# Eval("NewsDescription") %>'></asp:Literal>

                                      </p>
                                    <a class="text-danger" runat="server" href='<%#"AllCommunityNewsDetails?ID="+Utilities.StringCipher.Encrypt(Eval("IID").ToString())%>'>Read more</a>
                                    <div class="clearfix"></div>
                                </div>

                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <div class="col-sm-4 col-sm-4 col-lg-4 mostPopular">
                        <h3>Most Popular</h3>
                        <div class="newsItem2Inner">

                            <asp:Repeater ID="rpMostPopular" runat="server" OnItemDataBound="rpMostPopular_OnItemDataBound">
                                <ItemTemplate>
                                    <div class="newsItem2Inner">

                                        <asp:Image ID="img_inner" runat="server" Width="103" Height="89" ImageUrl='<%# Eval("Image")%>' AlternateText="img" />

                                        <h4>
                                            <asp:Literal ID="lblHeadline" runat="server" Text=' <%# Eval("HeadLine") %>'></asp:Literal></h4>
                                        </h4>
                                      <p>
                                          <asp:Literal ID="lblNewsDescription" runat="server" Text=' <%# Eval("NewsDescription") %>'></asp:Literal>

                                      </p>
                                        <a class="text-danger" runat="server" href='<%#"AllCommunityNewsDetails?ID="+Utilities.StringCipher.Encrypt(Eval("IID").ToString())%>'>Read more</a>
                                        <div class="clearfix"></div>
                                    </div>

                                </ItemTemplate>
                            </asp:Repeater>
                        </div>

                        <%-- <a class="text-danger" runat="server" href="MostPopularGuidesAll.aspx">Show all</a>
                        <div class="clearfix"></div>--%>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
