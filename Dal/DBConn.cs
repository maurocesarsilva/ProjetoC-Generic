using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Configuration;


namespace Dal
{
    public class DBConn
    {
        private static readonly string conString = ConfigurationManager.ConnectionStrings["Banco"].ConnectionString;

        private readonly string _clienteConnection = ConfigurationManager.ConnectionStrings["Banco"]?.ConnectionString;
        protected readonly string _TVPType = "GenericTVP";

        protected SqlConnection conn;

        public DBConn()
        {
            conn = new SqlConnection(conString);
        }

        public DBConn(string dbName)
        {
            conn = new SqlConnection(clienteConnection(dbName));
        }


        public string clienteConnection(string dbName)
        {
            return string.Format(_clienteConnection, dbName);
        }

        /// <summary>
        /// Devolve um datatable com uma tabela TVP Genérica, usada em Updates em lote.
        /// </summary>
        /// <param name="genericIDs"></param>
        /// <returns></returns>
        protected DataTable GetGenericTVPLong(long[] genericIDs)
        {
            var tabela = new DataTable();
            tabela.Columns.Add(new DataColumn("Id", typeof(long)));

            foreach (long id in genericIDs)
            {
                var row = tabela.NewRow();
                row["Id"] = id;
                tabela.Rows.Add(row);
            }

            return tabela;
        }

        /// <summary>
        /// metodo criado para evitar reencrita de codigo
        /// </summary>
        /// <param name="genericIDs"></param>
        /// <returns></returns>
        protected DataTable GetGenericTVP(int[] genericIDs)
        {
            return GetGenericTVPLong(genericIDs.Select(item => (long)item).ToArray());
        }


        /// <summary>
        /// Devolve um datatable com uma tabela TVP Genérica, usada em Updates em lote.
        /// </summary>
        /// <param name="genericIDs"></param>
        /// <returns></returns>
        protected DataTable GetGenericTVP(Dictionary<int, int> genericIDs)
        {
            var tabela = new DataTable();
            tabela.Columns.Add(new DataColumn("Id", typeof(long)));
            tabela.Columns.Add(new DataColumn("ValorAlterar", typeof(long)));

            foreach (var item in genericIDs)
            {
                var row = tabela.NewRow();
                row["Id"] = item.Key;
                row["ValorAlterar"] = item.Value;
                tabela.Rows.Add(row);
            }

            return tabela;
        }

        /// <summary>
        /// Override do metodo acima recebendo um dicionário de LONG e int, levando em conta que o banco aceita os dois
        /// </summary>
        /// <param name="genericIDs"></param>
        /// <returns></returns>
        protected DataTable GetGenericTVP(Dictionary<long, int> genericIDs)
        {
            var tabela = new DataTable();
            tabela.Columns.Add(new DataColumn("Id", typeof(long)));
            tabela.Columns.Add(new DataColumn("ValorAlterar", typeof(long)));

            foreach (var item in genericIDs)
            {
                var row = tabela.NewRow();
                row["Id"] = item.Key;
                row["ValorAlterar"] = item.Value;
                tabela.Rows.Add(row);
            }

            return tabela;
        }   
    }
}