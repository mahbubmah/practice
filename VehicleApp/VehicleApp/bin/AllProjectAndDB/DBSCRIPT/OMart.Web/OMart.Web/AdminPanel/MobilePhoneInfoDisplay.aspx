<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.Master" AutoEventWireup="true" CodeBehind="MobilePhoneInfoDisplay.aspx.cs" Inherits="OMart.Web.AdminPanel.MobilePhoneInfoDisplay" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AdminHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AdminContentPlaceHolder" runat="server">
 <section>
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

            <div class="row">
                <div class="col-sm-12 ">
                    <div class="manageAdd">
                        <div class="addPostMang">

                            <fieldset class="adminFieldset">
                                <legend>Mobile Phone Lists</legend>

                                <asp:ListView ID="lvMobilePhoneInfoDisplay" runat="server" DataKeyNames="IID"
                                    OnPagePropertiesChanging="lvMobilePhoneInfoDisplay_PagePropertiesChanging" OnPreRender="dataPagerMobilePhoneInfoDisplay_PreRender">
                                    <LayoutTemplate>
                                        <table class="table  table-hover table-bordered">
                                            <thead>
                                                <tr runat="server">

                                                    <th class="col-xs-1">SL #
                                                    </th>
                                                    <th class="col-xs-1"> Company
                                                    </th>
                                                    <th class="col-xs-1">Network 
                                                    </th>
                                                    <th class="col-xs-1"> Phone Type
                                                    </th>
                                                    <th class="col-xs-1">SIM ?
                                                    </th>
                                                    <th class="col-xs-1">Model 
                                                    </th>
                                                    <th class="col-xs-1"> TalkTime
                                                    </th>
                                                    <th class="col-xs-1">Time Unit
                                                    </th>
                                                      <th class="col-xs-1">TextSMS
                                                    </th>
                                                    <th class="col-xs-1"> UsableData
                                                    </th>
                                                    <th class="col-xs-1">Data Unit
                                                    </th>
                                                    <th class="col-xs-1">Conn. Type
                                                    </th>
                                                    <th class="col-xs-1"> Price
                                                    </th>
                                                    <th class="col-xs-1">Duration
                                                    </th>
                                                      <th class="col-xs-1">Inst_Amt
                                                    </th>
                                                  <%--  <th class="col-xs-1">Warranty Info
                                                    </th>
                                                    <th class="col-xs-1">Post AdDate
                                                    </th>--%>
                                                    <th class="col-xs-1">DisplayDate
                                                    </th>
                                                   <%-- <th class="col-xs-1">Redirect Url
                                                    </th>
                                                    <th>Eject?
                                                    </th>--%>
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
                                                <asp:Label ID="lblName" runat="server" Text='<%# Bind("CompanyName") %>'></asp:Label>
                                            </td>
                                             <td>
                                                <asp:Label ID="lblNetworkProviderID" runat="server" Text='<%# Bind("NetworkServiceProvider") %>'></asp:Label>
                                            </td>
                                             <td>
                                                <asp:Label ID="lblMPTypeID" runat="server" Text='<%# Bind("MPTypeName") %>'></asp:Label>
                                            </td>
                                             <td>
                                                <asp:Label ID="lblSIMAvailableID" runat="server" Text='<%# Bind("SIMAvailable") %>'></asp:Label>
                                            </td>
                                             <td>
                                                <asp:Label ID="lblModelName" runat="server" Text='<%# Bind("ModelName") %>'></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblTotalTalkTime" runat="server" Text='<%# Bind("TotalTalkTime") %>'></asp:Label>
                                            </td>
                                             <td>
                                                <asp:Label ID="lblTalkTimeUnitID" runat="server" Text='<%# Bind("TalkTimeUnit") %>'></asp:Label>
                                            </td>
                                             <td>
                                                <asp:Label ID="lblTotalTextMessage" runat="server" Text='<%# Bind("TotalTextMessage") %>'></asp:Label>
                                            </td>
                                             <td>
                                                <asp:Label ID="lblTotalUsableData" runat="server" Text='<%# Bind("TotalUsableData") %>'></asp:Label>
                                            </td>
                                             <td>
                                                <asp:Label ID="lblUsableDataUnitID" runat="server" Text='<%# Bind("UsableDataUnit") %>'></asp:Label>
                                            </td>
                                             <td>
                                                <asp:Label ID="lblConnectionTypeID" runat="server" Text='<%# Bind("ConnectionType") %>'></asp:Label>
                                            </td>
                                              <td >
                                                <asp:Label ID="lblTotalPrice" runat="server" Text='<%# Bind("TotalPrice") %>'></asp:Label>
                                            </td>
                                             <td>
                                                <asp:Label ID="lblContractDuration" runat="server" Text='<%# Bind("ContractDuration") %>'></asp:Label>
                                            </td>
                                             <td>
                                                <asp:Label ID="lblMonthlyInstallmentAmt" runat="server" Text='<%# Bind("MonthlyInstallmentAmt") %>'></asp:Label>
                                            </td>
                                          
                                             <td>
                                                <asp:Label ID="lblPostLastDisplayDate" runat="server" Text='<%# Bind("PostLastDisplayDate") %>'></asp:Label>
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
                                <asp:DataPager ID="dataPagerMobilePhoneInfoDisplay" runat="server" PagedControlID="lvMobilePhoneInfoDisplay"
                                    PageSize="10" OnPreRender="dataPagerMobilePhoneInfoDisplay_PreRender">
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
    </section>
</asp:Content>

