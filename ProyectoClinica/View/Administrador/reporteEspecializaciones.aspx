<%@ Page Title="" Language="C#" MasterPageFile="~/View/Administrador/masterAdministrador.master" 
    AutoEventWireup="true" CodeFile="~/Controller/ConAdministrador/reporteEspecializaciones.aspx.cs" Inherits="View_Administrador_Default" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <CR:CrystalReportViewer ID="CRV_Especial" runat="server" AutoDataBind="True" GroupTreeImagesFolderUrl="" Height="50px" ReportSourceID="CRS_Especial" ToolbarImagesFolderUrl="" ToolPanelWidth="200px" Width="350px" />
    <CR:CrystalReportSource ID="CRS_Especial" runat="server">
        <report filename="~\Reportes\Administrador\reportEspecializacion.rpt">
        </report>
    </CR:CrystalReportSource>
</asp:Content>

