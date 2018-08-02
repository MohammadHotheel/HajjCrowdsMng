<%@ Page Title='<%$ Resources:HCMResource, FAQ %>' Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FAQ.aspx.cs" Inherits="HCM.WebApp.FAQ" %>
<%@ Register Src="~/UC/ucFAQ.ascx" TagPrefix="uc1" TagName="ucFAQ" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <form>
        <fieldset>            
            <uc1:ucFAQ runat="server" id="ucFAQ" />
        </fieldset>
    </form>
</asp:Content>
