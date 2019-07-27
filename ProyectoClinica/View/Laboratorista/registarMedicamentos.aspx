<%@ Page Title="" Language="C#" MasterPageFile="~/View/Laboratorista/masterLaboratorista.master"
    AutoEventWireup="true" CodeFile="~/Controller/ConLaboratorista/registarMedicamentos.aspx.cs" Inherits="View_Laboratorista_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <asp:Label ID="lbl_nom_med" runat="server" Text="Nombre del Medicamento"></asp:Label>
    <br />
    <asp:TextBox ID="txt_nom_med" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="lbl_des_med" runat="server" Text="Describa el Medicamento"></asp:Label>
    <br />
    <asp:TextBox ID="txt_des_med" runat="server" TextMode="MultiLine" Height="72px"></asp:TextBox>
   <br />
   
    <asp:Label ID="lbl_stock" runat="server" Text="Seleccione un Stock"></asp:Label>
    <br />
    <asp:dropdownlist ID="DDL_stock" runat="server">
        <asp:ListItem>Seleccione un Stock</asp:ListItem>
        <asp:ListItem>Capsulas</asp:ListItem>
        <asp:ListItem>Pastas</asp:ListItem>
        <asp:ListItem>Cremas</asp:ListItem>
        <asp:ListItem>Jarabe</asp:ListItem>

    </asp:dropdownlist>
    <br />
   
    
    <br />
    <asp:Button ID="button_registrar_Medicamento" CssClass="btn btn-info" runat="server" Text="Registar Pedido" OnClick="button_registrar_Medicamento_Click" />
    
</asp:Content>

