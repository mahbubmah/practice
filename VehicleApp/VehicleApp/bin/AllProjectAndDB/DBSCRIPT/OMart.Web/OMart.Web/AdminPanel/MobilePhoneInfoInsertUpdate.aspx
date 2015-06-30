<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.Master" AutoEventWireup="true" CodeBehind="MobilePhoneInfoInsertUpdate.aspx.cs" Inherits="OMart.Web.AdminPanel.MobilePhoneInfoInsertUpdate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AdminHead" runat="server">
    <script type="text/javascript">
        function isNumberKeyWithDotOnlyOne(evt) {
            //evt = (evt) ? evt : event;
            //var charCode = (evt.charCode) ? evt.charCode : ((evt.keyCode) ? evt.keyCode : ((evt.which) ? evt.which : 0));
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57) && charCode != 46) {
                return false;
            }
            else {
                var len = document.getElementById("txtTotalAmount").value.length;
                var index = document.getElementById("txtTotalAmount").value.indexOf('.');
                //alert(len);
                if (index > 0 && charCode == 46) {
                    return false;
                }
            }
            return true;
        }
    </script>

    <script type="text/Javascript">
        function isNumberKeyWithoutDot(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
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
                                <legend>Add/Edit Mobile Phone Info</legend>
                                <div class="col-xs-12">
                                    <div class="col-xs-6">
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="lblMobilePhoneInfoName" runat="server" CssClass="control-label">Mobile Company Name</asp:Label>
                                                    <asp:DropDownList ID="dropdownCompany" runat="server" CssClass="sysTextBox"
                                                        Width="100%" Height="32px">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="rfvCompanyName" runat="server" ControlToValidate="dropdownCompany" ForeColor="Red"
                                                        ErrorMessage="PLease select a company name." InitialValue="-1"
                                                        Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="lblNetworkProvider" runat="server" CssClass="control-label">Network Service Provider</asp:Label>
                                                    <asp:DropDownList ID="dropDownNetworkProvider" runat="server" CssClass="sysTextBox"
                                                        Width="100%" Height="32px">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="lblMPTypeID" runat="server" CssClass="control-label">Mobile Phone Type</asp:Label>
                                                    <asp:DropDownList ID="dropDownMPTypeID" runat="server" CssClass="sysTextBox"
                                                        Width="100%" Height="32px">
                                                    </asp:DropDownList>
                                                     <asp:RequiredFieldValidator ID="rfvMPType" runat="server" ControlToValidate="dropDownMPTypeID" ForeColor="Red"
                                                        ErrorMessage="PLease select mobile type name." InitialValue="-1"
                                                        Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="lblModelName" runat="server" CssClass="control-label">Model Name</asp:Label>
                                                    <asp:TextBox ID="txtModelName" runat="server" CssClass="form-control" placeholder="Enter Model Name"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="lblSIMAvailableID" runat="server" CssClass="control-label">SIM Available </asp:Label>
                                                    <asp:DropDownList ID="dropdownSIMAvailable" runat="server" CssClass="sysTextBox"
                                                        Width="100%" Height="32px">
                                                    </asp:DropDownList>
                                                     <asp:RequiredFieldValidator ID="rfvSIMAvailableID" runat="server" ControlToValidate="dropdownSIMAvailable" ForeColor="Red"
                                                        ErrorMessage="PLease provide Sim Availability." InitialValue="-1"
                                                        Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </div>
                                        <br />

                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="lblPostLastDisplayDate" runat="server" CssClass="control-label"> Post Visibility day(s)</asp:Label>
                                                    <asp:TextBox ID="txtPostVisibilityDay" runat="server" Text="" class="form-control"  placeholder="Day(s) of display...?" onkeypress="return isNumberKeyWithoutDot(event)"></asp:TextBox>
                                                  
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="lblTotalTalkTime" runat="server" CssClass="control-label">Total Talk Time</asp:Label>
                                                    <asp:TextBox ID="txtTotalTalkTime" runat="server" CssClass="form-control" placeholder="Total Talk Time...?" onkeypress="return isNumberKeyWithoutDot(event)"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="lblTalkTimeUnitID" runat="server" CssClass="control-label">Talk Time Unit</asp:Label>
                                                    <asp:DropDownList ID="dropDownTalkTimeUnitID" runat="server" CssClass="sysTextBox"
                                                        Width="100%" Height="32px">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="lblTotalTxtMsg" runat="server" CssClass="control-label">Total Text Message</asp:Label>
                                                    <asp:TextBox ID="txtTotalTxtMsg" runat="server" CssClass="form-control" placeholder="Total Text Number...?" onkeypress="return isNumberKeyWithoutDot(event)"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                    </div>
                                    <div class="col-xs-6 align-right">
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="lblTotalUsableData" runat="server" CssClass="control-label">Total Usable Data</asp:Label>
                                                    <asp:TextBox ID="txtTotalUsableData" runat="server" CssClass="form-control" placeholder="Total Usable Data...?" onkeypress="return isNumberKeyWithDotOnlyOne(event)"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="lblUsableDataUnitID" runat="server" CssClass="control-label">Usable Data Unit</asp:Label>
                                                    <asp:DropDownList ID="dropDownUsableDataUnitID" runat="server" CssClass="sysTextBox"
                                                        Width="100%" Height="32px">
                                                    </asp:DropDownList>
                                                    

                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="lblConnectionTypeID" runat="server" CssClass="control-label">Connection Type</asp:Label>
                                                    <asp:DropDownList ID="dropDownConnectionTypeID" runat="server" CssClass="sysTextBox"
                                                        Width="100%" Height="32px">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="lblTotalPrice" runat="server" CssClass="control-label">Total Price</asp:Label>
                                                    <asp:TextBox ID="txtTotalPrice" runat="server" CssClass="form-control" placeholder="Total Price...?" onkeypress="return isNumberKeyWithDotOnlyOne(event)"></asp:TextBox>
                                                     <asp:RequiredFieldValidator ID="rfvTotalPrice" runat="server" ControlToValidate="txtTotalPrice" ForeColor="Red"
                                                        ErrorMessage="Please enter total price."
                                                        Display="Dynamic" ValidationGroup="gen">*</asp:RequiredFieldValidator>

                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="lblContractDuration" runat="server" CssClass="control-label">Contract Duration</asp:Label>
                                                    <asp:TextBox ID="txtContractDuration" runat="server" CssClass="form-control" placeholder="Contract Duration...?" onkeypress="return isNumberKeyWithoutDot(event)"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="lblMonthlyInstallmentAmt" runat="server" CssClass="control-label">Monthly Installment Amount</asp:Label>
                                                    <asp:TextBox ID="txtMonthlyInstallmentAmt" runat="server" class="form-control bottom-right" placeholder="Monthly Installment Amount...?" onkeypress="return isNumberKeyWithDotOnlyOne(event)"></asp:TextBox>
                                                </div>
                                            </div>

                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="lblWarrantyInfo" runat="server" CssClass="control-label">Warranty Info</asp:Label>
                                                    <asp:TextBox ID="txtWarrantyInfo" runat="server" class="form-control bottom-right" placeholder="Warranty Info...?"></asp:TextBox>
                                                </div>
                                            </div>

                                        </div>
                                        <br />

                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="lblRedirectUrl" runat="server" CssClass="control-label">Redirect Url</asp:Label>
                                                    <asp:TextBox ID="txtRedirectUrl" runat="server" CssClass="form-control" placeholder="Company Verification Redirect Url..."></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-sm-9 col-md-9">
                                                    <asp:Label ID="lblPicUrl" runat="server" CssClass="control-label">Picture Url</asp:Label>

                                                    <asp:FileUpload ID="PictureUpload" runat="server" class="fa-file-image-o" />
                                                  

                                                </div>
                                                <div>
                                                </div>
                                            </div>

                                        </div>
                                        <br />
                                        <div class="row">

                                            <div class="col-sm-9 col-md-9">
                                                <asp:CheckBox ID="chkIsRemoved" runat="server"></asp:CheckBox>
                                                <asp:Label ID="lblIsRemoved" runat="server" CssClass="control-label">Is Removed</asp:Label>

                                            </div>

                                        </div>


                                    </div>
                                </div>
                                <fieldset class="adminFieldset" style="width: 500px; margin:auto;">
                                    <legend>Extra Features</legend>
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-12">                                               
                                                <asp:Label ID="Label2" runat="server" CssClass="control-label">Description</asp:Label>
                                                <asp:TextBox ID="txtDesFeature" TextMode="MultiLine" runat="server" CssClass="form-control"></asp:TextBox></span>
                                                     <br />
                                                <asp:Button ID="btnAddFeature" runat="server" Text="Add Feature" CssClass="btn btn-primary pull-right" OnClick="btnAddFeature_Click" />
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <asp:Label ID="lblMessageFeature" runat="server"></asp:Label>
                                        <div class="col-sm-12">
                                            <div class="manageAdd">
                                                <div class="addPostMang">

                                               <%--     <fieldset class="adminFieldset">
                                                        <legend>Feature Lists</legend>--%>

                                                        <asp:ListView ID="lvFeature" runat="server" DataKeyNames="IID" Visible="false" OnItemCommand="lvFeature_ItemCommand" OnPagePropertiesChanging="lvFeature_PagePropertiesChanging" OnPreRender="lvFeature_PreRender">
                                                            <LayoutTemplate>
                                                                <table class="table  table-hover table-bordered">
                                                                    <thead>
                                                                        <tr runat="server">
                                                                            <th class="col-xs-2">SL #
                                                                            </th>
                                                                            <th class="col-xs-7">Description
                                                                            </th>

                                                                            <th class="col-xs-3">Delete
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
                                                                        <asp:Label ID="lblCode" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <p data-placement="top" data-toggle="tooltip" title="Delete">
                                                                            <asp:LinkButton ID="lnkbDelete" runat="server" CausesValidation="false" class="btn btn-danger btn-xs" data-title="Delete" OnClientClick="return confirm('Are you sure, do you want to delete?');"
                                                                                CommandName="DeleteInfo" CommandArgument='<%# Bind("Description") %>'><i class="fa fa-trash"></i></asp:LinkButton>
                                                                        </p>
                                                                    </td>
                                                                </tr>
                                                            </ItemTemplate>
                                                             <AlternatingItemTemplate>
                                                                <tr class="bg-info" runat="server">
                                                                    <td style="text-align: center">
                                                                        <%# Container.DataItemIndex + 1%>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblDes" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <p data-placement="top" data-toggle="tooltip" title="Delete">
                                                                            <asp:LinkButton ID="lnkbDelete" runat="server" CausesValidation="false" class="btn btn-danger btn-xs" data-title="Delete" OnClientClick="return confirm('Are you sure, do you want to delete?');"
                                                                                CommandName="DeleteInfo" CommandArgument='<%# Bind("Description") %>'><i class="fa fa-trash"></i></asp:LinkButton>
                                                                        </p>
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
                                                        <asp:DataPager ID="dataPagerFeature" runat="server" PagedControlID="lvFeature"
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
                                                   <%-- </fieldset>--%>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </fieldset>
                                <br/>
                                <div class="row">
                                    <div class="form-group">
                                        <div class="col-sm-3 col-md-3 pull-right">
                                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-danger" OnClick="btnCancel_Click" />
                                            <asp:Button ID="btn_CreateOrEdit" runat="server" class="btn btn-primary" Text="Save"
                                                OnClick="btn_CreateOrEdit_Click" ValidationGroup="gen"></asp:Button>
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
