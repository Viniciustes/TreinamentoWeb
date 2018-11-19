using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TreinamentoWeb.Apresentacao.Forms.ViewModels;
using TreinamentoWeb.Repositorio.Repositorio;

namespace TreinamentoWeb.Apresentacao.Forms
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            PreencherDataGridViewMarcasAsync();
            PreencherDataGridViewProdutosAsync();
        }

        private async void PreencherDataGridViewMarcasAsync()
        {
            var repositorio = new RepositorioMarca();
            var marcas = await repositorio.BuscarTodos();
            var viewModels = new List<MarcaViewModel>();

            foreach (var marca in marcas)
            {
                var marcaViewModel = new MarcaViewModel
                {
                    Id = marca.Id,
                    Nome = marca.Nome
                };
                viewModels.Add(marcaViewModel);
            }

            dgvMarcas.Invoke((MethodInvoker)delegate
            {
                dgvMarcas.DataSource = viewModels;
                dgvMarcas.Refresh();
            });
        }

        private async void PreencherDataGridViewProdutosAsync()
        {
            var repositorio = new RepositorioProduto();
            var produtos = await repositorio.BuscarTodos();
            var viewModels = new List<ProdutoViewModel>();

            foreach (var produto in produtos)
            {
                var produtoViewModel = new ProdutoViewModel
                {
                    Id = produto.Id,
                    Nome = produto.Nome,
                    IdMarca = produto.IdMarca,
                    Marca = produto.Marca.Nome
                };
                viewModels.Add(produtoViewModel);
            }

            dgvProdutos.Invoke((MethodInvoker)delegate
            {
                dgvProdutos.DataSource = viewModels;
                dgvProdutos.Refresh();
            });
        }

        private void BtnCadastrarMarca_Click(object sender, EventArgs e)
        {
            var frmMarca = new FrmMarca();
            frmMarca.ShowDialog();
            PreencherDataGridViewMarcasAsync();
        }

        private void BtnCadastrarProduto_Click(object sender, EventArgs e)
        {
            var frmProduto = new FrmProduto();
            frmProduto.ShowDialog();
            PreencherDataGridViewProdutosAsync();
        }

        private void BtnAlterarMarca_Click(object sender, EventArgs e)
        {
            if (dgvMarcas.SelectedRows.Count > 0)
            {
                var idMarca = (int)dgvMarcas.SelectedRows[0].Cells[0].Value;
                var repositorio = new RepositorioMarca();
                var marca = repositorio.BuscarPorId(idMarca);
                var frmMarca = new FrmMarca(marca);
                frmMarca.ShowDialog();
                PreencherDataGridViewMarcasAsync();
                PreencherDataGridViewProdutosAsync();
            }
            else
            {
                MessageBox.Show("Selecione a marca para alteração.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnAlterarProduto_Click(object sender, EventArgs e)
        {
            if (dgvProdutos.SelectedRows.Count > 0)
            {
                var idPrpoduto = (int)dgvProdutos.SelectedRows[0].Cells[0].Value;
                var repositorio = new RepositorioProduto();
                var produto = repositorio.BuscarPorId(idPrpoduto);
                var frmProduto = new FrmProduto(produto);
                frmProduto.ShowDialog();
                PreencherDataGridViewProdutosAsync();
            }
            else
            {
                MessageBox.Show("Selecione o produto para alteração.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnExcluirMarca_Click(object sender, EventArgs e)
        {
            if (dgvMarcas.SelectedRows.Count > 0)
            {
                var idMarca = (int)dgvMarcas.SelectedRows[0].Cells[0].Value;
                var repositorio = new RepositorioMarca();
                var marca = repositorio.BuscarPorId(idMarca);
                repositorio.Excluir(marca);
                PreencherDataGridViewMarcasAsync();
            }
            else
            {
                MessageBox.Show("Selecione a marca para alteração.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnExcluirProduto_Click(object sender, EventArgs e)
        {
            if (dgvProdutos.SelectedRows.Count > 0)
            {
                var idPrpoduto = (int)dgvProdutos.SelectedRows[0].Cells[0].Value;
                var repositorio = new RepositorioProduto();
                var produto = repositorio.BuscarPorId(idPrpoduto);
                repositorio.Excluir(produto);
                PreencherDataGridViewProdutosAsync();
            }
            else
            {
                MessageBox.Show("Selecione o produto para exclusão.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
