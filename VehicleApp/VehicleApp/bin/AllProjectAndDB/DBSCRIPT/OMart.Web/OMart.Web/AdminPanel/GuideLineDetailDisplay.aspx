<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.Master" AutoEventWireup="true" CodeBehind="GuideLineDetailDisplay.aspx.cs" Inherits="OMart.Web.AdminPanel.GuideLineDetailDisplay" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AdminHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AdminContentPlaceHolder" runat="server">
     <section>
        <div class="container signpPage">
           
             <div class="row">
                <div class="col-sm-12">
                    <div class="pull-left">
                        <asp:Label ID="labelMessageGuideLineDetail" runat="server"></asp:Label>
                    </div>
                    <div class="pull-right" style="padding-top:10px">
                         
                        <asp:Button ID="btnAddGuideLineDetail" runat="server" Text="Add New" CssClass="btn btn-primary" OnClick="btnAddGuideLineDetail_Click" />
                    </div>
                </div>
            </div>
            
        
          <div class="row">
                <div class="col-sm-12">
                    <div class="manageAdd">
                        <div class="addPostMang">

                            <fieldset class="adminFieldset">
                                <legend>Guide Line Detail List</legend>

                                <asp:ListView ID="lvGuideLineDetail" runat="server" DataKeyNames="IID" OnPagePropertiesChanging="lvGuideLineDetail_PagePropertiesChanging" OnPreRender="lvGuideLineDetail_PreRender"
                                    >
                                    <LayoutTemplate>
                                        <table class="table  table-hover table-bordered">
                                            <thead>
                                                <tr runat="server">
                                                     <th class="col-xs-1">SL #
                                                    </th>
                                                    <th class="col-xs-1">Guide Line
                                                    </th>
                                                     <th class="col-xs-1">Guide Line Detail
                                                    </th>
                                                     <th class="col-xs-2">Description
                                                    </th>
                                                     <th class="col-xs-1">Image
                                                    </th>
                                                     <th class="col-xs-1">Is Remove
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
                                             <td>
                                                <asp:Label ID="lblGuideLine" runat="server" Text='<%# Bind("guideLine") %>'></asp:Label>
                                            </td>
                                              <td>
                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("GuideLineDetail") %>'></asp:Label>
                                            </td>
                                             <td>
                                                 <p style="width:200px;height:100px;overflow:hidden ">
                                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                                            </p>
                                                     </td>
                                             <td>
                                                <div class="thumbnail">
                                                    <asp:Image runat="server" ID="OtherContentimg" Width="102" Height="60" ImageUrl='<%# Eval("ImageUrl") %>' alt="Image" />
                                                  
                                                </div>
                                            </td>
                                             <td>
                                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("IsRemoved") %>'></asp:Label>
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
                                <asp:DataPager ID="dataPagerGuideLineDetail" runat="server" PagedControlID="lvGuideLineDetail"
                                    PageSize="10" OnPreRender="dataPagerGuideLineDetail_PreRender" >
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
            </section>
</asp:Content>
