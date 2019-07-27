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
        if (GV_laboratorista.EditIndex == e.NewEditIndex)
        {
            ((TextBox)GV_laboratorista.Rows[0].FindControl("ed_txt_nac_lab")).Text = DateTime.Now.ToShortDateString();
            Button btn1 = ((Button)GV_laboratorista.Rows[0].FindControl("but_bloquear"));
            Button btn2 = ((Button)GV_laboratorista.Rows[0].FindControl("but_desbloquear"));
            String est_lab = ((Label)GV_laboratorista.Rows[0].FindControl("label_estado")).Text;
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
            String sede = ((Label)GV_laboratorista.Rows[0].FindControl("label_sede")).Text;

            DataTable tabla = new DAOSede().ver_Sede();
            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                if (sede.Equals(tabla.Rows[i]["id_sede"].ToString()))
                {
                    Label lbl_sede = ((Label)GV_laboratorista.Rows[0].FindControl("label_sede"));
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
    protected void GV_Laboratorista_RowCommand(object sender, GridViewCommandEventArgs e)
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
   
    protected void but_act_lab_Click(object sender, EventArgs e)
    {
        ClientScriptManager cd = this.ClientScript;
        Laboratorista lab = new Laboratorista();
        if ((DataControlRowState.Edit) > 0)
        {
            lab.Id = Convert.ToInt16(((TextBox)GV_laboratorista.Rows[GV_laboratorista.EditIndex].FindControl("ed_txt_id")).Text);
            lab.Cedula_lab = Convert.ToInt32(((TextBox)GV_laboratorista.Rows[GV_laboratorista.EditIndex].FindControl("ed_txt_ced_lab")).Text);
            lab.Nombre_lab = ((TextBox)GV_laboratorista.Rows[GV_laboratorista.EditIndex].FindControl("ed_txt_nom_lab")).Text;
            lab.Apellido_lab = ((TextBox)GV_laboratorista.Rows[GV_laboratorista.EditIndex].FindControl("ed_txt_ape_lab")).Text;
            lab.Direccion_lab = ((TextBox)GV_laboratorista.Rows[GV_laboratorista.EditIndex].FindControl("ed_txt_dir_lab")).Text;
            lab.Telefono_lab = Convert.ToInt32(((TextBox)GV_laboratorista.Rows[GV_laboratorista.EditIndex].FindControl("ed_txt_tel_lab")).Text);
            lab.Correo_lab = ((TextBox)GV_laboratorista.Rows[GV_laboratorista.EditIndex].FindControl("ed_txt_cor_lab")).Text;
            lab.Clave_lab = ((TextBox)GV_laboratorista.Rows[GV_laboratorista.EditIndex].FindControl("ed_txt_cla_lab")).Text;
            lab.Nacmiento_lab = Convert.ToDateTime(((TextBox)GV_laboratorista.Rows[GV_laboratorista.EditIndex].FindControl("ed_txt_nac_lab")).Text);
            lab.Sexo = ((DropDownList)GV_laboratorista.Rows[GV_laboratorista.EditIndex].FindControl("DDL_sexo_lab")).SelectedValue;
            FileUpload file = ((FileUpload)GV_laboratorista.Rows[GV_laboratorista.EditIndex].FindControl("FU_e_foto"));
            if (file.PostedFile.FileName != null && !(System.IO.Path.GetExtension(file.PostedFile.FileName).Equals(".jpg") || System.IO.Path.GetExtension(file.PostedFile.FileName).Equals(".png")))
            {
                lab.Foto = ((Image)GV_laboratorista.Rows[GV_laboratorista.EditIndex].FindControl("Image_e_lab")).ImageUrl;
            }
            else
            {

                lab.Foto = "~\\Imagenes\\Perfiles\\Laboratorista\\" + System.IO.Path.GetFileName(file.PostedFile.FileName);

                file.PostedFile.SaveAs(Server.MapPath(lab.Foto));
            }

            new DAOLaboratorista().modificar_lab(lab);
            Response.Redirect("~/View/Administrador/verLaboratorista.aspx");
        }
    }
}