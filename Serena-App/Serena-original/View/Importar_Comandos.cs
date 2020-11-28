/*
 * Created by SharpDevelop.
 * User: Omnia
 * Date: 12/02/2020
 * Time: 14:18
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace Serena_5._.View
{
	/// <summary>
	/// Description of Importar_Comandos.
	/// </summary>
	public partial class Importar_Comandos : Form
	{
		public Importar_Comandos()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void BTN_ImportarNovosComandosClick(object sender, EventArgs e)
		{
			try{
				openFileDialog1.Title = "Selecionar Arquivo para Importar";
				openFileDialog1.Filter = "DataBase Files (*.db)|*.db|" +
										"Arquivos SQLite (*.db)|*.db";//filtrar por .db
				DialogResult dr = openFileDialog1.ShowDialog();
				if (dr == System.Windows.Forms.DialogResult.OK)
	            {
					Model.Conexao_BD Endereco = new Model.Conexao_BD();
					string endereco_atual = openFileDialog1.FileName;//Endereço do arquivo selecionado
					string endereco_destino = Endereco.endereco_banco;//Endereço definido na classe do banco de dados
					
					if(File.Exists(endereco_destino))
					{
						if(MessageBox.Show("Você já possui um arquivo com comandos, deseja substituir por este selecionado ?" +
                                            "/n Caso continue o arquivo existente será removido e o arquivo selecionado será usado",
											"O Arquivo já existe", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes){
							File.Delete(endereco_destino);
							File.Copy(endereco_atual, endereco_destino);
							MessageBox.Show("O arquivo com os novos comandos foi importado com sucesso!");
						}					
					}
				}
			}
			catch(Exception ex){
				MessageBox.Show("Houve um erro Importar o arquivo com novos comandos ao  \nMotivo: "+ex.Message);
			}
		}
		void BTN_ExportarComandosClick(object sender, EventArgs e)
		{
			try{
				Model.Conexao_BD Endereco = new Model.Conexao_BD();
				string endereco_banco = Endereco.endereco_banco;//Endereço definido na classe do banco de dados
					
				
	            //define o titulo
	            saveFileDialog1.Title = "Exportar Banco de dados";
	            //Define as extensões permitidas
	            saveFileDialog1.Filter = "DataBase File|.db";
	            //Atribui um valor vazio ao nome do arquivo
	            saveFileDialog1.FileName = "Dados.db";
	
	            //Open the dialog and determine which button was pressed
	            DialogResult tela_salvar = saveFileDialog1.ShowDialog();
	
	            //Se o ousuário pressionar o botão Salvar
	            if (tela_salvar == DialogResult.OK)
	            {
	            	if(File.Exists(endereco_banco))
					{
	            		File.Delete(saveFileDialog1.FileName);
						File.Copy(endereco_banco, saveFileDialog1.FileName);
						MessageBox.Show("O Banco de Dados foi Exportado com sucesso!");				
					}
	            	else{
	            		MessageBox.Show("Nenhum Banco de Dados foi encontrado, cadastre algum novo comando e tente novamente!");
	            	}
					
	            }
			}
			catch(Exception ex){
				MessageBox.Show("Houve um erro ao Exportar o Banco de Dados \nMotivo: "+ex.Message);
			}
		}
	}
}
