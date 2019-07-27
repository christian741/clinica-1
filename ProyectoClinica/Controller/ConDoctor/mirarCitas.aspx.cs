using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_Doctor_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
   
          
    protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
    {
        DataTable fecha2 = new DAODoctor().traer_fecha_limite(Convert.ToInt32(Session["usuario"].ToString()));
        if (fecha2.Rows.Count < 1)
        {
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
    }
       
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        DataTable datos = new DAODoctor().f_ver_Citas(Convert.ToInt32(Session["usuario"].ToString()),Calendar1.SelectedDate);
        GridView1.DataSource = datos;
        GridView1.DataBind();
    }
}