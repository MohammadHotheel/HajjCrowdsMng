<%@ Page Title='<%$ Resources:HCMResource, ServiceDetailsMang %>' Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ServiceDetailsList.aspx.cs" Inherits="HCM.WebApp.SSA.ServiceDetailsList" %>

<%@ Register Src="~/UC/ucAlertMessage.ascx" TagPrefix="uc1" TagName="ucAlertMessage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <hr />
    <uc1:ucAlertMessage runat="server" ID="ucAlertMessage" />
    <div class="row">
        <div class="col-md-12">
            <form>
                <fieldset>
                    <legend><%= GetGlobalResourceObject("HCMResource","ServiceDetailsTitle") %></legend>
                    <div class="form-group row">
                        <label for="lblSSA" class="col-md-4 control-label"><%= GetGlobalResourceObject("HCMResource","SSA") %></label>
                        <div class="col-md-8">
                            <asp:Label ID="lblSSA" runat="server" Text=""></asp:Label>
                        </div>
                        <label for="lblServiceInfo" class="col-md-4 control-label"><%= GetGlobalResourceObject("HCMResource","ServiceInfo") %></label>
                        <div class="col-md-8">
                            <asp:Label ID="lblServiceInfo" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                    <div class="form-group row">
                        <div class="col-md-12">
                            <a href="../SSA/ServiceInfoList.aspx" class="btn btn-secondary" style="width: 100px"><< <%= GetGlobalResourceObject("HCMResource","Return") %></a>
                            <asp:LinkButton ID="lbAdd" runat="server" CssClass="btn btn-primary" Width="100px" PostBackUrl="~/SSA/ServiceDetailsMang.aspx" >
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
                    <asp:TemplateField HeaderText='<%$ Resources:HCMResource, InfoType %>'>
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%# Eval("InfoType") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                   <asp:TemplateField HeaderText='<%$ Resources:HCMResource, InformationContent %>'>
                        <ItemTemplate>
                            <%--<asp:Label runat="server" Text='<%# Eval("InformationContent") %>'></asp:Label>--%>
                            <a ID="file" runat="server" CausesValidation="False" Visible='<%# (Eval("InfoTypeId").ToString() == "1" ? true : false) %>'
                                href='<%# Eval("InformationContent") %>' target="_blank">
                                <%# Eval("InformationContent") %>
                            </a>
                            <a ID="url" runat="server" CausesValidation="False" Visible='<%# (Eval("InfoTypeId").ToString() == "2" ? true : false) %>'
                                href='<%# String.Format("~/DetailsFiles/{0}_{1}.{2}", Eval("svcInfoId"), Eval("Id"), Eval("FileExt")) %>'  target="_blank">
                                <%--<%= GetGlobalResourceObject("HCMResource","Link") %>--%>
                                <%# Eval("InformationContent") %>
                            </a>                            
                            <asp:Image ID="Image1" runat="server" Width="200px" Height="200px" Visible='<%# (Eval("InfoTypeId").ToString() == "3" ? true : false) %>'
                                 ToolTip='<%# Eval("InformationContent") %>' ImageUrl='<%# String.Format("~/DetailsImages/{0}_{1}.{2}", Eval("svcInfoId"), Eval("Id"), Eval("FileExt")) %>' />
                        </ItemTemplate>
                        <ControlStyle Width="300px" CssClass="btn btn-default btn-sm btn-icon icon-left" />
                        <ItemStyle Width="300px" />
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkUpdate" runat="server" CausesValidation="False" PostBackUrl='<%# String.Format("~/SSA/ServiceDetailsMang.aspx?Id={0}", Eval("Id")) %>'
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
