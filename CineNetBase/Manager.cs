namespace CineNetBase
{
    #region Referencias
    using System;
    using System.Data;
    using System.Data.Common;
    using System.Diagnostics;
    using System.Reflection;
    using Microsoft.Practices.EnterpriseLibrary.Data;
    using CineEntity;
    using System.Configuration;
    using CineNetEntity;
    #endregion

    /// <summary>
    /// Realiza el manejo de las conexiones y transacciones de la base de datos.
    /// </summary>
    /// <author>Carlos Sosa</author>
    /// <date>Sept 2008</date>
    public class Manager : IDisposable
    {
        protected DbCommand dbCommand;
        Database database;
        DbTransaction transaction;
        DbConnection connection;
        Guid callingTypeGuid;
        ApplicationEntity.EApplication application;
        public CountryEntity.ECountry Country { get; private set; }

        string callingTypeMethod;
        public string Instance { get; set; }
        /// <summary>Devuelve el valor CountryURL necesario para trabajar con wsIBS.</summary>
        public string CountryURL
        {
            get
            {
                //string keyName = Country + "." + Instance;
                return ConfigurationManager.AppSettings["COUNTRYURL"];
            }
        }

        /// <summary>
        /// Url para solicitar token a Api Manager.
        /// </summary>
        public string UrlApiManagerToken
        {
            get
            {
                return ConfigurationManager.AppSettings["URL_APIMANAGER_TOKEN"];
            }
        }

        /// <summary>
        /// Client ID para solicitar token a Api Manager.
        /// </summary>
        public string ClientId
        {
            get
            {
                return ConfigurationManager.AppSettings["CLIENT_ID"];
            }
        }

        /// <summary>
        /// Secret para solicitar token a Api Manager.
        /// </summary>
        public string ClientSecret
        {
            get
            {
                return ConfigurationManager.AppSettings["CLIENT_SECRET"];
            }
        }

        /// <summary>
        /// Grant Type para solicitar token a Api Manager.
        /// </summary>
        public string GrantType
        {
            get
            {
                return ConfigurationManager.AppSettings["GRANT_TYPE"];
            }
        }

        /// <summary>
        /// Patch certificado Api Manager
        /// </summary>
        public string PatchCertificate
        {
            get
            {
                return ConfigurationManager.AppSettings["PATCH_CERTIFICATE"];
            }
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase DirecTV.Data.ConnectionManager para la base de datos databaseName.
        /// </summary>
        /// <author>Carlos Sosa</author>
        /// <date>Oct 2008</date>
        [Obsolete("Debera instanciarse utilizando el constructor Manager(application, usuario)")]
        public Manager(ApplicationEntity.EApplication application, CountryEntity.ECountry country)
        {
            string databaseName;

            this.application = application;
            this.Country = country;
            databaseName = application + "." + country + "." + ConfigurationManager.AppSettings["INSTANCIA"].ToString();
            database = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase(databaseName);
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase DirecTV.Data.ConnectionManager para la base de datos databaseName.
        /// </summary>
        /// <author>Carlos Sosa</author>
        /// <date>Oct 2008</date>
        public Manager(ApplicationEntity.EApplication application, UsuarioEntity usuario)
        {
            try
            {
                string databaseName;

                this.application = application;
                this.Country = usuario.Country.Code;
                databaseName = (usuario.Instance != null && usuario.Instance != string.Empty) ?
                    (application + "." + Country + "." + usuario.Instance) :
                    (application + "." + Country);
                Instance = usuario.Instance;
                database = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory.CreateDatabase(databaseName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Inicializa una nueva instancia de la clase DirecTV.Data.ConnectionManager para la base de datos databaseName.
        /// </summary>
        /// <author>Carlos Sosa</author>
        /// <date>Oct 2008</date>
        public Manager(UsuarioEntity usuario)
        {
            this.Country = usuario.Country.Code;
            Instance = usuario.Instance;
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase DirecTV.Data.ConnectionManager para la base de datos predeterminada.
        /// </summary>
        /// <author>Carlos Sosa</author>
        /// <date>Sept 2008</date>
        [Obsolete("Debera instanciarse utilizando el constructor Manager(application, usuario)")]
        public Manager()
        {
        }

        /// <summary>
        /// Starts the database transaction.
        /// </summary>
        /// <author>Carlos Sosa</author>
        /// <date>Sept 2008</date>
        public bool BeginTransaction()
        {
            if (transaction == null)
            {
                StackTrace st = new StackTrace();
                MethodBase method = st.GetFrame(1).GetMethod();

                connection = database.CreateConnection();
                connection.Open();
                transaction = connection.BeginTransaction();
                callingTypeGuid = method.DeclaringType.GUID;
                callingTypeMethod = method.Name;

                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Commits the transaction to the database.
        /// </summary>
        /// <author>Carlos Sosa</author>
        /// <date>Sept 2008</date>
        public bool CommitTransaction()
        {
            if (IsCallingMethod())
            {
                transaction.Commit();
                transaction = null;
                callingTypeMethod = string.Empty;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Rolls back the transaction from a pending state.
        /// </summary>
        /// <author>Carlos Sosa</author>
        /// <date>Sept 2008</date>
        public bool RollbackTransaction()
        {
            if (IsCallingMethod())
            {
                transaction.Rollback();
                transaction = null;
                callingTypeMethod = string.Empty;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void AddInParameter(string name, DbType dbType, object value)
        {
            database.AddInParameter(dbCommand, name, dbType, value);
        }

        public void AddOutParameter(string name, DbType dbType, int size)
        {
            database.AddOutParameter(dbCommand, name, dbType, size);
        }

        public void AddReturnParameter(DbType dbType, int size)
        {
            database.AddParameter(dbCommand, "@return_value", dbType, ParameterDirection.ReturnValue, String.Empty, DataRowVersion.Default, null);
        }

        public virtual object GetParameterValue(string name)
        {
            return database.GetParameterValue(dbCommand, name);
        }

        public object GetReturnValue()
        {
            return dbCommand.Parameters["@return_value"].Value;
        }

        public virtual void SetParameterValue(string parameterName, object value)
        {
            database.SetParameterValue(dbCommand, parameterName, value);
        }

        /// <summary>
        /// Sends the CommandText and builds a SqlDataReader.
        /// </summary>
        /// <returns>SqlDataReader.</returns>
        /// <author>Carlos Sosa</author>
        public virtual IDataReader ExecuteReader()
        {
            if (transaction == null)
                return database.ExecuteReader(dbCommand);
            else
                return database.ExecuteReader(dbCommand, transaction);
        }

        public void GetStoredProcCommand(string storedProcedureName)
        {
            dbCommand = database.GetStoredProcCommand(storedProcedureName);
        }

        public void GetSqlStringCommand(string stringCommand)
        {
            dbCommand = database.GetSqlStringCommand(stringCommand);
        }

        /// <summary>
        /// Executes the query, and returns the first column of the first row in the result set returned by the query. Additional columns or rows are ignored.
        /// </summary>
        /// <returns>The first column of the first row in the result set returned by the query.</returns>
        /// <author>Carlos Sosa</author>
        public virtual object ExecuteScalar()
        {
            if (transaction == null)
                return database.ExecuteScalar(dbCommand);
            else
                return database.ExecuteScalar(dbCommand, transaction);
        }

        /// <summary>
        /// Executes a Transact-SQL statement against the connection and returns the number of rows affected.
        /// </summary>
        /// <returns>Returns the number of rows affected.</returns>
        /// <author>Carlos Sosa</author>
        public virtual int ExecuteNonQuery()
        {
            if (transaction == null)
                return database.ExecuteNonQuery(dbCommand);
            else
                return database.ExecuteNonQuery(dbCommand, transaction);
        }

        public void LoadDataSet(DataSet dataSet, string tableName)
        {
            database.LoadDataSet(dbCommand, dataSet, tableName);
        }

        public void LoadDataSet(DataSet dataSet, string[] tableNames)
        {
            database.LoadDataSet(dbCommand, dataSet, tableNames);
        }

        /// <summary>
        /// Implementacion de la interfaz IDisposable
        /// </summary>
        /// <author>Carlos Sosa</author>
        /// <date>Sept 2008</date>
        public void Dispose()
        {
            if (IsCallingMethod())
            {
                if (transaction != null)
                    transaction.Dispose();
                if (connection != null)
                {
                    if (connection.State == System.Data.ConnectionState.Open)
                        connection.Close();
                    connection.Dispose();
                }
            }
        }

        private bool IsCallingMethod()
        {
            StackTrace st = new StackTrace();
            MethodBase method = st.GetFrame(2).GetMethod();
            return (callingTypeGuid.Equals(method.DeclaringType.GUID) && callingTypeMethod == method.Name);
        }
        /// <summary>
        /// GetCurrentConnectionString()
        /// </summary>
        /// <returns> seria una forma de publicar la connectionstring para la conexion de hibernate </returns>
        internal string GetCurrentConnectionString()
        {
            return database.ConnectionStringWithoutCredentials;
        }

        public DbConnection GetConnection()
        {
            return connection;
        }
    }
}