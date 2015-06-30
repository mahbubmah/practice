<%@ Page Title="" Language="C#" MasterPageFile="~/ControlAdmin/ControlAdminMaster.Master" AutoEventWireup="true" CodeBehind="MappingCategoryWF.aspx.cs" Inherits="OH.Web.ControlAdmin.MappingCategoryWF" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headAdmin" runat="server">

    <script type="text/javascript">
        $(function () {

            function logParentID(memberID) {
                $("#<%= txtParentID.ClientID%>").val(memberID);
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
                $("#<%=txtCategoryID.ClientID %>").autocomplete({
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
                                givenText = $("#<%=txtCategoryID.ClientID %>").val();
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
                                    $("#<%=txtCategoryID.ClientID %>").val(givenText.toUpperCase());
                                }
                                else {
                                    $("#<%=txtCategoryID.ClientID %>").val(autoCompleteText.toUpperCase());
                                }

                                autoCompleteText = "";

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
        <div class="row">
            <h3>Category Mapping Table     </h3>
        </div>
        <div class="row">
            <asp:Label ID="labelMessage" runat="server" Text=""></asp:Label>
        </div>
        <fieldset>
            <legend>Category Wise New Mapping</legend>

            <div class="row">
                <div class="form-group col-xs-6">
                    <div class="input-group">
                        <span class="input-group-addon">Category Name
                        </span>
                        <asp:TextBox ID="txtCategoryID" runat="server" Text="" CssClass="form-control" placeholder="Enter Category Name..."></asp:TextBox>
                    </div>
                </div>
                <div style="visibility: hidden">
                    <asp:TextBox ID="txtParentID" runat="server" Text=""></asp:TextBox>
                    <asp:HiddenField runat="server" ID="hdParentID" />
                </div>
            </div>
            <%--model table--%>
            <fieldset>
                <legend>Mapping Table Information</legend>


                <div class="row">
                    <div class="form-group col-xs-6">
                        <%--<div class="input-group">--%>
                            <asp:ListView ID="lvMappingCategory" runat="server" align="left" DataKeyNames="IID">
                                <LayoutTemplate>
                                    <table class="table table-bordered table-hover" style="margin-bottom: 0px;">
                                        <tr runat="server">
                                            <th class="col-xs-1" style="text-align: center">
                                                <asp:CheckBox ID="chkModelAll" runat="server" TextAlign="Right" AutoPostBack="true" OnCheckedChanged="chkModelAll_CheckedChanged"></asp:CheckBox>
                                            </th>
                                            <th class="col-xs-3">Name
                                            </th>
                                            <th class="col-xs-3">Description
                                            </th>
                                        </tr>
                                        <tbody id="itemPlaceholder" runat="server">
                                        </tbody>
                                    </table>
                                </LayoutTemplate>
                                <ItemTemplate>
                                    <tr runat="server">
                                        <td style="text-align: center">
                                            <asp:Label ID="lblMappingTableIID" runat="server" Text='<%# Bind("IID") %>' Visible="false"></asp:Label>
                                            <asp:CheckBox ID="chkModel" runat="server"></asp:CheckBox>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblName" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblDescription" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <AlternatingItemTemplate>
                                    <tr class="bg-info" runat="server">

                                        <td style="text-align: center">
                                            <asp:Label ID="lblMappingTableIID" runat="server" Text='<%# Bind("IID") %>' Visible="false"></asp:Label>
                                            <asp:CheckBox ID="chkModel" runat="server"></asp:CheckBox>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblName" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblDescription" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                                        </td>

                                    </tr>
                                </AlternatingItemTemplate>
                                <EmptyDataTemplate>

                                    <tr>
                                        <td>Information is empty ...
                                        </td>
                                    </tr>

                                </EmptyDataTemplate>

                            </asp:ListView>
                            <%--<br />

                        </div>--%>
                    </div>
                </div>

            </fieldset>
            <%-- modeltable--%>
            <div class="clearfix">
            </div>
            <div class="row">
                <div class="col-xs-6 ">

                    <div class="input-group pull-right">
                        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" CssClass="btn btn-primary"
                            ValidationGroup="cValidationGroup"></asp:Button>
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click"
                            CssClass="btn btn-primary" ValidationGroup="cValidationGroup" />
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click"
                            CssClass="btn btn-primary" />
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click"
                            CssClass="btn btn-primary" />
                        <asp:HiddenField runat="server" ID="hdMappingCategoryID" />
                        <asp:HiddenField runat="server" ID="hdIsEdit" />
                        <asp:HiddenField runat="server" ID="hdIsDelete" />
                        <asp:ValidationSummary
                            ShowMessageBox="true"
                            ShowSummary="false"
                            HeaderText="You must enter a value in the following fields:"
                            EnableClientScript="true"
                            runat="server" ValidationGroup="cValidationGroup" />
                    </div>
                </div>
            </div>
        </fieldset>
        <div class="clearfix">
        </div>
        <br />
        <fieldset>
           <legend>Category Wise Mapping SetUp Lists</legend>

            <asp:ListView ID="lvMapCategoryList" runat="server" DataKeyNames="IID"   OnItemCommand="lvMapCategoryList_ItemCommand"
             Style="text-align: center; font-family: Arial, Helvetica, sans-serif; font-size: xx-small"
                OnPagePropertiesChanging="lvMapCategoryList_PagePropertiesChanging" OnPreRender="dataPagerMapCategoryList_PreRender">
                <LayoutTemplate>
                    <table class="table table-bordered table-hover" style="margin-bottom: 0px;">

                        <tr runat="server">

                            <th class="col-xs-3">Category Name
                            </th>
                            <th class="col-xs-4">Name
                            </th>
                            <th class="col-xs-5">Description
                            </th>
                        </tr>
                        <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                <%# fGroupingRowIfNewCategory() %>
                        <tr runat="server">
                        <td>  </td>
                        <td>
                          <%--  <asp:Label ID="lblModel" runat="server" Text='<%# Bind("MappingTableName") %>'  ></asp:Label>--%>
                               <asp:LinkButton ID="lnkBtnName" runat="server" CausesValidation="false" Text='<%#Bind("MappingTableName")%>'
                               CommandArgument='<%# Bind("CategoryID") %>' CommandName="EditMappinCategoryList"></asp:LinkButton>
                        </td>
                        <td>
                            <asp:Label ID="lbl" runat="server" Text='<%# Bind("MappingTableDescription") %>'></asp:Label>
                        </td>
                    </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>
               <%# fGroupingRowIfNewCategory() %>
                    
                    <tr class="bg-info" runat="server">
                        <td></td>
                        <td>
                         <%-- <asp:Label ID="lblModel" runat="server" Text='<%# Bind("MappingTableName") %>'  ></asp:Label>--%>
                               <asp:LinkButton ID="lnkBtnName" runat="server" CausesValidation="false" Text='<%#Bind("MappingTableName")%>'
                                 CommandArgument='<%# Bind("CategoryID") %>' CommandName="EditMappinCategoryList"></asp:LinkButton>
                        </td>
                        <td>
                            <asp:Label ID="lbl" runat="server" Text='<%# Bind("MappingTableDescription") %>'></asp:Label>
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
            <asp:DataPager ID="dataPagerMapCategoryList" runat="server" PagedControlID="lvMapCategoryList"
                PageSize="10" OnPreRender="dataPagerMapCategoryList_PreRender">
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
    <br />
</asp:Content>

