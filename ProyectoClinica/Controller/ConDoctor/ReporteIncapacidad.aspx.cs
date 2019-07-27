using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_Doctor_ReporteIncapacidad : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            infoDoctor reporte = ObtenerInforme();
            CRS_Incapacidad.ReportDocument.SetDataSource(reporte);
            crv_incapacidad.ReportSource = CRS_Incapacidad;
        }
        catch (Exception)
        {

            throw;
        }
    }

    protected infoDoctor ObtenerInforme()
    {
        DataRow fila;  //dr
        DataTable informacion = new DataTable(); //dt
        infoDoctor datos = new infoDoctor();

        informacion = datos.Tables["incapacidad"];
        DataTable datos2 = new DAODoctor().ver_Incapacidad(Convert.ToInt32(Session["usuario"].ToString()), Convert.ToInt32(Session["paciente"].ToString()));

      

       
            fila = informacion.NewRow();

            fila["Id"] = long.Parse(datos2.Rows[0]["id_incapacidad"].ToString());
            fila["razon"] = datos2.Rows[0]["razon"].ToString();
            fila["dias"] = datos2.Rows[0]["dias"].ToString();

            fila["fecha_fin"] =Convert.ToString( DateTime.Now.AddDays(Convert.ToInt32(datos2.Rows[0]["dias"].ToString())));
            DataTable doctor = new DAOUsuario().buscar_Usuario(Convert.ToInt32(Session["usuario"].ToString()));
            fila["cedula_doctor"] = doctor.Rows[0]["cedula"].ToString();
            fila["id_doctor"] = doctor.Rows[0]["nombre"].ToString()+" "+ doctor.Rows[0]["apellido"].ToString();
            DataTable paciente = new DAOUsuario().buscar_Usuario(Convert.ToInt32(Session["paciente"].ToString()));
            fila["id_paciente"] = paciente.Rows[0]["nombre"].ToString() + " " + doctor.Rows[0]["apellido"].ToString();
            fila["cedula_paciente"] = paciente.Rows[0]["cedula"].ToString();
            fila["especializacion"] = paciente.Rows[0]["cedula"].ToString();

        informacion.Rows.Add(fila);
        

        return datos;
    }


    private byte[] streamFile(string filename)
    {
        FileStream fs;

        fs = new FileStream(Server.MapPath(filename), FileMode.Open, FileAccess.Read);


        // Create a byte array of file stream length
        byte[] ImageData = new byte[fs.Length];

        //Read block of bytes from stream into the byte array
        fs.Read(ImageData, 0, System.Convert.ToInt32(fs.Length));

        //Close the File Stream
        fs.Close();
        return ImageData; //return the byte data
    }
}