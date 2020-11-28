/*
 * Created by SharpDevelop.
 * User: venda
 * Date: 25/02/2020
 * Time: 18:18
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace Serena_5._.Model
{
	/// <summary>
	/// Description of Conexao_BD.
	/// </summary>
	public class Conexao_BD
	{
		private string diretorio = "DataBase-Comandos";//Nome da pasta onde o BD está
		public string endereco_banco = "DataBase-Comandos/Dados.db";//Endereço do Banco de Dados para Importar e Exportar
		public SQLiteConnection Conexao = new SQLiteConnection("Data Source=DataBase-Comandos/Dados.db");//Cria e Acessa o Banco de Dados
		
		public Conexao_BD()
		{
			CriarDiretorio();
		}
		
		/*--------------------Métodos para Construir o Banco de Dados-------------------------*/
		public void CriarBancoDeDados()
		{
			CriarDiretorio();
			try{
				CriarTabelas();
			}
			catch(Exception ex){
				MessageBox.Show("Houve um erro ao criar o Banco de Dados \nMotivo: "+ex.Message);
			}
			
		}
		private void CriarDiretorio()
		{
			try{
				if (!Directory.Exists(diretorio))
					{
						Directory.CreateDirectory(diretorio);//Cria o Diretorio
					}
			}
			catch(Exception ex){
				MessageBox.Show("Houve um erro ao criar o Diretório: "+diretorio+" \nMotivo: "+ex.Message);
			}
		}
		private void CriarTabelas()
		{
			try
            {
				Conectar();
                using (var commando = Conexao.CreateCommand())
                {
                    commando.CommandText = "CREATE TABLE IF NOT EXISTS configuracoesvoz(" +
                    	"Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, " +
                    	"VelocidadeVoz INTEGER, " +
                    	"VolumeVoz INTEGER, " +
                    	"NomeUsuario TEXT, " +
                    	"NivelConfianca INTEGER)";
                    commando.ExecuteNonQuery();
                    Desconectar();
                    
                    Conectar();
                    commando.CommandText = "CREATE TABLE IF NOT EXISTS controlecomando(Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, " +
                    	"IsCommand TEXT, " +
                    	"Instrucao TEXT," +
                    	"Pronuncia TEXT, " +
                    	"TipoComando TEXT, " +
                    	"RespostaEsperada TEXT, " +
                    	"Executar1 TEXT, " +
                    	"Executar2 TEXT)";
                    commando.ExecuteNonQuery();
                    Desconectar();

					string SQL_Create = "insert into configuracoesvoz(VelocidadeVoz,VolumeVoz,NivelConfianca) values('" + 1 + "','" + 100 + "','" + 7 + "')";
					Conectar();
					SQLiteCommand Comando = new SQLiteCommand(SQL_Create, Conexao);
					Comando.ExecuteNonQuery();//Executa comandos SQL sem exibir resultado
					Desconectar();

				}
            }
            catch(Exception ex){
				MessageBox.Show("Houve um erro ao criar as Tabelas dentro do Banco de Dados \nMotivo: "+ex.Message);
			}
		}
		
		/*--------------------Métodos depois que o banco de dados foi criado-------------------------*/
		public void Conectar()
		{
			try{
				Conexao.Open();
			}
			catch(Exception Erro_Conectar){
				MessageBox.Show("Erro ao Abrir a Conexão: \n"+Erro_Conectar.Message+"\n Status da Conexao: "+Conexao.State);
			}
		}
		public void Desconectar()
		{
			try{
				Conexao.Close();
			}
			catch(Exception Erro_Desconectar){
				MessageBox.Show("Erro ao Fechar a Conexão: \n"+Erro_Desconectar.Message+"\n Status da Conexao: "+Conexao.State);
			}
		}
	}
}
