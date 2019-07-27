<%@ Page Title="" Language="C#" MasterPageFile="~/View/Farmaceuta/masterFarmaceuta.master" 
    AutoEventWireup="true" CodeFile="~/Controller/ConFarmaceuta/entregaMedicamentos.aspx.cs" Inherits="View_Farmaceuta_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="Label_Cedula" runat="server" Text="Digite la cedula que esta Buscando"></asp:Label>
    <br />
    <asp:TextBox ID="Text_cedula" runat="server" MaxLength="10" TextMode="Number"></asp:TextBox>
    <br />
    <asp:Button ID="But_buscar" runat="server" OnClick="Button1_Click" Text="Buscar"  />
    <br />
        <asp:Label ID="label_error_busqueda" runat="server" Text=""></asp:Label>


      <asp:FormView ID="FV_usuario" runat="server" DataSourceID="OBDS_usuario" Visible="False" >
        <ItemTemplate>
<div class="table-responsive">
    <table class="table table-sm">
      <thead>
        <tr >
            
            <caption>Información del Paciente</caption>
            <div class="container-fluid" style="text-align:center">
            INFORMACION DEL USUARIO
            </div>
            
        </tr>
      </thead>
      <tbody>
        <tr>
          <th scope="row" >            
          </th>
          <td><asp:Image ID="Imagen_usu" runat="server" ImageUrl='<%# Bind("foto") %>' Width="30%" CssClass="rounded-circle" />
          </td>
          <td style="padding-right:200px">
                  <table class="table table-sm" style="width:100%">
                      <thead>
                        <tr class=" table-active;table-info;">
                           Datos Personales
                        </tr>
                      </thead>
                      <tbody>
                        <tr>
                            <th scope="row"> 
                            </th>
                            <td>
                             <asp:Label ID="label_id" runat="server" Text='<%# Bind("id_usuario") %>' Visible="false"></asp:Label>

                               <asp:Label ID="label1" runat="server" Text="Cedula:"></asp:Label> 
                               <asp:Label ID="label_cedula" runat="server" Text='<%# Bind("cedula") %>'></asp:Label>
                            </td>
                            <td>                         
                                <asp:Label ID="label2" runat="server"  Text="Nombre:"></asp:Label> 
                                <asp:Label ID="label_nombre" runat="server" Text='<%# Bind("nombre") %>'></asp:Label>
                           </td>
                           <td>
                                <asp:Label ID="label3" runat="server"  Text="Apellido:"></asp:Label>  
                                <asp:Label ID="label_apellido" runat="server" Text='<%# Bind("apellido") %>'></asp:Label>
                            </td>
                        </tr>
                    </tbody>
                  </table>
          </td>
           
          
        </tr>
        <tr>
          <th scope="row"></th>
          <td>
               <asp:Label ID="label4" runat="server"  Text="Telefono:"></asp:Label>   
               <asp:Label ID="label_telefono" runat="server" Text='<%# Bind("telefono") %>'></asp:Label>
           
          </td>
          <td>
              <asp:Label ID="label6" runat="server"  Text="Correo:"></asp:Label>  
            <asp:Label ID="label_correo" runat="server" Text='<%# Bind("correo") %>'></asp:Label>
            
          </td>
        
         
        </tr>
        
        <tr>
         <th scope="row"></th>
          <td>
              <asp:Label ID="label8" runat="server"  Text="Fecha de Nacimiento:"></asp:Label>  
            <asp:Label ID="label_nacimiento" runat="server" Text='<%# Bind("fecha_nacimieno") %>'></asp:Label>
           
          </td>
          <td>
            <asp:Label ID="label9" runat="server"  Text="Sexo:"></asp:Label>  
            <asp:Label ID="label_sexo" runat="server" Text='<%# Bind("sexo") %>'></asp:Label>
          </td>
        </tr>
         <tr>
         <th scope="row"></th>
          <td>
          </td>
          <td>
          </td>
        </tr>
         
      </tbody>
    </table>
    
  </div>     
              </ItemTemplate>
    </asp:FormView> 
                  <asp:Button ID="Button_buscar" runat="server" Text="BuscarPedido" OnClick="Button_buscar_Click" Visible="false" />

    <asp:ObjectDataSource ID="OBDS_usuario" runat="server" SelectMethod="buscar_Usuario2" TypeName="DAOUsuario">
        <SelectParameters>
            <asp:SessionParameter Name="cedula" SessionField="busqueda" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>

   



</asp:Content>

