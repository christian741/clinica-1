using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_Laboratorista_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        ModalPanel.Visible = false;
        label_advertencia.Visible = false;
    }
    protected void but_aceptar_Click(object sender, EventArgs e)
    {
        label_advertencia.Visible = false;
        ModalPanel.Visible = false;

        return;
    }
    protected void button_salir_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/View/Laboratorista/indexLaboratorista.aspx");

    }

    protected void button_editar_Click(object sender, EventArgs e)
    {

        Boolean validacion = true;
        Administrador admin = new Administrador();
        admin.Id = Convert.ToInt32(Session["usuario"].ToString());
        Int32 cedula_label = Convert.ToInt32(((Label)FV_usuario.FindControl("label2")).Text);
        if (((TextBox)FV_usuario.FindControl("txt_cedula")).Text.Equals(""))
        {
            admin.Cedula = Convert.ToInt32(((Label)FV_usuario.FindControl("label2")).Text);
        }
        else
        {
            if (((TextBox)FV_usuario.FindControl("txt_cedula")).Text.Length < 9 || ((TextBox)FV_usuario.FindControl("txt_cedula")).Text.Length > 10)
            {
                validacion = false;
                ((Label)FV_usuario.FindControl("error_ced")).Visible = true;
                ((Label)FV_usuario.FindControl("error_ced")).Text = "Debe Contener almenos 9 o 10 digitos";
                ((Label)FV_usuario.FindControl("error_ced")).CssClass = "alert alert-danger";

            }

            admin.Cedula = Convert.ToInt32(((TextBox)FV_usuario.FindControl("txt_cedula")).Text);



        }
        if (cedula_label == admin.Cedula)
        {

        }
        else
        {
            DataTable datos = new DAOUsuario().buscar_Usuario2(admin.Cedula);

            if (datos.Rows.Count > 0)
            {
                validacion = false;
                ModalPanel.Visible = true;
                label_advertencia.Visible = true;
                label_advertencia.CssClass = "alert alert-danger";
                label_advertencia.Text = "Esta Cedula ya Existe en el Sistema";
                return;
            }
        }
        if (((TextBox)FV_usuario.FindControl("txt_nombre")).Text.Equals(""))
        {
            admin.Nombre = ((Label)FV_usuario.FindControl("label3")).Text;


        }
        else
        {
            if (((TextBox)FV_usuario.FindControl("txt_nombre")).Text.Length < 3)
            {
                validacion = false;
                ((Label)FV_usuario.FindControl("error_nom")).Visible = true;
                ((Label)FV_usuario.FindControl("error_nom")).Text = "Debe Contener minimo 2  caracteres";
                ((Label)FV_usuario.FindControl("error_nom")).CssClass = "alert alert-danger";

            }

            admin.Nombre = ((TextBox)FV_usuario.FindControl("txt_nombre")).Text;



        }
        if (((TextBox)FV_usuario.FindControl("txt_apellido")).Text.Equals(""))
        {
            admin.Apellido = ((Label)FV_usuario.FindControl("label4")).Text;

        }
        else
        {
            if (((TextBox)FV_usuario.FindControl("txt_apellido")).Text.Length < 4 || ((TextBox)FV_usuario.FindControl("txt_apellido")).Text.Length > 40)
            {
                validacion = false;
                ((Label)FV_usuario.FindControl("error_ape")).Visible = true;
                ((Label)FV_usuario.FindControl("error_ape")).Text = "Debe Contener minimo 2  caracteres";
                ((Label)FV_usuario.FindControl("error_ape")).CssClass = "alert alert-danger";

            }

            admin.Apellido = ((TextBox)FV_usuario.FindControl("txt_apellido")).Text;



        }
        if (((TextBox)FV_usuario.FindControl("txt_direccion")).Text.Equals(""))
        {
            admin.Direccion = ((Label)FV_usuario.FindControl("label6")).Text;

        }
        else
        {
            if (((TextBox)FV_usuario.FindControl("txt_direccion")).Text.Length < 9 || ((TextBox)FV_usuario.FindControl("txt_direccion")).Text.Length > 40)
            {
                validacion = false;
                ((Label)FV_usuario.FindControl("error_dir")).Visible = true;
                ((Label)FV_usuario.FindControl("error_dir")).Text = "Debe Contener minimo 9  caracteres";
                ((Label)FV_usuario.FindControl("error_dir")).CssClass = "alert alert-danger";

            }

            admin.Direccion = ((TextBox)FV_usuario.FindControl("txt_direccion")).Text;



        }
        if (((TextBox)FV_usuario.FindControl("txt_telefono")).Text.Equals(""))
        {
            admin.Telefono = Convert.ToInt32(((Label)FV_usuario.FindControl("label5")).Text);

        }
        else
        {
            if (((TextBox)FV_usuario.FindControl("txt_telefono")).Text.Length != 10)
            {
                validacion = false;
                ((Label)FV_usuario.FindControl("error_tel")).Visible = true;
                ((Label)FV_usuario.FindControl("error_tel")).Text = "Debe Contener minimo 10  caracteres";
                ((Label)FV_usuario.FindControl("error_tel")).CssClass = "alert alert-danger";

            }

            admin.Telefono = Convert.ToInt32(((TextBox)FV_usuario.FindControl("txt_telefono")).Text);



        }

        if (((TextBox)FV_usuario.FindControl("txt_correo")).Text.Equals(""))
        {
            admin.Correo = ((Label)FV_usuario.FindControl("label7")).Text;

        }
        else
        {
            if (((TextBox)FV_usuario.FindControl("txt_correo")).Text.Length < 7)
            {
                validacion = false;
                ((Label)FV_usuario.FindControl("error_correo")).Visible = true;
                ((Label)FV_usuario.FindControl("error_correo")).Text = "Debe Contener minimo 7  caracteres";
                ((Label)FV_usuario.FindControl("error_correo")).CssClass = "alert alert-danger";

            }

            admin.Correo = ((TextBox)FV_usuario.FindControl("txt_correo")).Text;



        }
        if (((TextBox)FV_usuario.FindControl("txt_contraseña")).Text.Equals(""))
        {
            admin.Clave = ((Label)FV_usuario.FindControl("label8")).Text;

        }
        else
        {
            if (((TextBox)FV_usuario.FindControl("txt_contraseña")).Text.Length < 8 || ((TextBox)FV_usuario.FindControl("txt_contraseña")).Text.Length > 16)
            {
                validacion = false;
                ((Label)FV_usuario.FindControl("error_clave")).Visible = true;
                ((Label)FV_usuario.FindControl("error_clave")).Text = "Debe Contener minimo 8  caracteres";
                ((Label)FV_usuario.FindControl("error_clave")).CssClass = "alert alert-danger";

            }

            admin.Clave = ((TextBox)FV_usuario.FindControl("txt_contraseña")).Text;



        }
        try
        {
            if (DateTime.Today.AddYears(-18).CompareTo(Convert.ToDateTime(((TextBox)FV_usuario.FindControl("txt_nacimiento")).Text)) >= 0)
            {

                admin.Nacimiento = Convert.ToDateTime(((TextBox)FV_usuario.FindControl("txt_nacimiento")).Text);

            }
            else
            {
                validacion = false;
                ((Label)FV_usuario.FindControl("error_nac")).Visible = true;
                ((Label)FV_usuario.FindControl("error_nac")).Text = "Debe ser Mayor de Edad";
                ((Label)FV_usuario.FindControl("error_nac")).CssClass = "alert alert-danger";


            }

        }
        catch (Exception ex)
        {
            if (ex.ToString().Equals(ex.ToString()))
            {

                admin.Nacimiento = Convert.ToDateTime(((Label)FV_usuario.FindControl("label9")).Text);

            }

        }





        admin.Sexo = ((DropDownList)FV_usuario.FindControl("DDL_sexo_doc")).SelectedValue;

        if (admin.Sexo.Equals("Seleccione un Sexo"))
        {
            admin.Sexo = ((Label)FV_usuario.FindControl("label_10")).Text;
        }
        else
        {
            admin.Sexo = ((DropDownList)FV_usuario.FindControl("DDL_sexo_doc")).SelectedValue;

        }

        FileUpload file = ((FileUpload)FV_usuario.FindControl("File_usu"));
        if (file.PostedFile.FileName != null && !(System.IO.Path.GetExtension(file.PostedFile.FileName).Equals(".jpg") || System.IO.Path.GetExtension(file.PostedFile.FileName).Equals(".png")))
        {
            admin.Foto = ((Image)FV_usuario.FindControl("Imagen_usu")).ImageUrl.ToString();
        }
        else
        {

            admin.Foto = "~\\Imagenes\\Perfiles\\Laboratorista\\" + System.IO.Path.GetFileName(file.PostedFile.FileName);

            file.PostedFile.SaveAs(Server.MapPath(admin.Foto));
        }
        if (validacion == false)
        {
            return;
        }
        admin.Sede = Convert.ToInt32(Session["sede"].ToString());
        new DAOAdministrador().modificar_admin(admin);
        Response.Redirect("~/View/Laboratorista/indexLaboratorista.aspx");

    }

}