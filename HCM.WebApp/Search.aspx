<%@ Page Title='<%$ Resources:HCMResource, Search %>' Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="HCM.WebApp.Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <hr />
    <form>
        <fieldset>
            <legend>
                <%= GetGlobalResourceObject("HCMResource","SSAList") %>
            </legend>
            <div class="row">
                <div class="col-md-12">
                    <div class="form-inline my-2 my-lg-0 center">
                        <%--<input class="form-control mr-sm-2" type="text" placeholder="Search">--%>
                        <asp:TextBox ID="txtSearch" runat="server" Width="500px" MaxLength="50" CssClass="form-control mr-sm-2"></asp:TextBox>
                        <%--<button class="btn btn-secondary my-2 my-sm-0" type="submit">Search</button>--%>
                        <asp:Button ID="btnSearch" runat="server" Text='<%$ Resources:HCMResource, Search %>' CssClass="btn btn-primary my-2 my-sm-0" OnClick="btnSearch_Click" ValidationGroup="Search" Width="100px" />
                    </div>
                    <div class="col-md-12">
                        <asp:RequiredFieldValidator ID="rfvSearch" runat="server" ControlToValidate="txtSearch" ValidationGroup="Search" Display="Dynamic"
                            ErrorMessage='<%$ Resources:HCMResource, ValidateRequiredField %>' ToolTip='<%$ Resources:HCMResource, ValidateRequiredField %>'
                            CssClass="text-danger"></asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>
            <br />
            <div class="row">
                <asp:Repeater ID="rptdata" runat="server">
                    <ItemTemplate>
                        <div class="col-md-6">
                            <div class="card text-white bg-secondary">
                                <div class="card-header"><strong><%# Eval("University") %></strong></div>
                                <div class="card-body">
                                    <h4 class="card-title">Name: <%# Eval("Name") %></h4>
                                    <p class="card-text">
                                        State: <%# Eval("State") %><br />
                                        City: <%# Eval("City") %><br />
                                        ZipCode: <%# Eval("ZipCode") %><br />
                                        Services Count: <span class="badge badge-primary badge-pill">(<%# Eval("ServiceCount") %>)</span>
                                    </p>
                                    <a href='<%# String.Format("SSAInfo?id={0}", Eval("Id")) %>' class="btn btn-primary">Details &raquo;</a>
                                </div>
                            </div>
                            <hr>
                            <%# (((Container.ItemIndex + 1) % 2) == 0 ? "</div><div class='row'>" : "")  %>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </fieldset>
    </form>

</asp:Content>
