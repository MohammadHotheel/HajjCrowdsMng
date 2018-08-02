<%@ Page Title='<%$ Resources:HCMResource, CityMang %>' Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CityMang.aspx.cs" Inherits="HCM.WebApp.SSA.CityMang" %>

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
                        <label for="ddlState" class="col-md-2 control-label"><%= GetGlobalResourceObject("HCMResource","State") %></label>
                        <div class="col-md-8">
                            <asp:DropDownList ID="ddlState" runat="server" CssClass="form-control" AppendDataBoundItems="true" 
                                AutoPostBack="true">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="txtCity" class="col-md-2 control-label"><%= GetGlobalResourceObject("HCMResource","City") %></label>
                        <div class="col-lg-8">
                            <asp:TextBox ID="txtCity" runat="server" CssClass="form-control" MaxLength="255" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvCity" runat="server" ControlToValidate="txtCity" ValidationGroup="Save" Display="Dynamic"
                                ErrorMessage='<%$ Resources:HCMResource, ValidateRequiredField %>' ToolTip='<%$ Resources:HCMResource, ValidateRequiredField %>'
                                CssClass="text-danger"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-12 col-md-offset-2">
                            <a href="../Admin/CityList.aspx" class="btn btn-secondary" style="width: 100px"><< <%= GetGlobalResourceObject("HCMResource","Return") %></a>
                            <asp:Button ID="btnSave" runat="server" Text='<%$ Resources:HCMResource, Save %>' CssClass="btn btn-primary" OnClick="btnSave_Click" ValidationGroup="Save" Width="100px" />
                        </div>
                    </div>

                </fieldset>
            </form>
        </div>
    </div>
</asp:Content>
