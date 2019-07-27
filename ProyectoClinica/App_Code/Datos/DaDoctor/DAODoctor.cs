using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Descripción breve de DAODoctor
/// </summary>
public class DAODoctor
{
    public DAODoctor()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
    public DataTable f_registrar_inasistencia(int id_doctor,string _fecha,string _session,string _razon)
    {
        //dias_descanzo
        DataTable Usuario = new DataTable();
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);


        try
        {

            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("cita.f_registrar_inasitencia", conection);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_doctor", NpgsqlDbType.Bigint).Value = id_doctor;
            dataAdapter.SelectCommand.Parameters.Add("_fecha", NpgsqlDbType.Text).Value = _fecha;
            dataAdapter.SelectCommand.Parameters.Add("_session", NpgsqlDbType.Text).Value = _session;
            dataAdapter.SelectCommand.Parameters.Add("_razon", NpgsqlDbType.Text).Value = _razon;

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
    public DataTable f_ver_inasistencia(int id_doctor, string _fecha)
    {
        //dias_descanzo
        DataTable Usuario = new DataTable();
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);


        try
        {

            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("cita.f_registrar_inasitencia", conection);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_fecha", NpgsqlDbType.Text).Value = _fecha;
            dataAdapter.SelectCommand.Parameters.Add("_id_doctor", NpgsqlDbType.Bigint).Value = id_doctor;

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


    public DataTable f_ver_Citas(int id_doctor, DateTime _fecha)
    {
        //dias_descanzo
        DataTable Usuario = new DataTable();
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);


        try
        {

            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("cita.f_traer_citas_doc", conection);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_doctor", NpgsqlDbType.Bigint).Value = id_doctor;
            dataAdapter.SelectCommand.Parameters.Add("_fecha", NpgsqlDbType.Date).Value = _fecha;

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

    public DataTable traer_fecha_limite(int id_doctor)
    {
        //dias_descanzo
        DataTable Usuario = new DataTable();
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);


        try
        {

            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("clinica.f_traer_fecha_limite", conection);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_doctor_id", NpgsqlDbType.Bigint).Value = id_doctor;

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

    public DataTable obtener_Sedes()
    {
        DataTable usuario = new DataTable();
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("clinica.f_obtener_sedes", conection);
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
    public DataTable traer_doctor(int id_doctor)
    {
        //this.validar_paciente(pac);
        DataTable Usuario = new DataTable();
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);


        try
        {

            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("cita.f_traer_doctor", conection);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_doctor", NpgsqlDbType.Integer).Value = id_doctor;

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
    public DataTable traer_descanzo(int id_doctor)
    {
        //dias_descanzo
        DataTable Usuario = new DataTable();
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);


        try
        {

            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("clinica.f_traer_descanzo", conection);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_doctor_id", NpgsqlDbType.Bigint).Value = id_doctor;

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
    public DataTable ver_Doctor()
    {
        DataTable usuario = new DataTable();
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("clinica.f_mostrar_doctor", conection);
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
    public DataTable ver_Incapacidad(int id_doctor, int id_paciente)
    {
        DataTable usuario = new DataTable();
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("cita.f_traer_incapacidad", conection);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_doctor_id", NpgsqlDbType.Bigint).Value = id_doctor;
            dataAdapter.SelectCommand.Parameters.Add("_paciente_id", NpgsqlDbType.Bigint).Value = id_paciente;

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

    public DataTable modificar_doctor(Doctor doc)
    {


        DataTable Usuario = new DataTable();
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
       
            try
            {

                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("clinica.f_modificar_usuario", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_id", NpgsqlDbType.Integer).Value = doc.Id;
                dataAdapter.SelectCommand.Parameters.Add("_cedula", NpgsqlDbType.Bigint).Value = doc.Cedula_doctor;
                dataAdapter.SelectCommand.Parameters.Add("_nombre", NpgsqlDbType.Varchar, 100).Value = doc.Nombre_doctor;
                dataAdapter.SelectCommand.Parameters.Add("_apellido", NpgsqlDbType.Varchar, 100).Value = doc.Apellido_doctor;
                dataAdapter.SelectCommand.Parameters.Add("_direccion", NpgsqlDbType.Text).Value = doc.Direccion_doctor;
                dataAdapter.SelectCommand.Parameters.Add("_telefono", NpgsqlDbType.Integer).Value = doc.Telefono_doctor;
                dataAdapter.SelectCommand.Parameters.Add("_correo", NpgsqlDbType.Varchar, 100).Value = doc.Correo_doctor;
                dataAdapter.SelectCommand.Parameters.Add("_clave", NpgsqlDbType.Varchar, 100).Value = doc.Clave_doctor;
                dataAdapter.SelectCommand.Parameters.Add("_fecha_nacimiento", NpgsqlDbType.Date).Value = doc.Nacmiento_doctor;
                dataAdapter.SelectCommand.Parameters.Add("_foto", NpgsqlDbType.Text).Value = doc.Foto;
                dataAdapter.SelectCommand.Parameters.Add("_sexo", NpgsqlDbType.Varchar, 100).Value = doc.Sexo;
                dataAdapter.SelectCommand.Parameters.Add("_sede", NpgsqlDbType.Integer).Value = doc.Sede;

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
    public DataTable registrar_doctor(Doctor doc)
    {
        DataTable Usuario = new DataTable();
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

        if (this.validar_doctor(doc).Rows.Count != 0)
        {

            return Usuario = null;
        }
        else
        {
            try
            {

                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("clinica.f_insertar_doctor", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_cedula", NpgsqlDbType.Bigint).Value = doc.Cedula_doctor;
                dataAdapter.SelectCommand.Parameters.Add("_nombre", NpgsqlDbType.Varchar, 100).Value = doc.Nombre_doctor;
                dataAdapter.SelectCommand.Parameters.Add("_apellido", NpgsqlDbType.Varchar, 100).Value = doc.Apellido_doctor;
                dataAdapter.SelectCommand.Parameters.Add("_direccion", NpgsqlDbType.Text).Value = doc.Direccion_doctor;
                dataAdapter.SelectCommand.Parameters.Add("_telefono", NpgsqlDbType.Integer).Value = doc.Telefono_doctor;
                dataAdapter.SelectCommand.Parameters.Add("_correo", NpgsqlDbType.Varchar, 100).Value = doc.Correo_doctor;
                dataAdapter.SelectCommand.Parameters.Add("_clave", NpgsqlDbType.Varchar, 100).Value = doc.Clave_doctor;
                dataAdapter.SelectCommand.Parameters.Add("_fecha_nacimiento", NpgsqlDbType.Date).Value = doc.Nacmiento_doctor;
                dataAdapter.SelectCommand.Parameters.Add("_foto", NpgsqlDbType.Text).Value = doc.Foto;
                dataAdapter.SelectCommand.Parameters.Add("_session", NpgsqlDbType.Text).Value = doc.Session;
                dataAdapter.SelectCommand.Parameters.Add("_sexo", NpgsqlDbType.Varchar,100).Value = doc.Sexo;
                dataAdapter.SelectCommand.Parameters.Add("_sede", NpgsqlDbType.Integer).Value = doc.Sede;
                dataAdapter.SelectCommand.Parameters.Add("_especializacion", NpgsqlDbType.Integer).Value = doc.Especializacion;
                dataAdapter.SelectCommand.Parameters.Add("_horario", NpgsqlDbType.Integer).Value = doc.Horario;
                dataAdapter.SelectCommand.Parameters.Add("_horas", NpgsqlDbType.Text).Value = doc.Tiempo_laborado;

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
    public DataTable registrar_descanzo(Int32 id_doctor,String session,string dia)
    {
        DataTable Usuario = new DataTable();
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

      
            try
            {

                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("clinica.f_insertar_descanzo", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_doctor_id", NpgsqlDbType.Bigint).Value = id_doctor;
                dataAdapter.SelectCommand.Parameters.Add("_session", NpgsqlDbType.Text).Value = session;
                dataAdapter.SelectCommand.Parameters.Add("_dia", NpgsqlDbType.Text).Value = dia;

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

    public DataTable validar_doctor(Doctor doc)
    {
        DataTable Usuario = new DataTable();
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

        try
        {

            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("clinica.f_validar_usuarios", conection);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_cedula", NpgsqlDbType.Bigint).Value = doc.Cedula_doctor;
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
    /*public DataTable guardadoSession_Doctor(Doctor doc)
    {
        DataTable Usuario = new DataTable();
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("security.f_guardado_session", conection);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_user_id", NpgsqlDbType.Integer).Value = doc.Cedula_doctor;
            dataAdapter.SelectCommand.Parameters.Add("_ip", NpgsqlDbType.Varchar, 100).Value = doc;
            dataAdapter.SelectCommand.Parameters.Add("_mac", NpgsqlDbType.Varchar, 100).Value = doc.Mac;
            dataAdapter.SelectCommand.Parameters.Add("_session", NpgsqlDbType.Text).Value = doc.Session;

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
    }*/

}