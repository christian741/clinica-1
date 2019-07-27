using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Usuario
/// </summary>
public class Usuario
{
    private int id;
    private DateTime fecha_inicio;
    private String session;
    private String ip;
    private String mac;
         
    public Usuario()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public DateTime Fecha_inicio { get => fecha_inicio; set => fecha_inicio = value; }
    public int Id { get => id; set => id = value; }
    public string Session { get => session; set => session = value; }
    public string Ip { get => ip; set => ip = value; }
    public string Mac { get => mac; set => mac = value; }
}