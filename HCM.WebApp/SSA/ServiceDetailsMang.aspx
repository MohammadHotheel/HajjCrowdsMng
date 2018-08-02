<%@ Page Title='<%$ Resources:HCMResource, ServiceDetailsMang %>' Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ServiceDetailsMang.aspx.cs" Inherits="HCM.WebApp.SSA.ServiceDetailsMang" %>

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
                            <div class="form-group">
                                <label for="ddlInfoType" class="col-md-4 control-label"><%= GetGlobalResourceObject("HCMResource","InfoType") %></label>
                                <div class="col-md-8">
                                    <asp:DropDownList ID="ddlInfoType" runat="server" CssClass="form-control" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="ddlInfoType_SelectedIndexChanged">
                                        <asp:ListItem Value="0" Text='<%$ Resources:HCMResource, Select %>'></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:CompareValidator ID="rfvInfoType" runat="server" ControlToValidate="ddlInfoType" Display="Dynamic" CssClass="text-danger"
                                        ErrorMessage='<%$ Resources:HCMResource, validateRequiredField %>' ToolTip='<%$ Resources:HCMResource, validateRequiredField %>'
                                        Operator="NotEqual" ValueToCompare="0" Type="Integer" ValidationGroup="Save" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-8">
                            <div class="form-group">
                                <label for="ddlServiceCategory" class="col-md-4 control-label"><%= GetGlobalResourceObject("HCMResource","InformationContent") %></label>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtInformationContent" runat="server" CssClass="form-control" MaxLength="255"></asp:TextBox>
                                    <br />
                                    <asp:FileUpload ID="FileUpload" runat="server" Visible="false" />
                                    <asp:RequiredFieldValidator ID="rfvInformationContent" runat="server" ControlToValidate="txtInformationContent" ValidationGroup="Save" Display="Dynamic"
                                        ErrorMessage='<%$ Resources:HCMResource, ValidateRequiredField %>' ToolTip='<%$ Resources:HCMResource, ValidateRequiredField %>'
                                        CssClass="text-danger"></asp:RequiredFieldValidator>
                                    <asp:RequiredFieldValidator ID="rfvFileUpload" runat="server" ControlToValidate="FileUpload" ValidationGroup="Save" Display="Dynamic"
                                        ErrorMessage='<%$ Resources:HCMResource, ValidateRequiredField %>' ToolTip='<%$ Resources:HCMResource, ValidateRequiredField %>'
                                        CssClass="text-danger" Enabled="false"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="revInformationContent" runat="server" ControlToValidate="txtInformationContent" Enabled="false"
                                        Display="Dynamic" CssClass="text-danger" ValidationGroup="Save" ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?"
                                        ErrorMessage='<%$ Resources:HCMResource, ValidateUrlRegularExpression %>' ToolTip='<%$ Resources:HCMResource, ValidateUrlRegularExpression %>'></asp:RegularExpressionValidator>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <a Id="lnkImg" runat="server" class="fancybox">
                                    <asp:Image ID="img" runat="server" Width="200px" Height="200px" Visible="false" />
                                </a>
                                <asp:LinkButton ID="url" runat="server" CausesValidation="False" Visible="false"></asp:LinkButton>
                                <asp:LinkButton ID="file" runat="server" CausesValidation="False" target="_blank" Visible="false"></asp:LinkButton>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group">
                                <div class="col-md-12 col-md-offset-2">
                                    <%--<a href="../SSA/ServiceInfoList.aspx" class="btn btn-secondary" style="width: 100px"><< <%= GetGlobalResourceObject("HCMResource","Return") %></a>--%>
                                    <asp:Button ID="btnReturn" runat="server" Text='<%$ Resources:HCMResource, Return %>' CssClass="btn btn-primary" OnClick="btnReturn_Click" CausesValidation="false" Width="100px" />
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
