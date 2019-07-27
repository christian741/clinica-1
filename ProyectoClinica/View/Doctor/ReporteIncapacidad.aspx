<%@ Page Language="C#" AutoEventWireup="true" 
    CodeFile="~/Controller/ConDoctor/ReporteIncapacidad.aspx.cs" Inherits="View_Doctor_ReporteIncapacidad" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <CR:CrystalReportViewer ID="crv_incapacidad" runat="server" AutoDataBind="True" GroupTreeImagesFolderUrl="" Height="50px" ReportSourceID="CRS_Incapacidad" ToolbarImagesFolderUrl="" ToolPanelWidth="200px" Width="350px" />
        <CR:CrystalReportSource ID="CRS_Incapacidad" runat="server">
            <Report FileName="~\Reportes\Administrador\Incapacidad.rpt">
            </Report>
        </CR:CrystalReportSource>
    </form>
</body>
</html>
