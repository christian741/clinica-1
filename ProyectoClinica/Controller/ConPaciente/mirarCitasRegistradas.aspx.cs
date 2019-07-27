using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_Paciente_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        String hoy = DateTime.Now.ToShortDateString();
        fecha_hoy.Text = hoy;
    }

    protected void cargar_Boton_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            Button btn1 = ((Button)e.Row.FindControl("but_cancelar"));
            btn1.Visible = true;

            /*Especializacion*/

            String especial = ((Label)e.Row.FindControl("label_especial")).Text;

            DataTable tabla = new DAOEspecializacion().traer_Especializacion();
            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                if (especial.Equals(tabla.Rows[i]["id_especializacion"].ToString()))
                {
                    Label lab_especial = ((Label)e.Row.FindControl("label_especial"));
                    lab_especial.Text = tabla.Rows[i]["nombre"].ToString();
                }
            }

            /*Sede*/
            String sede = ((Label)e.Row.FindControl("label_sede")).Text;

            DataTable tabla1 = new DAOSede().ver_Sede();
            for (int i = 0; i < tabla1.Rows.Count; i++)
            {
                if (sede.Equals(tabla1.Rows[i]["id_sede"].ToString()))
                {
                    Label lbl_sede = ((Label)e.Row.FindControl("label_sede"));
                    lbl_sede.Text = tabla1.Rows[i]["nombre"].ToString();
                }
            }
            /*Doctor*/
            String doctor= ((Label)e.Row.FindControl("label_doctor")).Text;

            DataTable tabla2 = new DAODoctor().ver_Doctor();
            for (int i = 0; i < tabla2.Rows.Count; i++)
            {
                if (doctor.Equals(tabla2.Rows[i]["id_usuario"].ToString()))
                {
                    Label alb_doc = ((Label)e.Row.FindControl("label_doctor"));
                    alb_doc.Text = tabla2.Rows[i]["nombre"].ToString()+" "+tabla2.Rows[i]["apellido"].ToString();
                }
            }

        }
    }



    protected void GV_citas_paciente_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("cancelar")) { 
           
            new DAOCita().cancelarCita(Convert.ToInt32(e.CommandArgument.ToString()));
            Response.Redirect("~/View/Paciente/mirarCitasRegistradas.aspx");

        }
    }
}