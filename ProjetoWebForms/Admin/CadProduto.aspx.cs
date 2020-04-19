using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using To;
using bll;
using Util;
using System.Data;

using System.Data;
using System.IO;
using System.Net;
using System.Web;

namespace ProjetoWebForms.Admin
{
    public partial class CadProduto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            grid.PagerTemplate =  new GridPageHelper(grid); //para formatar pagiação do grid
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
            _loadGrid(0);
        }

        protected void lkbid_Click(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(txtId.Text);
            ProdutoBll produtoBll = new ProdutoBll();
            var retorno = produtoBll.getByiId(id);
        }

        protected void grid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grid.PageIndex = e.NewPageIndex;
            _loadGrid(e.NewPageIndex);
        }

        private void _loadGrid(int paginaCorrente)
        {
            try
            {
                ProdutoBll produtoBll = new ProdutoBll();
                FiltroPaginacao filtroPag = new FiltroPaginacao()
                {
                    Pagina = paginaCorrente,
                    RegPorPagina = 10
                };

                var retorno = produtoBll.getAll(filtroPag);
                if (paginaCorrente == 0)
                {
                    grid.VirtualItemCount = retorno[0].qtdReg;
                }
                grid.PageSize = 10;
                grid.DataSource = retorno;
                grid.DataBind();
            }
            catch (Exception ex)
            {
                ucAlertas.ShowErrors(ex.Message);
            }
        }

        protected void lkbExcel_Click(object sender, EventArgs e)
        {
            try
            {
                var ca = Exportar.Text;
                ProdutoBll produtoBll = new ProdutoBll();
                var retorno = produtoBll.getAll();

                if (retorno == null || retorno.Count == 0)
                {
                    throw new ArgumentException("Nenhum registro encontrado! ");
                }
                else
                {
                    var tabela = retorno.ToDataTable();
                    var caminho = "C:\\Users\\maurocésar\\Desktop\\Excel.xlsx";
                    TabelasHelper.GerarArquivoExcel(tabela, "Tabela", caminho);
                }
            }
            catch (ArgumentException a)
            {
                ucAlertas.ShowAlerta(a.Message);
            }
            catch (Exception ex)
            {
                ucAlertas.ShowErrors("Erro ao exportar excel: " + ex.Message);
            }
        }
    }
}