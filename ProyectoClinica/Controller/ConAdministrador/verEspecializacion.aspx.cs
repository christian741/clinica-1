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
        if (GV_especializacion.EditIndex == e.NewEditIndex)
        {
            Button btn1 = ((Button)GV_especializacion.Rows[0].FindControl("but_bloquear"));
            Button btn2 = ((Button)GV_especializacion.Rows[0].FindControl("but_desbloquear"));
            String est_lab = ((Label)GV_especializacion.Rows[0].FindControl("label_estado")).Text;
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
            String sede = ((Label)GV_especializacion.Rows[0].FindControl("label_sede")).Text;
            String prioridad = ((Label)GV_especializacion.Rows[0].FindControl("label_prioridad")).Text;
            DataTable tabla = new DAOSede().ver_Sede();
            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                if (sede.Equals(tabla.Rows[i]["id_sede"].ToString()))
                {
                    Label lbl_sede = ((Label)GV_especializacion.Rows[0].FindControl("label_sede"));
                    lbl_sede.Text = tabla.Rows[i]["nombre"].ToString();
                }
                if (prioridad.Equals(tabla.Rows[i]["prioridad"].ToString()))
                {
                    Label lbl_prioridad = ((Label)GV_especializacion.Rows[0].FindControl("label_prioridad"));
                    if (tabla.Rows[i]["prioridad"].ToString().Equals("1"))
                    {
                        lbl_prioridad.Text = "Todos";
                    }
                    if (tabla.Rows[i]["prioridad"].ToString().Equals("2"))
                    {
                        lbl_prioridad.Text = "Solo Doctores";
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
                String sexo = ((Label)e.Row.FindControl("label_edad")).Text;
                String prioridad = ((Label)e.Row.FindControl("label_prioridad")).Text;
                 DataTable tabla = new DAOEspecializacion().ver_Especializacion();
                for (int i = 0; i < tabla.Rows.Count; i++)
                {
                    if (sexo.Equals(tabla.Rows[i]["edad"].ToString()))
                    {
                        Label lbl_sede = ((Label)e.Row.FindControl("label_edad"));
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
                    if (prioridad.Equals(tabla.Rows[i]["prioridad"].ToString()))
                     {
                        Label lbl_prioridad = ((Label)e.Row.FindControl("label_prioridad"));
                        if (tabla.Rows[i]["prioridad"].ToString().Equals("1"))
                        {
                        lbl_prioridad.Text = "Todos";
                        }
                        if (tabla.Rows[i]["prioridad"].ToString().Equals("2"))
                        {
                        lbl_prioridad.Text = "Solo Doctores";
                        }
                       
                    }

            }



        }



    }
    protected void GV_Especializacion_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("bloquear"))
        {
            Int32 dato = Convert.ToInt32(e.CommandArgument.ToString());
            new DAOEspecializacion().bloquear_Especializacion(dato);
            Response.Redirect("~/View/Administrador/verEspecializacion.aspx");


        }
        else
        {
            if (e.CommandName.Equals("desbloquear"))
            {
                Int32 dato = Convert.ToInt32(e.CommandArgument.ToString());
                new DAOEspecializacion().desbloquear_Especializacion(dato);
                Response.Redirect("~/View/Administrador/verEspecializacion.aspx");


            }
        }
    }

   

    protected void but_ed_esp_Click(object sender, EventArgs e)
    {
        ClientScriptManager cd = this.ClientScript;
        Especializacion esp = new Especializacion();
        if ((DataControlRowState.Edit) > 0)
        {
            esp.Nombre = ((TextBox)GV_especializacion.Rows[GV_especializacion.EditIndex].FindControl("txt_esp_nom")).Text;

            esp.Descripcion = ((TextBox)GV_especializacion.Rows[GV_especializacion.EditIndex].FindControl("txt_esp_des")).Text;
            string edad =((DropDownList)GV_especializacion.Rows[GV_especializacion.EditIndex].FindControl("DDL_edad_esp")).SelectedValue;
            if (edad.Equals("Seleccione una Edad"))
            {
                String edad1 = ((Label)GV_especializacion.Rows[GV_especializacion.EditIndex].FindControl("label_edad")).Text;
                if (edad1.Equals("Bebes"))
                {
                    esp.Edad = 3;
                }
                if(edad1.Equals("Menores de edad"))
                 {
                    esp.Edad = 17;
                }
                 if (edad1.Equals("Mayores de edad"))
                {
                    esp.Edad = 18;
                }
                if (edad1.Equals("Todas las Edades"))
                {
                    esp.Edad = 100;
                }
                
            }
            else
            {
                edad = ((DropDownList)GV_especializacion.Rows[GV_especializacion.EditIndex].FindControl("DDL_edad_esp")).SelectedValue;
                esp.Edad = Convert.ToInt16(edad);
            }
            string priori = ((DropDownList)GV_especializacion.Rows[GV_especializacion.EditIndex].FindControl("DDL_prioridad")).SelectedValue;
            if (priori.Equals("Seleccione un Permiso"))
            {
                string priori2 = ((Label)GV_especializacion.Rows[GV_especializacion.EditIndex].FindControl("label_prioridad")).Text;
                if (priori2.Equals("Todos"))
                {
                    esp.Prioridad = 1;
                }
                if (priori2.Equals("Solo Doctores"))
                {
                    esp.Prioridad = 2;
                }
            }
            else
            {
                if (priori.Equals("Todos"))
                {
                    esp.Prioridad = 1;
                }
                if(priori.Equals("Solo Doctores"))
                {
                    esp.Prioridad = 2;
                }
            }
            esp.Sexo = ((DropDownList)GV_especializacion.Rows[GV_especializacion.EditIndex].FindControl("DDL_sexo_esp")).SelectedValue;
            if (esp.Sexo.Equals("Seleccione un Sexo"))
            {
                string sexo = ((Label)GV_especializacion.Rows[GV_especializacion.EditIndex].FindControl("label_sexo")).Text;
                esp.Sexo = sexo;
            }
            else
            {
                esp.Sexo = ((DropDownList)GV_especializacion.Rows[GV_especializacion.EditIndex].FindControl("DDL_sexo_esp")).SelectedValue;
            }
            FileUpload file = ((FileUpload)GV_especializacion.Rows[GV_especializacion.EditIndex].FindControl("FU_edi_esp"));
            if (file.PostedFile.FileName != null && !(System.IO.Path.GetExtension(file.PostedFile.FileName).Equals(".jpg") || System.IO.Path.GetExtension(file.PostedFile.FileName).Equals(".png")))
            {
                esp.Foto = ((Image)GV_especializacion.Rows[GV_especializacion.EditIndex].FindControl("img_ed_esp")).ImageUrl;
            }
            else
            {

                esp.Foto = "~\\Imagenes\\Perfiles\\Especializacion\\" + System.IO.Path.GetFileName(file.PostedFile.FileName);

                file.PostedFile.SaveAs(Server.MapPath(esp.Foto));
            }
            esp.Id = Convert.ToInt16(((TextBox)GV_especializacion.Rows[GV_especializacion.EditIndex].FindControl("txt_id_esp")).Text);
            new DAOEspecializacion().Editar_Especializacion(esp);
            Response.Redirect("~/View/Administrador/verEspecializacion.aspx");

        }

    }
}