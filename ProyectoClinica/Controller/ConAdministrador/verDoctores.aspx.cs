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
        if (GV_Doctor.EditIndex == e.NewEditIndex)
        {
            ((TextBox)GV_Doctor.Rows[0].FindControl("ed_txt_nac_doc")).Text= DateTime.Now.ToShortDateString();
            Button btn1 = ((Button)GV_Doctor.Rows[0].FindControl("but_bloquear"));
            Button btn2 = ((Button)GV_Doctor.Rows[0].FindControl("but_desbloquear"));
            String est_lab = ((Label)GV_Doctor.Rows[0].FindControl("label_estado")).Text;

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

            String sede = ((Label)GV_Doctor.Rows[0].FindControl("label_sede")).Text;

            DataTable tabla = new DAOSede().ver_Sede();
            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                if (sede.Equals(tabla.Rows[i]["id_sede"].ToString()))
                {
                    Label lbl_sede = ((Label)GV_Doctor.Rows[0].FindControl("label_sede"));
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

    protected void but_act_doc_Click(object sender, EventArgs e)
    {
        ClientScriptManager cd = this.ClientScript;
        Doctor doc= new Doctor();
        if ((DataControlRowState.Edit) > 0)
        {
            doc.Id = Convert.ToInt16(((TextBox)GV_Doctor.Rows[GV_Doctor.EditIndex].FindControl("ed_txt_id")).Text);
            doc.Cedula_doctor =Convert.ToInt32(((TextBox)GV_Doctor.Rows[GV_Doctor.EditIndex].FindControl("ed_txt_ced_doc")).Text);
            doc.Nombre_doctor = ((TextBox)GV_Doctor.Rows[GV_Doctor.EditIndex].FindControl("ed_txt_nom_doc")).Text;
            doc.Apellido_doctor= ((TextBox)GV_Doctor.Rows[GV_Doctor.EditIndex].FindControl("ed_txt_ape_doc")).Text;
            doc.Direccion_doctor= ((TextBox)GV_Doctor.Rows[GV_Doctor.EditIndex].FindControl("ed_txt_dir_doc")).Text;
            doc.Telefono_doctor = Convert.ToInt32( ((TextBox)GV_Doctor.Rows[GV_Doctor.EditIndex].FindControl("ed_txt_tel_doc")).Text);
            doc.Correo_doctor=((TextBox)GV_Doctor.Rows[GV_Doctor.EditIndex].FindControl("ed_txt_cor_doc")).Text;
            doc.Clave_doctor= ((TextBox)GV_Doctor.Rows[GV_Doctor.EditIndex].FindControl("ed_txt_cla_doc")).Text;
           
            if (doc.Nacmiento_doctor.Equals(DateTime.Now.ToShortDateString())) { 
                    doc.Nacmiento_doctor = Convert.ToDateTime(((Label)GV_Doctor.Rows[GV_Doctor.EditIndex].FindControl("label_nacimiento")).Text);
            }
            else
            {
                doc.Nacmiento_doctor = Convert.ToDateTime(((TextBox)GV_Doctor.Rows[GV_Doctor.EditIndex].FindControl("ed_txt_nac_doc")).Text);

            }
           
            doc.Sexo=((DropDownList)GV_Doctor.Rows[GV_Doctor.EditIndex].FindControl("DDL_sexo_doc")).SelectedValue;

            if (doc.Sexo.Equals("Seleccione un Sexo"))
            {
                doc.Sexo = ((Label)GV_Doctor.Rows[GV_Doctor.EditIndex].FindControl("label_sexo")).Text;
            }
            else
            {
                doc.Sexo = ((DropDownList)GV_Doctor.Rows[GV_Doctor.EditIndex].FindControl("DDL_sexo_doc")).SelectedValue;

            }
            string sede= ((DropDownList)GV_Doctor.Rows[GV_Doctor.EditIndex].FindControl("DDL_sede_doctor")).SelectedItem.Text;
            string sede2 = ((Label)GV_Doctor.Rows[GV_Doctor.EditIndex].FindControl("label_sede")).Text;
            DataTable datos = new DAOSede().ver_Sede();
            if (sede.Equals("Seleccione una Sede"))
            {
                for(int i = 0;i<datos.Rows.Count; i++)
                {
                    if (datos.Rows[i]["nombre"].ToString().Equals(sede2))
                    {
                        doc.Sede = Convert.ToInt16(datos.Rows[i]["id_sede"].ToString());
                    }
                }
            }
            else
            {
              
              string sede3= ((DropDownList)GV_Doctor.Rows[GV_Doctor.EditIndex].FindControl("DDL_sede_doctor")).SelectedValue;
                doc.Sede = Convert.ToInt16(sede3);

            }
            FileUpload file = ((FileUpload)GV_Doctor.Rows[GV_Doctor.EditIndex].FindControl("FU_e_foto"));
            if (file.PostedFile.FileName != null && !(System.IO.Path.GetExtension(file.PostedFile.FileName).Equals(".jpg") || System.IO.Path.GetExtension(file.PostedFile.FileName).Equals(".png")))
            {
                doc.Foto = ((Image)GV_Doctor.Rows[GV_Doctor.EditIndex].FindControl("Image_e_doc")).ImageUrl.ToString();
            }
            else
            {

                doc.Foto = "~\\Imagenes\\Perfiles\\Doctor\\" + System.IO.Path.GetFileName(file.PostedFile.FileName);

                file.PostedFile.SaveAs(Server.MapPath(doc.Foto));
            }

            new DAODoctor().modificar_doctor(doc);
            Response.Redirect("~/View/Administrador/verDoctores.aspx");
        }
    }

   
    

    protected void GV_Doctor_RowCommand(object sender, GridViewCommandEventArgs e)
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
}