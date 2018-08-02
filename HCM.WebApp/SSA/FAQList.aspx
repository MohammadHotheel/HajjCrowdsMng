<%@ Page Title='<%$ Resources:HCMResource, FAQMang %>' Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FAQList.aspx.cs" Inherits="HCM.WebApp.SSA.FAQList" %>

<%@ Register Src="~/UC/ucAlertMessage.ascx" TagPrefix="uc1" TagName="ucAlertMessage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <hr />
    <uc1:ucAlertMessage runat="server" ID="ucAlertMessage" />
    <div class="row">
        <div class="col-md-12">
            <form>
                <fieldset>
                    <legend><%= GetGlobalResourceObject("HCMResource","FAQTitle") %></legend>
                    <div class="form-group row" id="divAdminView" runat="server">
                        <label for="ddlSSA" class="col-md-4 control-label"><%= GetGlobalResourceObject("HCMResource","SSA") %></label>
                        <div class="col-md-8">
                            <asp:DropDownList ID="ddlSSA" runat="server" CssClass="form-control" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="ddlSSA_SelectedIndexChanged">
                                <asp:ListItem Value="0" Text='<%$ Resources:HCMResource, All %>'></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group row">
                        <div class="col-md-12">
                            <a href="../SSA/SSAAdmin.aspx" class="btn btn-secondary" style="width: 100px"><< <%= GetGlobalResourceObject("HCMResource","Return") %></a>
                            <asp:LinkButton ID="lbAdd" runat="server" CssClass="btn btn-primary" Width="100px" OnClick="lbAdd_Click">
                            <i class="entypo-pencil"></i>
                            <%= GetGlobalResourceObject("HCMResource","Add") %> >>
                            </asp:LinkButton>
                        </div>
                    </div>
                </fieldset>
            </form>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%"
                OnRowCommand="GridView1_RowCommand" CssClass="table table-bordered responsive" PageSize="20" OnPageIndexChanging="GridView1_PageIndexChanging">
                <Columns>
                    <asp:TemplateField HeaderText='<%$ Resources:HCMResource, Index %>'>
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                        <ItemStyle Width="20px" />
                    </asp:TemplateField>
                    <%--<asp:TemplateField HeaderText='<%$ Resources:HCMResource, SSA %>'>
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%# Eval("SSA") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                    <asp:TemplateField HeaderText='<%$ Resources:HCMResource, Question %>'>
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%# Eval("Question") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText='<%$ Resources:HCMResource, Answer %>'>
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%# Eval("Answer") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkUpdate" runat="server" CausesValidation="False" PostBackUrl='<%# String.Format("~/SSA/FAQMang.aspx?Id={0}", Eval("Id")) %>'
                                CommandName="Update" CommandArgument='<%# Eval("Id") %>'>
                                <i class="entypo-pencil"></i>
                                <%= GetGlobalResourceObject("HCMResource","Update") %>
                            </asp:LinkButton>
                        </ItemTemplate>
                        <ControlStyle Width="80px" CssClass="btn btn-default btn-sm btn-icon icon-left" />
                        <ItemStyle Width="80px" />
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkDelete" runat="server" CausesValidation="False" OnClientClick='<%$ Resources:HCMResource, DeleteConfirm %>'
                                CommandName="DeleteUpdate" CommandArgument='<%# Eval("Id") %>'>
                                <i class="entypo-cancel"></i>
                                <%= GetGlobalResourceObject("HCMResource","Delete") %>
                            </asp:LinkButton>
                        </ItemTemplate>
                        <ControlStyle Width="80px" CssClass="btn btn-default btn-sm btn-icon icon-left" />
                        <ItemStyle Width="80px" />
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    <%= GetGlobalResourceObject("HCMResource","NoData") %>
                </EmptyDataTemplate>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
