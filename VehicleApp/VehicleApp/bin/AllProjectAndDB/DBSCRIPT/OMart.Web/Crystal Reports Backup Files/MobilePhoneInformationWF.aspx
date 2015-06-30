<%@ Page Title="" Language="C#" MasterPageFile="~/MobileMasterPage.Master" AutoEventWireup="true" CodeBehind="MobilePhoneInformationWF.aspx.cs" Inherits="OMart.Web.MobilePhoneInformationWF" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MobilePlaceHolder" runat="Server">
    <section>
        <div class="container">
            <div class="row">
                <div class="dealMfgFinerWrp">
                    <div class="col-sm-6 col-md-6 col-lg-6">
                        <div class="row">
                            <div class="dealFinderMfg">
                                <div class="col-sm-6">
                                    <div class="dealFinderLeft">
                                        <asp:Label runat="server" ID="lblMessage"></asp:Label>
                                        <h3>Deal Finder</h3>
                                        <p>
                                            Find your perfect mobile deal in 
seconds
                                        </p>
                                        <div class="selectChoice">
                                          
                                             <asp:DropDownList ID="ddTotalTalkTime"  runat="server" class="form-control">
                                                
                                            </asp:DropDownList>
                                         
                                            <asp:DropDownList ID="ddUsableData"  runat="server" class="form-control">
                                             
                                            </asp:DropDownList>
                                          

                                             <asp:DropDownList ID="ddMonthlyInstallment" runat="server" class="form-control">
                                               
                                         
                                            </asp:DropDownList>
                                          
                                             <asp:LinkButton ID="lnkbtnAnotherDeals" runat="server" CssClass="btn btn-primary form-control compareBtn2" Text="Compare Deals" OnClick="lnkbtnAnotherDeals_Click"></asp:LinkButton>
                                        </div>

                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <img class="img-responsive" src="Images/products/60.png" alt="img" />

                                </div>
                                <div class="clearfix"></div>
                            </div>
                        </div>

                    </div>
                    <div class="col-sm-6 col-md-6 col-lg-6">
                        <div class="row">
                            <div class="dealFinderMfg">
                                <div class="col-sm-6">
                                    <div class="dealFinderLeft">
                                        <h3>Choose by manufacturer</h3>
                                        <p>
                                            Compare mobile deals by brand,
select a handset to get started
                                        </p>
                                        
                                        <div class="selectChoice">
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                <ContentTemplate>
                                                <asp:DropDownList ID="ddlMobileCompany" AutoPostBack="true" runat="server" class="form-control" OnSelectedIndexChanged="ddlMobileCompany_SelectedIndexChanged">

                                            </asp:DropDownList>
                                            <asp:DropDownList ID="ddlMobileTypeAndModel" runat="server" class="form-control">

                                            </asp:DropDownList>
                                           <%-- <a href="#" class="btn btn-primary form-control compareBtn2">Compare deals <span class="glyphicon glyphicon-chevron-right oioCherRight2"></span></a>--%>
                                            <asp:LinkButton ID="lnkbtnCompareDeals" runat="server" CssClass="btn btn-primary form-control compareBtn2" Text="Compare Deals" OnClick="lnkbtnCompareDeals_Click"></asp:LinkButton>
                                           </ContentTemplate>
                                         </asp:UpdatePanel>
                                        </div>

                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <img class="img-responsive" src="Images/products/61.png" alt="img" />

                                </div>
                                <div class="clearfix"></div>

                            </div>
                        </div>
                    </div>

                </div>



            </div>
        </div>
        <div class="phoneFinder">
            <div class="container">
                <div class="row">
                    <div class="col-xs-2 col-sm-2 col-md-2 col-lg-2">
                        <img class="img-responsive" src="Images/products/62.png" alt="img" />
                    </div>
                    <div class="col-xs-7 col-sm-7 col-md-7 col-lg-7">
                        <div class="phoneFinderInner">
                            <h3>Phone finder</h3>
                            <p>Choose phone by colour, manufacturers or features</p>
                        </div>
                    </div>
                    <div class="col-sm-3 col-md-3 col-lg-3">
                        <a href="#" class="btn btn-primary form-control compareBtn2 marginTop30px">Browse phone <span class="glyphicon glyphicon-chevron-right oioCherRight2"></span></a>

                    </div>
                </div>
            </div>
            <div class="clearfix"></div>
        </div>
        <div class="container">

            <div class="row">
                <div class="servBoxWrp insServInner insGuide commBoxTitel2">
                    <div class="row">


                        <div class="col-sm-3 col-md-3 col-lg-3">
                            <div class="bBrandproductBox2Wrp">


                                <div class="img-thumbnail">
                                    <img class="img-responsive" src="Images/products/63.jpg" alt="img" />
                                </div>
                                <h5><span class="bbandProdHead_bg1 pull-left"></span>Best network/Operator deals<span class="bbandProdHead_bg2 pull-right"></span></h5>
                                <div class="bBrandproductCnt">
                                    <p>
                                        Lorem dummy text ever since the 1500s, when an unknown printer took a galley of  type specimen book.
                                    </p>


                                    <a class="btn btn-primary btnReadMore3" href="#">Read More</a>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-3 col-md-3 col-lg-3">
                            <div class="bBrandproductBox2Wrp">


                                <div class="img-thumbnail">
                                    <img class="img-responsive" src="Images/products/64.jpg" alt="img" />
                                </div>
                                <h5><span class="bbandProdHead_bg1 pull-left"></span>Best sim deals<span class="bbandProdHead_bg2 pull-right"></span></h5>
                                <div class="bBrandproductCnt">
                                    <p>
                                        Lorem dummy text ever since the 1500s, when an unknown printer took a galley of  type specimen book.
                                    </p>


                                    <a class="btn btn-primary btnReadMore3" href="#">Read More</a>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-3 col-md-3 col-lg-3">
                            <div class="bBrandproductBox2Wrp">


                                <div class="img-thumbnail">
                                    <img class="img-responsive" src="Images/products/65.jpg" alt="img" />
                                </div>
                                <h5><span class="bbandProdHead_bg1 pull-left"></span>Mobile Data Deals<span class="bbandProdHead_bg2 pull-right"></span></h5>
                                <div class="bBrandproductCnt">
                                    <p>
                                        Lorem dummy text ever since the 1500s, when an unknown printer took a galley of  type specimen book.
                                    </p>


                                    <a class="btn btn-primary btnReadMore3" href="#">Read More</a>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-3 col-md-3 col-lg-3">
                            <div class="bBrandproductBox2Wrp">


                                <div class="img-thumbnail">
                                    <img class="img-responsive" src="Images/products/66.jpg" alt="img" />
                                </div>
                                <h5><span class="bbandProdHead_bg1 pull-left"></span>Mobile phones coming soon<span class="bbandProdHead_bg2 pull-right"></span></h5>
                                <div class="bBrandproductCnt">
                                    <p>
                                        Lorem dummy text ever since the 1500s, when an unknown printer took a galley of  type specimen book.
                                    </p>


                                    <a class="btn btn-primary btnReadMore3" href="#">Read More</a>
                                </div>
                            </div>
                        </div>




                    </div>
                    <%--<div class="row">
                    <div class="col-sm-3 pull-right">
                    <a href="#" class="btn btn-primary viewAll pull-right ">View all</a>
                        </div>
                </div>--%>
                    <div class="clearfix"></div>
                </div>
            </div>
            <div class="latestPhone">
                <div class="row">

                    <h3>Compare mobile phones by network</h3>


                    <div class="row">

                        <div class="col-sm-2 col-md-2 col-lg-2">
                            <div class="sponserLogo img-thumbnail">
                                <a href="#">
                                    <img class="img-responsive" src="Images/products/67.jpg" alt="img" /></a>
                            </div>
                        </div>
                        <div class="col-sm-2 col-md-2 col-lg-2">
                            <div class="sponserLogo img-thumbnail">
                                <a href="#">
                                    <img class="img-responsive" src="Images/products/68.jpg" alt="img" /></a>
                            </div>
                        </div>
                        <div class="col-sm-2 col-md-2 col-lg-2">
                            <div class="sponserLogo img-thumbnail">
                                <a href="#">
                                    <img class="img-responsive" src="Images/products/69.jpg" alt="img" /></a>
                            </div>
                        </div>
                        <div class="col-sm-2 col-md-2 col-lg-2">
                            <div class="sponserLogo img-thumbnail">
                                <a href="#">
                                    <img class="img-responsive" src="Images/products/70.jpg" alt="img" /></a>
                            </div>
                        </div>
                        <div class="col-sm-2 col-md-2 col-lg-2">
                            <div class="sponserLogo img-thumbnail">
                                <a href="#">
                                    <img class="img-responsive" src="Images/products/71.jpg" alt="img" /></a>
                            </div>
                        </div>
                        <div class="col-sm-2 col-md-2 col-lg-2">
                            <div class="sponserLogo img-thumbnail">
                                <a href="#">
                                    <img class="img-responsive" src="Images/products/72.jpg" alt="img" /></a>
                            </div>
                        </div>


                    </div>
                    <div class="clearfix"></div>

                </div>
                <div class="row">
                    <h3>Latest mobile phone news</h3>

                    <div class="row">
                        <div class="col-sm-4 col-md-4 col-lg-4">
                            <div class="latestProductBox">
                                <fieldset>
                                    <legend>11 Mar 2015</legend>
                                    <div class="imgBox">
                                        <img src="Images/products/73.jpg" alt="img" />
                                    </div>
                                </fieldset>
                                <h5>Mobiles</h5>
                                <h4>Apple ResearchKit is an app 
ecosystem for medical 
research                            </h4>
                                <p>
                                    Turns the iPhone into a diagnostic 
tool.
                                </p>
                                <p><a class="readstory" href="#">Read story </a></p>

                            </div>
                        </div>

                        <div class="col-sm-4 col-md-4 col-lg-4">
                            <div class="latestProductBox">
                                <fieldset>
                                    <legend>11 Mar 2015</legend>
                                    <div class="imgBox">
                                        <img src="Images/products/74.jpg" alt="img" />
                                    </div>
                                </fieldset>
                                <h5>Mobiles</h5>
                                <h4>Total iPhone sales hit 700 
million </h4>
                                <p>
                                    Another landmark for the Jesus 
Phone.
                                </p>
                                <p><a class="readstory" href="#">Read story </a></p>

                            </div>
                        </div>
                        <div class="col-sm-4 col-md-4 col-lg-4">
                            <div class="latestProductBox">
                                <fieldset>
                                    <legend>11 Mar 2015</legend>
                                    <div class="imgBox">
                                        <img src="Images/products/75.jpg" alt="img" />
                                    </div>
                                </fieldset>
                                <h5>Mobiles</h5>
                                <h4>Apple Watch priced 000 tk
and on pre-order April 10th 
on sale 24th    </h4>
                                <p>
                                    Starts at 000 tk.
                                </p>
                                <p><a class="readstory" href="#">Read story </a></p>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>

</asp:Content>

