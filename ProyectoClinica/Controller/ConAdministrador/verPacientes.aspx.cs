using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Core;
using Utilitarios;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_Administrador_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       

    }

    protected void cargar_Botones_editar_RowDataBound(object sender, GridViewEditEventArgs e)
    {
        if (GV_paciente.EditIndex == e.NewEditIndex)
        {
            Button btn1 = ((Button)GV_paciente.Rows[0].FindControl("but_bloquear"));
            Button btn2 = ((Button)GV_paciente.Rows[0].FindControl("but_desbloquear"));
            String est_lab = ((Label)GV_paciente.Rows[0].FindControl("label_estado")).Text;
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
            String sexo = ((Label)GV_paciente.Rows[0].FindControl("label_edad")).Text;
            DataTable tabla = new DAOEspecializacion().ver_Especializacion();
            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                if (sexo.Equals(tabla.Rows[i]["edad"].ToString()))
                {
                    Label lbl_sede = ((Label)GV_paciente.Rows[0].FindControl("label_edad"));
                    if (tabla.Rows[i]["edad"].ToString().Equals("100"))
                    {
                        lbl_sede.Text = "Todas las Edades";
                    }
                    if (tabla.Rows[i]["edad"].ToString().Equals("3"))
                    {
                        lbl_sede.Text = "Bebes";
                    }
                    if (tabla.Rows[i]["edad"].ToString().Equals("17"))
                    {
                        lbl_sede.Text = "Menores de edad";
                    }
                    if (tabla.Rows[i]["edad"].ToString().Equals("18"))
                    {
                        lbl_sede.Text = "Mayores de Edad";
                    }
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
        }
    }

    protected void GV_Paciente_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("bloquear"))
        {
            Int32 dato = Convert.ToInt32(e.CommandArgument.ToString());
            new DAOUsuario().bloquear_usuario(dato);
            Response.Redirect("~/View/Administrador/verPacientes.aspx");


        }
        else
        {
            if (e.CommandName.Equals("desbloquear"))
            {
                Int32 dato = Convert.ToInt32(e.CommandArgument.ToString());

                new DAOUsuario().desbloquear_usuario(dato);
                Response.Redirect("~/View/Administrador/verPacientes.aspx");


            }
        }
    }
    protected void but_act_pac_Click(object sender, EventArgs e)
    {
        ClientScriptManager cd = this.ClientScript;
        U_Paciente pac = new U_Paciente();
        if ((DataControlRowState.Edit) > 0)
        {
            pac.Id = Convert.ToInt16(((TextBox)GV_paciente.Rows[GV_paciente.EditIndex].FindControl("ed_txt_id")).Text);
            pac.Cedula_paciente = Convert.ToInt32(((TextBox)GV_paciente.Rows[GV_paciente.EditIndex].FindControl("ed_txt_ced_doc")).Text);
            pac.Nombre_paciente= ((TextBox)GV_paciente.Rows[GV_paciente.EditIndex].FindControl("ed_txt_nom_doc")).Text;
            pac.Apellido_paciente = ((TextBox)GV_paciente.Rows[GV_paciente.EditIndex].FindControl("ed_txt_ape_doc")).Text;
            pac.Direccion_paciente = ((TextBox)GV_paciente.Rows[GV_paciente.EditIndex].FindControl("ed_txt_dir_doc")).Text;
            pac.Telefono_paciente = Convert.ToInt32(((TextBox)GV_paciente.Rows[GV_paciente.EditIndex].FindControl("ed_txt_tel_doc")).Text);
            pac.Correo_paciente = ((TextBox)GV_paciente.Rows[GV_paciente.EditIndex].FindControl("ed_txt_cor_doc")).Text;
            pac.Clave_paciente = ((TextBox)GV_paciente.Rows[GV_paciente.EditIndex].FindControl("ed_txt_cla_doc")).Text;
            pac.Nacmiento_paciente = Convert.ToDateTime(((TextBox)GV_paciente.Rows[GV_paciente.EditIndex].FindControl("ed_txt_nac_doc")).Text);
            pac.Sexo = ((DropDownList)GV_paciente.Rows[GV_paciente.EditIndex].FindControl("DDL_sexo_doc")).SelectedValue;
            FileUpload file = ((FileUpload)GV_paciente.Rows[GV_paciente.EditIndex].FindControl("FU_e_foto"));
            if (file.PostedFile.FileName != null && !(System.IO.Path.GetExtension(file.PostedFile.FileName).Equals(".jpg") || System.IO.Path.GetExtension(file.PostedFile.FileName).Equals(".png")))
            {
                pac.Foto = ((Image)GV_paciente.Rows[GV_paciente.EditIndex].FindControl("Image_e_doc")).ImageUrl;
            }
            else
            {

                pac.Foto = "~\\Imagenes\\Perfiles\\Doctor\\" + System.IO.Path.GetFileName(file.PostedFile.FileName);

                file.PostedFile.SaveAs(Server.MapPath(pac.Foto));
            }
            U_Registro modificar= new Core_Paciente().Modificar_paciente(pac);
           
            Response.Redirect(modificar.Url);
        }
    }
}