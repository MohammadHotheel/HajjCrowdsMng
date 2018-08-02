<%@ Page Title='<%$ Resources:HCMResource, FollowUpMessage %>' Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FollowUpMessage.aspx.cs" Inherits="HCM.WebApp.Admin.FollowUpMessage" %>

<%@ Register Src="~/UC/ucAlertMessage.ascx" TagPrefix="uc1" TagName="ucAlertMessage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <hr />
    <uc1:ucAlertMessage runat="server" ID="ucAlertMessage" />
    <div class="row">
        <div class="col-md-12">
            <form>
                <fieldset>
                    <legend><%= GetGlobalResourceObject("HCMResource","FollowUpMessageTitle") %></legend>
                    <div class="form-group row">
                        <label for="ddlMessageType" class="col-md-2 control-label"><%= GetGlobalResourceObject("HCMResource","MessageType") %></label>
                        <div class="col-md-4">
                            <asp:DropDownList ID="ddlMessageType" runat="server" CssClass="form-control" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="ddlMessageType_SelectedIndexChanged">
                                <asp:ListItem Value="0" Text='<%$ Resources:HCMResource, All %>'></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <label for="ddlStatus" class="col-md-2 control-label"><%= GetGlobalResourceObject("HCMResource","Status") %></label>
                        <div class="col-md-4">
                            <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged">
                                <asp:ListItem Value="-1" Text='<%$ Resources:HCMResource, All %>'></asp:ListItem>
                                <asp:ListItem Value="1" Text='<%$ Resources:HCMResource, Close  %>'></asp:ListItem>
                                <asp:ListItem Value="0" Text='<%$ Resources:HCMResource, Open %>'></asp:ListItem>
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
                    <asp:BoundField DataField="MessageText" HeaderText='<%$ Resources:HCMResource, Message %>' />
                    <asp:BoundField DataField="MessageType" HeaderText='<%$ Resources:HCMResource, MessageType %>' />
                    <asp:BoundField DataField="SenderName" HeaderText='<%$ Resources:HCMResource, FullName %>' />
                    <asp:BoundField DataField="SenderEmail" HeaderText='<%$ Resources:HCMResource, Email %>' />
                    <asp:BoundField DataField="SenderMobile" HeaderText='<%$ Resources:HCMResource, Mobile %>' />                    
                    <asp:TemplateField ShowHeader="true" HeaderText='<%$ Resources:HCMResource, Status %>'>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("Status").ToString() == "False" ? GetGlobalResourceObject("HCMResource","Open") : GetGlobalResourceObject("HCMResource","Close") %>'></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Width="100px" />
                        <ItemStyle Width="100px" HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="true" HeaderText='<%$ Resources:HCMResource, Action  %>'>
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkGrantPermission" runat="server" CausesValidation="False" OnClientClick='<%$ Resources:HCMResource, CloseConfirm %>'
                                CommandName="Close" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-default btn-sm"
                                Visible='<%# (Eval("Status").ToString() == "False") %>' >
                                <%# GetGlobalResourceObject("HCMResource","Close") %>
                            </asp:LinkButton>                            
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    <%# GetGlobalResourceObject("HCMResource","NoData") %>
                </EmptyDataTemplate>
                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Center" />
            </asp:GridView>
        </div>
    </div>
</asp:Content>
