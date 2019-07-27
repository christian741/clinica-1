using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Devolucion
/// </summary>
public class Devolucion
{
    private Int32 id_devolucion;
    private String Medicamentos;
    private String Session;
    private Int32 sede;
    public Devolucion()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public int Id_devolucion { get => id_devolucion; set => id_devolucion = value; }
    public string Medicamentos1 { get => Medicamentos; set => Medicamentos = value; }
    public string Session1 { get => Session; set => Session = value; }
    public int Sede { get => sede; set => sede = value; }
}