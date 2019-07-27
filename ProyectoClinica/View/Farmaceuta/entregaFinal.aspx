<%@ Page Title="" Language="C#" MasterPageFile="~/View/Farmaceuta/masterFarmaceuta.master" 
    AutoEventWireup="true" CodeFile="~/Controller/ConFarmaceuta/entregaFinal.aspx.cs" Inherits="View_Farmaceuta_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
<asp:GridView ID="Gv_entrega_final" runat="server" DataSourceID="OBDS_med_cita" AutoGenerateColumns="False" Width="100%" OnRowCommand="Gv_entrega_final_RowCommand" AllowPaging="True" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical">
    <AlternatingRowStyle BackColor="White" />
    <EmptyDataTemplate>
             <br />
               <asp:Label ID="label_cita" runat="server" CssClass="alert alert-warning" Text="No hay Registros"></asp:Label>
             <br />
         </EmptyDataTemplate>  
    <Columns>
        <asp:TemplateField HeaderText="Codigo" Visible="false">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Codigo") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="label_codigo" runat="server" Text='<%# Bind("Codigo") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Nombre">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Nombre") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="lable_nombre" runat="server" Text='<%# Bind("Nombre") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Descripcion">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Descripcion") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="label_descripcion" runat="server" Text='<%# Bind("Descripcion") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Stock">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Stock") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="label_stock" runat="server" Text='<%# Bind("Stock") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Cantidad">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Cantidad") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="label_cantidad" runat="server" Text='<%# Bind("Cantidad") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Modo de Uso">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("MododeUso") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="label_uso" runat="server" Text='<%# Bind("MododeUso") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Entregar">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Button ID="but_entregar"  CssClass="btn btn-success" runat="server" Text="Entrega Medicamento" CommandName="entrega" CommandArgument='<%# Bind("Codigo") %>'/>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
    <FooterStyle BackColor="#CCCC99" />
    <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
    <RowStyle BackColor="#F7F7DE" />
    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
    <SortedAscendingCellStyle BackColor="#FBFBF2" />
    <SortedAscendingHeaderStyle BackColor="#848384" />
    <SortedDescendingCellStyle BackColor="#EAEAD3" />
    <SortedDescendingHeaderStyle BackColor="#575357" />
    </asp:GridView>
    <asp:Button ID="but_terminar" runat="server" Text="Terminar Entrega" OnClick="but_terminar_Click" />

    <asp:ObjectDataSource ID="OBDS_med_cita" runat="server" SelectMethod="traerCitas_Medicamentos" TypeName="DAOFarmaceuta">
        <SelectParameters>
            <asp:SessionParameter Name="id_usuario" SessionField="entrega" Type="Int32" />
            <asp:SessionParameter Name="id_cita" SessionField="entregar_id" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>


</asp:Content>
