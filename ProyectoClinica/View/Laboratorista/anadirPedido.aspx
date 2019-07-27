<%@ Page Title="" Language="C#" MasterPageFile="~/View/Laboratorista/masterLaboratorista.master"
    AutoEventWireup="true" CodeFile="~/Controller/ConLaboratorista/anadirPedido.aspx.cs" Inherits="View_Laboratorista_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
                 <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <br />
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
         <ContentTemplate>
             <asp:DropDownList ID="DDL_Medicamento" runat="server" DataSourceID="OBDS_medicamento" DataTextField="nombre" DataValueField="codigo" AutoPostBack="True" OnSelectedIndexChanged="DDL_Medicamento_SelectedIndexChanged">
             </asp:DropDownList>
             <asp:ObjectDataSource ID="OBDS_medicamento" runat="server" SelectMethod="traer_Medicamento_Sede" TypeName="DAOMedicamento">
                 <SelectParameters>
                     <asp:SessionParameter Name="sede" SessionField="sede" Type="Int32" />
                 </SelectParameters>
             </asp:ObjectDataSource>

             
         <asp:FormView ID="FV_medicamento" runat="server" DataSourceID="OBDS_FV_med" >
                   <ItemTemplate>
                       <div class="container-fluid">
                           INFORMACION MEDICAMENTO
                       </div>
                        <asp:Label ID="label_codigo" runat="server" Text='<%# Bind("codigo") %>' Visible="false"></asp:Label>
                       <br />
                        <asp:Label ID="label__cantidad" runat="server" Text="Nombre del Medicamento: " ></asp:Label>

                        <asp:Label ID="label_nombre" runat="server" Text='<%# Bind("nombre") %>'></asp:Label>
                       <br />
                       <asp:Label ID="label__descripcion" runat="server" Text="Descripción del Medicamento: " ></asp:Label>

                        <asp:Label ID="label_descripcion" runat="server" Text='<%# Bind("descripcion") %>'></asp:Label>
                       <br />
                        <asp:Label ID="label__stock" runat="server" Text="Descripción del Medicamento: " ></asp:Label>

                        <asp:Label ID="label_stock" runat="server" Text='<%# Bind("stock") %>'></asp:Label>
                       <br />
                   </ItemTemplate>
                </asp:FormView>
    <asp:ObjectDataSource ID="OBDS_FV_med" runat="server" SelectMethod="BuscarMedicamento" TypeName="DAOMedicamento">
        <SelectParameters>
            <asp:ControlParameter ControlID="DDL_Medicamento" Name="codigo" PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>

              <asp:Button ID="but_añadir" runat="server" Text="Añadir Datos" OnClick="but_añadir_Click" />



     <asp:GridView ID="GV_lista_medicamentos_pedido" runat="server" AutoGenerateColumns="False"  AllowPaging="True"  Width="100%" DataKeyNames="codigo" OnRowCommand="GV_lista_medicamentos_RowCommand" OnPageIndexChanging="GV_lista_medicamentos_PageIndexChanging" 
         >
        <Columns>
            <asp:TemplateField HeaderText="Codigo" SortExpression="Codigo" Visible="false">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Codigo") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="label_codigo" runat="server" Text='<%# Bind("Codigo") %>' Visible="false"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Nombre" SortExpression="Nombre">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Nombre") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("Nombre") %>'></asp:Label>
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
              <asp:TemplateField HeaderText="Descripcion" SortExpression="Stock">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Stock") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="label_envase" runat="server" Text='<%# Bind("Stock") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Cantidad">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="label_error_cantidad" runat="server" Text="" Visible="false"></asp:Label>
                    <asp:TextBox ID="text_cantidad" runat="server" TextMode="Number"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Dias de Entrega" Visible="false">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="label_error_dias" runat="server" Text="" Visible="false"></asp:Label>

                    <asp:TextBox ID="text_dias" runat="server" TextMode="Number" Height="100%" Width="100%"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Quitar">
                <EditItemTemplate>
                    <asp:Button ID="but_quitar" runat="server" Text="Quitar" />
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Button ID="but_quitar" runat="server" Text="Quitar"   CommandArgument='<%# Bind("Codigo") %>' CommandName="quitar" />
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
    <asp:Button ID="but_salvar_med" runat="server" CssClass="alert alert-success" Text="Guardar Cambios" OnClick="but_salvar_med_Click" />
         <asp:Button ID="but_relizarCambios" CssClass="alert alert-warning" runat="server" Text="Realizar Cambios" Visible="false" OnClick="but_cam_med_Click" />
    
  <asp:Button ID="GuardarPedido" runat="server" CssClass="alert alert-dark" Visible="false" Text="Terminar" OnClick="GuardarPedido_Click" />
         </ContentTemplate>
  
    </asp:UpdatePanel>
     
   
</asp:Content>

