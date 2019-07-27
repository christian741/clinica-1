using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Remision
/// </summary>
public class Remision
{
    private Int32 id_remision;
    private Int32 id_usuario;
    private Int32 id_especializacion;
    private int dias;
    private DateTime fecha_inicio;
    private DateTime fecha_fin;
    private String session;
     
    public Remision()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public int Id_remision { get => id_remision; set => id_remision = value; }
    public int Id_usuario { get => id_usuario; set => id_usuario = value; }
    public int Id_especializacion { get => id_especializacion; set => id_especializacion = value; }
    public int Dias { get => dias; set => dias = value; }
    public DateTime Fecha_inicio { get => fecha_inicio; set => fecha_inicio = value; }
    public DateTime Fecha_fin { get => fecha_fin; set => fecha_fin = value; }
    public string Session { get => session; set => session = value; }
}