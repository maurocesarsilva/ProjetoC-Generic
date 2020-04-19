using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using To;
using Dal;

namespace bll
{
    public class ProdutoBll
    {
       private GenericDal<ProdutoTO> _produtoDal;
        public ProdutoBll()
        {
            _produtoDal = new GenericDal<ProdutoTO>();
        }

        public void cadastrarProduto(ProdutoTO produto)
        {
            _produtoDal.cadastrarProduto(produto);
        }
        public void atualizarProduto(ProdutoTO produto)
        {
            _produtoDal.atualizarProduto(produto);
        }
        public void deletarProduto(ProdutoTO produto)
        {
            _produtoDal.deletarProduto(produto);
        }
        public List<ProdutoTO> getProdutoTvp(List<int> IDs)
        {
            return _produtoDal.getProdutoTvp(IDs);
        }
        public List<ProdutoTO> getAll(FiltroPaginacao filtroPag)
        {
            return _produtoDal.getAll(filtroPag);
        }
        public List<ProdutoTO> getAll()
        {
            return _produtoDal.getAll();
        }
        public ProdutoTO getByiId(int id)
        {
            return _produtoDal.getById(id);
        }
    }
}
