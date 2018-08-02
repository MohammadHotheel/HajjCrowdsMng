<%@ Page Title='<%$ Resources:HCMResource, SSAMang %>' Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SSAAdmin.aspx.cs" Inherits="HCM.WebApp.SSA.SSAAdmin" %>

<%@ Register Src="~/UC/ucAlertMessage.ascx" TagPrefix="uc1" TagName="ucAlertMessage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <hr />
    <%--<div class="row">
        <div class="col-md-4">
            <p>
                <a class="btn btn-secondary" href="/SSA/SSAProfile.aspx"><%= GetGlobalResourceObject("HCMResource","Profile") %> &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <p>
                <a class="btn btn-secondary" href="/SSA/FAQList.aspx"><%= GetGlobalResourceObject("HCMResource","FAQ") %> &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <p>
                <a class="btn btn-secondary" href="/SSA/ServiceInfoList.aspx"><%= GetGlobalResourceObject("HCMResource","ServiceInfo") %> &raquo;</a>
            </p>
        </div>
    </div>--%>

    <div class="list-group">
        <a class="btn btn-secondary list-group-item list-group-item-action active" runat="server" href="~/SSA/SSAProfile.aspx"><%= GetGlobalResourceObject("HCMResource","Profile") %> &raquo;</a>
        <br />
        <a class="btn btn-secondary list-group-item list-group-item-action active" runat="server" href="~/SSA/FAQList.aspx"><%= GetGlobalResourceObject("HCMResource","FAQ") %> &raquo;</a>
        <br />
        <a class="btn btn-secondary list-group-item list-group-item-action active" runat="server" href="~/SSA/ServiceInfoList.aspx"><%= GetGlobalResourceObject("HCMResource","ServiceInfo") %> &raquo;</a>
    </div>

</asp:Content>
