<%@ Page Title="" Language="C#" MasterPageFile="~/OiiOInnerMasterPage.Master" AutoEventWireup="true" CodeBehind="BookCompetitions.aspx.cs" Inherits="OB.Web.BookCompetitions" %>
<%@ Import Namespace="OB.Utilities" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderInnerPage" runat="server">
     <div class="ContentArea commonH3titel compotationPage">
        <div class="row col-xs-12">
            <h3>Competitions</h3>
            <div class="well">
                Check back here regularly for all the latest competitions and giveaways from across the Random House Group.
            </div>
              <br/>
            <p style="float: left">
                <asp:Label runat="server" ID="lblResultPageCounter"></asp:Label>
            </p>
            <a href="LoginPage" class="btn btn-danger" style="float: right">Contestant Login</a> 
          
           <%-- <p>Showing <asp:Label ID="lblStartIndex" runat="server"></asp:Label> - <asp:Label ID="lblEndIndex" runat="server"></asp:Label> of <asp:Label ID="lblTotal" runat="server"></asp:Label> results</p>--%>

            <asp:ObjectDataSource ID="odsCompetitionDetails" runat="server"
                TypeName="OB.BLL.Basic.CompetitionInfoRT"
                SelectCountMethod="SelectCompetitionCount"
                EnablePaging="True"
                MaximumRowsParameterName="noOfMaximumRows"
                StartRowIndexParameterName="noOfStartRowIndex"
                SelectMethod="SelectAllList"
               ></asp:ObjectDataSource>
            <br/>
            <asp:ListView AllowPaging="True"
                AllowSorting="True"
                EnableSortingAndPagingCallbacks="True"
                AutoGenerateColumns="False"
                DataSourceID="odsCompetitionDetails"
                EmptyDataText="No rows to display."
                runat="server"
                ID="lvCompetitionDetails"
                OnPagePropertiesChanging="lvCompetitionDetails_PagePropertiesChanging"
              >

                <ItemTemplate>
                    <div class="contArea ">


                        <hr class="hrLine" />
                        <div class=" img-thumbnail">
                            <asp:Image ID="img_competition" runat="server" CssClass="img-responsive" ImageUrl='<%# Eval("ImageUrl") %>' alt="img" />
                        </div>


                        <h3>The Life-Changing Magic of Tidying & Lakeland</h3>
                        <h4>Get ready for <%# Enum.Parse(typeof(EnumCollection.CompititionSessionType), Eval("SeasonID").ToString()) %>!</h4>
                        <p>
                            <%# Eval("Description") %>
                        </p>
                        <p></p>
                        <%--<p><a href='<%#"CompetitionRegistrationPage.aspx?ID="+Eval("IID") %>' class="btn btn-success pull-left">Enter the Competitions</a> <span class="pull-right">Competition ends 27th April</span></p>--%>
                        <p><a href='<%# "CompetitionRegistrationPage.aspx?comID="+ OB.Utilities.StringCipher.Encrypt(Eval("IID").ToString()) %>' class="btn btn-success pull-left">Enter the Competitions</a> <span class="pull-right">Competition ends 27th April</span></p>
                        <div class=" clearfix"></div>
                        <hr class="hrLine" />
                    </div>
                </ItemTemplate>
            </asp:ListView>
            <asp:DataPager ID="dataPagerCompetitionInfo" runat="server" PagedControlID="lvCompetitionDetails"
                PageSize="2">
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
            <%--<div class="contArea ">

                <div class=" img-thumbnail">
                    <img class="img-responsive" src="Images/Interfaces/71.jpg" alt="img" />
                </div>


                <h3>Prof Steve Peters - Chimp Paradox</h3>
                <h4>Prof Steve Peters & The School of Life</h4>
                <p>
                    Get ready for Spring with Marie Kondo's Life-Changing Magic of Tidying and Lakeland.Transform your home into a permanently clear 
and clutter-free space with the incredible KonMari Method. Japan's expert declutterer and professional cleaner Marie Kond...
                </p>
                <p>Get ready for Spring by winning a copy of Marie Kondo's Life-Changing Magic of Tidying and a tidying...</p>
                <p><a href="CompetitionRegistrationPage.aspx" class="btn btn-success pull-left">Enter the Competitions</a> <span class="pull-right">Competition ends 27th April</span></p>
                <div class=" clearfix"></div>
            </div>--%>
        </div>

    </div>
</asp:Content>
