<%@ Page Title='<%$ Resources:HCMResource, CP %>' Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CP.aspx.cs" Inherits="HCM.WebApp.Security.CP" %>

<%@ Register Src="~/UC/ucAlertMessage.ascx" TagPrefix="uc1" TagName="ucAlertMessage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <hr />
    <div class="list-group">
        <a class="btn btn-secondary list-group-item list-group-item-action active" runat="server" href="~/Security/NotificationList.aspx"><%= GetGlobalResourceObject("HCMResource","NotificationMang") %> &raquo;</a>
    <%--<br />
        <a class="btn btn-secondary list-group-item list-group-item-action active" runat="server" href="~/SSA/FAQList.aspx"><%= GetGlobalResourceObject("HCMResource","FAQ") %> &raquo;</a>
        <br />
        <a class="btn btn-secondary list-group-item list-group-item-action active" runat="server" href="~/SSA/ServiceInfoList.aspx"><%= GetGlobalResourceObject("HCMResource","ServiceInfo") %> &raquo;</a>--%>
    </div>

</asp:Content>
