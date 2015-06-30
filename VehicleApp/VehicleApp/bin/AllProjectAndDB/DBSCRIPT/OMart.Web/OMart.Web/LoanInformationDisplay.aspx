<%@ Page Title="" Language="C#" MasterPageFile="~/LoanMasterPage.Master" AutoEventWireup="true" CodeBehind="LoanInformationDisplay.aspx.cs" Inherits="OMart.Web.LoanInformationDisplay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="container commBoxTitelLoan loanPageInner">
        <%--    <div class="row">--%>
        <div class="col-md-12">
            <h2>Which type of loan are you looking for?</h2>
        </div>
        <asp:Repeater ID="repLoanType" runat="server">
            <ItemTemplate>
                <div class="col-sm-4 col-md-4 col-lg-4">
                    <div class="loanBox">
                        <div class="label">
                            <asp:Label ID="lblLoanAmtYearScheduleID" runat="server" Text='<%# Bind("IID") %>' Visible="false"></asp:Label>
                        </div>
                        <div>
                            <h3>
                                <a href='<%#"LoanDesciptionDetails?ID="+Utilities.StringCipher.Encrypt(Eval("IID").ToString()) %>'>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Enum.Parse(typeof( Utilities.EnumCollection.LoanType),Eval("IID").ToString()) %>'></asp:Label><span class="right oioCherRight2"></span>
                                </a>
                                <%--                                <asp:Label ID="lblLoanType" runat="server" Text='<%# Enum.Parse(typeof( Utilities.EnumCollection.LoanType),Eval("IID").ToString()) %>'></asp:Label>--%>
                            </h3>
                        </div>
                        <div>
                            <p>
                                <asp:Label ID="lblDescription" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                            </p>
                        </div>
                        <div class="img-thumbnail imgBox">
                            <a href='<%#"LoanDesciptionDetails?ID="+Utilities.StringCipher.Encrypt(Eval("IID").ToString()) %>'>
                                <asp:Image ID="lblLoanTypeImage" runat="server" ImageUrl='<%# Bind("LoanTypeImageUrl")%>' AlternateText="img" Width="200" Height="200" />
                            </a>
                        </div>


                        <div class="loanBoxFoot">
                            <a href='<%#"LoanDesciptionDetails?ID="+Utilities.StringCipher.Encrypt(Eval("IID").ToString()) %>'>See all <span class="glyphicon glyphicon-chevron-right oioCherRight2"></span>
                            </a>
                        </div>
                    </div>
                </div>

            </ItemTemplate>

        </asp:Repeater>


        <div class="row">
            <div class="col-sm-12">
                <h2>Our loans providers</h2>

            </div>
            <asp:Repeater ID="repLoanProvider" runat="server" EnableViewState="false">
                <ItemTemplate>
                    <div class="col-sm-1 col-md-1 col-lg-2">
                        <div class="sponserLogo img-thumbnail">
                            <a href='<%# Eval("WebAddress")%>' runat="server" target="_blank">
                                <asp:Image ID="lblCompanyLogo" CssClass="img-responsive" runat="server" ImageUrl='<%# Bind("LogoUrl")%>' AlternateText="img" Width="100" Height="100" />
                            </a>
                        </div>
                    </div>
                </ItemTemplate>

            </asp:Repeater>

        </div>


        <div class="row loanServWrp">
            <div role="tabpanel">
                <div class="col-sm-12">
                    <!-- Nav tabs -->
                    <ul class="nav nav-tabs" role="tablist">
                        <li role="presentation" class="active"><a href="#Loanguides" aria-controls="Loanguides
"
                            role="tab" data-toggle="tab">Banking Guides
                        </a></li>
                        <li role="presentation"><a href="#Debthelp" aria-controls="Debthelp" role="tab" data-toggle="tab">Banking News</a></li>

                    </ul>
                </div>
                <!-- Tab panes -->
                <div class="tab-content">
                    <div role="tabpanel" class="tab-pane active" id="Loanguides">


                        <asp:Repeater ID="repBankingLoanGuide" runat="server">
                            <ItemTemplate>
                                <div class="col-sm-3 col-md-3 col-lg-3">
                                    <div class="loanServBox">
                                        <%--<img class="img-responsive" src="Images/products/81.jpg" alt="img" />--%>
                                        <a href='<%#"GuideLineDetails?ID="+Utilities.StringCipher.Encrypt(Eval("IID").ToString()) %>'>
                                            <asp:Image ID="imgImageUrl" CssClass="img-responsive" runat="server" ImageUrl='<%# Bind("ImageUrl")%>' AlternateText="img" Width="250" Height="180" />
                                        </a>
                                        <div class="loanservBoxCnt">
                                            <h5>
                                                <a href='<%#"GuideLineDetails?ID="+Utilities.StringCipher.Encrypt(Eval("IID").ToString()) %>' class="readstory">
                                                    <asp:Label ID="titleOfBankingBusinessType" runat="server" Text='<%#Bind("Title")%>'></asp:Label>
                                                </a></h5>
                                            <a href='<%#"GuideLineDetails?ID="+ Utilities.StringCipher.Encrypt(Eval("IID").ToString()) %>' class="readstory">Read more <span class="glyphicon glyphicon-chevron-right oioCherRight2 oioCherRight3"></span></a>
                                        </div>

                                    </div>

                                </div>
                            </ItemTemplate>

                        </asp:Repeater>


                        <%--                  <div class="col-sm-3 col-md-3 col-lg-3">
                            <div class="loanServBox">
                                <img class="img-responsive" src="Images/products/82.jpg" alt="img" />
                                <div class="loanservBoxCnt">
                                    <h3>Peer-to-peer lending UK  &nbsp;&nbsp;&nbsp;&nbsp;</h3>
                                    <a href="#" class="readstory">Read more <span class="glyphicon glyphicon-chevron-right oioCherRight2 oioCherRight3"></span></a>
                                </div>

                            </div>

                        </div>--%>
                        <%--                <div class="col-sm-3 col-md-3 col-lg-3">
                            <div class="loanServBox">
                                <img class="img-responsive" src="Images/products/83.jpg" alt="img" />
                                <div class="loanservBoxCnt">
                                    <h3>Early repayment charge &nbsp;&nbsp;&nbsp;&nbsp;</h3>
                                    <a href="#" class="readstory">Read more <span class="glyphicon glyphicon-chevron-right oioCherRight2 oioCherRight3"></span></a>
                                </div>

                            </div>

                        </div>--%>
                        <%--                     <div class="col-sm-3 col-md-3 col-lg-3">
                            <div class="loanServBox">

                                <div class="loanservBoxCnt">
                                    <h3>
                                        <a href="#">See more loans guides</a></h3>
                                </div>

                            </div>

                        </div>--%>
                    </div>
                    <div role="tabpanel" class="tab-pane" id="Debthelp">

                        <asp:Repeater ID="repBankingNews" runat="server">
                            <ItemTemplate>
                                <div class="col-sm-3 col-md-3 col-lg-3">
                                    <div class="loanServBox">
                                        <a href='<%#"AllNewsDetails?ID="+Utilities.StringCipher.Encrypt(Eval("IID").ToString()) %>' runat="server">
                                            <asp:Image ID="imgImageUrl" CssClass="img-responsive" runat="server" ImageUrl='<%# Bind("ImageUrl")%>' AlternateText="img" Width="250" Height="180" />
                                        </a>
                                        <div class="loanservBoxCnt">
                                            <h5><a href='<%#"AllNewsDetails?ID="+Utilities.StringCipher.Encrypt(Eval("IID").ToString()) %>' class="readstory">
                                                <asp:Label ID="titleOfBankingBusinessType" runat="server" Text='<%#Bind("TitleName")%>'></asp:Label>
                                            </a>

                                            </h5>
                                            <a href='<%#"AllNewsDetails?ID="+Utilities.StringCipher.Encrypt(Eval("IID").ToString()) %>' class="readstory">Read more <span class="glyphicon glyphicon-chevron-right oioCherRight2 oioCherRight3"></span></a>
                                        </div>

                                    </div>

                                </div>
                            </ItemTemplate>

                        </asp:Repeater>


                        <%--                    <div class="col-sm-3 col-md-3 col-lg-3">
                            <div class="loanServBox">
                                <img class="img-responsive" src="Images/products/83.jpg" alt="img" />
                                <div class="loanservBoxCnt">
                                    <h3>Early repayment charge &nbsp;&nbsp;&nbsp;&nbsp;</h3>
                                    <a href="#" class="readstory">Read more <span class="glyphicon glyphicon-chevron-right oioCherRight2 oioCherRight3"></span></a>
                                </div>

                            </div>

                        </div>--%>
                        <%--                       <div class="col-sm-3 col-md-3 col-lg-3">
                            <div class="loanServBox">
                                <img class="img-responsive" src="Images/products/81.jpg" alt="img" />
                                <div class="loanservBoxCnt">
                                    <h3>Home improvement loans</h3>
                                    <a href="#" class="readstory">Read more <span class="glyphicon glyphicon-chevron-right oioCherRight2 oioCherRight3"></span></a>
                                </div>

                            </div>

                        </div>--%>

                        <%--                  <div class="col-sm-3 col-md-3 col-lg-3">
                            <div class="loanServBox">
                                <img class="img-responsive" src="Images/products/82.jpg" alt="img" />
                                <div class="loanservBoxCnt">
                                    <h3>Peer-to-peer lending UK  &nbsp;&nbsp;&nbsp;&nbsp;</h3>
                                    <a href="#" class="readstory">Read more <span class="glyphicon glyphicon-chevron-right oioCherRight2 oioCherRight3"></span></a>
                                </div>

                            </div>

                        </div>--%>
                        <%--              <div class="col-sm-3 col-md-3 col-lg-3">
                            <div class="loanServBox">

                                <div class="loanservBoxCnt">
                                    <h3>
                                        <a href="#">See more loans guides</a></h3>
                                </div>

                            </div>

                        </div>--%>
                    </div>

                </div>

            </div>


        </div>


        <div class="row">
            <div class="oiioMat_bottom commBoxTitel">
                <div class="col-sm-5 col-md-5 col-lg-5">
                    <div class="oiioMatBox1">
                        <h3><span>Oiio Mart is here to help</span></h3>
                        <p>
                            Our BD-based call centre
                            <br />
                            staff are trained to help you
                            <br />
                            with expert advice.
                        </p>
                        <p>
                            <a href="#" class="pull-right btn btn-default ">BD Number here</a>
                        </p>
                    </div>

                </div>
                <div class="col-sm-2 col-md-2 col-lg-2">
                    <div class="">
                        <img src="Images/products/9.jpg" alt="img" />
                    </div>

                </div>
                <div class="col-sm-5 col-md-5 col-lg-5">
                    <div class="oiioMatBox1">
                        <h3><span>OiiO Mart money saving advice</span></h3>
                        <p>
                            Sign up for free news maney
                            <br />
                            saving offers for mobiles, energy,
                            <br />
                            broadband, credit cards 
and more
                        </p>
                        <p>
                            <a href="#" class="pull-right btn btn-default ">BD Number here</a>
                        </p>
                    </div>

                </div>
            </div>

        </div>

    </div>

</asp:Content>
