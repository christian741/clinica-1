using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de DAOPaciente
/// </summary>
public class DAOPaciente
{
    public DAOPaciente()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
    public DataTable ver_Paciente()
    {
        DataTable usuario = new DataTable();
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("clinica.f_mostrar_paciente", conection);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

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
    public DataTable ver_historial_Clinico(Int32 id_paciente)
    {
        DataTable usuario = new DataTable();
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("cita.f_traer_historial_clinico_paciente", conection);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_paciente", NpgsqlDbType.Bigint).Value = id_paciente;

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

    public DataTable modificar_paciente(Paciente pac)
    {


        DataTable Usuario = new DataTable();
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

        try
        {

            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("clinica.f_modificar_usuario", conection);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_id", NpgsqlDbType.Integer).Value = pac.Id;
            dataAdapter.SelectCommand.Parameters.Add("_cedula", NpgsqlDbType.Bigint).Value = pac.Cedula_paciente;
            dataAdapter.SelectCommand.Parameters.Add("_nombre", NpgsqlDbType.Varchar, 100).Value = pac.Nombre_paciente;
            dataAdapter.SelectCommand.Parameters.Add("_apellido", NpgsqlDbType.Varchar, 100).Value = pac.Apellido_paciente;
            dataAdapter.SelectCommand.Parameters.Add("_direccion", NpgsqlDbType.Text).Value = pac.Direccion_paciente;
            dataAdapter.SelectCommand.Parameters.Add("_telefono", NpgsqlDbType.Integer).Value = pac.Telefono_paciente;
            dataAdapter.SelectCommand.Parameters.Add("_correo", NpgsqlDbType.Varchar, 100).Value = pac.Correo_paciente;
            dataAdapter.SelectCommand.Parameters.Add("_clave", NpgsqlDbType.Varchar, 100).Value = pac.Clave_paciente;
            dataAdapter.SelectCommand.Parameters.Add("_fecha_nacimiento", NpgsqlDbType.Date).Value = pac.Nacmiento_paciente;
            dataAdapter.SelectCommand.Parameters.Add("_foto", NpgsqlDbType.Text).Value = pac.Foto;
            dataAdapter.SelectCommand.Parameters.Add("_sexo", NpgsqlDbType.Varchar, 100).Value = pac.Sexo;
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
    public DataTable traerRemision(Int32 id_usuario)
    {
        DataTable Usuario = new DataTable();
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

       
            try
            {

                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("cita.f_traer_remisiones_paciente", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_paciente", NpgsqlDbType.Bigint).Value = id_usuario;
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
    public DataTable actualizar_remision(Int32 id_remision)
    {
        DataTable Usuario = new DataTable();
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);


        try
        {

            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("cita.f_actualizar_remisiones_paciente", conection);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_id_remision", NpgsqlDbType.Bigint).Value = id_remision;
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
    public DataTable quitar_remision(Int32 id_remision)
    {
        DataTable Usuario = new DataTable();
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);


        try
        {

            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("cita.f_quitar_remisiones_paciente", conection);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_id_remision", NpgsqlDbType.Bigint).Value = id_remision;
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

    public DataTable remision_cita_realizada(Int32 id_remision)
    {
        DataTable Usuario = new DataTable();
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);


        try
        {

            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("cita.f_listo_remisiones_paciente", conection);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_id_remision", NpgsqlDbType.Bigint).Value = id_remision;
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

    public DataTable validar_citas(String _fecha , Int32 id_usuario)
    {
        DataTable Usuario = new DataTable();
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);


        try
        {

            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("cita.f_validar_cita_paciente", conection);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_fecha", NpgsqlDbType.Text).Value = _fecha;
            dataAdapter.SelectCommand.Parameters.Add("_paciente", NpgsqlDbType.Bigint).Value = id_usuario;
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
    public DataTable contar_citas( Int32 id_usuario)
    {
        DataTable Usuario = new DataTable();
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);


        try
        {

            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("cita.f_validar_cuenta_paciente", conection);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_paciente", NpgsqlDbType.Bigint).Value = id_usuario;
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

    public DataTable validar_paciente(Paciente pac)
    {
        DataTable Usuario = new DataTable();
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

        try
        {

            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("clinica.f_validar_usuarios", conection);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_cedula", NpgsqlDbType.Bigint).Value = pac.Cedula_paciente;
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
    public DataTable registrar_paciente(Paciente pac)
    {
        DataTable Usuario = new DataTable();
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

        if (this.validar_paciente(pac).Rows.Count != 0)
        {
            return Usuario = null;
        }
        else
        {
            try
            {

                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("clinica.f_insertar_paciente", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_cedula", NpgsqlDbType.Bigint).Value = pac.Cedula_paciente;
                dataAdapter.SelectCommand.Parameters.Add("_nombre", NpgsqlDbType.Varchar, 100).Value = pac.Nombre_paciente;
                dataAdapter.SelectCommand.Parameters.Add("_apellido", NpgsqlDbType.Varchar, 100).Value = pac.Apellido_paciente;
                dataAdapter.SelectCommand.Parameters.Add("_direccion", NpgsqlDbType.Text).Value = pac.Direccion_paciente;
                dataAdapter.SelectCommand.Parameters.Add("_telefono", NpgsqlDbType.Integer).Value = pac.Telefono_paciente;
                dataAdapter.SelectCommand.Parameters.Add("_correo", NpgsqlDbType.Varchar, 100).Value = pac.Correo_paciente;
                dataAdapter.SelectCommand.Parameters.Add("_clave", NpgsqlDbType.Varchar, 100).Value = pac.Clave_paciente;
                dataAdapter.SelectCommand.Parameters.Add("_fecha_nacimiento", NpgsqlDbType.Date).Value = pac.Nacmiento_paciente;
                dataAdapter.SelectCommand.Parameters.Add("_foto", NpgsqlDbType.Text).Value = pac.Foto;
                dataAdapter.SelectCommand.Parameters.Add("_session", NpgsqlDbType.Text).Value = pac.Session;
                dataAdapter.SelectCommand.Parameters.Add("_sexo", NpgsqlDbType.Varchar, 100).Value = pac.Sexo;
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
    
}