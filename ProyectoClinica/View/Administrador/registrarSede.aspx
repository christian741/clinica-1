﻿<%@ Page Title="" Language="C#" MasterPageFile="~/View/Administrador/masterAdministrador.master" 
    AutoEventWireup="true" CodeFile="~/Controller/ConAdministrador/registrarSede.aspx.cs" Inherits="View_Administrador_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 
            <asp:Image ID="Image_sede" runat="server" Width="30%" />
            <br />
           
            <br />
           
            <asp:Label ID="label_sede_reg" runat="server" Text="Nombre de la Sede: "></asp:Label>
            <br />
            <asp:TextBox ID="text_sede_nombre_reg" placeholder="Digite el Nombre de la Sede" runat="server"></asp:TextBox>
            <br />
            <br />
             <asp:Label ID="label_sede_direccion" runat="server" Text="Dirección de la Sede: "></asp:Label>
            <br />
            <asp:TextBox ID="text_sede_direccion" placeholder="Digite la Dirección de la Sede" runat="server"></asp:TextBox>
            <br />
            <br />
             <asp:Label ID="label_sede_descripcion" runat="server" Text="Breve Descripcion de la Sede: "></asp:Label>
            <br />
            <asp:TextBox ID="text_sede_descripcion" placeholder="Digite una Descripción de la Sede" runat="server"></asp:TextBox>
            <br />
            <br />
             <asp:Label ID="label_encargado_sede" runat="server" Text="Nombre del Encargado de la Sede: "></asp:Label>
            <br />
            <asp:TextBox ID="text_encargado_sede" placeholder="Digite el Nombre del Encargado de la Sede" runat="server"></asp:TextBox>
            <br />
            <br />
             <asp:Label ID="label_ciudad_sede" runat="server" Text="Ciudad de la Sede: "></asp:Label>
            <br />
            <asp:TextBox ID="text_ciudad_sede" placeholder="Digite la Ciudad de la Sede" runat="server"></asp:TextBox>
            <br />
            <br />


            <asp:Label ID="label_file_sede" runat="server" Text="Seleccione una Imagen: "></asp:Label>
                <br />
            <asp:FileUpload ID="FU_registro_sede" runat="server" />
            <br />
            <br />
            <asp:Button ID="button_sede" runat="server" Text="Registrar Sede" OnClick="button_sede_Click" CssClass="form-check-label"  />
            <br />
           
      
   
</asp:Content>

