using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Doctor
/// </summary>
public class Doctor
{
    private int id;
    private Int32 cedula_doctor;
    private String nombre_doctor;
    private String apellido_doctor;
    private String direccion_doctor;
    private Int32 telefono_doctor;
    private String correo_doctor;
    private String clave_doctor;
    private DateTime nacmiento_doctor;
    private String foto;
    private String session;
    private String sexo;
    private int especializacion;
    private int sede;
    private int horario;
    private String tiempo_laborado;

    
    

    public Doctor()
    {
    }

    public Int32 Cedula_doctor { get => cedula_doctor; set => cedula_doctor = value; }
    public string Nombre_doctor { get => nombre_doctor; set => nombre_doctor = value; }
    public string Apellido_doctor { get => apellido_doctor; set => apellido_doctor = value; }
    public string Direccion_doctor { get => direccion_doctor; set => direccion_doctor = value; }
    public Int32 Telefono_doctor { get => telefono_doctor; set => telefono_doctor = value; }
    public string Correo_doctor { get => correo_doctor; set => correo_doctor = value; }
    public string Clave_doctor { get => clave_doctor; set => clave_doctor = value; }
    public DateTime Nacmiento_doctor { get => nacmiento_doctor; set => nacmiento_doctor = value; }
    public string Foto { get => foto; set => foto = value; }
    public string Session { get => session; set => session = value; }
    public int Sede { get => sede; set => sede = value; }
    public string Sexo { get => sexo; set => sexo = value; }
    public int Especializacion { get => especializacion; set => especializacion = value; }
    public int Id { get => id; set => id = value; }
    public int Horario { get => horario; set => horario = value; }
    public string Tiempo_laborado { get => tiempo_laborado; set => tiempo_laborado = value; }
}