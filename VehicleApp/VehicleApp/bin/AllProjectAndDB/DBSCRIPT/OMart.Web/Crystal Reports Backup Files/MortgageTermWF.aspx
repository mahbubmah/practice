<%@ Page Title="Mortgage Term Year" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.Master" AutoEventWireup="true" CodeBehind="MortgageTermWF.aspx.cs" Inherits="OMart.Web.MortgageTermWF" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AdminHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AdminContentPlaceHolder" runat="server">
    <div class="container">
        <div class="row">
            <asp:Label ID="labelMessage" runat="server" Text=""></asp:Label>
        </div>

        <div class="row">
            <div class="row">
                <div class="col-sm-12">
                    <div class="manageAdd">
                        <div class="addPostMang">
                            <fieldset class="adminFieldset">
                                <legend>Add Mortgage Term Year</legend>
                                <div class="col-xs-6">
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="lblNoYear" runat="server" CssClass="control-label">Number of Year</asp:Label>
                                                <asp:TextBox ID="txtMortgageYear" TextMode="Number" runat="server" CssClass="form-control"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvNumberOfYear" runat="server"
                                                    ControlToValidate="txtMortgageYear"
                                                    ErrorMessage="Number of Year is a required field."
                                                    ForeColor="Red" ValidationGroup="vgMortgage">
                                                   
                                                </asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <asp:HiddenField runat="server" ID="hdEdit" />
                                    <asp:HiddenField runat="server" ID="hdIID" />
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Label ID="lblDescription" runat="server" CssClass="control-label">Description</asp:Label>
                                                <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>

                                            </div>
                                        </div>
                                    </div>                                  
                                    <br />
                                    <div class="row">                                        
                                        <asp:CheckBox ID="chkIsRemovedMortgageTerm" runat="server" Text=" Is Removed"></asp:CheckBox>
                                    </div>

                                    <br />
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-danger" OnClick="btnCancel_Click" />
                                                <asp:Button ID="btn_CreateOrEdit" runat="server" class="btn btn-primary  pull-right" Text="Submit"
                                                    OnClick="btn_CreateOrEdit_Click" ValidationGroup="vgMortgage" />
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-9 col-md-9">
                                            </div>
                                        </div>
                                    </div>

                                </div>
                            </fieldset>
                            <div class="clearfix">                                  
                                       
                            </div>
                            <div>
                                <fieldset>
                                     <legend>Mortgage Term Year List</legend>

                   <asp:ListView ID="lvUserGroup" runat="server" DataKeyNames="IID"  OnPagePropertiesChanging="lvMortgageTerm_PagePropertiesChanging">
                    <LayoutTemplate>
                        <table class="table table-bordered table-hover" style="margin-bottom: 0px;">
                            <thead>
                                <tr runat="server">
                                    <th class="col-xs-4" style="text-align: center">SL #
                                    </th>
                                    <th class="col-xs-4">Number of Year
                                    </th>
                                    <th class="col-xs-4">Description
                                    </th>
                                     <th class="col-xs-4">Is Remove
                                    </th>
                                    <th class="col-xs-4">Edit
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
                            <td style="text-align: left">
                               <asp:Label ID="Label2" runat="server" Text='<%#Bind("NumberOfYear")%>'></asp:Label>
                                
                            </td>
                            <td>
                                <asp:Label ID="lblTypeID" runat="server" Text='<%#Bind("Description")%>'></asp:Label>
                            </td>
                            <td>
                                                <asp:CheckBox ID="chkIsRemoved" runat="server" Checked='<%# Bind("IsRemoved") %>' Enabled="false"></asp:CheckBox>
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
                    PageSize="10" OnPreRender="dataPagerMortgageTerm_PreRender">
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
            </div>           
        </div>
</asp:Content>
