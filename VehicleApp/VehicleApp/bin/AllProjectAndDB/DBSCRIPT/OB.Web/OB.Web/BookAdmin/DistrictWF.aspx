<%@ Page Title="" Language="C#" MasterPageFile="~/BookAdmin/OiiOMasterPage.Master" AutoEventWireup="true" CodeBehind="DistrictWF.aspx.cs" Inherits="OB.Web.BookAdmin.DistrictWF" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


  <%--  <script type="text/javascript">
        $(function () {
            $.noConflict();

            function logCountryID(countryID) {
                $("#<%= txtCountryID.ClientID%>").val(countryID);
            }

            AutoCompleteBindCountry();

            var prmInstance = Sys.WebForms.PageRequestManager.getInstance();
            prmInstance.add_endRequest(function () {
                AutoCompleteBindCountry();
            });

            function AutoCompleteBindCountry() {
                //New For AutoComplete Selection
                var autoCompleteText = "";
                var currentText = "";
                var finalText = "";
                var givenText = "";
                var rowCount = 0;
                //End Section                      
                $("#<%=txtCountryName.ClientID %>").autocomplete({
                    source: function (request, response) {
                        var data_item = "{conName:'" + request.term + "'}";
                        $.ajax({
                            type: "POST",
                            url: "../HRWebService.asmx/GetCountryForSearch",
                            dataType: "json",
                            data: data_item,
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {
                                response($.map(data.d, function (item) {
                                    return {
                                        label: item.Name,
                                        IID: item.IID
                                    };
                                }));
                                //AutoComplete Selection
                                var dataList = data.d;
                                rowCount = 0;
                                givenText = $("#<%=txtCountryName.ClientID %>").val();
                                $.each(dataList, function (index, item) {
                                    currentText = item.Name;
                                    if (autoCompleteText == "") {
                                        autoCompleteText = currentText;
                                    }
                                    else {
                                        finalText = givenText.toUpperCase();
                                        if (autoCompleteText.length > givenText.length) {
                                            for (var i = givenText.length; i < autoCompleteText.length; i++) {
                                                if (autoCompleteText.charAt(i).toUpperCase() == item.Name.charAt(i).toUpperCase()) {
                                                    finalText += autoCompleteText.charAt(i).toUpperCase();
                                                }
                                                else {
                                                    break;
                                                }
                                            }
                                        }
                                        autoCompleteText = finalText;
                                    }
                                    rowCount++;
                                });

                                if (rowCount == 0) {
                                    $("#<%=txtCountryName.ClientID %>").val(givenText.toUpperCase());
                                }
                                else {
                                    $("#<%=txtCountryName.ClientID %>").val(autoCompleteText.toUpperCase());
                                }

                                autoCompleteText = "";
                                //End Section                               
                            }
                        });
                    },
                    delay: 300,
                    minLength: 1,

                    focus: function (event, ui) {
                        $(this).val(ui.item.label);
                        return false;
                    },
                    select: function (event, ui) {
                        logCountryID(ui.item ? ui.item.IID : "");
                        $(this).val(ui.item.label);
                        $(this).select();

                        return false;
                    },

                    open: function () {
                        $(this).removeClass("ui-corner-all").addClass("ui-corner-top");
                    },
                    close: function () {
                        $(this).removeClass("ui-corner-top").addClass("ui-corner-all");
                    }


                });
            };
        });



        $(function () {


            function logDivisionOrStateID(divisionOrStateID) {
                $("#<%= txtDivisionOrStateID.ClientID%>").val(divisionOrStateID);
            }

            AutoCompleteBindDiviOrState();

            var prmInstance = Sys.WebForms.PageRequestManager.getInstance();
            prmInstance.add_endRequest(function () {
                AutoCompleteBindDiviOrState();
            });

            function AutoCompleteBindDiviOrState() {
                //New For AutoComplete Selection
                var autoCompleteText = "";
                var currentText = "";
                var finalText = "";
                var givenText = "";
                var rowCount = 0;
                //End Section      


                $("#<%=txtDivisionOrStateName.ClientID %>").autocomplete({
                    source: function (request, response) {
                        var countryID = $("#<%=txtCountryID.ClientID %>").val();
                        var data_item = "{diviOrStateName:'" + request.term + "', countryID:" + countryID + "}";
                        $.ajax({
                            type: "POST",
                            url: "../HRWebService.asmx/GetDivOrStateByCountryIdSearch",
                            dataType: "json",
                            data: data_item,
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {
                                response($.map(data.d, function (item) {
                                    return {
                                        label: item.Name,
                                        IID: item.IID
                                    };
                                }));
                                //AutoComplete Selection
                                var dataList = data.d;
                                rowCount = 0;
                                givenText = $("#<%=txtDivisionOrStateName.ClientID %>").val();
                                $.each(dataList, function (index, item) {
                                    currentText = item.Name;
                                    if (autoCompleteText == "") {
                                        autoCompleteText = currentText;
                                    }
                                    else {
                                        finalText = givenText.toUpperCase();
                                        if (autoCompleteText.length > givenText.length) {
                                            for (var i = givenText.length; i < autoCompleteText.length; i++) {
                                                if (autoCompleteText.charAt(i).toUpperCase() == item.Name.charAt(i).toUpperCase()) {
                                                    finalText += autoCompleteText.charAt(i).toUpperCase();
                                                }
                                                else {
                                                    break;
                                                }
                                            }
                                        }
                                        autoCompleteText = finalText;
                                    }
                                    rowCount++;
                                });

                                if (rowCount == 0) {
                                    $("#<%=txtDivisionOrStateName.ClientID %>").val(givenText.toUpperCase());
                                }
                                else {
                                    $("#<%=txtDivisionOrStateName.ClientID %>").val(autoCompleteText.toUpperCase());
                                }

                                autoCompleteText = "";
                                //End Section                               
                            }
                        });
                    },
                    delay: 300,
                    minLength: 1,

                    focus: function (event, ui) {
                        $(this).val(ui.item.label);
                        return false;
                    },
                    select: function (event, ui) {
                        logDivisionOrStateID(ui.item ? ui.item.IID : "");
                        $(this).val(ui.item.label);
                        $(this).select();

                        return false;
                    },

                    open: function () {
                        $(this).removeClass("ui-corner-all").addClass("ui-corner-top");
                    },
                    close: function () {
                        $(this).removeClass("ui-corner-top").addClass("ui-corner-all");
                    }


                });
            };
        });
    </script>--%>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mainpageBody">
        <div class="container">
            <div class="row">
                <h2>District Info
                </h2>
            </div>
            <div class="row">
                <asp:Label ID="labelMessage" runat="server" Text="..."></asp:Label>
            </div>
            <fieldset>
                 <div class="row">
                    <div class="form-group col-xs-4">
                        <div class="input-group">
                            <span class="input-group-addon"> Country
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" InitialValue="-1" runat="server" ControlToValidate="ddlCountryID" ForeColor="Red"
                                     Display="Dynamic" ValidationGroup="disValidationGroup">*</asp:RequiredFieldValidator></span>
                            <asp:DropDownList ID="ddlCountryID" runat="server" CssClass="dropdown" Width="100%" Height="32px" OnSelectedIndexChanged="ddlCountryID_SelectedIndexChanged" AutoPostBack="true">
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                 <div class="row">
                    <div class="form-group col-xs-4">
                        <div class="input-group">
                            <span class="input-group-addon">Division or state
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" InitialValue="-1" runat="server" ControlToValidate="ddlDivisionorState" ForeColor="Red"
                                     Display="Dynamic" ValidationGroup="disValidationGroup">*</asp:RequiredFieldValidator></span>
                            <asp:DropDownList ID="ddlDivisionorState" runat="server" CssClass="dropdown" Width="100%" Height="32px" >
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="form-group col-xs-4">
                        <div class="input-group">
                            <span class="input-group-addon">District Code
                            <asp:RequiredFieldValidator ID="rfvDistrictCode" runat="server"
                                ControlToValidate="txtCode" ForeColor="Red"
                                ToolTip="*" Display="Dynamic" ValidationGroup="disValidationGroup">*</asp:RequiredFieldValidator>
                            </span>
                            <asp:TextBox ID="txtCode" runat="server" Text=""  class="form-control" placeholder="Enter code..."></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="form-group col-xs-4">
                        <div class="input-group">
                            <span class="input-group-addon">District Name
                            <asp:RequiredFieldValidator ID="rfvDistrictName" runat="server"
                                ControlToValidate="txtName" ForeColor="Red"
                                ToolTip="*" Display="Dynamic" ValidationGroup="disValidationGroup">*</asp:RequiredFieldValidator>
                            </span>
                            <asp:TextBox ID="txtName" runat="server" Text="" ValidationGroup="disValidationGroup" class="form-control" placeholder="Enter name..."></asp:TextBox>
                        </div>
                    </div>
                </div>
               
               <%-- <div class="row">
                    <div class="form-group col-xs-4">
                        <div class="input-group">
                            <span class="input-group-addon">Applicable Country

                            <asp:RequiredFieldValidator ID="rfvCountryName" runat="server"
                                ControlToValidate="txtCountryName" ForeColor="Red"
                                ToolTip="*" Display="Dynamic">*</asp:RequiredFieldValidator>
                            </span>
                            <asp:TextBox ID="txtCountryName" runat="server" Text="" ValidationGroup="disValidationGroup" class="form-control" placeholder="Search Country..."></asp:TextBox>
                        </div>
                    </div>
                    <div style="visibility: hidden">
                        <asp:TextBox ID="txtCountryID" runat="server" Text=""></asp:TextBox>
                    </div>
                </div>--%>
           <%--     <div class="row">
                    <div class="form-group col-xs-4">
                        <div class="input-group">
                            <span class="input-group-addon">Division Or State

                            <asp:RequiredFieldValidator ID="rfvDivisionOrStateName" runat="server"
                                ControlToValidate="txtDivisionOrStateName" ForeColor="Red"
                                ToolTip="*" Display="Dynamic">*</asp:RequiredFieldValidator>
                            </span>
                            <asp:TextBox ID="txtDivisionOrStateName" runat="server" Text="" ValidationGroup="disValidationGroup" class="form-control" placeholder="Search Division Or State..."></asp:TextBox>
                        </div>
                    </div>
                    <div style="visibility: hidden">
                        <asp:TextBox ID="txtDivisionOrStateID" runat="server" Text=""></asp:TextBox>
                    </div>
                </div>--%>


                <div class="clearfix">
                </div>
                <div class="row">
                    <div class="col-xs-4">

                        <div class="input-group">
                            <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="disValidationGroup" OnClick="btnSave_Click" CssClass="btn btn-primary" />
                            <asp:Button ID="btnUpdate" runat="server" Text="Update" ValidationGroup="disValidationGroup" OnClick="btnUpdate_Click"
                                CssClass="btn btn-primary" />
                            <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" CssClass="btn btn-primary" />
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" CssClass="btn btn-primary" />
                            <asp:HiddenField runat="server" ID="hdDistrictID" />
                            <asp:HiddenField runat="server" ID="hdIsEdit" />
                            <asp:HiddenField runat="server" ID="hdIsDelete" />
                        </div>
                         <asp:ValidationSummary
                                                            ShowMessageBox="true"
                                                            ShowSummary="false"
                                                            HeaderText="You have to fill the Marked fields:"
                                                            EnableClientScript="true"
                                                            runat="server" ValidationGroup="disValidationGroup" />
                    </div>
                </div>

            </fieldset>

            <div class="clearfix">
            </div>
            <br />

            <div>
                <fieldset>
                    <legend>District Information</legend>
                    <asp:ListView ID="lvDistrict" runat="server" DataKeyNames="IID"
                        OnItemCommand="lvDistrict_ItemCommand"
                        OnPagePropertiesChanging="lvDistrict_PagePropertiesChanging"
                        OnPreRender="dataPagerDistrict_PreRender">
                        <LayoutTemplate>
                            <table class="table table-bordered table-hover" style="margin-bottom: 0px;">
                                <thead>
                                    <tr runat="server">
                                        <th class="col-xs-1">SL #
                                        </th>
                                        <th class="col-xs-1">Name
                                        </th>
                                        <th class="col-xs-1">Code
                                        </th>
                                        <th class="col-xs-1">DivisionOrState
                                        </th>
                                        <th class="col-xs-1">Applicable Country
                                        </th>
                                    </tr>
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
                                    <asp:Label ID="lblDistrictID" runat="server" Text='<%# Bind("IID") %>' Visible="false"></asp:Label>
                                    <asp:LinkButton ID="lnkBtnName" runat="server" CausesValidation="false" Text='<%#Bind("Name")%>'
                                        CommandArgument='<%# Bind("IID") %>' CommandName="EditDistrict"></asp:LinkButton>
                                </td>
                                <td>
                                    <asp:Label ID="lblCode" runat="server" Text='<%# Bind("Code") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblDescription" runat="server" Text='<%# Bind("DivisionOrState") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblApplicableCountryID" runat="server" Text='<%# Bind("CountryName") %>'></asp:Label>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <tr class="bg-info" runat="server">
                                <td style="text-align: center">
                                    <%# Container.DataItemIndex + 1%>
                                </td>
                                <td style="text-align: left">
                                    <asp:Label ID="lblDesignationID" runat="server" Text='<%# Bind("IID") %>' Visible="false"></asp:Label>
                                    <asp:LinkButton ID="lnkBtnName" runat="server" CausesValidation="false" Text='<%#Bind("Name")%>'
                                        CommandArgument='<%# Bind("IID") %>' CommandName="EditDistrict"></asp:LinkButton>
                                </td>
                                <td>
                                    <asp:Label ID="lblCode" runat="server" Text='<%# Bind("Code") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblDescription" runat="server" Text='<%# Bind("DivisionOrState") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblApplicableCountryID" runat="server" Text='<%# Bind("CountryName") %>'></asp:Label>
                                </td>
                            </tr>
                        </AlternatingItemTemplate>
                        <EmptyDataTemplate>
                            <table>
                                <tr>
                                    <td>Information is empty ...
                                    </td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                    </asp:ListView>
                    <asp:DataPager ID="dataPagerDistrict" runat="server" PagedControlID="lvDistrict"
                        PageSize="10" OnPreRender="dataPagerDistrict_PreRender">
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
</asp:Content>
