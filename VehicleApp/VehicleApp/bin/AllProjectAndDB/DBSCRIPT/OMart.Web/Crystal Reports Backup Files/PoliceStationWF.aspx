<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.Master" AutoEventWireup="true" CodeBehind="PoliceStationWF.aspx.cs" Inherits="OMart.Web.ControlAdmin.PoliceStationWF" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AdminHead" runat="server">


    <%--    <script type="text/javascript">
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
        });--%>


    <%--    </script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AdminContentPlaceHolder" runat="server">
    <section>
        <div class="container">
            <div class="row">
                <div class="col-sm-12">
                    <asp:Label ID="labelMessage" runat="server"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-12">
                    <div class="manageAdd">
                        <div class="addPostMang">
                            <fieldset class="adminFieldset">
                                <legend>Add/Edit Police Station</legend>
                                <div class="col-xs-6">
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="lblCountry" runat="server" CssClass="control-label">Country</asp:Label>
                                                <asp:DropDownList ID="ddlCountry" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rfvCountry" runat="server" ControlToValidate="ddlCountry" ForeColor="Red"
                                                    ErrorMessage="Please select Country."
                                                    Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="lblDivOrState" runat="server" CssClass="control-label">Division Or State</asp:Label>
                                                <asp:DropDownList ID="ddlDivisionOrState" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlDivisionOrState_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rfvDivOrState" runat="server" ControlToValidate="ddlDivisionOrState" ForeColor="Red"
                                                    ErrorMessage="Please select Division Or State."
                                                    Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="lblDistrict" runat="server" CssClass="control-label">District</asp:Label>
                                                <asp:DropDownList ID="ddlDistrict" runat="server" CssClass="form-control"></asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rfvDistrict" runat="server" ControlToValidate="ddlDistrict" ForeColor="Red"
                                                    ErrorMessage="Please select District."
                                                    Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="lblPoliceStationCode" runat="server" CssClass="control-label">Police Station Code</asp:Label>
                                                <asp:TextBox ID="txtCode" runat="server" CssClass="form-control"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvCode" runat="server" ControlToValidate="txtCode" ForeColor="Red"
                                                    ErrorMessage="Please enter Police Station code."
                                                    Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="lblPoliceStationName" runat="server" CssClass="control-label">Police Station Name</asp:Label>
                                                <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName" ForeColor="Red"
                                                    ErrorMessage="Please enter Police Station name."
                                                    Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="clearfix">
                                            <asp:CheckBox ID="chkIsRemovedPoliceStation" runat="server" CssClass="checkbox" Text=" IsRemoved" />
                                        </div>
                                    </div>
     <%--                               <br />--%>
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-danger" OnClick="btnCancel_Click" />

                                                <asp:Button ID="btn_CreateOrEdit" runat="server" class="btn btn-primary  pull-right" Text="Submit"
                                                    OnClick="btn_CreateOrEdit_Click" ValidationGroup="gen"></asp:Button>
                                                <asp:HiddenField ID="hdPoliceStationID" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </fieldset>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-12">
                    <div class="manageAdd">
                        <div class="addPostMang">

                            <fieldset class="adminFieldset">
                                <legend>Police Station Lists</legend>

                                <asp:ListView ID="lvPoliceStation" runat="server" DataKeyNames="IID"
                                    OnPagePropertiesChanging="lvPoliceStation_PagePropertiesChanging" OnPreRender="dataPagerPoliceStation_PreRender">
                                    <LayoutTemplate>
                                        <table class="table  table-hover table-bordered">
                                            <thead>
                                                <tr runat="server">
                                                    <th class="col-xs-1">SL #
                                                    </th>
                                                    <th class="col-xs-2">Country 
                                                    </th>
                                                    <th class="col-xs-2">Division Or State 
                                                    </th>
                                                    <th class="col-xs-3">District 
                                                    </th>
                                                    <th class="col-xs-2">Police Station Code
                                                    </th>
                                                    <th class="col-xs-2">Police Station Name
                                                    </th>
                                                    <th class="col-xs-1">Is Removed
                                                    </th>
                                                    <th>Edit
                                                    </th>
                                                    <th>Delete
                                                    </th>

                                                </tr>
                                            </thead>
                                            <tbody id="itemPlaceholder" runat="server">
                                            </tbody>
                                        </table>
                                    </LayoutTemplate>
                                    <ItemTemplate>
                                        <tr runat="server">
                                            <td style="text-align: center">
                                                <%# Container.DataItemIndex + 1%>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblCountry" runat="server" Text='<%# Bind("CountryName") %>'></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblDivisionOrState" runat="server" Text='<%# Bind("DivisionOrState") %>'></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblDistrictID" runat="server" Text='<%# Bind("District") %>'></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblCode" runat="server" Text='<%# Bind("Code") %>'></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblName" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="chkIsRemoved" runat="server" Checked='<%# Bind("IsRemoved") %>' Enabled="false"></asp:CheckBox>
                                            </td>

                                            <td>
                                                <p data-placement="top" data-toggle="tooltip" title="Edit">
                                                    <asp:LinkButton ID="lnkbEdit" runat="server" CausesValidation="false" class="btn btn-primary btn-xs" data-title="Edit"
                                                        CommandArgument='<%# Bind("IID") %>' OnClick="lnkbEdit_Click"><i class="fa fa-pencil-square-o"></i></asp:LinkButton>

                                                </p>
                                            </td>
                                            <td>
                                                <p data-placement="top" data-toggle="tooltip" title="Delete">
                                                    <asp:LinkButton ID="lnkbDelete" runat="server" CausesValidation="false" class="btn btn-danger btn-xs" data-title="Delete" OnClientClick="return confirm('Are you sure, do you want to delete?');"
                                                        CommandArgument='<%# Bind("IID") %>' OnClick="lnkbDelete_Click"><i class="fa fa-trash"></i></asp:LinkButton>
                                                </p>
                                            </td>


                                        </tr>
                                    </ItemTemplate>
                                    <EmptyDataTemplate>
                                        <tr>
                                            <td>Information is empty ...
                                            </td>
                                        </tr>
                                        </table>
                                    </EmptyDataTemplate>
                                </asp:ListView>
                                <asp:DataPager ID="dataPagerDistrict" runat="server" PagedControlID="lvPoliceStation"
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
            </div>





        </div>
    </section>
    <%--    <div class="container">

        <div class="row">
            <h2>Police Station Info
            </h2>
        </div>
        <div>
            <asp:Label ID="labelMessage" runat="server" Text="..."></asp:Label>
        </div>

        <div class="row">
            <div class="adminFieldset">
                <fieldset>
                    <legend>Add New Police Station</legend>
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
                    </div>--%>

    <%--         <div class="row">
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
                    </div>--%>

    <%--            <div class="row">
                <div class="form-group col-xs-4">
                    <div class="dropdown">
                        <span class="input-group-addon">Applicable Country
                            <asp:RequiredFieldValidator ID="rfvApplicableCountry" runat="server"
                                ControlToValidate="ddlCountry" ForeColor="Red"
                                ToolTip="*" Display="Dynamic">*</asp:RequiredFieldValidator>
                        </span>
                        <asp:DropDownList ID="ddlCountry" runat="server" CssClass="form-control" AutoPostBack="true" 
                            onselectedindexchanged="ddlCountry_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </div>
            </div>--%>




    <%--                  <div class="row">
                        <div class="form-group col-xs-4">
                            <div class="input-group">
                                <span class="input-group-addon">Applicable Country

                            <asp:RequiredFieldValidator ID="rfvCountry" runat="server"
                                ControlToValidate="txtCountryName" ForeColor="Red"
                                ToolTip="*" Display="Dynamic" ValidationGroup="pStationValidationGroup">*</asp:RequiredFieldValidator>
                                </span>
                                <asp:TextBox ID="txtCountryName" runat="server" Text="" class="form-controlWebSer" placeholder="Search Country..."></asp:TextBox>
                            </div>
                        </div>
                        <div style="visibility: hidden">
                            <asp:TextBox ID="txtCountryID" runat="server" Text=""></asp:TextBox>
                        </div>
                    </div>--%>


    <%--           <div class="row">
                <div class="form-group col-xs-4">
                    <div class="dropdown">
                        <span class="input-group-addon">Division Or State
                            <asp:RequiredFieldValidator ID="rfvDivOrState" runat="server"
                                ControlToValidate="ddlDivisionOrState" ForeColor="Red"
                                ToolTip="*" Display="Dynamic">*</asp:RequiredFieldValidator>
                        </span>
                        <asp:DropDownList ID="ddlDivisionOrState" runat="server" CssClass="form-control" AutoPostBack="true"
                            onselectedindexchanged="ddlDivisionOrState_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </div>
            </div>--%>

    <%--                    <div class="row">
                        <div class="form-group col-xs-4">
                            <div class="input-group">
                                <span class="input-group-addon">Division Or State

                            <asp:RequiredFieldValidator ID="rfvDivOrState" runat="server"
                                ControlToValidate="txtDivOrStateName" ForeColor="Red"
                                ToolTip="*" Display="Dynamic" ValidationGroup="pStationValidationGroup">*</asp:RequiredFieldValidator>
                                </span>
                                <asp:TextBox ID="txtDivOrStateName" runat="server" Text="" class="form-controlWebSer" placeholder="Search Division Or State..."></asp:TextBox>
                            </div>
                        </div>
                        <div style="visibility: hidden">
                            <asp:TextBox ID="txtDivOrStateID" runat="server" Text=""></asp:TextBox>
                        </div>
                    </div>--%>

    <%--          <div class="row">
                <div class="form-group col-xs-4">
                    <div class="dropdown">
                        <span class="input-group-addon">District
                            <asp:RequiredFieldValidator ID="rfvDistrict" runat="server"
                                ControlToValidate="ddlDistrict" ForeColor="Red"
                                ToolTip="*" Display="Dynamic">*</asp:RequiredFieldValidator>
                        </span>
                        <asp:DropDownList ID="ddlDistrict" runat="server" CssClass="form-control">
                        </asp:DropDownList>
                    </div>
                </div>
            </div>--%>


    <%--                    <div class="row">
                        <div class="form-group col-xs-4">
                            <div class="input-group">
                                <span class="input-group-addon">District

                            <asp:RequiredFieldValidator ID="rfvDistrict" runat="server"
                                ControlToValidate="txtDistrictName" ForeColor="Red"
                                ToolTip="*" Display="Dynamic" ValidationGroup="pStationValidationGroup">*</asp:RequiredFieldValidator>
                                </span>
                                <asp:TextBox ID="txtDistrictName" runat="server" Text="" class="form-controlWebSer" placeholder="Search District..."></asp:TextBox>
                            </div>
                        </div>
                        <div style="visibility: hidden">
                            <asp:TextBox ID="txtDistrictID" runat="server" Text=""></asp:TextBox>
                        </div>
                    </div>--%>
    <%--             <div class="clearfix">
                    <asp:CheckBox ID="chkIsRemovedPoliceStation" runat="server" Text=" IsRemoved" />
                </div>
                    <div class="clearfix">
                    </div>--%>
    <%--                   <div class="row">
                        <div class="col-xs-4">

                            <%--<div class="input-group pull-right">--%>
    <%--                            <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="pStationValidationGroup" OnClick="btnSave_Click" CssClass="btn btn-primary pull-right" />
                            <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click"
                                CssClass="btn btn-primary" ValidationGroup="pStationValidationGroup" />
                            <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" CssClass="btn btn-primary" Visible="false" />
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" CssClass="btn btn-primary" />
                            <asp:HiddenField runat="server" ID="hdPoliceStationID" />
                            <asp:HiddenField runat="server" ID="hdIsEdit" />
                            <asp:HiddenField runat="server" ID="hdIsDelete" />

                            <asp:ValidationSummary
                                ShowMessageBox="true"
                                ShowSummary="false"
                                HeaderText="You must enter a value in the following fields:"
                                EnableClientScript="true"
                                runat="server" ValidationGroup="pStationValidationGroup" />--%>
    <%--</div>--%>
    <%--                 </div>
                    </div>--%>

    <%--
                </fieldset>
            </div>
            <div class="clearfix">
            </div>

        </div>--%>
    <%--       <br />
        <div class="row">
            <fieldset class="adminFieldset">
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
                                    <th class="col-xs-1">IsRemoved
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
                                <asp:CheckBox ID="chkIsRemovedPoliceStation" runat="server" Checked='<%# Bind("IsRemoved") %>' Enabled="false"></asp:CheckBox>
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
                                <asp:CheckBox ID="chkIsRemovedPoliceStation" runat="server" Checked='<%# Bind("IsRemoved") %>' Enabled="false"></asp:CheckBox>
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
        </div>--%>
    <%--    </div>--%>
</asp:Content>

