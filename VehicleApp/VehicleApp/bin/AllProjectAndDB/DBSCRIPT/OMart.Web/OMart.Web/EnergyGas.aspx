<%@ Page Title="" Language="C#" MasterPageFile="~/EnergyMaster.Master" AutoEventWireup="true" CodeBehind="EnergyGas.aspx.cs" Inherits="OMart.Web.EnergyGas" %>
<%@ Import Namespace="Utilities" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <section>
        <div class="container payasuDesc">
            <div class="row topLeadIns">
                <div class="col-xs-2 col-sm-2">
                    <h4>We impartially compare all of these suppliers and more...</h4>
                    <asp:Label ID="labelMessage" runat="server"></asp:Label>
                </div>
                <div class="col-xs-10 col-sm-10">
                    <asp:Repeater runat="server" ID="repEnergyCompanyLogo">
                        <ItemTemplate>
                            <asp:Image runat="server" CssClass="img-thumbnail img-responsive" ImageUrl='<%# Eval("LogoUrl") %>' Width="115" Height="90" />
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-4 col-md-4 col-lg-4">
                    <div class="leftSidebar">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <div class="updateForm">
                                    <div class="row">
                                        <div class="row_A">
                                            <div class="col-xs-5">
                                                <label>Company name</label>
                                            </div>
                                            <div class="col-xs-7">
                                                <asp:DropDownList runat="server" CssClass="form-control" ID="dropDownCompanyInfo" AutoPostBack="True" />
                                            </div>
                                            <div class="clearfix"></div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="row_A">
                                            <div class="col-xs-5">
                                                <label>District name</label>
                                            </div>
                                            <div class="col-xs-7">
                                                <asp:HiddenField runat="server" ID="hdCountryID" />
                                                <asp:DropDownList AutoPostBack="True" runat="server" CssClass="form-control" ID="dropDwonForDistrict" />
                                            </div>
                                            <div class="clearfix"></div>
                                        </div>
                                    </div>
                                    <%--<div class="row">
                                        <div class="row_A">
                                            <div class="col-xs-5">
                                                <label>Police station name</label>
                                            </div>
                                            <div class="col-xs-7">
                                                <asp:DropDownList runat="server" CssClass="form-control" ID="dropDownPoliceStation" />
                                            </div>
                                            <div class="clearfix"></div>
                                        </div>
                                    </div>--%>
                                    <div class="row">
                                        <div class="row_A">
                                            <div class="col-xs-5">
                                                <label>Amount of gas</label>
                                            </div>
                                            <div class="col-xs-7">
                                                <asp:TextBox runat="server" TextMode="Number" ID="txtSearchAmountOfGas" CssClass="form-control"></asp:TextBox>

                                            </div>
                                            <div class="clearfix"></div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-12">
                                            <asp:Button runat="server" CssClass="btn btn-primary btn-block updateBtn" Text="Update" OnClick="UpdateSearchResult" />
                                            <%--   <input type="button" class="btn btn-primary btn-block updateBtn" value="Update" />--%>
                                        </div>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <div class="updateProduct">
                            <asp:Repeater runat="server" ID="repEnergyGuideLine">
                                <ItemTemplate>
                                    <div class="updateProductRow">
                                        <asp:Image runat="server" ID="image" ImageUrl='<%# Eval("ImageUrl") %>' Height="75" Width="150"/>
                                        <h3><%# Eval("Title") %></h3>
                                        <p><%# Eval("Description") %>...</p>
                                        <p><a href='GuideLineDetails.aspx?ID= <%#StringCipher.Encrypt(Eval("GuideLineIid").ToString())%>'>Read more</a></p>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <div class="col-sm-8 col-md-8 col-lg-8">
                            <div class="payasuDesc broadbandDeals">

                                <asp:ListView runat="server" ID="lvGasSearchResult"
                                    OnPagePropertiesChanging="lvGasSearchResult_OnPagePropertiesChanging"
                                    OnPreRender="dataPagerGasSearchResult_PreRender">
                                    <LayoutTemplate>
                                        <table class="table payasuDescTb table-hover" id="task-table">
                                            <thead>
                                                <tr runat="server">
                                                    <th class="same_th">Company name</th>
                                                    <th class="same_th" style="text-align: center">Amount of gas</th>
                                                    <th class="same_th" style="text-align: center">Container weight</th>
                                                    <th class="same_th" style="text-align: center">Price</th>
                                                    <th class="same_th" style="text-align: center">Go to</th>
                                                </tr>
                                            </thead>
                                            <tbody id="itemPlaceholder" runat="server">
                                            </tbody>
                                        </table>
                                    </LayoutTemplate>
                                    <ItemTemplate>
                                        <tr runat="server">
                                            <td class="same_td same_td_1" style="text-align: left">
                                                <a runat="server" target="_blank" href='<%# Eval("WebAddress") %>'>
                                                    <asp:Image runat="server" ImageUrl='<%# Eval("LogoUrl") %>' Width="150" Height="50" /></a>

                                                <h4>
                                                    <asp:Label runat="server" Text='<%# Eval("CompanyName") %>'></asp:Label>
                                                </h4>
                                            </td>
                                            <td class="same_td same_td_2" style="text-align: center">
                                                <h4><%# Eval("WeightOfGas","{0:0.##}") %> KG</h4>
                                            </td>
                                            <td class="same_td same_td_3" style="text-align: center">
                                                <h4><%# Eval("WeightOfContainer","{0:0.##}") %> KG</h4>
                                            </td>
                                            <td class="same_td same_td_4" style="text-align: center">
                                                <h4><%# Eval("RetailPrice","{0:0.##}") %> TK</h4>
                                            </td>
                                            <td class="same_td same_td_5 applyBox" style="text-align: center">
                                                <br />
                                                <a runat="server" target="_blank" href='<%# Eval("RedirectUrl") %>' class="btn btn-infor">More info<span class="glyphicon glyphicon-chevron-down oioCherRight3"></span></a>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <EmptyDataTemplate>
                                        <tr>
                                            <td>Information is empty ...
                                            </td>
                                        </tr>
                                        </table>
                                    </EmptyDataTemplate>
                                </asp:ListView>
                            </div>
                            <asp:DataPager ID="dataPagerGasSearchResult" runat="server" PagedControlID="lvGasSearchResult"
                                PageSize="10" OnPreRender="dataPagerGasSearchResult_PreRender">
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
                            <%--  <div class="row">
                        <div class="col-md-12">
                            <a href="Insurance_Quotes.aspx" class="btn btn-primary seeResultsBtn">Show all deals</a>
                        </div>
                    </div>--%>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </section>
</asp:Content>

