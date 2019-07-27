<%@ Page Title="" Language="C#" MasterPageFile="~/View/Doctor/masterDoctor.master" 
    AutoEventWireup="true" CodeFile="~/Controller/ConDoctor/atenderPaciente.aspx.cs" Inherits="View_Doctor_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
     <asp:FormView ID="FV_usuario" runat="server" DataSourceID="OBDS_usuario" >
        <ItemTemplate>
<div class="table-responsive">
    <table class="table table-sm" style="width:100%">
      <thead>
        <tr >
            
            <caption>Información del Paciente</caption>
            <div class="container-fluid" style="text-align:center;color:white;background-color:blue">
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
    <asp:ObjectDataSource ID="OBDS_usuario" runat="server" SelectMethod="buscar_Usuario" TypeName="DAOUsuario">
        <SelectParameters>
            <asp:SessionParameter Name="cedula" SessionField="paciente" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>

    <div class="table-responsive">
    <table class="table table-sm" style="width:100%">
      <thead>
                    
            <caption>Informacion general</caption>
            <div class="container-fluid" style="text-align:center;color:white;background-color:blue">
            INFORMACION GENERAL
            </div>
            
        </tr>
      </thead>
      <tbody>
        <tr>
          <th scope="row" >            
          </th>
          <td>
                <asp:Label ID="Label_error_altura" runat="server" Text="" Visible="false"></asp:Label>

                <asp:Label ID="Label_altura" runat="server" Text="Digite la Altura Del Paciente"></asp:Label>
                <asp:TextBox ID="text_altura" runat="server" TextMode="Number" ></asp:TextBox> Metros.
          </td>
          <td >
                 <asp:Label ID="Label_error_peso" runat="server" Text="" Visible="false"></asp:Label>

                <asp:Label ID="Label_peso" runat="server" Text="Digite el Peso del Paaciente:"></asp:Label>
                <asp:TextBox ID="text_peso" runat="server" TextMode="Number" ></asp:TextBox>Kilogramos
    
          </td>
           
          
        </tr>
        <tr>
         <th scope="row"></th>
          <td>
                  <asp:Label ID="label_error_fre_res" runat="server" Text="" Visible="false"></asp:Label>

                  <asp:Label ID="lab_fre_res" runat="server" Text="Digite la Frecuencia Respitratoria"></asp:Label>
                   <asp:TextBox ID="text_fre_res" runat="server" TextMode="Number"></asp:TextBox>
  
          </td>
          <td>
                  <asp:Label ID="lab_error_fre" runat="server" Text="" Visible="false"></asp:Label>

               <asp:Label ID="lab_fre_car" runat="server" Text="Digite la Frecuencia Cardiaca:"></asp:Label>
               <asp:TextBox ID="text_fre_car" runat="server" TextMode="Number"></asp:TextBox>
  
             </td>
        </tr>
         <tr>
         <th scope="row"> </th>
              <asp:Label ID="label_error_Observaciones" runat="server" Text="" Visible="false"></asp:Label>

              <br />
                 <asp:Label ID="label_observaciones" runat="server" Text="Observacion del Doctor al paciente"></asp:Label>
                <br />
                <asp:TextBox ID="text_observaciones" runat="server" TextMode="MultiLine" Height="100px" Width="90%" ></asp:TextBox>
                <br />
         
        </tr>
        <tr>
        <th scope="row"></th>
          <td>
               <br />
                <asp:DropDownList ID="DDL_medicamento" runat="server" AutoPostBack="True" DataSourceID="OBDS_medicamento" DataTextField="nombre" DataValueField="codigo"  Width="222px" ></asp:DropDownList>
                <asp:ObjectDataSource ID="OBDS_medicamento" runat="server" SelectMethod="traer_Medicamento_Sede" TypeName="DAOMedicamento">
                    <SelectParameters>
                        <asp:SessionParameter Name="sede" SessionField="sede" Type="Int32" />
                    </SelectParameters>
               </asp:ObjectDataSource>
                <br />
          </td>
          <td>
               <asp:FormView ID="FV_medicamento" runat="server" DataSourceID="traerMedicamento" >
                   <ItemTemplate>

                        <asp:Label ID="label_codigo" runat="server" Text='<%# Bind("codigo") %>' Visible="false"></asp:Label>
                       <br />
                        <asp:Label ID="label__cantidad" runat="server" Text="Nombre del Medicamento: " ></asp:Label>

                        <asp:Label ID="label_nombre" runat="server" Text='<%# Bind("nombre") %>'></asp:Label>
                       <br />
                       <asp:Label ID="label__descripcion" runat="server" Text="Descripción del Medicamento: " ></asp:Label>
                       <br />
               <asp:Label ID="label_descripcion" runat="server" Text='<%# Bind("descripcion") %>'></asp:Label>
                        <asp:Label ID="label4" runat="server" Text="Stock Medicamento: " ></asp:Label>

                        <asp:Label ID="label5" runat="server" Text='<%# Bind("stock") %>'></asp:Label>
                       <br />
                       <asp:Button ID="Button_añadir" runat="server" Text="Añadir a la Lista" OnClick="Button_añadir_Click" />
                   </ItemTemplate>
                </asp:FormView>
                <asp:ObjectDataSource ID="traerMedicamento" runat="server" SelectMethod="BuscarMedicamento" TypeName="DAOMedicamento">
                <SelectParameters>
                    <asp:ControlParameter ControlID="DDL_medicamento" Name="codigo" PropertyName="SelectedValue" Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>
          </td>
        </tr>
        
      </tbody>
    </table>

  <div class="table-responsive">
 <table class="table table-sm" style="width:100%">
      <thead>
                    
            <caption>Información Medicamentocamento</caption>
            <div class="container-fluid" style="text-align:center;color:white;background-color:blue">
            INFORMACION MEDICAMENTOS
            </div>
            
        </tr>
      </thead>
      <tbody>
        <tr>
          <th scope="row" >            
          </th>
          <asp:GridView ID="GV_lista_medicamentos" runat="server" AutoGenerateColumns="False"  AllowPaging="True"  Width="100%" DataKeyNames="codigo" OnRowCommand="GV_lista_medicamentos_RowCommand" OnPageIndexChanging="GV_lista_medicamentos_PageIndexChanging" 
         >
        <Columns>
            <asp:TemplateField HeaderText="Codigo" SortExpression="Codigo">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Codigo") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="label_codigo" runat="server" Text='<%# Bind("Codigo") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Nombre" SortExpression="Nombre">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Nombre") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("Nombre") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Descripcion" SortExpression="Descripcion">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Descripcion") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="label_descripcion" runat="server" Text='<%# Bind("Descripcion") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
              <asp:TemplateField HeaderText="Descripcion" SortExpression="Descripcion">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Descripcion") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="label_envase" runat="server" Text='<%# Bind("Stock") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Cantidad">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="label_error_cantidad" runat="server" Text="" Visible="false"></asp:Label>
                    <asp:TextBox ID="text_cantidad" runat="server" TextMode="Number"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Modo de Uso">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="label_error_uso" runat="server" Text="" Visible="false"></asp:Label>

                    <asp:TextBox ID="text_uso" runat="server" TextMode="MultiLine" Height="100%" Width="100%"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Quitar">
                <EditItemTemplate>
                    <asp:Button ID="but_quitar" runat="server" Text="Quitar" />
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Button ID="but_quitar" runat="server" Text="Quitar"   CommandArgument='<%# Bind("Codigo") %>' CommandName="quitar" />
                </ItemTemplate>
            </asp:TemplateField>
         

        </Columns>
    </asp:GridView>
    <asp:Button ID="but_salvar_med" runat="server" Text="Guardar Cambios" OnClick="but_salvar_med_Click" />
         <asp:Button ID="but_relizarCambios" runat="server" Text="Realizar Cambios" Visible="false" OnClick="but_cam_med_Click" />
    
                  
        </tr>
          </tbody>
        </table>     
  </div>     

  <div class="table-responsive">
 <table class="table table-sm" style="width:100%">
      <thead>
                    
            <caption>Información Extra</caption>
            <div class="container-fluid" style="text-align:center">
            INFORMACION Extra
            </div>
            
        </tr>
      </thead>
      <tbody>
         <tr>
         <th scope="row"></th>
             <td>
               <!-- Button trigger modal -->
                <button type="button"  class="btn btn-outline-primary" data-toggle="modal" data-target="#LoginModal">
                <span class="fa fa-user-friends" style="font-size:x-large;font-weight:bold;color:white"></span>Incapacidad

                </button>
                <!-- Fin de botton trigger-->

                </td>
              <td>
                  <!-- Button trigger modal -->
                <button type="button" class="btn btn-outline-primary" data-toggle="modal" data-target="#modal_remitid">
                <span class="fa fa-user-friends" style="font-size:x-large;font-weight:bold;color:white"></span>Remision

                </button>
                <!-- Fin de botton trigger-->


              </td>
        </tr>
         <tr>
        <th scope="row"></th>
          <td>
              <asp:Label ID="label_error_guardar" runat="server" Text="" Visible="false"></asp:Label>
                   <asp:Button ID="GuardarCita" runat="server" Text="Terminar" OnClick="GuardarCita_Click" />

          </td>
          </tr>
          </tbody>
        </table>     
  </div>     
     

                <!-- Modal -->
                <div class="modal fade" id="LoginModal" tabindex="-1" role="dialog" aria-labelledby="LoginModal_1" aria-hidden="true">
                  <div class="modal-dialog" role="document">
                    <div class="modal-content">
                      <div class="modal-header">
                        <h5 class="modal-title" id="LoginModal_1">Generar Incapacidad</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                          <span aria-hidden="true">&times;</span>
                        </button>
                      </div>
                      <div class="modal-body">
                           <br />
                         
                                    
                             <asp:Label ID="label_Incaacidad" runat="server" Text="" Visible="false"></asp:Label>

                               
        
                            
                           <asp:Label ID="label_error_dias_in" runat="server" Text="" Visible="false"></asp:Label>

                            <asp:Label ID="label_dias_inca" runat="server" Text="Digite la Cantidad de dias que va a dar de Incapacidad"></asp:Label>
                            <br />
                            <asp:TextBox ID="text__dias_incapacidad" runat="server" TextMode="Number"></asp:TextBox>
                            <br />
                           <br />
                           <asp:Label ID="label_error_razon_in" runat="server" Text="" Visible="false"></asp:Label>

                            <asp:Label ID="label_razon" runat="server" Text="Digite la razon de la Incapacidad"></asp:Label>
                            <br />
                            <asp:TextBox ID="text_razon_incapa" runat="server" TextMode="MultiLine" ></asp:TextBox>
               
                      <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" >Salir</button>
                    <asp:Button ID="but_generarIncapacidad" CssClass="btn btn-outline-primary" runat="server" Text="Generar Incapacidad " OnClick="but_generarIncapacidad_Click" />
                       
                      </div>
                    </div>
                  </div>
                </div>
    </div>
                <!-- Fin del Modal-->
                    
                <!-- Modal -->
                <div class="modal fade" id="modal_remitid" tabindex="-1" role="dialog" aria-labelledby="LoginModal_2" aria-hidden="true">
                  <div class="modal-dialog" role="document">
                    <div class="modal-content">
                      <div class="modal-header">
                        <h5 class="modal-title" id="LoginModal_2" >Generar Remision</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                          <span aria-hidden="true">&times;</span>
                        </button>
                      </div>
                        <div class="modal-body">
                                    
                             <asp:Label ID="label_remision" runat="server" Text="" Visible="false"></asp:Label>

                               
                          <asp:Label ID="label_error_DDL" runat="server" Text="" Visible="false"></asp:Label>

                          <asp:Label ID="Remision" runat="server" Text="Seleccione a que Especializacion desea remitirlo"></asp:Label>
                             <br />
                                <asp:DropDownList ID="DDL_Especializacion" runat="server" DataSourceID="OBDS_traerEspecializacion" DataTextField="nombre" DataValueField="id"  Width="222px" ></asp:DropDownList>
                                <asp:ObjectDataSource ID="OBDS_traerEspecializacion" runat="server" SelectMethod="especial_DDL" TypeName="DAOEspecializacion"></asp:ObjectDataSource>
                             <br />
                          <asp:Label ID="label_error_dias_re" runat="server" Text="" Visible="false"></asp:Label>

                          <asp:Label ID="label_dias_Remitido" runat="server" Text="Digite el numero de Dias para que el paciente aparte su cita"></asp:Label>
                          <asp:TextBox ID="txt_dias_remitido" runat="server" TextMode="Number" placeholder="Dias Cita"></asp:TextBox>
                      </div>
                            <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" >Salir</button>
                        <asp:Button ID="Button_remision" runat="server" Text="Remitir" OnClick="Button_remision_Click" />
                       
                      </div>
                    </div>
                  </div>
                </div>
                <!-- Fin del Modal-->
       
    </asp:Content>

