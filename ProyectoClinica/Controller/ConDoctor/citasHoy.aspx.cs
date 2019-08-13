using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using Core;
using Utilitarios;
using System.Web.UI.WebControls;

public partial class View_Doctor_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        String hoy = DateTime.Now.ToShortDateString();
        //fecha_hoy.Text = hoy;
    }
    protected void cargar_Boton_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

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
            String paciente = ((Label)e.Row.FindControl("label_paciente")).Text;

            DataTable tabla2 = new Core_Paciente().verPacientes();
            for (int i = 0; i < tabla2.Rows.Count; i++)
            {
                if (paciente.Equals(tabla2.Rows[i]["id_usuario"].ToString()))
                {
                    Label alb_doc = ((Label)e.Row.FindControl("label_paciente"));
                    alb_doc.Text = tabla2.Rows[i]["nombre"].ToString() + " " + tabla2.Rows[i]["apellido"].ToString();
                }
            }

        }
    }

   

    protected void GV_citas_paciente_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("noVino"))
        {
            int id = 0;
            DataTable datos = new DAOCita().validarAtencion_fecha(Convert.ToInt32(e.CommandArgument.ToString()));
            DateTime _fecha_normal = Convert.ToDateTime(datos.Rows[0]["fecha_cita"].ToString());
            DateTime _hora = Convert.ToDateTime(datos.Rows[0]["fecha_cita"].ToString());
            DataTable datos2 = new DAOCita().validarAtencion_horas(Convert.ToInt32(Session["usuario"].ToString()), _hora.ToString("hh:mm:ss"));
            string sesion = Session.SessionID;

            if (DateTime.Now < Convert.ToDateTime(datos.Rows[0]["fecha_cita"].ToString()) )
            {
                // label_error.Text = "Lo siento no puede atender a alguien aun";
                // label_error.CssClass = "alert alert-danger"; DateTime.Now > Convert.ToDateTime(_fecha_normal.ToString("dd/mm/yyyy") + " " + datos2.Rows[0]["hora_fin"].ToString())
                return;
            }


            // label_error.Text = "";
            //  label_error.CssClass =null;
            new DAOCita().noVino(Convert.ToInt32(e.CommandArgument.ToString()), sesion);

            Response.Redirect("~/View/Doctor/citasHoy.aspx.cs");
        }
        else
        {
            if (e.CommandName.Equals("atender"))
            {
                int id = 0;
                DataTable datos = new DAOCita().validarAtencion_fecha(Convert.ToInt32(e.CommandArgument.ToString()));
                DateTime _fecha_normal = Convert.ToDateTime(datos.Rows[0]["fecha_cita"].ToString());
                DateTime _hora = Convert.ToDateTime(datos.Rows[0]["fecha_cita"].ToString()); 
                DataTable datos2 = new DAOCita().validarAtencion_horas(Convert.ToInt32(Session["usuario"].ToString()), _hora.ToString("hh:mm:ss"));
                string sesion = Session.SessionID;

                if (DateTime.Now < Convert.ToDateTime(datos.Rows[0]["fecha_cita"].ToString()) )
                {
                    // label_error.Text = "Lo siento no puede atender a alguien aun";
                    // label_error.CssClass = "alert alert-danger";
                    return;
                }
                foreach (GridViewRow gv in GV_citas_paciente.Rows)
                {
                    if (e.CommandArgument.ToString().Equals(((Label)gv.FindControl("label_cita")).Text))
                    {
                         id = Convert.ToInt32(((Label)gv.FindControl("label_id_paciente")).Text);
                    }
                }
                Session["paciente"] = id;
                Session["atencion"] = Convert.ToInt32(e.CommandArgument.ToString());
               // Thread.CurrentThread.CurrentCulture = currentCulture;
            
                    new DAOCita().atenderCita(id, sesion);
                Response.Redirect("~/View/Doctor/atenderPaciente.aspx");
            }
            else
            {
                Session["atencion"] = null;
                Session["paciente"] = null;
            }
        }
    }
}