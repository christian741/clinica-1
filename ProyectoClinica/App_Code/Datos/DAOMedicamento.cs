using Newtonsoft.Json;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de DAOMedicamento
/// </summary>
public class DAOMedicamento
{
    private List<Medicamento> datos = new List<Medicamento>();

    public DAOMedicamento()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
    public DataTable registrar_Medicamento(Medicamento med)
    {
        DataTable Medicamento = new DataTable();
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

       
        try
        {

            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("inventario.f_insertar_medicamento", conection);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_nombre", NpgsqlDbType.Varchar, 100).Value = med.Nombre;
            dataAdapter.SelectCommand.Parameters.Add("_descripcion", NpgsqlDbType.Text).Value = med.Descripcion;
           dataAdapter.SelectCommand.Parameters.Add("_stock", NpgsqlDbType.Varchar,100).Value = med.Stock;
           dataAdapter.SelectCommand.Parameters.Add("_session", NpgsqlDbType.Text).Value = med.Session;
            dataAdapter.SelectCommand.Parameters.Add("_sede", NpgsqlDbType.Integer).Value = med.Sede;

            conection.Open();
            dataAdapter.Fill(Medicamento);
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
        finally
        {
            if (conection != null)
            {
                conection.Close();
            }
        }
        return Medicamento;
   
    }
    public DataTable traer_Medicamento2()
    {
        DataTable Medicamento = new DataTable();
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);


        try
        {

            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("inventario.f_traer_medicamento_normal", conection);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            conection.Open();
            dataAdapter.Fill(Medicamento);
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
        finally
        {
            if (conection != null)
            {
                conection.Close();
            }
        }
        return Medicamento;

    }
    public DataTable traer_Medicamento()
    {
        DataTable Medicamento = new DataTable();
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);


        try
        {

            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("inventario.f_traer_medicamento", conection);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
           
            conection.Open();
            dataAdapter.Fill(Medicamento);
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
        finally
        {
            if (conection != null)
            {
                conection.Close();
            }
        }
        return Medicamento;

    }
    public DataTable traer_Medicamento_Sede(Int32 sede)
    {
        DataTable Medicamento = new DataTable();
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);


        try
        {

            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("inventario.f_traer_medicamento_sede", conection);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_sede", NpgsqlDbType.Bigint).Value = sede;

            conection.Open();
            dataAdapter.Fill(Medicamento);
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
        finally
        {
            if (conection != null)
            {
                conection.Close();
            }
        }
        return Medicamento;

    }
    public DataTable traer_vistaMedicamento_Sede(Int32 sede)
    {
        DataTable Medicamento = new DataTable();
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);


        try
        {

            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("inventario.f_traer_vistamedicamento_sede", conection);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_sede", NpgsqlDbType.Bigint).Value = sede;

            conection.Open();
            dataAdapter.Fill(Medicamento);
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
        finally
        {
            if (conection != null)
            {
                conection.Close();
            }
        }
        return Medicamento;

    }
    public DataTable actualizar_Medicamento(Medicamento med)
    {
        DataTable Medicamento = new DataTable();
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);


        try
        {

            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("inventario.f_actualizar_medicamento", conection);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_codigo", NpgsqlDbType.Bigint).Value = med.Codigo;
            dataAdapter.SelectCommand.Parameters.Add("_nombre", NpgsqlDbType.Varchar, 100).Value = med.Nombre;
            dataAdapter.SelectCommand.Parameters.Add("_descripcion", NpgsqlDbType.Text).Value = med.Descripcion;
            dataAdapter.SelectCommand.Parameters.Add("_stock", NpgsqlDbType.Varchar,100).Value = med.Stock;
            dataAdapter.SelectCommand.Parameters.Add("_session", NpgsqlDbType.Text).Value = med.Session;

            conection.Open();
            dataAdapter.Fill(Medicamento);
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
        finally
        {
            if (conection != null)
            {
                conection.Close();
            }
        }
        return Medicamento;

    }

    public DataTable BuscarMedicamento(Int32 codigo)
    {
        DataTable Medicamento = new DataTable();
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

        try
        {

            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("inventario.f_buscar_medicamento", conection);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_codigo", NpgsqlDbType.Bigint).Value = codigo;

            conection.Open();
            dataAdapter.Fill(Medicamento);
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
        finally
        {
            if (conection != null)
            {
                conection.Close();
            }
        }
      
       
        return Medicamento;
    }

  
   

}