<%@ Page Title="" Language="C#" MasterPageFile="~/View/Farmaceuta/masterFarmaceuta.master"
    AutoEventWireup="true" CodeFile="~/Controller/ConFarmaceuta/verMedicamentos.aspx.cs" Inherits="View_Farmaceuta_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="table-responsive" style="text-align:center;">

    <asp:GridView ID="GV_medicamentos" runat="server" AllowPaging="True" CssClass="table-hover" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="codigo" DataSourceID="OBDS_medicamentosSede" Width="100%" ForeColor="#333333" GridLines="None">
        <EditRowStyle BackColor="#999999" />
        <EmptyDataTemplate>
             <br />
               <asp:Label ID="label_cita" runat="server" CssClass="alert alert-warning" Text="No hay Registros"></asp:Label>
             <br />
         </EmptyDataTemplate>  
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:TemplateField  >
                <EditItemTemplate>
                    <asp:Label ID="label_codigo" runat="server"  Visible="false" Text='<%# Bind("codigo") %>' Enabled="false"></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="label_codigo" Visible="false" runat="server" Text='<%# Bind("codigo") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Nombre">
                <EditItemTemplate>
                    <asp:TextBox ID="text_nombre" runat="server" Text='<%# Bind("nombre") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="label_nombre" runat="server" Text='<%# Bind("nombre") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Descripcion">
                <EditItemTemplate>
                    <asp:TextBox ID="text_descripcion" runat="server" TextMode="MultiLine" Width="100%" Text='<%# Bind("descripcion") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="label_descripcion" runat="server" Text='<%# Bind("descripcion") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Stock">
                <EditItemTemplate>
                    <asp:Label ID="label_ed_stock" runat="server" Text='<%# Bind("stock") %>'></asp:Label>
                  <asp:dropdownlist ID="DDL_stock" runat="server">
                    <asp:ListItem>Seleccione un Stock</asp:ListItem>
                    <asp:ListItem>Capsulas</asp:ListItem>
                    <asp:ListItem>Pastas</asp:ListItem>
                    <asp:ListItem>Cremas</asp:ListItem>
                    <asp:ListItem>Jarabe</asp:ListItem>

                </asp:dropdownlist>
                    <asp:Button ID="actualizar" runat="server" Text="Actualizar" OnClick="but_act_doc_Click"   />
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("stock") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowEditButton="True" UpdateText="" />
        </Columns>
        <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
            </div>
    <asp:ObjectDataSource ID="OBDS_medicamentosSede" runat="server" SelectMethod="traer_vistaMedicamento_Sede" TypeName="DAOMedicamento">
        <SelectParameters>
            <asp:SessionParameter Name="sede" SessionField="sede" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>

