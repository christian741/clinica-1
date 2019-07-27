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

        label_error_ced.Visible = false;
        label_error_correo.Visible = false;
        label_error_direccion.Visible = false;
        label_error_nombre.Visible = false;
        label_erro_imagen.Visible = false;
        label_error_apellido.Visible = false;
        label_error_nacimiento.Visible = false;
        label_error_pass.Visible = false;
        label_error_sexo.Visible = false;
        label_error_telefono.Visible = false;
        label_error_sede.Visible = false;
        label_error_especial.Visible = false;
        label_error_horas.Visible = false;
        label_error_horario.Visible = false;




    }

    protected void button_doctor_Click(object sender, EventArgs e)
    {
        Boolean validacion = true;
        ClientScriptManager cd = this.ClientScript;
        Doctor doc = new Doctor();
         
      
        if (text_cedula_reg_doc.Text.Equals(""))
        {
            validacion = false;
            label_error_ced.Text = "Rellene este campo";
            label_error_ced.CssClass = "aler alert-danger";
            label_error_ced.Visible = true;
        }
        else
        {
            if (text_cedula_reg_doc.Text.Length<9 || text_cedula_reg_doc.Text.Length >10)
            {
                validacion = false;
                label_error_ced.Text = "Rellene debe contener minimo 9 a 10 digitos";
                label_error_ced.CssClass = "aler alert-danger";
                label_error_ced.Visible = true;
            }
            doc.Cedula_doctor = Convert.ToInt32(text_cedula_reg_doc.Text);

        }
        if (text_cedula_reg_doc.Text.Equals(""))
        {
            validacion = false;
            label_error_nombre.Text = "Rellene este campo";
            label_error_nombre.CssClass = "aler alert-danger";
            label_error_nombre.Visible = true;
        }
        else
        {
            if (text_nombre_reg_doc.Text.Length < 2 || text_nombre_reg_doc.Text.Length > 20)
            {
                validacion = false;
                label_error_nombre.Text = "Rellene debe contener minimo 2 a 20 caracteres";
                label_error_nombre.CssClass = "aler alert-danger";
                label_error_nombre.Visible = true;
            }
            doc.Nombre_doctor = text_nombre_reg_doc.Text;

        }
        if (text_apellido_reg_doc.Text.Equals(""))
        {
            validacion = false;
            label_error_apellido.Text = "Rellene este campo";
            label_error_apellido.CssClass = "aler alert-danger";
            label_error_apellido.Visible = true;
        }
        else
        {
            if (text_apellido_reg_doc.Text.Length < 2 || text_apellido_reg_doc.Text.Length > 20)
            {
                validacion = false;
                label_error_apellido.Text = "Rellene debe contener minimo 2 a 20 caracteres";
                label_error_apellido.CssClass = "aler alert-danger";
                label_error_apellido.Visible = true;
            }
            doc.Apellido_doctor = text_apellido_reg_doc.Text;

        }
        if (text_direccion_reg_doc.Text.Equals(""))
        {
            validacion = false;
            label_error_direccion.Text = "Rellene este campo";
            label_error_direccion.CssClass = "aler alert-danger";
            label_error_direccion.Visible = true;
        }
        else
        {
            if (text_direccion_reg_doc.Text.Length < 4|| text_direccion_reg_doc.Text.Length > 50)
            {
                validacion = false;
                label_error_direccion.Text = "Rellene debe contener minimo 4 a 50 caracteres";
                label_error_direccion.CssClass = "aler alert-danger";
                label_error_direccion.Visible = true;
            }
            doc.Direccion_doctor = text_direccion_reg_doc.Text;

        }
        if (text_telefono_reg_doc.Text.Equals(""))
        {
            validacion = false;
            label_error_nombre.Text = "Rellene este campo";
            label_error_nombre.CssClass = "aler alert-danger";
            label_error_nombre.Visible = true;
        }
        else
        {
            if (text_telefono_reg_doc.Text.Length !=10)
            {
                validacion = false;
                label_error_nombre.Text = "Rellene debe contener 10 digitos";
                label_error_nombre.CssClass = "aler alert-danger";
                label_error_nombre.Visible = true;
            }
            doc.Telefono_doctor = Convert.ToInt32(text_telefono_reg_doc.Text);

        }
        try
        {
            if (DateTime.Today.AddYears(-18).CompareTo(Convert.ToDateTime(text_nacimiento_doc.Text)) >= 0)
            {
                doc.Nacmiento_doctor = Convert.ToDateTime(text_nacimiento_doc.Text);

            }
            else
            {
                validacion = false;
                label_error_nacimiento.Visible = true;
                label_error_nacimiento.Text = "Debe ser Mayor de Edad";
                label_error_nacimiento.CssClass = "alert alert-danger";

            }

        }
        catch (Exception ex)
        {
            if (ex.ToString().Equals(ex.ToString()))
            {
                validacion = false;
                label_error_nacimiento.Visible = true;
                label_error_nacimiento.Text = "Rellene este Campo porfavor";
                label_error_nacimiento.CssClass = "alert alert-danger";

            }

        }
        if (text_correo_reg_doc.Text.Equals(""))
        {
            validacion = false;
            label_error_correo.Visible = true;
            label_error_correo.Text = "Rellene este Campo porfavor";
            label_error_correo.CssClass = "alert alert-danger";

        }
        else
        {
            if (text_correo_reg_doc.Text.Length < 4)
            {
                validacion = false;
                label_error_correo.Visible = true;
                label_error_correo.Text = "Debe Contener minimo 4 caracteres";
                label_error_correo.CssClass = "alert alert-danger";

            }
            else
            {
                doc.Correo_doctor = text_correo_reg_doc.Text;

            }
        }

        if (text_clave_reg_doc.Text.Equals(""))
        {
            validacion = false;
            label_error_pass.Visible = true;
            label_error_pass.Text = "Rellene este Campo porfavor";
            label_error_pass.CssClass = "alert alert-danger";

        }
        else
        {
            if (text_clave_reg_doc.Text.Length < 4 || text_clave_reg_doc.Text.Length > 16)
            {
                validacion = false;
                label_error_pass.Visible = true;
                label_error_pass.Text = "Debe Contener minimo 4 caracteres y maximo 16";
                label_error_pass.CssClass = "alert alert-danger";

            }
            else
            {
                doc.Clave_doctor = text_clave_reg_doc.Text;

            }
        }
       
        if (DDL_sexo_doctor.SelectedValue.Equals("Seleccionar Sexo"))
        {
            validacion = false;
            label_error_sexo.Visible = true;
            label_error_sexo.Text = "Debe Seleccionar un Sexo";
            label_error_sexo.CssClass = "alert alert-danger";

        }
        else
        {
            doc.Sexo = DDL_sexo_doctor.SelectedValue;
            
        }
        if(DDL_sede_doctor.SelectedValue.Equals("Seleccione una Sede"))
        {
            validacion = false;
            label_error_sede.Visible = true;
            label_error_sede.Text = "Debe Seleccionar una Sede";
            label_error_sede.CssClass = "alert alert-danger";

        }
        else
        {
            doc.Sede =Convert.ToInt16(DDL_sede_doctor.SelectedValue.ToString());
        }
        if (DDL_doctor_especializacion.SelectedValue.Equals("0"))
        {
            validacion = false;
            label_error_especial.Visible = true;
            label_error_especial.Text = "Debe Seleccionar un Sexo";
            label_error_especial.CssClass = "alert alert-danger";

        }
        else
        {
            doc.Especializacion = Convert.ToInt16(DDL_doctor_especializacion.SelectedValue.ToString());
        }
         String ruta = FU_registro_doc.PostedFile.FileName;

         if (ruta != null && !(System.IO.Path.GetExtension(ruta).Equals(".jpg") || System.IO.Path.GetExtension(ruta).Equals(".png")))
         {
            validacion = false;
            label_erro_imagen.Visible = true;
            label_erro_imagen.Text = "Debe Seleccionar un Archivo";
            label_erro_imagen.CssClass = "alert alert-danger";
        }
        else
         {
             Image_Registro_doc.ImageUrl = System.IO.Path.GetFileName(ruta);


             doc.Foto = "~\\Imagenes\\Perfiles\\Doctor\\" + System.IO.Path.GetFileName(ruta);

             FU_registro_doc.PostedFile.SaveAs(Server.MapPath(doc.Foto));
         }
         doc.Session = Session.SessionID;
        if (DDL_horario.SelectedValue.Equals("Seleccione un horario"))
        {
            validacion = false;
            label_error_horario.Visible = true;
            label_error_horario.Text = "Debe Seleccionar un Archivo";
            label_error_horario.CssClass = "alert alert-danger";
        }
        if (DDL_horario.SelectedValue.Equals("Diurno"))
        {
            doc.Horario = 1;
        }
        else
        {
            if (DDL_horario.SelectedValue.Equals("Tarde"))
            {
                doc.Horario = 2;
            }
            else
            {
                if (DDL_horario.SelectedValue.Equals("Nocturno"))
                {
                    doc.Horario = 3;
                }
               
            }
        }

        doc.Tiempo_laborado = txt_horas.Text;
        if (txt_horas.Text.Equals(""))
        {
            validacion = false;
            label_error_horas.Visible = true;
            label_error_horas.Text = "Rellene este campo";
            label_error_horas.CssClass = "alert alert-danger";
        }
        else
        {
            string horainicia = "00:10:00";
            string horafinal = "02:00:00";
            if ( Convert.ToDateTime(Convert.ToDateTime(txt_horas.Text).ToShortTimeString()) < Convert.ToDateTime(Convert.ToDateTime(horainicia).ToShortTimeString()))
            {
                validacion = false;
                label_error_horas.Visible = true;
                label_error_horas.Text = "Debe almenos durar 10 minutos";
                label_error_horas.CssClass = "alert alert-danger";

            }
            if (Convert.ToDateTime(Convert.ToDateTime(txt_horas.Text).ToShortTimeString()) > Convert.ToDateTime(Convert.ToDateTime(horafinal).ToShortTimeString()))
            {
                validacion = false;
                label_error_horas.Visible = true;
                label_error_horas.Text = "Debe almenos durar 2 horas";
                label_error_horas.CssClass = "alert alert-danger";

            }
        }
        if (validacion == false)
        {
            return;
        }

        if (new DAODoctor().registrar_doctor(doc) == null)
        {
            cd.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('El usuario Registrado ya existe');</script>");
            return;
        }
        else
        {
            cd.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Su  usuario ha sido creado satisfactoriamente');</script>");
            
           
        }
    }
}