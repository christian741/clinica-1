<%@ Page Title="" Language="C#" MasterPageFile="~/View/Paciente/masterPaciente.master" 
    AutoEventWireup="true" CodeFile="~/Controller/ConPaciente/Remisiones.aspx.cs" Inherits="View_Paciente_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <div class="table-responsive" style="text-align:center;">

    <asp:GridView ID="GD_View_Remisiones" runat="server" CssClass="table-hover" AllowPaging="True" Width="100%" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="id_remision" DataSourceID="OBDS_remision" OnRowCommand="GD_View_Remisiones_RowCommand" OnRowDataBound="GD_View_Remisiones_RowDataBound">
         <EmptyDataTemplate>
             <br />
               <asp:Label ID="label_cita" runat="server" CssClass="alert alert-warning" Text="No hay Remisiones Registradas"></asp:Label>
             <br />
         </EmptyDataTemplate>  
        <Columns>
            <asp:TemplateField HeaderText="Id Remision" Visible="false">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("id_remision") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="label_id" runat="server" Text='<%# Bind("id_remision") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Especializacion">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("id_especializacion") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                       <asp:Label ID="label_id_especial" Visible="false" runat="server" Text='<%# Bind("id_especializacion") %>'></asp:Label>

                    <asp:Label ID="label_especial" runat="server" Text='<%# Bind("id_especializacion") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Fecha Limite">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("fecha_fin","{0:d}") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="label_fecha" runat="server" Text='<%# Bind("fecha_fin","{0:d}") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="Estado remision">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("estado_remision") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="label_estado" runat="server" Text='<%# Bind("estado_remision") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                   <asp:Label ID="label_advertencia" runat="server" Text=""></asp:Label>
                   <asp:Button ID="but_quitar" runat="server" Visible="false" Text="Listo" CssClass="alert alert-info" CommandArgument='<%# Bind("id_remision") %>' CommandName="quitar" />

                    <asp:Button ID="but_crear_cita" runat="server" Text="Crear Cita Medica" CssClass="alert alert-info" CommandArgument='<%# Bind("id_remision") %>' CommandName="crear" />
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
    </div>
    <asp:ObjectDataSource ID="OBDS_remision" runat="server" SelectMethod="traerRemisiones" TypeName="Core.Core_Paciente">
        <SelectParameters>
            <asp:SessionParameter Name="id" SessionField="usuario" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>

