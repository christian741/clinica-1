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
/// Descripción breve de DAOLaboratorista
/// </summary>
public class DAOLaboratorista
{
    public DAOLaboratorista()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
    public DataTable ver_Laboratorista()
    {
        DataTable usuario = new DataTable();
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("clinica.f_mostrar_laboratorista", conection);
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
    public DataTable ver_Pedido(Int32 sede)
    {
        DataTable usuario = new DataTable();
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("inventario.f_traer_pedido_sede", conection);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_sede", NpgsqlDbType.Integer).Value = sede;

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
    public DataTable traer_Pedido()
    {
        DataTable usuario = new DataTable();
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("inventario.f_traer_pedido", conection);
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
    public void cancelarPedido(Int32 id_pedido)
    {
        DataTable usuario = new DataTable();
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("inventario.f_cancelar_pedido", conection);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_pedido", NpgsqlDbType.Bigint).Value = id_pedido;

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
    }
    public void retrasoPedido(Int32 id_pedido)
    {
        DataTable usuario = new DataTable();
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("inventario.f_cancelar_pedido", conection);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_pedido", NpgsqlDbType.Bigint).Value = id_pedido;

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
    }
    public void atenderPedido(Int32 id_pedido)
    {
        DataTable usuario = new DataTable();
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("inventario.f_atender_pedido", conection);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_pedido", NpgsqlDbType.Bigint).Value = id_pedido;

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
    }
    public List<ListaPedido> llenarPedido(Int32 id_pedido)
    {
        DataTable usuario = new DataTable();
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("inventario.f_llenar_pedido", conection);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_pedido", NpgsqlDbType.Bigint).Value = id_pedido;

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

        List<ListaPedido> lista =  JsonConvert.DeserializeObject<List<ListaPedido>>(usuario.Rows[0]["medicamentos"].ToString());



        return lista;
        
    }
    public List<ListaPedido> llenarInventario(Int32 id_pedido)
    {
        DataTable usuario = new DataTable();
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("inventario.f_llenar_pedido", conection);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_pedido", NpgsqlDbType.Bigint).Value = id_pedido;

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

        List<ListaPedido> lista = JsonConvert.DeserializeObject<List<ListaPedido>>(usuario.Rows[0]["medicamentos"].ToString());



        return lista;

    }

    public DataTable modificar_lab(Laboratorista lab)
    {


        DataTable Usuario = new DataTable();
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

        try
        {

            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("clinica.f_modificar_usuario", conection);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_id", NpgsqlDbType.Integer).Value = lab.Id;
            dataAdapter.SelectCommand.Parameters.Add("_cedula", NpgsqlDbType.Bigint).Value = lab.Cedula_lab;
            dataAdapter.SelectCommand.Parameters.Add("_nombre", NpgsqlDbType.Varchar, 100).Value = lab.Nombre_lab;
            dataAdapter.SelectCommand.Parameters.Add("_apellido", NpgsqlDbType.Varchar, 100).Value = lab.Apellido_lab;
            dataAdapter.SelectCommand.Parameters.Add("_direccion", NpgsqlDbType.Text).Value = lab.Direccion_lab;
            dataAdapter.SelectCommand.Parameters.Add("_telefono", NpgsqlDbType.Integer).Value = lab.Telefono_lab;
            dataAdapter.SelectCommand.Parameters.Add("_correo", NpgsqlDbType.Varchar, 100).Value = lab.Correo_lab;
            dataAdapter.SelectCommand.Parameters.Add("_clave", NpgsqlDbType.Varchar, 100).Value = lab.Clave_lab;
            dataAdapter.SelectCommand.Parameters.Add("_fecha_nacimiento", NpgsqlDbType.Date).Value = lab.Nacmiento_lab;
            dataAdapter.SelectCommand.Parameters.Add("_foto", NpgsqlDbType.Text).Value = lab.Foto;
            dataAdapter.SelectCommand.Parameters.Add("_sexo", NpgsqlDbType.Varchar, 100).Value = lab.Sexo;
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

    public DataTable registrar_Laboratorista(Laboratorista lab)
    {
        //this.validar_paciente(pac);
        DataTable Usuario = new DataTable();
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

        if (this.validar_laboratorista(lab).Rows.Count != 0)
        {

            return Usuario = null;
        }
        else
        {
            try
            {

                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("clinica.f_insertar_laboratorista", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_cedula", NpgsqlDbType.Bigint).Value = lab.Cedula_lab;
                dataAdapter.SelectCommand.Parameters.Add("_nombre", NpgsqlDbType.Varchar, 100).Value = lab.Nombre_lab;
                dataAdapter.SelectCommand.Parameters.Add("_apellido", NpgsqlDbType.Varchar, 100).Value = lab.Apellido_lab;
                dataAdapter.SelectCommand.Parameters.Add("_direccion", NpgsqlDbType.Text).Value = lab.Direccion_lab;
                dataAdapter.SelectCommand.Parameters.Add("_telefono", NpgsqlDbType.Integer).Value = lab.Telefono_lab;
                dataAdapter.SelectCommand.Parameters.Add("_correo", NpgsqlDbType.Varchar, 100).Value = lab.Correo_lab;
                dataAdapter.SelectCommand.Parameters.Add("_clave", NpgsqlDbType.Varchar, 100).Value = lab.Clave_lab;
                dataAdapter.SelectCommand.Parameters.Add("_fecha_nacimiento", NpgsqlDbType.Date).Value = lab.Nacmiento_lab;
                dataAdapter.SelectCommand.Parameters.Add("_foto", NpgsqlDbType.Text).Value = lab.Foto;
                dataAdapter.SelectCommand.Parameters.Add("_session", NpgsqlDbType.Text).Value = lab.Session;
                dataAdapter.SelectCommand.Parameters.Add("_sexo", NpgsqlDbType.Varchar, 100).Value = lab.Sexo;
                dataAdapter.SelectCommand.Parameters.Add("_sede", NpgsqlDbType.Integer).Value = lab.Sede;
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
    public DataTable validar_laboratorista(Laboratorista lab)
    {
        DataTable Usuario = new DataTable();
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

        try
        {

            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("clinica.f_validar_usuarios", conection);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_cedula", NpgsqlDbType.Bigint).Value = lab.Cedula_lab;
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
    public void insertar_Pedido(Pedido ped)
    {
        DataTable Usuario = new DataTable();
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);


        try
        {

            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("inventario.f_insertar_pedido", conection);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_sede", NpgsqlDbType.Bigint).Value = ped.Id_sede;
            dataAdapter.SelectCommand.Parameters.Add("_medicamentos", NpgsqlDbType.Json).Value = ped.Medicamentos;
            dataAdapter.SelectCommand.Parameters.Add("_session", NpgsqlDbType.Text).Value = ped.Session;

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


    public void insertar_Devolucion(Devolucion dev)
    {
        DataTable Usuario = new DataTable();
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);


        try
        {

            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("inventario.f_insertar_devolucion", conection);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_medicamentos", NpgsqlDbType.Json).Value = dev.Medicamentos1;
            dataAdapter.SelectCommand.Parameters.Add("_session", NpgsqlDbType.Text).Value = dev.Session1;
            dataAdapter.SelectCommand.Parameters.Add("_sede", NpgsqlDbType.Bigint).Value = dev.Sede;

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

    public void insertar_Inventario(Inventario inv)
    {
        DataTable Usuario = new DataTable();
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);


        try
        {

            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("inventario.f_insertar_inventario", conection);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_medicamentos", NpgsqlDbType.Json).Value = inv.Medicamentos;
            dataAdapter.SelectCommand.Parameters.Add("_session", NpgsqlDbType.Text).Value = inv.Session;
            dataAdapter.SelectCommand.Parameters.Add("_sede", NpgsqlDbType.Bigint).Value = inv.Sede;

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

}