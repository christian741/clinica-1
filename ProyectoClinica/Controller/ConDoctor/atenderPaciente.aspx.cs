using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_Doctor_Default : System.Web.UI.Page
{
    private DataTable dt;
    private ListaMedicamentos med = new ListaMedicamentos();
    private List<ListaMedicamentos> datos2;
    private List<ListaMedicamentos> datos;


    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["paciente"]== null || Session["atencion"] == null)
        {
            Response.Redirect("~/View/Doctor/citasHoy.aspx.cs");

        }
        if (IsPostBack == true)
        {
            Session["datos"] = (DataTable)Session["datos"];
            Session["lista"] = (List<ListaMedicamentos>)Session["lista"];
          /*  DataTable datos2 = new DAOCita().traer_remision_hoy(Convert.ToInt32(Session["usuario"].ToString()), Convert.ToInt32(Session["paciente"].ToString()));

            if (datos2.Rows.Count > 1)
            {
                label_dias_Remitido.Visible = false;
                txt_dias_remitido.Visible = false;
                label_remision.Visible = false;
                DDL_Especializacion.Visible = false;
                but_generarIncapacidad.Visible = false;
                label_Incaacidad.Visible = true;
                label_Incaacidad.Text = "Ya Se genero Una Remision para el paciente";
                label_Incaacidad.CssClass = "alert alert-info";
                return;
            }*/
            DataTable datos = new DAOCita().traer_Incapacidad_hoy(Convert.ToInt32(Session["usuario"].ToString()), Convert.ToInt32(Session["paciente"].ToString()));

            if (datos.Rows.Count > 1)
            {

                label_dias_inca.Visible = false;
                text_razon_incapa.Visible = false;
                text__dias_incapacidad.Visible = false;
                label_razon.Visible = false;
                but_generarIncapacidad.Visible = false;
                label_Incaacidad.Visible = true;
                label_Incaacidad.Text = "Ya Se genero Una Incapacidad para el paciente";
                label_Incaacidad.CssClass = "alert alert-info";
                return;
            }
        }
        else
        {
            /*
            DataTable datos2 = new DAOCita().traer_remision_hoy(Convert.ToInt32(Session["usuario"].ToString()), Convert.ToInt32(Session["paciente"].ToString()));

            if (datos2.Rows.Count > 1)
            {
                label_dias_Remitido.Visible = false;
                txt_dias_remitido.Visible = false;
                label_remision.Visible = false;
                DDL_Especializacion.Visible = false;
                but_generarIncapacidad.Visible = false;
                label_Incaacidad.Visible = true;
                label_Incaacidad.Text = "Ya Se genero Una Remision para el paciente";
                label_Incaacidad.CssClass = "alert alert-info";
                return;
            }*/
            DataTable datos = new DAOCita().traer_Incapacidad_hoy(Convert.ToInt32(Session["usuario"].ToString()), Convert.ToInt32(Session["paciente"].ToString()));
            if (datos.Rows.Count > 1)
            {
                label_dias_inca.Visible = false;
                text_razon_incapa.Visible = false;
                text__dias_incapacidad.Visible = false;
                label_razon.Visible = false;
                but_generarIncapacidad.Visible = false;
                label_Incaacidad.Visible = true;
                label_Incaacidad.Text = "Ya Se genero Una Incapacidad para el paciente";
                label_Incaacidad.CssClass = "alert alert-info";
                return;
            }
            but_salvar_med.Visible = false;
            Session["datos"] = null;
            Session["lista"] = null;
        }
        

    }



   



    protected void Button_añadir_Click(object sender, EventArgs e)
    {
        
        
        if (Session["datos"] != null && Session["lista"]!=null)
        {
            
            dt = (DataTable)Session["datos"];
            datos = (List<ListaMedicamentos>)Session["lista"];
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
                foreach (ListaMedicamentos med1 in datos)
                {
                   
                    if (med1.Codigo == med.Codigo )
                    {
                        aceptar = true;

                    }
                   
                   


                }
            }catch(Exception ex)
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
                row["Cantidad"] = med.Cantidad;
                row["Modo de Uso"] = med.Descripcion;
                row["Quitar"] = ((Button)GV_lista_medicamentos.FindControl("but_bloquear"));
                dt.Rows.Add(row); 
                dt.AcceptChanges();

            }

            GV_lista_medicamentos.DataSource = dt;
            GV_lista_medicamentos.DataBind();

        }
        else { 
            dt = new DataTable();
            datos = new List<ListaMedicamentos>();
            int codigo = Convert.ToInt32(((Label)FV_medicamento.FindControl("label_codigo")).Text);
            med.Codigo = codigo;
            DataTable medica = new DAOMedicamento().BuscarMedicamento(codigo);
            for (int i = 0; i < medica.Rows.Count; i++)
            {
                med.Descripcion = medica.Rows[i]["descripcion"].ToString();
                med.Nombre = medica.Rows[i]["nombre"].ToString();

            }

            dt.Columns.Add("Codigo", typeof(Int32));
            dt.Columns.Add("Nombre", typeof(string));
            dt.Columns.Add("Descripcion", typeof(string));
            dt.Columns.Add("Stock", typeof(string));
            dt.Columns.Add("Cantidad", typeof(int));
            dt.Columns.Add("Modo de Uso", typeof(string));
            dt.Columns.Add("Quitar", typeof(Button));
            datos.Add(med);
            foreach (ListaMedicamentos med1 in datos) {
                DataRow row = dt.NewRow();
                row["codigo"] = med1.Codigo;
                row["nombre"] = med1.Nombre;
                row["Descripcion"] = med1.Descripcion;
                row["Stock"] = med1.Stock;
                row["Cantidad"] = med1.Cantidad;
                row["Modo de Uso"] = med1.Descripcion;
                row["Quitar"] = ((Button)GV_lista_medicamentos.FindControl("but_bloquear")) ;
                dt.Rows.Add(row);
                dt.AcceptChanges();

            }
            Session["datos"] = dt;
            Session["lista"] = datos;
            GV_lista_medicamentos.DataSource = dt;
            GV_lista_medicamentos.DataBind();

        }

        but_salvar_med.Visible = true;




    }




    protected void but_salvar_med_Click(object sender, EventArgs e)
    {
        Boolean validar = false;
        int cantidad;
        datos = (List<ListaMedicamentos>)Session["lista"];
        datos2 = new List<ListaMedicamentos>();
        foreach (GridViewRow gv in GV_lista_medicamentos.Rows)
        {
            ListaMedicamentos lis = new ListaMedicamentos();

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
             
            String text_uso = ((TextBox)gv.FindControl("text_uso")).Text;
            
            if (text_uso == null)
            {
                ((Label)gv.FindControl("label_error_uso")).Text = "Rellene este campo";
                ((Label)gv.FindControl("label_error_uso")).Visible = true; ;
                ((Label)gv.FindControl("label_error_uso")).CssClass = "alert alert-danger";

                validar = true;
            }
            if (validar ==false)
            {
                 lis.Codigo=Convert.ToInt32(((Label)gv.FindControl("label_codigo")).Text);

                lis.Descripcion=((Label)gv.FindControl("label_descripcion")).Text;
                lis.Nombre= ((Label)gv.FindControl("Label2")).Text;
                lis.Stock= ((Label)gv.FindControl("label_envase")).Text;
                lis.Cantidad = Convert.ToInt32(((TextBox)gv.FindControl("text_cantidad")).Text);
                lis.ModeoUso = ((TextBox)gv.FindControl("text_uso")).Text;

                datos2.Add(lis);
              



                ((TextBox)gv.FindControl("text_cantidad")).Enabled = false;
                ((TextBox)gv.FindControl("text_uso")).Enabled = false;
                ((Button)gv.FindControl("but_quitar")).Enabled = false;
                ((Button)FV_medicamento.FindControl("Button_añadir")).Enabled = false;
                but_salvar_med.Visible = false;
                but_relizarCambios.Visible = true;
            }
        }
        Session["lista2"] = datos2;

        GuardarCita.Visible = true;
    }



    protected void GuardarCita_Click(object sender, EventArgs e)
    {
        Boolean validacion=true;
        Boolean vacios = true;
        if (but_salvar_med.Visible==true && Session["lista"]!=null)
        {
            label_error_guardar.Visible = true;
            label_error_guardar.Text = "Debe Guardar primero Los medicamentos";
            label_error_guardar.CssClass = "alert alert-warning";
            return;
        }
        HistoricoCita historia = new HistoricoCita();
        if (Session["lista2"] == null)
        {
            List<ListaMedicamentos> lista= null;
            historia.Medicamentos = "";
            vacios = false;

        }
        else
        {
            List<ListaMedicamentos> lista = (List<ListaMedicamentos>)Session["lista2"];
            historia.Medicamentos = JsonConvert.SerializeObject(lista);

        }

        if (text_observaciones.Text.Equals(""))
        {
            validacion = false;
            label_error_Observaciones.Visible = true;
            label_error_Observaciones.Text = "Rellene este campo";
            label_error_Observaciones.CssClass = "alert alert-danger";
        }
        else
        {
            historia.Descripcion1 = text_observaciones.Text;
        }
        if (text_altura.Text.Equals(""))
        {
            validacion = false;
            Label_error_altura.Visible = true;
            Label_error_altura.Text = "Rellene este campo";
            Label_error_altura.CssClass = "alert alert-danger";
        }
        else
        {
            historia.Altura = Convert.ToDouble(text_altura.Text);
        }
        if (text_peso.Text.Equals(""))
        {
            validacion = false;
            Label_error_peso.Visible = true;
            Label_error_peso.Text = "Rellene este campo";
            Label_error_peso.CssClass = "alert alert-danger";
        }
        else
        {
            historia.Peso = Convert.ToDouble(text_peso.Text);
        }
       
        historia.Id_cita_reg = Convert.ToInt32(Session["atencion"].ToString());


        if (Session["incapacidad"]==null)
        {
            Session["incapacidad"] = 0;
        }
        else
        {
            historia.Id_incapacidad = Convert.ToInt32(Session["incapacidad"].ToString());

        }
        if (text_fre_car.Text.Equals(""))
        {
            validacion = false;
            lab_error_fre.Visible = true;
            lab_error_fre.Text = "Rellene este campo";
            lab_error_fre.CssClass = "alert alert-danger";
        }
        else
        {
            historia.Cardiaca = Convert.ToInt16(text_fre_car.Text);
        }
        if (text_fre_res.Text.Equals(""))
        {
            validacion = false;
            label_error_fre_res.Visible = true;
            label_error_fre_res.Text = "Rellene este campo";
            label_error_fre_res.CssClass = "alert alert-danger";
        }
        else
        {
            historia.Respiratoria = Convert.ToInt16(text_fre_res.Text);
        }

        historia.Session = Session.SessionID;
        if (validacion == false)
        {
            return;
        }
        if (vacios == false)
        {
            new DAOCita().insertar_Atencion_Vacia(historia);
            Response.Redirect("~/View/Doctor/citasHoy.aspx");
        }
        new DAOCita().actualizar_citaRegistrada(historia.Id_cita_reg,historia.Session);
        new DAOCita().insertar_Atencion(historia);
        Session["incapacidad"] = null;
        Session["atencion"] = null;
        Session["lista"] = null;
        Session["lista2"] = null;
        Session["datos"] = null;
        Session["paciente"] = null;
        Response.Redirect("~/View/Doctor/citasHoy.aspx");


        Response.Redirect("~/View/Doctor/citasHoy.aspx");

    }
     




    protected void but_cam_med_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow gv in GV_lista_medicamentos.Rows)
        {
            ((TextBox)gv.FindControl("text_cantidad")).Enabled = true;
            ((TextBox)gv.FindControl("text_uso")).Enabled = true;
            ((Button)gv.FindControl("but_quitar")).Enabled = true;
            
        }
        Session["lista2"] = null;
        ((Button)FV_medicamento.FindControl("Button_añadir")).Enabled = true;
        GuardarCita.Visible = false;
        but_relizarCambios.Visible = false;
        but_salvar_med.Visible = true;
    }

    

    protected void GV_lista_medicamentos_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("quitar"))
        {
            Int32 dato = Convert.ToInt32(e.CommandArgument.ToString());

            int acumulador=0;
            dt = (DataTable)Session["datos"];
            datos = (List<ListaMedicamentos>)Session["lista"];
            try
            {
                foreach (ListaMedicamentos med1 in datos)
                {

                    if (med1.Codigo == dato)
                    {

                        dt.Rows.RemoveAt(GV_lista_medicamentos.Rows[acumulador].RowIndex);
                        datos.Remove(med1);
                    }
                    acumulador++;



                }
            }catch(Exception ex)
            {

            }
            GV_lista_medicamentos.DataSource = dt;
            GV_lista_medicamentos.DataBind();

        }
    }

    protected void GV_lista_medicamentos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GV_lista_medicamentos.PageIndex = e.NewPageIndex;
        GV_lista_medicamentos.DataBind();
    }

    protected void but_generarIncapacidad_Click(object sender, EventArgs e)
    {
        
        Boolean validacion = true;
        Incapacidad incapa = new Incapacidad();
        incapa.Id_doctor = Convert.ToInt32(Session["usuario"].ToString());
        incapa.Id_paciente= Convert.ToInt32(Session["paciente"].ToString());
        
        incapa.Razon = text_razon_incapa.Text;
        if (text_razon_incapa.Text.Equals(""))
        {
            validacion = false;
            label_error_razon_in.Visible = true;
            label_error_razon_in.Text = "Rellene este Campo";
            label_error_razon_in.CssClass = "alert alert-danger";
        }
        if (text__dias_incapacidad.Text.Equals(""))
        {
            validacion = false;
            label_error_dias_in.Visible = true;
            label_error_dias_in.Text = "Rellene este Campo";
            label_error_dias_in.CssClass = "alert alert-danger";
        }
        else
        {
            if (Convert.ToInt16(text__dias_incapacidad.Text)<=0 || Convert.ToInt16(text__dias_incapacidad.Text)>1200)
            {
                validacion = false;
                label_error_dias_in.Visible = true;
                label_error_dias_in.Text = "No puede Generar Una incapacidad mayor a 4 meses";
                label_error_dias_in.CssClass = "alert alert-danger";
            }
            incapa.Dias = Convert.ToInt16(text__dias_incapacidad.Text);

        }
        incapa.Session1 = Session.SessionID.ToString();
        if (validacion == false)
        {
            return;
        }
        new DAOCita().insertar_Incapacidad(incapa);
        DataTable datos = new DAOCita().traer_Incapacidad_hoy(Convert.ToInt32(Session["usuario"].ToString()), Convert.ToInt32(Session["paciente"].ToString()));

        if (datos.Rows.Count > 0)
        {
            if (datos.Rows.Count > 1)
            {
                label_dias_inca.Visible = false;
                text_razon_incapa.Visible = false;
                text__dias_incapacidad.Visible = false;
                label_razon.Visible = false;
                but_generarIncapacidad.Visible = false;
                label_Incaacidad.Visible = true;
                label_Incaacidad.Text = "Ya Se genero Una Incapacidad para el paciente";
                label_Incaacidad.CssClass = "alert alert-info";
                return;
            }
                Session["incapacidad"] = Convert.ToInt32(datos.Rows[0]["id_incapacidad"].ToString());
            Response.Write("<script>window.open('ReporteIncapacidad.aspx' ,'Reporte','height=100%', 'width=100%')</script>");
            label_dias_inca.Visible = false;
            text_razon_incapa.Visible = false;
            text__dias_incapacidad.Visible = false;
            label_razon.Visible = false;
            but_generarIncapacidad.Visible = false;
            label_Incaacidad.Visible = true;
            label_Incaacidad.Text = "Ya Se genero Una Incapacidad para el paciente";
            label_Incaacidad.CssClass = "alert alert-info";


        }
       
                   

   }

    protected void Button_remision_Click(object sender, EventArgs e)
    {
        Boolean validacion = true;
        Remision remitir = new Remision();
        
        if (txt_dias_remitido.Text.Equals(""))
        {
            validacion = false;
            label_error_dias_re.Visible = true;
            label_error_dias_re.Text = "LLene este campo";
            label_error_dias_re.CssClass = "alert alert-warning";

        }
        else
        {
           if(Convert.ToInt32(txt_dias_remitido.Text)<=0 || Convert.ToInt32(txt_dias_remitido.Text) > 30)
            {
                validacion = false;
                label_error_dias_re.Visible = true;
                label_error_dias_re.Text = "Debe tener maximo 30 dias";
                label_error_dias_re.CssClass = "alert alert-warning";
            }
            remitir.Dias = Convert.ToInt32(txt_dias_remitido.Text);

        }
        remitir.Id_usuario = Convert.ToInt32(Session["paciente"].ToString());
        remitir.Session = Session.SessionID;
        if (DDL_Especializacion.SelectedValue.Equals("0"))
        {
            label_error_DDL.Visible = true;
            label_error_DDL.Text = "Seleccione una Especializacion";
            label_error_DDL.CssClass = "alert alert-warning";
            validacion = false;
        }
        else
        {
            remitir.Id_especializacion = Convert.ToInt32(DDL_Especializacion.SelectedValue);

        }
        if (validacion == false)
        {
            return;
        }
        new DAOCita().insertar_Remision(remitir);
        DDL_Especializacion.Visible = false;
        Remision.Visible = false;
        label_dias_Remitido.Visible = false;
        txt_dias_remitido.Visible = false;
        Button_remision.Visible = false;
        label_remision.Visible = true;
        label_remision.Text = "Ya a remitido al paciente a una cita medica";
        

    }
}