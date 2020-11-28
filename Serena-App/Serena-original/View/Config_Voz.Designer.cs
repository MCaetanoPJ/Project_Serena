/*
 * Created by SharpDevelop.
 * User: Omnia
 * Date: 17/02/2020
 * Time: 16:38
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Serena_5._.View
{
	partial class Config_Voz
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button BTN_Salvar;
		private System.Windows.Forms.TextBox TXT_VolumeVoz;
		private System.Windows.Forms.TextBox TXT_VelocidadeVoz;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox TXT_NomeUsuario;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox TXT_Sensibilidade_Reconhecimento;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Button BTN_SintetizarNomeUsuario;
		
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BTN_Salvar = new System.Windows.Forms.Button();
            this.TXT_VolumeVoz = new System.Windows.Forms.TextBox();
            this.TXT_VelocidadeVoz = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TXT_NomeUsuario = new System.Windows.Forms.TextBox();
            this.TXT_Sensibilidade_Reconhecimento = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.BTN_SintetizarNomeUsuario = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Volume da Voz";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Velocidade da Voz";
            // 
            // BTN_Salvar
            // 
            this.BTN_Salvar.Location = new System.Drawing.Point(152, 160);
            this.BTN_Salvar.Name = "BTN_Salvar";
            this.BTN_Salvar.Size = new System.Drawing.Size(131, 25);
            this.BTN_Salvar.TabIndex = 4;
            this.BTN_Salvar.Text = "Salvar";
            this.BTN_Salvar.UseVisualStyleBackColor = true;
            this.BTN_Salvar.Click += new System.EventHandler(this.BTN_SalvarClick);
            // 
            // TXT_VolumeVoz
            // 
            this.TXT_VolumeVoz.Location = new System.Drawing.Point(151, 49);
            this.TXT_VolumeVoz.MaxLength = 3;
            this.TXT_VolumeVoz.Name = "TXT_VolumeVoz";
            this.TXT_VolumeVoz.Size = new System.Drawing.Size(131, 20);
            this.TXT_VolumeVoz.TabIndex = 1;
            // 
            // TXT_VelocidadeVoz
            // 
            this.TXT_VelocidadeVoz.Location = new System.Drawing.Point(151, 84);
            this.TXT_VelocidadeVoz.MaxLength = 2;
            this.TXT_VelocidadeVoz.Name = "TXT_VelocidadeVoz";
            this.TXT_VelocidadeVoz.Size = new System.Drawing.Size(131, 20);
            this.TXT_VelocidadeVoz.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 23);
            this.label3.TabIndex = 5;
            this.label3.Text = "Pronuncia do Seu Nome";
            // 
            // TXT_NomeUsuario
            // 
            this.TXT_NomeUsuario.Location = new System.Drawing.Point(152, 17);
            this.TXT_NomeUsuario.MaxLength = 20;
            this.TXT_NomeUsuario.Name = "TXT_NomeUsuario";
            this.TXT_NomeUsuario.Size = new System.Drawing.Size(130, 20);
            this.TXT_NomeUsuario.TabIndex = 0;
            // 
            // TXT_Sensibilidade_Reconhecimento
            // 
            this.TXT_Sensibilidade_Reconhecimento.Location = new System.Drawing.Point(151, 121);
            this.TXT_Sensibilidade_Reconhecimento.MaxLength = 3;
            this.TXT_Sensibilidade_Reconhecimento.Name = "TXT_Sensibilidade_Reconhecimento";
            this.TXT_Sensibilidade_Reconhecimento.Size = new System.Drawing.Size(131, 20);
            this.TXT_Sensibilidade_Reconhecimento.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(288, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 23);
            this.label5.TabIndex = 9;
            this.label5.Text = "0 -100";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(288, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 23);
            this.label6.TabIndex = 10;
            this.label6.Text = "1 - 10";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(288, 121);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 23);
            this.label7.TabIndex = 11;
            this.label7.Text = "0.0 - 1.0";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(12, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 39);
            this.label4.TabIndex = 12;
            this.label4.Text = "Sensibilidade do Reconhecimento de Voz";
            // 
            // BTN_SintetizarNomeUsuario
            // 
            this.BTN_SintetizarNomeUsuario.Location = new System.Drawing.Point(288, 17);
            this.BTN_SintetizarNomeUsuario.Name = "BTN_SintetizarNomeUsuario";
            this.BTN_SintetizarNomeUsuario.Size = new System.Drawing.Size(85, 20);
            this.BTN_SintetizarNomeUsuario.TabIndex = 13;
            this.BTN_SintetizarNomeUsuario.Text = "Ouvir";
            this.BTN_SintetizarNomeUsuario.UseVisualStyleBackColor = true;
            this.BTN_SintetizarNomeUsuario.Click += new System.EventHandler(this.BTN_SintetizarNomeUsuarioClick);
            // 
            // Config_Voz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 198);
            this.Controls.Add(this.BTN_SintetizarNomeUsuario);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TXT_Sensibilidade_Reconhecimento);
            this.Controls.Add(this.TXT_NomeUsuario);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TXT_VelocidadeVoz);
            this.Controls.Add(this.TXT_VolumeVoz);
            this.Controls.Add(this.BTN_Salvar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Config_Voz";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configurações de Saída de Voz";
            this.Load += new System.EventHandler(this.Config_VozLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
    }
}
