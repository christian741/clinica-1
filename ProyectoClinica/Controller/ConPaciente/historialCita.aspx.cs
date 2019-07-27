using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_Paciente_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }



    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
      
        String doctor = ((Label)e.Item.FindControl("label_doctor")).Text;
        DataTable tabla = new DAODoctor().ver_Doctor();
        for (int i = 0; i < tabla.Rows.Count; i++)
        {
            if (doctor.Equals(tabla.Rows[i]["id_usuario"].ToString()))
            {
                Label lbl_sede = ((Label)e.Item.FindControl("label_doctor"));
                lbl_sede.Text = tabla.Rows[i]["nombre"].ToString()+" "+ tabla.Rows[i]["apellido"].ToString();
                break;
            }
        }

        String especializacion = ((Label)e.Item.FindControl("label_especializacion")).Text;
        DataTable tabla3 = new DAOEspecializacion().ver_Especializacion();
        for (int i = 0; i < tabla3.Rows.Count; i++)
        {
            if (especializacion.Equals(tabla3.Rows[i]["id_especializacion"].ToString()))
            {
                Label lbl_sede = ((Label)e.Item.FindControl("label_especializacion"));
                lbl_sede.Text = tabla3.Rows[i]["nombre"].ToString();
                break;
            }
        }


        String sede = ((Label)e.Item.FindControl("label_sede")).Text;

        DataTable tabla2 = new DAOSede().ver_Sede();
        for (int i = 0; i < tabla2.Rows.Count; i++)
        {
            if (sede.Equals(tabla2.Rows[i]["id_sede"].ToString()))
            {
                Label lbl_sede = ((Label)e.Item.FindControl("label_sede"));
                lbl_sede.Text = tabla2.Rows[i]["nombre"].ToString();
                break;
            }
        }

    }

    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName.ToString().Equals("ver"))
        {
            DataTable medicamentos = new DAOFarmaceuta().traerCitas_Medicamentos(Convert.ToInt32(Session["usuario"].ToString()), Convert.ToInt32(((Label)e.Item.FindControl("label_id")).Text));
            Gv_medicamentos.Visible = true;
            Gv_medicamentos.DataSource = medicamentos;
            Gv_medicamentos.DataBind();
        }
    }
}