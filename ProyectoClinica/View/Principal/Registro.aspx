<%@ Page Title="Registro" Language="C#" MasterPageFile="~/View/Principal/MasterPrincipal.master" AutoEventWireup="true"
    CodeFile="~/Controller/ConPrincipal/Registro.aspx.cs" Inherits="View_Principal_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container-fluid">
         
            <div class="container-fluid" style="text-align:center;color:white;background-color:#1F618D  ">
               <h2>REGISTRO PACIENTE</h2> 
            </div>
    <div class="col">
  
                       <asp:FileUpload ID="FU_registro" runat="server" /> 
                       <asp:Label ID="label_erro_imagen" runat="server" Text=""> </asp:Label><br /><br />

              
                         <asp:Label ID="label_nombre_reg" runat="server" Text="Nombre: "></asp:Label>
                            <asp:TextBox ID="text_nombre_reg" placeholder="Digite su Nombre"  runat="server"></asp:TextBox>
                         <asp:Label ID="label_error_nombre" runat="server" Text=""> </asp:Label><br /><br />

                        
                     <asp:Label ID="label_direccion" runat="server" Text="Dirección: "></asp:Label>
                    <asp:TextBox ID="text_direccion_reg" placeholder="Digite su Dirección" runat="server"></asp:TextBox>
                     <asp:Label ID="label_error_direccion" runat="server" Text=""> </asp:Label><br /><br />

                  

                    <asp:Label ID="label_correo" runat="server" Text="Correo: "></asp:Label>
                    <asp:TextBox ID="text_correo_reg" runat="server" placeholder="Digite su Correo" TextMode="Email"></asp:TextBox>
                    <asp:Label ID="label_error_correo" runat="server" Text=""> </asp:Label><br /><br />

                         <asp:Label ID="label_fecha_nacimiento" runat="server" Text="Fecha Nacimiento: "></asp:Label>
                        <asp:TextBox ID="text_nacimiento" runat="server"  TextMode="Date"></asp:TextBox>
                         <asp:Label ID="label_error_nacimiento" runat="server" Text=""> </asp:Label><br /><br />
                 </div>
                   <div class="col">     
                        
                        <asp:Label ID="label_cedula_reg" runat="server" Text="Cédula: "></asp:Label>
                        <asp:TextBox ID="text_cedula_reg" placeholder="Digite su Cédula" TextMode="Number" runat="server"></asp:TextBox>
                        <asp:Label ID="label_error_ced" runat="server" Text=""> </asp:Label><br /><br />

                         <asp:Label ID="label_apellido" runat="server" Text="Apellido: "></asp:Label>
                        <asp:TextBox ID="text_apellido_reg" placeholder="Digite su Apellido" runat="server"></asp:TextBox>
                        <asp:Label ID="label_error_apellido" runat="server" Text=""> </asp:Label><br /><br />
                      

                        <asp:Label ID="label_telefono" runat="server" Text="Teléfono: "></asp:Label>
                        <asp:TextBox ID="text_telefono_reg" placeholder="Digite su Telefono" runat="server" TextMode="Number"></asp:TextBox>
                   <asp:Label ID="label_error_telefono" runat="server" Text=""> </asp:Label><br /><br />

                        <asp:Label ID="label_clave" runat="server" Text="Clave: "></asp:Label>
                        <asp:TextBox ID="text_clave_reg" placeholder="Digite su Contraseña" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:Label ID="label_error_pass" runat="server" Text=""> </asp:Label><br /><br />

                          <asp:Label ID="label_sexo" runat="server" Text="Sexo:"></asp:Label>
                            <asp:DropDownList ID="DrpD_paciente" runat="server">
                                <asp:ListItem>Seleccionar Sexo</asp:ListItem>
                                <asp:ListItem>Masculino</asp:ListItem>
                                <asp:ListItem>Femenino</asp:ListItem>
                                <asp:ListItem>Otro</asp:ListItem>
                            </asp:DropDownList>
                         <asp:Label ID="label_error_sexo" runat="server" Text=""> </asp:Label><br /><br />
                    </div>
               
            <asp:Button ID="button_paciente" runat="server" OnClick="button_paciente_Click" Text="Registrarse" />
            <br />
  
     
    </div>
    </div>
    
    

</asp:Content>

