using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace appBancoDeDados.DAL
{
    class AlunoDAL
    {
        Conexao con = new Conexao();
        

        
        public void Cadastrar(BLL.AlunoBLL aluno)
        {
            MySqlCommand cmd = new MySqlCommand();

            cmd.CommandText = @"INSERT INTO ALUNO
                (NOME,CPF,RG,EMAIL,DATA_NASC)
                VALUES
                (@NOME, @CPF, @RG, @EMAIL, @DATA_NASC)";

            cmd.Parameters.AddWithValue("@NOME", aluno.Nome);
            cmd.Parameters.AddWithValue("@CPF", aluno.Cpf);
            cmd.Parameters.AddWithValue("@RG", aluno.Rg);
            cmd.Parameters.AddWithValue("@EMAIL", aluno.Email);
            cmd.Parameters.AddWithValue("@DATA_NASC", aluno.Data);

            cmd.Connection = con.Conectar();
            cmd.ExecuteNonQuery();
            cmd.Connection = con.Desconectar();
        }

        public void Excluir(BLL.AlunoBLL aluno)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = @"DELETE FROM ALUNO
                WHERE CODALUNO=@CODALUNO";

            cmd.Parameters.AddWithValue("@CODALUNO", aluno.CodAluno);
            cmd.Connection = con.Conectar();
            cmd.ExecuteNonQuery();
            cmd.Connection = con.Desconectar();
        }

        public void Atualizar(BLL.AlunoBLL aluno)
        {
            MySqlCommand cmd = new MySqlCommand(
                @"UPDATE ALUNO
                    SET NOME = @NOME,
                            CPF = @CPF,
                            RG = @RG,
                            EMAIL = @EMAIL,
                            DATA_NASC = @DATA_NASC
                            WHERE CODALUNO = @CODALUNO", 
                con.Conectar()
                );

            cmd.Parameters.AddWithValue("@NOME", aluno.Nome);
            cmd.Parameters.AddWithValue("@CPF", aluno.Cpf);
            cmd.Parameters.AddWithValue("@RG", aluno.Rg);
            cmd.Parameters.AddWithValue("@EMAIL", aluno.Email);
            cmd.Parameters.AddWithValue("@DATA_NASC", aluno.Data);
            cmd.Parameters.AddWithValue("@CODALUNO", aluno.CodAluno);
            cmd.ExecuteNonQuery();
            cmd.Connection = con.Desconectar();
        }

        public BLL.AlunoBLL Retornar(BLL.AlunoBLL aluno)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = @"SELECT * FROM ALUNO WHERE CODALUNO = @CODALUNO";
            cmd.Parameters.AddWithValue("@CODALUNO", aluno.CodAluno);
            cmd.Connection = con.Conectar();
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                aluno.CodAluno = (Convert.ToInt32(dr["CODALUNO"]));
                aluno.Cpf = dr["CPF"].ToString();
                aluno.Rg = dr["RG"].ToString();
                aluno.Nome = dr["NOME"].ToString();
                aluno.Email = dr["EMAIL"].ToString();
                aluno.Data = Convert.ToDateTime(dr["DATA_NASC"].ToString());
            }
            dr.Close();
            con.Desconectar();
            return aluno;
        }


        public DataTable ConsultarTodos()
        {
            MySqlDataAdapter da = new MySqlDataAdapter(
                @"SELECT * FROM ALUNO",
                con.Conectar());

            DataTable dt = new DataTable();

            da.Fill(dt);
            con.Desconectar();
            return dt;
        }

        public DataTable PesquisarNome(BLL.AlunoBLL aluno)
        {
            MySqlDataAdapter da = new MySqlDataAdapter(
                @"SELECT * FROM ALUNO WHERE NOME LIKE @NOME ",
                con.Conectar());
            da.SelectCommand.Parameters.AddWithValue("@NOME", "%"+ aluno.Nome+"%");
            
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Desconectar();
            return dt;
        }
    }
}

