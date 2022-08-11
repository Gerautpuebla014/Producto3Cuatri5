using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using LibreriaAccesoaDatos;
using CapaEntidad;

namespace ClassLibrary1
{
    public class CapaNegocios
    {
        private AccesoSQL operacion = null;
        public CapaNegocios(string cadconexion)   
        {
            operacion = new AccesoSQL(cadconexion);
        }
        public string MiMessageBox(string titulo, string msg, short tip)
        {
            string icono = "";
            switch (tip)
            {
                case 1:
                    icono = "'info'";
                    break;
                case 2:
                    icono = "'success'";
                    break;
                case 3:
                    icono = "'error'";
                    break;
                case 4:
                    icono = "'question'";
                    break;
            }
            string functionjs = "Mensaje('" + titulo + "','" + msg + "'," + icono + ");";
            return functionjs;
        }
        public Boolean InsertarMarca( string Marca, ref string m)
        {
            string sentencia = "insert into Marca(Marca) values (@Marca);";
            SqlParameter[] coleccion = new SqlParameter[]
            {
                
                new SqlParameter("Marca",SqlDbType.VarChar,120)
                
            };
            coleccion[0].Value = Marca;
            
            Boolean salida = false;
            operacion.ModificarBDMasseguro(sentencia, operacion.Abrirconexion(ref m), ref m, coleccion);
            return salida;
        }

        public Boolean InsertarCategoria( string NombreCate, string Descripcion, ref string m)
        {
            string sentencia = "insert into Categoria (NombreCate,Descripcion) values (@categoria,@descripcion);";
            SqlParameter[] coleccion = new SqlParameter[]
            {
                
                new SqlParameter("categoria",SqlDbType.VarChar,120),
                new SqlParameter("descripcion",SqlDbType.VarChar,250)
                
            };
            coleccion[0].Value = NombreCate;
            coleccion[1].Value = Descripcion;
            Boolean salida = false;
            operacion.ModificarBDMasseguro(sentencia, operacion.Abrirconexion(ref m), ref m, coleccion);
            return salida;
        }

        public Boolean InsertarComponenteGenerico(string Nombre, string Descripcion, string ClaveSAT, string CodUnidad, int PiezasAlmacen, int F_Marca, int F_Categoria, ref string m)
        {
            string sentencia = "insert into ComponenteGenerico (Nombre,Descripcion,ClaveSAT,CodUnidad,PiezasAlmacen,F_Marca,F_Categoria) values (@nombre,@descripcion,@clavesat,@codunidad,@piezas,@marca,@categoria);";
            SqlParameter[] coleccion = new SqlParameter[]
            {
                new SqlParameter("nombre",SqlDbType.VarChar,160),
                new SqlParameter("descripcion",SqlDbType.VarChar,300),
                new SqlParameter("clavesat",SqlDbType.VarChar,20),
                new SqlParameter("codunidad",SqlDbType.VarChar,50),
                new SqlParameter("piezas",SqlDbType.Int),
                new SqlParameter("marca",SqlDbType.Int),
                new SqlParameter("categoria",SqlDbType.Int)
            };
            coleccion[0].Value = Nombre;
            coleccion[1].Value = Descripcion;
            coleccion[2].Value = ClaveSAT;
            coleccion[3].Value = CodUnidad;
            coleccion[4].Value = PiezasAlmacen;
            coleccion[5].Value = F_Marca;
            coleccion[6].Value = F_Categoria;

            Boolean salida = false;
            operacion.ModificarBDMasseguro(sentencia, operacion.Abrirconexion(ref m), ref m, coleccion);
            return salida;
        }
        public DataTable obtentodasMarcas(ref string mensaje)
        {
            string consulta = "select * from Marca;";
            DataSet obtener = null;
            DataTable salida = null;
            obtener = operacion.ConsultaDataSet(consulta, operacion.Abrirconexion(ref mensaje), ref mensaje);

            if (obtener != null)
            {
                salida = obtener.Tables[0];
            }
            return salida;
        }
        public DataTable obtentodasCategoria(ref string mensaje)
        {
            string consulta = "select * from Categoria;";
            DataSet obtener = null;
            DataTable salida = null;
            obtener = operacion.ConsultaDataSet(consulta, operacion.Abrirconexion(ref mensaje), ref mensaje);

            if (obtener != null)
            {
                salida = obtener.Tables[0];
            }
            return salida;
        }

        
        public DataTable obtentodosComponentesG(ref string mensaje)
        {
            string consulta = "select * from ComponenteGenerico;";
            DataSet obtener = null;
            DataTable salida = null;
            obtener = operacion.ConsultaDataSet(consulta, operacion.Abrirconexion(ref mensaje), ref mensaje);

            if (obtener != null)
            {
                salida = obtener.Tables[0];
            }
            return salida;
        }
        public DataTable obtentodosProveedores(ref string mensaje)
        {
            string consulta = "select * from Proveedor;";
            DataSet obtener = null;
            DataTable salida = null;
            obtener = operacion.ConsultaDataSet(consulta, operacion.Abrirconexion(ref mensaje), ref mensaje);

            if (obtener != null)
            {
                salida = obtener.Tables[0];
            }
            return salida;
        }

        public DataTable obtenEstados(ref string mensaje)
        {
            string consulta = "select* from EstadoComponente;";
            DataSet obtener = null;
            DataTable salida = null;
            obtener = operacion.ConsultaDataSet(consulta, operacion.Abrirconexion(ref mensaje), ref mensaje);

            if (obtener != null)
            {
                salida = obtener.Tables[0];
            }
            return salida;
        }

        public Boolean ModificarMarca(int id_Marca, string Marca, ref string m)
        {
            string sentencia = "UPDATE Marca SET Marca='" + Marca + "' where id_Marca =" + id_Marca + ";";
            Boolean salida = false;
            operacion.ModificarBD(sentencia, operacion.Abrirconexion(ref m), ref m);
            return salida;
        }
        public Boolean EliminarMarca(int id_Marca, ref string m)
        {
            string sentencia = "DELETE from Marca where id_Marca =" + id_Marca + ";";
            Boolean salida = false;
            operacion.ModificarBD(sentencia, operacion.Abrirconexion(ref m), ref m);
            return salida;
        }
        public Boolean ModificarCategoria(int id_Categoria, string NombreCate, ref string m)
        {
            string sentencia = "UPDATE Categoria SET NombreCate='" + NombreCate + "' where id_Categoria =" + id_Categoria + ";";
            Boolean salida = false;
            operacion.ModificarBD(sentencia, operacion.Abrirconexion(ref m), ref m);
            return salida;
        }

        public Boolean ModificarComponente(int id_Componente, int piezasAlmacen, ref string m)
        {
            string sentencia = "UPDATE ComponenteGenerico SET piezasAlmacen='" + piezasAlmacen + "' where id_Componente =" + id_Componente + ";";
            Boolean salida = false;
            operacion.ModificarBD(sentencia, operacion.Abrirconexion(ref m), ref m);
            return salida;
        }
        public Boolean EliminarCategoria(int id_Categoria, ref string m)
        {
            string sentencia = "DELETE from Categoria where id_Categoria =" + id_Categoria + ";";
            Boolean salida = false;
            operacion.ModificarBD(sentencia, operacion.Abrirconexion(ref m), ref m);
            return salida;
        }
        public Boolean EliminarComponente(int id_Componente, ref string m)
        {
            string sentencia = "DELETE from ComponenteGenerico where id_Componente =" + id_Componente + ";";
            Boolean salida = false;
            operacion.ModificarBD(sentencia, operacion.Abrirconexion(ref m), ref m);
            return salida;
        }
        public Boolean InsertarFacturaCompra(string Folio, DateTime Fecha, int F_Proveedor, string AnotacionExtra, ref string m)
        {
            string sentencia = "insert into FacturaCompra(Folio,Fecha,F_Proveedor,AnotacionExtra) values (@folio,@fecha,@f_prove,@anotacion);";
            SqlParameter[] coleccion = new SqlParameter[]
            {
                new SqlParameter("folio",SqlDbType.VarChar,50),
                new SqlParameter("fecha",SqlDbType.Date),
                new SqlParameter("f_prove",SqlDbType.Int),
                new SqlParameter("anotacion",SqlDbType.VarChar,60)
            };
            coleccion[0].Value = Folio;
            coleccion[1].Value = Fecha;
            coleccion[2].Value = F_Proveedor;
            coleccion[3].Value = AnotacionExtra;

            Boolean salida = false;
            operacion.ModificarBDMasseguro(sentencia, operacion.Abrirconexion(ref m), ref m, coleccion);
            return salida;
        }
        public DataTable obtenFacturaC(ref string mensaje)
        {
            string consulta = "select * from FacturaCompra;";
            DataSet obtener = null;
            DataTable salida = null;
            obtener = operacion.ConsultaDataSet(consulta, operacion.Abrirconexion(ref mensaje), ref mensaje);

            if (obtener != null)
            {
                salida = obtener.Tables[0];
            }
            return salida;
        }
        public Boolean InsertarContenidoFactura(decimal PrecioCompra, string NumSerie, int Estado, int F_factura,int F_Componente, ref string m)
        {
            string sentencia = "insert into ContenidoFactura(PrecioCompra,NumSerie,Estado,F_factura,F_Componente) values (@precioC,@NumS,@Esta,@F_fac,@F_Comp);";
            SqlParameter[] coleccion = new SqlParameter[]
            {
                new SqlParameter("precioC",SqlDbType.Money),
                new SqlParameter("NumS",SqlDbType.VarChar,(50)),
                new SqlParameter("Esta",SqlDbType.SmallInt),
                new SqlParameter("F_fac",SqlDbType.Int),
                new SqlParameter("F_Comp",SqlDbType.Int)

            };
            coleccion[0].Value = PrecioCompra;
            coleccion[1].Value = NumSerie;
            coleccion[2].Value = Estado;
            coleccion[3].Value = F_factura;
            coleccion[4].Value = F_Componente;
            

            Boolean salida = false;
            operacion.ModificarBDMasseguro(sentencia, operacion.Abrirconexion(ref m), ref m, coleccion);
            return salida;
        }

        public DataTable obtenFacturaFolio(string Folio ,ref string mensaje)
        {
            string consulta = "select * from FacturaCompra where Folio = '" + Folio + "';";
            DataSet obtener = null;
            DataTable salida = null;
            obtener = operacion.ConsultaDataSet(consulta, operacion.Abrirconexion(ref mensaje), ref mensaje);

            if (obtener != null)
            {
                salida = obtener.Tables[0];
            }
            return salida;
        }

        public DataTable DetallesFactura(string NumSerie, ref string mensaje)
        {
            string consulta = "Select C.NumSerie, A.Nombre AS 'Nombre del componente', T.NombreCate AS 'Categoria', F.Fecha AS 'Fecha Adquirido', P.NombreProvee AS 'Proveedor', P.Telefono AS 'Tel. proveedor', E.Estado  FROM ContenidoFactura C " +
                "INNER JOIN ComponenteGenerico A ON C.F_Componente = A.Id_Componente INNER JOIN Categoria T ON A.F_Categoria = T.Id_Categoria INNER JOIN FacturaCompra F ON C.F_factura = F.Id_Factura INNER JOIN Proveedor P ON F.F_Proveedor = P.Id_Provee " +
                "INNER JOIN EstadoComponente E ON C.Estado = E.Id_Estado Where C.NumSerie ='" +NumSerie + "';";
            DataSet obtener = null;
            DataTable salida = null;
            obtener = operacion.ConsultaDataSet(consulta, operacion.Abrirconexion(ref mensaje), ref mensaje);

            if (obtener != null)
            {
                salida = obtener.Tables[0];
            }
            return salida;
        }
        
        public DataTable obtenFolios(ref string mensaje)
        {
            string consulta = "select Id_Factura , Folio from FacturaCompra;";
            DataSet obtener = null;
            DataTable salida = null;
            obtener = operacion.ConsultaDataSet(consulta, operacion.Abrirconexion(ref mensaje), ref mensaje);

            if (obtener != null)
            {
                salida = obtener.Tables[0];
            }
            return salida;
        }
        public DataTable obtenNumSerie(ref string mensaje)
        {
            string consulta = "select id_Cont, NumSerie from ContenidoFactura;";
            DataSet obtener = null;
            DataTable salida = null;
            obtener = operacion.ConsultaDataSet(consulta, operacion.Abrirconexion(ref mensaje), ref mensaje);

            if (obtener != null)
            {
                salida = obtener.Tables[0];
            }
            return salida;
        }


    }

}
