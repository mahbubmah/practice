<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultMaster.Master" AutoEventWireup="true" CodeBehind="OiiOHelpSupportpage.aspx.cs" Inherits="OH.Web.OiiOHelpSupportpage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

              <section>
              
            <div class="container">
                <div class="mainPgCnt">
                	<div class="row">
                        <div class="col-md-12">
                        	<h2 class="pageTitelh2">OiiO Haat Help Support</h2>
                        </div>
                    </div>
                    
                     <asp:Repeater ID="rptrForAlert" runat="server" OnItemDataBound="rptrForAlert_ItemDataBound">
                         <ItemTemplate>
                         <div class="row">
                             <div class="col-md-12">
                                 <div class="form-group helpWrp">
                                     <div class="col-md-2">
                                        <h4><i class="fa fa-rss"></i>
                                             <asp:Label ID="lblAlertTitle" runat="server" Text='<%# Eval("Title") %>'></asp:Label></h4>
                                        </div>
                                       <div class="col-lg-10">
                                             <asp:Literal ID="ltrlAlertDescription" runat="server" Text='<%# Eval("Description") %>'></asp:Literal>
                                       </div>
                                     <div class="clearfix"></div>
                                 </div>
                             </div>
                          </div>
                        </ItemTemplate>
                     </asp:Repeater>  
                        
                  <%--   <div class="row">
                     <div class="col-md-12">
                    	<div class="form-group helpWrp">
                        	<div class="col-md-2">
                            	<h4 class="text-danger"><i class="fa fa-rss"></i> Site Alert !</h4>
                            </div>
                            <div class="col-lg-10">
                            <p>We are currently experiencing an issue where VAT receipts are not being sent out to you if you have purchased a Feature or have paid for an 
advert. We sincerely apologise for any inconvenience caused by this! We are aware of the issue; rest assured that we are working to get this 
issue resolved as soon as possible!</p>
                            </div>
                                <div class="clearfix"></div>                      
                        </div>
                         </div>
                    </div>--%>
                    
                   
                    
                 <asp:UpdatePanel ID="UpdatePanel3" runat="server">
        <ContentTemplate>
                    <div class="row">
                    <div class="col-sm-12 col-md-12 col-lg-12 " >
                        
                        
                        
                        
               <div class="panel with-nav-tabs panel-default oiioPanel">
                   <div class="panel-heading">
                            <!-- Nav tabs -->
                            <ul class="nav nav-tabs" >
                                <li  class="active" runat="server" id="liHelpHome" >
                              <%--      <a href="#carbuying" aria-controls="carbuying" role="tab" data-toggle="tab"> </a>--%>
                                     <asp:LinkButton runat="server" OnClick="lnkBtnhelpHome_Click" ID="lnkBtnhelpHome">
                                                 Help home
                                            <span class="badge badge-info">
                                                <asp:Label ID="lblhelpHome" runat="server"></asp:Label>
                                            </span>
                                                </asp:LinkButton>
                                </li>
                                <li runat="server" id="libasics">
                                <%--    <a href="#credithist" aria-controls="credithist" role="tab" data-toggle="tab"> </a>--%>
                                     <asp:LinkButton runat="server" OnClick="lnkBtnBasics_Click" ID="lnkBtnBasics">
                                                  Basics
                                            <span class="badge badge-info">
                                                <asp:Label ID="lblBasis" runat="server"></asp:Label>
                                            </span>
                                                </asp:LinkButton>
                                </li>
                                <li runat="server" id="lifaq">
                                  <%--  <a href="#carLoans" aria-controls="carLoans" role="tab" data-toggle="tab"> </a>--%>

                                    <asp:LinkButton runat="server" OnClick="lnkBtnFAQs_Click" ID="lnkBtnFAQs">
                                                 FAQ's
                                            <span class="badge badge-info">
                                                <asp:Label ID="lblFAQs" runat="server"></asp:Label>
                                            </span>
                                                </asp:LinkButton>
                                </li>
                                <li  runat="server" id="liWht">
                                    <%--<a href="#moiu" aria-controls="carLoans" role="tab" data-toggle="tab">Something not working? </a>--%>
                                      <asp:LinkButton runat="server" OnClick="lnkBtnhtsrong_Click" ID="lnkBtnhtsrong">
                                                 Something Not Working?
                                            <span class="badge badge-info">
                                                <asp:Label ID="lblWhtsWrong" runat="server"></asp:Label>
                                            </span>
                                                </asp:LinkButton>
                                </li>

                            </ul>
                       </div>
                            <!-- Tab panes -->
                    <div class="panel-body">
                            <div class="tab-content">
                                 <div class="tab-pane fade in active" id="tab1default">
                                      <div class="row panelBodyTop">
                                                    <div class="col-md-4 col-sm-4 col-lg-4">
                                                      
                                                    </div>
                                                    <div class="col-md-4 col-sm-4 col-lg-4 pull-right filterBox">
                                                    </div>
                                                </div>
                                     <div class="row">
                                         <asp:ObjectDataSource ID="objDataSourceForhelpSupport" runat="server"
                                                        EnablePaging="true"
                                                        TypeName="OH.BLL.Basic.HelpSupportRT"
                                                        SelectMethod="GetHelpSupportAccordingToHelpSupportID"
                                                        SelectCountMethod="GetCountTotalRowsForHelpSupport"
                                                        MaximumRowsParameterName="maxRowNumber"
                                                        StartRowIndexParameterName="startRowIndex"
                                                        OnSelecting="objDataSourceForhelpSupport_Selecting"></asp:ObjectDataSource>

                                                    <asp:ListView ID="lvForHelpsupport"
                                                        DataSourceID="objDataSourceForhelpSupport"
                                                        runat="server"
                                                        DataKeyNames="IID"
                                                        >

                                                        <ItemTemplate>
                                                            <div class="productRowWrp">
                                                                <div class="productRow" >
                                                                    <div style="margin-left:1%">
                                                                    <div class="text-danger">
                                                                        <asp:Label ID="lblTitleOfHelpSupport" runat="server" Text='<%# Eval("Title") %>' ></asp:Label>

                                                                    </div>  
                                                                     <div style="max-height:60px;overflow:hidden">
                                                                        <asp:Label ID="lblDescriptionHelpSupport" runat="server" Text='<%# Eval("Description") %>'></asp:Label>

                                                                    </div>                                                                                                    
                                                                        </div>
                                                                    </div>

                                                                    <div class="clearfix"></div>
                                                                </div>
                                                            
                                                        </ItemTemplate>
                                                    </asp:ListView>
                                                    <div class="paginationPart">
                                                        <asp:DataPager ID="dataPagerForHelpSupport" runat="server" PagedControlID="lvForHelpsupport"
                                                            PageSize="3">
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

                                   <%-- <h3>Need Help ?</h3>
                                    <div class="well3Inner">
                                        <div class="form-group">
                                            <div class="col-sm-1 col-md-1">
                                                <i class="fa fa-exclamation-triangle"></i>
                                            </div>
                                            <div class="col-sm-11 col-md-11">
                                                <h4>Something not working?</h4>
                                                <p>Can't log in, email confirmation, can't post an ad, can't reset password...</p>
                                            </div>
                                            <div class="clearfix"></div>
                                        </div>
                                        <div class="clearfix"></div>
                                    </div>--%>
                                </div>

                               <%-- <div role="tabpanel" class="tab-pane  " id="credithist">

                                    <div class="well3Inner">
                                        <div class="form-group">
                                            <div class="col-sm-1 col-md-1">
                                                <i class="fa fa-info-circle"></i>
                                            </div>
                                            <div class="col-md-11 col-md-11">
                                                <h4>Haat basics</h4>
                                                <p>Getting started, how to post ad, account setting, how to edit your ad...</p>
                                            </div>
                                            <div class="clearfix"></div>
                                        </div>

                                    </div>

                                </div>

                                <div role="tabpanel" class="tab-pane" id="carLoans">
                                    <div class="well3Inner">
                                        <div class="form-group">
                                            <div class="col-sm-1 col-md-1">
                                                <i class="fa fa-question-circle"></i>
                                            </div>
                                            <div class="col-sm-11 col-md-11">
                                                <h4>FAQ's</h4>
                                                <p>How do I post an ad, Why is my ad still processing?, I can't find my ad...</p>
                                            </div>
                                            <div class="clearfix"></div>
                                        </div>

                                    </div>
                                </div>

                               <div role="tabpanel" class="tab-pane" id="moiu">
                                    <div class="well3Inner">
                                        <div class="form-group">
                                            <div class="col-sm-1 col-md-1">
                                                <i class="fa fa-exclamation-triangle"></i>
                                            </div>
                                            <div class="col-sm-11 col-md-11">
                                                <h4>Something not working?</h4>
                                                <p>Can't log in, email confirmation, can't post an ad, can't reset password...</p>
                                            </div>
                                            <div class="clearfix"></div>

                                        </div>

                                    </div>
                                </div>--%>

                            </div>
                        </div>
                        </div>
                      </div>
                     </div> 
            </ContentTemplate>
                     </asp:UpdatePanel>   
                   </div>
                        
  
                    </div>
                  </section>

</asp:Content>
