/*
 * Created by SharpDevelop.
 * User: Omnia
 * Date: 03/03/2020
 * Time: 09:31
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Serena_5._.Model
{
	/// <summary>
	/// Description of OBJ_Comando.
	/// </summary>
	public class OBJ_Comando
	{
		Conexao_BD conexao = new Conexao_BD();
		Controller.Reconhecimento_Voz voz = new Controller.Reconhecimento_Voz();
		
		//Atributos para os comandos
		private int IdComando;
		private string IsCommand;
		private string Instrucao;
		private string Pronuncia;
		private string TipoComando;
		private string RespostaEsperada;
		private string Executar1;
		private string Executar2;
		
		public OBJ_Comando()
		{
		}
		
		/*---------------------Comandos---------------------------*/
		//Metodos Get
		public int getIdComando()
		{
			return IdComando;
		}
		public string getIsCommand()
		{
			return IsCommand;
		}
		public string getInstrucao()
		{
			return Instrucao;
		}
		public string getPronuncia()
		{
			return Pronuncia;
		}
		public string getTipoComando()
		{
			return TipoComando;
		}
		public string getRespostaEsperada()
		{
			return RespostaEsperada;
		}
		public string getExecutar1()
		{
			return Executar1;
		}
		public string getExecutar2()
		{
			return Executar2;
		}
		
		//Metodos Set
		public void setIdComando(int id)
		{
			this.IdComando = id;
		}
		public void setIsCommand(string command)
		{
			this.IsCommand = command;
		}
		public void setInstrucao(string instrucao)
		{
			this.Instrucao = instrucao;
		}
		public void setPronuncia(string pronuncia)
		{
			this.Pronuncia = pronuncia;
		}
		public void setTipoComando(string tipocomando)
		{
			this.TipoComando = tipocomando;
		}
		public void setRespostaEsperada(string respostaesperada)
		{
			this.RespostaEsperada = respostaesperada;
		}
		public void setExecutar1(string executar1)
		{
			this.Executar1 = executar1;
		}
		public void setExecutar2(string executar2)
		{
			this.Executar2 = executar2;
		}
		
		//Metodos CRUD
		public void CreateUpdateComando()
		{
			conexao.CriarBancoDeDados();
			try{
				if(IdComando == 0)//0 informa que o registro deve ser criado
				{
					string SQL_Create = "insert into controlecomando(IsCommand,Instrucao,Pronuncia,TipoComando,RespostaEsperada,Executar1,Executar2) values('"+IsCommand+ "','"+Instrucao+ "','"+Pronuncia+ "','"+TipoComando+ "','"+RespostaEsperada+ "','"+Executar1+ "','"+Executar2+"')";	
					conexao.Conectar();
					SQLiteCommand Comando = new SQLiteCommand(SQL_Create,conexao.Conexao);
					Comando.ExecuteNonQuery();//Executa comandos SQL sem exibir resultado
					conexao.Desconectar();
                    voz.Reiniciar_Reconhecimento();//Atualiza a gramatica SQL
                    MessageBox.Show("Comando Criado com Sucesso");
					
				}
				else
				{
					//Verifica se existe algum registro, se já existir atualiza pelo id
					string SQL_Update = "update controlecomando set IsCommand='"+IsCommand+ "',Instrucao='"+Instrucao+ "',Pronuncia='"+Pronuncia+ "',TipoComando='"+TipoComando+ "',RespostaEsperada='"+RespostaEsperada+ "',Executar1='"+Executar1+ "',Executar2='"+Executar2+ "' where id='"+IdComando+ "'";
					conexao.Conectar();
					SQLiteCommand Comando = new SQLiteCommand(SQL_Update,conexao.Conexao);
					Comando.ExecuteNonQuery();//Executa comandos SQL sem exibir resultado
					conexao.Desconectar();
                    voz.Reiniciar_Reconhecimento();
                    MessageBox.Show("Comando Atualizado com Sucesso!");
				}
			}
			catch(Exception Erro_ControleComando_Delete){
				MessageBox.Show("Erro ao tentar atualizar o comando \nMotivo: "+Erro_ControleComando_Delete.Message);
			}
		}
		public void DeleteComando()
		{
			conexao.CriarBancoDeDados();
			try{
				DataTable dt = new DataTable();
				string SQL_View = "select id from controlecomando where id ='"+IdComando+ "'";
				SQLiteDataAdapter da = new SQLiteDataAdapter(SQL_View,conexao.Conexao);
				da.Fill(dt);
				
				if(dt.Rows.Count < 1)
				{
					MessageBox.Show("O comando não existe para ser deletado");
				}
				else
				{
					string SQL_Delete = "delete from controlecomando where id ='"+IdComando+ "'";
					conexao.Conectar();
					SQLiteCommand Comando = new SQLiteCommand(SQL_Delete,conexao.Conexao);
					Comando.ExecuteNonQuery();//Executa comandos SQL sem exibir resultado
					conexao.Desconectar();
					voz.Reiniciar_Reconhecimento();
					MessageBox.Show("Comando Deletado com Sucesso!");
				}
			}
			catch(Exception Erro_ControleComando_Delete){
				MessageBox.Show("Erro ao tentar deletar o comando \nMotivo: "+Erro_ControleComando_Delete.Message);
			}
		}
		public void Consultar_Pronuncia(string pronuncia)
		{
			conexao.CriarBancoDeDados();
			try
			{
				DataTable Tabela = new DataTable();
				string SQL_Consulta = "select * from controlecomando where pronuncia ='"+pronuncia+ "'";
				SQLiteDataAdapter da = new SQLiteDataAdapter(SQL_Consulta,conexao.Conexao);
				da.Fill(Tabela);
				
				if(Tabela.Rows.Count >= 1)
				{
					IdComando = Convert.ToInt32(Tabela.Rows[0]["id"].ToString());
					IsCommand = Tabela.Rows[0]["iscommand"].ToString();
					Instrucao = Tabela.Rows[0]["instrucao"].ToString();
					Pronuncia = Tabela.Rows[0]["pronuncia"].ToString();
					TipoComando = Tabela.Rows[0]["tipocomando"].ToString();
					RespostaEsperada = Tabela.Rows[0]["respostaesperada"].ToString();
					Executar1 = Tabela.Rows[0]["executar1"].ToString();
					Executar2 = Tabela.Rows[0]["executar2"].ToString();
				}
			}
			catch(Exception Erro_Consulta)
			{
				MessageBox.Show("Erro ao realizar a consulta por pronuncia na tabela comando\nMotivo: "+Erro_Consulta.Message);
			}
		}
		public void Consultar_Id(int id)
		{
			conexao.CriarBancoDeDados();
			try
			{
				DataTable Tabela = new DataTable();
				string SQL_Consulta = "select * from controlecomando where id ='"+id+ "'";
				SQLiteDataAdapter da = new SQLiteDataAdapter(SQL_Consulta,conexao.Conexao);
				da.Fill(Tabela);
				
				if(Tabela.Rows.Count >= 1)
				{
					IdComando = Convert.ToInt32(Tabela.Rows[0]["id"].ToString());
					IsCommand = Tabela.Rows[0]["iscommand"].ToString();
					Instrucao = Tabela.Rows[0]["instrucao"].ToString();
					Pronuncia = Tabela.Rows[0]["pronuncia"].ToString();
					TipoComando = Tabela.Rows[0]["tipocomando"].ToString();
					RespostaEsperada = Tabela.Rows[0]["respostaesperada"].ToString();
					Executar1 = Tabela.Rows[0]["executar1"].ToString();
					Executar2 = Tabela.Rows[0]["executar2"].ToString();
				}
			}
			catch(Exception Erro_Consulta)
			{
				MessageBox.Show("Erro ao realizar a consulta por ID na tabela de comandos \nMotivo: "+Erro_Consulta.Message);
			}
		}
		public void Consultar_Comandos()
		{
			conexao.CriarBancoDeDados();
			try
			{
				DataTable Tabela = new DataTable();
				string SQL_Consulta = "select * from controlecomando";
				SQLiteDataAdapter da = new SQLiteDataAdapter(SQL_Consulta,conexao.Conexao);
				da.Fill(Tabela);
				
				if(Tabela.Rows.Count >= 1)
				{
					IdComando = Convert.ToInt32(Tabela.Rows[0]["id"].ToString());
					IsCommand = Tabela.Rows[0]["iscommand"].ToString();
					Instrucao = Tabela.Rows[0]["instrucao"].ToString();
					Pronuncia = Tabela.Rows[0]["pronuncia"].ToString();
					TipoComando = Tabela.Rows[0]["tipocomando"].ToString();
					RespostaEsperada = Tabela.Rows[0]["respostaesperada"].ToString();
					Executar1 = Tabela.Rows[0]["executar1"].ToString();
					Executar2 = Tabela.Rows[0]["executar2"].ToString();
				}
			}
			catch(Exception Erro_Consulta)
			{
				MessageBox.Show("Erro ao realizar a consulta na tabela comandos para exibir todos os registros \nMotivo: "+Erro_Consulta.Message);
			}
		}
	}
}
