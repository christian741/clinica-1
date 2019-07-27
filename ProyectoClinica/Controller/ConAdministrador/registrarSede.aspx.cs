using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_Administrador_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void button_sede_Click(object sender, EventArgs e)
    {
        Sede sede = new Sede();
        ClientScriptManager cd = this.ClientScript;
        sede.Nombre = text_sede_nombre_reg.Text;
        sede.Direccion = text_sede_direccion.Text;
        sede.Descripcion = text_sede_descripcion.Text;
        sede.Encargado = text_encargado_sede.Text;
        sede.Ciudad = text_ciudad_sede.Text;
        sede.Session = Session.SessionID;
        String ruta = FU_registro_sede.PostedFile.FileName;

        if (ruta != null && !(System.IO.Path.GetExtension(ruta).Equals(".jpg") || System.IO.Path.GetExtension(ruta).Equals(".png")))
        {
            cd.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Solo imagenes porfavor');</script>");
            return;
        }
        else
        {
           Image_sede.ImageUrl = System.IO.Path.GetFileName(ruta);

            sede.Foto = "~\\Imagenes\\Perfiles\\Sede\\" + System.IO.Path.GetFileName(ruta);

            FU_registro_sede.PostedFile.SaveAs(Server.MapPath(sede.Foto));
        }
        new DAOSede().registrar_sede(sede);
        Response.Redirect("~/View/Administrador/verSedes.aspx");

    }
}