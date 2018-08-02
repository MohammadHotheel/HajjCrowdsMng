<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucFAQ.ascx.cs" Inherits="HCM.WebApp.UC.ucFAQ" %>
<legend>
    <%= GetGlobalResourceObject("HCMResource","FAQ") %>
</legend>
<div id="accordion">
    <asp:Repeater ID="rptData" runat="server">
        <ItemTemplate>
            <h3><%# Eval("Question") %></h3>
            <div>
                <p>
                    <%# Eval("Answer") %>
                </p>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>


<%--<script type="text/javascript">
    $(function () {
        $("#accordion").accordion();
    });
</script>--%>
