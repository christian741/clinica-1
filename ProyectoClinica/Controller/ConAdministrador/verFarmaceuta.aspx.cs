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
        if (GV_farmaceuta.EditIndex == e.NewEditIndex)
        {
            ((TextBox)GV_farmaceuta.Rows[0].FindControl("ed_txt_nac_far")).Text = DateTime.Now.ToShortDateString();
            Button btn1 = ((Button)GV_farmaceuta.Rows[0].FindControl("but_bloquear"));
            Button btn2 = ((Button)GV_farmaceuta.Rows[0].FindControl("but_desbloquear"));
            String est_lab = ((Label)GV_farmaceuta.Rows[0].FindControl("label_estado")).Text;
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
            String sede = ((Label)GV_farmaceuta.Rows[0].FindControl("label_sede")).Text;

            DataTable tabla = new DAOSede().ver_Sede();
            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                if (sede.Equals(tabla.Rows[i]["id_sede"].ToString()))
                {
                    Label lbl_sede = ((Label)GV_farmaceuta.Rows[0].FindControl("label_sede"));
                    lbl_sede.Text = tabla.Rows[i]["nombre"].ToString();
                }
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
            String sede = ((Label)e.Row.FindControl("label_sede")).Text;

            DataTable tabla = new DAOSede().ver_Sede();
            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                if (sede.Equals(tabla.Rows[i]["id_sede"].ToString()))
                {
                    Label lbl_sede = ((Label)e.Row.FindControl("label_sede"));
                    lbl_sede.Text = tabla.Rows[i]["nombre"].ToString();
                }
            }
        }
    }


    protected void GV_Farmaceuta_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("bloquear"))
        {
            Int32 dato = Convert.ToInt32(e.CommandArgument.ToString());
            new DAOUsuario().bloquear_usuario(dato);
            Response.Redirect("~/View/Administrador/verDoctores.aspx");


        }
        else
        {
            if (e.CommandName.Equals("desbloquear"))
            {
                Int32 dato = Convert.ToInt32(e.CommandArgument.ToString());

                new DAOUsuario().desbloquear_usuario(dato);
                Response.Redirect("~/View/Administrador/verDoctores.aspx");


            }
        }
    }
    protected void but_act_doc_Click(object sender, EventArgs e)
    {
        ClientScriptManager cd = this.ClientScript;
        Farmaceuta far = new Farmaceuta();
        if ((DataControlRowState.Edit) > 0)
        {
            far.Id = Convert.ToInt16(((TextBox)GV_farmaceuta.Rows[GV_farmaceuta.EditIndex].FindControl("ed_txt_id")).Text);
            far.Cedula_farmaceuta = Convert.ToInt32(((TextBox)GV_farmaceuta.Rows[GV_farmaceuta.EditIndex].FindControl("ed_txt_ced_far")).Text);
            far.Nombre_farmaceuta = ((TextBox)GV_farmaceuta.Rows[GV_farmaceuta.EditIndex].FindControl("ed_txt_nom_far")).Text;
            far.Apellido_farmaceuta = ((TextBox)GV_farmaceuta.Rows[GV_farmaceuta.EditIndex].FindControl("ed_txt_ape_far")).Text;
            far.Direccion_farmaceuta = ((TextBox)GV_farmaceuta.Rows[GV_farmaceuta.EditIndex].FindControl("ed_txt_dir_far")).Text;
            far.Telefono_farmaceuta = Convert.ToInt32(((TextBox)GV_farmaceuta.Rows[GV_farmaceuta.EditIndex].FindControl("ed_txt_tel_far")).Text);
            far.Correo_farmaceuta = ((TextBox)GV_farmaceuta.Rows[GV_farmaceuta.EditIndex].FindControl("ed_txt_cor_far")).Text;
            far.Clave_farmaceuta = ((TextBox)GV_farmaceuta.Rows[GV_farmaceuta.EditIndex].FindControl("ed_txt_cla_far")).Text;
            far.Nacmiento_farmaceuta = Convert.ToDateTime(((TextBox)GV_farmaceuta.Rows[GV_farmaceuta.EditIndex].FindControl("ed_txt_nac_far")).Text);
            far.Sexo = ((DropDownList)GV_farmaceuta.Rows[GV_farmaceuta.EditIndex].FindControl("DDL_sexo_far")).SelectedValue;
            FileUpload file = ((FileUpload)GV_farmaceuta.Rows[GV_farmaceuta.EditIndex].FindControl("FU_e_foto"));
            if (file.PostedFile.FileName != null && !(System.IO.Path.GetExtension(file.PostedFile.FileName).Equals(".jpg") || System.IO.Path.GetExtension(file.PostedFile.FileName).Equals(".png")))
            {
                far.Foto = ((Image)GV_farmaceuta.Rows[GV_farmaceuta.EditIndex].FindControl("Image_e_far")).ImageUrl;
            }
            else
            {

                far.Foto = "~\\Imagenes\\Perfiles\\Farmaceuta\\" + System.IO.Path.GetFileName(file.PostedFile.FileName);

                file.PostedFile.SaveAs(Server.MapPath(far.Foto));
            }

            new DAOFarmaceuta().modificar_far(far);
            Response.Redirect("~/View/Administrador/verFarmaceuta.aspx");
        }
    }
}