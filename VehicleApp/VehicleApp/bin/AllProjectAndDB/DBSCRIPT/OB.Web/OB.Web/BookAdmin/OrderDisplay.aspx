<%@ Page Title="" Language="C#" MasterPageFile="~/BookAdmin/OiiOMasterPage.Master" AutoEventWireup="true" CodeBehind="OrderDisplay.aspx.cs" Inherits="OB.Web.BookAdmin.OrderDisplay" %>
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
                                <legend>Order Lists</legend>

                                <asp:ListView ID="lvOrder" runat="server" DataKeyNames="IID"
                                    OnPagePropertiesChanging="lvOrder_PagePropertiesChanging" OnPreRender="dataPagerOrder_PreRender">
                                  <LayoutTemplate>
                                        <table class="table  table-hover table-bordered">
                                            <thead>
                                                <tr runat="server">

                                                    <th class="col-xs-1">SL #
                                                    </th>
                                                    <th class="col-xs-1"> Quantity
                                                    </th>
                                                    <th class="col-xs-1">Shipping Address 
                                                    </th>
                                                    <th class="col-xs-1"> Shipping Cost
                                                    </th>
                                                    <th class="col-xs-1">Total Price
                                                    </th>
                                                    <th class="col-xs-1">Order Date 
                                                    </th>
                                                    <th class="col-xs-1"> User Comment 
                                                    </th>
                                                    <th class="col-xs-1">Additional Ph.
                                                    </th>
                                                      <th class="col-xs-1">Payment Status
                                                    </th>
                                                    <th class="col-xs-1"> Shipping Status
                                                    </th>
                                                    <th class="col-xs-1">Payment
                                                    </th>
                                                   <th class="col-xs-1">IsRem?
                                                    </th>
                                                 
                                                    <th >Edit
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
                                           
                                            <td style="text-align: left">
                                                <asp:Label ID="lblQuantity" runat="server" Text='<%# Bind("Quantity") %>'></asp:Label>
                                            </td>
                                             <td>
                                                <asp:Label ID="lblShippingAddress" runat="server" Text='<%# Bind("ShippingAddress") %>'></asp:Label>
                                            </td>
                                             <td>
                                                <asp:Label ID="lblShippingCost" runat="server" Text='<%# Bind("ShippingCost") %>'></asp:Label>
                                            </td>
                                             <td>
                                                <asp:Label ID="lblTotalPrice" runat="server" Text='<%# Bind("TotalPrice") %>'></asp:Label>
                                            </td>
                                             <td>
                                                <asp:Label ID="lblOrderDate" runat="server" Text='<%# Bind("OrderDate") %>'></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblUserComment" runat="server" Text='<%# Bind("UserComment") %>'></asp:Label>
                                            </td>
                                             <td>
                                                <asp:Label ID="lblAdditionalMobile" runat="server" Text='<%# Bind("AdditionalMobile") %>'></asp:Label>
                                            </td>
                                             <td>
                                                <asp:Label ID="lblPaymentStatusID" runat="server" Text='<%# Bind("PaymentStatusID") %>'></asp:Label>
                                            </td>
                                             <td>
                                                <asp:Label ID="lblShippingStatusID" runat="server" Text='<%# Bind("ShippingStatusID") %>'></asp:Label>
                                            </td>
                                             <td>
                                                <asp:Label ID="lblPayment" runat="server" Text='<%# Bind("Payment") %>'></asp:Label>
                                            </td>
                                      
                                             <td>
                                                <asp:CheckBox ID="chkremove" runat="server" Text='<%# Bind("IsRemoved") %>'></asp:CheckBox>
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
                                <asp:DataPager ID="dataPagerOrder" runat="server" PagedControlID="lvOrder"
                                    PageSize="10" OnPreRender="dataPagerOrder_PreRender">
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
