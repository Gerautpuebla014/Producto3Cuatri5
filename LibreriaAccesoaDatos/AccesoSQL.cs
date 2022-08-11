using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;

namespace LibreriaAccesoaDatos
{
    public class AccesoSQL
    {
        private string cadenaconexion;

        public AccesoSQL(string cadena)
        {
            cadenaconexion = cadena;
        }
        public SqlConnection Abrirconexion(ref string mensaje)
        {
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = cadenaconexion;
            //@"Data Source = LAPTOP-CQP8EP3M\SQLSERVER; initial Catalog =FerreteriaTemp; Integrated Security = true; ";

            try
            {
                conexion.Open();
                mensaje = "La conexion se ha abierto correctamente";
            }
            catch (Exception h)
            {
                mensaje = "ERROR" + h.Message;
                conexion = null;
            }
            return conexion;
        }

        public Boolean ModificarBD(string sentSql, SqlConnection cnAb, ref string mensaje)
        {
            Boolean salida = false;
            SqlCommand carrito = null;
            if (cnAb != null)
            {
                mensaje = "Conexion Abierta";
                using (carrito = new SqlCommand())
                {
                    carrito.CommandText = sentSql;
                    carrito.Connection = cnAb;
                    try
                    {
                        carrito.ExecuteNonQuery();
                        mensaje = "Modificacion CORRECTA";
                        salida = true;
                    }
                    catch (Exception s)
                    {
                        mensaje = "ERRO" + s.Message;
                        salida = false;
                    }
                }
                cnAb.Close();
                cnAb.Dispose();
            }
            else
            {
                mensaje = "no hay conexion abierta";
                salida = false;
            }
            return salida;
        }

        public Boolean ModificarBDMasseguro(string sentSql, SqlConnection cnAb, ref string mensaje,SqlParameter[] parametros)
        {
            Boolean salida = false;
            SqlCommand carrito = null;
            if (cnAb != null)
            {
                mensaje = "Conexion Abierta";
                using (carrito = new SqlCommand())
                {
                    carrito.CommandText = sentSql;
                    carrito.Connection = cnAb;
                    //Se asignan los parametros para poder utilizarlos con el arreglo 
                    foreach(SqlParameter x in parametros)
                    {
                        carrito.Parameters.Add(x);
                    }
                    try
                    {
                        carrito.ExecuteNonQuery();
                        mensaje = "Modificacion CORRECTA";
                        salida = true;
                    }
                    catch (Exception s)
                    {
                        mensaje = "ERRO" + s.Message;
                        salida = false;
                    }
                }
                cnAb.Close();
                cnAb.Dispose();
            }
            else
            {
                mensaje = "no hay conexion abierta";
                salida = false;
            }
            return salida;
        }

        public SqlDataReader ConsultaDR(string querySql, SqlConnection cnAb, ref string mensaje)
        {
            SqlCommand vocho = null;
            SqlDataReader caja;
            if (cnAb == null)
            {
                caja = null;
                mensaje = "No hay conexion abierta";

            }
            else
            {
                using (vocho = new SqlCommand(querySql, cnAb))
                {
                    try
                    {
                        caja = vocho.ExecuteReader();
                        mensaje = "Consulta correcta";
                    }
                    catch (Exception s)
                    {
                        mensaje = "ERROR" + s.Message;
                        caja = null;
                    }
                }
            }
            return caja;
        }

        public DataSet ConsultaDataSet(string querySql, SqlConnection cnAb, ref string mensaje)
        {
            SqlCommand vocho = null;
            DataSet cajagrande = null;
            SqlDataAdapter trailer = null;
            if (cnAb == null)
            {
                cajagrande = null;
                mensaje = "No hay conexion abierta";

            }
            else
            {
                using (vocho = new SqlCommand(querySql, cnAb))
                {
                    using (trailer = new SqlDataAdapter())
                    {
                        cajagrande = new DataSet();
                        trailer.SelectCommand = vocho;
                        try
                        {
                            trailer.Fill(cajagrande);
                            mensaje = "Consulta correcta";
                        }
                        catch (Exception s)
                        {
                            mensaje = "ERROR" + s.Message;
                            cajagrande = null;
                        }
                    }

                }
                cnAb.Close();
                cnAb.Dispose();
            }
            return cajagrande;
        }

        public Boolean MultiplesConsultasDataset(string querySql, SqlConnection cnAb, ref string mensaje, ref DataSet DsOriginal, string nomConsulta)
        {
            Boolean salida = false;
            SqlCommand vocho = null;
            SqlDataAdapter trailer = null;
            if (cnAb == null)
            {
                mensaje = "No hay conexion abierta";

            }
            else
            {
                using (vocho = new SqlCommand(querySql, cnAb))
                {
                    using (trailer = new SqlDataAdapter())
                    {

                        trailer.SelectCommand = vocho;
                        try
                        {
                            trailer.Fill(DsOriginal, nomConsulta);
                            mensaje = "Consulta correcta";
                            salida = true;
                        }
                        catch (Exception s)
                        {
                            mensaje = "ERROR" + s.Message;
                            salida = false;
                        }
                    }

                }
                cnAb.Close();
                cnAb.Dispose();
            }
            return salida;
        }
    }

}
