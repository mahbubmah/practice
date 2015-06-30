<%@ Page Title="" Language="C#" MasterPageFile="~/ControlAdmin/ControlAdminMaster.Master" AutoEventWireup="true" CodeBehind="MaterialAdminListWF.aspx.cs" Inherits="OH.Web.ControlAdmin.MaterialAdminListWF" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxConTK" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headAdmin" runat="server">
    <script type="text/javascript">
        $(function () {
            
            function logCategoryID(memberID) {
                $("#<%= txtCategoryID.ClientID%>").val(memberID);
            }

            AutoCompleteBindMember();

            var prmInstance = Sys.WebForms.PageRequestManager.getInstance();
            prmInstance.add_endRequest(function () {
                AutoCompleteBindMember();
            });

            function AutoCompleteBindMember() {
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
                        logCategoryID(ui.item ? ui.item.IID : "");
                        $(this).val(ui.item.Name);
                        $("#<%=btnSearch.ClientID %>").click();
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
            function logAdGiverID(memberID) {
                $("#<%= txtAdGiverID.ClientID%>").val(memberID);
            }

            AutoCompleteBindMember();

            var prmInstance = Sys.WebForms.PageRequestManager.getInstance();
            prmInstance.add_endRequest(function () {
                AutoCompleteBindMember();
            });

            function AutoCompleteBindMember() {
                //New For AutoComplete Selection
                var autoCompleteText = "";
                var currentText = "";
                var finalText = "";
                var givenText = "";
                var rowCount = 0;
                //End Section              
                $("#<%=txtAdgiver.ClientID %>").autocomplete({
                    source: function (request, response) {
                        var data_item = "{adGiverName:'" + request.term + "'}";
                        $.ajax({
                            type: "POST",
                            url: "../HRWebService.asmx/GetAllAdGiverForAdminSearch",
                            dataType: "json",
                            data: data_item,
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {
                                response($.map(data.d, function (item) {
                                    return {
                                        label: item.EmailID,
                                        IID: item.IID
                                    };
                                }));
                                //AutoComplete Selection
                                var dataList = data.d;
                                rowCount = 0;
                                givenText = $("#<%=txtAdgiver.ClientID %>").val();
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
                                    $("#<%=txtAdgiver.ClientID %>").val(givenText.toUpperCase());
                                }
                                else {
                                    $("#<%=txtAdgiver.ClientID %>").val(autoCompleteText.toUpperCase());
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
                        logAdGiverID(ui.item ? ui.item.IID : "");
                        $(this).val(ui.item.label);
                        $(this).select();
                        $("#<%=btnSearch.ClientID %>").click();
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentAdminMain" runat="server">


    <div class="container">


        <div class="row" style="text-align: center">
            <h2>Material Information
            </h2>
        </div>

        <div class="row">
            <asp:Label ID="labelMessage" runat="server" Text=""></asp:Label>
        </div>



        <fieldset>
            <legend>Edit or add material</legend>
            <div>
                
                <div class="col-lg-5">

                    <div class="row">
                        <div class="form-group col-xs-12">
                            <div class="input-group">
                                <span class="input-group-addon">Category
                                </span>
                                <asp:TextBox ID="txtCategory" runat="server" Text="" CssClass="form-controlWebSer" placeholder="Enter Category Name..."></asp:TextBox>
                            </div>
                        </div>
                        <div style="visibility: hidden; display: none">
                            <asp:TextBox ID="txtCategoryID" runat="server" Text=""></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group col-xs-12">
                            <div class="input-group">
                                <span class="input-group-addon">Posted By
                           
                                </span>
                                <asp:TextBox ID="txtAdgiver" runat="server" Text="" CssClass="form-controlWebSer" placeholder="Enter ad giver name..."></asp:TextBox>
                            </div>
                        </div>
                        <div style="visibility: hidden; display: none">
                            <asp:TextBox ID="txtAdGiverID" runat="server" Text=""></asp:TextBox>
                        </div>
                    </div>

                    <div class="row">
                        <div class="form-group col-xs-12">
                            <div class="input-group">
                                <span class="input-group-addon">Material Code
                                </span>
                                <asp:TextBox ID="txtMaterialCode" runat="server" Text="" CssClass="form-controlWebSer" placeholder="Enter material code..."></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="form-group col-xs-12">
                            <div class="input-group">
                                <span class="input-group-addon">From Date
                                </span>
                                <ajaxConTK:CalendarExtender ID="extDate2" runat="server" Enabled="True" TargetControlID="txtFromDate" Format="dd/MM/yyyy"></ajaxConTK:CalendarExtender>
                                <asp:TextBox ID="txtFromDate" runat="server" Text="" class="form-controlWebSer" placeholder="Select from date..."></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group col-xs-12">
                            <div class="input-group">
                                <span class="input-group-addon">To Date
                                </span>
                                <ajaxConTK:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" TargetControlID="txtToDate" Format="dd/MM/yyyy"></ajaxConTK:CalendarExtender>
                                <asp:TextBox ID="txtToDate" runat="server" Text="" class="form-controlWebSer" placeholder="Select to date..."></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                
                
                <div class="col-lg-7">

                    <div class="clearfix">
                    </div>
                    <div class="row">
                        <div class="col-xs-4 ">

                           

                                <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" CssClass="btn btn-primary"
                                    ValidationGroup="cValidationGroup"></asp:Button>

           
                        </div>
                    </div>
                    <br/>
                    <div class="row ">
                        <div class="col-xs-4 ">
                                 <asp:Button ID="btnCancel" runat="server" Text="Clear field" OnClick="btnClear_Click"
                                    CssClass="btn btn-primary" />
                   
                        </div>
                    </div>

                </div>
            </div>




        </fieldset>
        <div class="clearfix">
        </div>
        <br />

        <fieldset>
            <legend>Material Lists</legend>

            <asp:ListView ID="lvMaterial" runat="server" DataKeyNames="IID"
                OnItemCommand="lvMaterial_ItemCommand" OnPreRender="dataPagerMaterial_PreRender">
                <LayoutTemplate>
                    <table class="table table-bordered table-hover" style="margin-bottom: 0px;">
                        <tr runat="server">
                            <th class="col-xs-1" style="text-align: center">SL #
                            </th>
                            <th class="col-xs-2" style="text-align: center">Title Name
                            </th>
                            <th class="col-xs-1" style="text-align: center">Code
                            </th>
                            <th class="col-xs-2" style="text-align: center">Category
                            </th>
                            <th class="col-xs-2" style="text-align: center">Posted By
                            </th>
                            <th class="col-xs-1" style="text-align: center">Post Date
                            </th>
                            <th class="col-xs-1" style="text-align: center">Expiration date
                            </th>
                            <th class="col-xs-1" style="text-align: center">Status
                            </th>

                        </tr>
                        <tbody id="itemPlaceholder" runat="server">
                        </tbody>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr runat="server">
                        <td style="text-align: center">
                            <%# Container.DataItemIndex + 1%>
                        </td>
                        <td style="text-align: left">
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("TitleName") %>'></asp:Label>
                        </td>
                        <td style="text-align: left">

                            <asp:LinkButton ID="lnkBtnName" runat="server" CausesValidation="false" Text='<%#Bind("Code")%>'
                                CommandArgument='<%# Bind("IID") %>' CommandName="EditMaterial"></asp:LinkButton>
                        </td>
                        <td style="text-align: left">
                            <asp:Label ID="lblCatergory" runat="server" Text='<%# Bind("CategoryName") %>'></asp:Label>
                        </td>

                        <td style="text-align: left">
                            <asp:Label ID="lblCode" runat="server" Text='<%# Bind("AdGiverName") %>'></asp:Label>
                        </td>
                        <td style="text-align: center">
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("AdDate") %>'></asp:Label>
                        </td>
                        <td style="text-align: center">
                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("AdDisplayLastDate") %>'></asp:Label>
                        </td>
                        <td style="text-align: center">
                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("IsExpired") %>'></asp:Label>
                        </td>
                    </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>

                    <tr class="bg-info" runat="server">
                        <td style="text-align: center">
                            <%# Container.DataItemIndex + 1%>
                        </td>
                        <td style="text-align: left">
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("TitleName") %>'></asp:Label>
                        </td>
                        <td style="text-align: left">

                            <asp:LinkButton ID="lnkBtnName" runat="server" CausesValidation="false" Text='<%#Bind("Code")%>'
                                CommandArgument='<%# Bind("IID") %>' CommandName="EditMaterial"></asp:LinkButton>
                        </td>
                        <td style="text-align: left">
                            <asp:Label ID="lblCatergory" runat="server" Text='<%# Bind("CategoryName") %>'></asp:Label>
                        </td>

                        <td style="text-align: left">
                            <asp:Label ID="lblCode" runat="server" Text='<%# Bind("AdGiverName") %>'></asp:Label>
                        </td>
                        <td style="text-align: center">
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("AdDate") %>'></asp:Label>
                        </td>
                        <td style="text-align: center">
                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("AdDisplayLastDate") %>'></asp:Label>
                        </td>
                        <td style="text-align: center">
                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("IsExpired") %>'></asp:Label>
                        </td>
                    </tr>
                </AlternatingItemTemplate>
                <EmptyDataTemplate>

                    <tr>
                        <td>Information is empty ...
                        </td>
                    </tr>
                    </table>
                </EmptyDataTemplate>
            </asp:ListView>
          
        </fieldset>
        <br/>
        
        <fieldset>
            <legend>Archive</legend>

            <asp:ListView ID="lvMaterialArc" runat="server" DataKeyNames="IID"
                OnItemCommand="lvMaterialLog_ItemCommand"  OnPreRender="dataPagerMaterial_PreRender">
                <LayoutTemplate>
                    <table class="table table-bordered table-hover" style="margin-bottom: 0px;">
                        <tr runat="server">
                            <th class="col-xs-1" style="text-align: center">SL #
                            </th>
                            <th class="col-xs-2" style="text-align: center">Title Name
                            </th>
                            <th class="col-xs-1" style="text-align: center">Code
                            </th>
                            <th class="col-xs-2" style="text-align: center">Category
                            </th>
                            <th class="col-xs-2" style="text-align: center">Posted By
                            </th>
                            <th class="col-xs-1" style="text-align: center">Post Date
                            </th>
                            <th class="col-xs-1" style="text-align: center">Expiration date
                            </th>
                            <th class="col-xs-1" style="text-align: center">Status
                            </th>

                        </tr>
                        <tbody id="itemPlaceholder" runat="server">
                        </tbody>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr runat="server">
                        <td style="text-align: center">
                            <%# Container.DataItemIndex + 1%>
                        </td>
                        <td style="text-align: left">
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("TitleName") %>'></asp:Label>
                        </td>
                        <td style="text-align: left">

                            <asp:LinkButton ID="lnkBtnName" runat="server" CausesValidation="false" Text='<%#Bind("Code")%>'
                                CommandArgument='<%# Bind("IID") %>' CommandName="EditMaterial"></asp:LinkButton>
                        </td>
                        <td style="text-align: left">
                            <asp:Label ID="lblCatergory" runat="server" Text='<%# Bind("CategoryName") %>'></asp:Label>
                        </td>

                        <td style="text-align: left">
                            <asp:Label ID="lblCode" runat="server" Text='<%# Bind("AdGiverName") %>'></asp:Label>
                        </td>
                        <td style="text-align: center">
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("AdDate") %>'></asp:Label>
                        </td>
                        <td style="text-align: center">
                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("AdDisplayLastDate") %>'></asp:Label>
                        </td>
                        <td style="text-align: center">
                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("IsExpired") %>'></asp:Label>
                        </td>
                    </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>

                    <tr class="bg-info" runat="server">
                        <td style="text-align: center">
                            <%# Container.DataItemIndex + 1%>
                        </td>
                        <td style="text-align: left">
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("TitleName") %>'></asp:Label>
                        </td>
                        <td style="text-align: left">

                            <asp:LinkButton ID="lnkBtnName" runat="server" CausesValidation="false" Text='<%#Bind("Code")%>'
                                CommandArgument='<%# Bind("IID") %>' CommandName="EditMaterial"></asp:LinkButton>
                        </td>
                        <td style="text-align: left">
                            <asp:Label ID="lblCatergory" runat="server" Text='<%# Bind("CategoryName") %>'></asp:Label>
                        </td>

                        <td style="text-align: left">
                            <asp:Label ID="lblCode" runat="server" Text='<%# Bind("AdGiverName") %>'></asp:Label>
                        </td>
                        <td style="text-align: center">
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("AdDate") %>'></asp:Label>
                        </td>
                        <td style="text-align: center">
                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("AdDisplayLastDate") %>'></asp:Label>
                        </td>
                        <td style="text-align: center">
                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("IsExpired") %>'></asp:Label>
                        </td>
                    </tr>
                </AlternatingItemTemplate>
                <EmptyDataTemplate>

                    <tr>
                        <td>Information is empty ...
                        </td>
                    </tr>
                    </table>
                </EmptyDataTemplate>
            </asp:ListView>
           
        </fieldset>
    </div>
    <br />
</asp:Content>

