<%@ Page Title='<%$ Resources:HCMResource, Msg %>' Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Msg.aspx.cs" Inherits="HCM.WebApp.Msg" %>
<%@ Register Src="~/UC/ucAlertMessage.ascx" TagPrefix="uc1" TagName="ucAlertMessage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <hr />
    <div class="row">
        <div class="col-md-12">
            <form>
                <fieldset>
                    <legend><%= GetGlobalResourceObject("HCMResource","MsgTitle") %></legend>
                    <%--<div class="alert alert-dismissible alert-danger">
                        <button type="button" class="close" data-dismiss="alert">&times;</button>
                        <strong><%= GetGlobalResourceObject("HCMResource","AccountNotActive") %>.</strong>
                    </div>--%>
                    <uc1:ucAlertMessage runat="server" ID="ucAlertMessage" />
                </fieldset>
            </form>
        </div>
    </div>
</asp:Content>
