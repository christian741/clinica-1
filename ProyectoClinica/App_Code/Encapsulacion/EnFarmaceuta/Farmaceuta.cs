using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Farmaceuta
/// </summary>
public class Farmaceuta
{
    private int id;
    private Int32 cedula_farmaceuta;
    private String nombre_farmaceuta;
    private String apellido_farmaceuta;
    private String direccion_farmaceuta;
    private Int32 telefono_farmaceuta;
    private String correo_farmaceuta;
    private String clave_farmaceuta;
    private DateTime nacmiento_farmaceuta;
    private String foto;
    private String session;
    private int sede;
    private String sexo;
    public Farmaceuta()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public Int32 Cedula_farmaceuta { get => cedula_farmaceuta; set => cedula_farmaceuta = value; }
    public string Nombre_farmaceuta { get => nombre_farmaceuta; set => nombre_farmaceuta = value; }
    public string Apellido_farmaceuta { get => apellido_farmaceuta; set => apellido_farmaceuta = value; }
    public string Direccion_farmaceuta { get => direccion_farmaceuta; set => direccion_farmaceuta = value; }
    public Int32 Telefono_farmaceuta { get => telefono_farmaceuta; set => telefono_farmaceuta = value; }
    public string Correo_farmaceuta { get => correo_farmaceuta; set => correo_farmaceuta = value; }
    public string Clave_farmaceuta { get => clave_farmaceuta; set => clave_farmaceuta = value; }
    public DateTime Nacmiento_farmaceuta { get => nacmiento_farmaceuta; set => nacmiento_farmaceuta = value; }
    public string Foto { get => foto; set => foto = value; }
    public string Session { get => session; set => session = value; }
    public int Sede { get => sede; set => sede = value; }
    public string Sexo { get => sexo; set => sexo = value; }
    public int Id { get => id; set => id = value; }
}