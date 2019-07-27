using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_Farmaceuta_Default : System.Web.UI.Page
{
    private int cantidad_solicitada;
    private int id_inventario;
    private int id_inventario2;
   private ListaInventario objeto_inevntario3 = new ListaInventario();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["entregar_id"] == null ||  Session["entrega"] == null)
        {
            Response.Redirect("~/View/Farmaceuta/indexFarmaceuta.aspx");
        }
    }

    protected void Gv_entrega_final_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("entrega"))
        {
            foreach (GridViewRow gv in Gv_entrega_final.Rows)
            {
                if (((Label)gv.FindControl("label_codigo")).Text.Equals(e.CommandArgument.ToString()))
                {
                    cantidad_solicitada = Convert.ToInt32(((Label)gv.FindControl("label_cantidad")).Text);
                    ((Button)gv.FindControl("but_entregar")).Enabled = false;
                    break;
                }
            }
            Inventario objeto_no_inventario = new Inventario();
            DataTable inventario = new DAOFarmaceuta().traer_sede_inventario(Convert.ToInt32(Session["sede"].ToString()));
            //
            ListaInventario objeto_inevntario = new ListaInventario();
            //

            
            List<ListaInventario> lista_inventario = new List<ListaInventario>();

            for(int i = 0; i < inventario.Rows.Count; i++)
            {
                if (inventario.Rows[i]["Codigo"].ToString().Equals(e.CommandArgument.ToString())){
                    id_inventario = Convert.ToInt32(inventario.Rows[i]["id_inventario"].ToString());
                    objeto_inevntario.Codigo = Convert.ToInt32(inventario.Rows[i]["Codigo"].ToString());
                    objeto_inevntario.Nombre = inventario.Rows[i]["Nombre"].ToString();
                    objeto_inevntario.Descripcion =inventario.Rows[i]["Descripcion"].ToString();
                    objeto_inevntario.Stock = inventario.Rows[i]["Stock"].ToString();
                    objeto_inevntario.Cantidad = Convert.ToInt32(inventario.Rows[i]["Cantidad"].ToString());
                    objeto_inevntario.Fecha_vencimiento = Convert.ToDateTime(inventario.Rows[i]["Fecha_vencimiento"].ToString());

                    break;
                }

                //Validar si no esta el medicamento en la sede
                
            }
            
            if (cantidad_solicitada< objeto_inevntario.Cantidad) {
                int total_cantidad = objeto_inevntario.Cantidad - cantidad_solicitada;

               
                for (int i = 0; i < inventario.Rows.Count; i++)
                {
                    ListaInventario objeto2_inevntario = new ListaInventario();
                    if (id_inventario==Convert.ToInt32(inventario.Rows[i]["id_inventario"].ToString()))
                    {
                        if (inventario.Rows[i]["Codigo"].ToString().Equals(e.CommandArgument.ToString()))
                        {
                            objeto2_inevntario.Codigo = Convert.ToInt32(inventario.Rows[i]["Codigo"].ToString());
                            objeto2_inevntario.Nombre = inventario.Rows[i]["Nombre"].ToString();
                            objeto2_inevntario.Descripcion = inventario.Rows[i]["Descripcion"].ToString();
                            objeto2_inevntario.Stock = inventario.Rows[i]["Stock"].ToString();
                            objeto2_inevntario.Cantidad = total_cantidad;
                            objeto2_inevntario.Fecha_vencimiento = Convert.ToDateTime(inventario.Rows[i]["Fecha_vencimiento"].ToString());

                            lista_inventario.Add(objeto2_inevntario);
                        }
                        else
                        {
                            objeto2_inevntario.Codigo = Convert.ToInt32(inventario.Rows[i]["Codigo"].ToString());
                            objeto2_inevntario.Nombre = inventario.Rows[i]["Nombre"].ToString();
                            objeto2_inevntario.Descripcion = inventario.Rows[i]["Descripcion"].ToString();
                            objeto2_inevntario.Stock = inventario.Rows[i]["Stock"].ToString();
                            objeto2_inevntario.Cantidad = Convert.ToInt32(inventario.Rows[i]["Cantidad"].ToString());
                            objeto2_inevntario.Fecha_vencimiento = Convert.ToDateTime(inventario.Rows[i]["Fecha_vencimiento"].ToString());

                            lista_inventario.Add(objeto2_inevntario);

                        }
                    }
                }
                objeto_no_inventario.Codigo = id_inventario;
                objeto_no_inventario.Session = Session.SessionID;
                objeto_no_inventario.Medicamentos = JsonConvert.SerializeObject(lista_inventario);

            }
            else
            {
                if (cantidad_solicitada==objeto_inevntario.Cantidad)
                {
                    for (int i = 0; i < inventario.Rows.Count; i++)
                    {
                        ListaInventario objeto2_inevntario = new ListaInventario();

                        if (id_inventario == Convert.ToInt32(inventario.Rows[i]["id_inventario"].ToString()))
                        {
                            if (!inventario.Rows[i]["Codigo"].ToString().Equals(e.CommandArgument.ToString()))
                            {
                                objeto2_inevntario.Codigo = Convert.ToInt32(inventario.Rows[i]["Codigo"].ToString());
                                objeto2_inevntario.Nombre = inventario.Rows[i]["Nombre"].ToString();
                                objeto2_inevntario.Descripcion = inventario.Rows[i]["Descripcion"].ToString();
                                objeto2_inevntario.Stock = inventario.Rows[i]["Stock"].ToString();
                                objeto2_inevntario.Cantidad = Convert.ToInt32(inventario.Rows[i]["Cantidad"].ToString());
                                objeto2_inevntario.Fecha_vencimiento = Convert.ToDateTime(inventario.Rows[i]["Fecha_vencimiento"].ToString());

                                lista_inventario.Add(objeto2_inevntario);

                            }
                           
                        }
                    }
                    objeto_no_inventario.Codigo = id_inventario;
                    objeto_no_inventario.Session = Session.SessionID;

                    objeto_no_inventario.Medicamentos = JsonConvert.SerializeObject(lista_inventario);

                }
                else
                {
                    if (cantidad_solicitada > objeto_inevntario.Cantidad)
                   {
                   Int64 total_inevntario = funcionCantidad(Convert.ToInt32(e.CommandArgument.ToString()));

                       if(total_inevntario>cantidad_solicitada)
                       //if (acumulador > 1)
                       {

                                   Int32 resto2 = cantidad_solicitada-objeto_inevntario.Cantidad;

                                   for (int i = 0; i < inventario.Rows.Count; i++)
                                   {
                                ListaInventario objeto2_inevntario = new ListaInventario();

                                if (id_inventario == Convert.ToInt32(inventario.Rows[i]["id_inventario"].ToString()))
                                       {
                                           if (Convert.ToInt32(inventario.Rows[i]["Codigo"].ToString())!=Convert.ToInt32(e.CommandArgument.ToString()))
                                           {
                                               objeto2_inevntario.Codigo = Convert.ToInt32(inventario.Rows[i]["Codigo"].ToString());
                                               objeto2_inevntario.Nombre = inventario.Rows[i]["Nombre"].ToString();
                                               objeto2_inevntario.Descripcion = inventario.Rows[i]["Descripcion"].ToString();
                                               objeto2_inevntario.Stock = inventario.Rows[i]["Stock"].ToString();
                                               objeto2_inevntario.Cantidad = Convert.ToInt32(inventario.Rows[i]["Cantidad"].ToString());
                                               objeto2_inevntario.Fecha_vencimiento = Convert.ToDateTime(inventario.Rows[i]["Fecha_vencimiento"].ToString());

                                               lista_inventario.Add(objeto2_inevntario);

                                            }


                                       }
                                   }
                                   objeto_no_inventario.Codigo = id_inventario;
                                   objeto_no_inventario.Medicamentos = JsonConvert.SerializeObject(lista_inventario);
                                   objeto_no_inventario.Session = Session.SessionID;

                                   //UPDATE;
                                   new DAOFarmaceuta().actualizar_Inventario(objeto_no_inventario);

                                   DataTable inventario2 = new DAOFarmaceuta().traer_sede_inventario(Convert.ToInt32(Session["sede"].ToString()));

                                   for (int i = 0; i < inventario2.Rows.Count; i++)
                                           {
                                ListaInventario objeto_inevntario3 = new ListaInventario();

                                         if (inventario2.Rows[i]["Codigo"].ToString().Equals(e.CommandArgument.ToString()))
                                               {
                                                   id_inventario2 = Convert.ToInt32(inventario2.Rows[i]["id_inventario"].ToString());
                                                   objeto_inevntario3.Codigo = Convert.ToInt32(inventario2.Rows[i]["Codigo"].ToString());
                                                   objeto_inevntario3.Nombre = inventario2.Rows[i]["Nombre"].ToString();
                                                   objeto_inevntario3.Descripcion = inventario2.Rows[i]["Descripcion"].ToString();
                                                   objeto_inevntario3.Stock = inventario2.Rows[i]["Stock"].ToString();
                                                   objeto_inevntario3.Cantidad = Convert.ToInt32(inventario2.Rows[i]["Cantidad"].ToString());
                                                   objeto_inevntario3.Fecha_vencimiento = Convert.ToDateTime(inventario2.Rows[i]["Fecha_vencimiento"].ToString());

                                           break;
                                       }
                                   }

                                       Int32 total_cantidad2 = objeto_inevntario3.Cantidad - resto2;
                                       lista_inventario = new List<ListaInventario>();
                                       for (int i = 0; i < inventario2.Rows.Count; i++)  {
                                           if (id_inventario2 == Convert.ToInt32(inventario2.Rows[i]["id_inventario"].ToString()))
                                           {
                                    ListaInventario objeto4_inevntario = new ListaInventario();

                                    if (inventario2.Rows[i]["Codigo"].ToString().Equals(e.CommandArgument.ToString()))
                                               {
                                                   objeto4_inevntario.Codigo = Convert.ToInt32(inventario2.Rows[i]["Codigo"].ToString());
                                                   objeto4_inevntario.Nombre = inventario2.Rows[i]["Nombre"].ToString();
                                                   objeto4_inevntario.Descripcion = inventario2.Rows[i]["Descripcion"].ToString();
                                                   objeto4_inevntario.Stock = inventario2.Rows[i]["Stock"].ToString();
                                                   objeto4_inevntario.Cantidad = total_cantidad2;
                                                   objeto4_inevntario.Fecha_vencimiento = Convert.ToDateTime(inventario2.Rows[i]["Fecha_vencimiento"].ToString());

                                                   lista_inventario.Add(objeto4_inevntario);
                                               }
                                               else
                                               {
                                                   objeto4_inevntario.Codigo = Convert.ToInt32(inventario2.Rows[i]["Codigo"].ToString());
                                                   objeto4_inevntario.Nombre = inventario2.Rows[i]["Nombre"].ToString();
                                                   objeto4_inevntario.Descripcion = inventario2.Rows[i]["Descripcion"].ToString();
                                                   objeto4_inevntario.Stock = inventario2.Rows[i]["Stock"].ToString();
                                                   objeto4_inevntario.Cantidad = Convert.ToInt32(inventario2.Rows[i]["Cantidad"].ToString());
                                                   objeto4_inevntario.Fecha_vencimiento = Convert.ToDateTime(inventario2.Rows[i]["Fecha_vencimiento"].ToString());

                                                   lista_inventario.Add(objeto4_inevntario);

                                               }
                                                   }
                                               }
                                       Inventario objeto_no_inventario2 = new Inventario();

                                       objeto_no_inventario2.Codigo = id_inventario2;
                                        objeto_no_inventario2.Session = Session.SessionID;

                                        objeto_no_inventario2.Medicamentos = JsonConvert.SerializeObject(lista_inventario);
                                       new DAOFarmaceuta().actualizar_Inventario(objeto_no_inventario);
                                       return;
                          }
                        else
                        {
                            objeto_no_inventario.Codigo = id_inventario;
                            objeto_no_inventario.Session = Session.SessionID;

                            objeto_no_inventario.Medicamentos = JsonConvert.SerializeObject(lista_inventario);
                            return;
                         }
                




                    }
                }
            }


            objeto_no_inventario.Codigo = id_inventario;
            objeto_no_inventario.Session = Session.SessionID;

            objeto_no_inventario.Medicamentos = JsonConvert.SerializeObject(lista_inventario);
            new DAOFarmaceuta().actualizar_Inventario(objeto_no_inventario);

        }


    }

    
    private Int64 funcionCantidad(int _codigo)
    {
        int Cantidad_inventario=0;
        int Cantidad = 0;
        DataTable inventario = new DAOFarmaceuta().traer_sede_inventario(Convert.ToInt32(Session["sede"].ToString()));

        for (int i = 0; i < inventario.Rows.Count; i++)
        {
            if (inventario.Rows[i]["Codigo"].ToString().Equals(Convert.ToString(_codigo)))
            {
                
                Cantidad= Convert.ToInt32(inventario.Rows[i]["Cantidad"].ToString());
                Cantidad_inventario = Cantidad + Cantidad_inventario;


            }
        }
        return Cantidad_inventario;
    }
    
    protected void but_terminar_Click(object sender, EventArgs e)
    {
        Boolean validacion = true;
        foreach (GridViewRow gv in Gv_entrega_final.Rows)
        {
            if (((Button)gv.FindControl("but_entregar")).Enabled==true)
            {
                validacion = false;
            }
        }
        if (validacion == false)
        {
            //mensaje de rror
            return;
        }
       /* if ()
        {

        }*/
        new DAOFarmaceuta().actualizar_Citas_Historial(Convert.ToInt32(Session["entrega"].ToString()), Convert.ToInt32(Session["entregar_id"].ToString()), Convert.ToInt32(Session["sede"].ToString()));
        Session["entregar_id"] = null;
        Session["entrega"] = null;

        Response.Redirect("~/View/Farmaceuta/entregaMedicamentos.aspx");

    }
}