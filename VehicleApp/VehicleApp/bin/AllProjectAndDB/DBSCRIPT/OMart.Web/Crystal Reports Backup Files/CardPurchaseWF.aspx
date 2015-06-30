<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.Master" AutoEventWireup="true" CodeBehind="CardPurchaseWF.aspx.cs" Inherits="OMart.Web.AdminPanel.CardPurchaseWF" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AdminHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AdminContentPlaceHolder" runat="server">
     <div class="container">
        <div class="row">
            <asp:Label ID="labelMessageUserGroup" runat="server" Text="..."></asp:Label>
        </div>
   
        <fieldset>
            <legend>Card Info </legend>

            <div class="row">
                <div class="form-group col-xs-5">
                    <div class="input-group">
                        <span class="input-group-addon">Name                                              
                        </span>
                        <asp:TextBox ID="txtName" ReadOnly="true" runat="server" class="form-control" ></asp:TextBox>
                    </div>
                </div>
            </div>           
            <div class="row">
                <div class="form-group col-xs-5">
                    <div class="input-group">
                          <span class="input-group-addon">Description
                                              
                        </span>
                        <asp:TextBox ID="txtDescription" ReadOnly="true" runat="server" class="form-control" placeholder=""></asp:TextBox>
                    </div>
                </div>
            </div>
             <div class="row">
                <div class="form-group col-xs-5">
                    <div class="input-group">
                          <span class="input-group-addon">Card Type
                                              
                        </span>
                        <asp:TextBox ID="txtCartType" ReadOnly="true" runat="server" class="form-control" placeholder=""></asp:TextBox>
                    </div>
                </div>
            </div>
             <div class="row">
                <div class="form-group col-xs-5">
                    <div class="input-group">
                          <span class="input-group-addon">Balance Type
                                              
                        </span>
                        <asp:TextBox ID="txtBalType" ReadOnly="true" runat="server" class="form-control" placeholder=""></asp:TextBox>
                    </div>
                </div>
            </div>
        </fieldset>
         <br />
        <fieldset>
            <legend>Purchase</legend>
            <div class="row">
                <div class="form-group col-xs-5">
                    <div class="input-group">
                         <span class="input-group-addon">Month Number
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                ControlToValidate="txtMonthNo" ForeColor="Red"
                                ToolTip="*" Display="Dynamic" ValidationGroup="UserValidationGroup" ErrorMessage="Enter Month Number...">*</asp:RequiredFieldValidator>
                        
                        
                        </span>
                        <asp:TextBox ID="txtMonthNo" TextMode="Number" runat="server" class="form-control" placeholder=""></asp:TextBox>
                        
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="form-group col-xs-5">
                    <div class="input-group">
                         <span class="input-group-addon">Rate on Purchase
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                ControlToValidate="txtRateOnPurchase" ForeColor="Red"
                                ToolTip="*" Display="Dynamic" ValidationGroup="UserValidationGroup" ErrorMessage="Enter Rate on Purchase...">*</asp:RequiredFieldValidator>
                        
                        
                        </span>
                        <asp:TextBox ID="txtRateOnPurchase" TextMode="Number" runat="server" class="form-control" placeholder=""></asp:TextBox>
                    </div>
                </div>
            </div>

             <div class="row">
                <div class="form-group col-xs-5">
                    <div class="input-group">
                         <span class="input-group-addon">Note
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                ControlToValidate="txtRateOnPurchase" ForeColor="Red"
                                ToolTip="*" Display="Dynamic" ValidationGroup="UserValidationGroup" ErrorMessage="Enter Note...">*</asp:RequiredFieldValidator>
                        
                        
                        </span>
                        <asp:TextBox ID="txtNote" runat="server" class="form-control" placeholder=""></asp:TextBox>
                    </div>
                </div>
            </div>

             <div class="row">
                <div class="form-group col-xs-5">
                    <div class="input-group">
                        <span style="display: none">
                            <asp:TextBox ID="txtUsergrpID"  runat="server"></asp:TextBox>
                        </span>
                    </div>
                </div>
            </div>

             <div class="row">
                    <div class="form-group col-xs-5">
                        <div class="input-group">
                            <asp:CheckBox ID="chkUserGrpIsRemove" runat="server" Text=" &nbsp Is Remove"/>
                        </div>
                    </div>
                </div>


           <div class="row">
                <div class="col-xs-5">
                    <div class="input-group pull-right">
                        <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="UserValidationGroup" CssClass="btn btn-primary" OnClick="btnSave_Click"></asp:Button>
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" ValidationGroup="UserValidationGroup"
                            CssClass="btn btn-primary" OnClick="btnUpdate_Click" />
                        <asp:Button ID="btnDelete" runat="server" Text="Delete"
                            CssClass="btn btn-primary"  Visible="true"/>
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel"
                            CssClass="btn btn-primary" OnClick="btnCancel_Click" />
                        <asp:HiddenField runat="server" ID="hdCardInfoID" />
                        <asp:HiddenField runat="server" ID="hdIsEdit" />
                        <asp:HiddenField runat="server" ID="hdIsDelete" />
                        <asp:HiddenField ID="hdSave" runat="server" />
                        <asp:HiddenField ID="hdId" runat="server" />
                        <asp:ValidationSummary
                            ShowMessageBox="true"
                            ShowSummary="false"
                            HeaderText="You must enter a value in the following fields:"
                            EnableClientScript="true"
                            runat="server" ValidationGroup="UserValidationGroup" />

                    </div>
                </div>
            </div>

       

        <div class="fa-space-shuttle">
        </div>
         <br />
        <div>
            <fieldset>
                <legend>Card Purchase Information List</legend>

                <asp:ListView ID="lvUserGroup" runat="server" DataKeyNames="IID" OnItemCommand="lvUserGroup_ItemCommand" OnPagePropertiesChanging="lvUserGroup_PagePropertiesChanging">
                    <LayoutTemplate>
                        <table class="table table-bordered table-hover" style="margin-bottom: 0px;">
                            <thead>
                                <tr runat="server">
                                    <th class="col-xs-2" style="text-align: center">SL #
                                    </th>
                                    <th class="col-xs-3">Month Number
                                    </th>
                                     <th class="col-xs-3">Rate on Purchase
                                    </th>
                                    <th class="col-xs-3">Note
                                    </th>
                                    <th class="col-xs-2">Edit
                                    </th>
                                    <th class="col-xs-2">Delete
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
                                <asp:Label ID="lblTypeID" runat="server" Text='<%# Bind("MonthNumber") %>'></asp:Label>
                            </td>
                             <td>
                               <%-- <asp:Label ID="lblCountryID" runat="server" Text='<%# Bind("CounrtyName") %>'></asp:Label>--%>
                                <%-- <asp:CheckBox ID="chkIsRemove" runat="server" Checked='<%# Bind("IsRemoved") %>' Enabled="true"/>--%>
                                  <asp:Label ID="lblIsRemoved" runat="server" Text='<%# Bind("RateOnPurchase") %>'></asp:Label>
                             </td>
                             <td>
                                <asp:Label ID="lblNote" runat="server" Text='<%# Bind("Note") %>'></asp:Label>
                            </td>
                            <td>
                            <p data-placement="top" data-toggle="tooltip" title="Edit">
                               <asp:LinkButton ID="lnkbEdit" runat="server" CausesValidation="false" class="btn btn-primary btn-xs" data-title="Edit"
                               CommandArgument='<%# Bind("IID") %>' OnClick="lnkbEdit_Click"><i class="fa fa-pencil-square-o"></i></asp:LinkButton>
                            </p>
                        </td>
                         <td>
                            <p data-placement="top" data-toggle="tooltip" title="Delete">
                                <asp:LinkButton ID="lnkbDelete" runat="server" CausesValidation="false" class="btn btn-danger btn-xs" data-title="Delete" OnClientClick="return confirm('Are you sure, do you want to delete?');"
                                CommandArgument='<%# Bind("IID") %>' OnClick="lnkbDelete_Click"><i class="fa fa-trash"></i></asp:LinkButton>
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
                <asp:DataPager ID="dataPagerUserGroup" runat="server" PagedControlID="lvUserGroup"
                    PageSize="10" OnPreRender="dataPagerUserGroup_PreRender">
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
             </fieldset>
      </div>
</asp:Content>
