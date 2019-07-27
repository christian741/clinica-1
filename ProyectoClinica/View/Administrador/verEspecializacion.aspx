<%@ Page Title="" Language="C#" MasterPageFile="~/View/Administrador/masterAdministrador.master" AutoEventWireup="true"
    CodeFile="~/Controller/ConAdministrador/verEspecializacion.aspx.cs" Inherits="View_Administrador_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
   

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 
 <div class="table-responsive" style="text-align:center;">  
    <asp:GridView ID="GV_especializacion" runat="server" AllowPaging="True"  CssClass="table-hover" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="id_especializacion" DataSourceID="ONDS_especial"  Width="100%" OnRowDataBound="cargar_Botones_RowDataBound" OnRowCommand="GV_Especializacion_RowCommand" CellPadding="4" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:TemplateField HeaderText="Id" Visible="False">
                <EditItemTemplate>
                    <asp:TextBox ID="txt_id_esp" runat="server" Enabled="False" Text='<%# Bind("id_especializacion") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lab_esp_id" runat="server" Text='<%# Bind("id_especializacion") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Especialización">
                <EditItemTemplate>
                    <asp:TextBox ID="txt_esp_nom" runat="server" Text='<%# Bind("nombre") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lab_esp_nom" runat="server" Text='<%# Bind("nombre") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Descripción">
                <EditItemTemplate>
                    <asp:TextBox ID="txt_esp_des" runat="server" Text='<%# Bind("descripcion") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lab_esp_des" runat="server" Text='<%# Bind("descripcion") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Foto">
                <EditItemTemplate>
                    <asp:Image ID="img_ed_esp" runat="server" ImageUrl='<%# Bind("foto") %>' Width="20%" />
                    <br />
                    <asp:FileUpload ID="FU_edi_esp" runat="server" />
                    <asp:Button ID="but_ed_esp" runat="server" OnClick="but_ed_esp_Click" Text="Actualizar" />

                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Image ID="Img_esp" runat="server" ImageAlign="Middle" ImageUrl='<%# Bind("foto") %>' Width="20%" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Sexo">
                <EditItemTemplate>
                    <asp:Label ID="label_sexo" runat="server" Text='<%# Bind("sexo") %>'></asp:Label>
                    <br />
                        <br /><asp:DropDownList ID="DDL_sexo_esp" runat="server">
                            <asp:ListItem>Seleccione un Sexo</asp:ListItem>
                            <asp:ListItem>Maculino</asp:ListItem>
                            <asp:ListItem>Femenino</asp:ListItem>
                            <asp:ListItem>Ambos Sexos</asp:ListItem>
                                </asp:DropDownList>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="label_sexo" runat="server" Text='<%# Bind("sexo") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Edad">
                <EditItemTemplate>

                    <asp:Label ID="label_edad" runat="server" Text='<%# Bind("edad") %>'></asp:Label>
                    <br />

                    <asp:DropDownList ID="DDL_edad_esp" runat="server">
                        <asp:ListItem>Seleccione una Edad</asp:ListItem>
                        <asp:ListItem Value="3">Bebes</asp:ListItem>
                        <asp:ListItem Value="17">Menores de edad</asp:ListItem>
                        <asp:ListItem Value="18">Mayores de Edad</asp:ListItem>
                        <asp:ListItem Value="100">Todas las Edades</asp:ListItem>
                    </asp:DropDownList>              

                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="label_edad" runat="server" Text='<%# Bind("edad") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Prioridad">
                <EditItemTemplate>
                    <asp:Label ID="label_prioridad" runat="server" Text='<%# Bind("prioridad") %>'></asp:Label>
                    <asp:DropDownList ID="DDL_prioridad" runat="server">
                    <asp:ListItem>Seleccione un Permiso</asp:ListItem>
                    <asp:ListItem>Solo Doctores</asp:ListItem>
                    <asp:ListItem>Todos</asp:ListItem>
                </asp:DropDownList>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="label_prioridad" runat="server" Text='<%# Bind("prioridad") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowEditButton="True" UpdateText="" HeaderText="Editar" />
            <asp:TemplateField HeaderText="Estado" Visible="False">
                <EditItemTemplate>
                    <asp:Label ID="label_estado" runat="server" Text='<%# Bind("estado") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="label_estado" runat="server" Text='<%# Bind("estado") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="" >
                    <EditItemTemplate>
                        <asp:Button ID="but_bloquear" runat="server" CssClass="btn btn-danger" Text="Bloquear" CommandName="bloquear" CommandArgument='<%# Bind("id_especializacion") %>'/>
                        <asp:Button ID="but_desbloquear" runat="server"  CssClass="btn btn-success" Text="Desbloquear" CommandName="desbloquear" CommandArgument='<%# Bind("id_especializacion") %>'/>

                    </EditItemTemplate>
                    <ItemTemplate>
                          <asp:Button ID="but_desbloquear" runat="server" CssClass="btn btn-success" Text="Desbloquear" CommandName="desbloquear" CommandArgument='<%# Bind("id_especializacion") %>'/>
                         <asp:Button ID="but_bloquear" runat="server" CssClass="btn btn-danger" Text="Bloquear"  CommandName="bloquear" CommandArgument='<%# Bind("id_especializacion") %>'/>
                         
                    </ItemTemplate>
                </asp:TemplateField>
               
        </Columns>
        <EditRowStyle BackColor="#999999" />
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
 </div>
    <asp:ObjectDataSource ID="ONDS_especial" runat="server" SelectMethod="ver_Especializacion" TypeName="DAOEspecializacion" DeleteMethod="bloquear_Especializacion" UpdateMethod="Editar_Especializacion">
        <DeleteParameters>
            <asp:Parameter Name="id_especializacion" Type="Int32" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="id_especializacion" Type="Int32" />
            <asp:Parameter Name="nombre" Type="String" />
            <asp:Parameter Name="descripcion" Type="String" />
            <asp:Parameter Name="foto" Type="String" />
        </UpdateParameters>
    </asp:ObjectDataSource>
 
</asp:Content>

