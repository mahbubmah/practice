<%@ Page Title="" Language="C#" MasterPageFile="~/ControlAdmin/ControlAdminMaster.Master" AutoEventWireup="true" CodeBehind="CategoryWF.aspx.cs" Inherits="OH.Web.ControlAdmin.CategoryWF" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headAdmin" runat="server">
    <script type="text/javascript">
        $(function () {
            $.noConflict();

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
                $("#<%=txtParentCategoryID.ClientID %>").autocomplete({
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
                                givenText = $("#<%=txtParentCategoryID.ClientID %>").val();
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
                                    $("#<%=txtParentCategoryID.ClientID %>").val(givenText.toUpperCase());
                                }
                                else {
                                    $("#<%=txtParentCategoryID.ClientID %>").val(autoCompleteText.toUpperCase());
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


        <div class="row" style="text-align: center">
              <div class="col-md-12">
            <h2>Category Information
            </h2>
                  </div>
        </div>

        <div class="row">
            <asp:Label ID="labelMessage" runat="server" Text=""></asp:Label>
        </div>


        <div class="row">
        <fieldset>
            <legend>Add New Category</legend>


            <div class="row">
                <div class="form-group col-xs-5">
                    <div class="input-group">
                        <span class="input-group-addon">Category

                            <asp:RequiredFieldValidator ID="rfvCategoryName" runat="server"
                                ControlToValidate="txtName" ForeColor="Red"
                                ToolTip="*" Display="Dynamic" ValidationGroup="cValidationGroup" ErrorMessage="Enter Category Name...">*</asp:RequiredFieldValidator>
                        </span>

                        <asp:TextBox ID="txtName" runat="server" Text="" CssClass="form-control" placeholder="Enter Category Name..."></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="form-group col-xs-5">
                    <div class="input-group">
                        <span class="input-group-addon">Serial No.
                            <asp:RequiredFieldValidator ID="rfvSerialNo" runat="server"
                                ControlToValidate="txtSerialNo" ForeColor="Red"
                                ToolTip="*" Display="Dynamic" ValidationGroup="cValidationGroup" ErrorMessage="Enter Serial No...">*</asp:RequiredFieldValidator>
                        </span>
                        <asp:TextBox ID="txtSerialNo" runat="server" Text="" CssClass="form-control" placeholder="Enter Serial No..."></asp:TextBox>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="form-group col-xs-5">
                    <div class="input-group">
                        <span class="input-group-addon">Parent Category
                        </span>
                        <asp:TextBox ID="txtParentCategoryID" runat="server" Text="" CssClass="form-control" placeholder="Enter parent category..."></asp:TextBox>


                    </div>
                </div>
                <div style="visibility: hidden ; display: none">
                    <asp:TextBox ID="txtParentID" runat="server" Text=""></asp:TextBox>
                    <asp:HiddenField runat="server" ID="hdParentID" />
                </div>

            </div>


            <div class="clearfix">
            </div>
            <div class="row">
                <div class="col-xs-5 ">

                    <div class="input-group pull-right">
                        
                        
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click"
                            CssClass="btn btn-primary" ValidationGroup="cValidationGroup" />
                          &nbsp;
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click"
                            CssClass="btn btn-primary" />
                          &nbsp;
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click"
                            CssClass="btn btn-primary" />

                        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" CssClass="btn btn-primary"
                            ValidationGroup="cValidationGroup"></asp:Button>
                       


                        <asp:HiddenField runat="server" ID="hdCategoryID" />
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
        </div>
        <div class="row">
        <fieldset class="adminFieldset">
            <legend>Category Lists</legend>

            <asp:ListView ID="lvCategory" runat="server" DataKeyNames="IID"
                OnItemCommand="lvCategory_ItemCommand" OnPagePropertiesChanging="lvCategory_PagePropertiesChanging" OnPreRender="dataPagerCategory_PreRender">
                <LayoutTemplate>
                    <table class="table table-bordered table-hover" style="margin-bottom: 0px;">
                        <tr runat="server">
                            <th style="text-align: center" class="col-xs-1">SL #
                            </th>
                            <th class="col-xs-4">Name
                            </th>
                            <th class="col-xs-2">Serial No
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

                            <asp:LinkButton ID="lnkBtnName" runat="server" CausesValidation="false" Text='<%#Bind("Name")%>'
                                CommandArgument='<%# Bind("IID") %>' CommandName="EditCategory"></asp:LinkButton>
                        </td>
                        <td>
                            <asp:Label ID="lblCode" runat="server" Text='<%# Bind("SerialNo") %>'></asp:Label>
                        </td>
                    </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>

                    <tr class="bg-info" runat="server">
                        <td style="text-align: center">
                            <%# Container.DataItemIndex + 1%>
                        </td>
                        <td style="text-align: left">
                            <asp:LinkButton ID="lnkBtnName" runat="server" CausesValidation="false" Text='<%#Bind("Name")%>'
                                CommandArgument='<%# Bind("IID") %>' CommandName="EditCategory"></asp:LinkButton>
                        </td>
                        <td>
                            <asp:Label ID="lblCode" runat="server" Text='<%# Bind("SerialNo") %>'></asp:Label>
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
            <asp:DataPager ID="dataPagerCategory" runat="server" PagedControlID="lvCategory"
                PageSize="10" OnPreRender="dataPagerCategory_PreRender">
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
    <br/>
</asp:Content>

