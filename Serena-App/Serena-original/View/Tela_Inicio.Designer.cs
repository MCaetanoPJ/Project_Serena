/*
 * Created by SharpDevelop.
 * User: Omnia
 * Date: 18/02/2020
 * Time: 09:53
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Serena_5._.View
{
	partial class Tela_Inicio
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Button BTN_Configuracoes;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button BTN_CriarComandos;
		private System.Windows.Forms.Button BTN_ImportarComandos;
		private System.Windows.Forms.Button BTN_ExibirComandos;
		private System.Windows.Forms.Label label1;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Tela_Inicio));
            this.BTN_Configuracoes = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BTN_CriarComandos = new System.Windows.Forms.Button();
            this.BTN_ImportarComandos = new System.Windows.Forms.Button();
            this.BTN_ExibirComandos = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // BTN_Configuracoes
            // 
            this.BTN_Configuracoes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Configuracoes.ForeColor = System.Drawing.Color.White;
            this.BTN_Configuracoes.Location = new System.Drawing.Point(191, 131);
            this.BTN_Configuracoes.Name = "BTN_Configuracoes";
            this.BTN_Configuracoes.Size = new System.Drawing.Size(164, 33);
            this.BTN_Configuracoes.TabIndex = 0;
            this.BTN_Configuracoes.Text = "Configurações de Voz\r\n";
            this.BTN_Configuracoes.UseVisualStyleBackColor = true;
            this.BTN_Configuracoes.Click += new System.EventHandler(this.BTN_ConfiguracoesClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(182, 152);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.WaitOnLoad = true;
            // 
            // BTN_CriarComandos
            // 
            this.BTN_CriarComandos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_CriarComandos.ForeColor = System.Drawing.Color.White;
            this.BTN_CriarComandos.Location = new System.Drawing.Point(191, 12);
            this.BTN_CriarComandos.Name = "BTN_CriarComandos";
            this.BTN_CriarComandos.Size = new System.Drawing.Size(164, 33);
            this.BTN_CriarComandos.TabIndex = 2;
            this.BTN_CriarComandos.Text = "Criar/Editar Comando";
            this.BTN_CriarComandos.UseVisualStyleBackColor = true;
            this.BTN_CriarComandos.Click += new System.EventHandler(this.BTN_CriarComandosClick);
            // 
            // BTN_ImportarComandos
            // 
            this.BTN_ImportarComandos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_ImportarComandos.ForeColor = System.Drawing.Color.White;
            this.BTN_ImportarComandos.Location = new System.Drawing.Point(191, 90);
            this.BTN_ImportarComandos.Name = "BTN_ImportarComandos";
            this.BTN_ImportarComandos.Size = new System.Drawing.Size(168, 35);
            this.BTN_ImportarComandos.TabIndex = 3;
            this.BTN_ImportarComandos.Text = "Importar/Exportar Comandos";
            this.BTN_ImportarComandos.UseVisualStyleBackColor = true;
            this.BTN_ImportarComandos.Click += new System.EventHandler(this.BTN_ImportarComandosClick);
            // 
            // BTN_ExibirComandos
            // 
            this.BTN_ExibirComandos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_ExibirComandos.ForeColor = System.Drawing.Color.White;
            this.BTN_ExibirComandos.Location = new System.Drawing.Point(191, 51);
            this.BTN_ExibirComandos.Name = "BTN_ExibirComandos";
            this.BTN_ExibirComandos.Size = new System.Drawing.Size(168, 33);
            this.BTN_ExibirComandos.TabIndex = 4;
            this.BTN_ExibirComandos.Text = "Lista de Comandos";
            this.BTN_ExibirComandos.UseVisualStyleBackColor = true;
            this.BTN_ExibirComandos.Click += new System.EventHandler(this.BTN_ExibirComandosClick);
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(83, 167);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 23);
            this.label1.TabIndex = 5;
            this.label1.Text = "Desenvolvido por Marcos Caetano";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Tela_Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(360, 198);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BTN_ExibirComandos);
            this.Controls.Add(this.BTN_ImportarComandos);
            this.Controls.Add(this.BTN_CriarComandos);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.BTN_Configuracoes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Tela_Inicio";
            this.Text = "Projeto S.E.R.E.N.A";
            this.Load += new System.EventHandler(this.Tela_InicioLoad);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

		}
    }
}
