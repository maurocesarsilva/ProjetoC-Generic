using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using To;
using Dapper.Contrib.Extensions;
using Dapper;
using System.Reflection;

//https://medium.com/@felipesibh/reposit%C3%B3rio-gen%C3%A9rico-com-dapper-4aa53a4e82a0
//Link doc dapper metos genericos
namespace Dal
{
    public class GenericDal<T> : DBConn where T : class
    {
        public GenericDal()
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

            string sqlQuery = $@"select * from cadProduto c
                               INNER JOIN @tvp t on t.id = c.id";

            var retorno = conn.Query<T>(sqlQuery, new { tvp = tabelaTVP.AsTableValuedParameter(_TVPType) }, commandTimeout: int.MaxValue).ToList();
            return retorno;
            /*
             Para Tvp funcionar é preciso criar uma tabela temporario no sql server
             Tabela:
              CREATE TYPE GenericTVP AS TABLE
              ( Id bigint NULL)
              //Preciso na tablea tvp temporaria ter os mesmos parametros criados no data table do metodo  
              GetGenericTVP() da linha 34
              */
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
            var tableName = typeof(T).GetCustomAttribute<TableAttribute>().Name;
            //pega nome da tabela que foi definido no objeto pelo parameto do dapper

            string sql = $@"select * from {tableName}";

            var retorno = conn.Query<T>(sql).ToList();

            return retorno.FirstOrDefault();
        }

    }
}
