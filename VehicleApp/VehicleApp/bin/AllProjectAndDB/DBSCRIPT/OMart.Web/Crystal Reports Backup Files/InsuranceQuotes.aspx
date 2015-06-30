<%@ Page Title="" Language="C#" MasterPageFile="~/InsuranceMaster.Master" AutoEventWireup="true" CodeBehind="InsuranceQuotes.aspx.cs" Inherits="OMart.Web.InsuranceQuotes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <section>
                <div class=" oiioInsuranceFormWrp">

                    <nav role="navigation" class="navbar navbar-inverse oiioInsuranceFormMenu">
                        <div class="container">
                            <!-- Brand and toggle get grouped for better mobile display -->
                            <div class="navbar-header">
                                <button data-target="#insFormMenu" data-toggle="collapse" class="navbar-toggle" type="button">
                                    <span class="sr-only">Toggle navigation</span>
                                    <span class="icon-bar"></span>
                                    <span class="icon-bar"></span>
                                    <span class="icon-bar"></span>
                                </button>
                            </div>
                            <!-- Collect the nav links, forms, and other content for toggling -->
                            <div id="insFormMenu" class="collapse navbar-collapse">
                                <ul class="nav navbar-nav">
                                    <li>
                                        <a href="InsuranceCover.aspx"><span>1</span>Cover required</a>
                                    </li>
                                    <li>
                                        <a class="active" href="#"><span>2</span>Your  quotes</a>
                                    </li>
                                    <li>
                                        <a href="#"><span>3</span>Application</a>
                                    </li>
                                    <li>
                                        <a href="#"><span>4</span>Confirmation</a>
                                    </li>

                                </ul>
                            </div>
                            <!-- /.navbar-collapse -->
                        </div>
                        <!-- /.container -->
                    </nav>

                    <div class="formTitel">
                        <div class=" container">
                            <div class="row">
                                <div class="col-md-12">
                                    <h2>
                                        <asp:Label runat="server" ID="lblMessage"></asp:Label></h2>
                                    <%--<h2>Tarik, we have found 12 quotes from £9.26 per month.</h2>--%>
                                </div>
                            </div>
                        </div>

                    </div>
                    <div class="container">
                        <div class="row">

                            <div class="searchPanel13">
                                <div class="col-sm-2 col-md-2 col-lg-2">
                                    <h4>Quote reference</h4>
                                    <asp:TextBox runat="server" CssClass="form-control" ReadOnly="True" placeholder="Applican IID" ID="txtAppicantIID"></asp:TextBox>

                                    <%--   <a class="myAcc" href="#">My Account</a>--%>
                                </div>
                                <div class="col-sm-2 col-md-2 col-lg-2">
                                    <h4>Life cover:</h4>
                                    <asp:TextBox runat="server" TextMode="Number" CssClass="form-control" Text="" ID="txtCoverMoney"></asp:TextBox>
                                </div>
                                <div class="col-sm-2 col-md-2 col-lg-2">
                                    <h4>Critical illness:  </h4>
                                    <asp:DropDownList AutoPostBack="True" OnSelectedIndexChanged="dropDownHaveCriticalIllness_OnSelectedIndexChanged" CssClass="form-control" runat="server" ID="dropDownHaveCriticalIllness">
                                        <asp:ListItem Text="no" Value="0" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="yes" Value="1"></asp:ListItem>
                                    </asp:DropDownList>

                                </div>
                                <div id="divCriticalIllnessCoverAmount" visible="False" runat="server" class="col-sm-2 col-md-2 col-lg-2">
                                    <h4>Amount:</h4>
                                    <asp:TextBox runat="server" TextMode="Number" CssClass="form-control" Text="" ID="txtCriticalIllnessCoverAmount"></asp:TextBox>
                                </div>
                                <div class="col-sm-2 col-md-2 col-lg-2">
                                    <h4>Policy term:</h4>
                                    <asp:DropDownList runat="server" ID="dropDownPolicyTerm" CssClass="form-control" />
                                </div>

                                <div class="col-sm-2 col-md-2 col-lg-2 pull-right">
                                    <asp:Button runat="server" CssClass="btn btn-success seeResultsBtn2" ID="btnUpdateResult" Text="Update" OnClick="btnUpdateResult_OnClick" />

                                </div>
                                <div class="clearfix"></div>
                            </div>



                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <p>Select up to 5 quotes to compare</p>
                            </div>

                            <asp:ListView runat="server" ID="lvInsuranceQuotesSearchResult">
                                <LayoutTemplate>
                                    <table class="table payasuDescTb table-hover">
                                        <thead>
                                            <tr>
                                                <%-- <th class="sl_th"></th>--%>
                                                <th class="img_th sort_th">Provider</th>
                                                <th class="sort_th">Premium </th>
                                                <th class="cont_th">Life Cover</th>
                                                <th class="mint_th">Critical Illness</th>
                                                <th class="text_th">Guaranteed Premium</th>
                                                <th class="date_th">Policy Term</th>
                                                <th class="montCst_th">Claims Paid</th>
                                                <th></th>
                                            </tr>
                                        </thead>
                                        <tbody id="itemPlaceholder" runat="server">
                                        </tbody>
                                    </table>
                                </LayoutTemplate>
                                <ItemTemplate>
                                    <tbody>
                                        <tr>
                                            <%-- <td class="sl_th">

                                        <div class="checkbox multiCkbox">
                                            <div class="btn-group" data-toggle="buttons">
                                                <label class="btn btn-default">
                                                    <input type="checkbox" autocomplete="off" />
                                                    <span class="glyphicon glyphicon-ok"></span>
                                                </label>
                                            </div>


                                        </div>
                                    </td>--%>
                                            <td style="text-align: center" class="img_td">
                                                <a href="<%# Eval("RedirectUrl") %>">
                                                    <img runat="server" width="100" height="50" src='<%# Eval("ProviderLogoUrl") %>' alt="img" /></a>
                                            </td>
                                            <td style="text-align: center" class="productDescription">
                                                <%# Eval("PremiumAmount") %>
                                            </td>
                                            <td style="text-align: center" class="cont_th">
                                                <p>Tk <%# Eval("CoverAmount") %></p>
                                            </td>
                                            <td style="text-align: center" class="mint_th glyphiconWrp">
                                                <%# Eval("CriticalIllnessHtmlString") %>

                                            </td>
                                            <td style="text-align: center" class="text_th glyphiconWrp">

                                                <%# Eval("IsGuaranteedPremiumHtmlString") %>
                                            </td>
                                            <td style="text-align: center" class="date_th">
                                                <p><%# Eval("PolicyTerm") %></p>
                                            </td>
                                            <td style="text-align: center" class="montCst_th">
                                                <p>
                                                    <%# Eval("ClaimsPaidPercent") %>
                                                </p>
                                            </td>
                                            <td>
                                                <div class="applyBox">
                                                    <a href="<%# Eval("RedirectUrl") %>" class="btn btn-seeMore2">Apply now</a>
                                                </div>
                                            </td>
                                        </tr>
                                    </tbody>
                                </ItemTemplate>
                            </asp:ListView>
                            <asp:DataPager ID="dataPagerInsuranceQuotesSearchResult" runat="server" PagedControlID="lvInsuranceQuotesSearchResult"
                                PageSize="10" OnPreRender="dataPagerInsuranceQuotesSearchResult_PreRender">
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

            </section>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

