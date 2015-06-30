<%@ Page Title="" Language="C#" MasterPageFile="~/OiiOInnerMasterPage.Master" AutoEventWireup="true" CodeBehind="BookNewsDisplay.aspx.cs" Inherits="OB.Web.BookNewsDisplay" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderInnerPage" runat="server">
    <section>
    <div class="ContentArea commonH3titel compotationPage">
            <div class="contArea ">
                <hr class="hrLine" />
                <h3>News</h3>
                  <hr class="hrLine" />
                <asp:Repeater runat="server" ID="rptBookNewsShow" OnItemDataBound="rptBookNewsShow_ItemDataBound" >
                    <ItemTemplate>
                          <div class="well">
                    

                                <div class="newsItemInner">
                                    <div class="col-xs-2" >
                                        <asp:Image ID="img_inner" runat="server" Width="50px" Height="45" ImageUrl='<%# Eval("ImageUrl")%>' AlternateText="img" />

                                    </div>
                                    <div class="col-xs-10 newsItemPart">

                                        <h4>
                                            <asp:Literal ID="lblHeadline" runat="server" Text=' <%# Eval("HeadLine") %>'></asp:Literal></h4>

                                        <p>
                                            <asp:Literal ID="lblNewsDescription" runat="server" Text=' <%# Eval("NewsDescription").ToString().Substring(0,100) %>'></asp:Literal>
                                            <a runat="server" href='<%#"AllBookNewsDetails?Type="+OB.Utilities.StringCipher.Encrypt(Eval("IID").ToString())%>'>Read more</a>
                                        </p>
                                        <p>
                                            <%-- <asp:LinkButton ID="lnk_btn_Vedo_Lnk"  runat="server"  OnClick="lnk_btn_Vedo_Lnk_Click" CommandArgument='<%# Eval("IID") %>'  CssClass="list-group-item" target="blank">
                                                                   <asp:Literal ID="LiteralVedio" runat="server" Text=' <%# Eval("VideoLink") %>'></asp:Literal>
                                                                </asp:LinkButton>--%>
                                            <a rel="canonical" href="<%# Eval("VideoLink") %>" target="_blank">
                                                        <p>
                                                              <asp:Literal ID="LiteralVedio" runat="server" Text=' <%# Eval("VideoLink") %>'></asp:Literal>
                                                        </p>
                                                    </a>
                                          
                                        </p>
                                         <p>
                                            <%-- <asp:LinkButton ID="lnk_btn_Audio_Lnk" runat="server" CommandArgument='<%# Eval("IID") %>'  OnClick="lnk_btn_Audio_Lnk_Click" CssClass="list-group-item " target="blank">
                                                                   <asp:Literal ID="LiteralAudio" runat="server" Text=' <%# Eval("Audio") %>'></asp:Literal>
                                                                </asp:LinkButton>--%>
                                              <a rel="canonical" href="<%# Eval("Audio") %>" target="_blank">
                                                        <p>
                                                              <asp:Literal ID="LiteralAudio" runat="server" Text=' <%# Eval("Audio") %>'></asp:Literal>
                                                        </p>
                                                    </a>
                                          
                                        </p>
                                        <p>
                                            Published On:<%# Eval("PublishDate","{0:dd-MMM-yyyy}") %><%--<asp:Literal ID="lblPublishDate" runat="server" Text='<%# Eval("PublishDate","{0:dd-MMM-yyyy}") %>'> </asp:Literal>
                                            --%></p>
                                    </div>
                                    <div class="clearfix"></div>
                                </div>
                            
                         </div>
                        
                    </ItemTemplate>
                    
                </asp:Repeater>
                 <asp:LinkButton ID="lnk_btn_All_Lnk" runat="server" CommandArgument="1"  OnClick="lnk_btn_All_Lnk_Click" CssClass="list-group-item pull-right " Text="View All" target="blank">
                                                               
                                                                </asp:LinkButton>
                <%-- <div class="well">
                    Go behind the scences with the Ebury team for more infomation on life at the Ebury. Keep up to date with the latest events, awards, authors popping into the office and of course.. our cooking and baking triumphs.
                </div>
                 <div class="well">
                    Go behind the scences with the Ebury team for more infomation on life at the Ebury. Keep up to date with the latest events, awards, authors popping into the office and of course.. our cooking and baking triumphs.
                </div>
                 <div class="well">
                    Go behind the scences with the Ebury team for more infomation on life at the Ebury. Keep up to date with the latest events, awards, authors popping into the office and of course.. our cooking and baking triumphs.
                </div>
                 <div class="well">
                    Go behind the scences with the Ebury team for more infomation on life at the Ebury. Keep up to date with the latest events, awards, authors popping into the office and of course.. our cooking and baking triumphs.
                </div>
                 <div class="well">
                    Go behind the scences with the Ebury team for more infomation on life at the Ebury. Keep up to date with the latest events, awards, authors popping into the office and of course.. our cooking and baking triumphs.
                </div>--%>
              <%--  <p>Showing 0 - 0 of 0</p>--%>
                  
                
                
                <hr class="hrLine" />
               
            </div>
           
            


    </div>

    </section>

</asp:Content>
