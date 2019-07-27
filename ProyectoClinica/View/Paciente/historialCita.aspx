<%@ Page Title="" Language="C#" MasterPageFile="~/View/Paciente/masterPaciente.master" 
    AutoEventWireup="true" CodeFile="~/Controller/ConPaciente/historialCita.aspx.cs" Inherits="View_Paciente_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  
    <asp:Repeater ID="Repeater1" runat="server" DataSourceID="OBDS_historial_paciente" OnItemDataBound="Repeater1_ItemDataBound" OnItemCommand="Repeater1_ItemCommand">
       
        
        <ItemTemplate>
              <div class="container-fluid" style="background-color:blue;color:white">
                <h1>Cita Medica :</h1>
            </div>
            <div class="table-responsive">
    <table class="table table-sm">
      <thead>
        <tr >
           <asp:Label ID="label_id" runat="server" Visible="false" Text='<%# Bind("id_historial_cita") %>'></asp:Label>

            <caption>Información de la Cita Paciente</caption>
            
            
        </tr>
      </thead>
      <tbody>
        <tr>
          <th scope="row" >            
          </th>
               Fecha: <asp:Label ID="label_fecha" runat="server" Text='<%# Bind("fecha_cita") %>'></asp:Label>
                        <br />
             Sede: <asp:Label ID="label_sede" runat="server" Text='<%# Bind("id_sede") %>'></asp:Label>
                        <br />
          <td>
             <br />
          </td>
        <td>
              Informacion Doctor:
             <br />
            <asp:Label ID="label_doctor" runat="server" Text='<%# Bind("id_doctor") %>'></asp:Label>
          Especailizado en:
            <br />
            <asp:Label ID="label_especializacion" runat="server" Text='<%# Bind("id_especializacion") %>'></asp:Label>
                        <br />
          </td>
           
          
        </tr>
        <tr>
          <th scope="row"></th>
        <td>
              Frecuencia cardiaca: <br />
            <asp:Label ID="label_fre_cardiaca" runat="server" Text='<%# Bind("fre_cardiaca") %>'></asp:Label>
                        <br />
              Frecuencia Respiratoria: <br />
            <asp:Label ID="label_fre_respiratoria" runat="server" Text='<%# Bind("fre_respiratoria") %>'></asp:Label>
                        <br />
           </td>
        <td>
             Peso: <br />
            <asp:Label ID="label_peso" runat="server" Text='<%# Bind("peso") %>'></asp:Label>
              Altura:          <br />

            <asp:Label ID="label_altura" runat="server" Text='<%# Bind("altura") %>'></asp:Label>
           
            <br />
            </td>
        </tr>
      
        <tr>
         <th scope="row"></th>
            Razon de la cita:
         <asp:Label ID="label_razon" runat="server" Text='<%# Bind("razon") %>'></asp:Label>
                        <br />
        </tr>
        <tr>
        <th scope="row"></th>
          Descripcion del Doctor
            <asp:Label ID="label_descricpcion" runat="server" Text='<%# Bind("descripcion") %>'></asp:Label>
                        <br />
        </tr>
         <tr>
         <th scope="row"></th>
          <td>
             
          </td>
          <td>
          <asp:Button ID="button_ver_med"  CssClass="alert alert-primary" runat="server" Text="Ver medicamentos" CommandArgument='<%# Bind("id_historial_cita") %>' CommandName="ver" />

          </td>
        </tr>
         
      </tbody>
    </table>

           </ItemTemplate>
    </asp:Repeater>


     <asp:GridView ID="Gv_medicamentos" runat="server" AllowPaging="True" CellPadding="4"  ForeColor="#333333" GridLines="None" Visible="False">
         <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
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
    <asp:ObjectDataSource ID="OBDS_historial_paciente" runat="server" SelectMethod="ver_historial_Clinico" TypeName="DAOPaciente">
        <SelectParameters>
            <asp:SessionParameter Name="id_paciente" SessionField="usuario" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>

