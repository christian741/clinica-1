using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_Paciente_masterPaciente : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usuario"] == null || !Session["rol"].ToString().Equals("1"))
        {
            Response.Redirect("../Principal/index.aspx");
        }
        DataTable foto = new DAOUsuario().buscar_Usuario(Convert.ToInt16(Session["usuario"].ToString()));
        for(int i = 0; i < foto.Rows.Count; i++)
        {
            Image1.ImageUrl = foto.Rows[i]["foto"].ToString();
        }
    }
    protected void but_cerrar_Click(object sender, EventArgs e)
    {
        Usuario usu = new Usuario();
        usu.Session = Session.SessionID;
        new DAOUsuario().cerrarSession(usu);
        Session["usuario"] = null;
        Response.Redirect("../Principal/index.aspx");
    }
}
