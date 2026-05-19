using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace appBancoDeDados.UI
{
    public partial class FrmAluno : Form
    {
        DAL.AlunoDAL alunoDAL = new DAL.AlunoDAL();
        BLL.AlunoBLL alunoBLL = new BLL.AlunoBLL();
        bool cadastro = true;
        public FrmAluno()
        {
            InitializeComponent();
        }

        private void BtnCadastrar_Click(object sender, EventArgs e)
        {
            alunoBLL.Nome = txtNome.Text;
            alunoBLL.Cpf = txtCPF.Text;
            alunoBLL.Rg = txtRG.Text;
            alunoBLL.Data = txtDataNasc.Value;
            alunoBLL.Email = txtEMAIL.Text;
            

            if (cadastro == true)
            {
                alunoDAL.Cadastrar(alunoBLL);
                MessageBox.Show("Cadastro efetuado com sucesso!");
                Limpar();
            }
            else
            {
                alunoDAL.Atualizar(alunoBLL);
                MessageBox.Show("Dados atualizados");
                cadastro = true;
            }
        }

        private void FrmAluno_Load(object sender, EventArgs e)
        {
            txtDataNasc.Value = DateTime.Now;
            dgvAluno.DataSource = alunoDAL.ConsultarTodos();
        }

        public void Limpar()
        {
            txtNome.Clear();
            txtCPF.Clear();
            txtRG.Clear();
            txtEMAIL.Clear();
            txtDataNasc.Value = DateTime.Now;
            txtNome.Focus();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Limpar();
        }

        private void TxtConsultarNome_TextChanged(object sender, EventArgs e)
        {
            alunoBLL.Nome = txtConsultarNome.Text;
            dgvAluno.DataSource = alunoDAL.PesquisarNome(alunoBLL);
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente excluir?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes){

                alunoBLL.CodAluno = Convert.ToUInt16(dgvAluno[0, dgvAluno.CurrentRow.Index].Value);
                alunoDAL.Excluir(alunoBLL);
                dgvAluno.DataSource = alunoDAL.ConsultarTodos();
                txtConsultarNome.Text = "";
            }
           
           
            
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = Cadastro;
            alunoBLL.CodAluno = Convert.ToUInt16(dgvAluno[0, dgvAluno.CurrentRow.Index].Value);
            alunoBLL =  alunoDAL.Retornar(alunoBLL);
            txtNome.Text = alunoBLL.Nome;
            txtCPF.Text = alunoBLL.Cpf;
            txtRG.Text = alunoBLL.Rg;
            txtDataNasc.Value = alunoBLL.Data;
            txtEMAIL.Text = alunoBLL.Email;

            cadastro = false;

        }
    }
}
