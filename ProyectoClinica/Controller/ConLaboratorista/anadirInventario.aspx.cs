using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_Laboratorista_Default : System.Web.UI.Page
{
    private List<ListaInventario> list_inv = new List<ListaInventario>() ;
    private Inventario inventario = new Inventario();
    private ListaInventario lista = new ListaInventario();

    private ListaDevolucion lista2 = new ListaDevolucion();
    private Devolucion devolucion = new Devolucion();
    private List<ListaDevolucion> list_devo = new List<ListaDevolucion>();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["pedido"] == null)
        {
            Response.Redirect("~/View/Laboratorista/anadirMedicamentos.aspx");
        }
        if (IsPostBack == true)
        {
            Session["inventario"] = (List<ListaInventario>)Session["inventario"]; 
            Session["devolucion"] = (List<ListaDevolucion>)Session["devolucion"];


        }
        else
        {


            Session["inventario"] = null;
            Session["devolucion"] = null;
        }
       
    }



    protected void GV_inventario_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.ToString().Equals("recibir"))
        {
            foreach (GridViewRow gv in GV_inventario.Rows)
            {
                         
                if (e.CommandArgument.ToString().Equals(((Label)gv.FindControl("label_codigo")).Text))
                {
                         

                    lista.Codigo = Convert.ToInt32(e.CommandArgument.ToString());
                    lista.Nombre = ((Label)gv.FindControl("label_nombre")).Text;
                    lista.Descripcion = ((Label)gv.FindControl("label_descripcion")).Text;
                    lista.Stock = ((Label)gv.FindControl("label_stock")).Text;
                    lista.Cantidad = Convert.ToInt32(((Label)gv.FindControl("label_cantidad")).Text);
                    lista.Fecha_vencimiento = Convert.ToDateTime(((TextBox)gv.FindControl("txt_fecha")).Text);


                    ((Button)gv.FindControl("but_recibir")).Enabled = false;
                    ((Button)gv.FindControl("but_no_recibir")).Enabled = false;
                }
              }
            if (Session["inventario"] == null)
            {
                list_inv.Add(lista);
                Session["inventario"] = list_inv;

            }
            else
            {
                ((List<ListaInventario>)Session["inventario"]).Add(lista);

            }
        }
            if (e.CommandName.ToString().Equals("no_recibir"))
            {

                foreach (GridViewRow gv in GV_inventario.Rows)
                {
                    if (e.CommandArgument.ToString().Equals(((Label)gv.FindControl("label_codigo")).Text))
                    {

                        lista2.Codigo = Convert.ToInt32(e.CommandArgument.ToString());
                        lista2.Nombre = ((Label)gv.FindControl("label_nombre")).Text;
                        lista2.Descripcion = ((Label)gv.FindControl("label_descripcion")).Text;
                        lista2.Stock = ((Label)gv.FindControl("label_stock")).Text;
                        lista2.Cantidad = Convert.ToInt32(((Label)gv.FindControl("label_cantidad")).Text);
                        lista2.Fecha_vencimiento = Convert.ToDateTime(((TextBox)gv.FindControl("txt_fecha")).Text);

                        
                        ((Button)gv.FindControl("but_recibir")).Enabled = false;
                        ((Button)gv.FindControl("but_no_recibir")).Enabled = false;
                    }
                }
                if (Session["devolucion"] == null)
                {
                    list_devo.Add(lista2);
                    Session["devolucion"] = list_devo;

                }
                else
                {
                    ((List<ListaDevolucion>)Session["devolucion"]).Add(lista2);

                }
               

            }
        
    }

    protected void but_guardar_cambio_Click(object sender, EventArgs e)
    {
        Boolean validacion = true;
        foreach (GridViewRow gv in GV_inventario.Rows)
        {

            if (((Button)gv.FindControl("but_recibir")).Enabled == true)
            {
                validacion = false;
            }
               
            
        }
        if (validacion == false)
        {
            label_error_recibir.Text = "Lo siento debe Terminar de Recibir o devolver los Medicamentos";
            label_error_recibir.CssClass = "alert alert-warning";
            return;
        }
        if (Session["inventario"] != null)
        {
            inventario.Session = Session.SessionID;
            List<ListaInventario> lista_inventario = (List<ListaInventario>)Session["inventario"];
            inventario.Medicamentos = JsonConvert.SerializeObject(lista_inventario);
            inventario.Sede = Convert.ToInt32(Session["sede"]);
            new DAOLaboratorista().insertar_Inventario(inventario);
        }
        if (Session["devolucion"] != null)
        {
            devolucion.Session1 = Session.SessionID;
            devolucion.Sede = Convert.ToInt32(Session["sede"]);
            List<ListaDevolucion> lista_devolucion = (List<ListaDevolucion>)Session["devolucion"];
            devolucion.Medicamentos1 = JsonConvert.SerializeObject(lista_devolucion);
            new DAOLaboratorista().insertar_Devolucion(devolucion);

        }

        new DAOLaboratorista().atenderPedido(Convert.ToInt32(Session["pedido"].ToString()));

        Session["inventario"] = null;
        Session["devolucion"] = null;
        Response.Redirect("~/View/Laboratorista/indexLaboratorista.aspx");

    }
}