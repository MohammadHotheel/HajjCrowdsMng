<%@ Page Title='<%$ Resources:HCMResource, Login %>' Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login0.aspx.cs" Inherits="HCM.WebApp.Account.Login0" Async="true" %>
<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %></h2>
    <hr />
    <div class="row">
        <div class="col-md-8">
            <section id="loginForm">
                <div class="form-horizontal">
                    <h4><%= GetGlobalResourceObject("HCMResource","LoginTitle") %></h4>
                    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
                    </asp:PlaceHolder>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="txtUserName" CssClass="col-md-2 control-label"><%= GetGlobalResourceObject("HCMResource","UserName") %></asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="txtUserName" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtUserName"
                                CssClass="text-danger" ErrorMessage='<%$ Resources:HCMResource, ValidateRequiredField %>' />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="txtPassword" CssClass="col-md-2 control-label"><%= GetGlobalResourceObject("HCMResource","Password") %></asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPassword" CssClass="text-danger" ErrorMessage='<%$ Resources:HCMResource, ValidateRequiredField %>' />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <div class="checkbox">
                                <asp:CheckBox runat="server" ID="chkRememberMe" />
                                <asp:Label runat="server" AssociatedControlID="chkRememberMe"><%= GetGlobalResourceObject("HCMResource","RememberMe") %></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <asp:Button runat="server" OnClick="LogIn" Text='<%$ Resources:HCMResource, Login %>' CssClass="btn btn-primary" />
                        </div>
                    </div>
                </div>

                <p>
                    <%-- Enable this once you have account confirmation enabled for password reset functionality
                    <asp:HyperLink runat="server" ID="ForgotPasswordHyperLink" ViewStateMode="Disabled">Forgot your password?</asp:HyperLink>
                    --%>
                </p>
            </section>
        </div>

        <div class="col-md-4 alert alert-dismissible alert-primary">
            <strong>
                <p><%= GetGlobalResourceObject("HCMResource","RegisterFor") %></p>
            </strong>
            <p><%= GetGlobalResourceObject("HCMResource","RegisterDesc") %></p>
            <p>
                <asp:HyperLink runat="server" ID="RegisterHyperLink" ViewStateMode="Disabled" CssClass="btn btn-secondary"><%= GetGlobalResourceObject("HCMResource","Register") %></asp:HyperLink>
            </p>
            <section id="socialLoginForm" style="visibility: hidden;">
                <uc:OpenAuthProviders runat="server" ID="OpenAuthLogin" />
            </section>
        </div>
    </div>
</asp:Content>
