using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_Administrador_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void button_laboratorista_Click(object sender, EventArgs e)
    {


        ClientScriptManager cd = this.ClientScript;
        Laboratorista lab = new Laboratorista();

       lab.Cedula_lab = Convert.ToInt32(text_cedula_reg_lab.Text);
        lab.Nombre_lab = text_nombre_reg_lab.Text;
        lab.Apellido_lab = text_apellido_reg_lab.Text;
        lab.Direccion_lab = text_direccion_reg_lab.Text;
        lab.Telefono_lab = Convert.ToInt32(text_telefono_reg_lab.Text);
        lab.Nacmiento_lab = Convert.ToDateTime(text_nacimiento_lab.Text);
        lab.Correo_lab = text_correo_reg_lab.Text;
        lab.Clave_lab = text_clave_reg_lab.Text;
        /*if (DrpD_paciente.SelectedValue.Equals("Seleccionar Sexo"))
        {
            cd.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Registre un Sexo valido');</script>");
            return;
        }
        else
        {
            pac1.Sexo = DrpD_paciente.SelectedValue;
        }*/
        if (DDL_sexo_lab.SelectedValue.Equals("Seleccionar Sexo"))
        {
            cd.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Registre un Sexo valido');</script>");
            return;
        }
        else
        {
            lab.Sexo = DDL_sexo_lab.SelectedValue;
        }
        if (DDL_sede_lab.SelectedValue.Equals("Seleccione una Sede"))
        {
            cd.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Registre una Sede valida');</script>");
            return;
        }
        else
        {
            lab.Sede = Convert.ToInt16(DDL_sede_lab.SelectedIndex);
        }

        String ruta = FU_registro_lab.PostedFile.FileName;

        if (ruta != null && !(System.IO.Path.GetExtension(ruta).Equals(".jpg") || System.IO.Path.GetExtension(ruta).Equals(".png")))
        {
            cd.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Solo imagenes porfavor');</script>");
            return;
        }
        else
        {
            Image_Registro_lab.ImageUrl = System.IO.Path.GetFileName(ruta);


            lab.Foto = "~\\Imagenes\\Perfiles\\Laboratorista\\" + System.IO.Path.GetFileName(ruta);

            FU_registro_lab.PostedFile.SaveAs(Server.MapPath(lab.Foto));
        }
        lab.Session = Session.SessionID;



        if (new DAOLaboratorista().registrar_Laboratorista(lab) == null)
        {
            cd.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('El usuario Registrado ya existe');</script>");
            return;
        }
        else
        {
            cd.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Su  usuario ha sido creado satisfactoriamente');</script>");
            return;
        }
    }
}