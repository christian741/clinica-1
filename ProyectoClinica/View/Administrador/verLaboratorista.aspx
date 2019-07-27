<%@ Page Title="" Language="C#" MasterPageFile="~/View/Administrador/masterAdministrador.master" AutoEventWireup="true" 
    CodeFile="~/Controller/ConAdministrador/verLaboratorista.aspx.cs" Inherits="View_Administrador_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
       <div class="table-responsive" style="text-align:center;">
   
    <asp:GridView ID="GV_laboratorista" runat="server" AllowPaging="True" AllowSorting="True" DataSourceID="OBDS_Laboratorista" AutoGenerateColumns="False" OnRowDataBound="cargar_Botones_RowDataBound" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None">
        <AlternatingRowStyle BackColor="PaleGoldenrod" />
    <Columns>
               
                <asp:TemplateField HeaderText="Id" Visible="False">
                    <EditItemTemplate>
                        <asp:TextBox ID="ed_txt_id" runat="server" Text='<%# Bind("id_usuario") %>' Enabled="False"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="label_id_lab" runat="server" Text='<%# Bind("id_usuario") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Cedula" >
                    <EditItemTemplate>
                        <asp:TextBox ID="ed_txt_ced_lab" runat="server" Text='<%# Bind("cedula") %>' Enabled="False"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lab_ced_lab" runat="server" Text='<%# Bind("cedula") %>'  ></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Nombre" >
                    <EditItemTemplate>
                        <asp:TextBox ID="ed_txt_nom_lab" runat="server" Text='<%# Bind("nombre") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lab_nom_lab" runat="server" Text='<%# Bind("nombre") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Apellido" >
                    <EditItemTemplate>
                        <asp:TextBox ID="ed_txt_ape_lab" runat="server" Text='<%# Bind("apellido") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lab_ape_lab" runat="server" Text='<%# Bind("apellido") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Dirección">
                    <EditItemTemplate>
                        <asp:TextBox ID="ed_txt_dir_lab" runat="server" Text='<%# Bind("direccion") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lab_dir_lab" runat="server" Text='<%# Bind("direccion") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Teléfono">
                    <EditItemTemplate>
                        <asp:TextBox ID="ed_txt_tel_lab" runat="server" Text='<%# Bind("telefono") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lab_tel_lab" runat="server" Text='<%# Bind("telefono") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Correo">
                    <EditItemTemplate>
                        <asp:TextBox ID="ed_txt_cor_lab" runat="server" Text='<%# Bind("correo") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lab_cor_lab" runat="server" Text='<%# Bind("correo") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Contraseña">
                     <EditItemTemplate>
                        <asp:TextBox ID="ed_txt_cla_lab"  runat="server" Text='<%# Bind("clave") %>'  ></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lab_cla_lab" runat="server" Text='<%# Bind("clave") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Fecha Nacimiento">
                    <EditItemTemplate>
                        <asp:Label ID="label_nacimiento" runat="server" Text='<%# Bind("fecha_nacimieno") %>'></asp:Label>
                        <br />
                        <asp:TextBox ID="ed_txt_nac_lab" runat="server" Text='<%# Bind("fecha_nacimieno") %>'  TextMode="Date"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lab_nac_lab" runat="server" Text='<%# Bind("fecha_nacimieno") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Sexo">
                    <EditItemTemplate>
                        <asp:Label ID="label_sexo" runat="server" Text='<%# Bind("sexo") %>'></asp:Label>
                        <br />
                        <asp:DropDownList ID="DDL_sexo_lab" runat="server">
                            <asp:ListItem>Seleccione un Sexo</asp:ListItem>
                            <asp:ListItem>Maculino</asp:ListItem>
                            <asp:ListItem>Femenino</asp:ListItem>
                            <asp:ListItem>Otro</asp:ListItem>
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lab_sex_lab" runat="server" Text='<%# Bind("sexo") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Foto">
                    <EditItemTemplate>
                        <asp:Image ID="Image_e_lab" runat="server" ImageUrl='<%# Bind("foto") %>' Width="30%" />
                        <br />
                        <asp:FileUpload ID="FU_e_foto" runat="server" />
                        <br />
                        <asp:Button ID="but_act_lab" runat="server" Text="Actualizar" OnClick="but_act_lab_Click" />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Image ID="Ima_foto_lab" runat="server" ImageUrl='<%# Bind("foto") %>' Width="30%" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField Visible="False">
                    <EditItemTemplate>
                        <asp:Label ID="label_estado" runat="server" Text='<%# Bind("estado") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="label_estado" runat="server" Text='<%# Bind("estado") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Sede">
                    <EditItemTemplate>
                         <asp:Label ID="label_sede" runat="server" Text='<%# Bind("sede_id") %>'></asp:Label>
                            <asp:DropDownList ID="DDL_sede_doctor" runat="server" DataSourceID="OBDS_sede" DataTextField="nombre" DataValueField="id_sede">
                            </asp:DropDownList>
                        <asp:ObjectDataSource ID="OBDS_sede" runat="server" SelectMethod="traer_sede" TypeName="DAOSede" ></asp:ObjectDataSource>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="label_sede" runat="server" Text='<%# Bind("sede_id") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ShowEditButton="True" HeaderText="Editar" UpdateText="" />
                 <asp:TemplateField HeaderText="" >
                    <EditItemTemplate>
                        <asp:Button ID="but_bloquear" runat="server" Text="Bloquear" CommandName="bloquear" CommandArgument='<%# Bind("id_usuario") %>'/>
                        <asp:Button ID="but_desbloquear" runat="server" Text="Desbloquear" CommandName="desbloquear" CommandArgument='<%# Bind("id_usuario") %>'/>

                    </EditItemTemplate>
                    <ItemTemplate>
                          <asp:Button ID="but_desbloquear" runat="server" Text="Desbloquear" CommandName="desbloquear" CommandArgument='<%# Bind("id_usuario") %>'/>
                         <asp:Button ID="but_bloquear" runat="server" Text="Bloquear"  CommandName="bloquear" CommandArgument='<%# Bind("id_usuario") %>'/>
                         
                    </ItemTemplate>
                </asp:TemplateField>
               
            </Columns>
        
          <FooterStyle BackColor="Tan" />
        <HeaderStyle BackColor="Tan" Font-Bold="True" />
        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
        <SortedAscendingCellStyle BackColor="#FAFAE7" />
        <SortedAscendingHeaderStyle BackColor="#DAC09E" />
        <SortedDescendingCellStyle BackColor="#E1DB9C" />
        <SortedDescendingHeaderStyle BackColor="#C2A47B" />
        
          </asp:GridView>
        </div>
        <asp:ObjectDataSource ID="OBDS_Laboratorista" runat="server" SelectMethod="ver_Laboratorista" TypeName="DAOLaboratorista"></asp:ObjectDataSource>
  
   
   
</asp:Content>

