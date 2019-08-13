using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using Utilitarios;
using Core;
using System.Web.UI.WebControls;

public partial class View_Paciente_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void GD_View_Remisiones_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.ToString().Equals("crear"))
        {
            foreach (GridViewRow gv in GD_View_Remisiones.Rows)
            {
                if (e.CommandArgument.ToString().Equals(((Label)gv.FindControl("label_id")).Text))
                {
                    Session["remision"] = ((Label)gv.FindControl("label_id_especial")).Text;

                }
            }
                Session["remision2"] = Convert.ToInt32(e.CommandArgument.ToString());
            Response.Redirect("~/View/Paciente/citaRemision.aspx");
        }
        if (e.CommandName.ToString().Equals("quitar"))
        {
            new Core_Paciente().quitarRemision(Convert.ToInt32(e.CommandArgument.ToString()));
            Response.Redirect("~/View/Paciente/Remisiones.aspx");
        }
    }

    protected void GD_View_Remisiones_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow) {
            String especializacion = ((Label)e.Row.FindControl("label_especial")).Text;
            DataTable tabla3 = new DAOEspecializacion().ver_Especializacion();
            for (int i = 0; i < tabla3.Rows.Count; i++)
            {
                if (especializacion.Equals(tabla3.Rows[i]["id_especializacion"].ToString()))
                {
                    Label lbl_sede = ((Label)e.Row.FindControl("label_especial"));
                    lbl_sede.Text = tabla3.Rows[i]["nombre"].ToString();
                    break;
                }
            }
            Int32 id_remision= Convert.ToInt32(((Label)e.Row.FindControl("label_id")).Text);

            String fecha = ((Label)e.Row.FindControl("label_fecha")).Text;
            if (DateTime.Now> Convert.ToDateTime(fecha))
            {
                new Core_Paciente().actualizaRemision(id_remision);
            }
            Button btn1 = ((Button)e.Row.FindControl("but_crear_cita"));
            Button btn2 = ((Button)e.Row.FindControl("but_quitar"));
            String est_lab = ((Label)e.Row.FindControl("label_estado")).Text;
            if (est_lab.Equals("1"))
            {
                ((Label)e.Row.FindControl("label_estado")).Text = "Habilitado";
                btn1.Visible = true;
            }
            if (est_lab.Equals("2"))
            {
                ((Label)e.Row.FindControl("label_estado")).Text = "Deshabilitado";
                ((Label)e.Row.FindControl("label_advertencia")).Text = "Se ha excedido el tiempo";
                btn1.Visible = false;
                btn2.Visible = true;
            }

        }
    }
}