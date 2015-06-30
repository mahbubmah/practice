<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.Master" AutoEventWireup="true" CodeBehind="GuideLineWithDetailsInsertUpdate.aspx.cs" Inherits="OMart.Web.AdminPanel.GuideLineWithDetailsInsertUpdate" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxConTK" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AdminHead" runat="server">
    <script type="text/javascript">
        function isNumberKeyWithDotOnlyOne(evt) {
            evt = (evt) ? evt : window.event;
            var charCode = (evt.which) ? evt.which : evt.keyCode
            var part = evt.srcElement.value.split('.');
            if (charCode != 46 && charCode > 31
              && (charCode < 48 || charCode > 57) || (part.length > 1 && charCode == 46)) {
                return false;
            }
            return true;
        }
    </script>

    <script type="text/Javascript">
        function isNumberKeyWithoutDot(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            var part = evt.srcElement.value.split('.');
            if (charCode > 31
              && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AdminContentPlaceHolder" runat="server">
    <br />
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
                                <legend>Add/Edit Guide Line </legend>
                                <div class="col-xs-12">
                                    <div class="col-xs-6">
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="lblCompanyInfoName" runat="server" CssClass="control-label">Business Type</asp:Label>
                                                    <asp:DropDownList ID="ddlBusinessType" runat="server" CssClass="form-control"></asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="rfvTypeID" runat="server"
                                                        ControlToValidate="ddlBusinessType" ForeColor="Red" InitialValue="--Select Business Type--"
                                                        ToolTip="*" Display="Dynamic" ValidationGroup="gen" ErrorMessage="Select Business Type..."></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </div>

                                        <br />
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="lblLoanAmtYearSchedule" runat="server" CssClass="control-label">Title</asp:Label>
                                                    <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvCode" runat="server" ControlToValidate="txtTitle" ForeColor="Red"
                                                    ErrorMessage="Please enter Title."
                                                    Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </div>
                                        <br />

                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="lblDescription" runat="server" CssClass="control-label">Description </asp:Label>
                                                    <asp:TextBox ID="txtDescription1" TextMode="MultiLine" runat="server" CssClass="form-control"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDescription1" ForeColor="Red"
                                                    ErrorMessage="Please enter Description."
                                                    Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </div>
                                        <br />

                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="Label1" runat="server" CssClass="control-label"> Image</asp:Label>
                                                    <asp:FileUpload ID="FileUploadImage1" runat="server" class="form-control" />
                                                </div>
                                            </div>

                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="Label3" runat="server" CssClass="control-label">Is Removed</asp:Label>
                                                    <asp:CheckBox ID="chkIsRemoved1" runat="server" CssClass="form-control"></asp:CheckBox>
                                                </div>
                                            </div>
                                        </div>

                                    </div>

                                    <div class="col-xs-6 align-right">
                                        <fieldset>
                                            <legend>Add/Edit Guide Line Detail </legend>

                                            <br />
                                            <div class="row">
                                                <div class="form-group">
                                                    <div class="col-sm-9 col-md-9">
                                                        <asp:Label ID="lblPaymentAmt" runat="server" CssClass="control-label">Title</asp:Label>
                                                        <asp:TextBox ID="txtTitle2"  runat="server" CssClass="form-control" ></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtTitle2" ForeColor="Red"
                                                    ErrorMessage="Please enter Title."
                                                    Display="Dynamic" ValidationGroup="gon"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                            </div>
                                            <br />
                                            <div class="row">
                                                <div class="form-group">
                                                    <div class="col-sm-9 col-md-9">
                                                        <asp:Label ID="lblTotalReturnAmountt" runat="server" CssClass="control-label"> Description</asp:Label>
                                                        <asp:TextBox ID="txtDescription2" TextMode="MultiLine"  runat="server" CssClass="sysTextBox"
                                                            Width="100%" Height="32px" >   </asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtDescription2" ForeColor="Red"
                                                    ErrorMessage="Please enter Description."
                                                    Display="Dynamic" ValidationGroup="gon"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                            </div>
                                            <br />
                                            <div class="row">
                                                <div class="form-group">
                                                    <div class="col-sm-9 col-md-9">
                                                        <asp:Label ID="Label7" runat="server" CssClass="control-label"> Image</asp:Label>
                                                        <asp:FileUpload ID="FileUploadImage2" runat="server" class="form-control" />
                                                    </div>
                                                </div>

                                            </div>

                                            <br />

                                            <div class="row">
                                                <div class="form-group">
                                                    <div class="col-sm-9 col-md-9">
                                                        <asp:Label ID="lblIsRemoved" runat="server" CssClass="control-label">Is Removed</asp:Label>
                                                        <asp:CheckBox ID="chkIsRemoved2" runat="server" CssClass="form-control"></asp:CheckBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div style="display: none">
                                                <asp:TextBox ID="txtHoldImagePath" runat="server"></asp:TextBox>
                                                <asp:TextBox ID="txtHoldImagePath2" runat="server"></asp:TextBox>
                                            </div>
                                            <br />
                                            <fieldset class="adminFieldset" style="width: 400px;">
                                                
                                                                                   
                                        <div class="row align-right">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Button ID="btnAddGuideLine" runat="server" Text="Add GuideLine" CssClass="btn btn-primary" OnClick="btnAddGuideLine_Click" />
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="col-sm-12">
                                                <div class="manageAdd">
                                                    <div class="addPostMang">
                                                        <fieldset class="adminFieldset">
                                                            <legend>GuideLine Lists</legend>

                                                            <asp:ListView ID="lvGuideLine" runat="server" DataKeyNames="IID" OnItemCommand="lvGuideLine_ItemCommand" OnPagePropertiesChanging="lvGuideLine_PagePropertiesChanging" OnPreRender="lvGuideLine_PreRender">
                                                                <LayoutTemplate>
                                                                    <table class="table  table-hover table-bordered">
                                                                        <thead>
                                                                            <tr runat="server">
                                                                                <th class="col-xs-1">SL #
                                                                                </th>
                                                                                <th class="col-xs-2">Title
                                                                                </th>

                                                                                <th class="col-xs-1">Description
                                                                                </th>
                                                                                
                                                                                <th class="col-xs-1">Delete
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
                                                                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("Title") %>'></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblCode" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                                                                        </td>
                                                                        
                                                                        <td>
                                                                            <p data-placement="top" data-toggle="tooltip" title="Delete">
                                                                                <asp:LinkButton ID="lnkbDelete" runat="server" CausesValidation="false" class="btn btn-danger btn-xs" data-title="Delete" OnClientClick="return confirm('Are you sure, do you want to delete?');"
                                                                                    CommandName="DeleteInfo" CommandArgument='<%# Bind("Title") %>'><i class="fa fa-trash"></i></asp:LinkButton>
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
                                                            <asp:DataPager ID="dataPagerGuideLine" runat="server" PagedControlID="lvGuideLine"
                                                                PageSize="5" OnPreRender="dataPagerFeature_PreRender">
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
                                    </fieldset>
                                        </fieldset>
                                    </div>

                                    <div class="row" style="font-size: 16px">
                                        <div class="col-sm-12">
                                            <asp:Label ID="lblMessageGuideLine" runat="server"></asp:Label>
                                        </div>
                                    </div>

                                </div>

                                <div class="col-sm-12 col-md-12">
                                    <div class="row">
                                        <br />
                                        <div class="form-group">
                                            <div class="col-sm-3 col-md-3 pull-right">
                                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-danger" OnClick="btnCancel_Click" />

                                                <asp:Button ID="btn_CreateOrEdit" runat="server" class="btn btn-primary" Text="Submit"
                                                    ValidationGroup="gen" OnClick="btn_CreateOrEdit_Click"></asp:Button>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                            </fieldset>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
