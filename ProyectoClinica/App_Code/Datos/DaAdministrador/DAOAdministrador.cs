using Npgsql;
using NpgsqlTypes;
using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de DAOAdministrador
/// </summary>
public class DAOAdministrador
{
    public DAOAdministrador()
    {
    }
    public DataTable buscar_Usuario(Int32 cedula,String clave)
    {
        DataTable usuario = new DataTable();
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);


        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("clinica.f_buscar_usuario", conection);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_cedula", NpgsqlDbType.Bigint).Value = cedula;
            dataAdapter.SelectCommand.Parameters.Add("_clave", NpgsqlDbType.Varchar, 100).Value = clave;


            conection.Open();

            dataAdapter.Fill(usuario);
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
        return usuario;
    }
    public DataTable buscar_Usuario2(Int32 cedula, String clave)
    {
        DataTable usuario = new DataTable();
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);


        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("clinica.f_buscar_usuario2", conection);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_cedula", NpgsqlDbType.Bigint).Value = cedula;
            dataAdapter.SelectCommand.Parameters.Add("_clave", NpgsqlDbType.Varchar, 100).Value = clave;


            conection.Open();

            dataAdapter.Fill(usuario);
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
        return usuario;
    }
    public DataTable modificar_admin(Administrador admin)
    {


        DataTable Usuario = new DataTable();
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

        try
        {

            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("clinica.f_modificar_usuario", conection);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_id", NpgsqlDbType.Integer).Value = admin.Id;
            dataAdapter.SelectCommand.Parameters.Add("_cedula", NpgsqlDbType.Bigint).Value = admin.Cedula;
            dataAdapter.SelectCommand.Parameters.Add("_nombre", NpgsqlDbType.Varchar, 100).Value = admin.Nombre;
            dataAdapter.SelectCommand.Parameters.Add("_apellido", NpgsqlDbType.Varchar, 100).Value = admin.Apellido;
            dataAdapter.SelectCommand.Parameters.Add("_direccion", NpgsqlDbType.Text).Value = admin.Direccion;
            dataAdapter.SelectCommand.Parameters.Add("_telefono", NpgsqlDbType.Integer).Value = admin.Telefono;
            dataAdapter.SelectCommand.Parameters.Add("_correo", NpgsqlDbType.Varchar, 100).Value = admin.Correo;
            dataAdapter.SelectCommand.Parameters.Add("_clave", NpgsqlDbType.Varchar, 100).Value = admin.Clave;
            dataAdapter.SelectCommand.Parameters.Add("_fecha_nacimiento", NpgsqlDbType.Date).Value = admin.Nacimiento;
            dataAdapter.SelectCommand.Parameters.Add("_foto", NpgsqlDbType.Text).Value = admin.Foto;
            dataAdapter.SelectCommand.Parameters.Add("_sexo", NpgsqlDbType.Varchar, 100).Value = admin.Sexo;
            dataAdapter.SelectCommand.Parameters.Add("_sede", NpgsqlDbType.Integer).Value = admin.Sede;

            conection.Open();
            dataAdapter.Fill(Usuario);
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
        return Usuario;


    }

}