/*
 * Created by SharpDevelop.
 * User: Omnia
 * Date: 12/02/2020
 * Time: 14:18
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Serena_5._.View
{
	/// <summary>
	/// Description of Exibir_Comandos.
	/// </summary>
	public partial class Exibir_Comandos : Form
	{
		Model.Conexao_BD Conexao = new Model.Conexao_BD();
		
		public Exibir_Comandos()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void Exibir_ComandosLoad(object sender, EventArgs e)
		{
			Atualizar_Lista_ComandosSQL();
			Atualizar_Lista_ComandosInternos();
		}
		
		private void Atualizar_Lista_ComandosSQL()
		{
			Conexao.CriarBancoDeDados();//Cria caso não exista
			try
			{
				DataTable Tabela = new DataTable();
				string SQL = "select instrucao from controlecomando";
				SQLiteDataAdapter Adapter = new SQLiteDataAdapter(SQL,Conexao.Conexao);
				Adapter.Fill(Tabela);
				dataGridView1.DataSource = Tabela.DefaultView;
				//Tabela.Rows[0]["Pronuncia"] = Tabela.Rows.Add("teste");
			}
			catch(Exception ex){
				MessageBox.Show("Houve um erro ao carregar os comandos do Banco de dados na tabela \nMotivo: "+ex.Message);
			}
		}
		private void Atualizar_Lista_ComandosInternos()
		{
			Model.Pronuncia_Comandos p = new Model.Pronuncia_Comandos();
			foreach (string element in p.Comandos_Internos)
			{
				//Ler as pronuncias internas e adiciona em uma lista
				listBox1.Items.Add(element);
			}
		}
		
	}
}
