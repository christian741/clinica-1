<%@ Page Language="C#" AutoEventWireup="true" CodeFile="~/Controller/ConDoctor/diasHorario.aspx.cs"
    Inherits="View_Doctor_diasHorarioaspx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
           SELECCIONE UN DIA DE DESCANZO POR SEMANA<br />

            

            <asp:CheckBox ID="CB_Lunes" runat="server" Text="Lunes" />
            <br />
            <asp:CheckBox ID="CB_Martes" runat="server" Text="Martes" />
                        <br />

            <asp:CheckBox ID="CB_Miercoles" runat="server" Text="Miercoles" />
                        <br />

            <asp:CheckBox ID="CB_Jueves" runat="server" Text="Jueves"/>
                        <br />


            <asp:CheckBox ID="CB_Viernes" runat="server" Text="Viernes" />
                        <br />


            <asp:CheckBox ID="CB_Sabado" runat="server" Text="Sabado" />
                        <br />


            <asp:CheckBox ID="CB_Domingo" runat="server" Text="Domingo" />
                        <br />

            <asp:Button ID="but_seleccionar" runat="server" Text="Seleccionar" OnClick="but_seleccionar_Click" />
        </div>
    </form>
</body>
</html>
