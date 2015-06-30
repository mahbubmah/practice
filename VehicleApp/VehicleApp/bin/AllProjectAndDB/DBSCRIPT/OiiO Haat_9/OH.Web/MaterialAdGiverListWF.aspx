<%@ Page Title="" Language="C#" MasterPageFile="~/InnerMasterPage.Master" AutoEventWireup="true" CodeBehind="MaterialAdGiverListWF.aspx.cs" Inherits="OH.Web.MaterialAdGiverListWF" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxConTK" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headInner" runat="server">
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


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentInnerMain" runat="server">


    <div class="container">


        <div class="row">
            <asp:Label ID="labelMessage" runat="server" Text=""></asp:Label>
        </div>



        <fieldset>
            <legend>Search post</legend>
            <div>

                <div class="col-lg-5">

                    <div class="row">
                        <div class="form-group col-xs-12">
                            <div class="input-group">
                                <span class="input-group-addon">Category
                                </span>
                                <asp:TextBox ID="txtCategory" runat="server" Text="" CssClass="form-control" placeholder="Enter Category Name..."></asp:TextBox>
                            </div>
                        </div>
                        <div style="visibility: hidden; display: none">
                            <asp:TextBox ID="txtCategoryID" runat="server" Text=""></asp:TextBox>
                        </div>
                    </div>

                    <div class="row">
                        <div class="form-group col-xs-12">
                            <div class="input-group">
                                <span class="input-group-addon">Material Code
                                </span>
                                <asp:TextBox ID="txtMaterialCode" runat="server" Text="" CssClass="form-control" placeholder="Enter material code..."></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="form-group col-xs-12">
                            <div class="input-group">
                                <span class="input-group-addon">From Date
                                </span>
                                <ajaxConTK:CalendarExtender ID="extDate2" runat="server" Enabled="True" TargetControlID="txtFromDate" Format="dd/MM/yyyy"></ajaxConTK:CalendarExtender>
                                <asp:TextBox ID="txtFromDate" runat="server" Text="" class="form-control" placeholder="Select from date..."></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group col-xs-12">
                            <div class="input-group">
                                <span class="input-group-addon">To Date
                                </span>
                                <ajaxConTK:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" TargetControlID="txtToDate" Format="dd/MM/yyyy"></ajaxConTK:CalendarExtender>
                                <asp:TextBox ID="txtToDate" runat="server" Text="" class="form-control" placeholder="Select to date..."></asp:TextBox>
                            </div>
                        </div>
                    </div>
                      <asp:Button ID="btnCancel" runat="server" Text="Clear" OnClick="btnClear_Click"
                        CssClass="btn btn-primary" />
                    <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" CssClass="btn btn-primary"
                        ValidationGroup="cValidationGroup"></asp:Button>
                  

                </div>

            </div>




        </fieldset>
        <div class="clearfix">
        </div>
        <br />


        <fieldset>
            <legend></legend>
            <div class="container postanAD">
                <div class="row">
                    <div class="col-md-12">
                        <div class="formHeadBorder">

                            <div class="form-group">
                                  <div style="float: right">
                                    <asp:Button ID="btnRecentPost" runat="server" Text="Back to post" OnClick="btnRecentPost_Click" CssClass="btn btn-primary"
                                        ValidationGroup="cValidationGroup"></asp:Button>
                                </div>
                                <h3>My Archive</h3>
                            </div>

                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-12">
                        <div class="manageAdd">
                            <div class="addPostMang">
                              <h4>  <asp:Label ID="labelAdCount" runat="server" Text=""></asp:Label></h4>
                                <div class="table-responsive gridViewHaat">

                                    <asp:ListView ID="lvMaterialArchive" runat="server" DataKeyNames="IID"
                                        OnPagePropertiesChanging="lvMaterial_PagePropertiesChanging" OnPreRender="dataPagerMaterial_PreRender">

                                        <LayoutTemplate>
                                            <table class="table table-bordred table-striped table-hover">
                                                <thead runat="server">
                                                    <th class="col-xs-2" style="text-align: left">Ad ID
                                                    </th>
                                                    <th class="col-xs-2" style="text-align: left">Ad Titel
                                                    </th>

                                                    <th class="col-xs-2" style="text-align: left">Ad Type
                                                    </th>
                                                    <th class="col-xs-2" style="text-align: left">Ad Date
                                                    </th>
                                                    <th class="col-xs-2" style="text-align: left">Ad Last Date
                                                    </th>
                                                </thead>
                                                <tbody id="itemPlaceholder" runat="server">
                                                </tbody>
                                            </table>
                                        </LayoutTemplate>
                                        <ItemTemplate>
                                            <tr runat="server">
                                                <td style="text-align: left">
                                                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("Code") %>'></asp:Label>

                                                </td>
                                                <td style="text-align: left">
                                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("TitleName") %>'></asp:Label>
                                                </td>

                                                <td style="text-align: left">
                                                    <asp:Label ID="lblCatergory" runat="server" Text='<%# Bind("CategoryName") %>'></asp:Label>
                                                </td>

                                                <td style="text-align: left">
                                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("AdDate","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                                </td>
                                                <td style="text-align: left">
                                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("AdDisplayLastDate","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                                </td>

                                            </tr>
                                        </ItemTemplate>
                                        <AlternatingItemTemplate>

                                            <tr runat="server">
                                                <td style="text-align: left">
                                                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("Code") %>'></asp:Label>

                                                </td>
                                                <td style="text-align: left">
                                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("TitleName") %>'></asp:Label>
                                                </td>

                                                <td style="text-align: left">
                                                    <asp:Label ID="lblCatergory" runat="server" Text='<%# Bind("CategoryName") %>'></asp:Label>
                                                </td>

                                                <td style="text-align: left">
                                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("AdDate","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                                </td>
                                                <td style="text-align: left">
                                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("AdDisplayLastDate","{0:dd-MMM-yyyy}") %>'></asp:Label>
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
                                    <asp:DataPager ID="dataPagerMaterial" runat="server" class="pagination pull-right pagItem" PagedControlID="lvMaterialArchive"
                                        PageSize="10" OnPreRender="dataPagerMaterial_PreRender">
                                        <Fields>
                                            <asp:NextPreviousPagerField
                                                ShowNextPageButton="False" />
                                            <asp:NumericPagerField PreviousPageText="..."
                                                RenderNonBreakingSpacesBetweenControls="True"
                                                ButtonType="Link" />
                                            <asp:NextPreviousPagerField ShowPreviousPageButton="False" />
                                        </Fields>
                                    </asp:DataPager>
                                </div>


                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </fieldset>

    </div>
    <br />
</asp:Content>

