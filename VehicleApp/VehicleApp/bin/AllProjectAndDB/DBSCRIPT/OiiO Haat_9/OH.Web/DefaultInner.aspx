<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultMaster.Master" AutoEventWireup="true" CodeBehind="DefaultInner.aspx.cs" Inherits="OH.Web.DefaultInner" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="RatingStyle" type="text/css" href="Content/RatingStyle.css" />
    <style type="text/css">
        .Star {
            background-image: url(image/Star.gif);
            height: 17px;
            width: 17px;
        }

        .WaitingStar {
            background-image: url(image/WaitingStar.gif);
            height: 17px;
            width: 17px;
        }

        .FilledStar {
            background-image: url(image/FilledStar.gif);
            height: 17px;
            width: 17px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
        <ContentTemplate>
            <div class="mainBodyWrp">
                <section>
                    <div class="container">
                        <div class="row">
                            <div class="well searchPanel3">
                                <div class="col-sm-4 col-md-4 col-lg-4">
                                    <div class="selectWant">
                                    </div>
                                </div>
                                <br />

                                <div class="dropdown col-xs-3">
                                    <div class="dropdown-menu-left">
                                        <div class="dropdown col-xs-12">
                                            <div class="dropdown-menu-left">

                                                <asp:DropDownList ID="ddlCategory" CssClass="form-control selectCatg1" runat="server" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged" AutoPostBack="true">
                                                </asp:DropDownList>

                                            </div>
                                        </div>
                                    </div>
                                </div>


                                <div class="col-sm-3 col-md-3 col-lg-3">
                                </div>
                                <div class="clearfix"></div>
                            </div>

                        </div>
                        <div class="row">

                            <div class="col-sm-9 col-md-9 col-lg-9 cntLeftAra">

                                <div class="panel with-nav-tabs panel-default oiioPanel">

                                    <div class="panel-heading">
                                        <ul class="nav nav-tabs">

                                            <li class="active" runat="server" id="liAllAds">

                                                <asp:LinkButton CommandArgument="AllAds" runat="server" OnClick="lnkBtnAllAds_OnClick" ID="lnkBtnAllAds">
                                                    All ads 
                                            <span class="badge badge-info">
                                                <asp:Label ID="lblAllAds" runat="server"></asp:Label>
                                            </span>
                                                </asp:LinkButton>

                                            </li>
                                            <li runat="server" id="liPrivateAds">

                                                <asp:LinkButton CommandArgument="PrivateAds" OnClick="lnkBtnPrivateAds_OnClick" ID="lnkBtnPrivateAds" runat="server">
                                                    Private ads
                                            <span class="badge badge-info">
                                                <asp:Label ID="lblPrivateAds" runat="server"></asp:Label>
                                            </span>
                                                </asp:LinkButton>

                                            </li>
                                            <li runat="server" id="liBusinessAds">

                                                <asp:LinkButton CommandArgument="BusinessAds" runat="server" OnClick="lnkBtnBusinessAds_OnClick" ID="lnkBtnBusinessAds">
                                                    Business ads
                                            <span class="badge badge-info">
                                                <asp:Label ID="lblBusinessAds" runat="server"></asp:Label>
                                            </span>
                                                </asp:LinkButton>

                                            </li>
                                            <li runat="server" id="liMostRecentAds">

                                                <asp:LinkButton CommandArgument="MostRecentAds" runat="server" OnClick="lnkBtnMostRecentAds_OnClick" ID="lnkBtnMostRecentAds">
                                                    Most Recent Ads
                                            <span class="badge badge-info">
                                                <asp:Label ID="lblMostRecentAds" runat="server"></asp:Label>
                                            </span>
                                                </asp:LinkButton>

                                                <%--<a href="#tab4default" data-toggle="tab">Most Recent Ads <span class="badge badge-info">
                                        <asp:Label ID="lblMostRecentAds" runat="server"></asp:Label>
                                    </span></a>--%>

                                            </li>

                                        </ul>

                                    </div>


                                    <div class="panel-body">
                                        <div class="tab-content">
                                            <div class="tab-pane fade in active" id="tab1default">

                                                <div class="row panelBodyTop">
                                                    <div class="col-md-4 col-sm-4 col-lg-4">
                                                        <h4>All Ads <span>in Bangladesh</span></h4>
                                                    </div>
                                                    <div class="col-md-4 col-sm-4 col-lg-4 pull-right filterBox">
                                                    </div>
                                                </div>

                                                <div class="row">
                                                    <asp:ObjectDataSource ID="objDataSourceForMaterial" runat="server"
                                                        EnablePaging="true"
                                                        TypeName="OH.BLL.Basic.MaterialRT"
                                                        SelectMethod="GetSortedMaterialAccordingToCategoreyIidnClientTypeId"
                                                        SelectCountMethod="CountAllForMaterialTypenClientType"
                                                        MaximumRowsParameterName="maxRowNumber"
                                                        StartRowIndexParameterName="startRowIndex"
                                                        OnSelecting="objDataSourceForMaterial_Selecting"></asp:ObjectDataSource>

                                                    <asp:ListView ID="lvForAllAddsMaterial"
                                                        DataSourceID="objDataSourceForMaterial"
                                                        runat="server"
                                                        DataKeyNames="IID"
                                                        OnPagePropertiesChanging="lvForAllAddsMaterial_PagePropertiesChanging">

                                                        <ItemTemplate>
                                                            <div class="productRowWrp">
                                                                <div class="productRow">

                                                                    <div>
                                                                        <asp:Label ID="lblMaterialID" runat="server" Text='<%# Eval("IID") %>' Visible="false"></asp:Label>

                                                                    </div>
                                                                    <div class="col-xs-3">
                                                                        <div class="thumbnail productimg2">
                                                                            <a href='<%#"DetailPage?option="+OH.Utilities.StringCipher.Encrypt(Eval("IID").ToString()) %>'>
                                                                                <asp:Image ID="img_inner" runat="server" ImageUrl='<%# Eval("ImageUrl")%>' AlternateText="img" />
                                                                            </a>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-xs-9 productDetails">
                                                                        <a href='<%#"DetailPage?option="+OH.Utilities.StringCipher.Encrypt(Eval("IID").ToString()) %>'>
                                                                            <asp:Label ID="lblBrandName" runat="server">  <h5 class="product-name"><%# Eval("TitleName")%></h5> </asp:Label>
                                                                        </a>
                                                                        <p class="prodInfo"><%# Eval("CurrentLocation")%></p>

                                                                        <span>
                                                                            <asp:Label ID="lblPrice" runat="server"> <h3 class="pricePart list-inline"><%#(char)2547%><%#Eval("Price") %>  </asp:Label>
                                                                            <asp:Label ID="lblNegotiable" runat="server"> <%#Eval("IsNegotiablePrice") %> </h3> </asp:Label>
                                                                        </span>

                                                                        <p class=" text-right">
                                                                            <span><%#Eval("AdDate") %></span>
                                                                        </p>

                                                                        <div class="productPostDate">

                                                                            <a href="#"><span class="glyphicon glyphicon-star"></span></a>
                                                                        </div>

                                                                    </div>

                                                                    <div class="clearfix"></div>
                                                                </div>
                                                            </div>
                                                        </ItemTemplate>
                                                    </asp:ListView>
                                                    <div class="paginationPart">
                                                        <asp:DataPager ID="dataPagerForAllAddsMaterial" runat="server" PagedControlID="lvForAllAddsMaterial"
                                                            PageSize="10">
                                                            <Fields>
                                                                <asp:NextPreviousPagerField FirstPageText="First" ButtonCssClass="BornoCss" PreviousPageText="Previous"
                                                                    ShowNextPageButton="False" ShowFirstPageButton="False" />
                                                                <asp:NumericPagerField PreviousPageText="..." CurrentPageLabelCssClass="BornoCss"
                                                                    NumericButtonCssClass="BornoCss" NextPreviousButtonCssClass="BornoCss" RenderNonBreakingSpacesBetweenControls="True"
                                                                    ButtonType="Link" />
                                                                <asp:NextPreviousPagerField FirstPageText="First" ButtonCssClass="BornoCss" LastPageText="Last"
                                                                    NextPageText="Next" PreviousPageText="Previous" ShowPreviousPageButton="False"
                                                                    ShowLastPageButton="False" />
                                                            </Fields>
                                                        </asp:DataPager>
                                                    </div>
                                                </div>

                                            </div>

                                        </div>
                                    </div>

                                </div>


                            </div>


                            <div class="col-sm-3 col-md-3 col-lg-3 sideBarInnerPage">
                                <div class="sidebarTop">
                                    <h3>Post Your Free  Add</h3>
                                    <div class="sidebar-nav">
                                        <h4>All categories</h4>
                                        <div class="well">
                                            <ul class="accodionCategory nav nav-list">

                                                <asp:Repeater ID="rp_Load_Category_Outer" runat="server" OnItemDataBound="rp_Load_Category_Outer_ItemDataBound">
                                                    <ItemTemplate>

                                                        <li>
                                                            <asp:HiddenField ID="hfCategoryIID" runat="server" Value='<%# Eval("IID") %>' />
                                                            <asp:LinkButton ID="btn_Category_Link" runat="server" CommandArgument='<%# Eval("IID") %>' OnClick="btn_Category_Link_Click">
                                                                <%# Eval("Name") %> <span class="badge badge-info">
                                                                    <asp:Label ID="lbl_Total_Products" runat="server"></asp:Label></span>
                                                            </asp:LinkButton>
                                                            <ul class="nav tree">
                                                                <asp:Repeater ID="rp_Inner_Category" runat="server" OnItemDataBound="rp_Inner_Category_ItemDataBound">
                                                                    <ItemTemplate>
                                                                        <li>
                                                                            <asp:HiddenField ID="hf_inner_CategoryIID" runat="server" Value='<%# Eval("IID") %>' />
                                                                            <asp:LinkButton ID="lnk_btn_Category_Inner" runat="server" CommandArgument='<%# Eval("IID") %>' OnClick="lnk_btn_Category_Inner_Click">
                                                                                <%# Eval("Name") %> <span class="badge badge-info">
                                                                                    <asp:Label ID="lbl_Total_Products_Inner" runat="server"></asp:Label></span>
                                                                            </asp:LinkButton>
                                                                        </li>

                                                                    </ItemTemplate>
                                                                </asp:Repeater>
                                                            </ul>

                                                        </li>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </ul>
                                        </div>
                                        <h4>‹ All of World </h4>
                                        <div class="well">
                                            <asp:Repeater ID="rp_Country_Load" runat="server" OnItemDataBound="rp_Country_Load_ItemDataBound">
                                                <ItemTemplate>
                                                    <ul class="accodionCategory nav">

                                                        <li>
                                                            <a href="<%#Eval("IID") %>"><%#Eval("Name") %></a>
                                                            <asp:HiddenField ID="hfCIID" runat="server" Value='<%#Eval("IID") %>' />
                                                            <ul class="nav">
                                                                <asp:Repeater ID="rp_StateDivision" runat="server">
                                                                    <ItemTemplate>
                                                                        <li><a href="<%#Eval("IID") %>"><%#Eval("Name") %></a></li>
                                                                    </ItemTemplate>
                                                                </asp:Repeater>

                                                            </ul>
                                                        </li>


                                                    </ul>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </div>
                                    </div>
                                </div>
                                <div class="sidebarBottom">
                                    <a href="https://www.facebook.com/" runat="server" target="_blank">
                                        <img src="App_Themes/Default/images/interface/facebook.jpg" alt="img" />
                                    </a>
                                </div>
                            </div>

                            <div class="clearfix">
                            </div>
                        </div>

                    </div>

                </section>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    <%--    <script type="text/javascript">
        $(function () {
            $('.panel-heading ul li').on('click', function () {
                $(this).addClass('active');
                //return false;
            });
        });

    </script>--%>
</asp:Content>
