<%@ Page Title="" Language="C#" MasterPageFile="~/InsuranceMaster.Master" AutoEventWireup="true" CodeBehind="CarInsuranceQuoteResults.aspx.cs" Inherits="OMart.Web.CarInsuranceQuoteResults" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-sm-9 col-md-9 col-lg-9">
            <div class="row">
                <asp:ListView ID="lv_CarInsuranceQuoteResults" runat="server" DataKeyNames="IID">
                    <LayoutTemplate>
                        <table class="table payasuDescTb table-hover" id="task-table">
                            <thead>
                                <tr runat="server">
                                    <th class="col-xs-2">Serial No</span> </th>
                                    <th class="col-xs-2"><span class="btn btn-danger">Insurance Company</span> </th>
                                    <th class="col-xs-2">Fixed Total Amount</th>
                                    <th class="col-xs-2">Fixed Voluntary Amount</th>
                                    <th class="col-xs-2">Fixed Compulsory Amount</th>
                                    <th class="col-xs-2">Annual Gross Amount</th>
                                    <th class="col-xs-2">Total Month</th>
                                    <th class="col-xs-2">Installment Amount</th>
                                    <th></th>
                                </tr>

                            </thead>
                            <tbody id="itemPlaceholder" runat="server">
                            </tbody>
                        </table>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr runat="server" class="sl_th">
                            <td style="text-align: center">
                                <%# Container.DataItemIndex + 1%>
                            </td>
                            <td class="img_td">
                                 <asp:Image runat="server" ID="image" ImageUrl='<%# Bind("LogoUrl") %>' Width="150" Height="75" />
                            </td>
                            <td class="cont_th">
                                <asp:Label ID="lblNote" runat="server" Text='<%# Bind("FixedTotalAmount") %>'></asp:Label>
                            </td>
                            <td class="mint_th">
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("FixedVoluntaryAmount") %>'></asp:Label>

                            </td>
                            <td class="text_th">
                                <asp:Label ID="Label5" runat="server" Text='<%# Bind("FixedCompulsoryAmount") %>'></asp:Label>

                            </td>
                            <td class="date_th">
                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("AnnuallyGrossAmount") %>'></asp:Label>
                            </td>
                            <td class="montCst_th">
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("TotalMonth") %>'></asp:Label>
                            </td>
                            <td class="montCst_th">
                                <asp:Label ID="Label6" runat="server" Text='<%# Bind("InstallmentAmount") %>'></asp:Label>
                            </td>

                            <td>
                                <td>
                                    <div class="applyBox">
                                        <%--   <img src="Images/products/0403_6.jpg" alt="img" />--%>
                                    </div>
                                </td>
                            </td>
                        </tr>

                    </ItemTemplate>
                    <EmptyDataTemplate>
                        <tr>
                            <td>
                                <h3 style="color: red; text-align: center">No match found ...
                                </h3>
                            </td>
                        </tr>
                    </EmptyDataTemplate>
                </asp:ListView>


                <div class="clearfix"></div>
            </div>
        </div>
    </div>
</asp:Content>
