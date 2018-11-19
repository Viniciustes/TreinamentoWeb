using System;
using System.Windows.Forms;
using TreinamentoWeb.Dominio.Entidades;
using TreinamentoWeb.Repositorio.Repositorio;

namespace TreinamentoWeb.Apresentacao.Forms
{
    public partial class FrmMarca : Form
    {
        private readonly Marca _marca;

        public FrmMarca(Marca marca = null)
        {
            _marca = marca;
            InitializeComponent();
        }

        private void BtnCancelarMarca_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnSalvarMarca_Click(object sender, EventArgs e)
        {
            var repositorio = new RepositorioMarca();

            if (_marca == null)
            {
                var marca = new Marca
                {
                    Nome = txtNomeMarca.Text.Trim()
                };

                repositorio.Inserir(marca);
            }
            else
            {
                _marca.Nome = txtNomeMarca.Text.Trim();
                repositorio.Atualizar(_marca);
            }

            Close();
        }

        private void FrmMarca_Load(object sender, EventArgs e)
        {
            if (_marca != null)
            {
                txtNomeMarca.Text = _marca.Nome;
            }
            else
                txtNomeMarca.Text = string.Empty;
        }
    }
}
