using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_Laboratorista_Default : System.Web.UI.Page
{
    private DataTable dt;
    private Pedido pedido = new Pedido();
    private Medicamento med = new Medicamento();
    private List<ListaPedido> datos2;
    private List<Medicamento> datos;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (IsPostBack == true)
        {
            Session["datos_pedido"] = (DataTable)Session["datos_pedido"];
            Session["lista_pedido"] = (List<Medicamento>)Session["lista_pedido"];
          
           
        }
        else
        {
           

            but_salvar_med.Visible = false;
            Session["datos_pedido"] = null;
            Session["lista_pedido"] = null;
        }

    }

    protected void but_añadir_Click(object sender, EventArgs e)
    {

        if (Session["datos_pedido"] != null && Session["lista_pedido"] != null)
        {

            dt = (DataTable)Session["datos_pedido"];
            datos = (List<Medicamento>)Session["lista_pedido"];
            int codigo = Convert.ToInt32(((Label)FV_medicamento.FindControl("label_codigo")).Text);
            med.Codigo = codigo;
            DataTable medica = new DAOMedicamento().BuscarMedicamento(codigo);
            for (int i = 0; i < medica.Rows.Count; i++)
            {
                med.Descripcion = medica.Rows[i]["descripcion"].ToString();
                med.Nombre = medica.Rows[i]["nombre"].ToString();
                med.Stock = medica.Rows[i]["stock"].ToString();

            }
            Boolean aceptar = false;

            try
            {
                foreach (Medicamento med1 in datos)
                {

                    if (med1.Codigo == med.Codigo)
                    {
                        aceptar = true;

                    }




                }
            }
            catch (Exception ex)
            {

            }
            if (aceptar == false)
            {
                datos.Add(med);
                DataRow row = dt.NewRow();
                row["codigo"] = med.Codigo;
                row["nombre"] = med.Nombre;
                row["Descripcion"] = med.Descripcion;
                row["Stock"] = med.Stock;
                row["Cantidad"] = 0;
                row["Quitar"] = ((Button)GV_lista_medicamentos_pedido.FindControl("but_bloquear"));
                dt.Rows.Add(row);
                dt.AcceptChanges();

            }

            GV_lista_medicamentos_pedido.DataSource = dt;
            GV_lista_medicamentos_pedido.DataBind();

        }
        else
        {
            dt = new DataTable();
            datos = new List<Medicamento>();
            int codigo = Convert.ToInt32(((Label)FV_medicamento.FindControl("label_codigo")).Text);
            med.Codigo = codigo;
            DataTable medica = new DAOMedicamento().BuscarMedicamento(codigo);
            for (int i = 0; i < medica.Rows.Count; i++)
            {
                med.Descripcion = medica.Rows[i]["descripcion"].ToString();
                med.Nombre = medica.Rows[i]["nombre"].ToString();
                med.Stock = medica.Rows[i]["stock"].ToString();

            }

            dt.Columns.Add("Codigo", typeof(Int32));
            dt.Columns.Add("Nombre", typeof(string));
            dt.Columns.Add("Descripcion", typeof(string));
            dt.Columns.Add("Stock", typeof(string));
            dt.Columns.Add("Cantidad", typeof(int));
            dt.Columns.Add("Quitar", typeof(Button));
            datos.Add(med);
            foreach (Medicamento med1 in datos)
            {
                DataRow row = dt.NewRow();
                row["codigo"] = med1.Codigo;
                row["nombre"] = med1.Nombre;
                row["Descripcion"] = med1.Descripcion;
                row["Stock"] = med1.Stock;
                row["Cantidad"] = 0;
                row["Quitar"] = ((Button)GV_lista_medicamentos_pedido.FindControl("but_bloquear"));
                dt.Rows.Add(row);
                dt.AcceptChanges();

            }
            Session["datos_pedido"] = dt;
            Session["lista_pedido"] = datos;
            GV_lista_medicamentos_pedido.DataSource = dt;
            GV_lista_medicamentos_pedido.DataBind();

        }

        but_salvar_med.Visible = true;



    }
    protected void but_salvar_med_Click(object sender, EventArgs e)
    {
        
        Boolean validar = false;
        int cantidad;
        datos = (List<Medicamento>)Session["lista"];
        datos2 = new List<ListaPedido>();
        foreach (GridViewRow gv in GV_lista_medicamentos_pedido.Rows)
        {
            ListaPedido lis = new ListaPedido();
            if (((TextBox)gv.FindControl("text_cantidad")).Text.Equals(""))
            {
                cantidad = 0;
                if (cantidad == 0)
                {
                    ((Label)gv.FindControl("label_error_cantidad")).Text = "Rellene este campo";
                    ((Label)gv.FindControl("label_error_cantidad")).Visible = true; ;
                    ((Label)gv.FindControl("label_error_cantidad")).CssClass = "alert alert-danger";
                    validar = true;

                }
            }

            String text_dias = ((TextBox)gv.FindControl("text_dias")).Text;

            if (text_dias == null)
            {
                ((Label)gv.FindControl("label_error_dias")).Text = "Rellene este campo";
                ((Label)gv.FindControl("label_error_dias")).Visible = true; ;
                ((Label)gv.FindControl("label_error_dias")).CssClass = "alert alert-danger";

                validar = true;
            }
            if (validar == false)
            {
                lis.Codigo = Convert.ToInt32(((Label)gv.FindControl("label_codigo")).Text);
                lis.Descripcion = ((Label)gv.FindControl("label_descripcion")).Text;
                lis.Nombre = ((Label)gv.FindControl("Label2")).Text;
                lis.Stock = ((Label)gv.FindControl("label_envase")).Text;
                lis.Cantidad = Convert.ToInt32(((TextBox)gv.FindControl("text_cantidad")).Text);

                datos2.Add(lis);

                ((Label)gv.FindControl("label_error_dias")).Visible = false; ;


                ((TextBox)gv.FindControl("text_cantidad")).Enabled = false;
                ((Button)gv.FindControl("but_quitar")).Enabled = false;
                but_añadir.Enabled = false;
                but_salvar_med.Visible = false;
                but_relizarCambios.Visible = true;
               
            }
        }
        Session["lista_pedido2"] = datos2;
        GuardarPedido.Visible = true;


    }
    protected void but_cam_med_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow gv in GV_lista_medicamentos_pedido.Rows)
        {
            ((TextBox)gv.FindControl("text_cantidad")).Enabled = true;
            ((TextBox)gv.FindControl("text_dias")).Enabled = true;
            ((Button)gv.FindControl("but_quitar")).Enabled = true;

        }
        Session["lista_pedido2"] = null;
        but_añadir.Enabled = true;
     
        but_relizarCambios.Visible = false;
        but_salvar_med.Visible = true;
    }
    protected void GV_lista_medicamentos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GV_lista_medicamentos_pedido.PageIndex = e.NewPageIndex;
        GV_lista_medicamentos_pedido.DataBind();
    }
    protected void GV_lista_medicamentos_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("quitar"))
        {
            Int32 dato = Convert.ToInt32(e.CommandArgument.ToString());

            int acumulador = 0;
            dt = (DataTable)Session["datos_pedido"];
            datos = (List<Medicamento>)Session["lista_pedido"];
            try
            {
                foreach (Medicamento med1 in datos)
                {

                    if (med1.Codigo == dato)
                    {

                        dt.Rows.RemoveAt(GV_lista_medicamentos_pedido.Rows[acumulador].RowIndex);
                        datos.Remove(med1);
                    }
                    acumulador++;



                }
            }
            catch (Exception ex)
            {

            }
            GV_lista_medicamentos_pedido.DataSource = dt;
            GV_lista_medicamentos_pedido.DataBind();

        }
    }
    protected void GuardarPedido_Click(object sender, EventArgs e)
    {
        Boolean validacion = true;
        if (but_salvar_med.Visible==true && Session["lista_pedido"]!=null)
        {
             return;
        }
            Pedido pedido1 = new Pedido();
        pedido1.Id_sede = Convert.ToInt32(Session["sede"].ToString());
        if (Session["lista_pedido2"] == null)
        {
            List<ListaPedido> lista = null;
            pedido1.Medicamentos = "";
            return;

        }
        else
        {
            List<ListaPedido> lista = (List<ListaPedido>)Session["lista_pedido2"];
        pedido1.Medicamentos = JsonConvert.SerializeObject(lista);                                                        

        }

        
        pedido1.Session = Session.SessionID;
        if (validacion == false)
        {
            return;
        }

        new DAOLaboratorista().insertar_Pedido(pedido1);
        Session["lista_pedido"] = null;
        Session["lista_pedido2"] = null;
        Session["datos_pedido"] = null;
       

        Response.Redirect("~/View/Laboratorista/anadirMedicamentos.aspx");

    }


    protected void DDL_Medicamento_SelectedIndexChanged(object sender, EventArgs e)
    {
        new DAOMedicamento().BuscarMedicamento(Convert.ToInt32(DDL_Medicamento.SelectedValue));
    }
}