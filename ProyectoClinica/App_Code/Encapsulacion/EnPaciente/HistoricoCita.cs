using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de HistoricoCita
/// </summary>
public class HistoricoCita
{
    private Int32 id_histroico_cita;
    private String Descripcion;
    private int respiratoria;
    private int cardiaca;
    private String session;
    private String medicamentos;
    private Int32 id_cita_reg;
    private Int32 id_incapacidad;
    private Double peso;
    private Double altura;


    public HistoricoCita()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public string Session { get => session; set => session = value; }
    public int Id_histroico_cita { get => id_histroico_cita; set => id_histroico_cita = value; }
    public string Descripcion1 { get => Descripcion; set => Descripcion = value; }
    public int Respiratoria { get => respiratoria; set => respiratoria = value; }
    public int Cardiaca { get => cardiaca; set => cardiaca = value; }
    public string Medicamentos { get => medicamentos; set => medicamentos = value; }
    public int Id_cita_reg { get => id_cita_reg; set => id_cita_reg = value; }
    public int Id_incapacidad { get => id_incapacidad; set => id_incapacidad = value; }
    public double Peso { get => peso; set => peso = value; }
    public double Altura { get => altura; set => altura = value; }
}