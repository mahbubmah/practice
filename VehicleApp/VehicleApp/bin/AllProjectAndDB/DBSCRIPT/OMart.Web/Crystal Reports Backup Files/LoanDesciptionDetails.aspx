<%@ Page Title="" Language="C#" MasterPageFile="~/LoanMasterPage.Master" AutoEventWireup="true" CodeBehind="LoanDesciptionDetails.aspx.cs" Inherits="OMart.Web.LoanDesciptionDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container commBoxTitelLoan loanPageInner">

        <section>



            <div class="row col-sm-12">
                <div class="col-sm-3">
                    Loan Type
                    <asp:DropDownList ID="ddlLoanType" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlLoanType_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>

                </div>
                <div class="col-sm-3">
                    Total Amount
                    <asp:TextBox ID="txtTotalAmount" runat="server" CssClass="form-control" Text="" placeholder="Enter total amount..."></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorTotalAmt" runat="server" ErrorMessage="Numeric Only" ForeColor="Red" ControlToValidate="txtTotalAmount" ValidationExpression="(^[1-9]\d*$)"></asp:RegularExpressionValidator>
                </div>
                <div class="col-sm-3">
                    Duration In Year
                    <asp:TextBox ID="txtDuration" runat="server" CssClass="form-control" Text="" placeholder="Enter duration in year..."></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorDuration" runat="server" ErrorMessage="Numeric Only" ForeColor="Red" ControlToValidate="txtDuration" ValidationExpression="(^[1-9]\d*$)"></asp:RegularExpressionValidator>
                </div>

                <div class="col-sm-2">
                    Update 
                    <asp:Button ID="btnSearchLoanData" Text="Search" runat="server" CssClass="form-control" OnClick="btnSearchLoanData_Click" />
                </div>

            </div>


            <asp:ObjectDataSource ID="objDataSourceLoanDetail" runat="server"
      
              
                EnablePaging="true"
                OnSelecting="objDataSourceLoanDetail_Selecting"
                TypeName="BLL.Basic.LoanInformationRT"
                SelectMethod="GetAllLoanDescriptionTest"
                SelectCountMethod="CountAllLoanDescription"
                MaximumRowsParameterName="maxRowNumber"
                StartRowIndexParameterName="startRowIndex"></asp:ObjectDataSource>
            <div class="container descriptionPage">
                <div class="row">
                    <div class="col-md-12">
                        <!--------------------------------------------------Region Start ListView---------------------------------------------------------->
                        <asp:ListView ID="lvLoanDescriptionDetail" runat="server" DataSourceID="objDataSourceLoanDetail" OnItemDataBound="repDescription_ItemDataBound"
                            OnPagePropertiesChanging="lvLoanDescriptionDetail_PagePropertiesChanging" AllowPaging="True" AutoGenerateColumns="False">

                            <LayoutTemplate>
                                <table class="table tbLoan" id="task-table">
                                    <thead>
                                        <tr runat="server">
                                            <th class="col-xs-1"></th>
                                            <th class="col-xs-3"></th>

                                            <th class="col-xs-1">APR</th>
                                            <th class="col-xs-1">Total repayable</th>
                                            <th class="col-xs-1">Monthly repayments</th>
                                            <th class="col-xs-1"></th>
                                        </tr>
                                    </thead>
                                    <tbody id="itemPlaceholder" runat="server">
                                    </tbody>
                                </table>
                            </LayoutTemplate>

                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <div class="productDescImg">
                                            <asp:HiddenField ID="hdLoanInfoID" runat="server" Value='<%# Eval("IID") %>' />
                                            <a class="moreInformation" href="<%#Eval("WebAddress")%>" target="_blank">
                                                <asp:Image ID="lblCompanyLogo" runat="server" ImageUrl='<%# Bind("LogoUrl")%>' AlternateText="img" Width="168px" Height="78px" />
                                            </a>
                                        </div>
                                    </td>
                                    <td>
                                        <div class="productDescription">
                                            <h4><span><%#Eval("Name")%> <%#Eval("LoanName")%> Loan</span></h4>

                                            <asp:Repeater ID="repDescription" runat="server">
                                                <ItemTemplate>
                                                    <ul>
                                                        <li><%#Eval("Description")%></li>
                                                    </ul>
                                                </ItemTemplate>

                                            </asp:Repeater>

                                            <p><a class="moreInformation" href="<%#Eval("WebAddress")%>" target="_blank">More Info</a></p>
                                        </div>

                                    </td>
                                    <td>
                                        <div class="apr">
                                            <h4><span><%#(char)2547%><%#Eval("APR","{0:0.00}")%>% APR</span></h4>
                                            <p>Representative</p>
                                        </div>
                                    </td>
                                    <td>
                                        <div class="ttlPay">
                                            <h4><span><%#(char)2547%><%#Eval("TotalReturnAmount","{0:0.00}")%></span></h4>
                                        </div>
                                    </td>
                                    <td>
                                        <div class="repayble">
                                            <h4>
                                                <span><%#(char)2547%><%#Eval("MonthlyReturnAmount","{0:0.00}")%></span>
                                            </h4>
                                            <p>
                                                repayable per month
                                            </p>
                                        </div>
                                    </td>
                                    <td>
                                        <div class="applyBox">
                                            <a href="<%#Eval("WebAddress")%>" target="_blank" class="btn btn-danger">Apply <span class="glyphicon glyphicon-chevron-right oioCherRight2"></span></a>
                                            <%--                               <a href="#" class="text-danger">will I get this loan?</a>--%>
                                        </div>
                                    </td>
                                </tr>

                                <tr>
                                    <td colspan="6">
                                        <div class="trfoter">
                                            <p>
                                                <a href="<%#Eval("WebAddress")%>" target="_blank"><span><%#Eval("Description")%></span> </a>
                                            </p>
                                        </div>

                                    </td>
                                </tr>
                            </ItemTemplate>

                            <EmptyDataTemplate>
                                <table>
                                    <tr>
                                        <td>Information is empty ... 
                                        </td>
                                    </tr>
                                </table>
                            </EmptyDataTemplate>
                        </asp:ListView>

                        <asp:DataPager ID="dataPagerLoanDescriptionDetail" runat="server" PagedControlID="lvLoanDescriptionDetail"
                            PageSize="10">
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

            </div>
        </section>

    </div>
</asp:Content>
