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

    protected void button_farmaceuta_Click(object sender, EventArgs e)
    {

        ClientScriptManager cd = this.ClientScript;
        Farmaceuta far = new Farmaceuta();

        far.Cedula_farmaceuta = Convert.ToInt32(text_cedula_reg_far.Text);
        far.Nombre_farmaceuta = text_nombre_reg_far.Text;
        far.Apellido_farmaceuta = text_apellido_reg_far.Text;
        far.Direccion_farmaceuta = text_direccion_reg_far.Text;
        far.Telefono_farmaceuta = Convert.ToInt32(text_telefono_reg_far.Text);
        far.Nacmiento_farmaceuta = Convert.ToDateTime(text_nacimiento_far.Text);
        far.Correo_farmaceuta = text_correo_reg_far.Text;
        far.Clave_farmaceuta = text_clave_reg_far.Text;
        /*if (DrpD_paciente.SelectedValue.Equals("Seleccionar Sexo"))
        {
            cd.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Registre un Sexo valido');</script>");
            return;
        }
        else
        {
            pac1.Sexo = DrpD_paciente.SelectedValue;
        }*/
        if (DDL_sexo_far.SelectedValue.Equals("Seleccionar Sexo"))
        {
            cd.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Registre un Sexo valido');</script>");
           
            return;
        }
        else
        {
            far.Sexo = DDL_sexo_far.SelectedValue;
        }
        if (DDL_sede_far.SelectedValue.Equals("Seleccione una Sede"))
        {
            cd.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Registre una Sede valida');</script>");
           
            return;
        }
        else
        {
            far.Sede = Convert.ToInt16(DDL_sede_far.SelectedValue);
        }
       
        String ruta = FU_registro_far.PostedFile.FileName;

        if (ruta != null && !(System.IO.Path.GetExtension(ruta).Equals(".jpg") || System.IO.Path.GetExtension(ruta).Equals(".png")))
        {
            cd.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Solo imagenes porfavor');</script>");
           
            return;
        }
        else
        {
            Image_Registro_far.ImageUrl = System.IO.Path.GetFileName(ruta);


            far.Foto = "~\\Imagenes\\Perfiles\\Farmaceuta\\" + System.IO.Path.GetFileName(ruta);

            FU_registro_far.PostedFile.SaveAs(Server.MapPath(far.Foto));
        }
        far.Session = Session.SessionID;



        if (new DAOFarmaceuta().registrar_farmaceuta(far) == null)
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