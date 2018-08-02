<%@ Page Title='<%$ Resources:HCMResource, ServiceInfoMang %>' Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ServiceInfoMang.aspx.cs" Inherits="HCM.WebApp.SSA.ServiceInfoMang" %>

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
                             <div class="form-group" id="divAdminView" runat="server">
                                <label for="ddlSSA" class="col-md-4 control-label"><%= GetGlobalResourceObject("HCMResource","SSA") %></label>
                                <div class="col-md-8">
                                    <asp:DropDownList ID="ddlSSA" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                                        <asp:ListItem Value="0" Text='<%$ Resources:HCMResource, All %>'></asp:ListItem>
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
                            <div class="form-group" id="div1" runat="server">
                                <label for="ddlServiceCategory" class="col-md-4 control-label"><%= GetGlobalResourceObject("HCMResource","ServiceCategory") %></label>
                                <div class="col-md-8">
                                    <asp:DropDownList ID="ddlServiceCategory" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                                        <asp:ListItem Value="0" Text='<%$ Resources:HCMResource, All %>'></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:CompareValidator ID="cvServiceCategory" runat="server" ControlToValidate="ddlServiceCategory" Display="Dynamic" CssClass="text-danger"
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
                            <div class="form-group">
                                <label for="txtSection" class="col-md-2 control-label"><%= GetGlobalResourceObject("HCMResource","Section") %></label>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtSection" runat="server" CssClass="form-control" MaxLength="255"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvSection" runat="server" ControlToValidate="txtSection" ValidationGroup="Save" Display="Dynamic"
                                        ErrorMessage='<%$ Resources:HCMResource, ValidateRequiredField %>' ToolTip='<%$ Resources:HCMResource, ValidateRequiredField %>'
                                        CssClass="text-danger"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtAddress" class="col-md-2 control-label"><%= GetGlobalResourceObject("HCMResource","Address") %></label>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" MaxLength="255" Rows="3" TextMode="MultiLine"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ControlToValidate="txtAddress" ValidationGroup="Save" Display="Dynamic"
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
                                    <a href="../SSA/ServiceInfoList.aspx" class="btn btn-secondary" style="width: 100px"><< <%= GetGlobalResourceObject("HCMResource","Return") %></a>
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
