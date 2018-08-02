<%@ Page Title='<%$ Resources:HCMResource, Register %>' Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="HCM.WebApp.Account.Register" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %></h2>
    <hr />
    <P><%= GetGlobalResourceObject("HCMResource","RegisterFor") %></P>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>
    <div class="row">
        <div class="col-md-12">
            <form>
                <fieldset>
                    <legend><%= GetGlobalResourceObject("HCMResource","RegisterTitle") %></legend>
                    <asp:ValidationSummary runat="server" CssClass="text-danger" />

                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="UserName" CssClass="col-md-4 control-label"><%= GetGlobalResourceObject("HCMResource","UserName") %></asp:Label>
                                <div class="col-md-10">
                                    <asp:TextBox runat="server" ID="UserName" CssClass="form-control" />
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName" Display="Dynamic"
                                        CssClass="text-danger" ErrorMessage='<%$ Resources:HCMResource, validateRequiredField %>'
                                        ToolTip='<%$ Resources:HCMResource, validateRequiredField %>' ValidationGroup="Save" />
                                </div>
                                <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-4 control-label"><%= GetGlobalResourceObject("HCMResource","Email") %></asp:Label>
                                <div class="col-md-10">
                                    <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" />
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Email" Display="Dynamic"
                                        CssClass="text-danger" ErrorMessage='<%$ Resources:HCMResource, validateRequiredField %>'
                                        ToolTip='<%$ Resources:HCMResource, validateRequiredField %>' ValidationGroup="Save" />
                                </div>
                                <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-4 control-label"><%= GetGlobalResourceObject("HCMResource","Password") %></asp:Label>
                                <div class="col-md-10">
                                    <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" Display="Dynamic"
                                        CssClass="text-danger" ErrorMessage='<%$ Resources:HCMResource, validateRequiredField %>'
                                        ToolTip='<%$ Resources:HCMResource, validateRequiredField %>' ValidationGroup="Save" />
                                </div>
                                <asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="col-md-4 control-label"><%= GetGlobalResourceObject("HCMResource","ConfirmPassword") %></asp:Label>
                                <div class="col-md-10">
                                    <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="form-control" />
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword" Display="Dynamic"
                                        CssClass="text-danger" ErrorMessage='<%$ Resources:HCMResource, validateRequiredField %>'
                                        ToolTip='<%$ Resources:HCMResource, validateRequiredField %>' ValidationGroup="Save" />
                                    <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword" Display="Dynamic"
                                        CssClass="text-danger" ErrorMessage='<%$ Resources:HCMResource, validateConfirmation %>'
                                        ToolTip='<%$ Resources:HCMResource, validateConfirmation %>' ValidationGroup="Save" />
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="FullName" CssClass="col-md-4 control-label"><%= GetGlobalResourceObject("HCMResource","FullName") %></asp:Label>
                                <div class="col-md-10">
                                    <asp:TextBox runat="server" ID="FullName" CssClass="form-control" MaxLength="50" />
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="FullName" Display="Dynamic"
                                        CssClass="text-danger" ErrorMessage='<%$ Resources:HCMResource, validateRequiredField %>'
                                        ToolTip='<%$ Resources:HCMResource, validateRequiredField %>' ValidationGroup="Save" />
                                </div>
                                <asp:Label runat="server" AssociatedControlID="Mobile" CssClass="col-md-4 control-label"><%= GetGlobalResourceObject("HCMResource","Mobile") %></asp:Label>
                                <div class="col-md-10">
                                    <asp:TextBox runat="server" ID="Mobile" CssClass="form-control" MaxLength="10" />
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Mobile" Display="Dynamic"
                                        CssClass="text-danger" ErrorMessage='<%$ Resources:HCMResource, validateRequiredField %>'
                                        ToolTip='<%$ Resources:HCMResource, validateRequiredField %>' ValidationGroup="Save" />
                                </div>
                                <label for="ddlUniversity" class="col-md-4 control-label"><%= GetGlobalResourceObject("HCMResource","University") %></label>
                                <div class="col-md-10">
                                    <asp:DropDownList ID="ddlUniversity" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                                        <asp:ListItem Value="0" Text='<%$ Resources:HCMResource, Select %>'></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:CompareValidator ID="rfvUniversity" runat="server" ControlToValidate="ddlUniversity" Display="Dynamic" CssClass="text-danger"
                                        ErrorMessage='<%$ Resources:HCMResource, validateRequiredField %>' ToolTip='<%$ Resources:HCMResource, validateRequiredField %>'
                                        Operator="NotEqual" ValueToCompare="0" Type="Integer" ValidationGroup="Save" />
                                </div>
                                <div class="col-md-12">
                                    <small id="fileHelp" class="form-text text-muted"><%= GetGlobalResourceObject("HCMResource","addUni") %></small>
                                </div>
                            </div>
                        </div>
                    </div>



                    <hr />
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <asp:Button runat="server" OnClick="CreateUser_Click" Text='<%$ Resources:HCMResource, Register %>'
                                CssClass="btn btn-default" ValidationGroup="Save" />
                        </div>
                    </div>
                </fieldset>
            </form>
        </div>
    </div>
</asp:Content>
