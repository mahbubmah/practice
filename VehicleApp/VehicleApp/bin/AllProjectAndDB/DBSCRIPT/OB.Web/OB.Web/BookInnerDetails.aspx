<%@ Page Title="" Language="C#" MasterPageFile="~/OiiOInnerMasterPage.Master" AutoEventWireup="true" CodeBehind="BookInnerDetails.aspx.cs" Inherits="OB.Web.BookInnerDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderInnerPage" runat="server">
    <div class="ContentArea commonH3titel">
          <h3>View All Books </h3>
       <%-- <div class="bookBoxWrp">
            <div class="row">--%>
                <asp:Repeater ID="rpAllFictionBook" runat="server" OnItemDataBound="rpAllFictionBook_OnItemDataBound">
                    <ItemTemplate>
                        <%-- <div class="col-xs-4 col-sm-4 col-md-4  col-lg-4">--%>
                        <div class="bookBox">
                            <h4 style="text-align:left;"><span>Open</span> the Book</h4>
                            <div class="thumbnail">
                                <a runat="server" href='<%#"BookDetails?ID="+Eval("IID") %>'>
                                    <asp:Image runat="server" ID="img_Book" Class="img-responsive" width="150" Height="200" style="text-align:left;" ImageUrl='<%# Eval("ImageUrl") %>' alt="Image" />  &nbsp; 


                                    <h3>
                                      &nbsp;  <asp:Literal ID="ltrBookTitle" runat="server" Text=' <%# Eval("BookTitle") %>'></asp:Literal></h3>
                                </a>
                                <p>
                                    <a runat="server" href='<%#"BookAuthLists?ID="+Eval("IID") %>'>
                                       &nbsp; <asp:Literal ID="ltrAuthorName" runat="server" Text=' <%# Eval("AuthorName") %>'></asp:Literal>
                                    </a>
                                </p>
                                <p>
                                  &nbsp;  &nbsp;  <asp:Literal ID="ltrAbstract" runat="server" Text=' <%# Eval("Abstract") %>'></asp:Literal>
                                </p>

                            </div>
                        </div>
                        <%--   </div>--%>
                    </ItemTemplate>
                </asp:Repeater>

         <%--   </div>
        </div>--%>
    </div>
</asp:Content>
