<%@ Page Title='<%$ Resources:HCMResource, ServiceCategoryMang %>' Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ServiceCategoryMang.aspx.cs" Inherits="HCM.WebApp.SSA.ServiceCategoryMang" %>

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
                        <label for="txtServiceCategory" class="col-md-2 control-label"><%= GetGlobalResourceObject("HCMResource","ServiceCategory") %></label>
                        <div class="col-lg-8">
                            <asp:TextBox ID="txtServiceCategory" runat="server" CssClass="form-control" MaxLength="255" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvServiceCategory" runat="server" ControlToValidate="txtServiceCategory" ValidationGroup="Save" Display="Dynamic"
                                ErrorMessage='<%$ Resources:HCMResource, ValidateRequiredField %>' ToolTip='<%$ Resources:HCMResource, ValidateRequiredField %>'
                                CssClass="text-danger"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-12 col-md-offset-2">
                            <a href="../Admin/ServiceCategoryList.aspx" class="btn btn-secondary" style="width: 100px"><< <%= GetGlobalResourceObject("HCMResource","Return") %></a>
                            <asp:Button ID="btnSave" runat="server" Text='<%$ Resources:HCMResource, Save %>' CssClass="btn btn-primary" OnClick="btnSave_Click" ValidationGroup="Save" Width="100px" />
                        </div>
                    </div>

                </fieldset>
            </form>
        </div>
    </div>
</asp:Content>
