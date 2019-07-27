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
        Button_buscar.Visible = false;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        label_error_busqueda.Visible = false ;
        label_error_busqueda.Text = "";
        if (Text_cedula.Text.Equals(""))
        {
            label_error_busqueda.Text = "LLene este Campo";
            label_error_busqueda.CssClass = "alert alert-danger";
            Text_cedula.Text = "";
            label_error_busqueda.Visible = true;

            return;
        }
        Int32 cedula = Convert.ToInt32(Text_cedula.Text);
       
        DataTable datos_usu = new DAOUsuario().buscar_Usuario2(cedula);

        if (datos_usu.Rows.Count<1)
        {
            label_error_busqueda.Text = "Lo siento no se encontro el usuario";
            label_error_busqueda.CssClass = "alert alert-warning";
            Text_cedula.Text = "";
            label_error_busqueda.Visible = true;

            return;
        }
        else
        {
            if (!datos_usu.Rows[0]["rol_id"].ToString().Equals("1"))
            {
                label_error_busqueda.Text = "Lo siento no se encontro el usuario";
                label_error_busqueda.CssClass = "alert alert-warning";
                Text_cedula.Text = "";
                label_error_busqueda.Visible = true;

                return;
            }
            Session["busqueda"] = cedula;
            FV_usuario.Visible = true;
            Button_buscar.Visible = true;
            
         }
    }

    protected void Button_buscar_Click(object sender, EventArgs e)
    {
        FV_usuario.Visible = false;

        Session["busqueda"] = null;
        Session["entrega"] = Convert.ToInt32(((Label)FV_usuario.FindControl("label_id")).Text);

        Response.Redirect("~/View/Farmaceuta/listaUsuario.aspx");

    }
}