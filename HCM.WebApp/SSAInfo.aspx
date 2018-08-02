<%@ Page Title='<%$ Resources:HCMResource, SSAInfo %>' Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SSAInfo.aspx.cs" Inherits="HCM.WebApp.SSAInfo" %>

<%@ Register Src="~/UC/ucSSA.ascx" TagPrefix="uc1" TagName="ucSSA" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <hr />
    <form>
        <fieldset>
            <%--<legend>
                <%= GetGlobalResourceObject("HCMResource","SSAInfo") %>
            </legend>--%>
            <uc1:ucSSA runat="server" ID="ucSSA" />
        </fieldset>
    </form>
</asp:Content>
