<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CardFeatureInsertPopupForCardInfo.aspx.cs" Inherits="OMart.Web.AdminPanel.CardFeatureInsertPopupForCardInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <%--<meta http-equiv="X-UA-Compatible" content="IE=edge" />--%>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />

    <asp:PlaceHolder runat="server">
        <%: Scripts.Render("~/bundles/modernizr") %>
    </asp:PlaceHolder>

    <title>OiiO Mart</title>
    <%--<link href='http://fonts.googleapis.com/css?family=Advent+Pro:400,100,200,300,700,600,500' rel='stylesheet' type='text/css' />
    <link href='http://fonts.googleapis.com/css?family=Open+Sans:400,300,300italic,400italic,600,600italic,700,700italic,800italic,800' rel='stylesheet' type='text/css' />
    <link href='http://fonts.googleapis.com/css?family=Oswald:400,300,700' rel='stylesheet' type='text/css' />
    <link href='http://fonts.googleapis.com/css?family=Contrail+One' rel='stylesheet' type='text/css' />--%>
    <%--<link href='http://fonts.googleapis.com/css?family=Orbitron:400,500,900,700' rel='stylesheet' type='text/css' />
        @123456780#biswas
    --%>

    <link href="//maxcdn.bootstrapcdn.com/font-awesome/4.3.0/css/font-awesome.min.css" rel="stylesheet" />
    <link href='http://fonts.googleapis.com/css?family=Orbitron:400,500,700,900' rel='stylesheet' type='text/css' />

    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <link href="../Content/bootstrap.css" rel="stylesheet" />
    <link href="../Content/oiioStyle.css" rel="stylesheet" />
    <link href="../Content/screen.css" rel="stylesheet" />
    <link href="../Content/Admin_Menu.css" rel="stylesheet" />
    <script src="../Scripts/jquery-1.10.2.js" type="text/javascript"></script>
</head>
<body>
    <br />
    <form id="form1" runat="server">
        <div>
            <section>
                <fieldset class="adminFieldset col-sm-9 col-md-9">
                    <legend>Add/Edit card feature</legend>
                  
                    <asp:Label runat="server" ID="labelMessage"></asp:Label>
                    <div class="row">
                        <div class="form-group">
                            <div class="col-sm-12 col-md-12">
                                <asp:Label ID="Label22" runat="server" CssClass="control-label">Description (Optional)</asp:Label>
                                <asp:TextBox TextMode="MultiLine" ID="txtDescription" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="form-group">
                            <div class="col-sm-12 col-md-12 ">
                                <asp:Button ID="Button1" runat="server" class="btn btn-primary pull-right" Text="Add feature" OnClick="btn_CreateOrEdit_Click"
                                    ValidationGroup="gen"></asp:Button>
                            </div>
                        </div>
                    </div>
                </fieldset>
                <br />


                <fieldset class="adminFieldset col-sm-9 col-md-9">
                    <legend>Card feature List</legend>

                    <asp:ListView ID="lvCardFeature" runat="server" DataKeyNames="IID"
                        OnPagePropertiesChanging="lvCardFeature_PagePropertiesChanging" OnPreRender="dataPagerCardFeature_PreRender">
                        <LayoutTemplate>
                            <table class="table  table-hover table-bordered">
                                <thead>
                                    <tr runat="server">
                                        <th class="col-xs-1">SL #
                                        </th>
                                        <th class="col-xs-7">Description
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
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                                </td>

                                <td>
                                    <p data-placement="top" data-toggle="tooltip" title="Delete">
                                        <asp:LinkButton ID="lnkbDelete" runat="server" CausesValidation="false" class="btn btn-danger btn-xs" data-title="Delete" 
                                            CommandArgument='<%# Bind("Description") %>' OnClick="lnkbDelete_Click"><i class="fa fa-trash"></i></asp:LinkButton>
                                    </p>
                                </td>
                            </tr>
                        </ItemTemplate>
                      
                    </asp:ListView>
                </fieldset>


            </section>
        </div>
    </form>
</body>
</html>
