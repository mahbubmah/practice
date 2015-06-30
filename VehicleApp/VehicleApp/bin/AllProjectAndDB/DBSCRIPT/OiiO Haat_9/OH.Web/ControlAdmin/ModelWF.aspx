<%@ Page Title="" Language="C#" MasterPageFile="~/ControlAdmin/ControlAdminMaster.Master" AutoEventWireup="true" CodeBehind="ModelWF.aspx.cs" Inherits="OH.Web.ControlAdmin.ModelWF" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headAdmin" runat="server">

    <script type="text/javascript">
        $(function () {
            $.noConflict();
            debugger;
            function logBrandID(brandID) {
                $("#<%= txtBrandID.ClientID%>").val(brandID);
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
                $("#<%=txtBrandName.ClientID %>").autocomplete({
                    source: function (request, response) {
                        var data_item = "{brandName:'" + request.term + "'}";
                        $.ajax({
                            type: "POST",
                            url: "../HRWebService.asmx/GetAllBrandNameForSearch",
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
                                givenText = $("#<%=txtBrandName.ClientID %>").val();
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
                                $("#<%=txtBrandName.ClientID %>").val(givenText.toUpperCase());
                            }
                            else {
                                $("#<%=txtBrandName.ClientID %>").val(autoCompleteText.toUpperCase());
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

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentAdminMain" runat="server">
    <div class="container adminPagewrp">
        <div class="row">
            <div class="col-md-12">
                <h2>Model Info
                </h2>
            </div>
        </div>
        <div>
            <asp:Label ID="labelMessage" runat="server" Text="..."></asp:Label>
        </div>
        <div class="row">
            <fieldset class="adminFieldset">
                <legend>Add New Model</legend>

                <div class="form-group">
                    <div class="input-group">
                        <span class="input-group-addon">Brand Name
                            <asp:RequiredFieldValidator ID="rfvBrand" runat="server"
                                ControlToValidate="txtBrandName" ForeColor="Red"
                                ToolTip="*" Display="Dynamic" ValidationGroup="modelValidationGroup">*</asp:RequiredFieldValidator>
                        </span>
                        <asp:TextBox ID="txtBrandName" runat="server" Text="" class="form-control" placeholder="Search Brand Name..."></asp:TextBox>
                    </div>
                </div>
                <div style="display:none" >
                <asp:TextBox ID="txtBrandID"  runat="server" Text=""></asp:TextBox>
                    </div>


                <div class="form-group">
                    <div class="input-group">
                        <span class="input-group-addon">Model Info
                            <asp:RequiredFieldValidator ID="rfvModel" runat="server"
                                ControlToValidate="txtModelName" ForeColor="Red"
                                ToolTip="*" Display="Dynamic" ValidationGroup="modelValidationGroup">*</asp:RequiredFieldValidator>
                        </span>
                        <asp:TextBox ID="txtModelName" runat="server" Text="" class="form-control" placeholder=" Enter Model..."></asp:TextBox>
                    </div>
                </div>




                <div class="clearfix">
                </div>
                <div class="form-group">
                    <div class="col-xs-5">
                        <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="modelValidationGroup" OnClick="btnSave_Click" CssClass="btn btn-primary pull-right"></asp:Button>
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" ValidationGroup="modelValidationGroup" OnClick="btnUpdate_Click"
                            CssClass="btn btn-primary" />
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click"
                            CssClass="btn btn-primary" />
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click"
                            CssClass="btn btn-primary" />
                        <asp:HiddenField runat="server" ID="hdModelID" />
                        <asp:HiddenField runat="server" ID="hdIsEdit" />
                        <asp:HiddenField runat="server" ID="hdIsDelete" />

                        <asp:ValidationSummary
                            ShowMessageBox="true"
                            ShowSummary="false"
                            HeaderText="You must enter a value in the following fields:"
                            EnableClientScript="true"
                            runat="server" ValidationGroup="modelValidationGroup" />

                    </div>


                </div>

            </fieldset>
        </div>

        <div class="row">

            <fieldset class="adminFieldset">
                <legend>Model Information</legend>

                <asp:ListView ID="lvModel" runat="server" DataKeyNames="IID"
                    OnItemCommand="lvModel_ItemCommand" OnPagePropertiesChanging="lvModel_PagePropertiesChanging"
                    OnPreRender="dataPagerModel_PreRender">
                    <LayoutTemplate>
                        <table class="table table-bordered table-hover" style="margin-bottom: 0px;">
                            <thead>
                                <tr runat="server">
                                    <th class="col-xs-1">SL #
                                    </th>
                                    <th class="col-xs-2">Model Name
                                    </th>
                                    <th class="col-xs-1">Brand 
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
                                <asp:Label ID="lblModelID" runat="server" Text='<%# Bind("IID") %>' Visible="false"></asp:Label>
                                <asp:LinkButton ID="lnkBtnName" runat="server" CausesValidation="false" Text='<%#Bind("Name")%>'
                                    CommandArgument='<%# Bind("IID") %>' CommandName="EditModel"></asp:LinkButton>
                            </td>
                            <td>
                                <asp:Label ID="lblBandName" runat="server" Text='<%# Bind("BrandName") %>'></asp:Label>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <tr class="bg-info" runat="server">
                            <td style="text-align: center">
                                <%# Container.DataItemIndex + 1%>
                            </td>
                            <td style="text-align: left">
                                <asp:Label ID="lblModelID" runat="server" Text='<%# Bind("IID") %>' Visible="false"></asp:Label>
                                <asp:LinkButton ID="lnkBtnName" runat="server" CausesValidation="false" Text='<%#Bind("Name")%>'
                                    CommandArgument='<%# Bind("IID") %>' CommandName="EditModel"></asp:LinkButton>
                            </td>
                            <td>
                                <asp:Label ID="lblBandName" runat="server" Text='<%# Bind("BrandName") %>'></asp:Label>
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
                <asp:DataPager ID="dataPagerModel" runat="server" PagedControlID="lvModel"
                    PageSize="10" OnPreRender="dataPagerModel_PreRender">
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
