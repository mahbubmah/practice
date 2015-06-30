<%@ Page Title="" Language="C#" MasterPageFile="~/ControlAdmin/ControlAdminMaster.Master" AutoEventWireup="true" CodeBehind="MaterialWF.aspx.cs" Inherits="OH.Web.ControlAdmin.MaterialWF" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxConTK" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headAdmin" runat="server">
    <script type="text/javascript">
        $(function () {
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
    </script>

    <script type="text/javascript">
        $(function () {
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
            $('#' + '<%= dropDownClientType.ClientID %>').live('change', function () {
                var selectedTypeId = $(this).val();
                if (selectedTypeId == 1) {
                    $("#divCompanyOrOrganizationField").hide();
                }
                else {
                    $("#divCompanyOrOrganizationField").show();
                }
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentAdminMain" runat="server">
    <div class="container">
        <div class="row" style="text-align: center">
            <h2 style="text-align: center;">Material Information
            </h2>
        </div>

        <div class="row">
            <asp:Label ID="labelMessage" runat="server" Text=""></asp:Label>
        </div>



        <fieldset>
            <legend>Add New Material</legend>
            <div>
                <div class="col-lg-6">
                    <div class="row">
                        <div class="form-group col-xs-12">
                            <div class="input-group">
                                <span class="input-group-addon">Category
                            
                                </span>
                                <asp:TextBox ID="txtCategory" runat="server" Text="" class="form-control" placeholder="Search Category..."></asp:TextBox>
                            </div>
                        </div>
                        <div style="visibility: hidden; display: none">
                            <asp:TextBox ID="txtCategoryID" runat="server" Text=""></asp:TextBox>
                            <asp:Button ID="btnCategoryID" runat="server" Text="" OnClick="btnCategoryID_Click" />

                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group col-xs-12">
                            <div class="input-group">
                                <span class="input-group-addon">Code
                                </span>
                                <asp:TextBox ID="txtCode" runat="server" Text="" class="form-controlWebSer" ReadOnly="True"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group col-xs-12">
                            <div class="input-group">
                                <span class="input-group-addon">User ID
                                </span>
                                <asp:TextBox ID="txtUserID" runat="server" Text="" class="form-controlWebSer"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group col-xs-12">
                            <div class="input-group">
                                <span class="input-group-addon">Title Name

                            
                                </span>

                                <asp:TextBox ID="txtTitleName" runat="server" Text="" class="form-controlWebSer" placeholder="Enter Title Name..."></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="form-group col-xs-12">
                            <div class="input-group">
                                <span class="input-group-addon">Description
                                </span>
                                <asp:TextBox ID="txtDescription" runat="server" Text="" TextMode="MultiLine" class="form-controlWebSer" Height="55px" placeholder="Enter Description..."></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group col-xs-12">
                            <div class="input-group">
                                <span class="input-group-addon">Location
                                </span>
                                <asp:TextBox ID="txtLocation" runat="server" Text="" class="form-controlWebSer" placeholder="Enter Location..."></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="row" id="divBrand" runat="server">
                        <div class="form-group col-xs-12">
                            <div class="input-group">
                                <span class="input-group-addon">Brand
                                </span>
                                <asp:TextBox ID="txtBrand" runat="server" Text="" class="form-controlWebSer" placeholder="Enter Brand..."></asp:TextBox>
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
                                <asp:TextBox ID="txtModel" runat="server" Text="" class="form-controlWebSer" placeholder="Enter Model..."></asp:TextBox>
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
                                <asp:TextBox ID="txtColor" runat="server" Text="" class="form-controlWebSer" placeholder="Select Color..."></asp:TextBox>
                            </div>
                        </div>
                        <div style="visibility: hidden; display: none">
                            <asp:TextBox ID="txtColorID" runat="server" Text=""></asp:TextBox>
                        </div>
                    </div>


                    <div class="row">
                        <div class="form-group col-xs-12">
                            <div class="input-group">
                                <span class="input-group-addon">Date
                                </span>
                                <ajaxConTK:CalendarExtender ID="extDate2" runat="server" Enabled="True" TargetControlID="txtDate"></ajaxConTK:CalendarExtender>
                                <asp:TextBox ID="txtDate" runat="server" Text="" class="form-controlWebSer" placeholder="Select date..."></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group col-xs-12">
                            <div class="input-group">
                                <span class="input-group-addon">Display Last Date
                                </span>
                                <ajaxConTK:CalendarExtender ID="extDate1" runat="server" Enabled="True" TargetControlID="txtDisplayLastDate"></ajaxConTK:CalendarExtender>
                                <asp:TextBox ID="txtDisplayLastDate" runat="server" Text="" class="form-controlWebSer" placeholder="Select last day of display..."></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group col-xs-12">
                            <div class="input-group">
                                <span class="input-group-addon">Price
                                </span>
                                <asp:TextBox ID="txtPrice" runat="server" Text="" class="form-controlWebSer" placeholder="Enter price..."></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="form-group col-xs-12">
                            <div class="input-group col-lg-9" style="float: left">
                                <span class="input-group-addon">Add picture
                                </span>
                                <asp:FileUpload ID="MatPicUpload" runat="server" class="form-control"/>
                            </div>
                            <div style="float: right">
                                <asp:Button runat="server" ID="btnMatPicUpload" Text="Upload image" OnClick="btnMatPicUpload_Click" class="btn btn-primary" />

                            </div>
                        </div>
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

                                <asp:Button ID="btnPostAd" runat="server" Text="Post Ad" OnClick="btnPostAd_Click" CssClass="btn btn-primary"
                                    ValidationGroup="cValidationGroup"></asp:Button>


                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click"
                                    CssClass="btn btn-primary" />

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

                    <div>
                        <asp:DataList ID="datalistTempMatImage" runat="server" RepeatColumns="3">
                            <ItemTemplate>
                                <asp:Image ID="imgMatTempImage" runat="server" Width="200" Height="100" BorderColor="Red"  ImageUrl='<%#Bind("ImageUrlTemp") %>' />
                            </ItemTemplate>
                        </asp:DataList>
                    </div>
                </div>

                <div class="col-lg-6">
                    <fieldset>
                        <legend>Register</legend>
                        <div class="row">
                            <div class="form-group col-xs-12">
                                <div class="input-group">
                                    <span class="input-group-addon">Name
                                       
                                    </span>
                                    <asp:TextBox ID="txtAdGiverName" runat="server" Text="" class="form-control" placeholder="Enter your name..."></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="form-group col-xs-12">
                                <div class="input-group">
                                    <span class="input-group-addon">Natinal ID No.
                                    </span>
                                    <asp:TextBox ID="txtNationalID" runat="server" Text="" class="form-control" placeholder="Enter Natinal ID No..."></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="form-group col-xs-12">
                                <div class="input-group">
                                    <span class="input-group-addon">Account Type
                                        
                                    </span>
                                    <asp:DropDownList ID="dropDownClientType" runat="server" class="form-control"></asp:DropDownList>
                                </div>
                            </div>
                        </div>

                        <div id="divCompanyOrOrganizationField" style="display: none">
                            <fieldset>
                                <legend style="font-size: 120%" class="row">Enter your Company/Organization Informantion</legend>
                                <div class="row">
                                    <div class="form-group col-xs-12">
                                        <div class="input-group">
                                            <span class="input-group-addon">Company/Organization name
                                            </span>
                                            <asp:TextBox ID="txtCompanyName" runat="server" Text="" class="form-control" placeholder="Enter name of your Company/Organization..."></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group col-xs-12">
                                        <div class="input-group">
                                            <span class="input-group-addon">Company/Organization address
                                            </span>
                                            <asp:TextBox ID="txtCompanyAddress" runat="server" Text="" class="form-control" placeholder="Enter address..."></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group col-xs-12">
                                        <div class="input-group">
                                            <span class="input-group-addon">Company/Organization phone No.

                                            </span>
                                            <asp:TextBox ID="txtCompanyPhoneNo" runat="server" Text="" class="form-control" placeholder="Enter phone no..."></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </fieldset>
                            <br />
                        </div>



                        <div class="row">
                            <div class="form-group col-xs-12">
                                <div class="input-group">
                                    <span class="input-group-addon">Email
                                    </span>
                                    <asp:TextBox ID="txtEmail" runat="server" Text="" class="form-control" placeholder="Enter your email address..."></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="form-group col-xs-12">
                                <div class="input-group">
                                    <span class="input-group-addon">Contact No.
                                       
                                    </span>
                                    <asp:TextBox ID="txtContactNo" runat="server" Text="" class="form-control" placeholder="Enter your Contact no..."></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="form-group col-xs-12">
                                <div class="input-group">
                                    <span class="input-group-addon">Phone No(Optional)
                                    </span>
                                    <asp:TextBox ID="txtPhNoOptional" runat="server" Text="" class="form-control" placeholder="Enter your phone no..."></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="form-group col-xs-12">
                                <div class="input-group">
                                    <span class="input-group-addon">Location
                                    </span>
                                    <asp:TextBox ID="txtUserLocation" runat="server" Text="" class="form-control" placeholder="Enter your Location..."></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-12">

                                <div class="input-group pull-right">

                                    <asp:HiddenField runat="server" ID="hdAdGiverID" />
                                </div>


                            </div>

                        </div>
                    </fieldset>
                </div>
            </div>
            <div class="clearfix">
            </div>

        </fieldset>
        <div class="clearfix">
        </div>
        <br />

    </div>
    <br />
</asp:Content>

