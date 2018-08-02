<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucAlertMessage.ascx.cs" Inherits="HCM.WebApp.UC.ucAlertMessage" %>
<div class="row">
    <div class="col-md-12">
        <div id="divMsg" runat="server" class="alert alert-dismissible alert-primary">
            <button type="button" class="close" data-dismiss="alert">&times;</button>
            <strong>
                <asp:Label ID="lblMsgStrong" runat="server" Text=""></asp:Label></strong>
            <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
        </div>
    </div>
</div>
