<%@ Page Title='<%$ Resources:HCMResource, Associations %>' Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Associations.aspx.cs" Inherits="HCM.WebApp.Associations" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <hr />
    <form>
        <fieldset>
            <legend>
                <%= GetGlobalResourceObject("HCMResource","SSAList") %>
            </legend>            
            <div class="form-group row">
                <asp:Label runat="server" AssociatedControlID="ddlState" CssClass="col-md-1 control-label"><%= GetGlobalResourceObject("HCMResource","SelectState") %></asp:Label>
                <div class="col-md-3">
                    <asp:DropDownList ID="ddlState" runat="server" CssClass="form-control" AppendDataBoundItems="True"
                         AutoPostBack="true" OnSelectedIndexChanged="ddlState_SelectedIndexChanged">
                        <asp:ListItem Value="0" Text='<%$ Resources:HCMResource,  AllState %>'></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <asp:Label runat="server" AssociatedControlID="ddlCity" CssClass="col-md-1 control-label"><%= GetGlobalResourceObject("HCMResource","SelectCity") %></asp:Label>
                <div class="col-md-3">
                    <asp:DropDownList ID="ddlCity" runat="server" CssClass="form-control" AppendDataBoundItems="True"
                         AutoPostBack="true" OnSelectedIndexChanged="ddlCity_SelectedIndexChanged">
                        <asp:ListItem Value="0" Text='<%$ Resources:HCMResource,  AllCity %>'></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <asp:Label runat="server" AssociatedControlID="ddlServiceCategory" CssClass="col-md-1 control-label"><%= GetGlobalResourceObject("HCMResource","ServiceCategory") %></asp:Label>
                <div class="col-md-3">
                    <asp:DropDownList ID="ddlServiceCategory" runat="server" CssClass="form-control" AppendDataBoundItems="True"
                         AutoPostBack="true" OnSelectedIndexChanged="ddlServiceCategory_SelectedIndexChanged">
                        <asp:ListItem Value="0" Text='<%$ Resources:HCMResource,  AllCat %>'></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>

            <div class="row">
                <asp:Repeater ID="rptdata" runat="server">
                    <ItemTemplate>
                        <div class="col-md-6">
                            <div class="card text-white bg-secondary">
                                <div class="card-header"><strong><%# Eval("University") %></strong></div>
                                <div class="card-body">
                                    <h4 class="card-title">Name: <%# Eval("Name") %></h4>
                                    <p class="card-text">
                                        State: <%# Eval("State") %><br />
                                        City: <%# Eval("City") %><br />
                                        ZipCode: <%# Eval("ZipCode") %><br />
                                        Services Count: <span class="badge badge-primary badge-pill">(<%# Eval("ServiceCount") %>)</span>
                                    </p>
                                    <a href='<%# String.Format("SSAInfo?id={0}", Eval("Id")) %>' class="btn btn-primary">Details &raquo;</a>
                                </div>
                            </div>
                            <hr>
                            <%# (((Container.ItemIndex + 1) % 2) == 0 ? "</div><div class='row'>" : "")  %>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </fieldset>
    </form>

</asp:Content>
