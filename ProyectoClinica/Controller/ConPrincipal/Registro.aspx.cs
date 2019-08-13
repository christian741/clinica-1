using System;
using System.Web.UI;
using Utilitarios;
using Core;


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
      
        U_Registro registro = new U_Registro();
        U_Paciente pac1 = new U_Paciente();

        pac1.Cedula_paciente = Convert.ToInt32(text_cedula_reg.Text);
        label_error_ced.Visible = true;
        //label_error_ced.Text = registro.Error_cedula_paciente;
        pac1.Correo_paciente = text_correo_reg.Text;
        label_error_correo.Visible = true;
        //label_error_correo.Text = registro.Error_correo_paciente;
        pac1.Direccion_paciente = text_direccion_reg.Text;
        label_error_direccion.Visible = true;
        //label_error_direccion.Text = registro.Error_direccion_paciente;
        pac1.Nombre_paciente = text_nombre_reg.Text;
        label_error_nombre.Visible = true;
        //label_error_nombre.Text = registro.Error_nombre_paciente;
        label_erro_imagen.Visible = true;
        //label_erro_imagen.Text = registro.Error_foto;
        pac1.Apellido_paciente = text_apellido_reg.Text;
        label_error_apellido.Visible = true;
        //label_error_apellido.Text = registro.Error_apellido_paciente;
        try
        {
            pac1.Nacmiento_paciente = Convert.ToDateTime(text_nacimiento.Text);
        }
        catch (Exception ex)
        {

        }
        
        label_error_nacimiento.Visible = true;
        //label_error_nacimiento.Text = registro.Error_nacmiento_paciente;
        pac1.Clave_paciente = label_clave.Text;
        label_error_pass.Visible = true;
        //label_error_pass.Text = registro.Error_clave_paciente;
        pac1.Sexo = DrpD_paciente.SelectedValue;
        label_error_sexo.Visible = true;
        //label_error_sexo.Text = registro.Error_sexo;
        pac1.Telefono_paciente = Convert.ToInt32(text_telefono_reg.Text);
        label_error_telefono.Visible = true;
        //label_error_telefono.Text = registro.Error_telefono_paciente;

        pac1.Session = Session.SessionID;
        String ruta = FU_registro.PostedFile.FileName;
        pac1.Foto = ruta;
        registro = new Core_Paciente().registro(pac1 , FU_registro);

        Response.Redirect(registro.Url);
    }
}