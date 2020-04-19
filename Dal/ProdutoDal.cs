using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using To;
using Dapper.Contrib.Extensions;
using Dapper;
using System.Reflection;

namespace Dal
{
    public class ProdutoDal<T> : DBConn where T : class
    {
        public ProdutoDal()
        {

        }

        public void cadastrarProduto(T obj)
        {
            conn.Insert(obj);
        }
        public void atualizarProduto(T obj)
        {
            conn.Update(obj);
        }
        public void deletarProduto(T obj)
        {
            conn.Delete(obj);
        }
        public List<T> getProdutoTvp(List<int> IDs)
        {
            var tabelaTVP = GetGenericTVP(IDs.ToArray());
            var tableName = typeof(T).GetCustomAttribute<TableAttribute>();

            string sqlQuery = $@"select * from {tableName} c
                               INNER JOIN @tvp t on t.id = c.id";

            var retorno = conn.Query<T>(sqlQuery,new { tvp = tabelaTVP.AsTableValuedParameter(_TVPType), tableName }, commandTimeout: int.MaxValue).ToList();
            return retorno;
        }

        public List<T> getAll()
        {
            return conn.GetAll<T>().ToList();
        }

        public T getById(int id)
        {
            return conn.Get<T>(id);

        }
        public T getByAllDapper(int id)
        {
            var tableName = typeof(T).GetCustomAttribute<TableAttribute>().Name;//pega nome da tabela
            //que foi definido no objeto pelo parameto do dapper

            string sql = $@"select * from {tableName}";

            var retorno =  conn.Query<T>(sql).ToList();

            return retorno.FirstOrDefault();
        }

    }
}
