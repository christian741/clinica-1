using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_Laboratorista_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void button_registrar_Medicamento_Click(object sender, EventArgs e)
    {

        Medicamento med = new Medicamento();

        med.Nombre = txt_nom_med.Text;
        med.Descripcion = txt_des_med.Text;
        med.Stock = DDL_stock.SelectedValue;
        med.Session = Session.SessionID;
        med.Sede = Convert.ToInt32(Session["sede"].ToString());
        
        new DAOMedicamento().registrar_Medicamento(med);

        Response.Redirect("~/View/Laboratorista/verMedicamentos.aspx");


    }
}