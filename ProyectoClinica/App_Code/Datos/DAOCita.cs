using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de DAOCita
/// </summary>
public class DAOCita
{
    //cita.f_traer_citas_historiales
    public DAOCita()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
    public void  insertar_Incapacidad(Incapacidad inca)
    {
        DataTable Usuario = new DataTable();
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);


        try
        {

            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("cita.f_registrar_incapacidad", conection);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_doctor", NpgsqlDbType.Bigint).Value = inca.Id_doctor;
            dataAdapter.SelectCommand.Parameters.Add("_paciente", NpgsqlDbType.Bigint).Value =inca.Id_paciente;
            dataAdapter.SelectCommand.Parameters.Add("_razon", NpgsqlDbType.Text).Value = inca.Razon;
            dataAdapter.SelectCommand.Parameters.Add("_session", NpgsqlDbType.Text).Value = inca.Session1;
            dataAdapter.SelectCommand.Parameters.Add("_dias", NpgsqlDbType.Integer).Value = inca.Dias;

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

        
    }

    public DataTable traer_Incapacidad_hoy(Int32 id_doctor,Int32 id_paciente)
    {
        DataTable Usuario = new DataTable();
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);


        try
        {

            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("cita.f_buscar_incapacidad_hoy", conection);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_doctor", NpgsqlDbType.Bigint).Value = id_doctor;
            dataAdapter.SelectCommand.Parameters.Add("_paciente", NpgsqlDbType.Bigint).Value = id_paciente;
            
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
    public DataTable traer_remision_hoy(Int32 id_doctor, Int32 id_paciente)
    {
        DataTable Usuario = new DataTable();
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);


        try
        {

            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("cita.f_buscar_remision_hoy", conection);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_doctor", NpgsqlDbType.Bigint).Value = id_doctor;
            dataAdapter.SelectCommand.Parameters.Add("_paciente", NpgsqlDbType.Bigint).Value = id_paciente;

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

    public void insertar_Cita(Cita cita)
    {
        DataTable Usuario = new DataTable();
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);


        try
        {

            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("cita.f_registrar_cita", conection);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_especial", NpgsqlDbType.Integer).Value = cita.Especializacion;
            dataAdapter.SelectCommand.Parameters.Add("_paciente", NpgsqlDbType.Integer).Value = cita.Paciente;
            dataAdapter.SelectCommand.Parameters.Add("_doctor", NpgsqlDbType.Integer).Value =cita.Doctor;
            dataAdapter.SelectCommand.Parameters.Add("_sede", NpgsqlDbType.Integer).Value =cita.Sede;
            dataAdapter.SelectCommand.Parameters.Add("_fecha_cita", NpgsqlDbType.Text).Value = cita.Fecha_cita;
            dataAdapter.SelectCommand.Parameters.Add("_session", NpgsqlDbType.Text).Value = cita.Session;
            dataAdapter.SelectCommand.Parameters.Add("_razon", NpgsqlDbType.Text).Value = cita.Razon;

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
        

    }
    public void insertar_Atencion(HistoricoCita cita)
    {
        DataTable Usuario = new DataTable();
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);


        try
        {
         
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("cita.f_registrar_atencion_cita", conection);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_descripcion", NpgsqlDbType.Text).Value = cita.Descripcion1;
            dataAdapter.SelectCommand.Parameters.Add("_cardiaca", NpgsqlDbType.Integer).Value = cita.Cardiaca;
            dataAdapter.SelectCommand.Parameters.Add("_respiratoria", NpgsqlDbType.Integer).Value = cita.Respiratoria;
            dataAdapter.SelectCommand.Parameters.Add("_altura", NpgsqlDbType.Double).Value = cita.Altura;
            dataAdapter.SelectCommand.Parameters.Add("_peso", NpgsqlDbType.Double).Value = cita.Peso;
            dataAdapter.SelectCommand.Parameters.Add("_session", NpgsqlDbType.Text).Value = cita.Session;
            dataAdapter.SelectCommand.Parameters.Add("_incapacidad", NpgsqlDbType.Bigint).Value = cita.Id_incapacidad;
            dataAdapter.SelectCommand.Parameters.Add("_id_cita_registrada", NpgsqlDbType.Bigint).Value = cita.Id_cita_reg;
            dataAdapter.SelectCommand.Parameters.Add("_medicamentos", NpgsqlDbType.Json).Value = cita.Medicamentos;

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


    }
    public void insertar_Atencion_Vacia(HistoricoCita cita)
    {
        DataTable Usuario = new DataTable();
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);


        try
        {

            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("cita.f_registrar_atencion_cita_vacia", conection);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_descripcion", NpgsqlDbType.Text).Value = cita.Descripcion1;
            dataAdapter.SelectCommand.Parameters.Add("_cardiaca", NpgsqlDbType.Integer).Value = cita.Cardiaca;
            dataAdapter.SelectCommand.Parameters.Add("_respiratoria", NpgsqlDbType.Integer).Value = cita.Respiratoria;
            dataAdapter.SelectCommand.Parameters.Add("_altura", NpgsqlDbType.Double).Value = cita.Altura;
            dataAdapter.SelectCommand.Parameters.Add("_peso", NpgsqlDbType.Double).Value = cita.Peso;
            dataAdapter.SelectCommand.Parameters.Add("_session", NpgsqlDbType.Text).Value = cita.Session;
            dataAdapter.SelectCommand.Parameters.Add("_incapacidad", NpgsqlDbType.Bigint).Value = cita.Id_incapacidad;
            dataAdapter.SelectCommand.Parameters.Add("_id_cita_registrada", NpgsqlDbType.Bigint).Value = cita.Id_cita_reg;
            dataAdapter.SelectCommand.Parameters.Add("_medicamentos", NpgsqlDbType.Json).Value = cita.Medicamentos;

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


    }

    public void insertar_Remision(Remision rem)
    {
        DataTable Usuario = new DataTable();
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);


        try
        {

            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("cita.f_registrar_remision", conection);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_paciente", NpgsqlDbType.Bigint).Value = rem.Id_usuario;
            dataAdapter.SelectCommand.Parameters.Add("_dias", NpgsqlDbType.Text).Value = Convert.ToString(rem.Dias);
            dataAdapter.SelectCommand.Parameters.Add("_session", NpgsqlDbType.Text).Value = rem.Session;
            dataAdapter.SelectCommand.Parameters.Add("_especial", NpgsqlDbType.Bigint).Value = rem.Id_especializacion;

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


    }
   
    public DataTable insertar_fecha(int id,String fecha)
    {
        DataTable Usuario = new DataTable();
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
        if (fecha == null)
        {
            fecha = DateTime.Today.ToShortDateString();
        }

        try
        {

            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("cita.f_obtener_citas", conection);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_doctor_id", NpgsqlDbType.Integer).Value = id;
            dataAdapter.SelectCommand.Parameters.Add("_fecha", NpgsqlDbType.Text).Value = fecha;
           
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
    public DataTable traerCitas_Doctor(int id_usuario, String fecha)
    {
        DataTable Cita = new DataTable();
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);


        try
        {

            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("cita.f_traer_cita_hoy", conection);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_doctor", NpgsqlDbType.Bigint).Value = id_usuario;
            dataAdapter.SelectCommand.Parameters.Add("_fecha", NpgsqlDbType.Text).Value = fecha;

            conection.Open();
            dataAdapter.Fill(Cita);
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
        return Cita;

    }
    public DataTable traerCitas_Paciente(int id_usuario,String fecha)
    {
        DataTable Cita = new DataTable();
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
      

        try
        {

            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("cita.f_traer_cita", conection);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_paciente", NpgsqlDbType.Bigint).Value = id_usuario;
            dataAdapter.SelectCommand.Parameters.Add("_fecha", NpgsqlDbType.Text).Value = fecha;

            conection.Open();
            dataAdapter.Fill(Cita);
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
        return Cita;

    }
    public DataTable cancelarCita(int id_cita)
    {
        DataTable Cita = new DataTable();
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);


        try
        {

            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("cita.f_cancelar_cita", conection);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_id_cita", NpgsqlDbType.Bigint).Value = id_cita;

            conection.Open();
            dataAdapter.Fill(Cita);
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
        return Cita;

    }

    public DataTable atenderCita(int id_cita, string sesion)
    {
        DataTable Cita = new DataTable();
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);


        try
        {

            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("cita.f_atender_cita", conection);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_id_cita", NpgsqlDbType.Bigint).Value = id_cita;
            dataAdapter.SelectCommand.Parameters.Add("_session", NpgsqlDbType.Text).Value = sesion;

            conection.Open();
            dataAdapter.Fill(Cita);
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
        return Cita;

    }
    public DataTable noVino(int id_cita, string sesion)
    {
        DataTable Cita = new DataTable();
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);


        try
        {

            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("cita.f_no_vino", conection);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_id_cita", NpgsqlDbType.Bigint).Value = id_cita;
            dataAdapter.SelectCommand.Parameters.Add("_session", NpgsqlDbType.Text).Value = sesion;

            conection.Open();
            dataAdapter.Fill(Cita);
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
        return Cita;

    }

    public DataTable actualizar_citaRegistrada(int id_cita, string sesion)
    {
        DataTable Cita = new DataTable();
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);


        try
        {

            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("cita.f_actualizar_cita_registrada", conection);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_id", NpgsqlDbType.Bigint).Value = id_cita;
            dataAdapter.SelectCommand.Parameters.Add("_session", NpgsqlDbType.Text).Value = sesion;

            conection.Open();
            dataAdapter.Fill(Cita);
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
        return Cita;

    }

    public DataTable validarAtencion_fecha(Int32 id)
    {
        DataTable Usuario = new DataTable();
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
       
        try
        {

            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("cita.f_validar_atencion_cita", conection);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_id_cita", NpgsqlDbType.Bigint).Value = id;

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
    public DataTable validarAtencion_horas(Int32 id,String _fecha)
    {
        DataTable Usuario = new DataTable();
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

        try
        {

            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("cita.f_traer_horas", conection);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_doctor_id", NpgsqlDbType.Bigint).Value = id;
            dataAdapter.SelectCommand.Parameters.Add("_hora", NpgsqlDbType.Text).Value = _fecha;

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