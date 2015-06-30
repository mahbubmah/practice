<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultMaster.Master" AutoEventWireup="true" CodeBehind="SearchWeb.aspx.cs" Inherits="OH.Web.SearchWeb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

      <div class="mainBodyWrp">
        <section>
            <div class="container">
                <div class="well searchPanel3">
                    <div class="col-sm-4 col-md-4 col-lg-4">

                        <div class="selectWant">
                        </div>
                    </div>
                    <br />
                    <div class="panel-body">
                        <div class="tab-content">
                            <div class="tab-pane fade in active" id="tab1default">
                                <asp:Label ID="lblSearchWholeweb" runat="server" Text=""></asp:Label>
                                <div class="row panelBodyTop">
                                    <div class="col-md-4 col-sm-4 col-lg-4">
                                     <asp:Label ID="lblSearchCount" runat="server" Text=""></asp:Label>
                                    </div>
                                    <div class="col-md-4 col-sm-4 col-lg-4 pull-right filterBox">
                                    </div>
                                </div>

                                <div class="row">

                                    <asp:ListView ID="lvSearch" runat="server" DataKeyNames="IID" OnPagePropertiesChanging="lvSearch_PagePropertiesChanging" OnPreRender="lvSearch_PreRender" >

                                        <ItemTemplate>
                                            <div class="productRowWrp">
                                                <div class="productRow">
                                                    <div>
                                                        <asp:Label ID="lblSearchID" runat="server" Text='<%# Eval("IID") %>' Visible="false"></asp:Label>
                                                    </div>
                                        
                                                    <div class="col-xs-9 productDetails">
                                                        <a href='<%#"DetailPage?option="+OH.Utilities.StringCipher.Encrypt(Eval("IID").ToString()) %>'>
                                                            <asp:Label ID="lblBrandName" runat="server">  <h4 class="SearchItems-name"><%# Eval("TitleName")%></h4> </asp:Label>
                                                        </a>
                                                        <p><span style="color:blue">Category Name:&nbsp</span>
                                                            <asp:Label ID="lblCatagoryName" runat="server" Text='<%# Eval("CategoryName") %>'></asp:Label>
                                                        <br>
                                                              <span style="color:blue">Discription:&nbsp</span>
                                                            <asp:Label ID="lblDescription" runat="server" Text='<%# Eval("Matdis") %>'></asp:Label>
                                                        </p>

                                                   

                                                    </div>

                                                    <div class="clearfix"></div>
                                                </div>
                                            </div>
                                        </ItemTemplate>
                                        <AlternatingItemTemplate>

                                            <div class="productRowWrp">
                                                <div class="productRow">
                                                    <div>
                                                        <asp:Label ID="lblSearchID" runat="server" Text='<%# Eval("IID") %>' Visible="false"></asp:Label>
                                                    </div>
                              
                                                    <div class="col-xs-9 productDetails">
                                                        <a href='<%#"DetailPage?option="+OH.Utilities.StringCipher.Encrypt(Eval("IID").ToString()) %>'>
                                                            <asp:Label ID="lblBrandName" runat="server">  <h4 class="SearchItems-name"><%# Eval("TitleName")%></h4> </asp:Label>
                                                        </a>
                                                          <p><span style="color:blue">Category Name:&nbsp</span>
                                                            <asp:Label ID="lblCatagoryName" runat="server" Text='<%# Eval("CategoryName") %>'></asp:Label>
                                                       
                                                       <br>
                                                              <span style="color:blue">Discription:&nbsp</span>
                                                            <asp:Label ID="lblDescription" runat="server" Text='<%# Eval("Matdis") %>'></asp:Label>
                                                        
                                                                  </p>

                                                     

                                                    </div>

                                                    <div class="clearfix"></div>
                                                </div>
                                            </div>

                                        </AlternatingItemTemplate>

                                         <%--<ItemTemplate>
                     
                                              <div class="productRowWrp">
                                                <div class="productRow">
                                                    <div>
                                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("IID") %>' Visible="false"></asp:Label>
                                                    </div>
                              
                                                    <div class="col-xs-9 productDetails">
                                                        <a href="<%#"DetailPage?ID="+Eval("IID") %>">
                                                            <asp:Label ID="Label2" runat="server">  <h4 class="SearchItems-name"><%# Eval("TitleName")%></h4> </asp:Label>
                                                        </a>
                                                        <p>
                                                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("Matdis") %>'></asp:Label>
                                                        </p>

                                                     

                                                    </div>

                                                    <div class="clearfix"></div>
                                                </div>
                                            </div>
                                        </ItemTemplate>
                                       <AlternatingItemTemplate>

                                                                  <div class="productRowWrp">
                                                <div class="productRow">
                                                    <div>
                                                        <asp:Label ID="lblSearchID" runat="server" Text='<%# Eval("catID") %>' Visible="false"></asp:Label>
                                                    </div>
                              
                                                    <div class="col-xs-9 productDetails">
                                                        <a href="<%#"DetailPage?ID="+Eval("catID") %>">
                                                            <asp:Label ID="lblBrandName" runat="server">  <h4 class="SearchItems-name"><%# Eval("CategoryName")%></h4> </asp:Label>
                                                        </a>
                                                        <p>
                                                            <asp:Label ID="lblDescription" runat="server" Text='<%# Eval("catdis") %>'></asp:Label>
                                                        </p>

                                                 

                                                    </div>

                                                    <div class="clearfix"></div>
                                                </div>
                                            </div>

                                        </AlternatingItemTemplate>--%>

                                    </asp:ListView>

                                      <asp:ListView ID="lvStaticView" runat="server"  OnPagePropertiesChanging="lvStaticView_PagePropertiesChanging" >

                                        <ItemTemplate>
                                            <div class="productRowWrp">
                                                <div class="productRow">                                        
                                                    <div class="col-xs-9 productDetails" >

                                                         <a href='<%# Eval("UrlName")%>'>
                                                             <h4 class="SearchItems-name">
                                                   <asp:Label ID="lblBrandName" runat="server">  <h4 class=""><%# Eval("UrlName")%></h4> </asp:Label>
                                                                 </h4>
                                                        </a>
                                                        <p><span style="color:blue">Discription:&nbsp</span>
                                                            <asp:Label ID="lblDescription" runat="server" Text='<%# Eval("FindString") %>'></asp:Label>
                                                        </p>
                                                    
                                                    </div>
                                                    <div class="clearfix"></div>
                                                </div>
                                            </div>
                                        </ItemTemplate>

                                    </asp:ListView>


                                    <div class="paginationPart">

                                        <asp:DataPager ID="dataPagerSearch" runat="server" PagedControlID="lvSearch" 
                                            PageSize="7" OnPreRender="dataPagerSearch_PreRender"  ClientIDMode="AutoID">
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
                                          <asp:DataPager ID="dataPagerStaticSearch" runat="server" PagedControlID="lvStaticView" 
                                            PageSize="3" OnPreRender="dataPagerStaticSearch_PreRender"  >
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

                        <div class="clearfix">
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </div>


</asp:Content>
