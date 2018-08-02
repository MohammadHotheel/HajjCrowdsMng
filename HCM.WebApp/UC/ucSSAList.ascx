<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucSSAList.ascx.cs" Inherits="HCM.WebApp.UC.ucSSAList" %>

<%--<ul class="list-group">
    <asp:Repeater ID="rptdata" runat="server">
        <ItemTemplate>
            <li class="list-group-item d-flex justify-content-between align-items-center"><%# Eval("University") %>
                <span class="badge badge-primary badge-pill"><%# Eval("ServiceCount") %></span>
            </li>
        </ItemTemplate>
    </asp:Repeater>
</ul>--%>

<ul class="list-group">
    <li class="list-group-item d-flex justify-content-between align-items-center"><%= GetGlobalResourceObject("HCMResource","AssCount") %>
        <span class="badge badge-primary badge-pill"><%= AssCount %></span>
    </li>
    <li class="list-group-item d-flex justify-content-between align-items-center"><%= GetGlobalResourceObject("HCMResource","SvcInfoCount") %>
        <span class="badge badge-primary badge-pill"><%= SvcInfoCount %></span>
    </li>
</ul>

