<%@ Page Title="Registro Doctor" Language="C#" MasterPageFile="~/View/Administrador/masterAdministrador.master" AutoEventWireup="true" 
    CodeFile="~/Controller/ConAdministrador/registrarDoctor.aspx.cs" Inherits="View_Administrador_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
          
                       <asp:Image ID="Image_Registro_doc" runat="server" Width="30%" />
                       <br />
                       <asp:FileUpload ID="FU_registro_doc" runat="server" />
                           <asp:Label ID="label_erro_imagen" runat="server" Text=""> </asp:Label><br /><br />

                       <br />

                         <asp:Label ID="label_nombre_reg_doc" runat="server" Text="Nombre Doctor: "></asp:Label>
                        <asp:TextBox ID="text_nombre_reg_doc" placeholder="Digite el Nombre" runat="server" MaxLength="20"></asp:TextBox>
                        <asp:Label ID="label_error_nombre" runat="server" Text=""> </asp:Label><br /><br />
                    
    <br />
                     <asp:Label ID="label_direccion_doc" runat="server" Text="Dirección: "></asp:Label>
                    <asp:TextBox ID="text_direccion_reg_doc" placeholder="Digite su Dirección" runat="server" MaxLength="50"></asp:TextBox>
                   <asp:Label ID="label_error_direccion" runat="server" Text=""> </asp:Label><br /><br />
              
    <br />
                    <asp:Label ID="label_correo_doc" runat="server" Text="Correo: "></asp:Label>
                    <asp:TextBox ID="text_correo_reg_doc" runat="server" TextMode="Email" MaxLength="50"></asp:TextBox>
                        <asp:Label ID="label_error_correo" runat="server" Text=""> </asp:Label><br /><br />
               
    <br />
                         <asp:Label ID="label_fecha_nacimiento_doc" runat="server" Text="Fecha Nacimiento: "></asp:Label>
                        <asp:TextBox ID="text_nacimiento_doc" runat="server" TextMode="Date"></asp:TextBox>
                             <asp:Label ID="label_error_nacimiento" runat="server" Text=""> </asp:Label><br /><br />
                    
    <br />
                    
                        <asp:Label ID="label_cedula_reg_doc" runat="server" Text="Cédula: "></asp:Label>
                        <asp:TextBox ID="text_cedula_reg_doc" placeholder="Digite su Cédula" MaxLength="10" TextMode="Number" runat="server"></asp:TextBox>
                     <asp:Label ID="label_error_ced" runat="server" Text=""> </asp:Label><br /><br />
 
    <br />
                         <asp:Label ID="label_apellido_doc" runat="server" Text="Apellido del Doctor: "></asp:Label>
                        <asp:TextBox ID="text_apellido_reg_doc" placeholder="Digite su Apellido" MaxLength="20" runat="server"></asp:TextBox>
                      <asp:Label ID="label_error_apellido" runat="server" Text=""> </asp:Label><br /><br />

    <br />
                        <asp:Label ID="label_telefono_doc" runat="server" Text="Teléfono: "></asp:Label>
                        <asp:TextBox ID="text_telefono_reg_doc" runat="server" MaxLength="10" TextMode="Number"></asp:TextBox>
                       <asp:Label ID="label_error_telefono" runat="server" Text=""> </asp:Label><br /><br />
                    
    <br />
                        <asp:Label ID="label_clave_doc" runat="server" Text="Clave: "></asp:Label>
                        <asp:TextBox ID="text_clave_reg_doc" runat="server" MaxLength="16" TextMode="Password"></asp:TextBox>
                     <asp:Label ID="label_error_pass" runat="server" Text=""> </asp:Label><br /><br />
                   
    <br />
                          <asp:Label ID="label_sexo_doc" runat="server" Text="Sexo:"></asp:Label>
                            <asp:DropDownList ID="DDL_sexo_doctor" runat="server">
                                <asp:ListItem>Seleccionar Sexo</asp:ListItem>
                                <asp:ListItem>Masculino</asp:ListItem>
                                <asp:ListItem>Femenino</asp:ListItem>
                                <asp:ListItem>Otro</asp:ListItem>
                            </asp:DropDownList>
                            <br />
                             <asp:Label ID="label_error_sexo" runat="server" Text=""> </asp:Label><br /><br />

                         <asp:Label ID="label_sede_doc" runat="server" Text="Seleccione una Sede:"></asp:Label>
                            <asp:DropDownList ID="DDL_sede_doctor" runat="server" DataSourceID="OBDS_sede" DataTextField="sede_nombre" DataValueField="sede_id">
                            </asp:DropDownList>
                                <asp:ObjectDataSource ID="OBDS_sede" runat="server" SelectMethod="ver_Sede_DDL" TypeName="DAOSede" ></asp:ObjectDataSource>
                             <asp:Label ID="label_error_sede" runat="server" Text=""> </asp:Label><br /><br />

                             <asp:Label ID="label_horario" runat="server" Text="Seleccione una Horario  Para el Doctor:"></asp:Label>
                            <asp:DropDownList ID="DDL_horario" runat="server">
                                <asp:ListItem>Seleccione un horario</asp:ListItem>
                                <asp:ListItem>Diurno</asp:ListItem>
                                <asp:ListItem>Tarde</asp:ListItem>
                                <asp:ListItem>Nocturno</asp:ListItem>
                        </asp:DropDownList>
                             <asp:Label ID="label_error_horario" runat="server" Text=""> </asp:Label><br /><br />

                            <br />
                         <asp:Label ID="label_especializacion" runat="server" Text="Seleccione una Especializacion:"></asp:Label>
                            <asp:DropDownList ID="DDL_doctor_especializacion" runat="server" DataSourceID="OBDS_especializacion" DataTextField="nombre" DataValueField="id"> 
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="OBDS_especializacion" runat="server" SelectMethod="especial_DDL" TypeName="DAOEspecializacion" ></asp:ObjectDataSource>
                          <asp:Label ID="label_error_especial" runat="server" Text=""> </asp:Label><br /><br />
                   
    <br />
            <asp:Label ID="label_horas" runat="server" Text="Digite cuantos minutos o horas Tardara la Cita Medica"></asp:Label>

            <asp:TextBox ID="txt_horas" runat="server" TextMode="Time"></asp:TextBox>
              <asp:Label ID="label_error_horas" runat="server" Text=""> </asp:Label><br /><br />


            <asp:Button ID="button_doctor" runat="server" Text="Registrar Doctor" OnClick="button_doctor_Click" />
            <br />
            

       
</asp:Content>

