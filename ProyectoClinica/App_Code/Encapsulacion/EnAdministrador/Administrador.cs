using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Administrador
/// </summary>
public class Administrador
{
    private int id;
    private Int32 cedula;
    private String nombre;
    private String apellido;
    private String direccion;
    private Int32 telefono;
    private String correo;
    private String clave;
    private DateTime nacimiento;
    private String foto;
    private String session;
    private int sede;
    private String sexo;

    public Administrador()
    { 
    }

    public int Id { get => id; set => id = value; }
    public int Cedula { get => cedula; set => cedula = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Apellido { get => apellido; set => apellido = value; }
    public string Direccion { get => direccion; set => direccion = value; }
    public int Telefono { get => telefono; set => telefono = value; }
    public string Correo { get => correo; set => correo = value; }
    public string Clave { get => clave; set => clave = value; }
    public DateTime Nacimiento { get => nacimiento; set => nacimiento = value; }
    public string Foto { get => foto; set => foto = value; }
    public string Session { get => session; set => session = value; }
    public int Sede { get => sede; set => sede = value; }
    public string Sexo { get => sexo; set => sexo = value; }
}