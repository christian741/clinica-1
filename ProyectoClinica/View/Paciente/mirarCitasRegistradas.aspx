<%@ Page Title="" Language="C#" MasterPageFile="~/View/Paciente/masterPaciente.master"
    AutoEventWireup="true" CodeFile="~/Controller/ConPaciente/mirarCitasRegistradas.aspx.cs" Inherits="View_Paciente_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
       <div class="table-responsive" style="text-align:center;">

     <asp:GridView ID="GV_citas_paciente" runat="server" Width="100%" CssClass="table-hover" DataSourceID="citasHoy" AllowPaging="True" AutoGenerateColumns="False" OnRowDataBound="cargar_Boton_RowDataBound" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCommand="GV_citas_paciente_RowCommand">
         <EditRowStyle BackColor="#999999" />
         <EmptyDataTemplate>
             <br />
               <asp:Label ID="label_cita" runat="server" CssClass="alert alert-warning" Text="No hay Citas Registradas"></asp:Label>
             <br />
         </EmptyDataTemplate>  
         <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
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
               <asp:TemplateField HeaderText="Doctor">
                   <EditItemTemplate>
                       <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("id_doctor") %>'></asp:TextBox>
                   </EditItemTemplate>
                   <ItemTemplate>
                       <asp:Label ID="label_doctor" runat="server" Text='<%# Bind("id_doctor") %>'></asp:Label>
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
               <asp:TemplateField HeaderText="Cancelar">
                   <EditItemTemplate>
                   </EditItemTemplate>
                   <ItemTemplate>
                         <asp:Button ID="but_cancelar" runat="server" Text="Cancelar Cita" CommandArgument='<%# Bind("id_cita") %>' CommandName="cancelar" />

                   </ItemTemplate>
               </asp:TemplateField>
           </Columns>
         <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
         <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
         <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
         <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
         <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
         <SortedAscendingCellStyle BackColor="#E9E7E2" />
         <SortedAscendingHeaderStyle BackColor="#506C8C" />
         <SortedDescendingCellStyle BackColor="#FFFDF8" />
         <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
       <asp:ObjectDataSource ID="citasHoy" runat="server" SelectMethod="traerCitas_Paciente" TypeName="DAOCita">
           <SelectParameters>
               <asp:SessionParameter Name="id_usuario" SessionField="usuario" Type="Int32" />
               <asp:ControlParameter ControlID="fecha_hoy" Name="fecha" PropertyName="Text" Type="String" />
           </SelectParameters>
       </asp:ObjectDataSource>
       <asp:Label ID="fecha_hoy" runat="server" Text="Label" Visible="false"></asp:Label>

 </div>
<br />
    
   
 
   
</asp:Content>

