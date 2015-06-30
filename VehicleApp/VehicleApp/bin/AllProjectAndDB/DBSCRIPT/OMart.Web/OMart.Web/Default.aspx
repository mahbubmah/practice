<%@ Page Title="" Language="C#" MasterPageFile="~/OiiOMasterPage.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="OMart.Web.Default" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Slider" ContentPlaceHolderID="DefaultPageSlide" runat="server">
    <div class="carousel fade-carousel slide oiioFadeBanner" style="margin: 0;" data-ride="carousel" data-interval="4000" id="bs-carousel">
        <!-- Overlay -->
        <div class="overlay"></div>

        <!-- Wrapper for slides -->
        <div class="carousel-inner" style="height: 300px">
            <div class="item slides active">
                <div class="slide-1"></div>
                <div class="insBannerCntWrp">
                    <div class="insBannerCnt">
                        <div class="col-lg-8 col-sm-8">
                            <p>
                                <a class="bantxtTitel" href="#">
                                    <asp:LinkButton ID="lnkBtnTitle1" CssClass="bantxtTitel" runat="server" CausesValidation="false" CommandName="EditUserInfo" OnClick="lnkBtnTitle1_Click"></asp:LinkButton>
                                </a><span class="glyphicon glyphicon-chevron-right oioCherRight"></span>
                            </p>
                            <h4>
                                <asp:Literal ID="ltrFeatureDescription" runat="server"></asp:Literal></h4>
                            <div class="row">
                                <div class="col-sm-4">
                                    <ul class="insBannerLink">
                                        <asp:Repeater ID="childRepeaterFirst" runat="server"
                                            EnableViewState="False">
                                            <HeaderTemplate>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <li><a href='<%#"AllFeatureMoreDetails?fID="+Utilities.StringCipher.Encrypt(Eval("IID").ToString()) %>'><%# Eval("BusinessTypeBreakdownName") %><span class="glyphicon glyphicon-chevron-right oioCherRight2"></span></a></li>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                            </FooterTemplate>
                                        </asp:Repeater>

                                    </ul>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-4 col-sm-4">
                            <div class="hero2">
                                <a class="bantxtTitel" href="#">
                                    <asp:LinkButton ID="lkbImageFirst" CssClass="bantxtTitel" runat="server" CausesValidation="false" CommandName="EditUserInfo" OnClick="lkbImageFirst_Click">
                                        <asp:Image ID="img_AllFeatureFirst" runat="server" CssClass="img-responsive" Width="220" Height="220" alt="Image" />
                                    </asp:LinkButton>
                                </a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <asp:Repeater ID="ParentRepeater" runat="server" OnItemDataBound="ParentRepeater_ItemDataBound"
                EnableViewState="False">
                <ItemTemplate>
                    <div class="item slides">
                        <div class="slide-2"></div>
                        <div class="insBannerCntWrp">
                            <div class="insBannerCnt">
                                <div class="col-lg-8 col-sm-8">
                                    <p>
                                        <a class="bantxtTitel" href="#">
                                            <asp:LinkButton ID="lkbTitle2" CssClass="bantxtTitel" runat="server" CausesValidation="false" CommandArgument='<%# Eval("IID") %>' OnClick="lkbTitle2_Click"
                                                Text='<%# Eval("BussinessTypeName") %>'></asp:LinkButton>
                                        </a><span class="glyphicon glyphicon-chevron-right oioCherRight"></span>
                                    </p>

                                    <asp:HiddenField ID="hdAllFeatureIID" runat="server" Value='<%# Eval("IID") %>'></asp:HiddenField>

                                    <h4><%# Eval("Description") %></h4>
                                    <div class="row">
                                        <div class="col-sm-4">
                                            <ul class="insBannerLink">
                                                <asp:Repeater ID="childRepeater" runat="server"
                                                    EnableViewState="False">
                                                    <HeaderTemplate>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>

                                                        <li><a href='<%#"AllFeatureMoreDetails?fID="+Utilities.StringCipher.Encrypt(Eval("IID").ToString()) %>'><%# Eval("BusinessTypeBreakdownName") %><span class="glyphicon glyphicon-chevron-right oioCherRight2"></span></a></li>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                    </FooterTemplate>
                                                </asp:Repeater>

                                            </ul>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-lg-4 col-sm-4">
                                    <div class="hero2">
                                        <a class="bantxtTitel" href="#">
                                            <asp:LinkButton ID="lkbImage" CssClass="bantxtTitel" runat="server" CausesValidation="false" CommandArgument='<%# Eval("IID") %>' OnClick="lkbImage_Click">
                                                <asp:Image ID="img_AllFeature" runat="server" CssClass="img-responsive" Height="220" Width="220" ImageUrl='<%# Eval("ImageUrl") %>' alt="Image" />
                                            </asp:LinkButton>
                                        </a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                </ItemTemplate>
                <FooterTemplate>
                </FooterTemplate>
            </asp:Repeater>


        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="container">
        <div class="row">
            <div class="servBoxWrp">
                <div class="row">
                    <asp:Repeater ID="rptParentFeature" runat="server"
                        EnableViewState="False">
                        <ItemTemplate>
                            <div class="col-sm-3 col-md-3 col-lg-3">
                                <div class="productBox">
                                    <div class="productBoxInner">
                                        <a href='<%# "FeatureDescription?ID=" +Utilities.StringCipher.Encrypt(Eval("IID").ToString()) %>'>
                                            <h3><%# Eval("BussinessTypeName") %></h3>
                                            <p><%# Eval("Description") %>....</p>

                                            <asp:Image CssClass="img-responsive" ID="Image1" Height="250px" runat="server" ImageUrl='<%# Bind("ImageUrl") %>' alt="img" />
                                        </a>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                        <FooterTemplate>
                        </FooterTemplate>
                    </asp:Repeater>

                </div>
                <div class="row">
                    <div class="col-sm-3 pull-right">
                        <a href="#" class="btn btn-primary viewAll1 pull-right viewAll viewAll_Bottom">View all</a>
                    </div>
                </div>
                <div class="clearfix"></div>
            </div>
        </div>
        <div class="row">
            <div class="servBoxWrp">
                <div class="row">

                    <asp:Repeater ID="rptLogInfoImages" runat="server" OnItemDataBound="rptLogInfoImages_ItemDataBound"
                        EnableViewState="False">
                        <HeaderTemplate>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <div class="col-sm-1 col-md-1 col-lg-2">
                                <div class="sponserLogo img-thumbnail">

                                    <%-- <a href='<%# Eval("WebAddress") %>' target="_blank">--%>
                                    <asp:Image CssClass="img-responsive" ID="Image1" Width="150px" Height="150px" runat="server" ImageUrl='<%# Bind("LogoUrl") %>' alt="img" />
                                    <%--</a>--%>
                                </div>
                            </div>
                        </ItemTemplate>

                        <FooterTemplate>
                        </FooterTemplate>
                    </asp:Repeater>


                    <div class="clearfix"></div>
                </div>
            </div>
            <div class="row">
                <div class="servBoxWrp hlpBox commBoxTitel">
                    <div class="row">
                        <div class="col-sm-12">
                            <h3>New to <span>Switching? </span>Let us help <span class="pull-right"><a href="#" class="btn btn-primary viewAll"></a></span></h3>
                        </div>
                    </div>
                    <div class="row">
                        <asp:Repeater ID="rpGuideLine" runat="server" OnItemDataBound="rpGuideLine_OnItemDataBound">
                            <ItemTemplate>
                                <div class="col-sm-3 col-md-3 col-lg-3">
                                    <div class="productBox2Wrp">
                                        <div class="productBox2">
                                            <a href="#">
                                                <div class="productBoxInner2">
                                                    <h4>


                                                        <a runat="server" href='<%#"GuideLineDetails?ID="+Utilities.StringCipher.Encrypt(Eval("IID").ToString()) %>'>
                                                            <asp:Literal ID="lblGuideLineTypeName" runat="server" Text=' <%# Eval("BussinessTypeName") %>'></asp:Literal>
                                                        </a>


                                                    </h4>

                                                    <p>
                                                        <asp:Literal ID="ltrGuideTypeTitle" runat="server" Text=' <%# Eval("GuideTypeTitle") %>'></asp:Literal>
                                                    </p>
                                                    <a runat="server" href='<%#"GuideLineDetails?ID="+Utilities.StringCipher.Encrypt(Eval("IID").ToString()) %>'>
                                                        <asp:Image runat="server" ID="img_Ads" Width="250" Height="230" ImageUrl='<%# Eval("GuideTypeImage") %>' alt="Image" />
                                                    </a>
                                                </div>
                                            </a>
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
                <div class="servMenulist commBoxTitel">
                    <div class="row">
                        <div class="col-sm-12">
                            <h3>Latest <span>All</span> News</h3>
                        </div>
                    </div>
                    <div class="row">


                        <asp:ListView OnItemDataBound="repChildBusiness_OnItemDataBound" runat="server" ID="lvLatestAllNews">
                            <ItemTemplate>
                                <div class="col-sm-3 col-md-3 col-lg-3">
                                    <div class="servMenuItem">
                                        <h4>
                                            <asp:Label runat="server" ID="lblParentBusinesTypeName"><%#  Enum.Parse(typeof(Utilities.EnumCollection.BussinessType), Eval("BusinessTypeID").ToString()) %></asp:Label></h4>
                                        <asp:HiddenField ID="hdBusinessTypeID" runat="server" Value='<%# Eval("BusinessTypeID") %>' />
                                        <ul>
                                            <asp:Repeater runat="server" ID="repChildBusiness" EnableViewState="false">
                                                <ItemTemplate>
                                                    <li>
                                                        <a runat="server" href='<%#"AllNewsDetails?ID="+Utilities.StringCipher.Encrypt(Eval("IID").ToString()) %>'><span class="glyphicon glyphicon-chevron-right"></span><%# Eval("Name") %></a>

                                                    </li>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </ul>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:ListView>


                    </div>
                    <div class="clearfix"></div>
                </div>
            </div>
            <div class="row">
                <div class="oiioMat_bottom commBoxTitel">
                    <div class="col-sm-5 col-md-5 col-lg-5">
                        <div class="oiioMatBox1">
                           
                            <h3><asp:Label ID="lblHelpTitle1" runat="server"></asp:Label></h3>
                            <p><asp:Label ID="lblHelpDescription1" runat="server"></asp:Label></p>
                            <p><asp:LinkButton ID="lkbHelpAdvice1" runat="server" CssClass="pull-right btn btn-default" OnClick="lkbHelpAdvice1_Click">Read More</asp:LinkButton></p>
                        </div>

                    </div>
                    <div class="col-sm-2 col-md-2 col-lg-2">
                        <div class="">
                           
                            <asp:Image ID="imgHelpAdvice" Width="170" Height="233" runat="server" alt="img"/>
                        </div>

                    </div>
                    <div class="col-sm-5 col-md-5 col-lg-5">
                        <div class="oiioMatBox1">
                          
                            <h3><asp:Label ID="lblHelpTitle2" runat="server"></asp:Label></h3>
                            <p><asp:Label ID="lblHelpDescription2" runat="server"></asp:Label></p>
                            <p><asp:LinkButton ID="lkbHelpAdvice2" runat="server" CssClass="pull-right btn btn-default" OnClick="lkbHelpAdvice2_Click">Read More</asp:LinkButton></p>
                        </div>

                    </div>
                </div>

            </div>

        </div>
    </div>
</asp:Content>

