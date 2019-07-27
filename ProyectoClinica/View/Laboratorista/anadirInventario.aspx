<%@ Page Title="" Language="C#" MasterPageFile="~/View/Laboratorista/masterLaboratorista.master"
    AutoEventWireup="true" CodeFile="~/Controller/ConLaboratorista/anadirInventario.aspx.cs" Inherits="View_Laboratorista_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <div class="table-responsive" style="text-align:center;">
       <asp:GridView ID="GV_inventario" runat="server" AllowPaging="True" CssClass="table-hover" AllowSorting="True"  AutoGenerateColumns="False" Width="100%" DataSourceID="OBDS_inventario" OnRowCommand="GV_inventario_RowCommand"   >
           <Columns>
               <asp:TemplateField HeaderText="Codigo" SortExpression="Codigo" Visible="False">
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
                       <asp:Label ID="label_nombre" runat="server" Text='<%# Bind("Nombre") %>'></asp:Label>
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
               <asp:TemplateField HeaderText="Stock" SortExpression="Stock">
                   <EditItemTemplate>
                       <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Stock") %>'></asp:TextBox>
                   </EditItemTemplate>
                   <ItemTemplate>
                       <asp:Label ID="label_stock" runat="server" Text='<%# Bind("Stock") %>'></asp:Label>
                   </ItemTemplate>
               </asp:TemplateField>
               <asp:TemplateField HeaderText="Cantidad" SortExpression="Cantidad">
                   <EditItemTemplate>
                       <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Cantidad") %>'></asp:TextBox>
                   </EditItemTemplate>
                   <ItemTemplate>
                       <asp:Label ID="label_cantidad" runat="server" Text='<%# Bind("Cantidad") %>'></asp:Label>
                   </ItemTemplate>
               </asp:TemplateField>
              
               <asp:TemplateField HeaderText="Fecha_vencimiento" SortExpression="Fecha_vencimiento">
                   <EditItemTemplate>
                       <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("Fecha_vencimiento") %>'></asp:TextBox>
                   </EditItemTemplate>
                   <ItemTemplate>
                     <asp:Label ID="label_error_dias" runat="server" Text=""></asp:Label>

                       <asp:TextBox ID="txt_fecha" runat="server" TextMode="Date"></asp:TextBox>

                   </ItemTemplate>
               </asp:TemplateField>
               <asp:TemplateField HeaderText="Recibir" SortExpression="Codigo">
                   <EditItemTemplate>
                       <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
                   </EditItemTemplate>
                   <ItemTemplate>
                       <asp:Button ID="but_recibir" runat="server" Text="Recibir" CommandName="recibir" CommandArgument='<%# Bind("Codigo") %>'/>
                       <asp:Button ID="but_no_recibir" runat="server" Text="Incompleto" CommandName="no_recibir" CommandArgument='<%# Bind("Codigo") %>'/>

                       </ItemTemplate>
               </asp:TemplateField>
           </Columns>
            
        </asp:GridView>

        <asp:ObjectDataSource ID="OBDS_inventario" runat="server" SelectMethod="llenarPedido" TypeName="DAOLaboratorista">
            <SelectParameters>
                <asp:SessionParameter Name="id_pedido" SessionField="pedido" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>

        <asp:Label ID="label_error_recibir" runat="server" Text=""></asp:Label>
        <asp:Button ID="but_guardar_cambio" runat="server" Text="Guardar Cambios" OnClick="but_guardar_cambio_Click"  />
      </div>
   

</asp:Content>

