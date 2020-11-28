/*
 * Created by SharpDevelop.
 * User: Omnia
 * Date: 18/02/2020
 * Time: 09:53
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Serena_5._.View
{
	/// <summary>
	/// Description of Tela_Inicio.
	/// </summary>
	public partial class Tela_Inicio : Form
	{
		public Tela_Inicio()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void Tela_InicioLoad(object sender, EventArgs e)
		{
            //posição da tela ao iniciar
            StartPosition = FormStartPosition.Manual;
            Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - Width, 
            Screen.PrimaryScreen.WorkingArea.Height - Height);

            Controller.Reconhecimento_Voz voz = new Controller.Reconhecimento_Voz();
            voz.Iniciar_Reconhecimento();

            Model.OBJ_Configuracoes d = new Model.OBJ_Configuracoes();
            d.Consultar_Configuracoes();
            voz.Emulador_de_Voz("Bem Vindo " + d.getNomeUsuario() + ". como posso te ajudar");
        }

		void BTN_ConfiguracoesClick(object sender, EventArgs e)
		{
			View.Config_Voz c = new View.Config_Voz();
			c.Show();
		}
		void BTN_CriarComandosClick(object sender, EventArgs e)
		{
			View.Criador_Comandos c = new View.Criador_Comandos();
			c.Show();
		}
		void BTN_ExibirComandosClick(object sender, EventArgs e)
		{
			View.Exibir_Comandos c = new View.Exibir_Comandos();
			c.Show();
		}
		void BTN_ImportarComandosClick(object sender, EventArgs e)
		{
			View.Importar_Comandos c = new View.Importar_Comandos();
			c.Show();
		}
		public void Atualiza_label_StatusSistema(string StatusSistema)
		{
			
		}
	}
}
