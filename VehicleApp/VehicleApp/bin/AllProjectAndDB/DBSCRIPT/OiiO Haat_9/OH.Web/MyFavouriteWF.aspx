<%@ Page Title="" Language="C#" MasterPageFile="~/InnerMasterPage.Master" AutoEventWireup="true" CodeBehind="MyFavouriteWF.aspx.cs" Inherits="OH.Web.MyFavouriteWF" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headInner" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentInnerMain" runat="server">
    <div class="container">
         <div class="row">
            <asp:Label ID="lblMyfabourite" runat="server" Text=""></asp:Label>
        </div>
        <div class="clearfix">
        </div>

        <fieldset>
            <legend></legend>
            <div class="container postanAD">
                <div class="row">
                    <div class="col-md-12">
                        <div class="formHeadBorder">
                            <div class="form-group">
                                <h3>Manage My Favourites</h3>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-12">
                        <div class="manageAdd">
                            <div class="addPostMang">
                                <h4>
                                    <asp:Label ID="labelMyfvrt" runat="server" Text=""></asp:Label></h4>
                                <div class="table-responsive gridViewHaat">

                                    <asp:ListView ID="lvMyfvrt" runat="server" DataKeyNames="IID" OnItemCommand="lvMyfvrt_ItemCommand" OnPagePropertiesChanging="lvMyfvrt_PagePropertiesChanging">

                                        <LayoutTemplate>
                                            <table class="table table-bordred table-striped table-hover">
                                                <thead runat="server">
                                                    <th class="col-xs-2" style="text-align: center">Serial no
                                                    </th>
                                                    <th class="col-xs-2" style="text-align: left">Product Title
                                                    </th>

                                                    <th class="col-xs-2" style="text-align: left">Product Category
                                                    </th>
                                                    <th class="col-xs-1" style="text-align: left">
                                                      <th class="col-xs-1" style="text-align: left"> Delete
                                                        </th>
                                                </thead>
                                                <tbody id="itemPlaceholder" runat="server">
                                                </tbody>
                                            </table>
                                        </LayoutTemplate>
                                        <ItemTemplate>
                                            <tr id="trBody" runat="server">
                            <td style="text-align: center">
                                <%# Container.DataItemIndex + 1%>
                            </td>
                            <td style="text-align: left">
                                <asp:Label ID="lblMyfvrtID" runat="server" Text='<%# Bind("IID") %>' Visible="false"></asp:Label>
                                <asp:LinkButton ID="lnkBtnName" runat="server" CausesValidation="false" Text='<%#Bind("name")%>'
                                    CommandArgument='<%# Bind("IID") %>' CommandName="EditMyfvrt"></asp:LinkButton>
                            </td>
                                                <td style="text-align: left">
                                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("CatEgory") %>'></asp:Label>
                                                </td>

                                             <%--   <td style="text-align: left">
                                                    <asp:Label ID="lblCatergory" runat="server" Text='<%# Bind("CategoryName") %>'></asp:Label>
                                                </td>--%>

                                               
                                                <td style="text-align: center">
                                                    <td>
                                                        <p data-placement="top" data-toggle="tooltip" title="Delete">
                                                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" class="btn btn-danger btn-xs" data-title="Delete"  OnClientClick="return confirm('Are you sure to delete?');"
                                                                CommandArgument='<%# Bind("IID") %>' CommandName="DeleteMyfvrt"><i class="fa fa-trash"></i></asp:LinkButton>
                                                        </p>
                                                    </td>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                        <AlternatingItemTemplate>

                                            <tr class="bg-info" runat="server">
                                               <td style="text-align: center">
                                <%# Container.DataItemIndex + 1%>
                            </td>
                            <td style="text-align: left">
                                <asp:Label ID="lblMyfvrtID" runat="server" Text='<%# Bind("IID") %>' Visible="false"></asp:Label>
                                <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="false" Text='<%#Bind("name")%>'
                                    CommandArgument='<%# Bind("IID") %>' CommandName="EditMyfvrt"></asp:LinkButton>
                            </td>
                                                <td style="text-align: left">
                                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("CatEgory") %>'></asp:Label>
                                                </td>

                                               <%-- <td style="text-align: left">
                                                    <asp:Label ID="lblCatergory" runat="server" Text='<%# Bind("CategoryName") %>'></asp:Label>
                                                </td>--%>

                                               
                                                <td style="text-align: center">
                                                    <td>
                                                        <p data-placement="top" data-toggle="tooltip" title="Delete">
                                                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" class="btn btn-danger btn-xs" data-title="Delete" OnClientClick="return confirm('Are you sure to delete?');"
                                                                CommandArgument='<%# Bind("IID") %>' CommandName="DeleteMyfvrt"><i class="fa fa-trash"></i></asp:LinkButton>
                                                        </p>
                                                    </td>
                                                </td>

                                            </tr>
                                        </AlternatingItemTemplate>
                                        <EmptyDataTemplate>

                                            <tr>
                                                <td>Information is empty ...
                                                </td>
                                            </tr>
                                            </table>
                                        </EmptyDataTemplate>
                                    </asp:ListView>
                                    <asp:DataPager ID="dataPagerMyfvrt" runat="server" class="pagination pull-right pagItem" PagedControlID="lvMyfvrt"
                                        PageSize="10" OnPreRender="dataPagerMyfvrt_PreRender" >
                                        <Fields>
                                            <asp:NextPreviousPagerField
                                                ShowNextPageButton="False" />
                                            <asp:NumericPagerField PreviousPageText="..."
                                                RenderNonBreakingSpacesBetweenControls="True"
                                                ButtonType="Link" />
                                            <asp:NextPreviousPagerField ShowPreviousPageButton="False" />
                                        </Fields>
                                    </asp:DataPager>
                                </div>

                                <div class="table-responsive gridViewHaat">
                                   <%-- <asp:Label ID="label5" runat="server" Text=""></asp:Label>--%>

                                </div>

                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </fieldset>
        <asp:HiddenField ID="hdmyfvrt" runat="server" />
</div>
</asp:Content>
