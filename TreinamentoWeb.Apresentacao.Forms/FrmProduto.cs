using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TreinamentoWeb.Apresentacao.Forms.ViewModels;
using TreinamentoWeb.Dominio.Entidades;
using TreinamentoWeb.Repositorio.Repositorio;

namespace TreinamentoWeb.Apresentacao.Forms
{
    public partial class FrmProduto : Form
    {
        private readonly Produto _produto;

        public FrmProduto(Produto produto = null)
        {
            _produto = produto;
            InitializeComponent();
        }

        private void BtnCancelarProduto_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void FrmProduto_Load(object sender, EventArgs e)
        {
            var repositorio = new RepositorioMarca();
            var marcas = await repositorio.BuscarTodos();

            var viewModels = new List<MarcaViewModel>();

            foreach (var marca in marcas)
            {
                var viewModel = new MarcaViewModel
                {
                    Id = marca.Id,
                    Nome = marca.Nome
                };
                viewModels.Add(viewModel);
            }

            cmbMarcas.DataSource = viewModels;
            cmbMarcas.DisplayMember = "Nome";
            cmbMarcas.ValueMember = "Id";
            cmbMarcas.Refresh();

            if (_produto != null)
            {
                txtNomeProduto.Text = _produto.Nome;
                cmbMarcas.SelectedValue = _produto.IdMarca;
            }
            else
                txtNomeProduto.Text = string.Empty;
        }

        private void BtnSalvarProduto_Click(object sender, EventArgs e)
        {
            var repositorio = new RepositorioProduto();
            if (_produto == null)
            {
                var produto = new Produto
                {
                    Nome = txtNomeProduto.Text.Trim(),
                    IdMarca = (int)cmbMarcas.SelectedValue
                };

                repositorio.Inserir(produto);
            }
            else
            {
                _produto.Nome = txtNomeProduto.Text.Trim();
                _produto.IdMarca = (int)cmbMarcas.SelectedValue;

                repositorio.Atualizar(_produto);
            }
            Close();
        }
    }
}
