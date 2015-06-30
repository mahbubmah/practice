<%@ Page Title="" Language="C#" MasterPageFile="~/ControlAdmin/ControlAdminMaster.Master" AutoEventWireup="true" CodeBehind="BrandWF.aspx.cs" Inherits="OH.Web.ControlAdmin.BrandWF" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxConTK" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headAdmin" runat="server">

<script type="text/javascript">
    $(function () {
        $.noConflict();

        function logOriginID(countryID) {
            $("#<%= txtOriginID.ClientID%>").val(countryID);
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
                $("#<%=txtOriginName.ClientID %>").autocomplete({
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
                                givenText = $("#<%=txtOriginName.ClientID %>").val();
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
                                    $("#<%=txtOriginName.ClientID %>").val(givenText.toUpperCase());
                                }
                                else {
                                    $("#<%=txtOriginName.ClientID %>").val(autoCompleteText.toUpperCase());
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
                        logOriginID(ui.item ? ui.item.IID : "");
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

    ///////Display Calender Only For Year

    function onCalendarShown() {
        var cal = $find("cale_ClearedYr");
        //Setting the default mode to year
        cal._switchMode("years", true);
        //Iterate every year Item and attach click event to it
        if (cal._yearsBody) {
            for (var i = 0; i < cal._yearsBody.rows.length; i++) {
                var row = cal._yearsBody.rows[i];
                for (var j = 0; j < row.cells.length; j++) {
                    Sys.UI.DomEvent.addHandler(row.cells[j].firstChild, "click", call);
                }
            }
        }
    }

    function onCalendarHidden() {
        var cal = $find("cale_ClearedYr");
        //Iterate every month Item and remove click event from it
        if (cal._yearsBody) {
            for (var i = 0; i < cal._yearsBody.rows.length; i++) {
                var row = cal._yearsBody.rows[i];
                for (var j = 0; j < row.cells.length; j++) {
                    Sys.UI.DomEvent.removeHandler(row.cells[j].firstChild, "click", call);
                }
            }
        }
    }

    function call(eventElement) {
        var target = eventElement.target;
        switch (target.mode) {
            case "year":
                var cal = $find("cale_ClearedYr");
                cal._visibleDate = target.date;
                cal.set_selectedDate(target.date);
                cal._switchMonth(target.date);
                cal._blur.post(true);
                cal.raiseDateSelectionChanged();
                break;
        }
    }

    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentAdminMain" runat="server">

    <div class="container adminPagewrp">
        <div class="row">
            <div class="col=ms-12">
            <h2>Brand Info
            </h2>
                </div>
        </div>
   
        <asp:Label ID="labelMessage" runat="server" Text="..."></asp:Label>
    
   
        <div class="row">
        <fieldset class="adminFieldset">
            <legend>Add New Brand</legend>
           
                <div class="form-group">
                    <div class="input-group">
                        <span class="input-group-addon">Brand Name
                            <asp:RequiredFieldValidator ID="rfvBrand" runat="server"
                                ControlToValidate="txtBrandName" ForeColor="Red"
                                ToolTip="*" Display="Dynamic" ValidationGroup="brandValidationGroup">*</asp:RequiredFieldValidator>
                        </span>
                        <asp:TextBox ID="txtBrandName" runat="server" Text=""  class="form-control" placeholder="Enter Name..."></asp:TextBox>
                    </div>
                </div>
          
                <div class="form-group">
                    <div class="input-group">
                        <span class="input-group-addon">Origin
                            <asp:RequiredFieldValidator ID="rfvOrigin" runat="server"
                                ControlToValidate="txtOriginName" ForeColor="Red"
                                ToolTip="*" Display="Dynamic" ValidationGroup="brandValidationGroup">*</asp:RequiredFieldValidator>
                        </span>
                        <asp:TextBox ID="txtOriginName" runat="server" Text=""  class="form-controlWebSer" placeholder="Search Origin..."></asp:TextBox>
                    </div>
                </div>
               <div style="display: none; visibility: hidden">
                      <asp:TextBox ID="txtOriginID"  runat="server" Text=""></asp:TextBox>
               </div>
                <div class="form-group">
                    <div class="input-group">
                        <span class="input-group-addon">Establish Year
                            <asp:RequiredFieldValidator ID="rfvEstYear" runat="server"
                                ControlToValidate="txtEstablishYear" ForeColor="Red"
                                ToolTip="*" Display="Dynamic" ValidationGroup="brandValidationGroup">*</asp:RequiredFieldValidator>
                        </span>
                        <ajaxConTK:CalendarExtender ID="cale_ClearedYr" runat="server"
                            OnClientHidden="onCalendarHidden"
                            OnClientShown="onCalendarShown"
                            BehaviorID="cale_ClearedYr"
                            Enabled="True"
                            popupbuttonid="btn_ClearedYr"
                            TargetControlID="txtEstablishYear"
                            Format="yyyy">
                        </ajaxConTK:CalendarExtender>
                        <asp:TextBox ID="txtEstablishYear" runat="server" Text="" class="form-controlWebSer" placeholder="Select date..."></asp:TextBox>
                    </div>
                </div>
           


            <div class="clearfix">
            </div>
                  <div class="form-group">
                    <div class="col-xs-5">
                  

                        <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="brandValidationGroup" OnClick="btnSave_Click" CssClass="btn btn-primary pull-right"></asp:Button>
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" ValidationGroup="brandValidationGroup" OnClick="btnUpdate_Click"
                            CssClass="btn btn-primary" />
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click"
                            CssClass="btn btn-primary" />
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click"
                            CssClass="btn btn-primary" />
                        <asp:HiddenField runat="server" ID="hdBrandID" />
                        <asp:HiddenField runat="server" ID="hdIsEdit" />
                        <asp:HiddenField runat="server" ID="hdIsDelete" />

                        <asp:ValidationSummary
                            ShowMessageBox="true"
                            ShowSummary="false"
                            HeaderText="You must enter a value in the following fields:"
                            EnableClientScript="true"
                            runat="server" ValidationGroup="brandValidationGroup" />

                    </div>

                
            </div>

        </fieldset>
            </div>

        <div class="clearfix">
        </div>
        <div class="row">
        <fieldset class="adminFieldset">
            <legend>Brand Information</legend>

            <asp:ListView ID="lvBrand" runat="server" DataKeyNames="IID"
                OnItemCommand="lvBrand_ItemCommand" OnPagePropertiesChanging="lvBrand_PagePropertiesChanging"
                OnPreRender="dataPagerBrand_PreRender">
                <LayoutTemplate>
                    <table class="table table-bordered table-hover" style="margin-bottom: 0px;">
                        <thead>
                            <tr runat="server">
                                <th class="col-xs-1">SL #
                                </th>
                                <th class="col-xs-2">Brand Name
                                </th>
                                <th class="col-xs-1">Origin Name 
                                </th>
                                <th class="col-xs-1">EstablishYear 
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
                            <asp:Label ID="lblBrandID" runat="server" Text='<%# Bind("IID") %>' Visible="false"></asp:Label>
                            <asp:LinkButton ID="lnkBtnName" runat="server" CausesValidation="false" Text='<%#Bind("Name")%>'
                                CommandArgument='<%# Bind("IID") %>' CommandName="EditBrand"></asp:LinkButton>
                        </td>
                        <td>
                            <asp:Label ID="lblOrigin" runat="server" Text='<%# Bind("Origin") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblEstablishYear" runat="server" Text='<%# Bind("Year") %>'></asp:Label>
                        </td>
                    </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <tr class="bg-info" runat="server">
                        <td style="text-align: center">
                            <%# Container.DataItemIndex + 1%>
                        </td>
                        <td style="text-align: left">
                            <asp:Label ID="lblBrandID" runat="server" Text='<%# Bind("IID") %>' Visible="false"></asp:Label>
                            <asp:LinkButton ID="lnkBtnName" runat="server" CausesValidation="false" Text='<%#Bind("Name")%>'
                                CommandArgument='<%# Bind("IID") %>' CommandName="EditBrand"></asp:LinkButton>
                        </td>
                        <td>
                            <asp:Label ID="lblOrigin" runat="server" Text='<%# Bind("Origin") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblEstablishYear" runat="server" Text='<%# Bind("Year") %>'></asp:Label>
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
            <asp:DataPager ID="dataPagerBrand" runat="server" PagedControlID="lvBrand"
                PageSize="10" OnPreRender="dataPagerBrand_PreRender">
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
</asp:Content>
