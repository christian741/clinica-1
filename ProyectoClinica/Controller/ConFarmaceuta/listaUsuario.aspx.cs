using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_Farmaceuta_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["entrega"]==null)
        {
            Response.Redirect("~/View/Farmaceuta/indexFarmaceuta.aspx");

        }
    }



    protected void GV_entregas_citas_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("entregar"))
        {
          
            Session["entregar_id"] = Convert.ToInt32(e.CommandArgument.ToString());
            Response.Redirect("~/View/Farmaceuta/entregaFinal.aspx");

        }

    }

    protected void GV_entregas_citas_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Button btn1 = ((Button)e.Row.FindControl("but_entregar_medicamentos"));

            String label_doctor = ((Label)e.Row.FindControl("label_doctor")).Text;
            DataTable tabla_doctor = new DAODoctor().ver_Doctor();
            for (int i = 0; i < tabla_doctor.Rows.Count; i++)
            {
                if (label_doctor.Equals(tabla_doctor.Rows[i]["id_usuario"].ToString()))
                {
                    Label lbl_doc = ((Label)e.Row.FindControl("label_doctor"));
                    lbl_doc.Text = tabla_doctor.Rows[i]["nombre"].ToString()+" " + tabla_doctor.Rows[i]["apellido"].ToString();
                }
            }
            String label_especializacion = ((Label)e.Row.FindControl("label_especializacion")).Text;

            DataTable tabla_especial = new DAOEspecializacion().ver_Especializacion();
            for (int i = 0; i < tabla_especial.Rows.Count; i++)
            {
                if (label_especializacion.Equals(tabla_especial.Rows[i]["id_especializacion"].ToString()))
                {
                    Label lbl_esp = ((Label)e.Row.FindControl("label_especializacion"));
                    lbl_esp.Text = tabla_especial.Rows[i]["nombre"].ToString();
                }
            }


        }
    }
}