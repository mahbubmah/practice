<%@ Page Title="" Language="C#" MasterPageFile="~/InnerMasterPage.Master" AutoEventWireup="true" CodeBehind="PostAnAdd.aspx.cs" Inherits="OH.Web.PostAnAdd" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headInner" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentInnerMain" runat="server">

    <section style="background: #f9f9f9;">
        <div class="container postAddInfoHead">
            <div class="row">
                <div class="col-md-12">
                    <h2>Add Posting Information</h2>

                </div>
            </div>
        </div>

        <div class="container postAddInfo ">

            <div class="row">
                <div class="col-md-12">
                    <h3 class="panel-title">Post an add with your category</h3>
                    <div class="panelPostBody">
                        <div class="groupPart">
                            <label class="oiioLbl">Category</label>
                            <div class="row">
                                <div class="col-sm-4 col-md-4 col-lg-4">
                                    <asp:DropDownList ID="ddlAllParentCategory" runat="server" CssClass="form-control oiioPostFcnt">
                                        <asp:ListItem Value="For Sell" Text="For Sell"></asp:ListItem>
                                        <asp:ListItem Value="Jobs" Text="Jobs"></asp:ListItem>
                                        <asp:ListItem Value="Properties" Text="Properties"></asp:ListItem>
                                        <asp:ListItem Value="Motors" Text="Motors"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="clearfix"></div>
                        </div>

                        <div class="groupPart">
                            <label class="oiioLbl">Sub Category</label>
                            <div class="row">
                                <div class="col-sm-4 col-md-4 col-lg-4">
                                    <asp:DropDownList ID="ddlChildCategoryParentWise" runat="server" CssClass="form-control oiioPostFcnt">
                                        <asp:ListItem Value="Health and Beauty" Text="Health and Beauty"></asp:ListItem>
                                        <asp:ListItem Value="Books" Text="Books"></asp:ListItem>
                                        <asp:ListItem Value="Music and games" Text="Music and games"></asp:ListItem>
                                        <asp:ListItem Value="Pleasure and Travel" Text="Pleasure and Travel"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="clearfix"></div>
                        </div>

                        <div class="groupPart">
                            <label class="oiioLbl">Add Referance Code</label>
                            <div class="row">
                                <div class="col-sm-4 col-md-4 col-lg-4">
                                    <asp:TextBox ID="txtReferenceCode" runat="server" CssClass="form-control oiioPostFcnt" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>

                            <div class="clearfix"></div>
                        </div>

                    </div>

                    <h3 class="panel-title">Add Posting Details</h3>
                    <div class="panelPostBody">
                        <div class="groupPart">
                            <label class="oiioLbl">Add Title name</label>
                            <div class="row">
                                <div class="col-sm-4 col-md-4 col-lg-4">
                                    <asp:TextBox ID="txtAddTitle" runat="server" CssClass="form-control oiioPostFcnt"></asp:TextBox>
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
                                    <%-- <textarea class="form-control txtAra" rows="3"></textarea>--%>
                                    <CKEditor:CKEditorControl ID="txtAddDiscription" BasePath="/ckeditor/" runat="server">
                                    </CKEditor:CKEditorControl>

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
                                        <div class="form-group">
                                            <input type="file" name="files[]" id="js-upload-files" />
                                        </div>
                                        <button type="submit" class="btn btn-sm btn-primary" id="js-upload-submit">Add images</button>
                                    </div>
                                    <%--   <textarea class="form-control txtAra" rows="3"></textarea>--%>
                                </div>
                                <div class="col-sm-8 col-md-8 col-lg-8">
                                    <p>
                                        Upload clear images as many as posible which will increase your chances for 
                                        product to be sold quickly.
                                    </p>
                                </div>
                                <div class=" col-sm-12 col-md-12 col-lg-12" style="width: 97%; min-height: 100px; border: 1px solid #F3F3F3; margin-left: 15px;">
                                </div>
                            </div>

                            <div class="clearfix"></div>
                        </div>
                        <div class="groupPart">
                            <label class="oiioLbl">Price of product</label>
                            <div class="row">
                                <div class="col-sm-4 col-md-4 col-lg-4">
                                    <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control oiioPostFcnt" TextMode="Number"></asp:TextBox>
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
                                    <asp:TextBox ID="txtPostVisibilityDays" runat="server" CssClass="form-control oiioPostFcnt" TextMode="Number"></asp:TextBox>
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
                    <div class="panelPostBody">
                        <div class="groupPart">
                            <label class="oiioLbl">Please enter your district name</label>
                            <div class="row">
                                <div class="col-sm-4 col-md-4 col-lg-4">
                                    <asp:DropDownList ID="ddlAllDistrict" runat="server" CssClass="form-control oiioPostFcnt">
                                        <asp:ListItem Value="Dhaka" Text="Dhaka"></asp:ListItem>
                                        <asp:ListItem Value="Khulna" Text="Khulna"></asp:ListItem>
                                        <asp:ListItem Value="Rajshahi" Text="Rajshahi"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="clearfix"></div>
                        </div>
                        <div class="groupPart">
                            <label class="oiioLbl">Please select your police station</label>
                            <div class="row">
                                <div class="col-sm-4 col-md-4 col-lg-4">
                                    <asp:DropDownList ID="ddlPolicsStation" runat="server" CssClass="form-control oiioPostFcnt">
                                        <asp:ListItem Value="Mirpur" Text="Mirpur"></asp:ListItem>
                                        <asp:ListItem Value="Darussalam" Text="Darussalam"></asp:ListItem>
                                        <asp:ListItem Value="Uttara" Text="Uttara"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="clearfix"></div>
                        </div>


                        <div class="groupPart">
                            <label class="oiioLbl">Specific location</label>
                            <div class="row">
                                <div class="col-sm-4 col-md-4 col-lg-4">
                                    <textarea id="txtSpecificLocation" runat="server" class="form-control txtAra"></textarea>
                                </div>
                                <div class="col-sm-8 col-md-8">
                                    <p>You have to mantion your specific location.</p>
                                </div>
                            </div>

                            <div class="clearfix"></div>
                        </div>

                    </div>


                    <h3 class="panel-title">Linkupg</h3>
                    <div class="panelPostBody">
                        <div class="groupPart">
                            <label class="oiioLbl">Website Url</label>
                            <div class="row">
                                <div class="col-sm-4 col-md-4 col-lg-4">
                                    <asp:TextBox ID="txtWeburl" runat="server" placeholder="www.oiiohaat.com" CssClass="form-control oiioPostFcnt"></asp:TextBox>
                                </div>
                                <div class="col-sm-8 col-md-8 col-lg-8">
                                    <p>Enter your website link if you have.</p>
                                </div>
                            </div>

                            <div class="clearfix"></div>
                        </div>
                        <div class="groupPart">
                            <label class="oiioLbl">Youtube Url</label>
                            <div class="row">
                                <div class="col-sm-4 col-md-4 col-lg-4">
                                    <asp:TextBox ID="txtYoutubeUrl" runat="server" placeholder="www.youtube.com" CssClass="form-control oiioPostFcnt"></asp:TextBox>
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
                                <p>Please select at least one option to be contacted by.</p>

                                <div class="btn-group" data-toggle="buttons">
                                    <label class="btn btn-default">
                                        <asp:CheckBox ID="chkEmail" runat="server" autocomplete="off" />
                                        <span class="glyphicon glyphicon-ok"></span>
                                    </label>

                                </div>
                                <div class="btn-group" data-toggle="buttons">
                                    <label>
                                        Email
                                    </label>

                                </div>
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control oiioPostFcnt"></asp:TextBox>
                                <br />

                                <div class="btn-group" data-toggle="buttons">
                                    <label class="btn btn-default">
                                        <asp:CheckBox ID="chkPhoneNumber" runat="server" autocomplete="off" />
                                        <span class="glyphicon glyphicon-ok"></span>
                                    </label>

                                </div>
                                <div class="btn-group" data-toggle="buttons">
                                    <label>
                                        Contact Number
                                    </label>

                                </div>
                                <asp:TextBox ID="txtPhoneNumber" runat="server" CssClass="form-control oiioPostFcnt"></asp:TextBox>
                                <br />

                                <div class="btn-group" data-toggle="buttons">
                                    <label>
                                        User Name
                                    </label>

                                </div>
                                <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control oiioPostFcnt"></asp:TextBox>



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

                </div>

                <div class="col-sm-12" style="margin-top: 10px;">
                    <p>
                        By clicking post my add you agree to OiiO Haat's terms & condition, privacy policy and posting rules.
                        <input type="button" class="btn btn-info pull-right" name="dedr" value="Post my add" />
                    </p>


                </div>
            </div>

        </div>

    </section>
</asp:Content>
