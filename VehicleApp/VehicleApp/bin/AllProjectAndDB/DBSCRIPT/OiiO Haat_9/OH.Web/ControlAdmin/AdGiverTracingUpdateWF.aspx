<%@ Page Title="" Language="C#" MasterPageFile="~/ControlAdmin/ControlAdminMaster.Master" AutoEventWireup="true" CodeBehind="AdGiverTracingUpdateWF.aspx.cs" Inherits="OH.Web.ControlAdmin.AdGiverTracingUpdateWF" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headAdmin" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentAdminMain" runat="server">
    <div class="container adminPagewrp">
    <div class="row">
        <h2 style="text-align:center">
            Add Giver Tracing List
        </h2>
    </div>
        <div>
        <asp:Label ID="labelMessageUpdateAddGiverTracing" runat="server" Text="..."></asp:Label>
    </div>
        <asp:Panel ID="pnlAddGiverUpdate" runat="server" >
         <div>
        <fieldset>
               <legend><asp:Label ID="lblForLagendUpdate" runat="server"></asp:Label></legend>
             <div class="row" >
                <div class="form-group col-xs-5">
                    <div class="input-group">
                        <span class="input-group-addon"><asp:Label ID="lblForAddGiver" runat="server" Text=""></asp:Label> 
                            <asp:RequiredFieldValidator ID="rfvAdGiver" runat="server"
                                ControlToValidate="txtUpdateAdGiverID" ForeColor="Red"
                                ToolTip="*" Display="Dynamic">*</asp:RequiredFieldValidator>
                        </span>
                        <asp:TextBox ID="txtUpdateAdGiverID" runat="server" Text="" ValidationGroup="AdGiverUpdateValidationGroup" class="form-controlWebSer"></asp:TextBox>
                    </div>
                </div>
            </div>
             <div class="row" >
                <div class="form-group col-xs-5">
                    <div class="input-group">
                        <span class="input-group-addon"><asp:Label ID="lblForMaterial" runat="server" Text=""></asp:Label> 
                            <asp:RequiredFieldValidator ID="rfvMaterial" runat="server"
                                ControlToValidate="txtUpdateMaterialID" ForeColor="Red"
                                ToolTip="*" Display="Dynamic">*</asp:RequiredFieldValidator>
                        </span>
                        <asp:TextBox ID="txtUpdateMaterialID" runat="server" Text="" ValidationGroup="AdGiverUpdateValidationGroup" class="form-controlWebSer"></asp:TextBox>
                    </div>
                </div>
                   
            </div>

             <div class="row">
                <div class="form-group col-xs-5">
                    <div class="input-group">
                        <span class="input-group-addon"><asp:Label ID="lblIPAddress" runat="server" Text=""></asp:Label>
                            <asp:RequiredFieldValidator ID="rfvIPAddress" runat="server"
                                ControlToValidate="txtUpdateIPAddress" ForeColor="Red"
                                ToolTip="*" Display="Dynamic">*</asp:RequiredFieldValidator>
                        </span>
                        <asp:TextBox ID="txtUpdateIPAddress" runat="server" Text="" ValidationGroup="AdGiverUpdateValidationGroup" class="form-controlWebSer" placeholder="Enter IP Address..." ReadOnly="True"></asp:TextBox>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="form-group col-xs-5">
                    <div class="input-group">
                        <span class="input-group-addon"><asp:Label ID="lblMACAddress" runat="server" Text=""></asp:Label>
                            <asp:RequiredFieldValidator ID="rfvMACAddress" runat="server"
                                ControlToValidate="txtUpdateMACAddress" ForeColor="Red"
                                ToolTip="*" Display="Dynamic">*</asp:RequiredFieldValidator>
                        </span>
                        <asp:TextBox ID="txtUpdateMACAddress" runat="server" Text="" ValidationGroup="AdGiverUpdateValidationGroup" class="form-controlWebSer" placeholder="Enter MAC Address..." ReadOnly="True"></asp:TextBox>
                    </div>
                </div>
            </div>

             <div class="row">
                <div class="form-group col-xs-5">
                    <div class="input-group">
                        <span class="input-group-addon"><asp:Label ID="lblBrowserName" runat="server" Text=""></asp:Label>
                            <asp:RequiredFieldValidator ID="rfvBrowserNameID" runat="server"
                                ControlToValidate="txtUpdateBrowserNameID" ForeColor="Red"
                                ToolTip="*" Display="Dynamic">*</asp:RequiredFieldValidator>
                        </span>
                        <asp:TextBox ID="txtUpdateBrowserNameID" runat="server" Text="" ValidationGroup="AdGiverUpdateValidationGroup" class="form-controlWebSer" placeholder="Enter BrowserNameID..." ReadOnly="True"></asp:TextBox>
                    </div>
                </div>
            </div>
            
             <div class="row">
                <div class="form-group col-xs-5">
                    <div class="input-group">
                        <span class="input-group-addon"><asp:Label ID="lblBrowsingTime" runat="server" Text=""></asp:Label>
                            <asp:RequiredFieldValidator ID="rfvBrowsingTime" runat="server"
                                ControlToValidate="txtUpdateBrowsingTime" ForeColor="Red"
                                ToolTip="*" Display="Dynamic">*</asp:RequiredFieldValidator>
                        </span>
                        <asp:TextBox ID="txtUpdateBrowsingTime" runat="server" Text="" ValidationGroup="AdGiverUpdateValidationGroup" class="form-controlWebSer" placeholder="Enter Browsing Time..." ReadOnly="True"></asp:TextBox>
                    </div>
                </div>
            </div>

              <div class="row">
                    <div class="form-group col-xs-5">
                        <div class="input-group">
                           <asp:CheckBox ID="chkAdgiverTracingActv" runat="server" Text=" &nbsp Is Remove"/>
                        </div>
                    </div>
                </div>

            <div class="row">
                <div class="col-xs-5">
                    <div class="input-group pull-right">
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" ValidationGroup="AdGiverUpdateValidationGroup"  CssClass="btn btn-primary" OnClick="btnUpdate_Click" ></asp:Button>
                          <asp:Button ID="btnCancel" runat="server" Text="Cancel" ValidationGroup="AdGiverUpdateValidationGroup"  CssClass="btn btn-primary" OnClick="btnCancel_Click" ></asp:Button>
                          <asp:HiddenField runat="server" ID="hdUpdateAdGiverID" />
                        <asp:HiddenField runat="server" ID="hdIsEdit" />
                        <asp:HiddenField runat="server" ID="hdIsDelete" />
                      
                    </div>

                </div>
            </div>
        </fieldset>
              </div>
            </asp:Panel>

        <div>
         <fieldset>
            <legend>User Group Lists</legend>
             <h6 style="display:inline;color:red">Click "Ad Giver Name" to Update</h6>
            <asp:ListView ID="lvUpdateAdGiver" runat="server" DataKeyNames="IID" OnItemCommand="lvUpdateAdGiver_ItemCommand" OnPagePropertiesChanging="lvUpdateAdGiver_PagePropertiesChanging" 
               >
                <LayoutTemplate>
                    <table class="table table-bordered table-hover">
                        <thead>
                        <tr runat="server">
                            <th class="col-xs-1" style="text-align: center">SL #
                            </th>
                            <th class="col-xs-1" style="text-align: left">Ad Giver Name
                            </th>
                            <th class="col-xs-1" style="text-align: center">Material ID
                            </th>
                             <th class="col-xs-1" style="text-align: center">IP Address
                            </th>
                            <th class="col-xs-1" style="text-align: center">MAC Address
                            </th>
                             <th class="col-xs-1" style="text-align: left">Browser Name
                            </th>
                            <th class="col-xs-2" style="text-align: right">Browsing Time Duration
                            </th>
                             <th class="col-xs-1" style="text-align: left">Is Remove
                            </th>
                        </tr>
                            </thead>
                        <tbody id="itemPlaceholder" runat="server">
                        </tbody>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr  runat="server">
                        <td style="text-align: center">
                            <%# Container.DataItemIndex + 1%>
                        </td>
                        <td style="text-align: left">
                            <asp:Label ID="lblUpdateAdGiverID" runat="server" Text='<%# Bind("IID") %>' Visible="false"></asp:Label>
                            <asp:LinkButton ID="lnkBtnName" runat="server" CausesValidation="false" Text='<%#Bind("name")%>'
                                CommandArgument='<%# Bind("IID") %>' CommandName="EditUpdateAdGiver"></asp:LinkButton>
                        </td>
                        <td style="text-align: center">
                            <asp:Label ID="lblTypeID" runat="server" Text='<%#Bind("MaterialID")%>'></asp:Label>
                        </td>
                          <td style="text-align: center">
                            <asp:Label ID="Label1" runat="server" Text='<%#Bind("IPAddress")%>'></asp:Label>
                        </td>
                         <td style="text-align: center">
                            <asp:Label ID="Label2" runat="server" Text='<%#Bind("MACAddress")%>'></asp:Label>
                        </td>
                         <td style="text-align: left">
                            <asp:Label ID="Label3" runat="server" Text='<%#Enum.Parse(typeof(OH.Utilities.EnumCollection.Browsers), Eval("BrowserNameID").ToString())%>'></asp:Label>
                        </td>
                         <td style="text-align: right">
                            <asp:Label ID="Label4" runat="server" Text='<%#Bind("BrowsingTimeDuration")%>'></asp:Label>
                        </td>
                           <td>
                               <asp:CheckBox ID="chkIsRemove" runat="server" Checked='<%# Bind("IsRemoved") %>' Enabled="false"/>
                             </td>
                    </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>

                    <tr class="bg-info" runat="server">
                        <td style="text-align: center">
                            <%# Container.DataItemIndex + 1%>
                        </td>
                        <td style="text-align: left">
                            <asp:Label ID="lblUserGroupID" runat="server" Text='<%# Bind("IID") %>' Visible="false"></asp:Label>
                            <asp:LinkButton ID="lnkBtnName" runat="server" CausesValidation="false" Text='<%#Bind("name")%>'
                                CommandArgument='<%# Bind("IID") %>' CommandName="EditUpdateAdGiver"></asp:LinkButton>
                        </td>
                        <td style="text-align: center">
                            <asp:Label ID="lblTypeID" runat="server" Text='<%#Bind("MaterialID")%>'></asp:Label>
                        </td>
                          <td style="text-align: center">
                            <asp:Label ID="Label1" runat="server" Text='<%#Bind("IPAddress")%>'></asp:Label>
                        </td>
                         <td style="text-align: center">
                            <asp:Label ID="Label2" runat="server" Text='<%#Bind("MACAddress")%>'></asp:Label>
                        </td>
                         <td style="text-align: left">
                            <asp:Label ID="Label3" runat="server" Text='<%#Enum.Parse(typeof(OH.Utilities.EnumCollection.Browsers), Eval("BrowserNameID").ToString())%>'></asp:Label>
                        </td>
                         <td style="text-align: right">
                            <asp:Label ID="Label4" runat="server" Text='<%#Bind("BrowsingTimeDuration")%>'></asp:Label>
                        </td>
                           <td>
                               <asp:CheckBox ID="chkIsActive" runat="server" Checked='<%# Bind("IsRemoved") %>' Enabled="false"/>
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
            <asp:DataPager ID="dataPagerUpdateAdGiver" runat="server" PagedControlID="lvUpdateAdGiver"
                PageSize="10" OnPreRender="dataPagerUpdateAdGiver_PreRender">
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
