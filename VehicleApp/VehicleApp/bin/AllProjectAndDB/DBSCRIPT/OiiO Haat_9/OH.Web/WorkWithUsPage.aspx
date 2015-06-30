<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultMaster.Master" AutoEventWireup="true" CodeBehind="WorkWithUsPage.aspx.cs" Inherits="OH.Web.WorkWithUsPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container adminPagewrp">
        <h2 style="text-align: center;">Work With Us
            </h2>
        <div>
            <div class="col-lg-1"></div>
            <div class="">
                <fieldset style="width:95%;margin-left:1%;visibility:hidden">
                    <%-- <legend></legend>--%>
                      <div class="row" style="visibility:visible">
                            <div class="form-group col-xs-12">
                                <div class="input-group">
                                    <p style="display:inline">
                                        At <h5 style="color:red;display:inline">OiiO</h5>, we move fast. We are driven professionals who are not afraid to think on our feet and pursue excellence. We are team players, a versatile and agile company and we know that working together is much more effective than working alone.<h5 style="color:red;display:inline"> OiiO</h5> is a place for people who understand people, be it customers or colleagues. We need people who understand our vision and inspire confidence in our teams.
                                    </p>
                                    <p style="text-align:justify">
                                        It would be good if you have quantitative and analytical skills, since they do help with problem solving. But it’s most important that you have the right attitude, are optimistic, enjoy a good challenge, work hard and learn quickly. You will be challenged here, you will experiment to find solutions and you will push yourself for results. That’s ok. You won’t be doing it alone. We have a young team that’s growing and learning and we encourage collaboration as well as sharing wins and successes.
                                    </p>
                                    <p>
                                        Because the only way we know is up.
                                    </p>
                                    <p style="text-align:justify">
                                        If you think you’d be a good fit for our corporate culture, please write to us at <a href="#">careers@oiiohaat.com</a> 
                                    </p>
                                    <p>
                                        Thanks for now,
                                        </p>
                                    <p style="color:red;font-weight:bold">
                                          OiiO Haat, Bangladesh
                                    </p>
                                </div>
                            </div>
                        </div>
                </fieldset>
            </div>
        </div>
    </div>
</asp:Content>
