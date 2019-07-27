using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_Farmaceuta_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void but_act_doc_Click(object sender, EventArgs e)
    {
        Medicamento med = new Medicamento();

        if ((DataControlRowState.Edit) > 0)
        {
            med.Codigo = Convert.ToInt32(((Label)GV_medicamentos.Rows[GV_medicamentos.EditIndex].FindControl("label_codigo")).Text);

            med.Nombre = ((TextBox)GV_medicamentos.Rows[GV_medicamentos.EditIndex].FindControl("text_nombre")).Text;
            med.Descripcion = ((TextBox)GV_medicamentos.Rows[GV_medicamentos.EditIndex].FindControl("text_descripcion")).Text;

            string stock = ((DropDownList)GV_medicamentos.Rows[GV_medicamentos.EditIndex].FindControl("DDL_stock")).SelectedValue;
            if (stock.Equals("Seleccione un Stock"))
            {
                med.Stock = ((Label)GV_medicamentos.Rows[GV_medicamentos.EditIndex].FindControl("label_ed_stock")).Text;

            }
            else
            {
                med.Stock = stock;
            }

            med.Session = Session.SessionID;


            new DAOMedicamento().actualizar_Medicamento(med);
            Response.Redirect("~/View/Farmaceuta/verMedicamentos.aspx");
        }
    }

}