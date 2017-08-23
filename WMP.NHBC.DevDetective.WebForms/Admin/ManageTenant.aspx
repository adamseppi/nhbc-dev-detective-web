<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageTenant.aspx.cs" Inherits="WMP.NHBC.DevDetective.WebForms.Admin.ManageTenant" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <asp:Label ID="FacilityNameLabel" Text="New Facility Name" runat="server"></asp:Label>
        <asp:TextBox ID="FacilityName" runat="server"></asp:TextBox>
    </div>
     <div class="row">
        <asp:Label Text="Parent Facility Id (Optional)" runat="server"></asp:Label>
        <asp:TextBox ID="ParentFacilityId" runat="server"></asp:TextBox>
    </div>
    <div class="row">
          <asp:Label Text="Preload Facility With Inventory Item Types?" runat="server"></asp:Label>
          <asp:CheckBox ID="InitializeDataCheckBox" runat="server"></asp:CheckBox>
    </div>
    <div class="row">  
        <asp:Button ID="submitButton" runat="server" Text="Submit" OnClick="CreateFacility"/>
    </div>
    <br />
    <asp:GridView ID="FacilityGridView" HeaderStyle-BackColor="#3AC0F2" ItemType="ClassLibrary1.Facility" DataKeyNames="Id"  SelectMethod="GetFacilities" HeaderStyle-ForeColor="White"
        runat="server" AutoGenerateColumns="true" OnRowCommand="TenantsGridView_OnRowCommand">
        <Columns>
               <asp:TemplateField HeaderText="Manage Facility">
                <ItemTemplate>
                    <asp:LinkButton ID="ManageFacility" runat="server" CommandArgument='<%#Eval("Id")%>' CommandName="ManageFacility" Text="Manage Facility"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    
    <h3>Add User To Facility</h3>
    <div class="row">
        <asp:Label Text="UserId" runat="server"></asp:Label>
        <asp:textbox ID="UserIdTextBox" runat="server"></asp:textbox>
    </div>  
    <div class="row">
        <asp:Label Text="Facility Id" runat="server"></asp:Label>
        <asp:textbox ID="FacilityIdTextBox" runat="server"></asp:textbox>
    </div>
    <div class="row">  
        <asp:Button ID="UserSubmitButton" runat="server" Text="Submit" OnClick="CreateFacilityUser"/>
    </div>

    <h2>Facility Users</h2>
    <asp:GridView ID="UserGridView" HeaderStyle-BackColor="#3AC0F2" ItemType="ClassLibrary1.AspNetUser" DataKeyNames="Id"  SelectMethod="GetUsers" HeaderStyle-ForeColor="White"
                  runat="server" AutoGenerateColumns="true">
       
    </asp:GridView>
    
   
</asp:Content>
