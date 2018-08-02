<%@ Page Title='<%$ Resources:HCMResource, Navigation %>' Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Navigation.aspx.cs" Inherits="HCM.WebApp.Navigation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <form>
        <fieldset>
            <legend>
                <%= GetGlobalResourceObject("HCMResource","SSAList") %>
            </legend>
            <hr />

            <div class="form-group row">
                <asp:Label runat="server" AssociatedControlID="ddlState" CssClass="col-md-2 control-label"><%= GetGlobalResourceObject("HCMResource","SelectState") %></asp:Label>
                <div class="col-md-4">
                    <asp:DropDownList ID="ddlState" runat="server" CssClass="form-control" AppendDataBoundItems="True" AutoPostBack="true">
                        <asp:ListItem Value="0" Text='<%$ Resources:HCMResource,  AllState %>'></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <asp:Label runat="server" AssociatedControlID="ddlCity" CssClass="col-md-2 control-label"><%= GetGlobalResourceObject("HCMResource","SelectCity") %></asp:Label>
                <div class="col-md-4">
                    <asp:DropDownList ID="ddlCity" runat="server" CssClass="form-control" AppendDataBoundItems="True" AutoPostBack="true">
                        <asp:ListItem Value="0" Text='<%$ Resources:HCMResource,  AllCity %>'></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="form-group row">
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
                                    <a href='<%# String.Format("CompanyInfo.aspx?id={0}", Eval("Name")) %>' class="btn btn-primary">Details &raquo;</a>
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
