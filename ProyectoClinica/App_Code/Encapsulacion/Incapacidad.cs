using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Incapacidad
/// </summary>
public class Incapacidad
{
    private Int32 id_incapacidad;
    private Int32 id_paciente;
    private Int32 id_doctor;
    private Int32 id_historial;
    private int dias;
    private String razon;
    private string Session;
    public Incapacidad()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public int Id_incapacidad { get => id_incapacidad; set => id_incapacidad = value; }
    public int Id_paciente { get => id_paciente; set => id_paciente = value; }
    public int Id_doctor { get => id_doctor; set => id_doctor = value; }
    public string Session1 { get => Session; set => Session = value; }
    public int Dias { get => dias; set => dias = value; }
    public string Razon { get => razon; set => razon = value; }
    public int Id_historial { get => id_historial; set => id_historial = value; }
}