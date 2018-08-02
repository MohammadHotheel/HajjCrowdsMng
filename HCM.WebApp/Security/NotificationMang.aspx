<%@ Page Title='<%$ Resources:HCMResource, NotificationMang %>' Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NotificationMang.aspx.cs" Inherits="HCM.WebApp.Security.NotificationMang" %>

<%@ Register Src="~/UC/ucAlertMessage.ascx" TagPrefix="uc1" TagName="ucAlertMessage" %>
<%@ Register Src="~/UC/ucLocation.ascx" TagPrefix="uc1" TagName="ucLocation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <hr />
    <uc1:ucAlertMessage runat="server" ID="ucAlertMessage" />
    <div class="row">
        <div class="col-md-12">
            <form>
                <fieldset>
                    <legend><%= Operation %></legend>
                    <div class="row">
                        <div class="col-md-12">
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group" id="divAdminView" runat="server">
                                <label for="ddlUserType" class="col-md-4 control-label"><%= GetGlobalResourceObject("HCMResource","UserType") %></label>
                                <div class="col-md-8">
                                    <asp:DropDownList ID="ddlUserType" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                                        <asp:ListItem Value="0" Text='<%$ Resources:HCMResource, All %>'></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:CompareValidator ID="rfvUserType" runat="server" ControlToValidate="ddlUserType" Display="Dynamic" CssClass="text-danger"
                                        ErrorMessage='<%$ Resources:HCMResource, validateRequiredField %>' ToolTip='<%$ Resources:HCMResource, validateRequiredField %>'
                                        Operator="NotEqual" ValueToCompare="0" Type="Integer" ValidationGroup="Save" />
                                </div>
                            </div>
                            <div class="form-group" id="div2" runat="server">
                                <label for="ddlNotificationLevel" class="col-md-4 control-label"><%= GetGlobalResourceObject("HCMResource","NotificationLevel") %></label>
                                <div class="col-md-8">
                                    <asp:DropDownList ID="ddlNotificationLevel" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                                        <asp:ListItem Value="0" Text='<%$ Resources:HCMResource, All %>'></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:CompareValidator ID="cvNotificationLevel" runat="server" ControlToValidate="ddlNotificationLevel" Display="Dynamic" CssClass="text-danger"
                                        ErrorMessage='<%$ Resources:HCMResource, validateRequiredField %>' ToolTip='<%$ Resources:HCMResource, validateRequiredField %>'
                                        Operator="NotEqual" ValueToCompare="0" Type="Integer" ValidationGroup="Save" />
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtTitle" class="col-md-2 control-label"><%= GetGlobalResourceObject("HCMResource","Title") %></label>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control" MaxLength="255"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvTitle" runat="server" ControlToValidate="txtTitle" ValidationGroup="Save" Display="Dynamic"
                                        ErrorMessage='<%$ Resources:HCMResource, ValidateRequiredField %>' ToolTip='<%$ Resources:HCMResource, ValidateRequiredField %>'
                                        CssClass="text-danger"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtDescription" class="col-md-2 control-label"><%= GetGlobalResourceObject("HCMResource","Description") %></label>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" MaxLength="255" Rows="3" TextMode="MultiLine"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvDescription" runat="server" ControlToValidate="txtDescription" ValidationGroup="Save" Display="Dynamic"
                                        ErrorMessage='<%$ Resources:HCMResource, ValidateRequiredField %>' ToolTip='<%$ Resources:HCMResource, ValidateRequiredField %>'
                                        CssClass="text-danger"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <uc1:ucLocation runat="server" ID="ucLocation" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group">
                                <div class="col-md-12 col-md-offset-2">
                                    <a href="../Security/NotificationList.aspx" class="btn btn-secondary" style="width: 100px"><< <%= GetGlobalResourceObject("HCMResource","Return") %></a>
                                    <asp:Button ID="btnSave" runat="server" Text='<%$ Resources:HCMResource, Save %>' CssClass="btn btn-primary" OnClick="btnSave_Click" ValidationGroup="Save" Width="100px" />
                                </div>
                            </div>
                        </div>
                    </div>

                </fieldset>
            </form>
        </div>
    </div>
</asp:Content>
