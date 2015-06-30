<%@ Page Title="" Language="C#" MasterPageFile="~/InsuranceMaster.Master" AutoEventWireup="true" CodeBehind="CarInsuranceWF.aspx.cs" Inherits="OMart.Web.CarInsuranceWF" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
        <div class="container-fluid bannerWrp">
            <!-- Wrapper for slides -->
            <div class="carousel-inner">
                <div class="row">
                    <div class="col-sm-8 col-md-8 col-lg-8">
                        <div class="lifeInsr_compPart">
                            <img src="Images/products/0419_2.png" class="img-responsive" alt="img" />
                            <h4>Let's compare car insurance</h4>
                            <a class="btn btn-default btnQuote" href="<%=this.ResolveUrl("~/CarInsuranceQuote.aspx?Type=pnlBuzInsAbout")%>">Start a new quote</a>
                            <p>
                                We bring you some great deals on your life insurance from our 
panel of providers.
                            </p>
                            <p>
                                You can call a LifeSearch advisor to discuss your cover; they'll 
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
membership, or get your 2 
for 1 cinema voucher code.
                            </p>

                            <div class="clearfix"></div>
                        </div>

                    </div>
                </div>


            </div>


        </div>
    </section>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />


    <section>
        <div class="container insServ lifeInsr">

            <div class="row">
                <div class="lifeIsr_BoxWrp">
                    <div class="col-sm-7 col-md-7 col-lg-7">
                        <div class="lifeIsr_BoxA">
                            <div class="row">
                                <div class="col-sm-6 col-md-6 col-lg-6 ">
                                    <h3>Customer ratings</h3>
                                    <img src="Images/Interfaces/0419_3.png" alt="img" />
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
                            <img class="quoteImg" src="Images/products/0419_3.png" alt="img" />
                            <h3>We also quote for</h3>
                            <ul class="nav">

                                <asp:Repeater ID="rptInsuranceTypes" runat="server">

                                    <ItemTemplate>
                                        <li>
                                            <a href='<%#Eval("UrlWFName") %>'>
                                                <asp:Label ID="lbltype" runat="server" Text='<%#Eval("UrlWFDisplayName") %>'></asp:Label>
                                            </a>
                                        </li>
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
                        <asp:Repeater ID="rptInsuranceCarNews" runat="server">
                            <ItemTemplate>
                                <div class="leftsidebar_ins">
                                    <a href='<%#"AllNewsDetails?ID="+Utilities.StringCipher.Encrypt(Eval("IID").ToString()) %>'>
                                        <asp:Image CssClass="img-responsive" runat="server" ImageUrl='<%# Eval("ImageUrl") %>' alt="img" />
                                    </a>
                                    <div class="leftsidebar_insInnr">
                                        <a href='<%#"AllNewsDetails?ID="+Utilities.StringCipher.Encrypt(Eval("IID").ToString()) %>'>
                                            <asp:Label ID="lblNewstitle" runat="server" Text='<%# Eval("TitleName") %>'></asp:Label>
                                        </a>
                                        <a href='<%#"AllNewsDetails?ID="+Utilities.StringCipher.Encrypt(Eval("IID").ToString()) %>'>
                                            <p>'<%# Eval("Description") %>'</p>
                                        </a>

                                    </div>
                                    <a href='<%#"AllNewsDetails?ID="+Utilities.StringCipher.Encrypt(Eval("IID").ToString()) %>' class="btn btn-primary btnReadMore2">Read More  <span class="glyphicon glyphicon-chevron-right oioCherRight2"></span></a>
                                </div>
                            </ItemTemplate>

                        </asp:Repeater>
                    </div>
                </div>
                <div class="col-sm-6 col-md-6 col-lg-6">
                    <div class="contentArea_ins">
                        <h3>Why compare car insurance with us?</h3>
                        <p>
                            At OiiO Mart.com we provide insurance quotes for a wide range of cars. 
So whether you drive an Alfa or a Volvo – or most motors in between – take
a look at the links below and start your journey to insuring your car. We try 
to provide car insurance for as many manufacturers as possible. If the car 
you own isn’t listed here, don’t worry: get in contact with us, tell us how you
roll and we’ll see what we can do.
                        </p>
                        <p>
                            Whether you’re looking for fully comprehensive motor insurance to third 
party only, we could help you save money - it could be up to Tk 4234 (50% of 
consumers could achieve this saving with OiiO Mart.com Motor 
Insurance)^.28% of consumers achieved an average saving of £461 with 
OiiO Mart.com Motor Insurance.^
                        </p>
                        <h3>See how much you can save on your car 
insurance with OiiO Mart.com!</h3>
                        <p>
                            Here at OiiO Mart.com, we want to make it as quick and easy for you to 
find a great deal on insuring your vehicle. It’s really easy and only takes a 
few minutes. You only need to enter your information once into our simple 
form, just a little information about yourself, your driving history and 
vehicle itself and you can check quotes from some of the BD’s top providers 
almost instantly.
                        </p>
                        <p>
                            We understand getting a renewal on your insurance can be frustrating, 
but if you want to save money it’s always important to shop around. We can 
help you reduce the time this takes by making the process as easy as 
possible and listing your best quotes from our trusted panel of insurers in 
one place.
                        </p>
                        <p>
                            So, whether you’re looking to beat your current provider’s renewal quote, 
or you’re looking to insure a new vehicle, our easy to use comparison 
service could save you time and help you find a better deal.
                        </p>
                        <p>
                            Perhaps you’re looking for auto insurance quotes that are more precisely 
tailored to you, such as young driver cover or insurance for students. Don’t 
worry, we can help you with that too.
                        </p>
                        <p>Start now and see how much you could save money on your annual policy.</p>

                        <h3>What is the minimum policy duration for car insurance?</h3>
                        <p>
                            Life insurance comes in a variety of forms. At its simplest, it pays out an 
agreed amount, either as a lump sum or as a regular income, if you die 
within a specified period – known as the ‘term’. Hence its name: term 
insurance.
                        </p>

                        <h3>What is the minimum policy duration for car insurance?</h3>

                        <p>
                            Standard policies last for 1 year, with the option to pay the annual fee up 
front or as monthly payments.
                        </p>
                        <p>
                            Once you've found an auto insurance deal that's right for you just pick the 
provider and simply complete the process.
                        </p>

                    </div>
                </div>
                <div class="col-sm-3 col-md-3 col-lg-3">
                    <div class="right_sidebar_ins">
                        <div class="rightSidebarA">
                            <h3>Car FAQs</h3>
                            <p>Need more information about life insurance? Don't worry, we have a list of life insurance FAQs which may help with your query.</p>
                            <div class="clearfix"></div>
                        </div>

                        <div class="rightSidebarA">
                            <h3>Young drivers' 
insurance</h3>
                            <p>If you are looking for a cheaper young drivers car insurance policy, let us take away the hard work by comparing quotes across a range of providers.</p>
                            <div class="clearfix"></div>
                        </div>

                        <div class="rightSidebarA">
                            <h3>Women's car insurance</h3>
                            <p>Compare women’s car insurance quotes with just a few clicks and you could be saving money in no time at all!</p>
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
                    <asp:Repeater ID="rptInsuranceCompanyLogo" runat="server">
                        <ItemTemplate>
                            <asp:Image CssClass="img-thumbnail img-responsive" runat="server" ImageUrl='<%# Eval("LogoUrl") %>' alt="img" />

                        </ItemTemplate>

                    </asp:Repeater>




                </div>
            </div>

        </div>
    </section>
</asp:Content>
