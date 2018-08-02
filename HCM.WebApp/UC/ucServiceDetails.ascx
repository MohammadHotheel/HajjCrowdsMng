<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucServiceDetails.ascx.cs" Inherits="HCM.WebApp.UC.ucServiceDetails" %>
<%@ Register Src="~/UC/ucLocationsMap.ascx" TagPrefix="uc1" TagName="ucLocationsMap" %>
<legend>
    <%= GetGlobalResourceObject("HCMResource","ServiceDetails") %>
</legend>
<div class="row">
    <div class="col-md-6" id="divLink" runat="server">
        <div class="card border-success mb-6">
            <div class="card-header"><%= GetGlobalResourceObject("HCMResource","Links") %></div>
            <div class="card-body">
                <asp:Repeater ID="rptUrl" runat="server">
                    <ItemTemplate>
                        <a id="file" runat="server" causesvalidation="False" visible='<%# (Eval("InfoTypeId").ToString() == "1" ? true : false) %>'
                            href='<%# Eval("InformationContent") %>' target="_blank">
                            <%# Eval("InformationContent") %>
                        </a>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
    <div class="col-md-6" id="divFile" runat="server">
        <div class="card border-success mb-6">
            <div class="card-header"><%= GetGlobalResourceObject("HCMResource","Files") %></div>
            <div class="card-body">
                <asp:Repeater ID="rptFile" runat="server">
                    <ItemTemplate>
                        <a id="url" runat="server" causesvalidation="False" visible='<%# (Eval("InfoTypeId").ToString() == "2" ? true : false) %>'
                            href='<%# String.Format("~/DetailsFiles/{0}_{1}.{2}", Eval("ServiceInformationId"), Eval("Id"), Eval("FileExt")) %>' target="_blank">
                            <%# Eval("InformationContent") %>
                        </a>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
</div>
<br />
<div class="row" id="divImg" runat="server">
    <div class="col-md-12">
        <div class="card border-success mb-12">
            <div class="card-header"><%= GetGlobalResourceObject("HCMResource","Images") %></div>
            <div class="card-body">
                <ul class="gallery clearfix">
                    <asp:Repeater ID="rptImg" runat="server">
                        <ItemTemplate>
                            <li style="display: inline;">
                                <a id="lnkImg" runat="server" title='<%# Eval("InformationContent") %>' rel="prettyPhoto[gallery1]" 
                                    href='<%# String.Format("~/DetailsImages/{0}_{1}.{2}", Eval("ServiceInformationId"), Eval("Id"), Eval("FileExt")) %>'>
                                    <asp:Image ID="Image1" runat="server" Width="100px" Height="100px" BorderStyle="Solid" BorderWidth="1px" BorderColor="Black" style="margin:2px;"
                                        Visible='<%# (Eval("InfoTypeId").ToString() == "3" ? true : false) %>' ToolTip='<%# Eval("InformationContent") %>' 
                                        ImageUrl='<%# String.Format("~/DetailsImages/{0}_{1}.{2}", Eval("ServiceInformationId"), Eval("Id"), Eval("FileExt")) %>' />
                                </a>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
        </div>
    </div>
</div>
