using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appBancoDeDados.BLL
{
    class AlunoBLL
    {
        private int codAluno;
        private string nome,cpf,rg,email;
        private DateTime data;

        public int CodAluno { get => codAluno; set => codAluno = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Cpf { get => cpf; set => cpf = value; }
        public string Rg { get => rg; set => rg = value; }
        public string Email { get => email; set => email = value; }
        public DateTime Data { get => data; set => data = value; }

    }
}
