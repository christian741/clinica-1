<%@ Page Title="" Language="C#" MasterPageFile="~/View/Administrador/masterAdministrador.master" 
    AutoEventWireup="true" CodeFile="~/Controller/ConAdministrador/verDoctores.aspx.cs" Inherits="View_Administrador_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
    <div class="table-responsive" style="text-align:center;">
       <asp:GridView ID="GV_Doctor" runat="server" AllowPaging="True" CssClass="table-hover" AllowSorting="True" DataSourceID="OBDS_Doctores" AutoGenerateColumns="False" DataKeyNames="id_usuario" Width="100%"  OnRowDataBound="cargar_Botones_RowDataBound" OnRowCommand="GV_Doctor_RowCommand" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal"  >
            <Columns>
                <asp:TemplateField HeaderText="Id" Visible="False">
                    <EditItemTemplate>
                        <asp:TextBox ID="ed_txt_id" runat="server" Text='<%# Bind("id_usuario") %>' Enabled="False"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="label_id_doc" runat="server" Text='<%# Bind("id_usuario") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Cedula" >
                    <EditItemTemplate>
                        <asp:TextBox ID="ed_txt_ced_doc" runat="server" Text='<%# Bind("cedula") %>' Enabled="False"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lab_ced_doc" runat="server" Text='<%# Bind("cedula") %>'  ></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Nombre" >
                    <EditItemTemplate>
                        <asp:TextBox ID="ed_txt_nom_doc" runat="server" Text='<%# Bind("nombre") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lab_nom_doc" runat="server" Text='<%# Bind("nombre") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Apellido" >
                    <EditItemTemplate>
                        <asp:TextBox ID="ed_txt_ape_doc" runat="server" Text='<%# Bind("apellido") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lab_ape_doc" runat="server" Text='<%# Bind("apellido") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Dirección">
                    <EditItemTemplate>
                        <asp:TextBox ID="ed_txt_dir_doc" runat="server" Text='<%# Bind("direccion") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lab_dir_doc" runat="server" Text='<%# Bind("direccion") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Teléfono">
                    <EditItemTemplate>
                        <asp:TextBox ID="ed_txt_tel_doc" runat="server" Text='<%# Bind("telefono") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lab_tel_doc" runat="server" Text='<%# Bind("telefono") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Correo">
                    <EditItemTemplate>
                        <asp:TextBox ID="ed_txt_cor_doc" runat="server" Text='<%# Bind("correo") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lab_cor_doc" runat="server" Text='<%# Bind("correo") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Contraseña">
                     <EditItemTemplate>
                        <asp:TextBox ID="ed_txt_cla_doc" Visible="false" runat="server" Text='<%# Bind("clave") %>'  ></asp:TextBox>
                        <asp:Label ID="Label1" runat="server" Text="***************"></asp:Label>

                     </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lab_cla_doc" Visible="false" runat="server" Text='<%# Bind("clave") %>'></asp:Label>
                          <asp:Label ID="Label1" runat="server" Text="***************"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Fecha Nacimiento">
                    <EditItemTemplate>
                        <asp:Label ID="label_nacimiento" runat="server" Text='<%# Bind("fecha_nacimieno") %>'></asp:Label>
                        <br />
                        <asp:TextBox ID="ed_txt_nac_doc" runat="server"  TextMode="Date"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lab_nac_doc" runat="server" Text='<%# Bind("fecha_nacimieno") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Sexo">
                    <EditItemTemplate>
                        <asp:Label ID="label_sexo" runat="server" Text='<%# Bind("sexo") %>'></asp:Label>
                        <br />
                        <asp:DropDownList ID="DDL_sexo_doc" runat="server">
                            <asp:ListItem>Seleccione un Sexo</asp:ListItem>
                            <asp:ListItem>Maculino</asp:ListItem>
                            <asp:ListItem>Femenino</asp:ListItem>
                            <asp:ListItem>Otro</asp:ListItem>
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lab_sex_doc" runat="server" Text='<%# Bind("sexo") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Foto">
                    <EditItemTemplate>
                        <asp:Image ID="Image_e_doc" runat="server" ImageUrl='<%# Bind("foto") %>' Width="30%" />
                        <br />
                        <asp:FileUpload ID="FU_e_foto" runat="server" />
                        <br />
                        <asp:Button ID="but_act_doc" runat="server" OnClick="but_act_doc_Click" Text="Actualizar" />

                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Image ID="Ima_foto_doc" runat="server" ImageUrl='<%# Bind("foto") %>' Width="30%" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Sede">
                    <EditItemTemplate>
                         <asp:Label ID="label_sede" runat="server" Text='<%# Bind("sede_id") %>'></asp:Label>
                            <asp:DropDownList ID="DDL_sede_doctor" runat="server" DataSourceID="OBDS_sede" DataTextField="sede_nombre" DataValueField="sede_id">
                            </asp:DropDownList>
                        <asp:ObjectDataSource ID="OBDS_sede" runat="server" SelectMethod="ver_Sede_DDL" TypeName="DAOSede" ></asp:ObjectDataSource>
                   
      
                       
                        </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="label_sede" runat="server" Text='<%# Bind("sede_id") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ShowEditButton="True" UpdateText="" />
                <asp:TemplateField Visible="False">
                    <EditItemTemplate>
                        <asp:Label ID="label_estado" runat="server" Text='<%# Bind("estado") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="label_estado" runat="server" Text='<%# Bind("estado") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                
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
            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#242121" />
        </asp:GridView>
        
        <asp:ObjectDataSource ID="OBDS_Doctores" runat="server" SelectMethod="ver_Doctor" TypeName="DAODoctor" DeleteMethod="bloquear_Doctor" UpdateMethod="modificar_doctor">
            <DeleteParameters>
                <asp:Parameter Name="id_usuario" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="id" Type="Int32" />
                <asp:Parameter Name="cedula" Type="Int32" />
                <asp:Parameter Name="nombre" Type="String" />
                <asp:Parameter Name="apellido" Type="String" />
                <asp:Parameter Name="direccion" Type="String" />
                <asp:Parameter Name="telefono" Type="Int32" />
                <asp:Parameter Name="correo" Type="String" />
                <asp:Parameter Name="clave" Type="String" />
                <asp:Parameter Name="fecha" Type="DateTime" />
                <asp:Parameter Name="foto" Type="String" />
                <asp:Parameter Name="id_usuario" Type="Int32" />
                <asp:Parameter Name="fecha_nacimieno" Type="DateTime" />
                <asp:Parameter Name="sexo" Type="String" />
            </UpdateParameters>
       </asp:ObjectDataSource>
   </div>
      
</asp:Content>

