using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_Doctor_diasHorarioaspx : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void but_seleccionar_Click(object sender, EventArgs e)
    {
       
        if (CB_Lunes.Checked == true)
        {
            string session = Session.SessionID;
            new DAODoctor().registrar_descanzo(Convert.ToInt32(Session["usuario"].ToString()), session, "Monday");
        }
        if (CB_Martes.Checked == true)
        {
            string session = Session.SessionID;
            new DAODoctor().registrar_descanzo(Convert.ToInt32(Session["usuario"].ToString()), session, "Tuesday");

        }
        if (CB_Miercoles.Checked == true)
        {
            string session = Session.SessionID;
            new DAODoctor().registrar_descanzo(Convert.ToInt32(Session["usuario"].ToString()), session, "Wednesday");

        }
        if (CB_Jueves.Checked == true)
        {
            string session = Session.SessionID;
            new DAODoctor().registrar_descanzo(Convert.ToInt32(Session["usuario"].ToString()), session, "Thursday");

        }
        if (CB_Viernes.Checked == true)
        {
            string session = Session.SessionID;
            new DAODoctor().registrar_descanzo(Convert.ToInt32(Session["usuario"].ToString()), session, "Friday");

        }
        if (CB_Sabado.Checked == true)
        {
            string session = Session.SessionID;
            new DAODoctor().registrar_descanzo(Convert.ToInt32(Session["usuario"].ToString()), session, "Saturday");

        }
        if (CB_Domingo.Checked == true)
        {
            string session = Session.SessionID;
            new DAODoctor().registrar_descanzo(Convert.ToInt32(Session["usuario"].ToString()), session, "Sunday");

        }
      
        Response.Redirect("indexDoctor.aspx");


    }
    
}