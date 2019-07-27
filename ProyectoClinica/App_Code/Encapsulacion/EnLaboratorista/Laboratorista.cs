using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Laboratorista
/// </summary>
public class Laboratorista
{
    private int id;
    private Int32 cedula_lab;
    private String nombre_lab;
    private String apellido_lab;
    private String direccion_lab;
    private Int32 telefono_lab;
    private String correo_lab;
    private String clave_lab;
    private DateTime nacmiento_lab;
    private String foto;
    private String session;
    private int sede;
    private String sexo;
    public Laboratorista()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public Int32 Cedula_lab { get => cedula_lab; set => cedula_lab = value; }
    public string Nombre_lab { get => nombre_lab; set => nombre_lab = value; }
    public string Apellido_lab { get => apellido_lab; set => apellido_lab = value; }
    public string Direccion_lab { get => direccion_lab; set => direccion_lab = value; }
    public Int32 Telefono_lab { get => telefono_lab; set => telefono_lab = value; }
    public string Correo_lab { get => correo_lab; set => correo_lab = value; }
    public string Clave_lab { get => clave_lab; set => clave_lab = value; }
    public DateTime Nacmiento_lab { get => nacmiento_lab; set => nacmiento_lab = value; }
    public string Foto { get => foto; set => foto = value; }
    public string Session { get => session; set => session = value; }
    public int Sede { get => sede; set => sede = value; }
    public string Sexo { get => sexo; set => sexo = value; }
    public int Id { get => id; set => id = value; }
}