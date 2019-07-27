using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Pedido
/// </summary>
public class Pedido
{
    private Int32 id_pedido;
    private Int32 id_sede;
    private DateTime fecha_pedido;
    private String medicamentos;
    private int cantidad;
    private String nombre;
    private String descripcion;
    private String stock;
    private int dias_entrega;
    private string session;
    public Pedido()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public int Id_pedido { get => id_pedido; set => id_pedido = value; }
    public int Id_sede { get => id_sede; set => id_sede = value; }
    public DateTime Fecha_pedido { get => fecha_pedido; set => fecha_pedido = value; }
    public string Medicamentos { get => medicamentos; set => medicamentos = value; }
    public int Cantidad { get => cantidad; set => cantidad = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Descripcion { get => descripcion; set => descripcion = value; }
    public string Stock { get => stock; set => stock = value; }
    public int Dias_entrega { get => dias_entrega; set => dias_entrega = value; }
    public string Session { get => session; set => session = value; }
}