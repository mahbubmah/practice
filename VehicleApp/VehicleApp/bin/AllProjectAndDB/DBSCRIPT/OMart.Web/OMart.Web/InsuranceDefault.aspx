<%@ Page Title="" Language="C#" MasterPageFile="InsuranceMaster.Master" AutoEventWireup="true" CodeBehind="InsuranceDefault.aspx.cs" Inherits="OMart.Web.InsuranceDefault" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section>
        <div class="carousel fade-carousel slide oiioFadeBanner oiioInsBanner BroadBandBanner" data-ride="carousel" data-interval="4000" id="bs-carousel">
          
            <div class="carousel-inner">
                <div class="item slides active">
                    <div class="slideinsur1">
                    </div>
                    <div class="insBannerCntWrp">
                        <div class="insBannerCnt">

                            <p>
                               <%-- <a class="bantxtTitel" href='<%#"AllFeatureMoreDetails"%>'></a>--%>
                                   <asp:LinkButton ID="lkbBussinessType" runat="server" CssClass="bantxtTitel" OnClick="lkbBussinessType_Click"> <asp:Literal ID="ltrTitle" runat="server"></asp:Literal><span class="glyphicon glyphicon-chevron-right oioCherRight"></span></asp:LinkButton>
                            </p>
                            <h4>
                                <asp:Literal ID="ltrDescription" runat="server"></asp:Literal></h4>
                            <div class="row">
                                <div class="col-sm-4">
                                    <ul class="insBannerLink">
                                        <asp:Repeater ID="rptChildFirst" runat="server"
                                            EnableViewState="False">
                                            <ItemTemplate>
                                               <li> <a href='<%#"AllFeatureMoreDetails?ID="+Utilities.StringCipher.Encrypt(Eval("IID").ToString()) %>'><%# Eval("TitleName") %><span class="glyphicon glyphicon-chevron-right oioCherRight2"></span></a></li>
                                            </ItemTemplate>

                                        </asp:Repeater>
                                    </ul>
                                </div>
                            </div>

                            <div class="hero2">
                                <asp:Image ID="img_AllFeatureFirst" runat="server" CssClass="img-responsive" Width="220" Height="220" alt="Image" />
                            </div>

                        </div>
                    </div>
                </div>


               <asp:Repeater ID="parentRepeater" runat="server" OnItemDataBound="parentRepeater_ItemDataBound"
                    EnableViewState="False">
                    <ItemTemplate>
                        <div class="item slides">
                            <div class="slideinsur1"></div>
                            <div class="insBannerCntWrp">
                                <div class="insBannerCnt">

                                    <p><a class="bantxtTitel" href='<%#"AllFeatureMoreDetails?fID="+Utilities.StringCipher.Encrypt(Eval("IID").ToString()) %>'><%# Eval("BusinessTypeBreakdownName") %><span class="glyphicon glyphicon-chevron-right oioCherRight"></span></p></a>
                                    <h4><%# Eval("Description")%></h4>
                                    <div class="row">
                                        <div class="col-sm-4">
                                            <ul class="insBannerLink">
                                                <asp:HiddenField ID="hdAllFeatureIID" runat="server" Value='<%# Eval("IID") %>'></asp:HiddenField>
                                                <asp:Repeater ID="rptChildSecond" runat="server"
                                                    EnableViewState="False">
                                                    <ItemTemplate>
                                                        <li><a href='<%#"AllFeatureMoreDetails?ID="+Utilities.StringCipher.Encrypt(Eval("IID").ToString()) %>' runat="server"><%# Eval("TitleName") %><span class="glyphicon glyphicon-chevron-right oioCherRight2"></span></a></li>
                                                    </ItemTemplate>

                                                </asp:Repeater>

                                            </ul>
                                        </div>
                                    </div>

                                    <div class="hero2">
                                        <asp:Image ID="Image1" runat="server" CssClass="img-responsive" Width="220" Height="220" ImageUrl='<%# Eval("ImageUrl") %>' alt="Image" />
                                    </div>

                                </div>
                            </div>
                        </div>

                    </ItemTemplate>

                </asp:Repeater>
            </div>
        </div>
    </section>
    <section>
        <div class="container insServ">
            <div class="row">
                <div class="servBoxWrp insServInner commBoxTitel">

                    <div class="row">
                       
                        <div class="col-sm-3 col-md-3 col-lg-3">
                            <div class="productBox2Wrp">
                                <div class="productBox2">
                                    <a href="InsuranceCar.aspx" target="_blank">
                                        <div class="productBoxInner2">
                                            <h4>Car insurance</h4>
                                            <p>
                                                Our service is simple and
                                                <br />
                                                speedy
                                            </p>
                                            <img class="img-responsive" src="Images/products/10.jpg" alt="img" />
                                        </div>
                                    </a>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-3 col-md-3 col-lg-3">
                            <div class="productBox2Wrp">
                                <div class="productBox2">
                                    <a href="#">
                                        <div class="productBoxInner2">
                                            <h4>Travel insurance</h4>
                                            <p>
                                                Find out which service could be best 
for you
                                            </p>
                                            <img class="img-responsive" src="Images/products/11.jpg" alt="img" />
                                        </div>
                                    </a>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-3 col-md-3 col-lg-3">
                            <div class="productBox2Wrp">
                                <div class="productBox2">
                                    <a href="InsuranceCover.aspx">
                                        <div class="productBoxInner2">
                                            <h4>Life insurance</h4>
                                            <p>All the information you need to find the phone for you</p>
                                            <img class="img-responsive" src="Images/products/12.jpg" alt="img" />
                                        </div>
                                    </a>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-3 col-md-3 col-lg-3">
                            <div class="productBox2Wrp">
                                <div class="productBox2">
                                    <a href="BusinessInsurance.aspx">
                                        <div class="productBoxInner2">
                                            <h4>Business insurance</h4>
                                            <p>Simple straight talking advice to help you manage your money.</p>
                                            <img class="img-responsive" src="Images/products/13.jpg" alt="img" />
                                        </div>
                                    </a>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="clearfix"></div>
                </div>
            </div>

            <div class="row">
                <div class="servBoxWrp insServInner insGuide commBoxTitel2">
                    <div class="row">
                        <div class="col-sm-12">
                            <h3>Insurance guides <span class="pull-right"><a href="#" class="btn btn-primary viewAll">View all</a></span></h3>
                        </div>
                    </div>
                    <div class="row">

                        <asp:Repeater ID="repInsuranceGuide" runat="server">
                            <ItemTemplate>

                                <div class="col-sm-3 col-md-3 col-lg-3">
                                    <div class="productBox2Wrp">
                                        <div class="productBox2">

                                            <a href='<%#"GuideLineDetails?ID="+Utilities.StringCipher.Encrypt(Eval("IID").ToString()) %>' runat="server">
                                                <asp:Image ID="imgImageUrl" CssClass="img-responsive" runat="server" ImageUrl='<%# Bind("ImageUrl")%>' AlternateText="img" Width="250" Height="250" />
                                            </a>

                                            <a href='<%#"GuideLineDetails?ID="+Utilities.StringCipher.Encrypt(Eval("IID").ToString()) %>' class="readstory">
                                                <h5>
                                                    <asp:Label ID="lblTitle" runat="server" Text='<%#Bind("Title")%>'></asp:Label></h5>
                                            </a>

                                            <p>
                                                <asp:Label ID="lblDescription" runat="server" Text='<%#Bind("Description")%>'></asp:Label>
                                                <%--                                                </a>--%>
                                            </p>
                                            <a href='<%#"GuideLineDetails?ID="+Utilities.StringCipher.Encrypt(Eval("IID").ToString()) %>' class="btn btn-primary btnReadMore">Read more </a>
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>

                        </asp:Repeater>
                    </div>
                    <div class="clearfix"></div>
                </div>
            </div>


            <div class="row">
                <div class="servBoxWrp insServInner insGuide commBoxTitel2">
                    <div class="row">
                        <div class="col-sm-12">
                            <h3>Insurance news <span class="pull-right"><a href="#" class="btn btn-primary viewAll">View all</a></span></h3>
                        </div>
                    </div>
                    <div class="row">

                        <asp:Repeater ID="repInsuranceNews" runat="server">
                            <ItemTemplate>

                                <div class="col-sm-3 col-md-3 col-lg-3">
                                    <div class="productBox2Wrp">
                                        <div class="productBox2">


                                            <a href='<%#"AllNewsDetails?ID="+Utilities.StringCipher.Encrypt(Eval("IID").ToString()) %>' runat="server">
                                                <asp:Image ID="imgImageUrl" CssClass="img-responsive" runat="server" ImageUrl='<%# Bind("ImageUrl")%>' AlternateText="img" Width="250" Height="250" />
                                            </a>
                                            <div class="productCnt">
                                                <a href='<%#"AllNewsDetails?ID="+Utilities.StringCipher.Encrypt(Eval("IID").ToString()) %>' class="readstory">
                                                    <h6><span class="productCntHead pull-left">
                                                        <asp:Label ID="lblChildInsuranceName" runat="server" Text='<%#  Eval("Name")%>'> </asp:Label>
                                                    </span>

                                                    </h6>
                                                </a>
                                                <p class="productCntDesc" runat="server">
                                                    <asp:Label ID="lblDescription" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                                                </p>

                                            </div>


                                            <%--<a class="btn btn-primary btnReadMore2" href="#">More Car Insurance <span class="glyphicon glyphicon-chevron-right oioCherRight2"></span></a>--%>
                                            <a href='<%#"AllNewsDetails?ID="+Utilities.StringCipher.Encrypt(Eval("IID").ToString()) %>' class="btn btn-primary btnReadMore2">More <%#  Enum.Parse(typeof(Utilities.EnumCollection.BusinessInsuranceType), Eval("BusinessTypeBreakdownID").ToString()) %> <span class="glyphicon glyphicon-chevron-right oioCherRight2"></span></a>

                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>

                        </asp:Repeater>
                    </div>
                    <div class="clearfix"></div>
                </div>
            </div>
        </div>
    </section>

</asp:Content>

