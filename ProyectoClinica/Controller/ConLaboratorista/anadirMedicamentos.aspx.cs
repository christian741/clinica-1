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

    }
      protected void GV_Pedido_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName.Equals("atender"))
        {
            Session["pedido"] = Convert.ToInt32(e.CommandArgument.ToString());
            Response.Redirect("~/View/Laboratorista/anadirInventario.aspx");
        }
        if (e.CommandName.Equals("cancelar"))
        {
            new DAOLaboratorista().cancelarPedido(Convert.ToInt32(e.CommandArgument.ToString()));

            Response.Redirect("~/View/Laboratorista/anadirMedicamentos.aspx");

        }

    }

    protected void GV_Pedido_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
             Button btn1 = ((Button)e.Row.FindControl("but_atender_pedido"));
             Button btn2 = ((Button)e.Row.FindControl("but_cancelar_pedido"));

            String lab_sede = ((Label)e.Row.FindControl("Label4")).Text;

            String estado = ((Label)e.Row.FindControl("label_estado")).Text;
            String sede = ((Label)e.Row.FindControl("label_sede")).Text;
           
             DateTime fecha = new DateTime().Date;
              fecha  =Convert.ToDateTime( ((Label)e.Row.FindControl("label_fecha_pedido")).Text);
             DateTime mañana = DateTime.Now.AddDays(1);
             if (fecha > mañana)
             {
                 Int32 dato = Convert.ToInt32(((Label)e.Row.FindControl("label_fecha_pedido")).Text);
                 new DAOLaboratorista().retrasoPedido(dato);
             }
             if (estado.Equals("1"))
             {
                 ((Label)e.Row.FindControl("label_estado")).Text = "Pedido Solicitado";
                ((Label)e.Row.FindControl("label_estado")).CssClass = "alert alert-sucess";
                 btn1.Visible = true;
                 btn2.Visible = true;
             }
             if (estado.Equals("2"))
             {

                 ((Label)e.Row.FindControl("label_estado")).Text = "Pedido Retrasado";
                ((Label)e.Row.FindControl("label_estado")).CssClass = "alert alert-warning";
                btn1.Visible = true;
                 btn2.Visible = true;
             }
             if (estado.Equals("3"))
             {
                 ((Label)e.Row.FindControl("label_estado")).Text = "Pedido Cancelado";
                ((Label)e.Row.FindControl("label_estado")).CssClass = "alert alert-danger";
                 btn1.Visible = false;
                 btn2.Visible = false;
             }
             if (estado.Equals("4"))
             {
                 ((Label)e.Row.FindControl("label_estado")).Text = "Pedido Entregado";
                ((Label)e.Row.FindControl("label_estado")).CssClass = "alert alert-info";
                 btn1.Visible = false;
                 btn2.Visible = false;
             }

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
}