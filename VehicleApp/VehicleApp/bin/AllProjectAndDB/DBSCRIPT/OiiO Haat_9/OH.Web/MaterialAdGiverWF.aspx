<%@ Page Title="" Language="C#" MasterPageFile="~/InnerMasterPage.Master" AutoEventWireup="true" CodeBehind="MaterialAdGiverWF.aspx.cs" Inherits="OH.Web.MaterialAdGiverWF" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>



<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxConTK" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headInner" runat="server">
    <%--<script type="text/javascript">
        $(function () {
            $.noConflict();
            function logParentID(catID) {
                $("#<%= txtCategoryID.ClientID%>").val(catID);
            }

            AutoCompleteBindCategory();

            var prmInstance = Sys.WebForms.PageRequestManager.getInstance();
            prmInstance.add_endRequest(function () {
                AutoCompleteBindCategory();
            });

            function AutoCompleteBindCategory() {
                //New For AutoComplete Selection
                var autoCompleteText = "";
                var currentText = "";
                var finalText = "";
                var givenText = "";
                var rowCount = 0;
                //End Section              
                $("#<%=txtCategory.ClientID %>").autocomplete({
                    source: function (request, response) {
                        var data_item = "{catName:'" + request.term + "'}";
                        $.ajax({
                            type: "POST",
                            url: "../HRWebService.asmx/GetAllCategoryForSearch",
                            dataType: "json",
                            data: data_item,
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {
                                response($.map(data.d, function (item) {
                                    return {
                                        label: item.Description,
                                        Name: item.Name,
                                        IID: item.IID
                                    };
                                }));
                                //AutoComplete Selection
                                var dataList = data.d;
                                rowCount = 0;
                                givenText = $("#<%=txtCategory.ClientID %>").val();
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
                                    $("#<%=txtCategory.ClientID %>").val(givenText.toUpperCase());
                                }
                                else {
                                    $("#<%=txtCategory.ClientID %>").val(autoCompleteText.toUpperCase());
                                }

                                autoCompleteText = "";
                                //End Section                               
                            }
                        });
                    },
                    delay: 300,
                    minLength: 1,

                    focus: function (event, ui) {
                        $(this).val(ui.item.Name);
                        return false;
                    },
                    select: function (event, ui) {
                        logParentID(ui.item ? ui.item.IID : "");
                        $(this).val(ui.item.Name);
                        $(this).select();
                        $("#<%=btnCategoryID.ClientID %>").click();
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

    <script type="text/javascript">
        $(function () {
            $.noConflict();
            function logBrandID(brandID) {
                $("#<%= txtBrandID.ClientID%>").val(brandID);
            }

            AutoCompleteBindBrand();

            var prmInstance = Sys.WebForms.PageRequestManager.getInstance();
            prmInstance.add_endRequest(function () {
                AutoCompleteBindBrand();
            });

            function AutoCompleteBindBrand() {
                //New For AutoComplete Selection
                var autoCompleteText = "";
                var currentText = "";
                var finalText = "";
                var givenText = "";
                var rowCount = 0;
                //End Section              
                $("#<%=txtBrand.ClientID %>").autocomplete({
                    source: function (request, response) {
                        var data_item = "{brandName:'" + request.term + "'}";
                        $.ajax({
                            type: "POST",
                            url: "../HRWebService.asmx/GetAllBrandByName",
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
                                givenText = $("#<%=txtBrand.ClientID %>").val();
                                $.each(dataList, function (index, item) {
                                    currentText = item.Description;
                                    if (autoCompleteText == "") {
                                        autoCompleteText = currentText;
                                    }
                                    else {
                                        finalText = givenText.toUpperCase();
                                        if (autoCompleteText.length > givenText.length) {
                                            for (var i = givenText.length; i < autoCompleteText.length; i++) {
                                                if (autoCompleteText.charAt(i).toUpperCase() == item.Description.charAt(i).toUpperCase()) {
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
                                    $("#<%=txtBrand.ClientID %>").val(givenText.toUpperCase());
                                }
                                else {
                                    $("#<%=txtBrand.ClientID %>").val(autoCompleteText.toUpperCase());
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
                        logBrandID(ui.item ? ui.item.IID : "");
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
    </script>




    <script type="text/javascript">
        $(function () {
            function logModelID(modelID) {
                $("#<%= txtModelID.ClientID%>").val(modelID);
            }

            AutoCompleteBindModel();

            var prmInstance = Sys.WebForms.PageRequestManager.getInstance();
            prmInstance.add_endRequest(function () {
                AutoCompleteBindModel();
            });

            function AutoCompleteBindModel() {
                //New For AutoComplete Selection                
                var autoCompleteText = "";
                var currentText = "";
                var finalText = "";
                var givenText = "";
                var rowCount = 0;

                //End Section              
                $("#<%=txtModel.ClientID %>").autocomplete({
                    source: function (request, response) {
                        var brandID = $("#<%= txtBrandID.ClientID%>").val();
                        var data_item = "{modelName:'" + request.term + "', brandID:" + brandID + "}";
                        $.ajax({
                            type: "POST",
                            url: "../HRWebService.asmx/GetAllModelByName",
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
                                givenText = $("#<%=txtModel.ClientID %>").val();
                                $.each(dataList, function (index, item) {
                                    currentText = item.Description;
                                    if (autoCompleteText == "") {
                                        autoCompleteText = currentText;
                                    }
                                    else {
                                        finalText = givenText.toUpperCase();
                                        if (autoCompleteText.length > givenText.length) {
                                            for (var i = givenText.length; i < autoCompleteText.length; i++) {
                                                if (autoCompleteText.charAt(i).toUpperCase() == item.Description.charAt(i).toUpperCase()) {
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
                                    $("#<%=txtModel.ClientID %>").val(givenText.toUpperCase());
                                }
                                else {
                                    $("#<%=txtModel.ClientID %>").val(autoCompleteText.toUpperCase());
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
                        logModelID(ui.item ? ui.item.IID : "");
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
    </script>
    <script type="text/javascript">
        $(function () {
            function logColorID(colorID) {
                $("#<%= txtBrandID.ClientID%>").val(colorID);
            }

            AutoCompleteBindColor();

            var prmInstance = Sys.WebForms.PageRequestManager.getInstance();
            prmInstance.add_endRequest(function () {
                AutoCompleteBindColor();
            });

            function AutoCompleteBindColor() {
                //New For AutoComplete Selection
                var autoCompleteText = "";
                var currentText = "";
                var finalText = "";
                var givenText = "";
                var rowCount = 0;
                //End Section              
                $("#<%=txtColor.ClientID %>").autocomplete({
                    source: function (request, response) {
                        var data_item = "{colorName:'" + request.term + "'}";
                        $.ajax({
                            type: "POST",
                            url: "../HRWebService.asmx/GetAllColorNameForSearch",
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
                                givenText = $("#<%=txtColor.ClientID %>").val();
                                $.each(dataList, function (index, item) {
                                    currentText = item.Description;
                                    if (autoCompleteText == "") {
                                        autoCompleteText = currentText;
                                    }
                                    else {
                                        finalText = givenText.toUpperCase();
                                        if (autoCompleteText.length > givenText.length) {
                                            for (var i = givenText.length; i < autoCompleteText.length; i++) {
                                                if (autoCompleteText.charAt(i).toUpperCase() == item.Description.charAt(i).toUpperCase()) {
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
                                    $("#<%=txtColor.ClientID %>").val(givenText.toUpperCase());
                                }
                                else {
                                    $("#<%=txtColor.ClientID %>").val(autoCompleteText.toUpperCase());
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
                        logColorID(ui.item ? ui.item.IID : "");
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
    </script>

    <script type="text/javascript">
        $(function () {
            function logLocationID(districtId, policeStationId, locationId, policeStation, districtName) {
                $("#<%= txtDistrictID.ClientID%>").val(districtId);
                $("#<%= txtPoliceStationID.ClientID%>").val(policeStationId);
                $("#<%= txtLocationID.ClientID%>").val(locationId);
                $("#<%= txtPoliceStation.ClientID%>").val(policeStation);
                $("#<%= txtDistrict.ClientID%>").val(districtName);
            }

            AutoCompleteBindLocation();

            var prmInstance = Sys.WebForms.PageRequestManager.getInstance();
            prmInstance.add_endRequest(function () {
                AutoCompleteBindLocation();
            });

            function AutoCompleteBindLocation() {
                //New For AutoComplete Selection
                var autoCompleteText = "";
                var currentText = "";
                var finalText = "";
                var givenText = "";
                var rowCount = 0;
                //End Section              
                $("#<%=txtLocation.ClientID %>").autocomplete({
                    source: function (request, response) {
                        var policeStationId = $("#<%= txtPoliceStationID.ClientID%>").val();
                        var districtId = $("#<%= txtDistrictID.ClientID%>").val();
                        var countryID = $("#<%= hdCountryID.ClientID%>").val();
                        var data_item = "{locationName:'" + request.term + "', policeStationId:'" + policeStationId + "', districtId:'" + districtId + "', countryID:'" + countryID + "'}";
                        $.ajax({
                            type: "POST",
                            url: "../HRWebService.asmx/GetLocationForSearch",
                            dataType: "json",
                            data: data_item,
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {
                                response($.map(data.d, function (item) {
                                    return {
                                        label: item.fullSearchLocation,
                                        LocationName: item.CurrentLocationName,
                                        LocationID: item.LocationID,
                                        DistrictID: item.DistrictID,
                                        PoliceStationID: item.PoliceStationID,
                                        PoliceStationName: item.PoliceStationName,
                                        DistrictName: item.DistrictName
                                    };
                                }));
                                //AutoComplete Selection
                                var dataList = data.d;
                                rowCount = 0;
                                givenText = $("#<%=txtLocation.ClientID %>").val();
                                $.each(dataList, function (index, item) {
                                    currentText = item.Description;
                                    if (autoCompleteText == "") {
                                        autoCompleteText = currentText;
                                    }
                                    else {
                                        finalText = givenText;
                                        if (autoCompleteText.length > givenText.length) {
                                            for (var i = givenText.length; i < autoCompleteText.length; i++) {
                                                if (autoCompleteText.charAt(i).toUpperCase() == item.Description.charAt(i).toUpperCase()) {
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
                                
                                autoCompleteText = "";
                                //End Section                               
                            }
                        });
                    },
                    delay: 300,
                    minLength: 1,
                    focus: function (event, ui) {
                        $(this).val(ui.item.LocationName);
                        return false;
                    },
                    select: function (event, ui) {
                        logLocationID((ui.item ? ui.item.DistrictID : ""), (ui.item ? ui.item.PoliceStationID : ""), (ui.item ? ui.item.LocationID : ""), (ui.item ? ui.item.PoliceStationName : ""), (ui.item ? ui.item.DistrictName : ""));
                        $(this).val(ui.item.LocationName);
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
    </script>

    <script type="text/javascript">
        $(function () {
            function logPoliceStationID(districtId, policeStationId, districtName) {
                $("#<%= txtDistrictID.ClientID%>").val(districtId);
                $("#<%= txtPoliceStationID.ClientID%>").val(policeStationId);
                $("#<%= txtDistrict.ClientID%>").val(districtName);
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
                        var districtId = $("#<%= txtDistrictID.ClientID%>").val();
                        var countryID = $("#<%= hdCountryID.ClientID%>").val();
                        var data_item = "{policeStationName:'" + request.term + "', districtId:'" + districtId + "', countryID:'" + countryID + "'}";
                        $.ajax({
                            type: "POST",
                            url: "../HRWebService.asmx/GetPoliceStationForSearch",
                            dataType: "json",
                            data: data_item,
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {
                                response($.map(data.d, function (item) {
                                    return {
                                        label: item.fullSearchPoliceStation,
                                        DistrictID: item.DistrictID,
                                        PoliceStationID: item.PoliceStationID,
                                        PoliceStationName: item.PoliceStationName,
                                        DistrictName: item.DistrictName
                                    };
                                }));
                                //AutoComplete Selection
                                var dataList = data.d;
                                rowCount = 0;
                                givenText = $("#<%=txtPoliceStation.ClientID %>").val();
                                $.each(dataList, function (index, item) {
                                    currentText = item.Description;
                                    if (autoCompleteText == "") {
                                        autoCompleteText = currentText;
                                    }
                                    else {
                                        finalText = givenText.toUpperCase();
                                        if (autoCompleteText.length > givenText.length) {
                                            for (var i = givenText.length; i < autoCompleteText.length; i++) {
                                                if (autoCompleteText.charAt(i).toUpperCase() == item.Description.charAt(i).toUpperCase()) {
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
                        $(this).val(ui.item.PoliceStationName);
                        return false;
                    },
                    select: function (event, ui) {
                        logPoliceStationID((ui.item ? ui.item.DistrictID : ""), (ui.item ? ui.item.PoliceStationID : ""), (ui.item ? ui.item.DistrictName : ""));
                        $(this).val(ui.item.PoliceStationName);
                        $(this).select();
                        $("#<%= txtLocationID.ClientID%>").val("");
                        $("#<%= txtLocation.ClientID%>").val("");
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
    </script>
    <script type="text/javascript">
        $(function () {
            function logDistrictID(districtId) {
                $("#<%= txtDistrictID.ClientID%>").val(districtId);
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
                $("#<%=txtDistrict.ClientID %>").autocomplete({
                    source: function (request, response) {
                        var countryID = $("#<%= hdCountryID.ClientID%>").val();
                        var data_item = "{districtName:'" + request.term + "', countryID:'" + countryID + "'}";
                        $.ajax({
                            type: "POST",
                            url: "../HRWebService.asmx/GetDistrictForSearch",
                            dataType: "json",
                            data: data_item,
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {
                                response($.map(data.d, function (item) {
                                    return {
                                        label: item.fullSearchDistrict,
                                        DistrictID: item.DistrictID,
                                        DistrictName: item.DistrictName
                                    };
                                }));
                                //AutoComplete Selection
                                var dataList = data.d;
                                rowCount = 0;
                                givenText = $("#<%=txtDistrict.ClientID %>").val();
                                $.each(dataList, function (index, item) {
                                    currentText = item.Description;
                                    if (autoCompleteText == "") {
                                        autoCompleteText = currentText;
                                    }
                                    else {
                                        finalText = givenText.toUpperCase();
                                        if (autoCompleteText.length > givenText.length) {
                                            for (var i = givenText.length; i < autoCompleteText.length; i++) {
                                                if (autoCompleteText.charAt(i).toUpperCase() == item.Description.charAt(i).toUpperCase()) {
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
                                    $("#<%=txtDistrict.ClientID %>").val(givenText.toUpperCase());
                                }
                                else {
                                    $("#<%=txtDistrict.ClientID %>").val(autoCompleteText.toUpperCase());
                                }

                                autoCompleteText = "";
                                //End Section                               
                            }
                        });
                    },
                    delay: 300,
                    minLength: 1,
                    focus: function (event, ui) {
                        $(this).val(ui.item.DistrictName);
                        return false;
                    },
                    select: function (event, ui) {
                        logDistrictID(ui.item ? ui.item.DistrictID : "");
                        $(this).val(ui.item.DistrictName);
                        $(this).select();
                        $("#<%= txtPoliceStationID.ClientID%>").val("");
                        $("#<%= txtLocationID.ClientID%>").val("");
                        $("#<%= txtLocation.ClientID%>").val("");
                        $("#<%= txtPoliceStation.ClientID%>").val("");
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
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentInnerMain" runat="server">




    <section style="background: #f9f9f9;">
        <%--        <asp:UpdatePanel ID="upPostAdAdd" runat="server">
            <ContentTemplate>--%>
        <div class="container postAddInfoHead">
            <div class="row">
                <div class="col-md-12">
                    <h2>Material Information</h2>

                </div>
            </div>
            <div class="container postAddInfo ">

                <div class="row">
                    <div class="col-md-12">
                        <div class="row">
                            <asp:Label ID="labelMessage" runat="server" Text=""></asp:Label>
                        </div>
                        <h3 class="panel-title">Edit Material</h3>
                         <asp:UpdatePanel runat="server" ID="updatePanelCategory">
                            <ContentTemplate>
                        <div class="panelPostBody">
                            <div class="groupPart">
                                <label class="oiioLbl">Category</label>
                                <div class="row">
                                    <div class="col-sm-4 col-md-4 col-lg-4">
                                        <asp:DropDownList ID="dropDownCategory" OnSelectedIndexChanged="btnCategoryID_Click" AutoPostBack="True" runat="server" class="form-control"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="clearfix"></div>
                            </div>
                            <div style="visibility: hidden; display: none">
                                <asp:HiddenField ID="HiddenField1" runat="server" />

                                <asp:Button ID="Button1" runat="server" Text=""  OnClick="btnCategoryID_Click"/>
                            </div>
                            <div class="groupPart">
                                <label class="oiioLbl">Add Referance Code</label>
                                <div class="row">
                                    <div class="col-sm-4 col-md-4 col-lg-4">
                                        <asp:TextBox ID="txtCode" runat="server" Text="" class="form-control oiioPostFcnt" ReadOnly="True"></asp:TextBox>

                                    </div>
                                </div>

                                <div class="clearfix"></div>
                            </div>

                        </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        <h3 class="panel-title">Add Posting Details</h3>
                        <div class="panelPostBody">
                            <div class="groupPart">
                                <label class="oiioLbl">Add Title name</label>
                                <div class="row">
                                    <div class="col-sm-4 col-md-4 col-lg-4">

                                        <asp:TextBox ID="txtTitleName" runat="server" Text="" class="form-control oiioPostFcnt" placeholder="Enter Title Name..."></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rbfFirstName" runat="server" ControlToValidate="txtTitleName" ForeColor="Red"
                                            ErrorMessage="PLease Enter Product Title."
                                            Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-sm-8 col-md-8 col-lg-8">
                                        <p>This field cannot be empty.</p>
                                    </div>
                                </div>

                                <div class="clearfix"></div>
                            </div>
                            <div class="groupPart">
                                <label class="oiioLbl">Discription of the add</label>
                                <div class="row">
                                    <div class="col-sm-4 col-md-4 col-lg-4">

                                        <CKEditor:CKEditorControl ID="txtDescription" BasePath="/ckeditor/" runat="server" placeholder="Enter Description...">
                                        </CKEditor:CKEditorControl>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtDescription" ForeColor="Red"
                                            ErrorMessage="PLease enter Description."
                                            Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-sm-8 col-md-8 col-lg-8">
                                        <p>
                                            Enter the information about your add as much as possible ; add with detailed 
                                        and longer discriptions will increase your chances for product to be 
                                        sold quickly.
                                        </p>
                                    </div>
                                </div>

                                <div class="clearfix"></div>
                            </div>
                            <div class="groupPart">
                                <label class="oiioLbl">Add Images</label>
                                <div class="row">

                                    <div class="col-sm-4 col-md-4 col-lg-4">
                                        <div class="form-inline" style="margin-bottom: 10px;">
                                            <div class="col-sm-8 col-md-8 col-lg-8">
                                                <div id="js-upload-files">
                                                    <asp:FileUpload AllowMultiple="True" ID="MatPicUpload" runat="server" class="oiioPostFcnt" />
                                                </div>
                                            </div>

                                        </div>
                                    </div>
                                    <div class="col-sm-8 col-md-8 col-lg-8">
                                        <div id="js-upload-submit" class="col-sm-2 col-md-2 col-lg-2 pull-left">
                                            <asp:Button runat="server" ID="btnMatPicUpload" Text="Add Images" OnClick="btnMatPicUpload_Click" class="btn btn-primary" Height="27px"/>
                                        </div>
                                        <div class="col-sm-10 col-md-10 col-lg-10">
                                            <p>
                                                Upload clear images as many as posible which will increase your chances for 
                                        product to be sold quickly.
                                            </p>
                                        </div>
                                    </div>
                                    <div class=" col-sm-12 col-md-12 col-lg-12" style="width: 97%; min-height: 100px; border: 1px solid #F3F3F3; margin-left: 1px;">
                                        <asp:DataList ID="datalistMatPic" runat="server" RepeatColumns="8">
                                            <ItemTemplate>
                                                <asp:Image ID="imgMatTempImage" CssClass="img-thumbnail" runat="server" Width="90" Style="" Height="75" ImageUrl='<%#Bind("ImageUrlTemp") %>' />
                                                <asp:CheckBox ID="chkImg" CssClass="checkbox-inline" runat="server" />
                                                &emsp; 
                                            </ItemTemplate>
                                        </asp:DataList>
                                        <asp:Button runat="server" Text="Delete selected" CssClass="btn btn-danger" ID="btnDeleteImageTemp" OnClick="btnDeleteSelectedImage_Click"></asp:Button>

                                    </div>
                                </div>

                                <div class="clearfix"></div>
                            </div>
                            <div class="groupPart">
                                <label class="oiioLbl">Price of product</label>
                                <div class="row">
                                    <div class="col-sm-4 col-md-4 col-lg-4">
                                        <asp:TextBox ID="txtPrice" runat="server" Text="" TextMode="Number" CssClass="form-control oiioPostFcnt" placeholder="Enter price..."></asp:TextBox>
                                        <ajaxConTK:FilteredTextBoxExtender ID="FilteredTextBoxExtenderPrice" runat="server"
                                            TargetControlID="txtPrice" FilterType="Custom, Numbers" ValidChars="." />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtPrice" ForeColor="Red"
                                            ErrorMessage="PLease enter your  price."
                                            Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                        <br />
                                         <asp:CheckBox ID="chkNegotiable" runat="server" Text="Check if this Price is Negotiable" />
                                        <%--<div class="btn-group" data-toggle="buttons">
                                            <label class="btn btn-default">
                                                <asp:CheckBox ID="chkNegotiable" runat="server" Text="Check if this Price is Negotiable"/>
                                                <span class="glyphicon glyphicon-ok"></span>
                                            </label>
                                          
                                        </div>--%>

                                    </div>
                                    <div class="col-sm-8 col-md-8 col-lg-8">
                                        <p>How much do you want for your product ?</p>
                                    </div>
                                </div>

                                <div class="clearfix"></div>
                            </div>
                            <div class="groupPart" id="div1">
                                <label class="oiioLbl">Visibility</label>
                                <div class="row">
                                    <div class="col-sm-4 col-md-4 col-lg-4">

                                        <asp:TextBox ID="txtPostVisibilityDay" runat="server" Text="" CssClass="form-control oiioPostFcnt" TextMode="Number" placeholder="Select last day of display..."></asp:TextBox>
                                        <ajaxConTK:FilteredTextBoxExtender ID="FilteredTextBoxExtenderVisibilityDay" runat="server"
                                            TargetControlID="txtPostVisibilityDay" FilterType="Custom, Numbers" ValidChars="." />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtPostVisibilityDay" ForeColor="Red"
                                            ErrorMessage="PLease enter last day of display."
                                            Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-sm-8 col-md-8 col-lg-8">
                                        <p>
                                            How many days do you want to post visibility ?
                                        </p>
                                    </div>
                                </div>

                                <div class="clearfix"></div>
                            </div>

                        </div>

                        <h3 class="panel-title">Location</h3>

                        <asp:UpdatePanel ID="upLocation" runat="server">
                            <ContentTemplate>

                                <div class="panelPostBody">
                                    <div class="groupPart">
                                        <label class="oiioLbl">Please enter your district name</label>
                                        <div class="row">
                                            <div class="col-sm-4 col-md-4 col-lg-4">
                                                 <asp:TextBox ID="txtDistrict" runat="server" Text="" class="form-control" placeholder="District..."></asp:TextBox>
                                              <%--  <asp:DropDownList ID="dropdownDistrict" OnSelectedIndexChanged="dropdownDistrict_SelectedIndexChange" AutoPostBack="True" runat="server" CssClass="form-control oiioPostFcnt"></asp:DropDownList>--%>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"
                                                ControlToValidate="txtDistrict" ForeColor="Red"
                                                ToolTip="*" Display="Dynamic" ValidationGroup="UserValidationGroup" ErrorMessage="District is required...">*</asp:RequiredFieldValidator>
                                                 </div>
                                        </div>
                                        <div style="visibility: hidden; display: none">
                                            <asp:TextBox ID="txtDistrictID" runat="server" Text=""></asp:TextBox>
                                        </div>
                                        <div class="clearfix"></div>
                                    </div>
                                    <div class="groupPart">
                                        <label class="oiioLbl">Please select your police station</label>
                                        <div class="row">
                                            <div class="col-sm-4 col-md-4 col-lg-4">
                                                 <asp:TextBox ID="txtPoliceStation" runat="server" Text="" class="form-control" placeholder="Police station ..."></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                                ControlToValidate="txtPoliceStation" ForeColor="Red"
                                                ToolTip="*" Display="Dynamic" ValidationGroup="UserValidationGroup" ErrorMessage="Police Station is required...">*</asp:RequiredFieldValidator>
                                                <%--<asp:DropDownList ID="dropdownPoliceStation" runat="server" CssClass="form-control oiioPostFcnt"></asp:DropDownList>--%>
                                                <div style="visibility: hidden; display: none">
                                                    <asp:TextBox ID="txtPoliceStationID" runat="server" Text=""></asp:TextBox>
                                                </div>
                                            </div>


                                        </div>
                                    </div>

                                    <div class="groupPart">
                                        <label class="oiioLbl">Specific location</label>
                                        <div class="row">
                                            <div class="col-sm-4 col-md-4 col-lg-4">

                                                <asp:TextBox ID="txtLocation" runat="server" Text="" class="form-control txtAra" placeholder="location..." TextMode="MultiLine"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtLocation" ForeColor="Red"
                                                    ErrorMessage="PLease enter your location."
                                                    Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                            </div>
                                            <div style="visibility: hidden; display: none">
                                    <asp:TextBox ID="txtLocationID" runat="server" Text=""></asp:TextBox>
                                </div>
                                            <div class="col-sm-8 col-md-8">
                                                <p>You have to mantion your specific location.</p>
                                            </div>
                                        </div>
                                        <div style="visibility: hidden; display: none">
                                            <asp:TextBox ID="TextBox8" runat="server" Text=""></asp:TextBox>
                                        </div>

                                    </div>

                                    <div class="clearfix"></div>
                                </div>

                            </ContentTemplate>
                        </asp:UpdatePanel>

                    </div>
                </div>


                <h3 class="panel-title">Linkup</h3>
                <div class="panelPostBody">
                    <div class="groupPart">
                        <label class="oiioLbl">Website Url</label>
                        <div class="row">
                            <div class="col-sm-4 col-md-4 col-lg-4">
                                <asp:TextBox ID="txtWeburl" runat="server" placeholder="http://www.oiiohaat.com" CssClass="form-control oiioPostFcnt"></asp:TextBox>
                            </div>
                            <div class="col-sm-8 col-md-8 col-lg-8">
                                <p>Enter your website link if you have.Include 'http://' in your Website Url</p>
                            </div>
                        </div>

                        <div class="clearfix"></div>
                    </div>
                    <div class="groupPart">
                        <label class="oiioLbl">Youtube Url</label>
                        <div class="row">
                            <div class="col-sm-4 col-md-4 col-lg-4">
                                <asp:TextBox ID="txtYoutubeUrl" runat="server" placeholder="http://www.youtube.com" CssClass="form-control oiioPostFcnt"></asp:TextBox>
                            </div>
                            <div class="col-sm-8 col-md-8 col-lg-8">
                                <p>Enter your youtube link if you have.</p>
                            </div>
                        </div>

                        <div class="clearfix"></div>
                    </div>
                </div>


                <h3 class="panel-title">Your Contact Details</h3>
                <div class="panelPostBody">
                    <div class="groupPart">
                        <div class="col-sm-4 col-md-4 col-lg-4">
                            <p>
                                <asp:Label ID="lblAdGiverInfo" runat="server" Text=""></asp:Label>
                            </p>
                            <div class="btn-group" data-toggle="buttons">
                                <label>
                                    Your Email
                                </label>

                            </div>
                            <asp:TextBox ID="txtUserID" runat="server" CssClass="form-control oiioPostFcnt " ReadOnly="true"></asp:TextBox>
                            <asp:Label ID="lblEmail" runat="server"></asp:Label>
                            <br />

                            <div class="btn-group" data-toggle="buttons">
                                <label>
                                    Your Contact Number
                                </label>

                            </div>
                            <asp:TextBox ID="txtPhoneNumber" runat="server" CssClass="form-control oiioPostFcnt" TextMode="Phone"></asp:TextBox>
                            <asp:Label ID="lblPhoneNumber" runat="server"></asp:Label>
                            <ajaxConTK:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                TargetControlID="txtPhoneNumber" FilterType="Custom, Numbers" ValidChars="." />
                            <br />

                            <div class="btn-group" data-toggle="buttons">
                                <label>
                                    Your Name
                                </label>

                            </div>

                            <asp:TextBox ID="TxtName" ReadOnly="True" runat="server" Text="" class="form-control oiioPostFcnt" placeholder="Enter you email address..."></asp:TextBox>


                        </div>
                        <div class="col-sm-8 col-md-8 col-lg-8">
                            <div class="well">

                                <p>Check for spelling and grammatical errors.</p>
                                <p>Make sure all details are up to date and be careful not to overload your profile with too much text.</p>
                                <p>Only use experience that you have had in the last 5 years or that shows an unusual talent</p>
                                <p>Keep your format consistent.</p>


                            </div>
                        </div>
                        <div class="clearfix"></div>
                    </div>

                </div>



                <div class="col-sm-12" style="margin-top: 10px;">
                    <p>
                        By clicking post my add you agree to OiiO Haat's terms & condition, privacy policy and posting rules.
                    </p>

                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click"
                        CssClass="btn btn-info pull-right" BorderWidth="5px" BorderColor="WhiteSmoke" />
                    &nbsp;

                            <asp:Button ID="btnUpdatePost" runat="server" Text="Update" OnClick="btnUpdatePost_Click" CssClass="btn btn-primary btn-info pull-right"
                                ValidationGroup="gen" BorderWidth="5px" BorderColor="WhiteSmoke"></asp:Button>

                    <asp:HiddenField runat="server" ID="hdMaterialID" />
                    <asp:HiddenField runat="server" ID="hdIsEdit" />
                    <asp:HiddenField runat="server" ID="hdCountryID" />

                    <asp:ValidationSummary
                        ShowMessageBox="true"
                        ShowSummary="false"
                        HeaderText="You must enter a value in the following fields:"
                        EnableClientScript="true"
                        runat="server" ValidationGroup="gen" />


                    <div class="row" style="visibility: hidden; display: none">
                        <div class="col-xs-12">
                            <asp:CheckBox ID="chkIsUrgent" runat="server" Text="Urgent" CssClass="checkbox-inline"></asp:CheckBox>
                        </div>
                        <div class="col-xs-12">
                            <asp:CheckBox ID="chkIsFeatured" runat="server" Text="Featured" CssClass="checkbox-inline"></asp:CheckBox>
                        </div>
                        <div class="col-xs-12">
                            <asp:CheckBox ID="chkIsSpotlight" runat="server" Text="Spotlight" CssClass="checkbox-inline"></asp:CheckBox>
                        </div>
                    </div>

                    <div id="divBrand" runat="server" class="form-group ">
                        <div class="input-group">
                            <span class="input-group-addon">Brand
                            </span>
                            <asp:TextBox ID="txtBrand" runat="server" Text="" class="form-control" placeholder="Enter Brand..."></asp:TextBox>
                        </div>
                    </div>
                    <div style="visibility: hidden; display: none">
                          <asp:TextBox ID="txtBrandID" runat="server" Text=""></asp:TextBox>
                       <%-- <asp:HiddenField ID="txtBrandID" runat="server" />--%>
                    </div>

                    <div id="divModel" runat="server" class="form-group">
                        <div class="input-group">
                            <span class="input-group-addon">Model
                            </span>
                            <asp:TextBox ID="txtModel" runat="server" Text="" class="form-control" placeholder="Enter Model..."></asp:TextBox>
                        </div>
                    </div>
                    <div style="visibility: hidden; display: none">
                          <asp:TextBox ID="txtModelID" runat="server" Text=""></asp:TextBox>
                    <%--    <asp:HiddenField ID="txtModelID" runat="server" />--%>

                    </div>

                    <div id="divColor" runat="server" class="form-group">
                        <div class="input-group">
                            <span class="input-group-addon">Color
                            </span>
                            <asp:TextBox ID="txtColor" runat="server" Text="" class="form-control" placeholder="Select Color..."></asp:TextBox>
                        </div>
                    </div>
                    <div style="visibility: hidden; display: none">
                        <asp:TextBox ID="txtColorID" runat="server" Text=""></asp:TextBox>
                   <%--     <asp:HiddenField ID="txtColorID" runat="server" />--%>
                    </div>

                </div>
            </div>
        </div>
        <%-- </ContentTemplate>
        </asp:UpdatePanel>--%>
    </section>


























    <%--<div class="container">
        <div class="row" style="text-align: center">
            <h2 style="text-align: center;">Material Information
            </h2>
        </div>

        <div class="row">
            <asp:Label ID="labelMessage" runat="server" Text=""></asp:Label>
        </div>

        <div>
            <div class="col-lg-2">
            </div>
            <div class="col-lg-8">
                <fieldset>
                    <legend>Edit Material</legend>
                    <div>
                        
                        <div class="row">
                            <div class="form-group col-xs-12">
                                <div class="input-group">
                                    <span class="input-group-addon">Category
                                
                                    </span>
                                    <asp:DropDownList ID="dropDownCategory" OnSelectedIndexChanged="btnCategoryID_Click" AutoPostBack="True" runat="server" class="form-control"></asp:DropDownList>
                                   
                                </div>
                                <div class="clearfix"></div>
                            </div>
                            <div style="visibility: hidden; display: none">
                                <asp:HiddenField ID="HiddenField1" runat="server" />

                                <asp:Button ID="Button1" runat="server" Text="" OnClick="btnCategoryID_Click" />
                            </div>
                        </div>
                        
                        <div class="row">
                            <div class="form-group col-xs-12">
                                <div class="input-group">
                                    <span class="input-group-addon">Code
                                    </span>
                                    <asp:TextBox ID="txtCode" runat="server" Text="" class="form-control" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="form-group col-xs-12">
                                <div class="input-group">
                                    <span class="input-group-addon">User ID
                                        
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                               ControlToValidate="txtUserID" ForeColor="Red"
                               ToolTip="*" Display="Dynamic" ValidationGroup="UserValidationGroup" ErrorMessage="User Id is required...">*</asp:RequiredFieldValidator>

                                    </span>
                                    <asp:TextBox ID="txtUserID" ReadOnly="True" TextMode="Email" runat="server" Text="" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="form-group col-xs-12">
                                <div class="input-group">
                                    <span class="input-group-addon">Title Name
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                            ControlToValidate="txtTitleName" ForeColor="Red"
                                            ToolTip="*" Display="Dynamic" ValidationGroup="UserValidationGroup" ErrorMessage="Title name is required...">*</asp:RequiredFieldValidator>

                                    </span>

                                    <asp:TextBox ID="txtTitleName" runat="server" Text="" class="form-control" placeholder="Enter Title Name..."></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="form-group col-xs-12">
                                <div class="input-group">
                                    <span class="input-group-addon">Description
                                    </span>
                                    <asp:TextBox ID="txtDescription" runat="server" Text="" TextMode="MultiLine" class="form-control" Height="55px" placeholder="Enter Description..."></asp:TextBox>
                                </div>
                            </div>

                        </div>

                        <div class="row">
                            <div class="form-group">

                                <div class="form-group col-lg-6">
                                    <div class="input-group">
                                        <span class="input-group-addon">District
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"
                                                ControlToValidate="txtDistrict" ForeColor="Red"
                                                ToolTip="*" Display="Dynamic" ValidationGroup="UserValidationGroup" ErrorMessage="District is required...">*</asp:RequiredFieldValidator>
                                        </span>
                                        <asp:TextBox ID="txtDistrict" runat="server" Text="" class="form-control" placeholder="District..."></asp:TextBox>
                                    </div>
                                    <div style="visibility: hidden; display: none">
                                        <asp:TextBox ID="txtDistrictID" runat="server" Text=""></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-group col-lg-6">
                                    <div class="input-group">
                                        <span class="input-group-addon">Police Station
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                                ControlToValidate="txtPoliceStation" ForeColor="Red"
                                                ToolTip="*" Display="Dynamic" ValidationGroup="UserValidationGroup" ErrorMessage="Police Station is required...">*</asp:RequiredFieldValidator>
                                        </span>
                                        <asp:TextBox ID="txtPoliceStation" runat="server" Text="" class="form-control" placeholder="Police station ..."></asp:TextBox>
                                    </div>
                                    <div style="visibility: hidden; display: none">
                                        <asp:TextBox ID="txtPoliceStationID" runat="server" Text=""></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="form-group col-xs-12">
                                <div class="input-group">
                                    <span class="input-group-addon">Location
                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                                 ControlToValidate="txtLocation" ForeColor="Red"
                                                 ToolTip="*" Display="Dynamic" ValidationGroup="UserValidationGroup" ErrorMessage="Location is required...">*</asp:RequiredFieldValidator>
                                    </span>
                                    <asp:TextBox ID="txtLocation" runat="server" Text="" class="form-control" placeholder="Location..."></asp:TextBox>
                                </div>
                                <div style="visibility: hidden; display: none">
                                    <asp:TextBox ID="txtLocationID" runat="server" Text=""></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row" id="divBrand" runat="server">
                            <div class="form-group col-xs-12">
                                <div class="input-group">
                                    <span class="input-group-addon">Brand
                                    </span>
                                    <asp:TextBox ID="txtBrand" runat="server" Text="" class="form-control" placeholder="Enter Brand..."></asp:TextBox>
                                </div>
                            </div>
                            <div style="visibility: hidden; display: none">
                                <asp:TextBox ID="txtBrandID" runat="server" Text=""></asp:TextBox>
                            </div>
                        </div>
                        <div class="row" id="divModel" runat="server">
                            <div class="form-group col-xs-12">
                                <div class="input-group">
                                    <span class="input-group-addon">Model
                                    </span>
                                    <asp:TextBox ID="txtModel" runat="server" Text="" class="form-control" placeholder="Enter Model..."></asp:TextBox>
                                </div>
                            </div>
                            <div style="visibility: hidden; display: none">
                                <asp:TextBox ID="txtModelID" runat="server" Text=""></asp:TextBox>

                            </div>
                        </div>

                        <div class="row" id="divColor" runat="server">
                            <div class="form-group col-xs-12">
                                <div class="input-group">
                                    <span class="input-group-addon">Color
                                    </span>
                                    <asp:TextBox ID="txtColor" runat="server" Text="" class="form-control" placeholder="Select Color..."></asp:TextBox>
                                </div>
                            </div>
                            <div style="visibility: hidden; display: none">
                                <asp:TextBox ID="txtColorID" runat="server" Text=""></asp:TextBox>
                            </div>
                        </div>

                        <div class="row" id="div1" runat="server">
                            <div class="form-group col-xs-12">
                                <div class="input-group">
                                    <span class="input-group-addon">Post Visibility Day(s)
                                    </span>
                                    <asp:TextBox ID="txtPostVisibilityDay" runat="server" Text="" class="form-control" placeholder="Select last day of display..."></asp:TextBox>
                                </div>
                            </div>
                        </div>



                        <div class="row">
                            <div class="form-group col-xs-12">
                                <div class="input-group">
                                    <span class="input-group-addon">Price
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                                            ControlToValidate="txtPrice" ForeColor="Red"
                                            ToolTip="*" Display="Dynamic" ValidationGroup="UserValidationGroup" ErrorMessage="Price is required...">*</asp:RequiredFieldValidator>
                                    </span>
                                    <asp:TextBox ID="txtPrice" runat="server" Text="" class="form-control" placeholder="Enter price..."></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="fileuploadPart">
                            <asp:FileUpload AllowMultiple="True" ID="MatPicUpload" runat="server" class="form-control" />
                            <asp:Button runat="server" ID="btnMatPicUpload" Text="Add image" OnClick="btnMatPicUpload_Click" Height="27px" class="btn btn-primary pull-right" />
                        </div>
                        <div class="form-group">
                            <asp:DataList ID="datalistMatPic" runat="server" RepeatColumns="4">
                                <ItemTemplate>
                                    <asp:Image ID="imgMatTempImage" CssClass="img-thumbnail" runat="server" Width="90" Style="margin: 0 1px 2px;" Height="75" ImageUrl='<%#Bind("ImageUrlTemp") %>' />
                                    <asp:CheckBox ID="chkImg" CssClass="checkbox-inline" runat="server" />
                                    &emsp; &emsp; &emsp;&emsp;&emsp;&emsp;
                                </ItemTemplate>
                            </asp:DataList>
                            <asp:Button runat="server" Text="Delete selected" CssClass="btn btn-danger" ID="btnDeleteImageTemp" OnClick="btnDeleteSelectedImage_Click"></asp:Button>
                        </div>

                        <div class="row" style="visibility: hidden; display: none">
                            <div class="col-xs-12">
                                <asp:CheckBox ID="chkIsUrgent" runat="server" Text="Urgent" CssClass="checkbox-inline"></asp:CheckBox>
                            </div>
                            <div class="col-xs-12">
                                <asp:CheckBox ID="chkIsFeatured" runat="server" Text="Featured" CssClass="checkbox-inline"></asp:CheckBox>
                            </div>
                            <div class="col-xs-12">
                                <asp:CheckBox ID="chkIsSpotlight" runat="server" Text="Spotlight" CssClass="checkbox-inline"></asp:CheckBox>
                            </div>
                        </div>


                        <div class="row">
                            <div class="col-xs-12">

                                <div class="input-group pull-right">

                                    <asp:Button ID="btnUpdatePost" runat="server" Text="Update" OnClick="btnUpdatePost_Click" CssClass="btn btn-primary"
                                        ValidationGroup="cValidationGroup"></asp:Button>
                                    &nbsp;
                                 

                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click"
                                    CssClass="btn btn-primary" />

                                    <asp:HiddenField runat="server" ID="hdCountryID" />
                                    <asp:HiddenField runat="server" ID="hdMaterialID" />
                                    <asp:HiddenField runat="server" ID="hdIsEdit" />

                                    <asp:ValidationSummary
                                        ShowMessageBox="true"
                                        ShowSummary="false"
                                        HeaderText="You must enter a value in the following fields:"
                                        EnableClientScript="true"
                                        runat="server" ValidationGroup="cValidationGroup" />

                                </div>


                            </div>

                        </div>


                    </div>
                    <div class="clearfix">
                    </div>
                </fieldset>
            </div>
            <div class="col-lg-2">
            </div>
        </div>


        <div class="clearfix">
        </div>
        <br />

    </div>--%>
    <br />

    <asp:Label ID="labelCategoryList" runat="server" Text=""></asp:Label>
</asp:Content>

