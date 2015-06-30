<%@ Page Title="" Language="C#" MasterPageFile="~/ControlAdmin/ControlAdminMaster.Master" AutoEventWireup="true" CodeBehind="DivisionOrStateWF.aspx.cs" Inherits="OH.Web.ControlAdmin.DivisionORStateWF" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headAdmin" runat="server">

    <script type="text/javascript">
        $(function () {
            $.noConflict();

            function logCountryID(countryID) {
                $("#<%= txtCountryID.ClientID%>").val(countryID);
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
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentAdminMain" runat="server">

    <div class="container adminPagewrp">
        <div class="row">
            <h2>Division Or State Info
            </h2>
        </div>
        <div class="row">
            <asp:Label ID="labelMessage" runat="server" Text="..."></asp:Label>
        </div>

        <div class="row">
            <fieldset class="adminFieldset">
                <legend>Add New Division Or State</legend>
                <div class="row">
                    <div class="form-group col-xs-4">
                        <div class="input-group">
                            <span class="input-group-addon">Division Or State Code
                            <asp:RequiredFieldValidator ID="rfvDivOrStateCode" runat="server"
                                ControlToValidate="txtCode" ForeColor="Red"
                                ToolTip="*" Display="Dynamic" ValidationGroup="dValidationGroup" ErrorMessage="Enter code...">*</asp:RequiredFieldValidator>
                            </span>
                            <asp:TextBox ID="txtCode" runat="server" Text="" class="form-control" placeholder="Enter code..."></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="form-group col-xs-4">
                        <div class="input-group">
                            <span class="input-group-addon">Division Or State Name

                            <asp:RequiredFieldValidator ID="rfvName" runat="server"
                                ControlToValidate="txtName" ForeColor="Red"
                                ToolTip="*" Display="Dynamic" ValidationGroup="dValidationGroup" ErrorMessage="Enter name...">*</asp:RequiredFieldValidator>
                            </span>

                            <asp:TextBox ID="txtName" runat="server" Text="" class="form-control" placeholder="Enter name..."></asp:TextBox>
                        </div>
                    </div>
                </div>


                <div class="row">
                    <div class="form-group col-xs-4">
                        <div class="input-group">
                            <span class="input-group-addon">Applicable Country

                            <asp:RequiredFieldValidator ID="rfvCountry" runat="server"
                                ControlToValidate="txtCountryName" ForeColor="Red"
                                ToolTip="*" Display="Dynamic" ValidationGroup="dValidationGroup" ErrorMessage="Search Country...">*</asp:RequiredFieldValidator>
                            </span>
                            <asp:TextBox ID="txtCountryName" runat="server" Text="" class="form-controlWebSer" placeholder="Search Country..."></asp:TextBox>
                        </div>
                    </div>
                    <div style="visibility: hidden">
                        <asp:TextBox ID="txtCountryID" runat="server" Text=""></asp:TextBox>
                        <%-- <asp:Button ID="btnCountry" runat="server" Text="" OnClick="btnCountry_Click" />--%>
                        <%-- <asp:HiddenField runat="server" ID="hdCountryID" />--%>
                    </div>
                </div>
                <div class="clearfix">
                    <asp:CheckBox ID="chkIsRemovedDivOrState" runat="server" Text=" &nbsp IsRemoved" />
                </div>

                <div class="clearfix">
                </div>
                <div class="row">
                    <div class="form-group">

                        <div class="col-xs-5">

                            <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="dValidationGroup" OnClick="btnSave_Click" CssClass="btn btn-primary pull-right"></asp:Button>
                            <asp:Button ID="btnUpdate" runat="server" Text="Update" ValidationGroup="dValidationGroup" OnClick="btnUpdate_Click"
                                CssClass="btn btn-primary pull-right" />
                            <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click"
                                CssClass="btn btn-primary pull-right" Visible="false"/>
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click"
                                CssClass="btn btn-primary pull-right" />
                            <asp:HiddenField runat="server" ID="hdDivisionOrStateID" />
                            <asp:HiddenField runat="server" ID="hdIsEdit" />
                            <asp:HiddenField runat="server" ID="hdIsDelete" />
                            <asp:ValidationSummary
                                ShowMessageBox="true"
                                ShowSummary="false"
                                HeaderText="You must enter a value in the following fields:"
                                EnableClientScript="true"
                                runat="server" ValidationGroup="dValidationGroup" />
                        </div>


                    </div>
                </div>
            </fieldset>

            <div class="clearfix">
            </div>
        </div>
        <br />
        <div class="row">
            <fieldset class="adminFieldset">
                <legend>Division or State Information</legend>

                <asp:ListView ID="lvDivisionOrState" runat="server" DataKeyNames="IID"
                    OnItemCommand="lvDivisionOrState_ItemCommand" OnPagePropertiesChanging="lvDivisionOrState_PagePropertiesChanging"
                    OnPreRender="dataPagerDivisionOrState_PreRender">
                    <LayoutTemplate>
                        <table class="table table-bordered table-hover" style="margin-bottom: 0px;">
                            <thead>
                                <tr runat="server">
                                    <th class="col-xs-1">SL #
                                    </th>
                                    <th class="col-xs-2">Name
                                    </th>
                                    <th class="col-xs-1">Code
                                    </th>
                                    <th class="col-xs-2">Applicable Country
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
                                <asp:Label ID="lblDivisionID" runat="server" Text='<%# Bind("IID") %>' Visible="false"></asp:Label>
                                <asp:LinkButton ID="lnkBtnName" runat="server" CausesValidation="false" Text='<%#Bind("Name")%>'
                                    CommandArgument='<%# Bind("IID") %>' CommandName="EditDivission"></asp:LinkButton>
                            </td>
                            <td>
                                <asp:Label ID="lblName" runat="server" Text='<%# Bind("Code") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblApplicableCountryID" runat="server" Text='<%# Bind("CountryName") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:CheckBox ID="chkIsRemovedDivOrState" runat="server" Checked='<%# Bind("IsRemoved") %>' Enabled="false"></asp:CheckBox>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <tr class="bg-info" runat="server">
                            <td style="text-align: center">
                                <%# Container.DataItemIndex + 1%>
                            </td>
                            <td style="text-align: left">
                                <asp:Label ID="lblDivisionID" runat="server" Text='<%# Bind("IID") %>' Visible="false"></asp:Label>
                                <asp:LinkButton ID="lnkBtnName" runat="server" CausesValidation="false" Text='<%#Bind("Name")%>'
                                    CommandArgument='<%# Bind("IID") %>' CommandName="EditDivission"></asp:LinkButton>
                            </td>
                            <td>
                                <asp:Label ID="lblName" runat="server" Text='<%# Bind("Code") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblApplicableCountryID" runat="server" Text='<%# Bind("CountryName") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:CheckBox ID="chkIsRemovedDivOrState" runat="server" Checked='<%# Bind("IsRemoved") %>' Enabled="false"></asp:CheckBox>
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
                <asp:DataPager ID="dataPagerDivisionOrState" runat="server" PagedControlID="lvDivisionOrState"
                    PageSize="10" OnPreRender="dataPagerDivisionOrState_PreRender">
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
