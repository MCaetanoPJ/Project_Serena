/*
 * Created by SharpDevelop.
 * User: Omnia
 * Date: 12/02/2020
 * Time: 14:17
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SQLite;
using Serena_5._.Model;

namespace Serena_5._.View
{
	/// <summary>
	/// Description of Criador_Comandos.
	/// </summary>
	public partial class Criador_Comandos : Form
	{		
		public Criador_Comandos()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void BTN_SalvarClick(object sender, EventArgs e)
		{
			if(IsComando.Text == "Sim"){
				if(TXT_Instrucao.Text == ""){
					MessageBox.Show("Campo Instrução é Obrigatório");
					return;
				}
				if(TXT_Pronuncia.Text == ""){
					MessageBox.Show("Campo Pronuncia é Obrigatório");
					return;
				}
				if(TXT_Pronuncia.TextLength < 3){
					MessageBox.Show("Campo Pronuncia deve ter mais de 03 caracteres");
					return;
				}
				if(TXT_TipoComando.Text == "CMD"){
					if(TXT_Executar1.Text == ""){
						MessageBox.Show("É Obrigatorio informar um Comando");
						return;
					}
				}
				if(TXT_TipoComando.Text == "Programa"){
					if(TXT_Executar1.Text == ""){
						MessageBox.Show("É Obrigatorio informar um Endereço de algum programa");
						return;
					}
				}
				if(TXT_TipoComando.Text == "Site"){
					if(TXT_Executar1.Text == ""){
						MessageBox.Show("É Obrigatorio informar algum link de site");
						return;
					}
				}
				if(TXT_TipoComando.Text == "Tecla"){
					if(TXT_Executar1.Text == ""){
						MessageBox.Show("É Obrigatorio informar algum comando de Tecla");
						return;
					}
				}
				Salvar_Registro();
			}
			else{
				if(TXT_Instrucao.Text == ""){
					MessageBox.Show("Campo Instrução é Obrigatório");
					return;
				}
				if(TXT_Pronuncia.Text == ""){
					MessageBox.Show("Campo Pronuncia é Obrigatório");
					return;
				}
				Salvar_Registro();
			}
		}
		private void Salvar_Registro()
		{
			Model.OBJ_Comando c = new Model.OBJ_Comando();
			try{
				c.setIdComando(Convert.ToInt32(TXT_Id.Text));
				c.setIsCommand(IsComando.Text);
				c.setInstrucao(TXT_Instrucao.Text);
				c.setPronuncia(TXT_Pronuncia.Text);
				c.setTipoComando(TXT_TipoComando.Text);
				c.setRespostaEsperada(TXT_RespostaEsperada.Text);
				c.setExecutar1(TXT_Executar1.Text);
				c.setExecutar2(TXT_Executar2.Text);
				c.CreateUpdateComando();
			}
			catch{
				MessageBox.Show("Verifique se todos os campos estão preenchidos");
			}
			Atualiza_Tabela();
			Limpar_Campos();
		}
		private void Limpar_Campos()
		{
			TXT_Id.Text = "0";//Zero informa que deve criar o registro
			IsComando.Text = "Sim";
			TXT_Instrucao.Clear();
          	TXT_Pronuncia.Clear();
          	TXT_TipoComando.Text = "CMD";
          	TXT_RespostaEsperada.Clear();
          	TXT_Executar1.Clear();
          	TXT_Executar2.Clear();
		}
		private void Atualiza_Tabela()
		{			
			try{
				DataTable dt = new DataTable();
				string SQL = "select id,Instrucao from controlecomando";
				Model.Conexao_BD d = new Model.Conexao_BD();
				SQLiteDataAdapter da = new SQLiteDataAdapter(SQL,d.Conexao);
				da.Fill(dt);
				dataGridView1.DataSource = dt.DefaultView;
			}
			catch{
				MessageBox.Show("Erro ao exibir os comandos referentes ao id:"+Convert.ToInt32(TXT_Id.Text));
			}
		}
		void BTN_DeletarClick(object sender, EventArgs e)
		{
			try{
			Model.OBJ_Comando c = new Model.OBJ_Comando();
			c.setIdComando(Convert.ToInt32(TXT_Id.Text));
			c.DeleteComando();
			}
			catch{
				MessageBox.Show("Nenhum comando foi selecionado para ser deletado");
			}
			
			Atualiza_Tabela();
			Limpar_Campos();
		}
		void BTN_LimparClick(object sender, EventArgs e)
		{
			Limpar_Campos();
		}
		void Criador_ComandosLoad(object sender, EventArgs e)
		{
			Limpar_Campos();
			Atualiza_Tabela();
		}
		void DataGridView1CellClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				TXT_Id.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();//Passa o valor da coluna Id da Tabela para o TXT_ID
				
				Model.OBJ_Comando c = new Model.OBJ_Comando();
				c.Consultar_Id(Convert.ToInt32(TXT_Id.Text));
				TXT_Id.Text = c.getIdComando().ToString();
				IsComando.Text = c.getIsCommand();
				TXT_Instrucao.Text = c.getInstrucao();
				TXT_Pronuncia.Text = c.getPronuncia();
				TXT_TipoComando.Text = c.getTipoComando();
				TXT_RespostaEsperada.Text = c.getRespostaEsperada();
				TXT_Executar1.Text = c.getExecutar1();
				TXT_Executar2.Text = c.getExecutar2();
			}
			catch(Exception ex){
				MessageBox.Show("Houve um erro ao consultar as informações sobre o comando selecionado \nMotivo:"+ex.Message);
			}
			
		}
		void IsComandoSelectedIndexChanged(object sender, EventArgs e)
		{
			if(IsComando.Text == "Sim")
			{
				TXT_Instrucao.Enabled = true;
	          	TXT_Pronuncia.Enabled = true;
	          	TXT_TipoComando.Enabled = true;
			}
			if(IsComando.Text == "Não")
			{
				TXT_Instrucao.Enabled = true;
	          	TXT_Pronuncia.Enabled = true;
	          	TXT_TipoComando.Enabled = false;
	          	TXT_RespostaEsperada.Enabled = false;
	          	TXT_Executar1.Enabled = false;
	          	TXT_Executar2.Enabled = false;
			}
		}
		void TXT_TipoComandoSelectedIndexChanged(object sender, EventArgs e)
		{
			if(TXT_TipoComando.Text != null){
				if(TXT_TipoComando.Text == "CMD")
				{
					label6.Text = "1° Parte do comando do CMD";
					label7.Text = "2° Parte do comando caso tenha";
					TXT_Instrucao.Enabled = true;
		          	TXT_Pronuncia.Enabled = true;
		          	TXT_RespostaEsperada.Enabled = true;
		          	TXT_Executar1.Enabled = true;
		          	TXT_Executar2.Enabled = true;
		          	BTN_SelecionarPrograma.Visible = false;
				}
				if(TXT_TipoComando.Text == "Tecla")
				{
					label6.Text = "Informe as teclas que serão pressionadas pelo sistema";
					label7.Text = "";
					TXT_Instrucao.Enabled = true;
		          	TXT_Pronuncia.Enabled = true;
		          	TXT_RespostaEsperada.Enabled = true;
		          	TXT_Executar1.Enabled = true;
		          	TXT_Executar2.Enabled = false;
		          	BTN_SelecionarPrograma.Visible = false;
				}
				if(TXT_TipoComando.Text == "Site")
				{
					label6.Text = "Link do Site a ser acessado";
					label7.Text = "";
					TXT_Instrucao.Enabled = true;
		          	TXT_Pronuncia.Enabled = true;
		          	TXT_RespostaEsperada.Enabled = true;
		          	TXT_Executar1.Enabled = true;
		          	TXT_Executar2.Enabled = false;
		          	BTN_SelecionarPrograma.Visible = false;
				}
				if(TXT_TipoComando.Text == "Programa")
				{
					label6.Text = "Endereço do Programa";
					label7.Text = "";
					TXT_Instrucao.Enabled = true;
		          	TXT_Pronuncia.Enabled = true;
		          	TXT_RespostaEsperada.Enabled = true;
		          	TXT_Executar1.Enabled = false;
		          	TXT_Executar2.Enabled = false;
		          	BTN_SelecionarPrograma.Visible = true;
				}
			}
		}
		void BTN_Testar_Executar1e2Click(object sender, EventArgs e)
		{
			try{
			if(TXT_TipoComando.Text == "CMD")
				{
					if(TXT_Executar1.Text == "")
					{
						Process.Start("\""+TXT_Executar2.Text+"\"");
					}
					else if(TXT_Executar2.Text == "")
					{
						Process.Start("\""+TXT_Executar1.Text+"\"");
					}
					else
					{
						Process.Start("\""+TXT_Executar1.Text+"\"","\""+TXT_Executar2.Text+"\"");
					}
					MessageBox.Show("Teste de Instrução bem sucedido");
				}
			if(TXT_TipoComando.Text == "Tecla")
				{
					SendKeys.SendWait(TXT_Executar1.Text);
					MessageBox.Show("Teste bem sucedido");
				}
			if(TXT_TipoComando.Text == "Site" || TXT_TipoComando.Text == "Programa")
				{
		          	Process.Start("\""+TXT_Executar1.Text+"\"");
		          	MessageBox.Show("Teste bem sucedido");
				}
			}
			catch(Exception ex){
				MessageBox.Show("Erro ao executar o teste de instrução \n Motivo: "+ex.Message);
			}
		}
		void BTN_SelecionarProgramaClick(object sender, EventArgs e)
		{
			try
			{
				openFileDialog1.Title = "Selecione o Programa";
				openFileDialog1.Filter = "Executavel (*.exe)|*.exe|" +
										"Executavel (*.exe)|*.exe";//filtrar por .exe
				DialogResult dr = openFileDialog1.ShowDialog();
				if (dr == System.Windows.Forms.DialogResult.OK)
	            {
					TXT_Executar1.Text = openFileDialog1.FileName;
				}
			}
			catch(Exception ex){
				MessageBox.Show("Houve um erro Importar o arquivo com novos comandos ao  \nMotivo: "+ex.Message);
			}
		}
    }
}
