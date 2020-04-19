using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using To;
using bll;

namespace ProjetoWebForms.Admin
{
    public partial class CadProduto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lkbCadastro_Click(object sender, EventArgs e)
        {
            try
            {
                ProdutoBll produtoBll = new ProdutoBll();

                ProdutoTO produtoTo = new ProdutoTO
                {
                    nome = txtNomeProd.Text,
                    valor = Convert.ToDouble(txtValor.Text)
                };

                produtoBll.cadastrarProduto(produtoTo);
                ucAlertas.ShowSuccess("Cadastrado com sucesso");
            }
            catch (Exception ex)
            {
                ucAlertas.ShowErrors(ex.Message);
            }
        }

        protected void lkbAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                ProdutoBll produtoBll = new ProdutoBll();

                ProdutoTO produtoTo = new ProdutoTO
                {
                    id = Convert.ToInt32(txtId.Text),
                    nome = txtNomeProd.Text,
                   // valor = Convert.ToDouble(txtValor.Text)
                };

                produtoBll.atualizarProduto(produtoTo);
                ucAlertas.ShowSuccess("Atualizado com sucesso");
            }
            catch (Exception ex)
            {
                ucAlertas.ShowErrors(ex.Message);
            }
        }

        protected void lkbDeletar_Click(object sender, EventArgs e)
        {
            try
            {
                ProdutoBll produtoBll = new ProdutoBll();

                ProdutoTO produtoTo = new ProdutoTO
                {
                    id = Convert.ToInt32(txtId.Text),
                    nome = txtNomeProd.Text,
                    valor = Convert.ToDouble(txtValor.Text)
                };

                produtoBll.deletarProduto(produtoTo);
                ucAlertas.ShowSuccess("Deletado com sucesso");
            }
            catch (Exception ex)
            {
                ucAlertas.ShowErrors(ex.Message);
            }
        }

        protected List<ProdutoTO> getProdutosTvp()
        {
            ProdutoBll produtoBll = new ProdutoBll();
            List<int> ids = new List<int>();
            ids.Add(2);
            ids.Add(3);
            ids.Add(4);

            return produtoBll.getProdutoTvp(ids);
        }

        protected void lkbtvp_Click(object sender, EventArgs e)
        {
            var retorno = getProdutosTvp();
        }

        protected void lkbTodos_Click(object sender, EventArgs e)
        {
            ProdutoBll produtoBll = new ProdutoBll();
             var retorno = produtoBll.getAll();

        }

        protected void lkbid_Click(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(txtId.Text);
            ProdutoBll produtoBll = new ProdutoBll();
            var retorno = produtoBll.getByiId(id);
        }
    }
}