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
            CRS_Especial.ReportDocument.SetDataSource(reporte);
            CRV_Especial.ReportSource = CRS_Especial;
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

        informacion = datos.Tables["Especializacion"];
        DAOEspecializacion esp = new DAOEspecializacion();

        DataTable intermedio = esp.ver_Especializacion();

        for (int i = 0; i < intermedio.Rows.Count; i++)
        {
            fila = informacion.NewRow();

            fila["Id"] = long.Parse(intermedio.Rows[i]["id_especializacion"].ToString());
            fila["Nombre"] = intermedio.Rows[i]["nombre"].ToString();
            fila["Descripcion"] = intermedio.Rows[i]["descripcion"].ToString();
           
                if (intermedio.Rows[i]["edad"].ToString().Equals("100"))
                {
                    fila["Edad"]  = "Todas las Edades";
                }
                if (intermedio.Rows[i]["edad"].ToString().Equals("3"))
                {
                     fila["Edad"] =  "Bebes";
                }
                if (intermedio.Rows[i]["edad"].ToString().Equals("17"))
                {
                    fila["Edad"] = "Menores de edad";
                }
                if (intermedio.Rows[i]["edad"].ToString().Equals("18"))
                {
                    fila["Edad"] =  "Mayores de Edad";
                }
     
                if (intermedio.Rows[i]["prioridad"].ToString().Equals("1"))
                {
                    fila["Prioridad"] = "Todos";
                }
                if (intermedio.Rows[i]["prioridad"].ToString().Equals("2"))
                {
                    fila["Prioridad"]= "Solo Doctores";
                }

            
            fila["Sexo"] = intermedio.Rows[i]["sexo"].ToString();
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