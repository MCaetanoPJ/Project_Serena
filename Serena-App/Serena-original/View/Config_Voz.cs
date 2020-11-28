/*
 * Created by SharpDevelop.
 * User: Omnia
 * Date: 17/02/2020
 * Time: 16:38
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SQLite;
using Microsoft.Speech.Synthesis;
using Serena_5._.Controller;

namespace Serena_5._.View
{
	/// <summary>
	/// Description of Config_Voz.
	/// </summary>
	public partial class Config_Voz : Form
	{		
		static Controller.Reconhecimento_Voz voz = new Controller.Reconhecimento_Voz();
		public SpeechSynthesizer Sintetiza_Voz = new SpeechSynthesizer();

		//private SpeechSynthesizer Sintetiza_Voz = new SpeechSynthesizer();
		
		public Config_Voz()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		private void Salvar_Registro()
		{
			try{
				Model.OBJ_Configuracoes d = new Model.OBJ_Configuracoes();
				d.setVelocidadeVoz(Convert.ToInt32(TXT_VelocidadeVoz.Text));
				d.setVolumeVoz(Convert.ToInt32(TXT_VolumeVoz.Text));
				d.setNomeUsuario(TXT_NomeUsuario.Text);
				d.setNivelConfianca(Convert.ToInt32(TXT_Sensibilidade_Reconhecimento.Text));
				d.CreateUpdateConfiguracoes();
				voz.Controles_do_sintetizador_de_voz();
			}
			catch(Exception erro){
				MessageBox.Show("Verifique o preenchimento correto dos campos \n Motivo: "+erro.Message);
			}
			atualizar_campos();
		}
		
		void BTN_SalvarClick(object sender, EventArgs e)
		{
			try{
			if(TXT_NomeUsuario.TextLength > 20)
			{
				MessageBox.Show("A pronuncia do Nome do Usuário deve possuir no máximo 20 Caracteres");
				return;
			}
			if(Convert.ToInt32(TXT_VelocidadeVoz.Text) < 1 || Convert.ToInt32(TXT_VelocidadeVoz.Text) > 10)
			{
				MessageBox.Show("A velocidade da Voz deve ser entre 1 e 10");
				return;
			}
			if(Convert.ToInt32(TXT_VolumeVoz.Text) < 1 || Convert.ToInt32(TXT_VolumeVoz.Text) > 100)
			{
				MessageBox.Show("O Volume da Voz deve ser entre 1 e 100");
				return;
			}
                if(Convert.ToInt32(TXT_Sensibilidade_Reconhecimento.Text) < 1 || Convert.ToInt32(TXT_Sensibilidade_Reconhecimento.Text) > 10)
                {
                	MessageBox.Show("O valor da Confiança deve estar entre 1 e 10");
                	return;
                }

                Salvar_Registro();
			}
			catch{
				MessageBox.Show("Verifique se preencheu os campos corretamentes");
			}
			
		}
		void Config_VozLoad(object sender, EventArgs e)
		{
			atualizar_campos();
		}
		void BTN_SintetizarNomeUsuarioClick(object sender, EventArgs e)
		{
            try
            {
                Sintetiza_Voz.Volume = Convert.ToInt32(TXT_VolumeVoz.Text); // controla volume de saida
                Sintetiza_Voz.Rate = Convert.ToInt32(TXT_VelocidadeVoz.Text); // velocidade de fala
                Sintetiza_Voz.SetOutputToDefaultAudioDevice(); // auto falante padrao
                Sintetiza_Voz.SpeakAsyncCancelAll();
                Sintetiza_Voz.SpeakAsync(TXT_NomeUsuario.Text);
            }
            catch
            {
                MessageBox.Show("Aguarde a pronúncia do nome terminar, antes de ouvir outra pronúncia");
            }
		}
		private void atualizar_campos()
		{
			Model.OBJ_Configuracoes c = new Model.OBJ_Configuracoes();
			c.Consultar_Configuracoes();
			TXT_VelocidadeVoz.Text = c.getVelocidadeVoz().ToString();
			TXT_VolumeVoz.Text = c.getVolumeVoz().ToString();
			TXT_NomeUsuario.Text = c.getNomeUsuario();
			TXT_Sensibilidade_Reconhecimento.Text = c.getNivelConfianca().ToString();
			
		}
	}
}
