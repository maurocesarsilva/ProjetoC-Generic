using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace To
{
   public class FiltroPaginacao
    {
        public int? Pagina { get; set; }
        public int RegPorPagina { get; set; }

        public string GetOver()
        {
            return Pagina == 0 ? ", COUNT(*) over() as qtdReg" : string.Empty;

        }

        public string GetFetchNext()
        {
            string SqlFetchNext = "";
            if (Pagina != null)
            {
                var Offset = Pagina * RegPorPagina + 1;
                SqlFetchNext = $@" OFFSET {Offset} ROWS  
                                  FETCH NEXT {RegPorPagina}
                                  ROWS ONLY";
            }
            return SqlFetchNext;
        }
    }
}
