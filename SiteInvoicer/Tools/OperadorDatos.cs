using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
    /// <summary>
    /// Clase que permite la conexión y la persistencia con la base de datos
    /// </summary>
    public class OperadorDatos
    {
        #region<<Campos Privados de la Clase>>

        private string p_Servidor = string.Empty;
        private string p_Base = string.Empty;
        private string p_Usuario = string.Empty;
        private int p_CodigoUsuario = -1;
        private string p_Clave = string.Empty;
        private string p_Maquina = string.Empty;
        private SqlCommand oCommand = null;
        private string p_Accion = string.Empty;
        private string p_NombreSp = string.Empty;
        protected string cadena_conexion = string.Empty;
        protected SqlConnection oConexion = null;
        protected SqlTransaction oTran = null;
        protected string TranName = "transaccion";
        protected string SQLString = string.Empty;

        #endregion

        #region<<Propiedades Públicas de la Clase>>

        public string Servidor
        {
            get
            {
                return this.p_Servidor;
            }
            set
            {
                if (value == string.Empty)
                    throw new ArgumentNullException("Servidor",
                        "El Sevidor no puede ser nulo");
                this.p_Servidor = value;
            }
        }

        public string Base
        {
            get
            {
                return this.p_Base;
            }
            set
            {
                if (value == string.Empty)
                    throw new ArgumentNullException("Base",
                        "La base no puede ser nula");
                this.p_Base = value;
            }
        }

        public int CodigoUsuario
        {
            get
            {
                return this.p_CodigoUsuario;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentNullException("Codigo Usuario",
                        "El codigo del usuario no puede ser negativo");
                this.p_CodigoUsuario = value;
            }
        }

        public string Usuario
        {
            get
            {
                return this.p_Usuario;
            }
            set
            {
                if (value == string.Empty)
                    throw new ArgumentNullException("Usuario",
                        "El usuario no puede ser nulo");
                this.p_Usuario = value;
            }
        }

        public string Clave
        {
            get
            {
                return this.p_Clave;
            }
            set
            {
                if (value == string.Empty)
                    throw new ArgumentNullException("Clave",
                        "La clave no puede ser nula");
                this.p_Clave = value;
            }
        }

        public string Maquina
        {
            get
            {
                return this.p_Maquina;
            }
            set
            {
                if (value == string.Empty)
                    throw new ArgumentNullException("Maquina",
                        "El Nombre de la Maquina no puede ser nulo");
                this.p_Maquina = value;
            }
        }

        public string NombreProcedimiento
        {
            get
            {
                return this.oCommand.CommandText;
            }
            set
            {
                if (value == string.Empty)
                    throw new ArgumentNullException("NombreProcedimiento",
                        "El nombre del procedimiento no puede ser nulo");
                this.oCommand.CommandText = value;
            }
        }

        public string InstruccionSQL
        {
            get
            {
                return this.SQLString;
            }
            set
            {
                this.SQLString = value;
            }
        }

        public string CadenaConexion
        {
            get
            {
                return this.cadena_conexion;
            }
            set
            {
                this.cadena_conexion = value;
            }
        }

        #endregion

        #region<<Métodos Públicos de la Clase>>

        public void BeginTran()
        {
            //if (TransactionName == string.Empty)
            //    TranName = "transaccion";
            //else
            //    TranName = TransactionName;
            this.oConexion.ConnectionString = this.CadenaConexion;
            this.oConexion.Open();
            this.oTran = this.oConexion.BeginTransaction(TranName);
        }

        public void CommitTran()
        {
            this.oTran.Commit();
            this.oConexion.Close();
            this.oTran = null;
        }

        public void AgregarParametro(string Nombre, object Valor)
        {
            this.oCommand.Parameters.AddWithValue(Nombre, Valor);
        }

        public void CerrarConexion()
        {
            this.oConexion.Close();
        }

        public DataSet RetornarDataSet()
        {
            //SqlConnection oConexion;
            //oConexion = new SqlConnection(this.CadenaConexion);
            this.oConexion.ConnectionString = this.CadenaConexion;
            this.oCommand.Connection = oConexion;
            SqlDataAdapter oDataAdapter;
            oDataAdapter = new SqlDataAdapter(this.oCommand);

            DataSet oDataSet;

            try
            {
                oConexion.Open();
                oDataSet = new DataSet();
                oDataAdapter.Fill(oDataSet);
            }
            catch (SqlException ex)
            {
                this.oCommand.Parameters.Clear();
                throw ex;
            }
            finally
            {
                oConexion.Close();
            }

            this.oCommand.Parameters.Clear();

            return oDataSet;
        }

        public DataSet RetornarDataSet2()
        {
            //SqlConnection oConexion;
            //oConexion = new SqlConnection(this.CadenaConexion);
            if (this.oConexion.State != ConnectionState.Open)
            {
                this.oConexion.ConnectionString = this.CadenaConexion;
                this.oCommand.Connection = oConexion;
                this.oConexion.Open();
            }
            SqlDataAdapter oDataAdapter;
            oDataAdapter = new SqlDataAdapter(this.oCommand);

            DataSet oDataSet;

            try
            {

                oDataSet = new DataSet();
                oDataAdapter.Fill(oDataSet);
            }
            catch (SqlException ex)
            {
                this.oCommand.Parameters.Clear();
                throw ex;
            }
            finally
            {

            }

            this.oCommand.Parameters.Clear();

            return oDataSet;
        }

        public DataTable RetornarTabla()
        {
            DataSet ds = this.RetornarDataSet();
            if (ds.Tables.Count > 0)
                return ds.Tables[0];
            else
                return null;
        }

        public DataTable RetornarTabla2()
        {
            DataSet ds = this.RetornarDataSet2();
            if (ds.Tables.Count > 0)
                return ds.Tables[0];
            else
                return null;
        }

        public DataRow RetornarFila()
        {
            DataTable dt = this.RetornarTabla();
            if (dt.Rows.Count > 0)
                return dt.Rows[0];
            else
                return null;
        }

        public int RetornarValor()
        {

            //DateTime dtInicio = DateTime.Now; 
            //SqlConnection oConexion;
            //oConexion = new SqlConnection(this.CadenaConexion);
            if (this.oConexion.State != ConnectionState.Open)
                this.oConexion.ConnectionString = this.CadenaConexion;

            this.oCommand.Connection = oConexion;
            this.oCommand.Transaction = this.oTran;
            SqlDataAdapter oDataAdapter;
            oDataAdapter = new SqlDataAdapter(this.oCommand);

            int Valor;

            try
            {
                if (this.oConexion.State != ConnectionState.Open)
                    oConexion.Open();
                Valor = Convert.ToInt32(this.oCommand.ExecuteScalar());
            }
            catch (SqlException ex)
            {
                if (this.oTran != null)
                    this.oTran.Rollback(this.TranName);
                this.oCommand.Parameters.Clear();
                throw ex;
            }

            this.oCommand.Parameters.Clear();
            //this.oConexion.Close();
            if (this.oTran == null)
                this.oConexion.Close();

            return Valor;
        }

        public string RetornarValorString()
        {

            //SqlConnection oConexion;
            //oConexion = new SqlConnection(this.CadenaConexion);
            if (string.IsNullOrEmpty(this.oConexion.ConnectionString))
            {
                this.oConexion.ConnectionString = this.CadenaConexion;
            }


            this.oCommand.Connection = oConexion;
            SqlDataAdapter oDataAdapter;
            oDataAdapter = new SqlDataAdapter(this.oCommand);

            string Valor;
            SqlDataReader reader;

            try
            {

                if (this.oConexion.State != ConnectionState.Open)
                    oConexion.Open();
                reader = this.oCommand.ExecuteReader();
                if (reader.Read())
                {
                    Valor = reader[0].ToString();
                }
                else
                {
                    Valor = "";
                }
            }
            catch (SqlException ex)
            {
                this.oCommand.Parameters.Clear();
                throw ex;
            }
            this.oCommand.Parameters.Clear();
            //this.oConexion.Close();
            if (this.oTran == null)
                this.oConexion.Close();
            reader.Close();
            return Valor;
        }

        public void EjecutarNonQuery()
        {
            //DateTime dtInicio = DateTime.Now;
            //SqlConnection oConexion;
            //oConexion = new SqlConnection(this.CadenaConexion);
            if (this.oConexion.State != ConnectionState.Open)
                this.oConexion.ConnectionString = this.CadenaConexion;

            this.oCommand.Connection = oConexion;
            this.oCommand.Transaction = this.oTran;
            SqlDataAdapter oDataAdapter;
            oDataAdapter = new SqlDataAdapter(this.oCommand);

            try
            {
                if (this.oConexion.State != ConnectionState.Open)
                    oConexion.Open();
                this.oCommand.ExecuteNonQuery();
                if (this.oTran == null)
                    this.oConexion.Close();
                //this.oConexion.Close();
            }
            catch (SqlException ex)
            {
                if (this.oTran != null)
                    this.oTran.Rollback(this.TranName);
                this.oCommand.Parameters.Clear();
                if (this.oConexion.State == ConnectionState.Open)
                {
                    this.oConexion.Close();
                }
                throw ex;
            }

            this.oCommand.Parameters.Clear();
        }

        #endregion

        #region<<Métodos Internos de la Clase>>

        #endregion

        #region<<Constructores de la Clase>>
        public OperadorDatos()
        {
            this.oConexion = new SqlConnection();
            this.oCommand = new SqlCommand();
            this.oCommand.CommandType = CommandType.StoredProcedure;
            this.oCommand.CommandTimeout = 120;
        }

        public OperadorDatos(string NombreTransaccion)
        {
            this.TranName = NombreTransaccion;
            this.oConexion = new SqlConnection();
            this.oCommand = new SqlCommand();
            this.oCommand.CommandType = CommandType.StoredProcedure;
            this.oCommand.CommandTimeout = 120;
        }

        #endregion
    }
}
