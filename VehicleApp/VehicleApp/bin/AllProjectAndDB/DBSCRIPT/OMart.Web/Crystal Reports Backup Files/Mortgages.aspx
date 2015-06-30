<%@ Page Title="" Language="C#" MasterPageFile="~/MortgageMasterPage.Master" AutoEventWireup="true" CodeBehind="Mortgages.aspx.cs" Inherits="OMart.Web.Mortgages" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MortgagePlaceHolder" runat="server">

    <section>

        <div class="container brodBandServ commBoxTitelLoan mortagesPage">

            <div class="row">

                <div class="servBoxWrp insServInner insGuide commBoxTitel2">
                    <div class="col-md-12">
                        <h2>Which type of loan are you looking for?</h2>
                    </div>
                    <asp:Repeater ID="rptMortgageTypeDisplay" runat="server"
                        EnableViewState="False">
                        <HeaderTemplate>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <div class="col-sm-3 col-md-3 col-lg-3">
                                <div class="bBrandproductBox2Wrp">
                                    <div class="img-thumbnail">
                                        <asp:LinkButton ID="lnkBtnMotgageType" runat="server" CausesValidation="false" Text='' OnClick="lnkBtnMotgageType_Click" CommandArgument='<%# Eval("IID") %>'>
                                             <asp:Image CssClass="img-responsive" runat="server" Height="200px" ImageUrl='<%# Eval("ImageUrl") %>' alt="img" />
                                        </asp:LinkButton>
                                    </div>
                                    <h5><span class="bbandProdHead_bg1 pull-left"></span><%# Eval("Name") %><span class="bbandProdHead_bg2 pull-right"></span></h5>
                                    <div class="bBrandproductCnt" style="height: 250px;">
                                        <h6>I want a better deal on my current <%# Eval("Name") %>...</h6>
                                        <p class="text-left">
                                            <%# Eval("Description")%>.......
                                        </p>
                                        <asp:LinkButton ID="lnkBtnReadMore" runat="server" CausesValidation="false" class="btn btn-primary btnReadMore3" Text='Read More' OnClick="lnkBtnReadMore_Click" CommandArgument='<%# Eval("IID") %>'></asp:LinkButton>
                                    </div>
                                </div>
                            </div>

                        </ItemTemplate>
                        <%--<AlternatingItemTemplate>
                                                     <asp:LinkButton ID="lnkBtnName1" runat="server" CausesValidation="false" Text='<%# Eval("Name")%>'
                                CommandArgument='<%# Eval("Value") %>' CommandName="EditUserInfo"></asp:LinkButton><span class="glyphicon glyphicon-chevron-right oioCherRight2"></span></a></li>
                                                </AlternatingItemTemplate>--%>
                        <FooterTemplate>
                        </FooterTemplate>
                    </asp:Repeater>

                </div>

                <div class="clearfix"></div>
            </div>
            <div class="row">
                <div class="col-sm-3 pull-right">
                    <asp:LinkButton ID="lnkBtnViewAll" runat="server" CausesValidation="false" Text='View all' CssClass="btn btn-primary viewAll pull-right " OnClick="lnkBtnViewAll_Click"></asp:LinkButton>
                </div>
            </div>

            <div class="row">
                <div class="col-sm-12">
                    <asp:LinkButton ID="lnkBtnMtProvider" runat="server" CausesValidation="false" Text='' OnClick="lnkBtnMtProvider_Click"><h2>Our mortgage providers </h2>
                    </asp:LinkButton>
                </div>
                <asp:Repeater ID="rptMortgageProvider" runat="server" OnItemDataBound="rptMortgageProvider_ItemDataBound"
                    EnableViewState="False">
                    <HeaderTemplate>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div class="col-sm-1 col-md-1 col-lg-2">
                            <div class="sponserLogo img-thumbnail">
                                <%--<asp:LinkButton ID="lnkBtnMotgageProvider" runat="server" CausesValidation="false" Text='' OnClick="lnkBtnMotgageProvider_Click"></asp:LinkButton>--%>
                                <a href='<%# Eval("ProviderUrl") %>' target="_blank">
                                    <asp:Image CssClass="img-responsive" Width="150px" Height="150px" runat="server" ImageUrl='<%# Eval("LogoUrl") %>' alt="img" />
                                </a>
                            </div>
                        </div>
                    </ItemTemplate>

                    <FooterTemplate>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
            <div class="row">
                <div class="col-sm-3 pull-right">
                    <asp:LinkButton ID="lkbMorgageProvider" runat="server" CausesValidation="false" Text='View all mortgage providers' CssClass="btn btn-primary viewAll pull-right " OnClick="lkbMorgageProvider_Click"></asp:LinkButton>
                </div>
            </div>

        </div>


        <div class="providerIem2">
            <div class="container">
                <div class="row">
                    <div class="col-md-12">
                        <%--<a href="#">Mortgage guides</a>--%>
                        <%-- <asp:LinkButton runat="server" ID="lBtnMortgageGuides" OnClick="MortgateGuides_Click">Mortgage guides</asp:LinkButton>--%>
                        <asp:LinkButton runat="server" ID="lBtnMortgagedNews" OnClick="MortgateNews_Click">Mortgage news</asp:LinkButton>
                        <%--<a href="#">About mortgages</a>--%>
                    </div>
                </div>
            </div>
            <div class="clearfix"></div>
        </div>
    </section>
</asp:Content>
