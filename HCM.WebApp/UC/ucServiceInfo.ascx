<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucServiceInfo.ascx.cs" Inherits="HCM.WebApp.UC.ucServiceInfo" %>
<%@ Register Src="~/UC/ucLocationsMap.ascx" TagPrefix="uc1" TagName="ucLocationsMap" %>
<%@ Register Src="~/UC/ucServiceDetails.ascx" TagPrefix="uc1" TagName="ucServiceDetails" %>


<div class="row">
    <div class="col-md-12">
        <div class="form-group row">
            <asp:Label runat="server" AssociatedControlID="ddlServiceCategory" CssClass="col-sm-2 col-form-label"><%= GetGlobalResourceObject("HCMResource","SelectCat") %></asp:Label>
            <div class="col-sm-4">
                <asp:DropDownList ID="ddlServiceCategory" runat="server" CssClass="form-control" AppendDataBoundItems="True" AutoPostBack="true" OnSelectedIndexChanged="ddlServiceCategory_SelectedIndexChanged">
                    <asp:ListItem Value="0" Text='<%$ Resources:HCMResource, AllCat %>'></asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
    </div>
</div>
<div class="row">
    <div class="col-md-12">
        <div class="form-horizontal">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%" DataKeyNames="Id"
                CssClass="table table-bordered responsive" PageSize="20" OnPageIndexChanging="GridView1_PageIndexChanging"
                OnRowCommand="GridView1_RowCommand" >
                <Columns>
                    <asp:TemplateField HeaderText="#">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                        <ItemStyle Width="20px" />
                    </asp:TemplateField>                    
                    <asp:BoundField DataField="ServiceCategory" HeaderText='<%$ Resources:HCMResource, ServiceCategory %>' />
                    <asp:BoundField DataField="Title" HeaderText='<%$ Resources:HCMResource, Title %>' />
                    <asp:BoundField DataField="Description" HeaderText='<%$ Resources:HCMResource, Description %>' />
                    <asp:BoundField DataField="Section" HeaderText='<%$ Resources:HCMResource, Section %>' />
                    <asp:BoundField DataField="Address" HeaderText='<%$ Resources:HCMResource, Address %>' />
                    <asp:TemplateField HeaderText='<%$ Resources:HCMResource, ServiceDetails %>'>
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkUpdate" runat="server" CausesValidation="False" CommandName="Details" CommandArgument='<%# Eval("Id") %>'>
                                <i class="entypo-pencil"></i>
                                <%= GetGlobalResourceObject("HCMResource","ServiceDetails") %> (<%# Eval("ServiceDetailsCount") %>)
                            </asp:LinkButton>
                        </ItemTemplate>
                        <ControlStyle Width="120px" CssClass="btn btn-default btn-sm btn-icon icon-left" />
                        <ItemStyle Width="120px" />
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    <%= GetGlobalResourceObject("HCMResource","NoData") %>
                </EmptyDataTemplate>
            </asp:GridView>
        </div>
    </div>
</div>
<div class="row">
    <div class="col-md-12">
        <hr />
        <uc1:ucServiceDetails runat="server" ID="ucServiceDetails" />  
        <hr />      
    </div>
</div>
<div class="row">
    <div class="col-md-12">
        <uc1:ucLocationsMap runat="server" ID="ucLocationsMap" />
    </div>
</div>
