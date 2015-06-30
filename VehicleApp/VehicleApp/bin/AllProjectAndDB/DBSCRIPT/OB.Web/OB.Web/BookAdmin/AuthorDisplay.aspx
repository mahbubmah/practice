<%@ Page Title="" Language="C#" MasterPageFile="~/BookAdmin/OiiOMasterPage.Master" AutoEventWireup="true" CodeBehind="AuthorDisplay.aspx.cs" Inherits="OB.Web.BookAdmin.AuthorDisplay" %>
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
                        <asp:Label ID="labelMessage" runat="server"></asp:Label>
                    </div>
                    <div class="pull-right">

                        <asp:Button ID="btnAdd" runat="server" Text="Add New" OnClick="btnAdd_Click" CssClass="btn btn-primary" />
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-sm-12">
                    <div class="manageAdd">
                        <div class="addPostMang">

                            <fieldset class="adminFieldset">
                                <legend>Author Lists</legend>

                                <asp:ListView ID="lvAuthor" runat="server" DataKeyNames="IID"
                                    OnPagePropertiesChanging="lvAuthor_PagePropertiesChanging" OnPreRender="dataPagerAuthor_PreRender">
                                    <LayoutTemplate>
                                        <table class="table  table-hover table-bordered">
                                            <thead>
                                                <tr runat="server">
                                                    <th class="col-xs-1">SL #
                                                    </th>
                                                    <th class="col-xs-2">Author Name
                                                    </th>
                                                    <th class="col-xs-6">About Author 
                                                    </th>
                                                    <th class="col-xs-2">Favorite Qoute
                                                    </th>
                                                     <th class="col-xs-2">Country
                                                    </th>
                                                    <th class="col-xs-2">Is Featured
                                                    </th>
                                                     <th class="col-xs-2">Is Removed
                                                    </th>
                                                    <th>Edit
                                                    </th>
                                                    <th>Delete
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
                                                <asp:Label ID="lblName" runat="server" Text='<%# Bind("AuthorName") %>'></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblAboutAuthor" runat="server" Text='<%# Bind("AboutAuthor") %>'></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblFavQoute" runat="server" Text='<%# Bind("FavouriteQuote") %>'></asp:Label>
                                            </td>
                                              <td>
                                                <asp:Label ID="lblCountry" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                            </td>
                                             <td>
                                                <asp:CheckBox ID="chkIsFeatured" runat="server" Checked='<%# Bind("IsFeatured") %>' Enabled="false"></asp:CheckBox>
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="chkIsRemoved" runat="server" Checked='<%# Bind("IsRemoved") %>' Enabled="false"></asp:CheckBox>
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
                                <asp:DataPager ID="dataPagerAuthor" runat="server" PagedControlID="lvAuthor"
                                    PageSize="10" OnPreRender="dataPagerAuthor_PreRender">
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
