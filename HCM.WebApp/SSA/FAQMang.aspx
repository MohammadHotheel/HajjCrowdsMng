<%@ Page Title='<%$ Resources:HCMResource, FAQMang %>' Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FAQMang.aspx.cs" Inherits="HCM.WebApp.SSA.FAQMang" %>

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
                    <div class="form-group">
                        <label for="txtQuestion" class="col-md-2 control-label"><%= GetGlobalResourceObject("HCMResource","Question") %></label>
                        <div class="col-md-8">
                            <asp:TextBox ID="txtQuestion" runat="server" CssClass="form-control" MaxLength="255" Rows="3" TextMode="MultiLine"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvQuestion" runat="server" ControlToValidate="txtQuestion" ValidationGroup="Save" Display="Dynamic"
                                ErrorMessage='<%$ Resources:HCMResource, ValidateRequiredField %>' ToolTip='<%$ Resources:HCMResource, ValidateRequiredField %>'
                                CssClass="text-danger"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="txtAnswer" class="col-md-2 control-label"><%= GetGlobalResourceObject("HCMResource","Answer") %></label>
                        <div class="col-md-8">
                            <asp:TextBox ID="txtAnswer" runat="server" CssClass="form-control" MaxLength="255" Rows="3" TextMode="MultiLine"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvAnswer" runat="server" ControlToValidate="txtAnswer" ValidationGroup="Save" Display="Dynamic"
                                ErrorMessage='<%$ Resources:HCMResource, ValidateRequiredField %>' ToolTip='<%$ Resources:HCMResource, ValidateRequiredField %>'
                                CssClass="text-danger"></asp:RequiredFieldValidator>
                        </div>
                    </div>
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
                    <div class="form-group">
                        <div class="col-md-12 col-md-offset-2">
                            <a href="../SSA/FAQList.aspx" class="btn btn-secondary" style="width: 100px"><< <%= GetGlobalResourceObject("HCMResource","Return") %></a>
                            <asp:Button ID="btnSave" runat="server" Text='<%$ Resources:HCMResource, Save %>' CssClass="btn btn-primary" OnClick="btnSave_Click" ValidationGroup="Save" Width="100px" />
                        </div>
                    </div>

                </fieldset>
            </form>
        </div>
    </div>
</asp:Content>
