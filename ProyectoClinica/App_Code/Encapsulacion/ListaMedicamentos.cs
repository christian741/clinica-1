using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de ListaMedicamentos
/// </summary>
public class ListaMedicamentos
{
    private Int32 codigo;
    private String nombre;
    private String descripcion;
    private String stock;
    private int cantidad;
    private String modeoUso;
    
    public ListaMedicamentos()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public int Codigo { get => codigo; set => codigo = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Descripcion { get => descripcion; set => descripcion = value; }
    public string Stock { get => stock; set => stock = value; }
    public int Cantidad { get => cantidad; set => cantidad = value; }
    public string ModeoUso { get => modeoUso; set => modeoUso = value; }
}