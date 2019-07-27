<%@ Page Title="" Language="C#" MasterPageFile="~/View/Doctor/masterDoctor.master"
    AutoEventWireup="true" CodeFile="~/Controller/ConDoctor/citasHoy.aspx.cs" Inherits="View_Doctor_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container-fluid" style="text-align:center;color:white;background-color:cornflowerblue">
        CITAS REGISTRADAS PARA HOY
    </div>
     
   <div class="table-responsive" style="text-align:center;">
        <br />
               <asp:Label ID="label_error" runat="server" Text=""></asp:Label>
             <br />
     <asp:GridView ID="GV_citas_paciente" runat="server" DataSourceID="citasHoy" CssClass="table-hover" Width="100%" AllowPaging="True" AutoGenerateColumns="False" OnRowDataBound="cargar_Boton_RowDataBound" OnRowCommand="GV_citas_paciente_RowCommand">
           <EmptyDataTemplate>
              <br />
               <asp:Label ID="label_sads" runat="server" CssClass="alert alert-warning" Text="No hay Citas Registradas"></asp:Label>
             <br />
        </EmptyDataTemplate>
         <Columns>
               <asp:TemplateField HeaderText="Id_Cita" Visible="false">
                   <EditItemTemplate>
                       <asp:Label ID="label_cita" runat="server" Text='<%# Bind("id_cita") %>'></asp:Label>
                   </EditItemTemplate>
                   <ItemTemplate>
                       <asp:Label ID="label_cita" runat="server" Text='<%# Bind("id_cita") %>'></asp:Label>
                   </ItemTemplate>
               </asp:TemplateField>
               <asp:TemplateField HeaderText="Especializacion">
                   <EditItemTemplate>
                       <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("id_especializacion") %>'></asp:TextBox>
                   </EditItemTemplate>
                   <ItemTemplate>
                       <asp:Label ID="label_especial" runat="server" Text='<%# Bind("id_especializacion") %>'></asp:Label>
                   </ItemTemplate>
               </asp:TemplateField>
                <asp:TemplateField HeaderText="id_paciente" Visible="false">
                   <EditItemTemplate>
                       <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("id_paciente") %>'></asp:TextBox>
                   </EditItemTemplate>
                   <ItemTemplate>
                       <asp:Label ID="label_id_paciente" runat="server" Text='<%# Bind("id_paciente") %>'></asp:Label>
                   </ItemTemplate>
               </asp:TemplateField>
               <asp:TemplateField HeaderText="Paciente">
                   <EditItemTemplate>
                       <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("id_paciente") %>'></asp:TextBox>
                   </EditItemTemplate>
                   <ItemTemplate>
                       <asp:Label ID="label_paciente" runat="server" Text='<%# Bind("id_paciente") %>'></asp:Label>
                   </ItemTemplate>
               </asp:TemplateField>
               <asp:TemplateField HeaderText="Sede">
                   <EditItemTemplate>
                       <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("id_sede") %>'></asp:TextBox>
                   </EditItemTemplate>
                   <ItemTemplate>
                       <asp:Label ID="label_sede" runat="server" Text='<%# Bind("id_sede") %>'></asp:Label>
                   </ItemTemplate>
               </asp:TemplateField>
               <asp:TemplateField HeaderText="Fecha Cita">
                   <EditItemTemplate>
                       <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("fecha_cita") %>'></asp:TextBox>
                   </EditItemTemplate>
                   <ItemTemplate>
                       <asp:Label ID="label_fecha_cita" runat="server" Text='<%# Bind("fecha_cita") %>'></asp:Label>
                   </ItemTemplate>
               </asp:TemplateField>
               <asp:TemplateField HeaderText="Razon">
                   <EditItemTemplate>
                       <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("razon") %>'></asp:TextBox>
                   </EditItemTemplate>
                   <ItemTemplate>
                       <asp:Label ID="label_razon" runat="server" Text='<%# Bind("razon") %>'></asp:Label>
                   </ItemTemplate>
               </asp:TemplateField>
               <asp:TemplateField HeaderText="Atencion">
                   <EditItemTemplate>
                   </EditItemTemplate>
                   <ItemTemplate>
                         <asp:Button ID="but_atender" runat="server" Text="Atender" CssClass="btn btn-success" CommandName="atender" CommandArgument='<%# Bind("id_cita") %>' />
                          <asp:Button ID="but_noVino" runat="server" Text="No llego" CssClass="btn btn-warning" CommandName="noVino" />

                   </ItemTemplate>
               </asp:TemplateField>
           </Columns>
        </asp:GridView>
       <asp:ObjectDataSource ID="citasHoy" runat="server" SelectMethod="traerCitas_Doctor" TypeName="DAOCita">
           <SelectParameters>
               <asp:SessionParameter Name="id_usuario" SessionField="usuario" Type="Int32" />
               <asp:ControlParameter ControlID="fecha_hoy" Name="fecha" PropertyName="Text" Type="String" />
           </SelectParameters>
       </asp:ObjectDataSource>
       <asp:Label ID="fecha_hoy" runat="server" Text="Label" Visible="false"></asp:Label>
   </div>
    
</asp:Content>

