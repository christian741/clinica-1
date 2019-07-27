using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Inventario
/// </summary>
public class Inventario
{
    private Int32 codigo;
    private String medicamentos;
    private String session;
    private Int32 sede;
    public Inventario()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public int Codigo { get => codigo; set => codigo = value; }
    public string Medicamentos { get => medicamentos; set => medicamentos = value; }
    public string Session { get => session; set => session = value; }
    public int Sede { get => sede; set => sede = value; }
}