<%@ Page Title='<%$ Resources:HCMResource, SSAProfile %>' Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SSAProfile.aspx.cs" Inherits="HCM.WebApp.SSA.SSAProfile" %>

<%@ Register Src="~/UC/ucAlertMessage.ascx" TagPrefix="uc1" TagName="ucAlertMessage" %>

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
                            <div class="form-group" id="divAdminView" runat="server">
                                <label for="ddlSSA" class="col-md-4 control-label"><%= GetGlobalResourceObject("HCMResource","SSA") %></label>
                                <div class="col-md-8">
                                    <asp:DropDownList ID="ddlSSA" runat="server" CssClass="form-control" AppendDataBoundItems="true" 
                                        AutoPostBack="true" OnSelectedIndexChanged="ddlSSA_SelectedIndexChanged" >
                                    </asp:DropDownList>
                                    <asp:CompareValidator ID="rfvSSA" runat="server" ControlToValidate="ddlSSA" Display="Dynamic" CssClass="text-danger"
                                        ErrorMessage='<%$ Resources:HCMResource, validateRequiredField %>' ToolTip='<%$ Resources:HCMResource, validateRequiredField %>'
                                        Operator="NotEqual" ValueToCompare="0" Type="Integer" ValidationGroup="Save" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label for="txtName" class="col-md-2 control-label"><%= GetGlobalResourceObject("HCMResource","Name") %></label>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtName" runat="server" CssClass="form-control" MaxLength="255" Rows="3"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName" ValidationGroup="Save" Display="Dynamic"
                                        ErrorMessage='<%$ Resources:HCMResource, ValidateRequiredField %>' ToolTip='<%$ Resources:HCMResource, ValidateRequiredField %>'
                                        CssClass="text-danger"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="ddlState" class="col-md-4 control-label"><%= GetGlobalResourceObject("HCMResource","State") %></label>
                                <div class="col-md-8">
                                    <asp:DropDownList ID="ddlState" runat="server" CssClass="form-control" AppendDataBoundItems="true" 
                                        AutoPostBack="true" OnSelectedIndexChanged="ddlState_SelectedIndexChanged">
                                        <asp:ListItem Value="0" Text='<%$ Resources:HCMResource, All %>'></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:CompareValidator ID="cvState" runat="server" ControlToValidate="ddlState" Display="Dynamic" CssClass="text-danger"
                                        ErrorMessage='<%$ Resources:HCMResource, validateRequiredField %>' ToolTip='<%$ Resources:HCMResource, validateRequiredField %>'
                                        Operator="NotEqual" ValueToCompare="0" Type="Integer" ValidationGroup="Save" />
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtStreet" class="col-md-2 control-label"><%= GetGlobalResourceObject("HCMResource","Street") %></label>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtStreet" runat="server" CssClass="form-control" MaxLength="255" Rows="3"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvStreet" runat="server" ControlToValidate="txtName" ValidationGroup="Save" Display="Dynamic"
                                        ErrorMessage='<%$ Resources:HCMResource, ValidateRequiredField %>' ToolTip='<%$ Resources:HCMResource, ValidateRequiredField %>'
                                        CssClass="text-danger"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtPhone" class="col-md-2 control-label"><%= GetGlobalResourceObject("HCMResource","Phone") %></label>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control" MaxLength="255" Rows="3"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvPhone" runat="server" ControlToValidate="txtPhone" ValidationGroup="Save" Display="Dynamic"
                                        ErrorMessage='<%$ Resources:HCMResource, ValidateRequiredField %>' ToolTip='<%$ Resources:HCMResource, ValidateRequiredField %>'
                                        CssClass="text-danger"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtWebsite" class="col-md-2 control-label"><%= GetGlobalResourceObject("HCMResource","Website") %></label>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtWebsite" runat="server" CssClass="form-control" MaxLength="255" Rows="3"></asp:TextBox>
                                    <%--<asp:RequiredFieldValidator ID="rfvWebsite" runat="server" ControlToValidate="txtWebsite" ValidationGroup="Save" Display="Dynamic"
                                        ErrorMessage='<%$ Resources:HCMResource, ValidateRequiredField %>' ToolTip='<%$ Resources:HCMResource, ValidateRequiredField %>'
                                        CssClass="text-danger"></asp:RequiredFieldValidator>--%>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label for="ddlUniversity" class="col-md-4 control-label"><%= GetGlobalResourceObject("HCMResource","University") %></label>
                                <div class="col-md-8">
                                    <asp:DropDownList ID="ddlUniversity" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                                        <asp:ListItem Value="0" Text='<%$ Resources:HCMResource, All %>'></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:CompareValidator ID="cvUniversity" runat="server" ControlToValidate="ddlUniversity" Display="Dynamic" CssClass="text-danger"
                                        ErrorMessage='<%$ Resources:HCMResource, validateRequiredField %>' ToolTip='<%$ Resources:HCMResource, validateRequiredField %>'
                                        Operator="NotEqual" ValueToCompare="0" Type="Integer" ValidationGroup="Save" />
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="ddlCity" class="col-md-4 control-label"><%= GetGlobalResourceObject("HCMResource","City") %></label>
                                <div class="col-md-8">
                                    <asp:DropDownList ID="ddlCity" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                                        <asp:ListItem Value="0" Text='<%$ Resources:HCMResource, All %>'></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:CompareValidator ID="cvCity" runat="server" ControlToValidate="ddlCity" Display="Dynamic" CssClass="text-danger"
                                        ErrorMessage='<%$ Resources:HCMResource, validateRequiredField %>' ToolTip='<%$ Resources:HCMResource, validateRequiredField %>'
                                        Operator="NotEqual" ValueToCompare="0" Type="Integer" ValidationGroup="Save" />
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtZipCode" class="col-md-2 control-label"><%= GetGlobalResourceObject("HCMResource","ZipCode") %></label>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtZipCode" runat="server" CssClass="form-control" MaxLength="255" Rows="3"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvZipCode" runat="server" ControlToValidate="txtZipCode" ValidationGroup="Save" Display="Dynamic"
                                        ErrorMessage='<%$ Resources:HCMResource, ValidateRequiredField %>' ToolTip='<%$ Resources:HCMResource, ValidateRequiredField %>'
                                        CssClass="text-danger"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtFax" class="col-md-2 control-label"><%= GetGlobalResourceObject("HCMResource","Fax") %></label>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtFax" runat="server" CssClass="form-control" MaxLength="255" Rows="3"></asp:TextBox>
                                    <%--<asp:RequiredFieldValidator ID="rfvFax" runat="server" ControlToValidate="txtFax" ValidationGroup="Save" Display="Dynamic"
                                        ErrorMessage='<%$ Resources:HCMResource, ValidateRequiredField %>' ToolTip='<%$ Resources:HCMResource, ValidateRequiredField %>'
                                        CssClass="text-danger"></asp:RequiredFieldValidator>--%>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtSocialInfo" class="col-md-2 control-label"><%= GetGlobalResourceObject("HCMResource","SocialInfo") %></label>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtSocialInfo" runat="server" CssClass="form-control" MaxLength="255" Rows="3" TextMode="MultiLine"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvSocialInfo" runat="server" ControlToValidate="txtSocialInfo" ValidationGroup="Save" Display="Dynamic"
                                        ErrorMessage='<%$ Resources:HCMResource, ValidateRequiredField %>' ToolTip='<%$ Resources:HCMResource, ValidateRequiredField %>'
                                        CssClass="text-danger"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-12">
                                    <small id="fileHelp" class="form-text text-muted">facebook, twitter</small>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-12 col-md-offset-2">
                            <a href="../SSA/SSAAdmin.aspx" class="btn btn-secondary" style="width: 100px"><< <%= GetGlobalResourceObject("HCMResource","Return") %></a>
                            <%--<a href="/Default.aspx" class="btn btn-secondary" style="width: 100px"><< <%= GetGlobalResourceObject("HCMResource","Return") %></a>--%>
                            <asp:Button ID="btnSave" runat="server" Text='<%$ Resources:HCMResource, Save %>' CssClass="btn btn-primary"
                                OnClick="btnSave_Click" ValidationGroup="Save" Width="100px" />
                        </div>
                    </div>
                </fieldset>
            </form>
        </div>
    </div>
</asp:Content>
