<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Notification.aspx.cs" Inherits="HCM.WebApp.Notification" %>
<%@ Register Src="~/UC/ucLocationsMap.ascx" TagPrefix="uc1" TagName="ucLocationsMap" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-12">
            <uc1:ucLocationsMap runat="server" ID="ucLocationsMap" />
        </div>
    </div>
</asp:Content>
