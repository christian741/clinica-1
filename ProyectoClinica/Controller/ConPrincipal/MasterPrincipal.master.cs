using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_Principal_MasterPrincipal : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ModalPanel.Visible = false;
        label_advertencia.Visible = false;
    }
  

    protected void button_ingresar_Click(object sender, EventArgs e)
    {
        if (text_cedula.Text.Equals("") || text_contraseña.Text.Equals(""))
        {
            ModalPanel.Visible = true;
            label_advertencia.Visible = true;
            label_advertencia.CssClass = "alert alert-danger";
            label_advertencia.Text = "Sus Datos son erroneos";

            return;
        }
            DataTable datos_usuario = new DAOAdministrador().buscar_Usuario(Convert.ToInt32(text_cedula.Text), text_contraseña.Text);
           
           
             if (datos_usuario.Rows.Count>0)
            {
                if (datos_usuario.Rows[0]["estado"].ToString().Equals("2"))
                {
                    ModalPanel.Visible = true;
                    label_advertencia.Visible = true;
                    label_advertencia.CssClass = "alert alert-danger";
                    label_advertencia.Text = "Su Usuario esta Bloqueado,Contactese con el Administrador";

                    return;
                }
                if (datos_usuario.Rows[0]["rol_id"].ToString().Equals("1"))
                {
                    Usuario usu = new Usuario();
                    Session["usuario"] = Convert.ToInt32(datos_usuario.Rows[0]["id_usuario"].ToString());
                    Session["rol"] = Convert.ToInt32(datos_usuario.Rows[0]["rol_id"].ToString());
                    Session["sede"] = Convert.ToInt32(datos_usuario.Rows[0]["sede_id"].ToString());

                     MAC datosConexion = new MAC();

                    usu.Id = Convert.ToInt32(datos_usuario.Rows[0]["id_usuario"].ToString());
                    usu.Ip = datosConexion.ip();
                    usu.Mac = datosConexion.mac();
                    usu.Session = Session.SessionID;

                    new DAOUsuario().guardadoSession(usu);

                    Response.Redirect("../Paciente/indexPaciente.aspx");
                }
                else
                {
                    if (datos_usuario.Rows[0]["rol_id"].ToString().Equals("2"))
                    {
                        Usuario usu = new Usuario();
                        Session["usuario"] = Convert.ToInt32(datos_usuario.Rows[0]["id_usuario"].ToString());
                        Session["rol"] = Convert.ToInt32(datos_usuario.Rows[0]["rol_id"].ToString());
                        Session["sede"] = Convert.ToInt32(datos_usuario.Rows[0]["sede_id"].ToString());

                        MAC datosConexion = new MAC();

                        usu.Id = Convert.ToInt16(datos_usuario.Rows[0]["id_usuario"].ToString());
                        usu.Ip = datosConexion.ip();
                        usu.Mac = datosConexion.mac();
                        usu.Session = Session.SessionID;

                        new DAOUsuario().guardadoSession(usu);
                        DataTable dia = new DAODoctor().traer_descanzo(Convert.ToInt32(Session["usuario"].ToString()));
                        if (dia.Rows[0]["dias_descanzo"].ToString().Equals("null"))
                        {
                             Response.Redirect("../Doctor/diasHorario.aspx");

                        }
                        Response.Redirect("../Doctor/indexDoctor.aspx");

                    }
                    else
                    {
                        if (datos_usuario.Rows[0]["rol_id"].ToString().Equals("3"))
                        {
                            Usuario usu = new Usuario();
                        Session["usuario"] = Convert.ToInt32(datos_usuario.Rows[0]["id_usuario"].ToString());
                        Session["rol"] = Convert.ToInt32(datos_usuario.Rows[0]["rol_id"].ToString());
                        Session["sede"] = Convert.ToInt32(datos_usuario.Rows[0]["sede_id"].ToString());
                        MAC datosConexion = new MAC();

                            usu.Id = Convert.ToInt16(datos_usuario.Rows[0]["id_usuario"].ToString());
                            usu.Ip = datosConexion.ip();
                            usu.Mac = datosConexion.mac();
                            usu.Session = Session.SessionID;

                            new DAOUsuario().guardadoSession(usu);
                            Response.Redirect("../Farmaceuta/indexFarmaceuta.aspx");

                        }
                        else
                        {
                            if (datos_usuario.Rows[0]["rol_id"].ToString().Equals("4"))
                            {
                                Usuario usu = new Usuario();
                                Session["usuario"] = Convert.ToInt32(datos_usuario.Rows[0]["id_usuario"].ToString());
                                Session["rol"] = Convert.ToInt32(datos_usuario.Rows[0]["rol_id"].ToString());
                                Session["sede"] = Convert.ToInt32(datos_usuario.Rows[0]["sede_id"].ToString());
                                MAC datosConexion = new MAC();

                                usu.Id = Convert.ToInt16(datos_usuario.Rows[0]["id_usuario"].ToString());
                                usu.Ip = datosConexion.ip();
                                usu.Mac = datosConexion.mac();
                                usu.Session = Session.SessionID;

                                new DAOUsuario().guardadoSession(usu);
                                Response.Redirect("../Laboratorista/indexLaboratorista.aspx");

                             }
                             else
                             {
                                    if (datos_usuario.Rows[0]["rol_id"].ToString().Equals("5"))
                                    {
                                        Usuario usu = new Usuario();
                                        Session["usuario"] = Convert.ToInt32(datos_usuario.Rows[0]["id_usuario"].ToString());
                                        Session["rol"] = Convert.ToInt32(datos_usuario.Rows[0]["rol_id"].ToString());
                                        Session["sede"] = Convert.ToInt32(datos_usuario.Rows[0]["sede_id"].ToString());
                                        MAC datosConexion = new MAC();

                                        usu.Id = Convert.ToInt16(datos_usuario.Rows[0]["id_usuario"].ToString());
                                        usu.Ip = datosConexion.ip();
                                        usu.Mac = datosConexion.mac();
                                        usu.Session = Session.SessionID;

                                        new DAOUsuario().guardadoSession(usu);
                                        Response.Redirect("../Administrador/indexAdmin.aspx");

                                     }
                                }


                         }
                    }
                }
            }
        Session["usuario"] = null;
        Session["rol"] = null;
        Session["sede"] = null;

        ModalPanel.Visible = true;
        label_advertencia.Visible = true;
        label_advertencia.CssClass = "alert alert-danger";
        label_advertencia.Text = "Lo siento Sus datos son Incorrectos";

        return;

        

        
    }



    protected void but_aceptar_Click(object sender, EventArgs e)
    {
        label_advertencia.Visible = false;
        ModalPanel.Visible = false;

        return;
    }
}
