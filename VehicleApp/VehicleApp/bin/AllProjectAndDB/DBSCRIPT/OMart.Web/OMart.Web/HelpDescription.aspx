<%@ Page Title="" Language="C#" MasterPageFile="~/OiiOMasterPage.Master" AutoEventWireup="true" CodeBehind="HelpDescription.aspx.cs" Inherits="OMart.Web.HelpDescription" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="DefaultPageSlide" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <section>
        <div style="background-color: White;margin-left:20px; padding: 20px;">
            <div class="row">
                
                        <div class="productRowWrp">
                            <div class="productRow">
                                <h3 style="font-weight: 800; color: #d40101; font-size: 30px; line-height: 35px;text-align:center;margin-bottom:20px;">
                                    <asp:Label ID="ltrTitle" runat="server" ></asp:Label>
                                </h3>
                                <div class="col-xs-3">
                                    <div class="thumbnail productimg2">
                                        <asp:Image ID="img_inner" runat="server" Width="292" Height="260"  AlternateText="img" />
                                    </div>
                                </div>
                                <div class="col-xs-9 productDetails">
                                    <p>
                                        <asp:Literal ID="ltrDescription" runat="server" ></asp:Literal>
                                    </p>
                                </div>
                                <div class="clearfix"></div>
                            </div>
                        </div>
                        <hr />
                   
            </div>

        </div>
    </section>
</asp:Content>
