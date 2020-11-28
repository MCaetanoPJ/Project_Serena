/*
 * Created by SharpDevelop.
 * User: Omnia
 * Date: 03/03/2020
 * Time: 09:23
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Serena_5._.Model
{
	/// <summary>
	/// Description of OBJ_Configuracoes.
	/// </summary>
	public class OBJ_Configuracoes
	{
		Conexao_BD conexao = new Conexao_BD();
		
		//Atributos para as Configurações
		private int IdConfiguracao = 1;//Deve existir apenas uma configuração de saida de voz - NÃO ALTERAR O VALOR 1
		private string NomeUsuario;
		private int VelocidadeVoz;
		private int VolumeVoz;
		private double NivelConfianca;
		
		public OBJ_Configuracoes()
		{
		}
		
		//Metodos Get
		public int getIdConfiguracao()
		{
			return IdConfiguracao;
		}
		public string getNomeUsuario()
		{
			return NomeUsuario;
		}
		public int getVelocidadeVoz()
		{
			return VelocidadeVoz;
		}
		public int getVolumeVoz()
		{
			return VolumeVoz;
		}
		public double getNivelConfianca()
		{
			return NivelConfianca;
		}
		
		//Metodos Set
		public void setIdConfiguracao(int idconfiguracao)
		{
			this.IdConfiguracao = idconfiguracao;
		}
		public void setNomeUsuario(string nomeusuario)
		{
			this.NomeUsuario = nomeusuario;
		}
		public void setVelocidadeVoz(int velocidadevoz)
		{
			this.VelocidadeVoz = velocidadevoz;
		}
		public void setVolumeVoz(int volumevoz)
		{
			this.VolumeVoz = volumevoz;
		}
		public void setNivelConfianca(double nivelconfianca)
		{
			this.NivelConfianca = nivelconfianca;
		}
		
		//Metodos CRUD
		public void CreateUpdateConfiguracoes()
		{
			conexao.CriarBancoDeDados();
			try{
				DataTable Tabela = new DataTable();
				string SQL_View = "select id from configuracoesvoz where id ='"+IdConfiguracao+ "'";
				SQLiteDataAdapter da = new SQLiteDataAdapter(SQL_View,conexao.Conexao);
				da.Fill(Tabela);
				
				if(Tabela.Rows.Count < 1)
				{
					string SQL_Create = "insert into configuracoesvoz(id,VelocidadeVoz,VolumeVoz,NomeUsuario,NivelConfianca) values('"+IdConfiguracao+ "','"+VelocidadeVoz+ "','"+VolumeVoz+ "','"+NomeUsuario+ "','"+NivelConfianca+ "')";
					conexao.Conectar();
					SQLiteCommand Comando = new SQLiteCommand(SQL_Create,conexao.Conexao);
					Comando.ExecuteNonQuery();//Executa comandos SQL sem exibir resultado
					conexao.Desconectar();
					MessageBox.Show("Configuração Criada com Sucesso");
				}
				else
				{
					//Verifica se existe algum registro, se já existir atualiza pelo id
					string SQL_Update = "update configuracoesvoz set velocidadevoz='"+VelocidadeVoz+ "',volumevoz='"+VolumeVoz+ "',NomeUsuario='"+NomeUsuario+ "',NivelConfianca='"+NivelConfianca+ "' where id='"+IdConfiguracao+ "'";
					conexao.Conectar();
					SQLiteCommand Comando = new SQLiteCommand(SQL_Update,conexao.Conexao);
					Comando.ExecuteNonQuery();//Executa comandos SQL sem exibir resultado
					conexao.Desconectar();
					MessageBox.Show("Configuração Atualizada com Sucesso!");
				}
			}
			catch(Exception Erro_ConfiguracoesVoz_CreateUpdate)	{	
				MessageBox.Show("Erro ao criar ou atualizar a Configuração da voz\nMotivo: "+Erro_ConfiguracoesVoz_CreateUpdate.Message);
			}
		}
		public void Consultar_Configuracoes()
		{
			conexao.CriarBancoDeDados();
			try
			{
				DataTable Tabela = new DataTable();
				string SQL_View= "select id,VelocidadeVoz,VolumeVoz,NomeUsuario,NivelConfianca from configuracoesvoz where id ='"+IdConfiguracao+ "'";
				SQLiteDataAdapter da = new SQLiteDataAdapter(SQL_View,conexao.Conexao);
                da.Fill(Tabela);
				
				if(Tabela.Rows.Count >= 1)
				{
					IdConfiguracao = Convert.ToInt32(Tabela.Rows[0]["id"].ToString());
					NomeUsuario = Tabela.Rows[0]["NomeUsuario"].ToString();
					VelocidadeVoz = Convert.ToInt32(Tabela.Rows[0]["VelocidadeVoz"].ToString());
					VolumeVoz = Convert.ToInt32(Tabela.Rows[0]["VolumeVoz"].ToString());
					NivelConfianca = Convert.ToInt32(Tabela.Rows[0]["NivelConfianca"].ToString());
				}
			}
			catch(SQLiteException Erro_Consulta)
			{
				MessageBox.Show("Erro ao realizar a consulta \nMotivo: "+Erro_Consulta.Message);
			}
		}
	}
}
