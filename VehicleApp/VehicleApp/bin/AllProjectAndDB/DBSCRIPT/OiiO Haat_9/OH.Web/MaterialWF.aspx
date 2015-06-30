<%@ Page Title="" Language="C#" MasterPageFile="~/InnerMasterPage.Master" AutoEventWireup="true" CodeBehind="MaterialWF.aspx.cs" Inherits="OH.Web.MaterialWF" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxConTK" %>



<asp:Content ID="Content1" ContentPlaceHolderID="headInner" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentInnerMain" runat="server">


    <section style="background: #f9f9f9;">
        <%--        <asp:UpdatePanel ID="upPostAdAdd" runat="server">
            <ContentTemplate>--%>
        <div class="container postAddInfoHead">
            <div class="row">
                <div class="col-md-12">
                    <h2>Add Posting Information</h2>

                </div>
            </div>
            <div class="container postAddInfo ">

                <div class="row">
                    <div class="col-md-12">
                        <div class="row">
                            <asp:Label ID="labelMessage" runat="server" Text=""></asp:Label>
                        </div>
                        <h3 class="panel-title">Post an add with your category</h3>
                        <asp:UpdatePanel runat="server" ID="updatePanelCategory">
                            <ContentTemplate>
                        <div class="panelPostBody">
                            <div class="groupPart">
                                <label class="oiioLbl">Category</label>
                                <div class="row">
                                    <div class="col-sm-4 col-md-4 col-lg-4">
                                        <asp:DropDownList ID="dropDownCategory" OnSelectedIndexChanged="btnCategoryID_Click" AutoPostBack="True" runat="server" class="form-control oiioPostFcnt"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="clearfix"></div>
                            </div>
                            <div style="visibility: hidden; display: none">
                                <asp:HiddenField ID="txtCategoryID" runat="server" />

                                <asp:Button ID="btnCategoryID" runat="server" Text="" OnClick="btnCategoryID_Click" />
                            </div>
                            <div class="groupPart">
                                <label class="oiioLbl">Add Referance Code</label>
                                <div class="row">
                                    <div class="col-sm-4 col-md-4 col-lg-4">
                                        <asp:TextBox ID="txtCode" runat="server" Text="" class="form-control oiioPostFcnt" ReadOnly="True"></asp:TextBox>

                                    </div>
                                </div>

                                <div class="clearfix"></div>
                            </div>

                        </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        <h3 class="panel-title">Add Posting Details</h3>
                        <div class="panelPostBody">
                            <div class="groupPart">
                                <label class="oiioLbl">Add Title name</label>
                                <div class="row">
                                    <div class="col-sm-4 col-md-4 col-lg-4">

                                        <asp:TextBox ID="txtTitleName" runat="server" Text="" class="form-control oiioPostFcnt" placeholder="Enter Title Name..."></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rbfFirstName" runat="server" ControlToValidate="txtTitleName" ForeColor="Red"
                                            ErrorMessage="PLease Enter Product Title."
                                            Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-sm-8 col-md-8 col-lg-8">
                                        <p>This field cannot be empty.</p>
                                    </div>
                                </div>

                                <div class="clearfix"></div>
                            </div>
                            <div class="groupPart">
                                <label class="oiioLbl">Discription of the add</label>
                                <div class="row">
                                    <div class="col-sm-4 col-md-4 col-lg-4">

                                        <CKEditor:CKEditorControl ID="txtDescription" BasePath="/ckeditor/" runat="server" placeholder="Enter Description...">
                                        </CKEditor:CKEditorControl>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDescription" ForeColor="Red"
                                            ErrorMessage="PLease enter Description."
                                            Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-sm-8 col-md-8 col-lg-8">
                                        <p>
                                            Enter the information about your add as much as possible ; add with detailed 
                                        and longer discriptions will increase your chances for product to be 
                                        sold quickly.
                                        </p>
                                    </div>
                                </div>

                                <div class="clearfix"></div>
                            </div>
                            <div class="groupPart">
                                <label class="oiioLbl">Add Images</label>
                                <div class="row">

                                    <div class="col-sm-4 col-md-4 col-lg-4">
                                        <div class="form-inline" style="margin-bottom: 10px;">
                                            <div class="col-sm-8 col-md-8 col-lg-8">
                                                <div id="js-upload-files">
                                                    <asp:FileUpload AllowMultiple="True" ID="MatPicUpload" runat="server" class="oiioPostFcnt" />
                                                </div>
                                            </div>

                                        </div>
                                    </div>
                                    <div class="col-sm-8 col-md-8 col-lg-8">
                                        <div id="js-upload-submit" class="col-sm-2 col-md-2 col-lg-2 pull-left">
                                            <asp:Button runat="server" ID="btnMatPicUpload" Text="Add Images" OnClick="btnMatPicUpload_Click" class="btn btn-primary" />
                                        </div>
                                        <div class="col-sm-10 col-md-10 col-lg-10">
                                            <p>
                                                Upload clear images as many as posible which will increase your chances for 
                                        product to be sold quickly.
                                            </p>
                                        </div>
                                    </div>
                                    <div class=" col-sm-12 col-md-12 col-lg-12" style="width: 97%; min-height: 100px; border: 1px solid #F3F3F3; margin-left: 1px;">
                                        <asp:DataList ID="datalistTempMatImage" runat="server" RepeatColumns="8">
                                            <ItemTemplate>
                                                <asp:Image ID="imgMatTempImage" CssClass="img-thumbnail" runat="server" Width="90" Style="" Height="75" ImageUrl='<%#Bind("ImageUrlTemp") %>' />
                                                <asp:CheckBox ID="chkImg" CssClass="checkbox-inline" runat="server" />
                                                &emsp; 
                                            </ItemTemplate>
                                        </asp:DataList>
                                        <asp:Button runat="server" Text="Delete selected" CssClass="btn btn-danger" ID="btnDeleteImageTemp" OnClick="btnDeleteImageTemp_Click"></asp:Button>

                                    </div>
                                </div>

                                <div class="clearfix"></div>
                            </div>
                            <div class="groupPart">
                                <label class="oiioLbl">Price of product</label>
                                <div class="row">
                                    <div class="col-sm-4 col-md-4 col-lg-4">
                                        <asp:TextBox ID="txtPrice" runat="server" Text="" TextMode="Number" CssClass="form-control oiioPostFcnt" placeholder="Enter price..."></asp:TextBox>
                                        <ajaxConTK:FilteredTextBoxExtender ID="FilteredTextBoxExtenderPrice" runat="server"
                                            TargetControlID="txtPrice" FilterType="Custom, Numbers" ValidChars="." />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPrice" ForeColor="Red"
                                            ErrorMessage="PLease enter your  price."
                                            Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                        <br />
                                        <%-- <asp:CheckBox ID="chkNegotiable" runat="server" Text="Check if this Price is Negotiable" />--%>
                                        <div class="btn-group" data-toggle="buttons">
                                            <label class="btn btn-default">
                                                <asp:CheckBox ID="chkNegotiable" runat="server" autocomplete="off" />
                                                <span class="glyphicon glyphicon-ok"></span>
                                            </label>
                                            &nbsp;&nbsp; Check if this Price is Negotiable
                                        </div>

                                    </div>
                                    <div class="col-sm-8 col-md-8 col-lg-8">
                                        <p>How much do you want for your product ?</p>
                                    </div>
                                </div>

                                <div class="clearfix"></div>
                            </div>
                            <div class="groupPart">
                                <label class="oiioLbl">Visibility</label>
                                <div class="row">
                                    <div class="col-sm-4 col-md-4 col-lg-4">

                                        <asp:TextBox ID="txtPostVisibilityDay" runat="server" Text="" CssClass="form-control oiioPostFcnt" TextMode="Number" placeholder="Select last day of display..."></asp:TextBox>
                                        <ajaxConTK:FilteredTextBoxExtender ID="FilteredTextBoxExtenderVisibilityDay" runat="server"
                                            TargetControlID="txtPostVisibilityDay" FilterType="Custom, Numbers" ValidChars="." />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPostVisibilityDay" ForeColor="Red"
                                            ErrorMessage="PLease enter last day of display."
                                            Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-sm-8 col-md-8 col-lg-8">
                                        <p>
                                            How many days do you want to post visibility ?
                                        </p>
                                    </div>
                                </div>

                                <div class="clearfix"></div>
                            </div>

                        </div>

                        <h3 class="panel-title">Location</h3>

                        <asp:UpdatePanel ID="upLocation" runat="server">
                            <ContentTemplate>

                                <div class="panelPostBody">
                                    <div class="groupPart">
                                        <label class="oiioLbl">Please enter your district name</label>
                                        <div class="row">
                                            <div class="col-sm-4 col-md-4 col-lg-4">

                                                <asp:DropDownList ID="dropdownDistrict" OnSelectedIndexChanged="dropdownDistrict_SelectedIndexChange" AutoPostBack="True" runat="server" CssClass="form-control oiioPostFcnt"></asp:DropDownList>
                                            </div>
                                        </div>
                                        <div style="visibility: hidden; display: none">
                                            <asp:TextBox ID="txtDistrictID" runat="server" Text=""></asp:TextBox>
                                        </div>
                                        <div class="clearfix"></div>
                                    </div>
                                    <div class="groupPart">
                                        <label class="oiioLbl">Please select your police station</label>
                                        <div class="row">
                                            <div class="col-sm-4 col-md-4 col-lg-4">

                                                <asp:DropDownList ID="dropdownPoliceStation" runat="server" CssClass="form-control oiioPostFcnt"></asp:DropDownList>
                                                <div style="visibility: hidden; display: none">
                                                    <asp:TextBox ID="txtPoliceStationID" runat="server" Text=""></asp:TextBox>
                                                </div>
                                            </div>


                                        </div>
                                    </div>

                                    <div class="groupPart">
                                        <label class="oiioLbl">Specific location</label>
                                        <div class="row">
                                            <div class="col-sm-4 col-md-4 col-lg-4">

                                                <asp:TextBox ID="txtLocation" runat="server" Text="" class="form-control txtAra" placeholder="location..." TextMode="MultiLine"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtLocation" ForeColor="Red"
                                                    ErrorMessage="PLease enter your location."
                                                    Display="Dynamic" ValidationGroup="gen"></asp:RequiredFieldValidator>
                                            </div>
                                            <div class="col-sm-8 col-md-8">
                                                <p>You have to mantion your specific location.</p>
                                            </div>
                                        </div>
                                        <div style="visibility: hidden; display: none">
                                            <asp:TextBox ID="txtLocationID" runat="server" Text=""></asp:TextBox>
                                        </div>

                                    </div>

                                    <div class="clearfix"></div>
                                </div>

                            </ContentTemplate>
                        </asp:UpdatePanel>

                    </div>
                </div>


                <h3 class="panel-title">Linkup</h3>
                <div class="panelPostBody">
                    <div class="groupPart">
                        <label class="oiioLbl">Website Url</label>
                        <div class="row">
                            <div class="col-sm-4 col-md-4 col-lg-4">
                                <asp:TextBox ID="txtWeburl" runat="server" placeholder="https://" CssClass="form-control oiioPostFcnt"></asp:TextBox>
                            </div>
                            <div class="col-sm-8 col-md-8 col-lg-8">
                                <p>Enter your website link if you have.Include 'http://' in your Website Url</p>
                            </div>
                        </div>

                        <div class="clearfix"></div>
                    </div>
                    <div class="groupPart">
                        <label class="oiioLbl">Youtube Url</label>
                        <div class="row">
                            <div class="col-sm-4 col-md-4 col-lg-4">
                                <asp:TextBox ID="txtYoutubeUrl" runat="server" placeholder="https://www.youtube.com" CssClass="form-control oiioPostFcnt"></asp:TextBox>
                            </div>
                            <div class="col-sm-8 col-md-8 col-lg-8">
                                <p>Enter your youtube link if you have.</p>
                            </div>
                        </div>

                        <div class="clearfix"></div>
                    </div>
                </div>


                <h3 class="panel-title">Your Contact Details</h3>
                <div class="panelPostBody">
                    <div class="groupPart">
                        <div class="col-sm-4 col-md-4 col-lg-4">
                            <p>
                                <asp:Label ID="lblAdGiverInfo" runat="server" Text=""></asp:Label>
                            </p>
                            <div class="btn-group" data-toggle="buttons">
                                <label>
                                    Your Email
                                </label>

                            </div>
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control oiioPostFcnt " ReadOnly="true"></asp:TextBox>
                            <asp:Label ID="lblEmail" runat="server"></asp:Label>
                            <br />

                            <div class="btn-group" data-toggle="buttons">
                                <label>
                                    Your Contact Number
                                </label>

                            </div>
                            <asp:TextBox ID="txtPhoneNumber" runat="server" CssClass="form-control oiioPostFcnt" TextMode="Phone"></asp:TextBox>
                            <asp:Label ID="lblPhoneNumber" runat="server"></asp:Label>
                            <ajaxConTK:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                TargetControlID="txtPhoneNumber" FilterType="Custom, Numbers" ValidChars="." />
                            <br />

                            <div class="btn-group" data-toggle="buttons">
                                <label>
                                    Your Name
                                </label>

                            </div>

                            <asp:TextBox ID="txtUserID" ReadOnly="True" runat="server" Text="" class="form-control oiioPostFcnt" placeholder="Enter you email address..."></asp:TextBox>


                        </div>
                        <div class="col-sm-8 col-md-8 col-lg-8">
                            <div class="well">

                                <p>Check for spelling and grammatical errors.</p>
                                <p>Make sure all details are up to date and be careful not to overload your profile with too much text.</p>
                                <p>Only use experience that you have had in the last 5 years or that shows an unusual talent</p>
                                <p>Keep your format consistent.</p>


                            </div>
                        </div>
                        <div class="clearfix"></div>
                    </div>

                </div>



                <div class="col-sm-12" style="margin-top: 10px;">
                    <p>
                        By clicking post my add you agree to OiiO Haat's terms & condition, privacy policy and posting rules.
                    </p>

                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click"
                        CssClass="btn btn-info pull-right" BorderWidth="5px" BorderColor="WhiteSmoke" />
                    &nbsp;

                            <asp:Button ID="btnPostAd" runat="server" Text="Post Ad" OnClick="btnPostAd_Click" CssClass="btn btn-primary btn-info pull-right"
                                ValidationGroup="gen" BorderWidth="5px" BorderColor="WhiteSmoke"></asp:Button>

                    <asp:HiddenField runat="server" ID="hdMaterialID" />
                    <asp:HiddenField runat="server" ID="hdIsEdit" />
                    <asp:HiddenField runat="server" ID="hdCountryID" />

                    <asp:ValidationSummary
                        ShowMessageBox="true"
                        ShowSummary="false"
                        HeaderText="You must enter a value in the following fields:"
                        EnableClientScript="true"
                        runat="server" ValidationGroup="gen" />


                    <div class="row" style="visibility: hidden; display: none">
                        <div class="col-xs-12">
                            <asp:CheckBox ID="chkIsUrgent" runat="server" Text="Urgent" CssClass="checkbox-inline"></asp:CheckBox>
                        </div>
                        <div class="col-xs-12">
                            <asp:CheckBox ID="chkIsFeatured" runat="server" Text="Featured" CssClass="checkbox-inline"></asp:CheckBox>
                        </div>
                        <div class="col-xs-12">
                            <asp:CheckBox ID="chkIsSpotlight" runat="server" Text="Spotlight" CssClass="checkbox-inline"></asp:CheckBox>
                        </div>
                    </div>

                    <div id="divBrand" runat="server" class="form-group ">
                        <div class="input-group">
                            <span class="input-group-addon">Brand
                            </span>
                            <asp:TextBox ID="txtBrand" runat="server" Text="" class="form-control" placeholder="Enter Brand..."></asp:TextBox>
                        </div>
                    </div>
                    <div style="visibility: hidden; display: none">
                        <%--  <asp:TextBox ID="txtBrandID" runat="server" Text=""></asp:TextBox>--%>
                        <asp:HiddenField ID="txtBrandID" runat="server" />
                    </div>

                    <div id="divModel" runat="server" class="form-group">
                        <div class="input-group">
                            <span class="input-group-addon">Model
                            </span>
                            <asp:TextBox ID="txtModel" runat="server" Text="" class="form-control" placeholder="Enter Model..."></asp:TextBox>
                        </div>
                    </div>
                    <div style="visibility: hidden; display: none">
                        <%--  <asp:TextBox ID="txtModelID" runat="server" Text=""></asp:TextBox>--%>
                        <asp:HiddenField ID="txtModelID" runat="server" />

                    </div>

                    <div id="divColor" runat="server" class="form-group">
                        <div class="input-group">
                            <span class="input-group-addon">Color
                            </span>
                            <asp:TextBox ID="txtColor" runat="server" Text="" class="form-control" placeholder="Select Color..."></asp:TextBox>
                        </div>
                    </div>
                    <div style="visibility: hidden; display: none">
                        <%--<asp:TextBox ID="txtColorID" runat="server" Text=""></asp:TextBox>--%>
                        <asp:HiddenField ID="txtColorID" runat="server" />
                    </div>

                </div>
            </div>
        </div>
        <%-- </ContentTemplate>
        </asp:UpdatePanel>--%>
    </section>

    
</asp:Content>

