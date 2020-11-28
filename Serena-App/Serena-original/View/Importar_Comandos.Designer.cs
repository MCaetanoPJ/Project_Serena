/*
 * Created by SharpDevelop.
 * User: Omnia
 * Date: 12/02/2020
 * Time: 14:18
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Serena_5._.View
{
	partial class Importar_Comandos
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Button BTN_ImportarNovosComandos;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.Button BTN_ExportarComandos;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.PictureBox pictureBox2;
		
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Importar_Comandos));
			this.BTN_ImportarNovosComandos = new System.Windows.Forms.Button();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.BTN_ExportarComandos = new System.Windows.Forms.Button();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			this.SuspendLayout();
			// 
			// BTN_ImportarNovosComandos
			// 
			this.BTN_ImportarNovosComandos.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.BTN_ImportarNovosComandos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.BTN_ImportarNovosComandos.Location = new System.Drawing.Point(12, 12);
			this.BTN_ImportarNovosComandos.Name = "BTN_ImportarNovosComandos";
			this.BTN_ImportarNovosComandos.Size = new System.Drawing.Size(254, 43);
			this.BTN_ImportarNovosComandos.TabIndex = 0;
			this.BTN_ImportarNovosComandos.Text = "Importar Novos Comandos";
			this.BTN_ImportarNovosComandos.UseVisualStyleBackColor = true;
			this.BTN_ImportarNovosComandos.Click += new System.EventHandler(this.BTN_ImportarNovosComandosClick);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "Dados";
			this.openFileDialog1.Filter = "\"Arquivo de Banco de Dados(*.db)|*.db\"";
			// 
			// BTN_ExportarComandos
			// 
			this.BTN_ExportarComandos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.BTN_ExportarComandos.Location = new System.Drawing.Point(12, 81);
			this.BTN_ExportarComandos.Name = "BTN_ExportarComandos";
			this.BTN_ExportarComandos.Size = new System.Drawing.Size(254, 43);
			this.BTN_ExportarComandos.TabIndex = 1;
			this.BTN_ExportarComandos.Text = "Exportar Arquivo com Comandos";
			this.BTN_ExportarComandos.UseVisualStyleBackColor = true;
			this.BTN_ExportarComandos.Click += new System.EventHandler(this.BTN_ExportarComandosClick);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(272, 12);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(65, 43);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 2;
			this.pictureBox1.TabStop = false;
			// 
			// pictureBox2
			// 
			this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
			this.pictureBox2.Location = new System.Drawing.Point(272, 81);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(65, 43);
			this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox2.TabIndex = 3;
			this.pictureBox2.TabStop = false;
			// 
			// Importar_Comandos
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(355, 141);
			this.Controls.Add(this.pictureBox2);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.BTN_ImportarNovosComandos);
			this.Controls.Add(this.BTN_ExportarComandos);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Importar_Comandos";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Importar_Comandos";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			this.ResumeLayout(false);

		}
	}
}
