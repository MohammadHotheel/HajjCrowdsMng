<%@ Page Title='<%$ Resources:HCMResource, Contact %>' Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="HCM.WebApp.Contact" %>

<%@ Register Src="~/UC/ucSendMsg.ascx" TagPrefix="uc1" TagName="ucSendMsg" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <hr />
    <h3>Murray State University</h3>
    <address>
        Dalal Al Faia<br />
        Supervised by: Dr. Solomon Antony
    </address>
    <uc1:ucSendMsg runat="server" ID="ucSendMsg" />
</asp:Content>
