<%@ Page Title="" Language="C#" MasterPageFile="~/BookAdmin/OiiOMasterPage.Master" AutoEventWireup="true" CodeBehind="PoliceStationWF.aspx.cs" Inherits="OB.Web.BookAdmin.PoliceStationWF" %>

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
                $("#<%= txtDivOrStateID.ClientID%>").val(divisionOrStateID);
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


                $("#<%=txtDivOrStateName.ClientID %>").autocomplete({
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
                                givenText = $("#<%=txtDivOrStateName.ClientID %>").val();
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
                                    $("#<%=txtDivOrStateName.ClientID %>").val(givenText.toUpperCase());
                                }
                                else {
                                    $("#<%=txtDivOrStateName.ClientID %>").val(autoCompleteText.toUpperCase());
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




        $(function () {


            function logDistrictID(districtID) {
                $("#<%= txtDistrictID.ClientID%>").val(districtID);
            }

            AutoCompleteBindDistrict();

            var prmInstance = Sys.WebForms.PageRequestManager.getInstance();
            prmInstance.add_endRequest(function () {
                AutoCompleteBindDistrict();
            });

            function AutoCompleteBindDistrict() {
                //New For AutoComplete Selection
                var autoCompleteText = "";
                var currentText = "";
                var finalText = "";
                var givenText = "";
                var rowCount = 0;
                //End Section      


                $("#<%=txtDistrictName.ClientID %>").autocomplete({
                    source: function (request, response) {
                        var countryID = $("#<%=txtCountryID.ClientID %>").val();
                        var divOrStateID = $("#<%=txtDivOrStateID.ClientID %>").val();
                        var data_item = "{districtName:'" + request.term + "', countryID:" + countryID + ", divOrStateID:" + divOrStateID + "}";
                        $.ajax({
                            type: "POST",
                            url: "../HRWebService.asmx/GetDistrictByCountryDivOrStateID",
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
                                givenText = $("#<%=txtDistrictName.ClientID %>").val();
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
                                    $("#<%=txtDistrictName.ClientID %>").val(givenText.toUpperCase());
                                }
                                else {
                                    $("#<%=txtDistrictName.ClientID %>").val(autoCompleteText.toUpperCase());
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
                        logDistrictID(ui.item ? ui.item.IID : "");
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
                <h2>Police Station Info
                </h2>
            </div>
            <div>
                <asp:Label ID="labelMessage" runat="server" Text="..."></asp:Label>
            </div>
            <div>
                <fieldset>
                    <div class="row">
                        <div class="form-group col-xs-4">
                            <div class="input-group">
                                <span class="input-group-addon">Applicable Country
                            <asp:RequiredFieldValidator ID="rfvApplicableCountry" runat="server"
                                ControlToValidate="ddlCountry" InitialValue="-1" ForeColor="Red"
                                ToolTip="*" Display="Dynamic" ValidationGroup="pStationValidationGroup">*</asp:RequiredFieldValidator>
                                </span>
                                <asp:DropDownList ID="ddlCountry" runat="server" Width="100%" Height="32px" InitialValue="-1" CssClass="dropdown" AutoPostBack="true"
                                    OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group col-xs-4">
                            <div class="input-group">
                                <span class="input-group-addon">Division Or State
                            <asp:RequiredFieldValidator ID="rfvDivOrState" runat="server"
                                ControlToValidate="ddlDivisionOrState" ForeColor="Red"
                                ToolTip="*" Display="Dynamic" ValidationGroup="pStationValidationGroup">*</asp:RequiredFieldValidator>
                                </span>
                                <asp:DropDownList ID="ddlDivisionOrState" InitialValue="-1" runat="server" Width="100%" Height="32px" CssClass="dropdown" AutoPostBack="true"
                                    OnSelectedIndexChanged="ddlDivisionOrState_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group col-xs-4">
                            <div class="input-group">
                                <span class="input-group-addon">District
                            <asp:RequiredFieldValidator ID="rfvDistrict" runat="server"
                                ControlToValidate="ddlDistrict" ForeColor="Red"
                                ToolTip="*" Display="Dynamic" ValidationGroup="pStationValidationGroup">*</asp:RequiredFieldValidator>
                                </span>
                                <asp:DropDownList ID="ddlDistrict" InitialValue="-1" Width="100%" Height="32px" runat="server" CssClass="dropdown">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>


                    <div class="row">
                        <div class="form-group col-xs-4">
                            <div class="input-group">
                                <span class="input-group-addon">Police Station Code
                            <asp:RequiredFieldValidator ID="rfvPoliceStaionCode" runat="server"
                                ControlToValidate="txtCode" ForeColor="Red"
                                ToolTip="*" Display="Dynamic" ValidationGroup="pStationValidationGroup">*</asp:RequiredFieldValidator>
                                </span>
                                <asp:TextBox ID="txtCode" runat="server" Text="" class="form-control" placeholder="Enter code..."></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="form-group col-xs-4">
                            <div class="input-group">
                                <span class="input-group-addon">Police Station Name
                            <asp:RequiredFieldValidator ID="rfvPoliceStaionName" runat="server"
                                ControlToValidate="txtName" ForeColor="Red"
                                ToolTip="*" Display="Dynamic" ValidationGroup="pStationValidationGroup">*</asp:RequiredFieldValidator>
                                </span>
                                <asp:TextBox ID="txtName" runat="server" Text="" class="form-control" placeholder="Enter Name..."></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group col-xs-5">
                            <div class="input-group">
                                <asp:CheckBox ID="chkRemove" runat="server" Text=" &nbsp Is Remove" />
                            </div>
                        </div>
                    </div>
                    <%-- <div class="row">
                <div class="form-group col-xs-4">
                    <div class="input-group">
                        <span class="input-group-addon">Applicable Country

                            <asp:RequiredFieldValidator ID="rfvCountry" runat="server"
                                ControlToValidate="txtCountryName" ForeColor="Red"
                                ToolTip="*" Display="Dynamic">*</asp:RequiredFieldValidator>
                        </span>
                        <asp:TextBox ID="txtCountryName" runat="server" Text="" ValidationGroup="pStationValidationGroup" class="form-control" placeholder="Search Country..."></asp:TextBox>
                    </div>
                </div>
                    <div style="visibility:hidden">
                         <asp:TextBox ID="txtCountryID" runat="server" Text=""></asp:TextBox>
                    </div>
            </div>--%>
                    <%--  <div class="row">
                <div class="form-group col-xs-4">
                    <div class="input-group">
                        <span class="input-group-addon">Division Or State

                            <asp:RequiredFieldValidator ID="rfvDivOrState" runat="server"
                                ControlToValidate="txtDivOrStateName" ForeColor="Red"
                                ToolTip="*" Display="Dynamic">*</asp:RequiredFieldValidator>
                        </span>
                        <asp:TextBox ID="txtDivOrStateName" runat="server" Text="" ValidationGroup="pStationValidationGroup" class="form-control" placeholder="Search Division Or State..."></asp:TextBox>
                    </div>
                </div>
                    <div style="visibility:hidden">
                         <asp:TextBox ID="txtDivOrStateID" runat="server" Text=""></asp:TextBox>
                    </div>
            </div>--%>
                    <%-- <div class="row">
                <div class="form-group col-xs-4">
                    <div class="input-group">
                        <span class="input-group-addon">District

                            <asp:RequiredFieldValidator ID="rfvDistrict" runat="server"
                                ControlToValidate="txtDistrictName" ForeColor="Red"
                                ToolTip="*" Display="Dynamic">*</asp:RequiredFieldValidator>
                        </span>
                        <asp:TextBox ID="txtDistrictName" runat="server" Text="" ValidationGroup="pStationValidationGroup" class="form-control" placeholder="Search District..."></asp:TextBox>
                    </div>
                </div>
                    <div style="visibility:hidden">
                         <asp:TextBox ID="txtDistrictID" runat="server" Text=""></asp:TextBox>
                    </div>
            </div>--%>
                    <div class="clearfix">
                    </div>
                    <div class="row">
                        <div class="col-xs-4">

                            <div class="input-group">
                                <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="pStationValidationGroup" OnClick="btnSave_Click" CssClass="btn btn-primary" />
                                <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click"
                                    CssClass="btn btn-primary" ValidationGroup="pStationValidationGroup" />
                                <asp:Button ID="btnDelete" runat="server" Text="Delete" Visible="false" OnClick="btnDelete_Click" CssClass="btn btn-primary" />
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" CssClass="btn btn-primary" />
                                <asp:HiddenField runat="server" ID="hdPoliceStationID" />
                                <asp:HiddenField runat="server" ID="hdIsEdit" />
                                <asp:HiddenField runat="server" ID="hdIsDelete" />
                                <asp:HiddenField runat="server" ID="hdSave" />
                            </div>
                            <asp:ValidationSummary
                                ShowMessageBox="true"
                                ShowSummary="false"
                                HeaderText="You have to fill the Marked fields:"
                                EnableClientScript="true"
                                runat="server" ValidationGroup="pStationValidationGroup" />
                        </div>
                    </div>
                </fieldset>
            </div>
            <br />
            <div>
                <fieldset>
                    <legend>Police Station Information</legend>
                    <asp:ListView ID="lvPoliceStation" runat="server" DataKeyNames="IID"
                        OnItemCommand="lvPoliceStation_ItemCommand"
                        OnPagePropertiesChanging="lvPoliceStation_PagePropertiesChanging"
                        OnPreRender="dataPagerPoliceStation_PreRender">
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
                                        <th class="col-xs-1">Country Name
                                        </th>
                                        <th class="col-xs-1">Division OrState  
                                        </th>
                                        <th class="col-xs-1">District
                                        </th>
                                        <th class="col-xs-1">Is Remove
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
                                    <asp:Label ID="lblPoliceStationID" runat="server" Text='<%# Bind("IID") %>' Visible="false"></asp:Label>
                                    <asp:LinkButton ID="lnkBtnName" runat="server" CausesValidation="false" Text='<%#Bind("Name")%>'
                                        CommandArgument='<%# Bind("IID") %>' CommandName="EditPoliceStation"></asp:LinkButton>
                                </td>
                                <td>
                                    <asp:Label ID="lblCode" runat="server" Text='<%# Bind("Code") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblCountryID" runat="server" Text='<%# Bind("CountryName") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblDivisionOrStateID" runat="server" Text='<%# Bind("DivisionOrState") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblDistrictID" runat="server" Text='<%# Bind("District") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:CheckBox ID="chkIssRemoved" runat="server" Checked='<%# Bind("IsRemoved") %>' Enabled="false"></asp:CheckBox>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <tr class="bg-info" runat="server">
                                <td style="text-align: center">
                                    <%# Container.DataItemIndex + 1%>
                                </td>
                                <td style="text-align: left">
                                    <asp:Label ID="lblPoliceStationID" runat="server" Text='<%# Bind("IID") %>' Visible="false"></asp:Label>
                                    <asp:LinkButton ID="lnkBtnName" runat="server" CausesValidation="false" Text='<%#Bind("Name")%>'
                                        CommandArgument='<%# Bind("IID") %>' CommandName="EditPoliceStation"></asp:LinkButton>
                                </td>
                                <td>
                                    <asp:Label ID="lblCode" runat="server" Text='<%# Bind("Code") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblCountryID" runat="server" Text='<%# Bind("CountryName") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblDivisionOrStateID" runat="server" Text='<%# Bind("DivisionOrState") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblDistrictID" runat="server" Text='<%# Bind("District") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:CheckBox ID="chkIssRemoved" runat="server" Checked='<%# Bind("IsRemoved") %>' Enabled="false"></asp:CheckBox>
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
                    <asp:DataPager ID="dataPagerPoliceStation" runat="server" PagedControlID="lvPoliceStation"
                        PageSize="10" OnPreRender="dataPagerPoliceStation_PreRender">
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

