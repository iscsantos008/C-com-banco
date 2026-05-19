using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace appBancoDeDados.DAL
{
    class Conexao
    {
        MySqlConnection conexao = new MySqlConnection(@"server=localhost;
            database=bdAcademia; uid=root; pwd='';");


        public MySqlConnection Conectar()
        {
            if (conexao.State != ConnectionState.Open)
            {
                conexao.Open();
            }
            return conexao;
        }

        public MySqlConnection Desconectar()
        {
            if(conexao.State == ConnectionState.Open)
            {
                conexao.Close();
            }
            return conexao;
        }
    }
}
