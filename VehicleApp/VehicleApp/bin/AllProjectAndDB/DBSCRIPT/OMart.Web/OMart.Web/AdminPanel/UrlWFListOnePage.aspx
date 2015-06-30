<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.Master" AutoEventWireup="true" CodeBehind="UrlWFListOnePage.aspx.cs" Inherits="OMart.Web.UrlWFListOnePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AdminHead" runat="server">
    <script type="text/javascript">
        $(function () {
            var txtQtyOfPro = $("#<%=txtUrlWFSerialNo.ClientID %>");
         $(txtQtyOfPro).keydown(function (event) {
             if (event.keyCode == 46 || event.keyCode == 8 || event.keyCode == 9 || event.keyCode == 27 || (event.keyCode == 65 && event.ctrlKey === true) || (event.keyCode >= 35 && event.keyCode <= 39)) {
                 return;
             }
             else {
                 if ((event.keyCode < 48 || event.keyCode > 57) && (event.keyCode < 96 || event.keyCode > 105)) {
                     event.preventDefault();
                 }
             }
         });
     });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AdminContentPlaceHolder" runat="server">
    <div class="container">
        <div class="row">
            <h2>Url List Information
            </h2>
        </div>

        <div class="row">
            <asp:Label ID="labelMessage" runat="server" Text="..."></asp:Label>
        </div>
          <div class="col-xs-12">
        <fieldset>
            <legend>Add New Url</legend>
          
            <div class="col-xs-6" >
                <div class="row">
                    <div class="form-group">
                        <div class="col-sm-9 col-md-9">
                            <asp:Label ID="Label1" runat="server" CssClass="control-label">Module Name</asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" InitialValue="--Select Module Name--"
                                ControlToValidate="dropDownModuleName" ForeColor="Red"
                                ToolTip="*" Display="Dynamic" ValidationGroup="cValidationGroup" ErrorMessage="Select Module Name...">*</asp:RequiredFieldValidator>
                            <asp:DropDownList ID="dropDownModuleName" AutoPostBack="true" runat="server" Height="100%" class="form-control"
                                OnSelectedIndexChanged="dropDownModuleName_SelectedIndexChanged1">
                            </asp:DropDownList>

                        </div>
                    </div>
                </div>

                <br />

                <div class="row">
                    <div class="form-group">
                        <div class="col-sm-9 col-md-9">
                            <asp:Label ID="Label2" runat="server" CssClass="control-label">Module Serial No</asp:Label>
                            <asp:TextBox ID="txtModuleSerialNo" runat="server" ReadOnly="true" Height="100%" class="form-control"></asp:TextBox>

                        </div>
                    </div>
                </div>

                <br />
                <div class="row">
                    <div class="form-group">
                        <div class="col-sm-9 col-md-9">
                            <asp:Label ID="Label8" runat="server" CssClass="control-label">Module Url</asp:Label>
                            <asp:TextBox ID="txtModuleurl" runat="server" Height="100%" class="form-control"></asp:TextBox>

                        </div>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="form-group">
                        <div class="col-sm-9 col-md-9">
                            <asp:Label ID="Label6" runat="server" CssClass="control-label">Module Note</asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                ControlToValidate="txtModuleNote" ForeColor="Red"
                                ToolTip="*" Display="Dynamic" ValidationGroup="cValidationGroup" ErrorMessage="Enter Url Name...">*</asp:RequiredFieldValidator>
                            <asp:TextBox ID="txtModuleNote" runat="server" Height="100%" class="form-control"></asp:TextBox>

                        </div>
                    </div>
                </div>
                </div>
          
           <div class="col-xs-6 pull-right">

              
              
                <div class="row">
                    <div class="form-group">
                        <div class="col-sm-9 col-md-9">
                            <asp:Label ID="Label7" runat="server" CssClass="control-label">Module Image</asp:Label>
                            <asp:FileUpload ID="FileUploadImage" runat="server" class="form-control" />

                        </div>
                    </div>
                </div>
                 <div style="display: none">
                    <asp:TextBox ID="txtHoldImagePath" runat="server"></asp:TextBox>
                </div>
                <br />

                <div class="row">
                    <div class="form-group">
                        <div class="col-sm-9 col-md-9">
                            <asp:Label ID="Label3" runat="server" CssClass="control-label">Url Name</asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                                ControlToValidate="txtUrlWFName" ForeColor="Red"
                                ToolTip="*" Display="Dynamic" ValidationGroup="cValidationGroup" ErrorMessage="Enter Url Name...">*</asp:RequiredFieldValidator>
                            <asp:TextBox ID="txtUrlWFName" runat="server" Height="100%" class="form-control"></asp:TextBox>

                        </div>
                    </div>
                </div>

                <br />

                <div class="row">
                    <div class="form-group">
                        <div class="col-sm-9 col-md-9">
                            <asp:Label ID="Label4" runat="server" CssClass="control-label">Url Serial No</asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                ControlToValidate="txtUrlWFSerialNo" ForeColor="Red"
                                ToolTip="*" Display="Dynamic" ValidationGroup="cValidationGroup" ErrorMessage="Enter Url Serial No...">*</asp:RequiredFieldValidator>
                            <asp:TextBox ID="txtUrlWFSerialNo" runat="server" TextMode="Number" Height="100%" class="form-control"></asp:TextBox>

                        </div>
                    </div>
                </div>

                <br />

                <div class="row">
                    <div class="form-group">
                        <div class="col-sm-9 col-md-9">
                            <asp:Label ID="Label5" runat="server" CssClass="control-label">Url Display Name</asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                ControlToValidate="txtUrlWFDisplayName" ForeColor="Red"
                                ToolTip="*" Display="Dynamic" ValidationGroup="cValidationGroup"
                                ErrorMessage="Enter Url Display Name...">*</asp:RequiredFieldValidator>

                            <asp:TextBox ID="txtUrlWFDisplayName" runat="server" Height="100%" class="form-control"></asp:TextBox>

                        </div>
                    </div>
                </div>
            </div>
      
            <br />



            <div class="clearfix">
            </div>
            <br />
            <div class="row">
                <div class="form-group pull-right">

                    <div class="col-sm-12 col-md-12">

                        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" CssClass="btn btn-primary"
                            ValidationGroup="cValidationGroup"></asp:Button>

                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click"
                            CssClass="btn btn-danger" />

                        <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="lnkbEdit_Click"
                            CssClass="btn btn-primary" ValidationGroup="cValidationGroup" />

                        <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click"
                            CssClass="btn btn-primary" />



                        <asp:HiddenField runat="server" ID="hdUrlListID" />
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

        <div class="clearfix">
        </div>
        <br />
        <div>
            <fieldset>
                <legend>Url Information</legend>

                <asp:ListView ID="lvUrlWFList" runat="server" DataKeyNames="IID"
                    OnItemCommand="lvUrlWFList_ItemCommand" OnPagePropertiesChanging="lvUrlWFList_PagePropertiesChanging">
                    <LayoutTemplate>
                        <table class="table table-bordered table-hover" style="margin-bottom: 0px;">
                            <thead>
                                <tr runat="server">
                                    <th class="col-xs-1">SL #
                                    </th>
                                    <th class="col-xs-2">Module Name
                                    </th>
                                    <th class="col-xs-2">Module Serial No
                                    </th>
                                    <th class="col-xs-2">Url Module Name
                                    </th>
                                    <th class="col-xs-2">Module Note
                                    </th>
                                    <th class="col-xs-2">Module Image
                                    </th>
                                    <th class="col-xs-3">UrlWF Name
                                    </th>
                                    <th class="col-xs-2">UrlWF Display Name
                                    </th>
                                    <th class="col-xs-2">UrlWF Serial No
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
                            <td style="text-align: left">

                                <asp:Label ID="lnkBtnName" runat="server" Text='<%#Bind("ModuleName")%>'> </asp:Label>
                            </td>
                            <td style="text-align: right">
                                <asp:Label ID="lblCode" runat="server" Text='<%# Bind("ModuleSerialNo") %>'></asp:Label>
                            </td>
                            <td style="text-align: right">
                                <asp:Label ID="Label9" runat="server" Text='<%# Bind("UrlModuleName") %>'></asp:Label>
                            </td>
                            <td style="text-align: right">
                                <asp:Label ID="lblModuleNote" runat="server" Text='<%# Bind("ModuleNote") %>'></asp:Label>
                            </td>
                            <td>
                                <div class="thumbnail">
                                    <asp:Image runat="server" ID="OtherContentimg" Width="172" Height="130" ImageUrl='<%# Eval("ModuleImage") %>' alt="Image" />
                                    <%--<asp:Label ID="lblImageUrl" runat="server" Text='<%# Bind("ImageUrl") %>'></asp:Label>--%>
                                </div>
                            </td>
                            <td style="text-align: left">
                                <asp:Label ID="lblDescription" runat="server" Text='<%# Bind("UrlWFName") %>'></asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:Label ID="lblApplicableCountryID" runat="server" Text='<%# Bind("UrlWFDisplayName") %>'></asp:Label>
                            </td>
                            <td style="text-align: right">
                                <asp:Label ID="lblUrlSerialNo" runat="server" Text='<%# Bind("UrlWFSerialNO") %>'></asp:Label>
                            </td>
                            <td>
                                <p data-placement="top" data-toggle="tooltip" title="Edit">
                                    <asp:LinkButton ID="lnkbEdit" runat="server" CausesValidation="false" class="btn btn-primary btn-xs" data-title="Edit"
                                        CommandArgument='<%# Bind("IID") %>' CommandName="EditUrlWFList"><i class="fa fa-pencil-square-o"></i></asp:LinkButton>

                                </p>
                            </td>
                            <td>
                                <p data-placement="top" data-toggle="tooltip" title="Delete">
                                    <asp:LinkButton ID="lnkbDelete" runat="server" CausesValidation="false" class="btn btn-danger btn-xs" data-title="Delete" OnClientClick="return confirm('Are you sure, do you want to delete?');"
                                        CommandArgument='<%# Bind("IID") %>' CommandName="DeleteUrlWFList"><i class="fa fa-trash"></i></asp:LinkButton>
                                </p>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <tr id="trBody" runat="server" class="bg-info">
                            <td style="text-align: center">
                                <%# Container.DataItemIndex + 1%>
                            </td>
                            <td style="text-align: left">
                                <asp:Label ID="lnkBtnName" runat="server" Text='<%#Bind("ModuleName")%>'> </asp:Label>
                            </td>
                            <td style="text-align: right">
                                <asp:Label ID="lblCode" runat="server" Text='<%# Bind("ModuleSerialNo") %>'></asp:Label>
                            </td>
                             <td style="text-align: right">
                                <asp:Label ID="Label9" runat="server" Text='<%# Bind("UrlModuleName") %>'></asp:Label>
                            </td>
                            <td style="text-align: right">
                                <asp:Label ID="lblModuleNote" runat="server" Text='<%# Bind("ModuleNote") %>'></asp:Label>
                            </td>
                            <td>
                                <div class="thumbnail">
                                    <asp:Image runat="server" ID="OtherContentimg" Width="172" Height="130" ImageUrl='<%# Eval("ModuleImage") %>' alt="Image" />
                                    <%--<asp:Label ID="lblImageUrl" runat="server" Text='<%# Bind("ImageUrl") %>'></asp:Label>--%>
                                </div>
                            </td>
                            <td style="text-align: left">
                                <asp:Label ID="lblDescription" runat="server" Text='<%# Bind("UrlWFName") %>'></asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:Label ID="lblApplicableCountryID" runat="server" Text='<%# Bind("UrlWFDisplayName") %>'></asp:Label>
                            </td>
                            <td style="text-align: right">
                                <asp:Label ID="lblUrlSerialNo" runat="server" Text='<%# Bind("UrlWFSerialNO") %>'></asp:Label>
                            </td>
                            <td>
                                <p data-placement="top" data-toggle="tooltip" title="Edit">
                                    <asp:LinkButton ID="lnkbEdit" runat="server" CausesValidation="false" class="btn btn-primary btn-xs" data-title="Edit"
                                        CommandArgument='<%# Bind("IID") %>' CommandName="EditUrlWFList"><i class="fa fa-pencil-square-o"></i></asp:LinkButton>

                                </p>
                            </td>
                            <td>
                                <p data-placement="top" data-toggle="tooltip" title="Delete">
                                    <asp:LinkButton ID="lnkbDelete" runat="server" CausesValidation="false" class="btn btn-danger btn-xs" data-title="Delete" OnClientClick="return confirm('Are you sure, do you want to delete?');"
                                        CommandArgument='<%# Bind("IID") %>' CommandName="DeleteUrlWFList"><i class="fa fa-trash"></i></asp:LinkButton>
                                </p>
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
                <asp:DataPager ID="dataPagerUrlWFList" runat="server" PagedControlID="lvUrlWFList"
                    PageSize="5" OnPreRender="dataPagerUrlWFList_PreRender">
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
                <p>
                    <br />
                    <br />
                </p>
            </fieldset>
        </div>
    </div>
    
</asp:Content>


