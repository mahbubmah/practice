<%@ Page Title="Energy Payment" Language="C#" MasterPageFile="~/OiiOMasterPage.master" AutoEventWireup="true" CodeBehind="EnergyPayment.aspx.cs" Inherits="EnergyPayment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section>
        <div class="container-fluid bannerWrp mortagesPage">
            <nav role="navigation" class="navbar navbar-inverse oiioMainMenu">
                <div class="container">
                    <!-- Brand and toggle get grouped for better mobile display -->
                    <div class="navbar-header">
                        <button data-target="#bs-example-navbar-collapse-1" data-toggle="collapse" class="navbar-toggle" type="button">
                            <span class="sr-only">Toggle navigation</span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                        </button>
                    </div>
                    <!-- Collect the nav links, forms, and other content for toggling -->
                    <div id="bs-example-navbar-collapse-1" class="collapse navbar-collapse">
                        <ul class="nav navbar-nav">
                            <li>
                                <a href="Index.aspx">Home</a>
                            </li>

                            <li class="dropdown oiioBrand">
                                <a class="dropdown-toggle" data-toggle="dropdown" href="Shopping.aspx">Energy</a>
                                <ul class="dropdown-menu">
                                    <li><a href="#">Compare gas and electricity</a></li>
                                    <li><a href="#">Compare electricitys</a></li>
                                    <li><a href="#">Compare gas</a></li>
                                    <li><a href="#">Solar power</a></li>
                                    <li><a href="#">Business energy</a></li>
                                    <li><a href="#">Energy price changes</a></li>
                                    <li><a href="#">Prepayment meters</a></li>
                                </ul>
                            </li>
                            <li class=" active dropdown oiioBrand">
                                <a class="dropdown-toggle" data-toggle="dropdown" href="Money.aspx">Money</a>
                                <ul class="dropdown-menu">
                                    <li><a href="CurrentAccount.aspx">Current accounts</a></li>
                                    <li><a href="#">Cradit cards</a></li>
                                    <li><a href="Money.aspx">Loans</a></li>
                                    <li><a href="Mortgages.aspx">Mortgages</a></li>
                                    <li><a href="BankingNews.aspx">Banking news</a></li>
                                </ul>
                            </li>
                            <li class="dropdown oiioBrand">
                                <a class="dropdown-toggle" data-toggle="dropdown" href="Travel.aspx">Travel</a>
                                <ul class="dropdown-menu">

                                    <li><a href="#">Holidays</a></li>
                                    <li><a href="#">Flights</a></li>
                                    <li><a href="#">Hotels</a></li>
                                    <li><a href="#">Travel Insurance</a></li>
                                    <li><a href="#">Travel Extras</a></li>

                                </ul>
                            </li>

                            <li class="dropdown oiioBrand">
                                <a class="dropdown-toggle" data-toggle="dropdown" href="InsuranceNews.aspx">Insurance</a>
                                <ul class="dropdown-menu">

                                    <li><a href="#">Car insurance</a></li>
                                    <li><a href="#">Motorbike insurance</a></li>
                                    <li><a href="#">Travel insurance</a></li>
                                    <li><a href="#">Life insurance</a></li>
                                    <li><a href="#">Home insurance</a></li>
                                    <li><a href="#">Business insurance</a></li>
                                </ul>
                            </li>

                            <li class="dropdown oiioBrand">
                                <a class=" dropdown-toggle" data-toggle="dropdown" href="Shopping.aspx">Shopping</a>
                                <ul class="dropdown-menu">
                                    <li><a href="#">Health & beauty</a></li>
                                    <li><a href="#">Office supplies</a></li>
                                    <li><a href="#">Cameras</a></li>
                                    <li><a href="#">Televisions</a></li>
                                    <li><a href="#">Computers</a></li>
                                    <li><a href="#">Fashion</a></li>
                                    <li><a href="#">Furniture</a></li>

                                </ul>
                            </li>
                            <li class="dropdown oiioBrand">
                                <a class="dropdown-toggle" data-toggle="dropdown" href="MobilePhones.aspx">Mobile Phones </a>
                                <ul class="dropdown-menu">
                                    <li><a href="#">Mobile phone deals</a></li>
                                    <li><a href="#">SIM only deals</a></li>
                                    <li><a href="#">iPhone deals</a></li>
                                    <li><a href="#">iPad deals</a></li>
                                    <li><a href="#">Pay as you go phones</a></li>
                                    <li><a href="#">Mobile news</a></li>

                                </ul>
                            </li>
                            <li class="dropdown oiioBrand">
                                <a class="dropdown-toggle" data-toggle="dropdown" href="Broadband.aspx">Broadband</a>
                                <ul class="dropdown-menu">
                                    <li><a href="#">Broadband deals</a></li>
                                    <li><a href="#">Mobile broadband</a></li>
                                    <li><a href="#">Broadband packages</a></li>
                                    <li><a href="#">Broadband and tv</a></li>
                                    <li><a href="#">Broadband and phone</a></li>
                                    <li><a href="#">Broadband, tv and phone</a></li>

                                </ul>
                            </li>

                            <li class="dropdown oiioBrand">
                                <a class="dropdown-toggle" data-toggle="dropdown" href="Vouchers.aspx">Vouchers</a>
                                <ul class="dropdown-menu">
                                    <li><a href="#">content comming soon</a></li>

                                </ul>
                            </li>





                            <li>
                                <a href="News.aspx">News & Community</a>
                            </li>

                        </ul>
                    </div>
                    <!-- /.navbar-collapse -->
                </div>
                <!-- /.container -->
            </nav>






            <div class="carousel fade-carousel slide oiioFadeBanner payasyouBanner" data-ride="carousel" data-interval="4000" id="bs-carousel">
                <!-- Overlay -->


                <!-- Indicators -->
                <%-- <ol class="carousel-indicators">
    <li data-target="#bs-carousel" data-slide-to="0" class="active"></li>
    <li data-target="#bs-carousel" data-slide-to="1"></li>
    <li data-target="#bs-carousel" data-slide-to="2"></li>
  </ol>--%>

                <!-- Wrapper for slides -->
                <div class="carousel-inner">
                    <div class="item slides active">
                        <div class="slide20">
                        </div>
                        <div class="insBannerCntWrp">
                            <div class="insBannerCntWrp">
                            <div class="insBannerCnt">


                                <div class="row">

                                    <div class="col-sm-4">
                                        <div class="bannerMortagesCnt">
                                            <h3>Take back control of your energy bills</h3>
                                            <p>We compare prices from every energy supplier in 
Bangladesh to help lower your fuel bills</p>
                                           <p><a href="#" class="btn btn-primary compareBtn ">Compare deals <span class="glyphicon glyphicon-chevron-right oioCherRight2"></span></a></p>
                                        </div>
                                    </div>
                                    <div class="col-sm-6">
                                    </div>
                                </div>

                                <div class="hero2">

                                    <img class="img-responsive" src="Images/banner/0423_1.png" alt="img" />
                                </div>

                            </div>
                        </div>
                        </div>
                    </div>
                    <div class="item slides">
                        <div class="slide21"></div>
                        <div class="insBannerCntWrp">
                            <div class="insBannerCnt">


                                <div class="row">

                                    <div class="col-sm-4">
                                        <div class="bannerMortagesCnt">
                                            <h3>Take back control of your energy bills</h3>
                                            <p>We compare prices from every energy supplier in 
Bangladesh to help lower your fuel bills</p>
                                           <a href="#" class="btn btn-primary compareBtn ">Compare deals <span class="glyphicon glyphicon-chevron-right oioCherRight2"></span></a>
                                        </div>
                                    </div>
                                    <div class="col-sm-6">
                                    </div>
                                </div>

                                <div class="hero2">

                                    <img class="img-responsive" src="Images/banner/0423_1.png" alt="img" />
                                </div>

                            </div>
                        </div>
                    </div>

                </div>
            </div>

        </div>
    </section>
    <section>


        <div class="container payasuDesc">
            <div class="row topLeadIns">
                    <div class="col-xs-2 col-sm-2">
                        <h4>We impartially 
compare all of these 
suppliers and more...</h4>
                    </div>
                    <div class="col-xs-10 col-sm-10">

                        <img class="img-thumbnail img-responsive" src="Images/Interfaces/0423_2.png" alt="img" />
                         <img class="img-thumbnail img-responsive" src="Images/Interfaces/0423_3.png" alt="img" />
                         <img  class="img-thumbnail img-responsive" src="Images/Interfaces/0424_4.png" alt="img" />
                          <img class="img-thumbnail img-responsive" src="Images/Interfaces/0424_5.png" alt="img" />

                         <img  class="img-thumbnail img-responsive" src="Images/Interfaces/0424_6.png" alt="img" />

                       

                         <img class="img-thumbnail img-responsive" src="Images/Interfaces/0424_7.png" alt="img" />

                         <img class="img-thumbnail img-responsive" src="Images/Interfaces/0424_8.png" alt="img" />

                         <img class="img-thumbnail img-responsive" src="Images/Interfaces/0424_9.png" alt="img" />

                        
                    </div>
            </div>


            <div class="row">
                <div class="col-sm-4 col-md-4 col-lg-4">
                    <div class="leftSidebar">
                        <div class="updateForm">
                            <div class="row">
                                <div class="row_A">
                                <div class="col-xs-5">
                                    <label>Company name</label>
                                </div>
                                <div class="col-xs-7">
                                    <select class="form-control" name="s">
                                        <option>Oiio Ins</option>
                                        <option>Oiio Ins</option>
                                        <option>Oiio Ins</option>
                                        <option>Oiio Ins</option>
                                        <option>Oiio Ins</option>

                                    </select>
                                </div>
                                    <div class="clearfix"></div>
                                    </div>
                            </div>
                           <div class="row">
                                <div class="row_A">
                                <div class="col-xs-5">
                                    <label>Distributor name</label>
                                </div>
                                <div class="col-xs-7">
                                    <select class="form-control" name="s">
                                        <option>Oiio Ins</option>
                                        <option>Oiio Ins</option>
                                        <option>Oiio Ins</option>
                                        <option>Oiio Ins</option>
                                        <option>Oiio Ins</option>

                                    </select>
                                </div>
                                    <div class="clearfix"></div>
                                    </div>
                            </div>
                            <div class="row">
                                <div class="row_A">
                                <div class="col-xs-5">
                                    <label>District name</label>
                                </div>
                                <div class="col-xs-7">
                                    <select class="form-control" name="s">
                                        <option>Oiio Ins</option>
                                        <option>Oiio Ins</option>
                                        <option>Oiio Ins</option>
                                        <option>Oiio Ins</option>
                                        <option>Oiio Ins</option>

                                    </select>
                                </div>
                                    <div class="clearfix"></div>
                                    </div>
                            </div>
                            <div class="row">
                                <div class="row_A">
                                <div class="col-xs-5">
                                    <label>Police station name</label>
                                </div>
                                <div class="col-xs-7">
                                    <select class="form-control" name="s">
                                        <option>Oiio Ins</option>
                                        <option>Oiio Ins</option>
                                        <option>Oiio Ins</option>
                                        <option>Oiio Ins</option>
                                        <option>Oiio Ins</option>

                                    </select>
                                </div>
                                    <div class="clearfix"></div>
                                    </div>
                            </div>
                            <div class="row">
                                <div class="row_A">
                                <div class="col-xs-5">
                                    <label>Amount of gas</label>
                                </div>
                                <div class="col-xs-7">
                                    <input type="text" name="name" class="form-control" />
                                </div>
                                    <div class="clearfix"></div>
                                    </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-12">
                                    <input type="button" class="btn btn-primary btn-block updateBtn" value="Update" />
                                </div>
                            </div>

                        </div>

                        <div class="updateProduct">
                            <div class="updateProductRow">
                                <img src="Images/products/0424_10.jpg" alt="img" />
                                <h3>Find my supplier</h3>
                                <p>Find out who is currently supplying your gas and electricity</p>
                                <p><a href="#">Read more</a></p>
                            </div>
                            <div class="updateProductRow">
                                <img src="Images/products/0424_11.jpg" alt="img" />
                                <h3>Switch energy supplier</h3>
                                <p>Everything you need to know to switch to a cheaper gas and electricity tariff</p>
                                <p><a href="#">Read more</a></p>
                            </div>
                            <div class="updateProductRow">
                                <img src="Images/products/0424_12.jpg" alt="img" />
                                <h3>Prepayment meters</h3>
                                <p>Read our guide to prepayment meters and find out how to switch to a credit </p>
                                <p><a href="#">Read more</a></p>
                            </div>
                            <div class="updateProductRow">
                                <img src="Images/products/0424_13.jpg" alt="img" />
                                <h3>Gas and electricity bills</h3>
                                <p>Cut through the jargon on your gas and electricity bills with this useful guide</p>
                                <p><a href="#">Read more</a></p>
                            </div>
                        </div>

                    </div>

                    


                </div>
                <div class="col-sm-8 col-md-8 col-lg-8">
                    <div class="payasuDesc broadbandDeals">
                        <table class="table payasuDescTb table-hover" id="task-table">
                            <thead>
                                <tr>
                                    <th class="same_th">Company name</th>
                                    <th class="same_th">Amount of gas</th>
                                    <th class="same_th">Container weight</th>
                                    <th class="same_th">Price</th>
                                    <th class="same_th">Go to</th>

                                </tr>

                            </thead>
                            <tbody>
                                <tr>


                                    <td class="same_td same_td_1">

                                        <img src="Images/products/0423_14.jpg" alt="img" />

                                        <h4>Transmission &
                                            <br />
                                            distributions co.ltd</h4>

                                    </td>
                                    <td class="same_td same_td_2">
                                        <h4>12KG</h4>
                                    </td>
                                    <td class="same_td same_td_3">
                                        <h4>18KG</h4>

                                    </td>
                                    <td class="same_td same_td_4">
                                        <h4>TK3000</h4>

                                    </td>
                                    <td class="same_td same_td_5 applyBox">

                                        <img src="Images/products/0423_14.jpg" alt="img" />
                                        <a href="#" class="btn btn-infor">More info<span class="glyphicon glyphicon-chevron-down oioCherRight3"></span></a>

                                    </td>

                                </tr>
                                <tr>


                                    <td class="same_td same_td_1">

                                        <img src="Images/products/0423_12.png" alt="img" />

                                        <h4>LP GAS
                                            <br />
                                            Association</h4>

                                    </td>
                                    <td class="same_td same_td_2">
                                        <h4>12KG</h4>
                                    </td>
                                    <td class="same_td same_td_3">
                                        <h4>18KG</h4>

                                    </td>
                                    <td class="same_td same_td_4">
                                        <h4>TK3000</h4>

                                    </td>
                                    <td class="same_td same_td_5 applyBox">

                                        <img src="Images/products/0423_12.png" alt="img" />
                                        <a href="#" class="btn btn-infor">More info<span class="glyphicon glyphicon-chevron-down oioCherRight3"></span></a>

                                    </td>

                                </tr>
                                <tr>


                                    <td class="same_td same_td_1">

                                        <img src="Images/products/0423_13.png" alt="img" />

                                        <h4>Exelon
                                            <br />
                                            Bangladesh</h4>

                                    </td>
                                    <td class="same_td same_td_2">
                                        <h4>12KG</h4>
                                    </td>
                                    <td class="same_td same_td_3">
                                        <h4>18KG</h4>

                                    </td>
                                    <td class="same_td same_td_4">
                                        <h4>TK3000</h4>

                                    </td>
                                    <td class="same_td same_td_5 applyBox">

                                        <img src="Images/products/0423_13.png" alt="img" />
                                        <a href="#" class="btn btn-infor">More info<span class="glyphicon glyphicon-chevron-down oioCherRight3"></span></a>

                                    </td>

                                </tr>

                                <tr>


                                    <td class="same_td same_td_1">

                                        <img src="Images/products/0423_14.jpg" alt="img" />

                                        <h4>Transmission &
                                            <br />
                                            distributions co.ltd</h4>

                                    </td>
                                    <td class="same_td same_td_2">
                                        <h4>12KG</h4>
                                    </td>
                                    <td class="same_td same_td_3">
                                        <h4>18KG</h4>

                                    </td>
                                    <td class="same_td same_td_4">
                                        <h4>TK3000</h4>

                                    </td>
                                    <td class="same_td same_td_5 applyBox">

                                        <img src="Images/products/0423_14.jpg" alt="img" />
                                        <a href="#" class="btn btn-infor">More info<span class="glyphicon glyphicon-chevron-down oioCherRight3"></span></a>

                                    </td>

                                </tr>
                                <tr>


                                    <td class="same_td same_td_1">

                                        <img src="Images/products/0423_12.png" alt="img" />

                                        <h4>LP GAS
                                            <br />
                                            Association</h4>

                                    </td>
                                    <td class="same_td same_td_2">
                                        <h4>12KG</h4>
                                    </td>
                                    <td class="same_td same_td_3">
                                        <h4>18KG</h4>

                                    </td>
                                    <td class="same_td same_td_4">
                                        <h4>TK3000</h4>

                                    </td>
                                    <td class="same_td same_td_5 applyBox">

                                        <img src="Images/products/0423_12.png" alt="img" />
                                        <a href="#" class="btn btn-infor">More info<span class="glyphicon glyphicon-chevron-down oioCherRight3"></span></a>

                                    </td>

                                </tr>
                                <tr>


                                    <td class="same_td same_td_1">

                                        <img src="Images/products/0423_13.png" alt="img" />

                                        <h4>Exelon
                                            <br />
                                            Bangladesh</h4>

                                    </td>
                                    <td class="same_td same_td_2">
                                        <h4>12KG</h4>
                                    </td>
                                    <td class="same_td same_td_3">
                                        <h4>18KG</h4>

                                    </td>
                                    <td class="same_td same_td_4">
                                        <h4>TK3000</h4>

                                    </td>
                                    <td class="same_td same_td_5 applyBox">

                                        <img src="Images/products/0423_13.png" alt="img" />
                                        <a href="#" class="btn btn-infor">More info<span class="glyphicon glyphicon-chevron-down oioCherRight3"></span></a>

                                    </td>

                                </tr>


                            </tbody>
                        </table>
                    </div>

                    <div class="row">
                        <div class="col-md-12">
                            <a href="Insurance_Quotes.aspx" class="btn btn-primary seeResultsBtn">Show all deals</a>
                        </div>
                    </div>

                </div>
            </div>

            

        </div>
    </section>

</asp:Content>

