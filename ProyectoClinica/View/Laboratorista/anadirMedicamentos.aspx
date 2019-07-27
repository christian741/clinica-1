<%@ Page Title="" Language="C#" MasterPageFile="~/View/Laboratorista/masterLaboratorista.master"
    AutoEventWireup="true" CodeFile="~/Controller/ConLaboratorista/anadirMedicamentos.aspx.cs" Inherits="View_Laboratorista_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="table-responsive" style="text-align:center;">
       <asp:GridView ID="GV_Pedido" runat="server" AllowPaging="True" CssClass="table-hover" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="OBDS_pedido" OnRowCommand="GV_Pedido_RowCommand" OnRowDataBound="GV_Pedido_RowDataBound" Width="100%"   >
           <Columns>
               <asp:TemplateField HeaderText="id" Visible="false">
                   <EditItemTemplate>
                       <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("id_pedido") %>'></asp:TextBox>
                   </EditItemTemplate>
                   <ItemTemplate>
                       <asp:Label ID="Label4" runat="server" Text='<%# Bind("id_pedido") %>'></asp:Label>
                   </ItemTemplate>
               </asp:TemplateField>
                <asp:TemplateField HeaderText="Fecha del Pedido Realizado">
                   <EditItemTemplate>
                       <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("id_pedido") %>'></asp:TextBox>
                   </EditItemTemplate>
                   <ItemTemplate>
                       <asp:Label ID="label_fecha_pedido" runat="server" Text='<%# Bind("fecha_pedido","{0:d}") %>'></asp:Label>
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
               <asp:TemplateField HeaderText="Estado Pedido">
                   <EditItemTemplate>
                       <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                   </EditItemTemplate>
                   <ItemTemplate>
                       <br />
                       <asp:Label ID="label_estado" runat="server" Text='<%# Bind("estado_pedido") %>'></asp:Label>
                                         <br />

                       </ItemTemplate>
               </asp:TemplateField>
               <asp:TemplateField HeaderText="Atender">
                   <EditItemTemplate>
                       <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                   </EditItemTemplate>
                   <ItemTemplate>
                       <asp:Button ID="but_atender_pedido" runat="server" Text="Atender"  CommandName="atender" CommandArgument='<%# Bind("id_pedido") %>'/>
                        <asp:Button ID="but_cancelar_pedido" runat="server" Text="Cancelar Pedido"  CommandName="cancelar" CommandArgument='<%# Bind("id_pedido") %>' />
                   </ItemTemplate>
               </asp:TemplateField>
           </Columns>
        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F7F7F7" />
        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
        <SortedDescendingCellStyle BackColor="#E5E5E5" />
        <SortedDescendingHeaderStyle BackColor="#242121" />
        </asp:GridView>
        
   </div>
         <asp:ObjectDataSource ID="OBDS_pedido" runat="server" SelectMethod="ver_Pedido" TypeName="DAOLaboratorista">
             <SelectParameters>
                 <asp:SessionParameter Name="sede" SessionField="sede" Type="Int32" />
             </SelectParameters>
         </asp:ObjectDataSource>

        
   
</asp:Content>

