<%@ Page Title="" Language="C#" MasterPageFile="~/View/Farmaceuta/masterFarmaceuta.master"
    AutoEventWireup="true" CodeFile="~/Controller/ConFarmaceuta/listaUsuario.aspx.cs" Inherits="View_Farmaceuta_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView ID="GV_entregas_citas" runat="server" Width="100%" CssClass="table-hover" AllowPaging="True" AutoGenerateColumns="False" DataSourceID="OBDS_entragas_pedientes" OnRowCommand="GV_entregas_citas_RowCommand" OnRowDataBound="GV_entregas_citas_RowDataBound" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" >
        <EmptyDataTemplate>
             <br />
               <asp:Label ID="label_cita" runat="server" CssClass="alert alert-warning" Text="No hay Registros"></asp:Label>
             <br />
         </EmptyDataTemplate>  
        <Columns>
            <asp:TemplateField HeaderText="id_historial" Visible="false">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("id_cita") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="label_historial" runat="server" Text='<%# Bind("id_cita") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Doctor">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("id_doctor") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="label_doctor" runat="server" Text='<%# Bind("id_doctor") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Especializacion">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("id_especializacion") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="label_especializacion" runat="server" Text='<%# Bind("id_especializacion") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Fecha de la Cita">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("fecha_cita") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="label_fecha_cita" runat="server" Text='<%# Bind("fecha_cita") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Entrega">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Button ID="but_entregar_medicamentos" runat="server" Text="Entregar Medicamentos"  CommandName="entregar" CommandArgument='<%# Bind("id_cita") %>'/>

                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="White" ForeColor="#000066" />
        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
        <RowStyle ForeColor="#000066" />
        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#007DBB" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#00547E" />
    </asp:GridView>
   
    <asp:ObjectDataSource ID="OBDS_entragas_pedientes" runat="server" SelectMethod="traerCitas_Historial" TypeName="DAOFarmaceuta">
        <SelectParameters>
            <asp:SessionParameter Name="id_usuario" SessionField="entrega" Type="Int32" />
            <asp:SessionParameter Name="sede" SessionField="sede" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
   
</asp:Content>

