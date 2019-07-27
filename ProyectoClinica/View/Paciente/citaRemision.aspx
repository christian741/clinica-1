<%@ Page Title="" Language="C#" MasterPageFile="~/View/Paciente/masterPaciente.master"
    AutoEventWireup="true" CodeFile="~/Controller/ConPaciente/citaRemision.aspx.cs" 
    Inherits="View_Paciente_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
        <asp:Label ID="Label_error_especial" runat="server" Text=""></asp:Label>

     <br />
     <asp:ScriptManager ID="ScriptManager1" runat="server">
     </asp:ScriptManager>
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
         <ContentTemplate>
               <asp:Label ID="label_especial" runat="server" Text="Seleccione una Especialización:"></asp:Label>
       <asp:DropDownList ID="DDL_especial" runat="server" DataSourceID="OBDS_especial" DataTextField="nombre" DataValueField="id_especializacion" AutoPostBack="True" OnSelectedIndexChanged=" buscarSede_SelectedIndexChanged" >
       </asp:DropDownList>
        <asp:ObjectDataSource ID="OBDS_especial" runat="server" SelectMethod="traer_Especial" TypeName="DAOEspecializacion" >
            <SelectParameters>
                <asp:SessionParameter Name="id_especial" SessionField="remision" Type="Int32" />
            </SelectParameters>
     </asp:ObjectDataSource>
             
    <!-- Button trigger modal -->
        <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#Especial">
          Ver informacion de la Especializacion
        </button>
                

        <!-- Modal -->
        <div class="modal fade" id="Especial" tabindex="-1" role="dialog" aria-labelledby="Especial1" aria-hidden="true">
          <div class="modal-dialog modal-dialog-scrollable" role="document">
            <div class="modal-content">
              <div class="modal-header">
                <h5 class="modal-title" id="Especial1">Especializacion</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                  <span aria-hidden="true">&times;</span>
                </button>
              </div>
              <div class="modal-body">
                  <asp:Label ID="Label1" runat="server" Text="" Visible="false"></asp:Label>
                  <asp:FormView ID="FV_especial" runat="server" DataSourceID="informacion_especial">
                   <ItemTemplate>
                        <asp:Image ID="Imagen_usu" runat="server" ImageUrl='<%# Bind("foto") %>' Width="30%" />
                       <br />
                       <asp:Label ID="Label_no" runat="server" Text="Nombre:"></asp:Label>
                       <asp:Label ID="label_nombre" runat="server" Text='<%# Bind("nombre") %>'></asp:Label>
                        <br />
                        <asp:Label ID="Label_Des" runat="server" Text="Descripción:"></asp:Label>
                        <asp:Label ID="label_descripcion" runat="server" Text='<%# Bind("descripcion") %>'></asp:Label>
                          </ItemTemplate>
                </asp:FormView>
                <asp:ObjectDataSource ID="informacion_especial" runat="server" SelectMethod="traer_Especial" TypeName="DAOEspecializacion">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="DDL_especial" Name="id_especial" PropertyName="SelectedValue" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
              </div>
              <div class="modal-footer">
                <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
              </div>
            </div>
          </div>
        </div>
   
     <br />
    
             <br />
             <asp:Label ID="label_sede_cita" runat="server" Text="Seleccione una Sede:"></asp:Label>
             <br />
             <asp:DropDownList ID="DDL_sede_cita" runat="server" AutoPostBack="True" DataSourceID="OBDS_sede" DataTextField="sede_nombre" DataValueField="sede_id" OnSelectedIndexChanged=" buscarDoctor_SelectedIndexChanged">
             </asp:DropDownList>
             <br />
             <asp:ObjectDataSource ID="OBDS_sede" runat="server" SelectMethod="traer_Sede" TypeName="DAOEspecializacion">
                 <SelectParameters>
                     <asp:ControlParameter ControlID="DDL_especial" Name="id_especializacion" PropertyName="SelectedValue" Type="Int32" />
                 </SelectParameters>
             </asp:ObjectDataSource>
                   
    <br />
     <!-- Button trigger modal -->
        <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#Sede">
          Ver informacion de la Sede</button>

        <!-- Modal -->
        <div class="modal fade" id="Sede" tabindex="-1" role="dialog" aria-labelledby="exampleModalScrollableTitle" aria-hidden="true">
          <div class="modal-dialog modal-dialog-scrollable" role="document">
            <div class="modal-content">
              <div class="modal-header">
                <h5 class="modal-title" id="exampleModalScrollableTitle">Sede</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                  <span aria-hidden="true">&times;</span>
                </button>
              </div>
              <div class="modal-body">
                   <asp:Label ID="Label_errorSede" runat="server" Text="" Visible="false"></asp:Label>

                  <asp:FormView ID="FV_Sede" runat="server" DataSourceID="informacion_sede">
                   <ItemTemplate>
                        <asp:Image ID="Imagen_usu" runat="server" ImageUrl='<%# Bind("foto") %>' Width="30%" />
                        <asp:Label ID="label_nombre" runat="server" Text='<%# Bind("nombre") %>'></asp:Label>
                        <asp:Label ID="label_descripcion" runat="server" Text='<%# Bind("descripcion") %>'></asp:Label>
                          </ItemTemplate>
                </asp:FormView>
                <asp:ObjectDataSource ID="informacion_sede" runat="server" SelectMethod="buscarSede" TypeName="DAOSede">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="DDL_sede_cita" Name="id_sede" PropertyName="SelectedValue" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
              </div>
              <div class="modal-footer">
                <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
              </div>
            </div>
          </div>
        </div>
      
    <br />
  
         </ContentTemplate>
     </asp:UpdatePanel>
    
        
     <asp:UpdatePanel ID="UpdatePanel2" runat="server">
         <ContentTemplate>
             <asp:Label ID="label_doctor_cita" runat="server" Text="Seleccione un Doctor:"></asp:Label>
             <br />
             <asp:DropDownList ID="DDL_doctor_cita" runat="server" AutoPostBack="True" DataSourceID="OBDS_doctor" DataTextField="doctor_nombre" DataValueField="doctor_id" OnSelectedIndexChanged="DDL_doctor_cita_SelectedIndexChanged">
             </asp:DropDownList>
             <br />

    <!-- Button trigger modal -->
        <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#Doctor">
          Ver informacion de Doctor</button>

        <!-- Modal -->
        <div class="modal fade" id="Doctor" tabindex="-1" role="dialog" aria-labelledby="Doctor1" aria-hidden="true">
          <div class="modal-dialog modal-dialog-scrollable" role="document">
            <div class="modal-content">
              <div class="modal-header">
                <h5 class="modal-title" id="Doctor1">Doctor</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                  <span aria-hidden="true">&times;</span>
                </button>
              </div>
              <div class="modal-body">
              <asp:Label ID="label_error_doctor" runat="server" Text="" Visible="false"></asp:Label>

              <asp:FormView ID="FV_Doctor" runat="server" DataSourceID="informacion_doctor">
                   <ItemTemplate>
                        <asp:Image ID="Imagen_usu" runat="server" ImageUrl='<%# Bind("foto") %>' Width="30%" />
                        <asp:Label ID="label_nombre" runat="server" Text='<%# Bind("nombre") %>'></asp:Label>
                        <asp:Label ID="label_descripcion" runat="server" Text='<%# Bind("apellido") %>'></asp:Label>
                          </ItemTemplate>
                </asp:FormView>
                <asp:ObjectDataSource ID="informacion_doctor" runat="server" SelectMethod="traer_doctor" TypeName="DAODoctor">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="DDL_doctor_cita" Name="id_doctor" PropertyName="SelectedValue" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
              </div>
              <div class="modal-footer">
                <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
              </div>
            </div>
          </div>
        </div>
 
         </ContentTemplate>
         <Triggers>
             <asp:AsyncPostBackTrigger ControlID="DDL_sede_cita" EventName="SelectedIndexChanged" />
             <asp:AsyncPostBackTrigger ControlID="DDL_especial" EventName="SelectedIndexChanged" />
         </Triggers>
     </asp:UpdatePanel>
    
       <asp:ObjectDataSource ID="OBDS_doctor" runat="server" SelectMethod="traer_doctor" TypeName="DAOSede">
           <SelectParameters>
               <asp:ControlParameter ControlID="DDL_sede_cita"  Name="id_sede"  PropertyName="SelectedValue" Type="Int32" />

               <asp:ControlParameter ControlID="DDL_especial" DefaultValue="id_especializacion" Name="id_especial" PropertyName="SelectedValue" Type="Int32" />

               </SelectParameters>
       </asp:ObjectDataSource>
      
     <asp:Label ID="label_fecha" runat="server" Visible="False"></asp:Label>
      
   
 
     <br />
     <asp:Label ID="label_razon_cita" runat="server" Text="Razon de la Cita:"></asp:Label>
     <asp:TextBox ID="text_razon" runat="server" TextMode="MultiLine" Width="100%" Height="100px"></asp:TextBox>
    <br />

     <asp:Label ID="label_calendario" runat="server" Text="" Visible="false"></asp:Label>

                 <br />
                 <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                     <ContentTemplate>
                         <asp:Calendar ID="Calendar_cita" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" CssClass="auto-style1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="274px" OnDayRender="Calendar_cita_DayRender" OnSelectionChanged="Calendar_cita_SelectionChanged" Width="358px">
                             <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                             <NextPrevStyle VerticalAlign="Bottom" />
                             <OtherMonthDayStyle ForeColor="#808080" />
                             <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                             <SelectorStyle BackColor="#CCCCCC" />
                             <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                             <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                         </asp:Calendar>
                         <asp:Label ID="label_hora" runat="server" Text="Seccione una Hora:"></asp:Label>
     <br />
                         <asp:DropDownList ID="DDL_fecha" runat="server" DataSourceID="OBDS_fecha" DataTextField="hora_inicio" DataValueField="hora_inicio">
                         </asp:DropDownList>
                         <asp:ObjectDataSource ID="OBDS_fecha" runat="server" SelectMethod="insertar_fecha" TypeName="DAOCita">
                             <SelectParameters>
                                 <asp:ControlParameter ControlID="DDL_doctor_cita" Name="id" PropertyName="SelectedValue" Type="Int32" />
                                 <asp:ControlParameter ControlID="label_fecha" Name="fecha" PropertyName="Text" Type="String" />
                             </SelectParameters>
                         </asp:ObjectDataSource>
                         <asp:Button ID="button_cita" runat="server" OnClick="button_cita_Click" Text="Registrar Cita" />
                     </ContentTemplate>
                 </asp:UpdatePanel>
     <br />
     <br />
     <br />
     <br />
      
   
       <br />

              
</asp:Content>

