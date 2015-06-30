<%@ Page Title="" Language="C#" MasterPageFile="~/OiiOMasterPage.Master" AutoEventWireup="true" CodeBehind="AllNewsDetails.aspx.cs" Inherits="OMart.Web.AllNewsDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="h3">
            <h3>All News Informaiton </h3>
        </div>
        <br />
        <asp:Repeater ID="repAllTypeNews" runat="server">

            <ItemTemplate>
                <div class="col-sm-3 col-md-3 col-lg-3">
                    <div class="loanServBox">
                        <a href='<%#"AllNewsDetails?ID="+Utilities.StringCipher.Encrypt(Eval("IID").ToString()) %>' runat="server">
                            <asp:Image ID="imgImageUrl" CssClass="img-responsive" runat="server" ImageUrl='<%# Bind("ImageUrl")%>' AlternateText="img" Width="250" Height="170" />
                        </a>
                        <div class="loanservBoxCnt">
                            <h5>
                                <a href='<%#"AllNewsDetails?ID="+Utilities.StringCipher.Encrypt(Eval("IID").ToString()) %>' class="readstory">
                                    <asp:Label ID="titleOfBankingBusinessType" runat="server" Text='<%#Bind("TitleName")%>'></asp:Label>
                                </a></h5>
                            <a href='<%#"AllNewsDetails?ID="+Utilities.StringCipher.Encrypt(Eval("IID").ToString()) %>' class="readstory">Read more <span class="glyphicon glyphicon-chevron-right oioCherRight2 oioCherRight3"></span></a>
                        </div>

                    </div>

                </div>
            </ItemTemplate>
        </asp:Repeater>



        <div class="clearfix">
        </div>
        <br />


        <div class="well searchPanel3">

            <div class="row panelBodyTop">
                <div class="col-md-12 col-sm-12 col-lg-12">
                    <div class="col-md-8 col-sm-8 col-lg-8">
                        <h3>
                            <asp:Label ID="lbltype" runat="server" Text='<%# Enum.Parse(typeof( Utilities.EnumCollection.BussinessType),Eval("BusinessTypeID").ToString()) %>'></asp:Label>

                        </h3>

                        <h5>
                            <asp:Label ID="lblTitle" runat="server" Text='<%# Eval("TitleName") %>'></asp:Label>
                        </h5>

                        <h6>
                            <asp:Label ID="lblDescription" runat="server" Text='<%# Eval("Description") %>'></asp:Label>
                        </h6>
                    </div>
                    <div class="col-md-4 col-sm-4 col-lg-4">
                        <div class="thumbnail productimg2 ">
                            <asp:Image ID="img" runat="server" Height="300" Width="400" ImageUrl='<%# Eval("ImageUrl")%>' AlternateText="img" />
                        </div>
                    </div>
                </div>
            </div>


            <br />
            <div class="panel-body">
                <div class="tab-content">
                    <div class="tab-pane fade in active" id="tab1default">

                        <div class="row panelBodyTop">
                            <div class="col-md-4 col-sm-4 col-lg-4">
                                <h4>All Detail News Information <span>
                                    <asp:Label ID="lblBusinessTypeName" runat="server" Text='<%# Enum.Parse(typeof( Utilities.EnumCollection.BussinessType),Eval("BusinessTypeID").ToString()) %>'></asp:Label>

                                </span></h4>
                                <hr />
                            </div>
                            <div class="col-md-4 col-sm-4 col-lg-4 pull-right filterBox">
                            </div>
                        </div>

                        <div class="row">


                            <asp:ObjectDataSource ID="objDataSourceNewsDetails" runat="server"
                                EnablePaging="true"
                                OnSelecting="objDataSourceNewsDetails_Selecting"
                                TypeName="BLL.Basic.AllNewsRT"
                                SelectMethod="GetAllNewsDetailListByAllNesIid"
                                SelectCountMethod="CountAllNewsDetailsByAllNewsID"
                                MaximumRowsParameterName="maxRowNumber"
                                StartRowIndexParameterName="startRowIndex"></asp:ObjectDataSource>

                            <asp:ListView ID="lvAllNewsDetails" DataSourceID="objDataSourceNewsDetails" runat="server" DataKeyNames="IID">

                                <ItemTemplate>
                                    <div class="productRowWrp">
                                        <div class="productRow">
                                            <h4>
                                                <%--          <a runat="server" href='<%#"GuideLineMoreDetails?ID="+Eval("IID") %>'>--%>
                                                <asp:Literal ID="lblNewsTypeName" runat="server" Text=' <%# Eval("TitleName") %>'></asp:Literal>
                                                <%--                                                </a>--%>
                                            </h4>
                                            <div class="col-xs-3">
                                                <div class="thumbnail productimg2">

                                                    <asp:Image ID="img_inner" runat="server" Width="100%" ImageUrl='<%# Eval("ImageUrl")%>' AlternateText="img" />

                                                </div>
                                            </div>
                                            <div class="col-xs-9 productDetails">

                                                <p>
                                                    <asp:Label ID="lblNewsTypeDescription" runat="server" Text='<%# Eval("Description") %>'></asp:Label>
                                                </p>

                                                <div class="productPostDate">
                                                </div>

                                            </div>
                                            <div class="clearfix"></div>
                                        </div>
                                    </div>
                                    <hr />
                                </ItemTemplate>

                                <EmptyDataTemplate>
                                    <table>
                                        <tr>
                                            <td>Information is empty ...
                                            </td>
                                        </tr>
                                    </table>
                                </EmptyDataTemplate>

                            </asp:ListView>

                            <div class="paginationPart">

                                <asp:DataPager ID="dataPagerAllGuides" runat="server" PagedControlID="lvAllNewsDetails"
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

                <div class="clearfix">
                </div>
            </div>
        </div>


    </div>


</asp:Content>
