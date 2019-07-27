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
        
    }


    protected void button_editar_Click1(object sender, EventArgs e)
    {
        ClientScriptManager cd = this.ClientScript;
        String password = ((TextBox)FV_usuario.FindControl("text_validar_pass")).Text;

        DataTable validar = new DAOAdministrador().buscar_Usuario2(Convert.ToInt32(Session["usuario"].ToString()), password);
        if (validar.Rows.Count < 1)
        {
            cd.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Su contraseña es Invalida');</script>");
            return;
        }
        else
        {
            Session["editar"] = 1;
            Response.Redirect("~/View/Paciente/editarUsuario.aspx");

        }

    }
}