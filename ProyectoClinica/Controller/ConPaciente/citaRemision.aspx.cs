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
        if (Session["remision"] == null || Session["remision2"] ==null  )
        {
            Response.Redirect("~/View/Paciente/Remisiones.aspx");

        }
        label_hora.Visible = false;
        DDL_fecha.Visible = false;
        button_cita.Visible = false;


        /* Label_errorSede.Visible = true;
         Label_errorSede.CssClass = "alert alert-warning";
         Label_errorSede.Text = "No ha Seleccionado ninguna Sede";
         FV_Sede.Visible = false;


         label_error_doctor.Visible = true;
         label_error_doctor.CssClass = "alert alert-warning";
         label_error_doctor.Text = "No ha Seleccionado ningun Doctor";
         FV_Doctor.Visible = false;

         Label_error_especial.Visible = true;
         Label_error_especial.CssClass = "alert alert-warning";
         Label_error_especial.Text = "No ha Seleccionado ninguna Especializacion";
         FV_Doctor.Visible = false;*/




    }

    protected void buscarSede_SelectedIndexChanged(object sender, EventArgs e)
    {

        int dato = Convert.ToInt16(DDL_especial.SelectedValue);
        if (DDL_especial.SelectedValue.Equals("0"))
        {
            Label_error_especial.Visible = true;
            Label_error_especial.CssClass = "alert alert-warning";
            Label_error_especial.Text = "No ha Seleccionado ninguna Especializacion";
            FV_especial.Visible = false;
            return;

        }
        else
        {
            Label_error_especial.Visible = false;

            FV_especial.Visible = true;
        }

        DataTable especial = new DAOEspecializacion().traer_Sede(dato);

    }
    protected void buscarDoctor_SelectedIndexChanged(object sender, EventArgs e)
    {

        int dato = Convert.ToInt16(DDL_sede_cita.SelectedValue);
        int dato2 = Convert.ToInt16(DDL_especial.SelectedValue);
        if (DDL_sede_cita.SelectedValue.Equals("0"))
        {
            Label_errorSede.Visible = true;
            Label_errorSede.CssClass = "alert alert-warning";
            Label_errorSede.Text = "No ha Seleccionado ninguna Sede";
            FV_Sede.Visible = false;
            return;

        }
        else
        {
            Label_errorSede.Visible = false;
            FV_Sede.Visible = true;
        }

        DataTable sede = new DAOSede().traer_doctor(dato, dato2);

    }


    protected void button_cita_Click(object sender, EventArgs e)
    {

        Cita cita = new Cita();
        cita.Especializacion = Convert.ToInt16(DDL_especial.SelectedValue);
        cita.Doctor = Convert.ToInt16(DDL_doctor_cita.SelectedValue);
        cita.Paciente = Convert.ToInt16(Session["usuario"].ToString());
        cita.Sede = Convert.ToInt16(DDL_sede_cita.SelectedValue);
        cita.Fecha_cita = DDL_fecha.SelectedValue;
        cita.Razon = text_razon.Text;
        cita.Session = Session.SessionID;
        new DAOCita().insertar_Cita(cita);
        new Core_Paciente().remision_cita_realizada(Convert.ToInt32(Session["remision2"].ToString()));
        Session["remision"] = null;
        Session["remision2"] = null;

        Response.Redirect("~/View/Paciente/mirarCitasRegistradas.aspx");
    }



    protected void DDL_doctor_cita_SelectedIndexChanged(object sender, EventArgs e)
    {

        int dato = Convert.ToInt16(DDL_doctor_cita.SelectedValue);
        String fecha = Calendar_cita.SelectedDate.ToShortDateString();
        if (DDL_doctor_cita.SelectedValue.Equals("0"))
        {
            label_error_doctor.Visible = true;
            label_error_doctor.CssClass = "alert alert-warning";
            label_error_doctor.Text = "No ha Seleccionado ningun Doctor";
            FV_Doctor.Visible = false;
            return;

        }
        else
        {
            label_error_doctor.Visible = false;
            FV_Doctor.Visible = true;
            label_calendario.Visible = true;
            label_calendario.Text = "Seleccione un dia del calendario";
            Calendar_cita.Visible = true;
        }
        DataTable datos = new DAOCita().insertar_fecha(dato, fecha);
        DDL_fecha.Visible = false;

        Calendar_cita.SelectedDate = DateTime.Now;



    }

    protected void Calendar_cita_DayRender(object sender, DayRenderEventArgs e)
    {
        DataTable fecha2 = new DAODoctor().traer_fecha_limite(Convert.ToInt32(DDL_doctor_cita.SelectedValue));
        if (fecha2.Rows.Count < 1)
        {
            return;
        }
        if (e.Day.Date <= DateTime.Now || e.Day.Date > Convert.ToDateTime(fecha2.Rows[0]["fecha_fin"].ToString()))
        {

            e.Day.IsSelectable = false;
            e.Cell.CssClass = "alert alert-danger";


        }
        else
        {
            e.Cell.CssClass = "alert alert-success";
        }
        if (e.Day.IsSelected == true)
        {
            label_fecha.Text = Calendar_cita.SelectedDate.ToShortDateString();
            int dato = Convert.ToInt32(DDL_doctor_cita.SelectedValue);
            String fecha = Calendar_cita.SelectedDate.ToShortDateString();
            DataTable descanzo = new DAODoctor().traer_descanzo(dato);
            if (descanzo.Rows.Count < 1)
            {
                DDL_fecha.Visible = false;
                button_cita.Visible = false;
                label_hora.Visible = false;
                return;
            }
            Calendar_cita.SelectedDate.DayOfWeek.ToString();
            if (Calendar_cita.SelectedDate.DayOfWeek.ToString().Equals(descanzo.Rows[0]["dias_descanzo"].ToString()))
            {
                DDL_fecha.Visible = false;
                button_cita.Visible = false;
                label_hora.Visible = false;
                return;
            }
            DataTable datos = new DAOCita().insertar_fecha(dato, fecha);
            if (datos.Rows.Count > 0 && Calendar_cita.SelectedDate >= DateTime.Now)
            {
                DDL_fecha.Visible = false;
                button_cita.Visible = false;
                label_hora.Visible = false;
            }
            DDL_fecha.Visible = true;
            button_cita.Visible = true;
            label_hora.Visible = true;

        }
        if (e.Day.IsSelectable == true)
        {
            label_fecha.Text = Calendar_cita.SelectedDate.ToShortDateString();
            int dato = Convert.ToInt32(DDL_doctor_cita.SelectedValue);
            String fecha = Calendar_cita.SelectedDate.ToShortDateString();
            DataTable descanzo = new DAODoctor().traer_descanzo(dato);
            if (descanzo.Rows.Count < 1)
            {
                return;
            }
            Calendar_cita.SelectedDate.DayOfWeek.ToString();
            if (Calendar_cita.SelectedDate.DayOfWeek.ToString().Equals(descanzo.Rows[0]["dias_descanzo"].ToString()))
            {
                //error
                return;
            }
            DataTable datos = new DAOCita().insertar_fecha(dato, fecha);
            if (datos.Rows.Count > 0 && Calendar_cita.SelectedDate >= DateTime.Now)
            {

            }

        }

    }



    protected void Calendar_cita_SelectionChanged(object sender, EventArgs e)
    {
        label_fecha.Text = Calendar_cita.SelectedDate.ToShortDateString();
        int dato = Convert.ToInt32(DDL_doctor_cita.SelectedValue);
        DataTable descanzo = new DAODoctor().traer_descanzo(dato);
       
        Calendar_cita.SelectedDate.DayOfWeek.ToString();
        if (Calendar_cita.SelectedDate.DayOfWeek.ToString().Equals(descanzo.Rows[0]["dias_descanzo"].ToString()))
        {
            //error
            return;
        }
        String fecha = Calendar_cita.SelectedDate.ToShortDateString();
        DataTable datos = new DAOCita().insertar_fecha(dato, fecha);
        if (datos.Rows.Count > 0 && Calendar_cita.SelectedDate > DateTime.Now)
        {


        }
        DDL_fecha.Visible = true;
        button_cita.Visible = true;
        label_hora.Visible = true;

    }

}