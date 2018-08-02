<%@ Page Title='<%$ Resources:HCMResource, AccountMang %>' Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageAccount.aspx.cs" Inherits="HCM.WebApp.Admin.ManageAccount" %>

<%@ Register Src="~/UC/ucAlertMessage.ascx" TagPrefix="uc1" TagName="ucAlertMessage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <hr />
    <uc1:ucAlertMessage runat="server" ID="ucAlertMessage" />
    <div class="row">
        <div class="col-md-12">
            <form>
                <fieldset>
                    <legend><%= GetGlobalResourceObject("HCMResource","AccountTitle") %></legend>
                    <div class="form-group row">
                        <label for="ddlUserType" class="col-md-1 control-label"><%= GetGlobalResourceObject("HCMResource","UserType") %></label>
                        <div class="col-md-3">
                            <asp:DropDownList ID="ddlUserType" runat="server" CssClass="form-control" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="ddlUserType_SelectedIndexChanged">
                                <asp:ListItem Value="0" Text='<%$ Resources:HCMResource, All %>'></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <label for="ddlPermmisions" class="col-md-1 control-label"><%= GetGlobalResourceObject("HCMResource","Permmisions") %></label>
                        <div class="col-md-3">
                            <asp:DropDownList ID="ddlPermmisions" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlPermmisions_SelectedIndexChanged">
                                <asp:ListItem Value="-1" Text='<%$ Resources:HCMResource, All %>'></asp:ListItem>
                                <asp:ListItem Value="1" Text='<%$ Resources:HCMResource, HavePermmisions %>'></asp:ListItem>
                                <asp:ListItem Value="0" Text='<%$ Resources:HCMResource, NotHavePermmisions %>'></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <label for="ddlActive" class="col-md-1 control-label"><%= GetGlobalResourceObject("HCMResource","Active") %></label>
                        <div class="col-md-3">
                            <asp:DropDownList ID="ddlActive" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlActive_SelectedIndexChanged">
                                <asp:ListItem Value="-1" Text='<%$ Resources:HCMResource, All %>'></asp:ListItem>
                                <asp:ListItem Value="1" Text='<%$ Resources:HCMResource, Active %>'></asp:ListItem>
                                <asp:ListItem Value="0" Text='<%$ Resources:HCMResource, NotActive %>'></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>

                </fieldset>
            </form>
        </div>
    </div>
     <div class="row">
        <div class="col-md-12">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%" AllowPaging="true"
                OnRowCommand="GridView1_RowCommand" OnPageIndexChanging="GridView1_PageIndexChanging" >
                <Columns>
                    <asp:TemplateField HeaderText='<%$ Resources:HCMResource, Index %>'>
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                        <ItemStyle Width="20px" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="FullName" HeaderText='<%$ Resources:HCMResource, FullName %>' />
                    <asp:BoundField DataField="Email" HeaderText='<%$ Resources:HCMResource, Email %>' />
                    <asp:BoundField DataField="UserName" HeaderText='<%$ Resources:HCMResource, UserName %>' />
                    <asp:BoundField DataField="Mobile" HeaderText='<%$ Resources:HCMResource, Mobile %>' />
                    <asp:BoundField DataField="University" HeaderText='<%$ Resources:HCMResource, University %>' />
                    <asp:TemplateField ShowHeader="true" HeaderText='<%$ Resources:HCMResource, Permmisions %>'>
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkGrantPermission" runat="server" CausesValidation="False" OnClientClick='<%$ Resources:HCMResource, GrantPermissionConfirm %>'
                                CommandName="GrantPermission" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-default btn-sm"
                                Visible='<%# (Eval("Active").ToString() == "False") %>' >
                                <%# GetGlobalResourceObject("HCMResource","GrantPermission") %>
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="true" HeaderText='<%$ Resources:HCMResource, Roles %>'>
                        <ItemTemplate>
                            <asp:Repeater ID="repRole" runat="server" DataSource='<%# Eval("AspNetRoles") %>'>
                                <ItemTemplate>
                                    <%--<%# GetRoleNameByRoleId(Eval("Id").ToString()) %><br />--%>
                                    <%# Eval("Name").ToString() %><br />
                                </ItemTemplate>
                            </asp:Repeater>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="true" HeaderText="Active/Lock">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkActive" runat="server" CausesValidation="False" OnClientClick='<%$ Resources:HCMResource, ActiveConfirm %>'
                                CommandName="ActiveUser" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-default btn-sm">
                                <%# ((Eval("LockoutEndDateUtc") != null ? Convert.ToDateTime(Eval("LockoutEndDateUtc")).ToString("d") : "") != "" ? GetGlobalResourceObject("HCMResource","Active") : GetGlobalResourceObject("HCMResource","Lock")) %>
                            </asp:LinkButton>
                            <%--<%# (Eval("LockoutEndDateUtc") != null ? GetGlobalResourceObject("HCMResource","LockDate") + ":" + Convert.ToDateTime(Eval("LockoutEndDateUtc")).ToString("d") : "") %>--%>
                        </ItemTemplate>
                        <ControlStyle Width="100px" />
                        <ItemStyle Width="100px" HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    No Data ....
                </EmptyDataTemplate>
                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Center" />
            </asp:GridView>
        </div>
    </div>
</asp:Content>
