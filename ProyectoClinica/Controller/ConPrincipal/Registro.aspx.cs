using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_Principal_Default : System.Web.UI.Page
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
        
    }

    protected void button_paciente_Click(object sender, EventArgs e)
    {
            Boolean validacion = true;
            Paciente pac1 = new Paciente();
            ClientScriptManager cd = this.ClientScript;
            if (text_cedula_reg.Text.Equals(""))
            {
                validacion = false;
                label_error_ced.Visible = true;
                label_error_ced.Text = "Rellene este Campo porfavor";
                label_error_ced.CssClass = "alert alert-danger";

                
            }
            else
            {
                if (text_cedula_reg.Text.Length<9 || text_cedula_reg.Text.Length> 10)
                {
                    validacion = false;
                    label_error_ced.Visible = true;
                    label_error_ced.Text = "Debe Contener almenos 9 o 10 digitos";
                    label_error_ced.CssClass = "alert alert-danger";

                   

                }
                else
                {
                    pac1.Cedula_paciente = Convert.ToInt32(text_cedula_reg.Text);

                }
            }
            if (text_nombre_reg.Text.Equals(""))
            {
                validacion = false;
                label_error_nombre.Visible = true;
                label_error_nombre.Text = "Rellene este Campo porfavor";
                label_error_nombre.CssClass = "alert alert-danger";

            }
            else
            {
                if (text_nombre_reg.Text.Length < 2 || text_nombre_reg.Text.Length >20)
                {
                    validacion = false;
                    label_error_nombre.Visible = true;
                    label_error_nombre.Text = "Debe Contener minimo 2 a 20 caracteres";
                    label_error_nombre.CssClass = "alert alert-danger";

                   

                }
                else
                {
                    pac1.Nombre_paciente = text_nombre_reg.Text;

                }
        }
            if (text_apellido_reg.Text.Equals(""))
            {
                validacion = false;
                label_error_apellido.Visible = true;
                label_error_apellido.Text = "Rellene este Campo porfavor";
                label_error_apellido.CssClass = "alert alert-danger";

            }
            else
            {
                if (text_apellido_reg.Text.Length < 4 || text_apellido_reg.Text.Length > 20)
                {
                    validacion = false;
                    label_error_apellido.Visible = true;
                    label_error_apellido.Text = "Debe Contener minimo 2 a 20 caracteres";
                    label_error_apellido.CssClass = "alert alert-danger";

                }
                else
                {
                     pac1.Apellido_paciente = text_apellido_reg.Text;

                }
            }
            if (text_direccion_reg.Text.Equals(""))
            {
                validacion = false;
                label_error_direccion.Visible = true;
                label_error_direccion.Text = "Rellene este Campo porfavor";
                label_error_direccion.CssClass = "alert alert-danger";

            }
            else
            {
                if (text_direccion_reg.Text.Length < 4 || text_direccion_reg.Text.Length > 20)
                {
                    validacion = false;
                    label_error_direccion.Visible = true;
                    label_error_direccion.Text = "Debe Contener minimo 2 a 20 caracteres";
                    label_error_direccion.CssClass = "alert alert-danger";

                }
                else
                {
                  pac1.Direccion_paciente = text_direccion_reg.Text;

                }
            }
            if (text_telefono_reg.Text.Equals(""))
            {
                validacion = false;
                label_error_telefono.Visible = true;
                label_error_telefono.Text = "Rellene este Campo porfavor";
                label_error_telefono.CssClass = "alert alert-danger";

            }
            else
            {
                if (text_telefono_reg.Text.Length!=10)
                {
                validacion = false;
                label_error_telefono.Visible = true;
                label_error_telefono.Text = "Debe Contener 10 digitos";
                label_error_telefono.CssClass = "alert alert-danger";

                }
                else
                {
                pac1.Telefono_paciente = Convert.ToInt32(text_telefono_reg.Text);

                }
            }
            try
            {
                if (DateTime.Today.AddYears(-18).CompareTo(Convert.ToDateTime(text_nacimiento.Text)) >= 0)
                {
                    pac1.Nacmiento_paciente = Convert.ToDateTime(text_nacimiento.Text);

                }
                else
                {
                    validacion = false;
                    label_error_nacimiento.Visible = true;
                    label_error_nacimiento.Text = "Debe ser Mayor de Edad";
                    label_error_nacimiento.CssClass = "alert alert-danger";

                }
             
            }catch(Exception ex)
            {
                if (ex.ToString().Equals(ex.ToString()))
                {
                validacion = false;
                label_error_nacimiento.Visible = true;
                label_error_nacimiento.Text = "Rellene este Campo porfavor";
                label_error_nacimiento.CssClass = "alert alert-danger";

                }
                
             }
            if (text_correo_reg.Text.Equals(""))
            {
                validacion = false;
                label_error_correo.Visible = true;
            label_error_correo.Text = "Rellene este Campo porfavor";
            label_error_correo.CssClass = "alert alert-danger";

            }
            else
            {
                if (text_correo_reg.Text.Length < 4 )
                {
                    validacion = false;
                label_error_correo.Visible = true;
                label_error_correo.Text = "Debe Contener minimo 4 caracteres";
                label_error_correo.CssClass = "alert alert-danger";

                }
                else
                {
                pac1.Correo_paciente = text_correo_reg.Text;

                }
            }
            if (text_clave_reg.Text.Equals(""))
            {
                validacion = false;
                label_error_pass.Visible = true;
            label_error_pass.Text = "Rellene este Campo porfavor";
            label_error_pass.CssClass = "alert alert-danger";

            }
            else
            {
                if (text_clave_reg.Text.Length < 4 || text_clave_reg.Text.Length>16)
                {
                    validacion = false;
                label_error_pass.Visible = true;
                label_error_pass.Text = "Debe Contener minimo 4 caracteres y maximo 16";
                label_error_pass.CssClass = "alert alert-danger";

                }
                else
                {
                pac1.Clave_paciente = text_clave_reg.Text;

                }
            }
            if (DrpD_paciente.SelectedValue.Equals("Seleccionar Sexo"))
            {
                validacion = false;
                label_error_sexo.Visible = true;
                label_error_sexo.Text = "Debe Seleccionar un Sexo";
                label_error_sexo.CssClass = "alert alert-danger";

            }
            else
            {
                pac1.Sexo = DrpD_paciente.SelectedValue;
            }
            String ruta = FU_registro.PostedFile.FileName;

            if (ruta != null && !(System.IO.Path.GetExtension(ruta).Equals(".jpg") || System.IO.Path.GetExtension(ruta).Equals(".png")))
            {
                validacion = false;
                label_erro_imagen.Visible = true;
                label_erro_imagen.Text = "Debe Seleccionar un Archivo";
                label_erro_imagen.CssClass = "alert alert-danger";
            }
            else
            {

                pac1.Foto = "~\\Imagenes\\Perfiles\\Paciente\\" + System.IO.Path.GetFileName(ruta);

                FU_registro.PostedFile.SaveAs(Server.MapPath(pac1.Foto));
            }
            pac1.Session = Session.SessionID;

            if (validacion == false){
            return;
            }
            if (new DAOPaciente().registrar_paciente(pac1) == null )
            {
                cd.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('El usuario Registrado ya existe');</script>");
                return;
            }
            else
            {
                cd.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Su  usuario ha sido creado satisfactoriamente');</script>");
              
            }

        Response.Redirect("~/View/Principal/index.aspx");



    }
}