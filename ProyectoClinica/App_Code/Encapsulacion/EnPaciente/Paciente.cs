using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Paciente
/// </summary>
public class Paciente
{
    private int id;
    private Int32 cedula_paciente;
    private String nombre_paciente;
    private String apellido_paciente;
    private String direccion_paciente;
    private Int32 telefono_paciente;
    private String correo_paciente;
    private String clave_paciente;
    private DateTime nacmiento_paciente;
    private String foto;
    private String session;
    private String sexo;
    public Paciente()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public Int32 Cedula_paciente { get => cedula_paciente; set => cedula_paciente = value; }
    public string Nombre_paciente { get => nombre_paciente; set => nombre_paciente = value; }
    public string Apellido_paciente { get => apellido_paciente; set => apellido_paciente = value; }
    public string Direccion_paciente { get => direccion_paciente; set => direccion_paciente = value; }
    public Int32 Telefono_paciente { get => telefono_paciente; set => telefono_paciente = value; }
    public string Correo_paciente { get => correo_paciente; set => correo_paciente = value; }
    public string Clave_paciente { get => clave_paciente; set => clave_paciente = value; }
    public DateTime Nacmiento_paciente { get => nacmiento_paciente; set => nacmiento_paciente = value; }
    public string Foto { get => foto; set => foto = value; }
    public string Session { get => session; set => session = value; }
    public string Sexo { get => sexo; set => sexo = value; }
    public int Id { get => id; set => id = value; }
}