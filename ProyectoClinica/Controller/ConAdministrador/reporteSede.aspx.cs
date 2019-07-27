using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_Administrador_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      
        try
        {
            infoSede reporte = ObtenerInforme();
            CRS_reportSede.ReportDocument.SetDataSource(reporte);
            CRV_sede.ReportSource = CRS_reportSede;
        }
        catch (Exception)
        {

            throw;
        }
    }

    protected infoSede ObtenerInforme()
    {
        DataRow fila;  //dr
        DataTable informacion = new DataTable(); //dt
        infoSede datos = new infoSede();

        informacion = datos.Tables["Sedes"];
        DAOSede sede = new DAOSede();

        DataTable intermedio = sede.ver_Sede();

        for (int i = 0; i < intermedio.Rows.Count; i++)
        {
            fila = informacion.NewRow();

            fila["Id"] = long.Parse(intermedio.Rows[i]["id_sede"].ToString());
            fila["Nombre"] = intermedio.Rows[i]["nombre"].ToString();
            fila["Descripcion"] = intermedio.Rows[i]["descripcion"].ToString();
            fila["Direccion"] = intermedio.Rows[i]["direccion"].ToString();
            fila["Encargado"] = intermedio.Rows[i]["encargado"].ToString();
            fila["Ciudad"] = intermedio.Rows[i]["ciudad"].ToString();
            fila["Foto"] = streamFile(intermedio.Rows[i]["foto"].ToString());

            informacion.Rows.Add(fila);
        }

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