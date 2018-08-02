<%@ Page Title='<%$ Resources:HCMResource, Home %>' Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HCM.WebApp._Default" %>

<%@ Register Src="~/UC/ucSSAList.ascx" TagPrefix="uc1" TagName="ucSSAList" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1 class="display-4"><%= GetGlobalResourceObject("HCMResource","SSACP") %></h1>
        <p class="lead"><%= GetGlobalResourceObject("HCMResource","SSACPDesc") %></p>
        <hr class="my-4">
        <div class="row">
            <div class="col-md-6">
                <p><%= GetGlobalResourceObject("HCMResource","RegisterDesc") %></p>
                <p class="lead">
                    <a class="btn btn-primary btn-lg" href="Account/Register.aspx" role="button"><%= GetGlobalResourceObject("HCMResource","Register") %></a>
                </p>
            </div>
            <div class="col-md-6">
                <p><%= GetGlobalResourceObject("HCMResource","AboutUsDesc") %></p>
                <p class="lead">
                    <a class="btn btn-primary btn-lg" href="About.aspx" role="button"><%= GetGlobalResourceObject("HCMResource","AboutUs") %></a>
                </p>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <h2><%= GetGlobalResourceObject("HCMResource","Notification") %></h2>
            <p>
                <%= GetGlobalResourceObject("HCMResource","NotificationDesc") %>
            </p>
            <p>
                <a class="btn btn-secondary" href="Notification.aspx"><%= GetGlobalResourceObject("HCMResource","Go") %> &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2><%= GetGlobalResourceObject("HCMResource","Search") %></h2>
            <p>
                <%= GetGlobalResourceObject("HCMResource","SearchDesc") %>
            </p>
            <p>
                <a class="btn btn-secondary" href="Search.aspx"><%= GetGlobalResourceObject("HCMResource","Go") %> &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2><%= GetGlobalResourceObject("HCMResource","Statistics") %></h2>
            <p>
                <uc1:ucSSAList runat="server" ID="ucSSAList" />
            </p>
            <%--<h2><%= GetGlobalResourceObject("HCMResource","Navigation") %></h2>
            <p>
                <%= GetGlobalResourceObject("HCMResource","NavigationDesc") %>
            </p>
            <p>
                <a class="btn btn-secondary" href="Navigation.aspx"><%= GetGlobalResourceObject("HCMResource","Open") %> &raquo;</a>
            </p>--%>
        </div>
    </div>

</asp:Content>
