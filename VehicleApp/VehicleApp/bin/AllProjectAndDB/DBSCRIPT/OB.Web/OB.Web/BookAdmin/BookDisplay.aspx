<%@ Page Title="" Language="C#" MasterPageFile="~/BookAdmin/OiiOMasterPage.Master" AutoEventWireup="true" CodeBehind="BookDisplay.aspx.cs" Inherits="OB.Web.BookAdmin.BookDisplay" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <section>
     <div class="mainpageBody">
        <div class="container">

            <br />
            <div class="row">
                <div class="col-sm-12">
                    <div class="pull-left">
                        <asp:Label ID="lblMessage" runat="server"></asp:Label>
                    </div>
                    <div class="pull-right">

                        <asp:Button ID="btnAdd" runat="server" Text="Add New" OnClick="btnAdd_Click" CssClass="btn btn-primary" />
                    </div>
                </div>
            </div>

            <div class="row pull-left">
                <div class="col-sm-12 ">
                    <div class="manageAdd">
                        <div class="addPostMang">

                            <fieldset class="adminFieldset">
                                <legend>Book Lists</legend>

                                <asp:ListView ID="lvBookDisplay" runat="server" DataKeyNames="IID"
                                    OnPagePropertiesChanging="lvBookDisplay_PagePropertiesChanging" OnPreRender="dataPagerBookDisplay_PreRender">
                                    <LayoutTemplate>
                                        <table class="table  table-hover table-bordered">
                                            <thead>
                                                <tr runat="server">

                                                    <th class="col-xs-1">SL #
                                                    </th>
                                                   
                                                    <th class="col-xs-1">P.Category 
                                                    </th>
                                                     <th class="col-xs-2"> Title
                                                    </th>
                                                     <th class="col-xs-1">Category 
                                                    </th>
                                                    <th class="col-xs-1"> Author
                                                    </th>
                                                    <th class="col-xs-1">Publisher
                                                    </th>
                                                    <th class="col-xs-1"> ISBN 
                                                    </th>
                                                    <th class="col-xs-1">Price
                                                    </th>
                                                    <th class="col-xs-1">Quantity
                                                    </th>
                                                    <th class="col-xs-1"> PublishedIn?
                                                    </th>
                                                    <th class="col-xs-1">Latest?
                                                    </th>
                                                      <th class="col-xs-1">Recomm?
                                                    </th>
                                                    <th class="col-xs-1">Display Day(s)
                                                    </th>
                                                    <th class="col-xs-1">Edit
                                                    </th>
                                                    <th >Delete
                                                    </th>
                                                </tr>
                                            </thead>
                                            <tbody id="itemPlaceholder" runat="server">
                                            </tbody>
                                        </table>
                                    </LayoutTemplate>
                                    <ItemTemplate>
                                        <tr runat="server">
                                            <td style="text-align: center">
                                                <%# Container.DataItemIndex + 1%>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("ParentCategory") %>'></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblName" runat="server" Text='<%# Bind("BookTitle") %>'></asp:Label>
                                            </td>
                                             <td>
                                                <asp:Label ID="lblNetworkProviderID" runat="server" Text='<%# Bind("CategoryName") %>'></asp:Label>
                                            </td>
                                             <td>
                                                <asp:Label ID="lblMPTypeID" runat="server" Text='<%# Bind("AuthorName") %>'></asp:Label>
                                            </td>
                                             <td>
                                                <asp:Label ID="lblSIMAvailableID" runat="server" Text='<%# Bind("PublisherName") %>'></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblTotalTalkTime" runat="server" Text='<%# Bind("ISBN") %>'></asp:Label>
                                            </td>
                                             <td>
                                                <asp:Label ID="lblTalkTimeUnitID" runat="server" Text='<%# Bind("Price") %>'></asp:Label>
                                            </td>
                                          
                                             <td>
                                                <asp:Label ID="lblConnectionTypeID" runat="server" Text='<%# Bind("Quantity") %>'></asp:Label>
                                            </td>
                                              <td >
                                                <asp:Label ID="lblTotalPrice" runat="server" Text='<%# Bind("PublishedDate","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                            </td>
                                             <td>
                                                <asp:CheckBox ID="chklatest" Enabled="false" runat="server" ></asp:CheckBox>
                                            </td>
                                             <td>
                                                <asp:CheckBox ID="chkrecom" Enabled="false" runat="server" ></asp:CheckBox>
                                            </td>
                                          
                                             <td>
                                                <asp:Label ID="lblPostLastDisplayDate" runat="server" Text='<%# Bind("LastVisibilityDate","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                            </td>
                                            
                                          <td>
                                                <p data-placement="top" data-toggle="tooltip" title="Edit">
                                                    <asp:LinkButton ID="lnkbEdit" runat="server" CausesValidation="false" class="btn btn-primary btn-xs" data-title="Edit"
                                                        CommandArgument='<%# Bind("IID") %>' OnClick="lnkbEdit_Click"><i class="fa fa-pencil-square-o"></i></asp:LinkButton>

                                                </p>
                                            </td>
                                            <td>
                                                <p data-placement="top" data-toggle="tooltip" title="Delete">
                                                    <asp:LinkButton ID="lnkbDelete" runat="server" CausesValidation="false" class="btn btn-danger btn-xs" data-title="Delete" OnClientClick="return confirm('Are you sure, do you want to delete?');"
                                                        CommandArgument='<%# Bind("IID") %>' OnClick="lnkbDelete_Click"><i class="fa fa-trash"></i></asp:LinkButton>
                                                </p>
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
                                <asp:DataPager ID="dataPagerBookDisplay" runat="server" PagedControlID="lvBookDisplay"
                                    PageSize="10" OnPreRender="dataPagerBookDisplay_PreRender">
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
                            </fieldset>
                        </div>
                    </div>
                </div>
            </div>
        </div>
         </div>
    </section>
</asp:Content>

