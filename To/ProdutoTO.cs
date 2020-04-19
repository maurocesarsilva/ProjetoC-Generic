using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace To
{
    [Table("cadProduto")]
    public class ProdutoTO
    {
        public ProdutoTO()
        {

        }
        [Key]
        public int id { get; set; }
        public string nome { get; set; }
        public double? valor { get; set; }
        public int qtdReg { get; set; }

    }
}
