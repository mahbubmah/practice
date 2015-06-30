<%@ Page Title="" Language="C#" MasterPageFile="~/ControlAdmin/ControlAdminMaster.Master" AutoEventWireup="true" CodeBehind="AddGiverTracingWF.aspx.cs" Inherits="OH.Web.ControlAdmin.AddGiverTracingWF" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headAdmin" runat="server">
     <script type="text/javascript">
         $(function () {
             $.noConflict();
             function logAdGiverID(adGiverID) {
                 $("#<%= txtAdGiverID.ClientID%>").val(adGiverID);
            }

             AutoCompleteBindAdGiver();

            var prmInstance = Sys.WebForms.PageRequestManager.getInstance();
            prmInstance.add_endRequest(function () {
                AutoCompleteBindAdGiver();
            });

            function AutoCompleteBindAdGiver() {
                //New For AutoComplete Selection
                var autoCompleteText = "";
                var currentText = "";
                var finalText = "";
                var givenText = "";
                var rowCount = 0;
                //End Section              
                $("#<%=txtAdGiverName.ClientID %>").autocomplete({
                    source: function (request, response) {
                        var data_item = "{AdgiverName:'" + request.term + "'}";
                        $.ajax({
                            type: "POST",
                            url: "../HRWebService.asmx/GetAdGiverForSearch",
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
                                givenText = $("#<%=txtAdGiverName.ClientID %>").val();
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
                                    $("#<%=txtAdGiverName.ClientID %>").val(givenText.toUpperCase());
                                }
                                else {
                                    $("#<%=txtAdGiverName.ClientID %>").val(autoCompleteText.toUpperCase());
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
       <%-- ////////////////////// Material Name/////////////////////////////////////////////--%>
         <script type="text/javascript">
         $(function () {
            

             function logMaterialID(MaterialID) {
                 $("#<%= txtMaterialID.ClientID%>").val(MaterialID);
             }

             AutoCompleteBindMaterial();

             var prmInstance = Sys.WebForms.PageRequestManager.getInstance();
             prmInstance.add_endRequest(function () {
                 AutoCompleteBindMaterial();
             });

             function AutoCompleteBindMaterial() {
                 //New For AutoComplete Selection
                 var autoCompleteText = "";
                 var currentText = "";
                 var finalText = "";
                 var givenText = "";
                 var rowCount = 0;
                 //End Section                      
                 $("#<%=txtMaterial.ClientID %>").autocomplete({
                    source: function (request, response) {
                        var data_item = "{materialName:'" + request.term + "'}";
                        $.ajax({
                            type: "POST",
                            url: "../HRWebService.asmx/GetMaterialByAlphabetForSearch",
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
                                givenText = $("#<%=txtMaterial.ClientID %>").val();
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
                                    $("#<%=txtMaterial.ClientID %>").val(givenText.toUpperCase());
                                }
                                else {
                                    $("#<%=txtMaterial.ClientID %>").val(autoCompleteText.toUpperCase());
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
                        logMaterialID(ui.item ? ui.item.IID : "");
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentAdminMain" runat="server">
     <div class="container adminPagewrp">
    <div class="row">
        <h2>
            Add Giver Tracing 
        </h2>
    </div>
        <div>
        <asp:Label ID="labelMessageAddGiverTracing" runat="server" Text="..."></asp:Label>
             <asp:Label ID="labelMessgRead" runat="server" Text=""></asp:Label>
    </div>
         <div>
        <fieldset>
               <legend>Insert New Add Giver Tracing</legend>
             <div class="row" >
                  
                <div class="form-group col-xs-5">
                    <div class="input-group">
                        <span class="input-group-addon">Add Giver 
                            <asp:RequiredFieldValidator ID="rfvAdGiver" runat="server"
                                ControlToValidate="txtAdGiverName" ForeColor="Red"
                                ToolTip="*" Display="Dynamic" ValidationGroup="AdGiverValidationGroup"
                                ErrorMessage="Enter Add Giver....">*</asp:RequiredFieldValidator>
                        </span>
                        <asp:TextBox ID="txtAdGiverName" runat="server" Text=""  class="form-controlWebSer" placeholder="Search Ad Giver..."></asp:TextBox>
                    </div>   
                </div>   
                  <%--<div class="col-xs-6" >--%>
                     <div class="col-xs-2" style="">
                          <asp:Button ID="btnShowAddGiver" runat="server" Text="Show Add Giver List"  CssClass="btn btn-primary" OnClick="btnShowAddGiver_Click" />
                         </div>
                       <%--</div>--%>
                    <div style="visibility:hidden">
                         <asp:TextBox ID="txtAdGiverID" runat="server" Text=""></asp:TextBox>
                    </div>
                 
            </div>
             <div class="row" >
                <div class="form-group col-xs-5">
                    <div class="input-group">
                        <span class="input-group-addon">Material 
                            <asp:RequiredFieldValidator ID="rfvMaterial" runat="server"
                                ControlToValidate="txtMaterial" ForeColor="Red"
                                ToolTip="*" Display="Dynamic" ValidationGroup="AdGiverValidationGroup"
                                ErrorMessage="Enter Material...">*</asp:RequiredFieldValidator>
                        </span>
                        <asp:TextBox ID="txtMaterial" runat="server" Text=""  class="form-controlWebSer" placeholder="Search Material..."></asp:TextBox>
                    </div>
                </div>
                    <div style="visibility:hidden">
                         <asp:TextBox ID="txtMaterialID" runat="server" Text=""></asp:TextBox>
                    </div>
            </div>

             <div class="row">
                <div class="form-group col-xs-5">
                    <div class="input-group">
                        <span class="input-group-addon">IP Address
                            <asp:RequiredFieldValidator ID="rfvIPAddress" runat="server"
                                ControlToValidate="txtIPAddress" ForeColor="Red"
                                ToolTip="*" Display="Dynamic">*</asp:RequiredFieldValidator>
                        </span>
                        <asp:TextBox ID="txtIPAddress" runat="server" Text="" ValidationGroup="AdGiverValidationGroup" class="form-controlWebSer" placeholder="Enter IP Address..." ReadOnly="True"></asp:TextBox>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="form-group col-xs-5">
                    <div class="input-group">
                        <span class="input-group-addon">MAC Address
                            <asp:RequiredFieldValidator ID="rfvMACAddress" runat="server"
                                ControlToValidate="txtMACAddress" ForeColor="Red"
                                ToolTip="*" Display="Dynamic">*</asp:RequiredFieldValidator>
                        </span>
                        <asp:TextBox ID="txtMACAddress" runat="server" Text="" ValidationGroup="AdGiverValidationGroup" class="form-controlWebSer" placeholder="Enter MAC Address..." ReadOnly="True"></asp:TextBox>
                    </div>
                </div>
            </div>

             <div class="row">
                <div class="form-group col-xs-5">
                    <div class="input-group">
                        <span class="input-group-addon">Browser Name ID
                            <asp:RequiredFieldValidator ID="rfvBrowserNameID" runat="server"
                                ControlToValidate="txtBrowserNameID" ForeColor="Red"
                                ToolTip="*" Display="Dynamic">*</asp:RequiredFieldValidator>
                        </span>
                        <asp:TextBox ID="txtBrowserNameID" runat="server" Text="" ValidationGroup="AdGiverValidationGroup" class="form-controlWebSer" placeholder="Enter BrowserNameID..." ReadOnly="True"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div style="display:none">
            <asp:DropDownList ID="DropDownBrowser" runat="server"></asp:DropDownList>
            <asp:TextBox ID="txtBrowserID" runat="server"></asp:TextBox>
                </div>
             <div class="row">
                <div class="form-group col-xs-5">
                    <div class="input-group">
                        <span class="input-group-addon">Browsing Time
                            <asp:RequiredFieldValidator ID="rfvBrowsingTime" runat="server"
                                ControlToValidate="txtBrowsingTime" ForeColor="Red"
                                ToolTip="*" Display="Dynamic">*</asp:RequiredFieldValidator>
                        </span>
                        <asp:TextBox ID="txtBrowsingTime" runat="server" Text="" ValidationGroup="AdGiverValidationGroup" class="form-controlWebSer" placeholder="Enter Browsing Time..." ReadOnly="True"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-5">
                    <div class="input-group pull-right">
                        <%--<asp:Button ID="btnShowAddGiver" runat="server" Text="Show Add Giver List" ValidationGroup="AdGiverValidationGroup" CssClass="btn btn-primary" OnClick="btnShowAddGiver_Click" />--%>
                            <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="AdGiverValidationGroup"  CssClass="btn btn-primary" OnClick="btnSave_Click" ></asp:Button>
                          <asp:HiddenField runat="server" ID="hdAdGiverID" />
                        <asp:HiddenField runat="server" ID="hdIsEdit" />
                        <asp:HiddenField runat="server" ID="hdIsDelete" />

                         <asp:ValidationSummary
                                ShowMessageBox="true"
                                ShowSummary="false"
                                HeaderText="You must enter a value in the following fields:"
                                EnableClientScript="true"
                                runat="server" ValidationGroup="AdGiverValidationGroup" />
                    </div>
                    </div>
                </div>
             <%--<div class="col-xs-3">
                        </div>--%>
        </fieldset>
              </div>
         

</div>
</asp:Content>
