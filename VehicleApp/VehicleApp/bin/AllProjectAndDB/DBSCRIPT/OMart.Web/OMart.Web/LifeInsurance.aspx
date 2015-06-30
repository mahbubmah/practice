
<%@ Page Title="Life Insurance" Language="C#" MasterPageFile="~/InsuranceMaster.master" AutoEventWireup="true" CodeBehind="LifeInsurance.aspx.cs" Inherits="OMart.Web.LifeInsurance" %>

<%@ Import Namespace="Utilities" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <section>
        <div class="container insServ lifeInsr">
            <div class="row">
                <div class="col-sm-8 col-md-8 col-lg-8">
                    <div class="lifeInsr_compPart">
                        <img src="Images/products/0429_10.png" class="img-responsive" alt="img" />
                        <h4>Let's compare Life insurance</h4>
                        <a class="btn btn-default btnQuote" href="<%=this.ResolveUrl("~/InsuranceCover.aspx")%>">Start a new quote</a>
                        <p>
                            We bring you some great deals on your life insurance from our 
panel of providers. 
                        </p>
                        <p>
                            You can call a life insurance Search advisor to discuss your cover; they'll 
answer questions and provide advice to help you decide.
                        </p>

                        <div class="clearfix"></div>
                    </div>

                </div>
                <div class="col-sm-4 col-md-4 col-lg-4">
                    <div class="lifeInsr_compPart text-center">
                        <h4>Already a customer?</h4>
                        <a class="btn btn-default btnQuote" href="Insurance_Cover.aspx">Retrieve quotes</a>

                        <p>
                            Sign in to view or edit a previous 
quote, activate your OiiO news 
membership, 
                        </p>

                        <div class="clearfix"></div>
                    </div>

                </div>
            </div>
            <div class="row">
                <div class="lifeIsr_BoxWrp">
                    <div class="col-sm-7 col-md-7 col-lg-7">
                        <div class="lifeIsr_BoxA">
                            <div class="row">
                                <div class="col-sm-6 col-md-6 col-lg-6 ">
                                    <h3>Customer ratings</h3>
                                    <img src="Images/Interfaces/0417_2.png" alt="img" />
                                    <h3>4.7/5</h3>
                                    <p>
                                        Our customers rate us 4.7/5 
based on 13587 customer 
reviews
                                    </p>
                                </div>
                                <div class="col-sm-6 col-md-6 col-lg-6 divider2">
                                    <h3>Wsmith 3 Mar 2015</h3>
                                    <img src="Images/Interfaces/0417_2.png" alt="img" />
                                    <h3>4.7/5</h3>
                                    <p>
                                        Found some great deals with just what I 
needed. Would recommend to anyone as 
so easy to do.s
                                    </p>
                                    <p><a href="#">Read all reviews</a></p>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-5 col-md-5 col-lg-5">
                        <div class="lifeIsr_BoxA">
                            <h3>We also quote for</h3>
                            <img class="quoteImg quoteImg2" src="Images/products/0429_11.png" alt="img" />


                            <ul class="nav">
                                <asp:Repeater runat="server" ID="repOtherInsurenceLinks">
                                    <ItemTemplate>
                                        <li><a href='<%# Eval("UrlWFName") %>' target="_blank"><%# Eval("UrlWFDisplayName") %></a></li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </div>
                    </div>
                    <div class="clearfix"></div>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-3 col-md-3 col-lg-3">
                    <div class="sidebar">
                        <asp:Repeater runat="server" ID="repBiInsuranceGuideLine">
                            <ItemTemplate>
                                <div class="leftsidebar_ins">
                                    <div class="leftsidebar_insInnr">
                                        <asp:Image runat="server" CssClass="img-responsive" ID="image" ImageUrl='<%# Eval("ImageUrl") %>' Height="100" Width="250" />
                                        <h3><%# Eval("Title") %></h3>
                                        <p><%# Eval("Description") %>...</p>
                                        <p><a target="_blank" href='GuideLineDetails.aspx?ID= <%#StringCipher.Encrypt(Eval("GuideLineIid").ToString())%>'>Read more</a></p>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
                <div class="col-sm-6 col-md-6 col-lg-6">
                    <asp:Repeater runat="server" ID="repInsuranceNews">
                        <ItemTemplate>
                            <div class="contentArea_ins">
                                <h3><%# Eval("TitleName") %></h3>
                                <p><%# Eval("Description") %></p>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <div class="col-sm-3 col-md-3 col-lg-3">
                    <div class="right_sidebar_ins">
                        <div class="rightSidebarA">
                            <h3>Shop</h3>
                            <p>Need more information about life insurance? Don't worry, we have a list of life insurance shop which may help with your query.</p>
                            <div class="clearfix"></div>
                        </div>

                        <div class="rightSidebarA">
                            <h3>Office</h3>
                            <p>Find the best critical illness cover and start saving money today with OiiO Mart.com. </p>
                            <div class="clearfix"></div>
                        </div>

                        <div class="rightSidebarA">
                            <h3>Hotel</h3>
                            <p>Find the best over 50s life insurance policy for you, quickly and easily, here at OiiO Mart.com.</p>
                            <div class="clearfix"></div>
                        </div>
                        <div class="rightSidebarA">
                            <h3>Pub</h3>
                            <p>Find the best over 50s life insurance policy for you, quickly and easily, here at OiiO Mart.com.</p>
                            <div class="clearfix"></div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row topLeadIns">
                <div class="col-xs-2 col-sm-2">
                    <h4>We compare quotes 
from these leading 
BD insurers and 
more...</h4>
                </div>
                <div class="col-xs-10 col-sm-10">
                    <asp:Repeater runat="server" ID="repInsuranceCompanyLogo">
                        <ItemTemplate>
                            <asp:Image CssClass="img-thumbnail img-responsive" Width="165" Height="100" runat="server" ImageUrl='<%# Eval("LogoUrl") %>' />

                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>

        </div>
    </section>

</asp:Content>

