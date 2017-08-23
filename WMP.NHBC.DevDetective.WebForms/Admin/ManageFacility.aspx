<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageFacility.aspx.cs" Inherits="WMP.NHBC.DevDetective.WebForms.Admin.ManageFacility" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Label ID="FacilityName" CssClass="panel-title" runat="server"></asp:Label>

    <asp:Label ID="FacilityProductItemName" Text="New Facility Inventory Item Name" runat="server"></asp:Label>
    <asp:TextBox ID="FacilityInventoryItemName" runat="server"></asp:TextBox>
    <asp:Button ID="submitButton" runat="server" Text="Submit" OnClick="SubmitForm" />

    <br />
    <asp:Label runat="server" Text="Facility Items: "></asp:Label>
    <asp:Button ID="SaveItems" runat="server" Text="Submit" OnClick="SaveFacilityItems" />
    <asp:GridView ID="FacilityInventoryItemGridView" HeaderStyle-BackColor="#3AC0F2" ItemType="ClassLibrary1.FacilityInventoryItemType" DataKeyNames="Id" SelectMethod="SelectFacilityInventoryItems" HeaderStyle-ForeColor="White"
        runat="server" OnRowCommand="FacilityInventoryItemGridView_OnRowCommand">
        <Columns>
            <asp:TemplateField HeaderText="Quantity On Hand">
                <ItemTemplate>
                    <asp:HiddenField ID="HiddenId" runat="server" Value='<%# Eval("Id") %>' />
                    <asp:TextBox ID="QuantityOnHand" runat="server" Text='<%#Eval("QuantityOnHand")%>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Quantity On Order">
                <ItemTemplate>
                    <asp:TextBox ID="QuantityOnOrder" Text='<%#Eval("QuantityOnOrder")%>' runat="server"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Price">
                <ItemTemplate>
                    <asp:TextBox ID="Price" Text='<%#Eval("Price")%>' runat="server"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

</asp:Content>
