<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucSSA.ascx.cs" Inherits="HCM.WebApp.UC.ucSSA" %>
<%@ Register Src="~/UC/ucServiceInfo.ascx" TagPrefix="uc1" TagName="ucServiceInfo" %>
<%@ Register Src="~/UC/ucFAQ.ascx" TagPrefix="uc1" TagName="ucFAQ" %>

<asp:Repeater ID="rptdata" runat="server">
    <ItemTemplate>
        <div class="row">
            <div class="col-md-12">
                <div class="card text-white bg-secondary">
                    <div class="card-header"><h3><strong><%# Eval("Name") %></strong></h3></div>
                    <div class="card-body">
                        <div class="form-group row">
                            <label for='<%# Eval("University") %>' class="col-sm-2 col-form-label"><%= GetGlobalResourceObject("HCMResource","University") %></label>
                            <div class="col-sm-4">
                                <input type="text" readonly="" class="form-control-plaintext" id='<%# Eval("University") %>' value='<%# Eval("University") %>'>
                            </div>
                            <%--<label for='<%# Eval("Email") %>' class="col-sm-2 col-form-label"><%= GetGlobalResourceObject("HCMResource","Email") %></label>
                            <div class="col-sm-4">
                                <input type="text" readonly="" class="form-control-plaintext" id='<%# Eval("Email") %>' value='<%# Eval("Email") %>'>
                            </div>--%>
                        </div>
                        <div class="form-group row">
                            <label for='<%# Eval("State") %>' class="col-sm-2 col-form-label"><%= GetGlobalResourceObject("HCMResource","State") %></label>
                            <div class="col-sm-4">
                                <input type="text" readonly="" class="form-control-plaintext" id='<%# Eval("State") %>' value='<%# Eval("State") %>'>
                            </div>
                            <label for='<%# Eval("City") %>' class="col-sm-2 col-form-label"><%= GetGlobalResourceObject("HCMResource","City") %></label>
                            <div class="col-sm-4">
                                <input type="text" readonly="" class="form-control-plaintext" id='<%# Eval("City") %>' value='<%# Eval("City") %>'>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label for='<%# Eval("Street") %>' class="col-sm-2 col-form-label"><%= GetGlobalResourceObject("HCMResource","Street") %></label>
                            <div class="col-sm-4">
                                <input type="text" readonly="" class="form-control-plaintext" id='<%# Eval("Street") %>' value='<%# Eval("Street") %>'>
                            </div>
                            <label for='<%# Eval("ZipCode") %>' class="col-sm-2 col-form-label"><%= GetGlobalResourceObject("HCMResource","ZipCode") %></label>
                            <div class="col-sm-4">
                                <input type="text" readonly="" class="form-control-plaintext" id='<%# Eval("ZipCode") %>' value='<%# Eval("ZipCode") %>'>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label for='<%# Eval("Phone") %>' class="col-sm-2 col-form-label"><%= GetGlobalResourceObject("HCMResource","Phone") %></label>
                            <div class="col-sm-4">
                                <input type="text" readonly="" class="form-control-plaintext" id='<%# Eval("Phone") %>' value='<%# Eval("Phone") %>'>
                            </div>
                            <label for='<%# Eval("Fax") %>' class="col-sm-2 col-form-label"><%= GetGlobalResourceObject("HCMResource","Fax") %></label>
                            <div class="col-sm-4">
                                <input type="text" readonly="" class="form-control-plaintext" id='<%# Eval("Fax") %>' value='<%# Eval("Fax") %>'>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label for='<%# Eval("Website") %>' class="col-sm-2 col-form-label"><%= GetGlobalResourceObject("HCMResource","Website") %></label>
                            <div class="col-sm-4">
                                <input type="text" readonly="" class="form-control-plaintext" id='<%# Eval("Website") %>' value='<%# Eval("Website") %>'>
                            </div>
                            <label for='<%# Eval("SocialInfo") %>' class="col-sm-2 col-form-label"><%= GetGlobalResourceObject("HCMResource","SocialInfo") %></label>
                            <div class="col-sm-4">
                                <input type="text" readonly="" class="form-control-plaintext" id='<%# Eval("SocialInfo") %>' value='<%# Eval("SocialInfo") %>'>
                            </div>
                        </div>
                    </div>
                    <hr>
                    <%= GetGlobalResourceObject("HCMResource","LastUpdatedDate") %>: <%#  Eval("LastUpdatedDate") %>
                </div>
            </div>
        </div>
        <hr />
        <div class="row">
            <div class="col-md-12">
                <uc1:ucServiceInfo runat="server" ID="ucServiceInfo" />
            </div>
        </div>
        <hr />
        <div class="row">
            <div class="col-md-12">
                <uc1:ucFAQ runat="server" id="ucFAQ" />
            </div>
        </div>
        <%--<div class="row">
            <div class="col-md-12">
                <div class="list-group">
                    <a class="btn btn-secondary list-group-item list-group-item-action active" href='<%# String.Format("/FAQ?id={0}", Eval("Id")) %>' target="_blank"><%= GetGlobalResourceObject("HCMResource","FAQ") %> &raquo;</a>
                </div>
            </div>
        </div>--%>
    </ItemTemplate>
</asp:Repeater>

