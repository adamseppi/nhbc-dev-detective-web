<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageTenants.aspx.cs" Inherits="WMP.NHBC.DevDetective.WebForms.Admin.ManageTenants" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Label ID="TenantNameLabel" Text="New Tenant Name" runat="server"></asp:Label>
    <asp:TextBox ID="TenantName" runat="server"></asp:TextBox>
    <asp:Button ID="submitButton" runat="server" Text="Submit" OnClick="SubmitForm" />
    <br />
    <asp:Label runat="server" Text="Tenants"></asp:Label>
    <asp:GridView ID="TenantGridView" HeaderStyle-BackColor="#3AC0F2" ItemType="ClassLibrary1.Tenant" DataKeyNames="Id" SelectMethod="SelectTenant" HeaderStyle-ForeColor="White"
        runat="server" AutoGenerateColumns="true" OnRowCommand="TenantGridView_OnRowCommand">
        <Columns>
            <asp:TemplateField HeaderText="Vendor Name">
                <ItemTemplate>
                    <asp:LinkButton ID="ManageTenant" runat="server" CommandArgument='<%#Eval("Id")%>' CommandName="ManageTenant" Text="Manage Tenant"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
