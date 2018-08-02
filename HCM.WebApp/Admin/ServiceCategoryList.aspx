<%@ Page Title='<%$ Resources:HCMResource, ServiceCategoryMang %>' Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ServiceCategoryList.aspx.cs" Inherits="HCM.WebApp.SSA.ServiceCategoryList" %>

<%@ Register Src="~/UC/ucAlertMessage.ascx" TagPrefix="uc1" TagName="ucAlertMessage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <hr />
    <uc1:ucAlertMessage runat="server" ID="ucAlertMessage" />
    <div class="row">
        <div class="col-md-12">
            <form>
                <fieldset>
                    <legend><%= GetGlobalResourceObject("HCMResource","ServiceCategoryTitle") %></legend>
                    <div class="form-group row">
                        <div class="col-md-12">
                            <asp:LinkButton ID="lbAdd" runat="server" CssClass="btn btn-primary" Width="100px" PostBackUrl="~/Admin/ServiceCategoryMang.aspx">
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
                    <asp:TemplateField HeaderText='<%$ Resources:HCMResource, ServiceCategory %>'>
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkUpdate" runat="server" CausesValidation="False" PostBackUrl='<%# String.Format("~/Admin/ServiceCategoryMang.aspx?Id={0}", Eval("Id")) %>'
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
