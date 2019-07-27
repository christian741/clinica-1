<%@ Page Title="" Language="C#" MasterPageFile="~/View/Laboratorista/masterLaboratorista.master" 
    AutoEventWireup="true" CodeFile="~/Controller/ConLaboratorista/verMedicamentos.aspx.cs" Inherits="View_Laboratorista_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <div class="table-responsive" style="text-align:center;">

    <asp:GridView ID="GV_medicamentos" runat="server" AllowPaging="True" CssClass="table-hover" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="codigo" DataSourceID="OBDS_medicamentosSede" ForeColor="Black" GridLines="Horizontal" Width="100%">
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
                    <asp:Button ID="actualizar" runat="server" Text="Actualizar" OnClick="but_act_doc_Click" CommandArgument='<%# Bind("codigo") %>'  />
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("stock") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowEditButton="True" UpdateText="" />
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
    <asp:ObjectDataSource ID="OBDS_medicamentosSede" runat="server" SelectMethod="traer_vistaMedicamento_Sede" TypeName="DAOMedicamento">
        <SelectParameters>
            <asp:SessionParameter Name="sede" SessionField="sede" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>

