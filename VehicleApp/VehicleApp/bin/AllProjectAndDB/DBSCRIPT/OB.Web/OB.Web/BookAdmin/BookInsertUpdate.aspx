<%@ Page Title="" Language="C#" MasterPageFile="~/BookAdmin/OiiOMasterPage.Master" AutoEventWireup="true" CodeBehind="BookInsertUpdate.aspx.cs" Inherits="OMart.Web.BookAdmin.BookInsertUpdate" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxConTK" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <section>
        <div class="mainpageBody">
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
                                    <legend>Add/Edit Book</legend>
                                    <div class="col-xs-12">
                                        <div class="col-xs-6">
                                            <div class="row">
                                                <div class="form-group">
                                                    <div class="col-sm-9 col-md-9">
                                                        <asp:Label ID="lblBookTitle" runat="server" CssClass="control-label">Book Title</asp:Label>
                                                        <asp:TextBox ID="txtBookTitle" runat="server" CssClass="form-control"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rvfBookTitle" runat="server" ControlToValidate="txtBookTitle" ForeColor="Red"
                                                            ErrorMessage="Please enter book title."
                                                            Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                            </div>
                                            <br />
                                            <div class="row">
                                                <div class="form-group">
                                                    <div class="col-sm-9 col-md-9">
                                                        <asp:Label ID="lblISBN" runat="server" CssClass="control-label">ISBN</asp:Label>
                                                        <asp:TextBox ID="txtISBN" runat="server" CssClass="form-control"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rbfISBN" runat="server" ControlToValidate="txtISBN" ForeColor="Red"
                                                            ErrorMessage="Please enter ISBN number."
                                                            Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                            </div>
                                            <br />
                                            <div class="row">
                                                <div class="form-group">
                                                    <div class="col-sm-9 col-md-9">
                                                        <asp:Label ID="lblAuthor" runat="server" CssClass="control-label">Author</asp:Label>
                                                        <asp:DropDownList ID="DropDownAuthor" runat="server" CssClass="form-control"
                                                            Width="100%" Height="32px">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="rvfAuthor" runat="server" ControlToValidate="DropDownAuthor" ForeColor="Red" InitialValue="-1"
                                                            ErrorMessage="Please select a author."
                                                            Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                            </div>
                                            <br />
                                            <div class="row">
                                                <div class="form-group">
                                                    <div class="col-sm-9 col-md-9">
                                                        <asp:Label ID="lblPublisher" runat="server" CssClass="control-label">Publisher</asp:Label>
                                                        <asp:DropDownList ID="DropDownPublisher" runat="server" CssClass="form-control"
                                                            Width="100%" Height="32px">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="rvfPublisher" runat="server" ControlToValidate="DropDownPublisher" ForeColor="Red"
                                                            ErrorMessage="Please select publisher name." InitialValue="-1"
                                                            Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                            </div>
                                            <br />
                                            <div class="row">
                                                <div class="form-group">
                                                    <div class="col-sm-9 col-md-9">
                                                        <asp:Label ID="lblPublishedDate" runat="server" CssClass="control-label">Published Date</asp:Label>
                                                        <asp:TextBox ID="txtPublishedDate" runat="server" CssClass="form-control"></asp:TextBox>
                                                        <ajaxConTK:CalendarExtender ID="extDate2" runat="server" Enabled="True" TargetControlID="txtPublishedDate" Format="dd/MM/yyyy"></ajaxConTK:CalendarExtender>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtPublishedDate" ForeColor="Red"
                                                            ErrorMessage="Please enter PublishedDate."
                                                            Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                            </div>







                                            <br />
                                            <fieldset class="adminFieldset" style="border: 1px dashed #000000; padding-left: 20px">
                                                <legend>Add available book URL</legend>

                                                <div class="row">
                                                    <div class="form-group">
                                                        <div class="col-sm-9 col-md-9">
                                                            <asp:Label ID="lblBookWishType" runat="server" CssClass="control-label">Book Wish Type</asp:Label>
                                                            <asp:DropDownList ID="ddlBookWishType" runat="server" CssClass="form-control"
                                                                Width="100%" Height="32px">
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator InitialValue="-1" ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlBookWishType" ForeColor="Red"
                                                                ErrorMessage="Please select book wish type." Display="Dynamic" ValidationGroup="child"></asp:RequiredFieldValidator>

                                                        </div>
                                                    </div>
                                                </div>
                                                <br />
                                                <div class="row">
                                                    <div class="form-group">
                                                        <div class="col-sm-9 col-md-9">
                                                            <asp:Label ID="lblBookAvailableUrl" runat="server" CssClass="control-label">Book Available Url</asp:Label>
                                                            <asp:TextBox ID="txtBookAvailableUrl" runat="server" CssClass="form-control" placeholder="Company Verification Redirect Url..."></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtBookAvailableUrl" ForeColor="Red"
                                                                ErrorMessage="Please enter a valid book url." Display="Dynamic" ValidationGroup="child"></asp:RequiredFieldValidator>

                                                            <%--<asp:RegularExpressionValidator
                                                                ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtBookAvailableUrl"
                                                                ForeColor="Red" Display="Dynamic" ErrorMessage="Please enter a valid book url."
                                                                ValidationExpression="/(((http|ftp|https):\/{2})+(([0-9a-z_-]+\.)+(aero|asia|biz|cat|com|coop|edu|gov|info|int|jobs|mil|mobi|museum|name|net|org|pro|tel|travel|ac|ad|ae|af|ag|ai|al|am|an|ao|aq|ar|as|at|au|aw|ax|az|ba|bb|bd|be|bf|bg|bh|bi|bj|bm|bn|bo|br|bs|bt|bv|bw|by|bz|ca|cc|cd|cf|cg|ch|ci|ck|cl|cm|cn|co|cr|cu|cv|cx|cy|cz|cz|de|dj|dk|dm|do|dz|ec|ee|eg|er|es|et|eu|fi|fj|fk|fm|fo|fr|ga|gb|gd|ge|gf|gg|gh|gi|gl|gm|gn|gp|gq|gr|gs|gt|gu|gw|gy|hk|hm|hn|hr|ht|hu|id|ie|il|im|in|io|iq|ir|is|it|je|jm|jo|jp|ke|kg|kh|ki|km|kn|kp|kr|kw|ky|kz|la|lb|lc|li|lk|lr|ls|lt|lu|lv|ly|ma|mc|md|me|mg|mh|mk|ml|mn|mn|mo|mp|mr|ms|mt|mu|mv|mw|mx|my|mz|na|nc|ne|nf|ng|ni|nl|no|np|nr|nu|nz|nom|pa|pe|pf|pg|ph|pk|pl|pm|pn|pr|ps|pt|pw|py|qa|re|ra|rs|ru|rw|sa|sb|sc|sd|se|sg|sh|si|sj|sj|sk|sl|sm|sn|so|sr|st|su|sv|sy|sz|tc|td|tf|tg|th|tj|tk|tl|tm|tn|to|tp|tr|tt|tv|tw|tz|ua|ug|uk|us|uy|uz|va|vc|ve|vg|vi|vn|vu|wf|ws|ye|yt|yu|za|zm|zw|arpa)(:[0-9]+)?((\/([~0-9a-zA-Z\#\+\%@\.\/_-]+))?(\?[0-9a-zA-Z\+\%@\/&\[\];=_-]+)?)?))\b/imuS" ValidationGroup="child">
                                                            </asp:RegularExpressionValidator>--%>
                                                        </div>
                                                    </div>
                                                </div>
                                                <br />
                                                <div class="row">
                                                    <div class="form-group">
                                                        <div class="col-sm-9 col-md-9">
                                                            <asp:Label ID="lblOfferDescription" runat="server" CssClass="control-label">Offer description</asp:Label>
                                                            <asp:TextBox ID="txtOfferDescription" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <br />
                                                <div class="row">
                                                    <div class="form-group">
                                                        <div class="col-sm-9 col-md-9">
                                                            <asp:Label ID="lblSpecialDescription" runat="server" CssClass="control-label">Sepcial offer description</asp:Label>
                                                            <asp:TextBox ID="txtSpecialOfferDescription" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <br />
                                                <div class="row">
                                                    <div class="form-group">
                                                        <div class="col-sm-9 col-md-9">
                                                            <asp:Label ID="lblHasSpecialOffer" runat="server" CssClass="control-label">Has special offer description</asp:Label>
                                                            <asp:CheckBox ID="chkHasSpecialOffer" runat="server" CssClass="form-control"></asp:CheckBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <br />
                                                <div class="row">
                                                    <div class="form-group">
                                                        <div class="col-sm-9 col-md-9">
                                                            <asp:Button ID="btnAddUrl" runat="server" class="btn btn-primary pull-right" Text="Add Url" ValidationGroup="child"
                                                                OnClick="btnAddUrl_Click"></asp:Button>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="row">
                                                    <div class="col-sm-10 col-md-10">
                                                        <div class="manageAdd">
                                                            <div class="addPostMang">

                                                                <fieldset class="adminFieldset">
                                                                    <legend>Available book URL lists</legend>

                                                                    <asp:ListView ID="lvBookFeature" runat="server" DataKeyNames="IID" OnItemCommand="lvBookFeature_ItemCommand">
                                                                        <LayoutTemplate>
                                                                            <table class="table  table-hover table-bordered">
                                                                                <thead>
                                                                                    <tr runat="server">
                                                                                        <th class="col-xs-1">SL #
                                                                                        </th>
                                                                                        <th class="col-xs-4">Book wish type
                                                                                        </th>
                                                                                        <th class="col-xs-4">Url 
                                                                                        </th>
                                                                                        <th class="col-xs-3">Has special offer 
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
                                                                                    <asp:Label ID="lblBookWishType" runat="server" Text='<%# Bind("BookWishTypeID") %>'></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblUrl" runat="server" Text='<%# Bind("BookAvailableUrl") %>'></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:CheckBox ID="lblHasSpecialOffer" runat="server" Enabled="false"></asp:CheckBox>
                                                                                </td>
                                                                                <td>
                                                                                    <p data-placement="top" data-toggle="tooltip" title="Delete">
                                                                                        <asp:LinkButton ID="lnkbDelete" runat="server" CausesValidation="false" class="btn btn-danger btn-xs" data-title="Delete" CommandName="DeleteInfo"><i class="fa fa-trash"></i></asp:LinkButton>
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
                                                                    <asp:DataPager ID="dpBookFeature" runat="server" PagedControlID="lvBookFeature"
                                                                        PageSize="5">
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
                                        </div>

                                        <br />

                                        <div class="col-xs-6 align-right">
                                            <div class="row">
                                                <div class="form-group">
                                                    <div class="col-sm-9 col-md-9">
                                                        <asp:Label ID="lblAbstract" runat="server" CssClass="control-label">Abstract</asp:Label>
                                                        <asp:TextBox ID="txtAbstract" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rvfAbstract" runat="server" ControlToValidate="txtAbstract" ForeColor="Red"
                                                            ErrorMessage="Please give abstract of book."
                                                            Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                            </div>
                                            <br />
                                            <div class="row">
                                                <div class="form-group">
                                                    <div class="col-sm-9 col-md-9">
                                                        <asp:Label ID="lblQuantity" runat="server" CssClass="control-label">Quantity</asp:Label>
                                                        <asp:TextBox ID="txtQuantity" runat="server" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <br />
                                            <div class="row">
                                                <div class="form-group">
                                                    <div class="col-sm-9 col-md-9">
                                                        <asp:Label ID="lblPrice" runat="server" CssClass="control-label">Price(per book)</asp:Label>
                                                        <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control"></asp:TextBox>
                                                        <asp:RequiredFieldValidator InitialValue="-1" ID="rvfPrice" runat="server" ControlToValidate="txtPrice" ForeColor="Red"
                                                            ErrorMessage="Please enter price of book." Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                            </div>
                                            <br />
                                            <div class="row">
                                                <div class="form-group">
                                                    <div class="col-sm-9 col-md-9">
                                                        <asp:Label ID="lblDiscount" runat="server" CssClass="control-label">Discount(%)</asp:Label>
                                                        <asp:TextBox ID="txtDiscount" runat="server" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <br />
                                            <div class="row">
                                                <div class="form-group">
                                                    <div class="col-sm-9 col-md-9">
                                                        <asp:Label ID="lblEdition" runat="server" CssClass="control-label">Edition</asp:Label>
                                                        <asp:TextBox ID="txtEdition" runat="server" CssClass="form-control"></asp:TextBox>

                                                    </div>
                                                </div>
                                            </div>
                                            <br />
                                            <div class="row">
                                                <div class="form-group">
                                                    <div class="col-sm-9 col-md-9">
                                                        <asp:Label ID="lblCategory" runat="server" CssClass="control-label">Category</asp:Label>
                                                        <asp:DropDownList ID="dropDownCategory" runat="server" CssClass="form-control"
                                                            Width="100%" Height="32px">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator InitialValue="-1" ID="rvfCategory" runat="server" ControlToValidate="dropDownCategory" ForeColor="Red"
                                                            ErrorMessage="Please select book`s category." Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>

                                                    </div>
                                                </div>
                                            </div>


                                            <br />
                                            <div class="row">
                                                <div class="form-group">
                                                    <div class="col-sm-9 col-md-9">
                                                        <asp:Label ID="lblPostLastDisplayDate" runat="server" CssClass="control-label"> Post Visibility Day(s)</asp:Label>
                                                        <asp:TextBox ID="txtPostVisibilityDay" runat="server" Text="" class="form-control" placeholder="Last day of display...?"></asp:TextBox>
                                                        <asp:RequiredFieldValidator InitialValue="-1" ID="rvfPostVisibilityDay" runat="server" ControlToValidate="txtPostVisibilityDay" ForeColor="Red"
                                                            ErrorMessage="Please enter Post Visibility Day(s)." Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                            </div>

                                            <br />

                                            <br />
                                            <div class="row">
                                                <div class="form-group">
                                                    <div class="col-sm-9 col-md-9">
                                                        <asp:Label ID="lblPicUrl" runat="server" CssClass="control-label">Picture Url</asp:Label>

                                                        <asp:FileUpload ID="PictureUpload" runat="server" CssClass="form-control" />


                                                    </div>
                                                    <div>
                                                    </div>
                                                </div>

                                            </div>
                                            <br />
                                            <div class="row">
                                                <div class="form-group">
                                                    <div class="col-sm-9 col-md-9">
                                                        <asp:Label ID="lblIsLatest" runat="server" CssClass="control-label">Is Latest</asp:Label>
                                                        <asp:CheckBox ID="chkIsLatest" runat="server" CssClass="form-control"></asp:CheckBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <br />
                                            <div class="row">
                                                <div class="form-group">
                                                    <div class="col-sm-9 col-md-9">
                                                        <asp:Label ID="lblIsRecommended" runat="server" CssClass="control-label">Is Recommended</asp:Label>
                                                        <asp:CheckBox ID="chkIsRecommended" runat="server" CssClass="form-control"></asp:CheckBox>
                                                    </div>
                                                    <%-- <div class="col-sm-3 col-md-3">
                                                        <asp:CheckBox ID="chkIsRemoved" runat="server"></asp:CheckBox>
                                                        <asp:Label ID="lblIsRemoved" runat="server" CssClass="control-label">Is Removed</asp:Label>

                                                    </div>--%>
                                                </div>

                                            </div>
                                        </div>
                                    </div>
                                </fieldset>
                            </div>
                        </div>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="form-group">
                        <div class="col-sm-6 col-md-6 col-sm-offset-6 col-md-6">
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-danger pull-left" OnClick="btnCancel_Click" />

                            <asp:Button ID="btn_CreateOrEdit" runat="server" class="btn btn-primary pull-right" Text="Submit"
                                OnClick="btn_CreateOrEdit_Click" ValidationGroup="gen"></asp:Button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>

