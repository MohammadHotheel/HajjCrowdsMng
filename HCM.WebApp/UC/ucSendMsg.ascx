<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucSendMsg.ascx.cs" Inherits="HCM.WebApp.UC.ucSendMsg" %>
<%@ Register Src="~/UC/ucAlertMessage.ascx" TagPrefix="uc1" TagName="ucAlertMessage" %>
<uc1:ucAlertMessage runat="server" ID="ucAlertMessage" />
<div class="row">
    <div class="col-md-12">
        <form>
            <fieldset>
                <legend><%= GetGlobalResourceObject("HCMResource","SendMsg") %></legend>
                <hr />
                <asp:HiddenField ID="hfId" runat="server" />
                <div class="form-group">
                    <label for="ddlMessageType" class="col-md-2 control-label"><%= GetGlobalResourceObject("HCMResource","MessageType") %></label>
                    <div class="col-md-8">
                        <asp:DropDownList ID="ddlMessageType" runat="server" CssClass="form-control" AppendDataBoundItems="True">
                            <asp:ListItem Value="0" Text='<%$ Resources:HCMResource, Select %>'></asp:ListItem>
                        </asp:DropDownList>
                        <asp:CompareValidator ID="cvMessageType" runat="server" ControlToValidate="ddlMessageType" Display="Dynamic" CssClass="text-danger"
                            ErrorMessage='<%$ Resources:HCMResource, validateRequiredField %>' ToolTip='<%$ Resources:HCMResource, validateRequiredField %>'
                            ValidationGroup="Save" Operator="NotEqual" ValueToCompare="0" />
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtMessage" class="col-md-2 control-label"><%= GetGlobalResourceObject("HCMResource","Message") %></label>
                    <div class="col-md-8">
                        <asp:TextBox ID="txtMessage" runat="server" CssClass="form-control" MaxLength="255" Rows="3" TextMode="MultiLine"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvMessage" runat="server" ControlToValidate="txtMessage" ValidationGroup="Save" Display="Dynamic"
                            ErrorMessage='<%$ Resources:HCMResource, validateRequiredField %>' ToolTip='<%$ Resources:HCMResource, validateRequiredField %>'
                            CssClass="text-danger"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="txtEmail" CssClass="col-md-2 control-label"><%= GetGlobalResourceObject("HCMResource","Email") %></asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" TextMode="Email" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtEmail" Display="Dynamic" ValidationGroup="Save"
                            CssClass="text-danger" ErrorMessage='<%$ Resources:HCMResource, validateRequiredField %>' ToolTip='<%$ Resources:HCMResource, validateRequiredField %>' />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="txtFullName" CssClass="col-md-2 control-label"><%= GetGlobalResourceObject("HCMResource","FullName") %></asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="txtFullName" CssClass="form-control" MaxLength="50" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtFullName" Display="Dynamic" ValidationGroup="Save"
                            CssClass="text-danger" ErrorMessage='<%$ Resources:HCMResource, validateRequiredField %>' ToolTip='<%$ Resources:HCMResource, validateRequiredField %>' />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="txtMobile" CssClass="col-md-2 control-label"><%= GetGlobalResourceObject("HCMResource","Mobile") %></asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="txtMobile" CssClass="form-control" MaxLength="10" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtMobile" Display="Dynamic" ValidationGroup="Save"
                            CssClass="text-danger" ErrorMessage='<%$ Resources:HCMResource, validateRequiredField %>' ToolTip='<%$ Resources:HCMResource, validateRequiredField %>' />
                    </div>
                </div>
                <hr />
                <div class="form-group">
                    <div class="col-md-offset-2 col-md-10">
                        <asp:Button runat="server" ID="btnClear" OnClick="btnClear_Click" Text='<%$ Resources:HCMResource, Clear %>' CssClass="btn btn-secondary" CausesValidation="false" />
                        <asp:Button runat="server" ID="btnSend" OnClick="btnSend_Click" Text='<%$ Resources:HCMResource, Send %>' CssClass="btn btn-primary"
                            ValidationGroup="Save" CausesValidation="true" Width="100px" />
                    </div>
                </div>
            </fieldset>
        </form>
    </div>
</div>
