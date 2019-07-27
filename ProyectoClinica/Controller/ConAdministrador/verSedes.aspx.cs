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

    protected void cargar_Botones_editar_RowDataBound(object sender, GridViewEditEventArgs e)
    {
        if (GV_sedes.EditIndex==e.NewEditIndex)
        {
            Button btn1 = ((Button)GV_sedes.Rows[0].FindControl("but_bloquear"));
            Button btn2 = ((Button)GV_sedes.Rows[0].FindControl("but_desbloquear"));
            String est_lab = ((Label)GV_sedes.Rows[0].FindControl("label_estado")).Text;
            if (est_lab.Equals("1"))
            {

                btn1.Visible = true;
                btn2.Visible = false;
            }
            else
            {
                btn1.Visible = false;
                btn2.Visible = true;
            }

        }
    }
    protected void cargar_Botones_RowDataBound(object sender, GridViewRowEventArgs e)
    {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Button btn1 = ((Button)e.Row.FindControl("but_bloquear"));
                Button btn2 = ((Button)e.Row.FindControl("but_desbloquear"));
                String est_lab = ((Label)e.Row.FindControl("label_estado")).Text;
                if (est_lab.Equals("1"))
                {

                    btn1.Visible = true;
                    btn2.Visible = false;
                }
                else
                {
                    btn1.Visible = false;
                    btn2.Visible = true;
                }

            }
        
        
    }
    protected void GV_Sede_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("bloquear"))
        {
            Int32 dato = Convert.ToInt32(e.CommandArgument.ToString());
            new DAOSede().bloquear_Sede(dato);
            Response.Redirect("~/View/Administrador/verSedes.aspx");


        }
        else
        {
            if (e.CommandName.Equals("desbloquear"))
            {
                Int32 dato = Convert.ToInt32(e.CommandArgument.ToString());

                new DAOSede().desbloquear_Sede(dato);
                Response.Redirect("~/View/Administrador/verSedes.aspx");

            }
        }
    }
    protected void but_act_sed_Click(object sender, EventArgs e)
    {
        ((Label)GV_sedes.Rows[GV_sedes.EditIndex].FindControl("label_error_nombre")).Visible = false;
        Boolean validacion = true;
        ClientScriptManager cd = this.ClientScript;
        Sede sed = new Sede();
        if ((DataControlRowState.Edit) > 0){

            if (((TextBox)GV_sedes.Rows[GV_sedes.EditIndex].FindControl("txt_nom_sede")).Text.Equals(""))
            {
                ((Label)GV_sedes.Rows[GV_sedes.EditIndex].FindControl("label_error_nombre")).Text = "Rellene este Campo";
                ((Label)GV_sedes.Rows[GV_sedes.EditIndex].FindControl("label_error_nombre")).Visible = true;
                validacion = false;
            }
            else
            {
                if (((TextBox)GV_sedes.Rows[GV_sedes.EditIndex].FindControl("txt_nom_sede")).Text.Length<4)
                {
                    ((Label)GV_sedes.Rows[GV_sedes.EditIndex].FindControl("label_error_nombre")).Text = "Debe Contener minimo 4 caracteres";
                    ((Label)GV_sedes.Rows[GV_sedes.EditIndex].FindControl("label_error_nombre")).Visible = true;
                    validacion = false;

                }
                sed.Nombre = ((TextBox)GV_sedes.Rows[GV_sedes.EditIndex].FindControl("txt_nom_sede")).Text;

            }
            if (((TextBox)GV_sedes.Rows[GV_sedes.EditIndex].FindControl("txt_des_sede")).Text.Equals(""))
            {
                ((Label)GV_sedes.Rows[GV_sedes.EditIndex].FindControl("label_error_des")).Text = "Rellene este Campo";
                ((Label)GV_sedes.Rows[GV_sedes.EditIndex].FindControl("label_error_des")).Visible = true;
                validacion = false;
            }
            else
            {
                if (((TextBox)GV_sedes.Rows[GV_sedes.EditIndex].FindControl("txt_des_sede")).Text.Length < 8)
                {
                    ((Label)GV_sedes.Rows[GV_sedes.EditIndex].FindControl("label_error_des")).Text = "Debe Contener minimo 8 caracteres";
                    ((Label)GV_sedes.Rows[GV_sedes.EditIndex].FindControl("label_error_des")).Visible = true;
                    validacion = false;

                }
                sed.Descripcion = ((TextBox)GV_sedes.Rows[GV_sedes.EditIndex].FindControl("txt_des_sede")).Text;

            }
            if (((TextBox)GV_sedes.Rows[GV_sedes.EditIndex].FindControl("txt_cid_sede")).Text.Equals(""))
            {
                ((Label)GV_sedes.Rows[GV_sedes.EditIndex].FindControl("label_error_ciudad")).Text = "Rellene este Campo";
                ((Label)GV_sedes.Rows[GV_sedes.EditIndex].FindControl("label_error_ciudad")).Visible = true;
                validacion = false;
            }
            else
            {
                if (((TextBox)GV_sedes.Rows[GV_sedes.EditIndex].FindControl("txt_cid_sede")).Text.Length < 4)
                {
                    ((Label)GV_sedes.Rows[GV_sedes.EditIndex].FindControl("label_error_ciudad")).Text = "Debe Contener minimo 4 caracteres";
                    ((Label)GV_sedes.Rows[GV_sedes.EditIndex].FindControl("label_error_ciudad")).Visible = true;
                    validacion = false;

                }
                sed.Ciudad = ((TextBox)GV_sedes.Rows[GV_sedes.EditIndex].FindControl("txt_cid_sede")).Text;

            }
            if (((TextBox)GV_sedes.Rows[GV_sedes.EditIndex].FindControl("txt_dir_sede")).Text.Equals(""))
            {
                ((Label)GV_sedes.Rows[GV_sedes.EditIndex].FindControl("label_error_direccion")).Text = "Rellene este Campo";
                ((Label)GV_sedes.Rows[GV_sedes.EditIndex].FindControl("label_error_direccion")).Visible = true;
                validacion = false;
            }
            else
            {
                if (((TextBox)GV_sedes.Rows[GV_sedes.EditIndex].FindControl("txt_dir_sede")).Text.Length<8)
                {
                    ((Label)GV_sedes.Rows[GV_sedes.EditIndex].FindControl("label_error_direccion")).Text = "minimo 8 caracteres";
                    ((Label)GV_sedes.Rows[GV_sedes.EditIndex].FindControl("label_error_direccion")).Visible = true;
                    validacion = false;
                }
                sed.Direccion = ((TextBox)GV_sedes.Rows[GV_sedes.EditIndex].FindControl("txt_dir_sede")).Text;


            }
            if (((TextBox)GV_sedes.Rows[GV_sedes.EditIndex].FindControl("txt_eng_sede")).Text.Equals(""))
            {
                ((Label)GV_sedes.Rows[GV_sedes.EditIndex].FindControl("label_error_eng")).Text = "Rellene este Campo";
                ((Label)GV_sedes.Rows[GV_sedes.EditIndex].FindControl("label_error_eng")).Visible = true;
                validacion = false;
            }
            else
            {
                if (((TextBox)GV_sedes.Rows[GV_sedes.EditIndex].FindControl("txt_eng_sede")).Text.Length < 8)
                {
                    ((Label)GV_sedes.Rows[GV_sedes.EditIndex].FindControl("label_error_eng")).Text = "minimo 8 caracteres";
                    ((Label)GV_sedes.Rows[GV_sedes.EditIndex].FindControl("label_error_eng")).Visible = true;
                    validacion = false;
                }
                sed.Encargado = ((TextBox)GV_sedes.Rows[GV_sedes.EditIndex].FindControl("txt_eng_sede")).Text;


            }

            FileUpload file = ((FileUpload)GV_sedes.Rows[GV_sedes.EditIndex].FindControl("FU_ed_Sede"));
            if (file.PostedFile.FileName != null && !(System.IO.Path.GetExtension(file.PostedFile.FileName).Equals(".jpg") || System.IO.Path.GetExtension(file.PostedFile.FileName).Equals(".png")))
            {
                sed.Foto = ((Image)GV_sedes.Rows[GV_sedes.EditIndex].FindControl("Img_ed_sede")).ImageUrl;
            }
            else
            {

                sed.Foto = "~\\Imagenes\\Perfiles\\Sede\\" + System.IO.Path.GetFileName(file.PostedFile.FileName);

                file.PostedFile.SaveAs(Server.MapPath(sed.Foto));
            }
            sed.Id = Convert.ToInt16(((TextBox)GV_sedes.Rows[GV_sedes.EditIndex].FindControl("txt_id_sede")).Text);
            if (validacion == false)
            {
                return;
            }
            new DAOSede().modificar_sede(sed);
            Response.Redirect("~/View/Administrador/verSedes.aspx");

        }
    }
}