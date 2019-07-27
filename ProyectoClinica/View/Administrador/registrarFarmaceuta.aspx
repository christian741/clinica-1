<%@ Page Title="" Language="C#" MasterPageFile="~/View/Administrador/masterAdministrador.master" AutoEventWireup="true" 
    CodeFile="~/Controller/ConAdministrador/registrarFarmaceuta.aspx.cs" Inherits="View_Administrador_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      
                       <asp:Image ID="Image_Registro_far" runat="server" Width="30%" />
                       <br />
                       <asp:FileUpload ID="FU_registro_far" runat="server" />
                       <br />
                         <asp:Label ID="label_nombre_reg_far" runat="server" Text="Nombre Farmaceuta: "></asp:Label>
                        <asp:TextBox ID="text_nombre_reg_far" placeholder="Digite el Nombre" runat="server"></asp:TextBox>
                        <br />
                     <asp:Label ID="label_direccion_far" runat="server" Text="Dirección: "></asp:Label>
                    <asp:TextBox ID="text_direccion_reg_far" placeholder="Digite la Dirección" runat="server"></asp:TextBox>
                    <br />
                    <asp:Label ID="label_correo_far" runat="server" Text="Correo: "></asp:Label>
                    <asp:TextBox ID="text_correo_reg_far" runat="server"></asp:TextBox>
                    <br />
                         <asp:Label ID="label_fecha_nacimiento_far" runat="server" Text="Fecha Nacimiento: "></asp:Label>
                        <asp:TextBox ID="text_nacimiento_far" runat="server"></asp:TextBox>
                        <br />
                        <asp:Label ID="label_cedula_reg_far" runat="server" Text="Cédula: "></asp:Label>
                        <asp:TextBox ID="text_cedula_reg_far" placeholder="Digite la Cédula" runat="server"></asp:TextBox>
                        <br />
                         <asp:Label ID="label_apellido_far" runat="server" Text="Apellido del Doctor: "></asp:Label>
                        <asp:TextBox ID="text_apellido_reg_far" placeholder="Digite su Apellido" runat="server"></asp:TextBox>
                        <br />
                        <asp:Label ID="label_telefono_far" runat="server" Text="Teléfono: "></asp:Label>
                        <asp:TextBox ID="text_telefono_reg_far" runat="server"></asp:TextBox>
                        <br />
                        <asp:Label ID="label_clave_far" runat="server" Text="Clave: "></asp:Label>
                        <asp:TextBox ID="text_clave_reg_far" runat="server"></asp:TextBox>
                        <br />
                          <asp:Label ID="label_sexo_far" runat="server" Text="Sexo:"></asp:Label>
                            <asp:DropDownList ID="DDL_sexo_far" runat="server">
                                <asp:ListItem>Seleccionar Sexo</asp:ListItem>
                                <asp:ListItem>Masculino</asp:ListItem>
                                <asp:ListItem>Femenino</asp:ListItem>
                                <asp:ListItem>Otro</asp:ListItem>
                            </asp:DropDownList>
                            <br />
                         <asp:Label ID="label_sede_doc" runat="server" Text="Seleccione una Sede:"></asp:Label>
                            <asp:DropDownList ID="DDL_sede_far" runat="server" DataSourceID="OBDS_listaSede" DataTextField="nombre" DataValueField="id_sede">
                              
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="OBDS_listaSede" runat="server" SelectMethod="traer_sede" TypeName="DAOSede"></asp:ObjectDataSource>
                            <br />
                         <br />
               
          
           
            <asp:Button ID="button_farmaceuta" runat="server" Text="Registrar Farmaceuta" OnClick="button_farmaceuta_Click"  />
            <br />
           
       
</asp:Content>

