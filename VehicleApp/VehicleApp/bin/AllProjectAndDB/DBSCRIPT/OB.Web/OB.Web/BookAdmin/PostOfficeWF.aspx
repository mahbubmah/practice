<%@ Page Title="" Language="C#" MasterPageFile="~/BookAdmin/OiiOMasterPage.Master" AutoEventWireup="true" CodeBehind="PostOfficeWF.aspx.cs" Inherits="OB.Web.BookAdmin.PostOfficeWF" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--    <script type="text/javascript">
        ////////////////////////For Country////////Asiful Islam/////23.02.2015//////////////
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
                            url: "../HRWebService.asmx/GetCountryByAlphabetForSearch",
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

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

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

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

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

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        $(function () {


            function logPoliceStationID(PoliceStationID) {
                $("#<%= txtPoliceStationID.ClientID%>").val(PoliceStationID);
            }

            AutoCompleteBindPoliceStation();

            var prmInstance = Sys.WebForms.PageRequestManager.getInstance();
            prmInstance.add_endRequest(function () {
                AutoCompleteBindPoliceStation();
            });

            function AutoCompleteBindPoliceStation() {
                //New For AutoComplete Selection
                var autoCompleteText = "";
                var currentText = "";
                var finalText = "";
                var givenText = "";
                var rowCount = 0;
                //End Section      


                $("#<%=txtPoliceStation.ClientID %>").autocomplete({
                    source: function (request, response) {
                        var countryID = $("#<%=txtCountryID.ClientID %>").val();
                         var divOrStateID = $("#<%=txtDivOrStateID.ClientID %>").val();
                         var districtID = $("#<%=txtDistrictID.ClientID %>").val();
                         var data_item = "{policeStationName:'" + request.term + "',districtID:" + districtID + " , divOrStateID:" + divOrStateID + ",countryID:" + countryID + " }";
                         $.ajax({
                             type: "POST",
                             url: "../HRWebService.asmx/GetpoliceStatioByDistrictByCountryDivOrStateID",
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
                                 givenText = $("#<%=txtPoliceStation.ClientID %>").val();
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
                                     $("#<%=txtPoliceStation.ClientID %>").val(givenText.toUpperCase());
                                }
                                else {
                                    $("#<%=txtPoliceStation.ClientID %>").val(autoCompleteText.toUpperCase());
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
                        logPoliceStationID(ui.item ? ui.item.IID : "");
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
                <h2>Post Office Info
                </h2>
            </div>
            <div>
                <asp:Label ID="labelMessagePostOffice" runat="server" Text="..."></asp:Label>
            </div>
            <div>
                <fieldset>
                    <legend>New Post Office</legend>
                    <div class="row">
                        <div class="form-group col-xs-4">
                            <div class="input-group">
                                <span class="input-group-addon">Applicable Country
                            <asp:RequiredFieldValidator ID="rfvApplicableCountry" runat="server"
                                ControlToValidate="ddlCountry" ForeColor="Red"
                                ToolTip="*" Display="Dynamic" ValidationGroup="PostOfficeValidationGroup">*</asp:RequiredFieldValidator>
                                </span>
                                <asp:DropDownList ID="ddlCountry" runat="server" Width="100%" Height="32px" InitialValue="-1" CssClass="dropdown" AutoPostBack="true" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged"
                                    >
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group col-xs-4">
                            <div class="input-group">
                                <span class="input-group-addon">Division Or State
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                ControlToValidate="ddlDivisionOrState" ForeColor="Red"
                                ToolTip="*" Display="Dynamic" ValidationGroup="PostOfficeValidationGroup">*</asp:RequiredFieldValidator>
                                </span>
                                <asp:DropDownList ID="ddlDivisionOrState" InitialValue="-1" runat="server" Width="100%" Height="32px" CssClass="dropdown" AutoPostBack="true" OnSelectedIndexChanged="ddlDivisionOrState_SelectedIndexChanged"
                                   >
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group col-xs-4">
                            <div class="input-group">
                                <span class="input-group-addon">District
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                ControlToValidate="ddlDistrict" ForeColor="Red"
                                ToolTip="*" Display="Dynamic" ValidationGroup="PostOfficeValidationGroup">*</asp:RequiredFieldValidator>
                                </span>
                                <asp:DropDownList ID="ddlDistrict" InitialValue="-1" Width="100%" Height="32px" runat="server" CssClass="dropdown" AutoPostBack="true" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group col-xs-4">
                            <div class="input-group">
                                <span class="input-group-addon">Police Station
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                ControlToValidate="ddlPoliceStation" ForeColor="Red"
                                ToolTip="*" Display="Dynamic" ValidationGroup="PostOfficeValidationGroup">*</asp:RequiredFieldValidator>
                                </span>
                                <asp:DropDownList ID="ddlPoliceStation" InitialValue="-1" Width="100%" Height="32px" runat="server" CssClass="dropdown">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="form-group col-xs-4">
                            <div class="input-group">
                                <span class="input-group-addon">Post Office Code
                            <asp:RequiredFieldValidator ID="rfvPostOfficeCode" runat="server"
                                ControlToValidate="txtPostOfficeCode" ForeColor="Red"
                                ToolTip="*" Display="Dynamic" ValidationGroup="PostOfficeValidationGroup" >*</asp:RequiredFieldValidator>
                                </span>
                                <asp:TextBox ID="txtPostOfficeCode" runat="server" Text="" class="form-control" placeholder="Enter Post Office code..."></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="form-group col-xs-4">
                            <div class="input-group">
                                <span class="input-group-addon">Post Office Name
                            <asp:RequiredFieldValidator ID="rfvPostOfficeName" runat="server"
                                ControlToValidate="txtPostOfficeName" ForeColor="Red"
                                ToolTip="*" Display="Dynamic"  ValidationGroup="PostOfficeValidationGroup">*</asp:RequiredFieldValidator>
                                </span>
                                <asp:TextBox ID="txtPostOfficeName" runat="server" Text="" class="form-control" placeholder="Enter Post Office Name..."></asp:TextBox>
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




                    <%--  <div class="row">
                        <div class="form-group col-xs-4">
                            <div class="input-group">
                                <span class="input-group-addon">Applicable Country
                            <asp:RequiredFieldValidator ID="rfvCountry" runat="server"
                                ControlToValidate="txtCountryName" ForeColor="Red"
                                ToolTip="*" Display="Dynamic">*</asp:RequiredFieldValidator>
                                </span>
                                <asp:TextBox ID="txtCountryName" runat="server" Text="" ValidationGroup="PostOfficeValidationGroup" class="form-controlWebSer" placeholder="Search Country..."></asp:TextBox>
                            </div>
                        </div>
                        <div style="visibility: hidden">
                            <asp:TextBox ID="txtCountryID" runat="server" Text=""></asp:TextBox>
                        </div>
                    </div>--%>

                    <%--        <div class="row">
                        <div class="form-group col-xs-4">
                            <div class="input-group">
                                <span class="input-group-addon">Division Or State
                            <asp:RequiredFieldValidator ID="rfvDivOrState" runat="server"
                                ControlToValidate="txtDivOrStateName" ForeColor="Red"
                                ToolTip="*" Display="Dynamic">*</asp:RequiredFieldValidator>
                                </span>
                                <asp:TextBox ID="txtDivOrStateName" runat="server" Text="" ValidationGroup="PostOfficeValidationGroup" class="form-controlWebSer" placeholder="Search Division Or State..."></asp:TextBox>
                            </div>
                        </div>
                        <div style="visibility: hidden">
                            <asp:TextBox ID="txtDivOrStateID" runat="server" Text=""></asp:TextBox>
                        </div>
                    </div>--%>

                    <%--   <div class="row">
                        <div class="form-group col-xs-4">
                            <div class="input-group">
                                <span class="input-group-addon">District
                            <asp:RequiredFieldValidator ID="rfvDistrict" runat="server"
                                ControlToValidate="txtDistrictName" ForeColor="Red"
                                ToolTip="*" Display="Dynamic">*</asp:RequiredFieldValidator>
                                </span>
                                <asp:TextBox ID="txtDistrictName" runat="server" Text="" ValidationGroup="PostOfficeValidationGroup" class="form-controlWebSer" placeholder="Search District..."></asp:TextBox>
                            </div>
                        </div>
                        <div style="visibility: hidden">
                            <asp:TextBox ID="txtDistrictID" runat="server" Text=""></asp:TextBox>
                        </div>
                    </div>--%>

                    <%--   <div class="row">
                        <div class="form-group col-xs-4">
                            <div class="input-group">
                                <span class="input-group-addon">Police Station
                            <asp:RequiredFieldValidator ID="rfvPoliceStation" runat="server"
                                ControlToValidate="txtPoliceStation" ForeColor="Red"
                                ToolTip="*" Display="Dynamic">*</asp:RequiredFieldValidator>
                                </span>
                                <asp:TextBox ID="txtPoliceStation" runat="server" Text="" ValidationGroup="PostOfficeValidationGroup" class="form-controlWebSer" placeholder="Search Police Station..."></asp:TextBox>
                            </div>
                        </div>
                        <div style="visibility: hidden">
                            <asp:TextBox ID="txtPoliceStationID" runat="server" Text=""></asp:TextBox>
                        </div>
                    </div>--%>

                    <div class="row">
                        <div class="col-xs-4">
                            <div class="input-group pull-right">
                                <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="PostOfficeValidationGroup" CssClass="btn btn-primary" OnClick="btnSave_Click"></asp:Button>
                                <asp:Button ID="btnUpdate" runat="server" Text="Update" ValidationGroup="PostOfficeValidationGroup"
                                    CssClass="btn btn-primary" OnClick="btnUpdate_Click" />
                                <asp:Button ID="btnDelete" runat="server" Text="Delete"
                                    CssClass="btn btn-primary" OnClick="btnDelete_Click" Visible="false" />
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel"
                                    CssClass="btn btn-primary" OnClick="btnCancel_Click" />
                                <asp:HiddenField runat="server" ID="hdPostOfficeID" />
                                <asp:HiddenField runat="server" ID="hdIsEdit" />
                                <asp:HiddenField runat="server" ID="hdIsDelete" />
                                 <asp:HiddenField runat="server" ID="hdSave" />
                            </div>
                             <asp:ValidationSummary
                                                            ShowMessageBox="true"
                                                            ShowSummary="false"
                                                            HeaderText="You have to fill the Marked fields:"
                                                            EnableClientScript="true"
                                                            runat="server" ValidationGroup="PostOfficeValidationGroup" />
                        </div>
                    </div>

                </fieldset>
            </div>

            <div>
                <fieldset>
                    <legend>Post Office Information</legend>
                    <asp:ListView ID="lvPostOffice" runat="server" DataKeyNames="IID" OnItemCommand="lvPostOffice_ItemCommand" OnPagePropertiesChanging="lvPostOffice_PagePropertiesChanging">
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
                                        <th class="col-xs-1">Police Station
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
                                    <asp:Label ID="lblPostOfficeID" runat="server" Text='<%# Bind("IID") %>' Visible="false"></asp:Label>
                                    <asp:LinkButton ID="lnkBtnName" runat="server" CausesValidation="false" Text='<%#Bind("Name")%>'
                                        CommandArgument='<%# Bind("IID") %>' CommandName="EditPostOffice"></asp:LinkButton>
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
                                    <asp:Label ID="lblPoliceStationID" runat="server" Text='<%# Bind("PoliceStationName") %>'></asp:Label>
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
                                    <asp:Label ID="lblPostOfficeID" runat="server" Text='<%# Bind("IID") %>' Visible="false"></asp:Label>
                                    <asp:LinkButton ID="lnkBtnName" runat="server" CausesValidation="false" Text='<%#Bind("Name")%>'
                                        CommandArgument='<%# Bind("IID") %>' CommandName="EditPostOffice"></asp:LinkButton>
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
                                    <asp:Label ID="lblPoliceStationID" runat="server" Text='<%# Bind("PoliceStationName") %>'></asp:Label>
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
                    <asp:DataPager ID="dataPagerPostOffice" runat="server" PagedControlID="lvPostOffice"
                        PageSize="10" OnPreRender="dataPagerPostOffice_PreRender">
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
        <div class="fa-space-shuttle">
        </div>
    </div>
</asp:Content>
