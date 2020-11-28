/*
 * Created by SharpDevelop.
 * User: Omnia
 * Date: 12/02/2020
 * Time: 14:17
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Serena_5._.View
{
	partial class Criador_Comandos
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.ComboBox IsComando;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox TXT_Instrucao;
		private System.Windows.Forms.ComboBox TXT_TipoComando;
		private System.Windows.Forms.TextBox TXT_Pronuncia;
		private System.Windows.Forms.TextBox TXT_RespostaEsperada;
		private System.Windows.Forms.TextBox TXT_Executar1;
		private System.Windows.Forms.TextBox TXT_Executar2;
		private System.Windows.Forms.Button BTN_Salvar;
		private System.Windows.Forms.Button BTN_Limpar;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Button BTN_Deletar;
		private System.Windows.Forms.TextBox TXT_Id;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Button BTN_Testar_Executar1e2;
		private System.Windows.Forms.Button BTN_SelecionarPrograma;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		
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
            this.IsComando = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.TXT_Instrucao = new System.Windows.Forms.TextBox();
            this.TXT_Pronuncia = new System.Windows.Forms.TextBox();
            this.TXT_RespostaEsperada = new System.Windows.Forms.TextBox();
            this.TXT_Executar1 = new System.Windows.Forms.TextBox();
            this.TXT_Executar2 = new System.Windows.Forms.TextBox();
            this.BTN_Salvar = new System.Windows.Forms.Button();
            this.TXT_TipoComando = new System.Windows.Forms.ComboBox();
            this.BTN_Limpar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.BTN_Deletar = new System.Windows.Forms.Button();
            this.TXT_Id = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.BTN_Testar_Executar1e2 = new System.Windows.Forms.Button();
            this.BTN_SelecionarPrograma = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // IsComando
            // 
            this.IsComando.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.IsComando.FormattingEnabled = true;
            this.IsComando.Items.AddRange(new object[] {
            "Sim",
            "Não"});
            this.IsComando.Location = new System.Drawing.Point(369, 31);
            this.IsComando.Name = "IsComando";
            this.IsComando.Size = new System.Drawing.Size(298, 21);
            this.IsComando.TabIndex = 0;
            this.IsComando.SelectedIndexChanged += new System.EventHandler(this.IsComandoSelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(250, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "É Comando ?";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(250, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Instrução";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(250, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 23);
            this.label3.TabIndex = 3;
            this.label3.Text = "Pronuncia";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(250, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 23);
            this.label4.TabIndex = 4;
            this.label4.Text = "Tipo de Comando";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(250, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 23);
            this.label5.TabIndex = 5;
            this.label5.Text = "Resposta Esperada";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(252, 174);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 37);
            this.label6.TabIndex = 6;
            this.label6.Text = "Executar1";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(251, 217);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(112, 37);
            this.label7.TabIndex = 7;
            this.label7.Text = "Executar2";
            // 
            // TXT_Instrucao
            // 
            this.TXT_Instrucao.Location = new System.Drawing.Point(369, 60);
            this.TXT_Instrucao.MaxLength = 40;
            this.TXT_Instrucao.Name = "TXT_Instrucao";
            this.TXT_Instrucao.Size = new System.Drawing.Size(298, 20);
            this.TXT_Instrucao.TabIndex = 1;
            // 
            // TXT_Pronuncia
            // 
            this.TXT_Pronuncia.Location = new System.Drawing.Point(369, 89);
            this.TXT_Pronuncia.MaxLength = 40;
            this.TXT_Pronuncia.Name = "TXT_Pronuncia";
            this.TXT_Pronuncia.Size = new System.Drawing.Size(298, 20);
            this.TXT_Pronuncia.TabIndex = 2;
            // 
            // TXT_RespostaEsperada
            // 
            this.TXT_RespostaEsperada.Location = new System.Drawing.Point(369, 142);
            this.TXT_RespostaEsperada.MaxLength = 60;
            this.TXT_RespostaEsperada.Name = "TXT_RespostaEsperada";
            this.TXT_RespostaEsperada.Size = new System.Drawing.Size(298, 20);
            this.TXT_RespostaEsperada.TabIndex = 4;
            // 
            // TXT_Executar1
            // 
            this.TXT_Executar1.Location = new System.Drawing.Point(369, 174);
            this.TXT_Executar1.MaxLength = 200;
            this.TXT_Executar1.Multiline = true;
            this.TXT_Executar1.Name = "TXT_Executar1";
            this.TXT_Executar1.Size = new System.Drawing.Size(217, 37);
            this.TXT_Executar1.TabIndex = 5;
            // 
            // TXT_Executar2
            // 
            this.TXT_Executar2.Location = new System.Drawing.Point(369, 220);
            this.TXT_Executar2.MaxLength = 60;
            this.TXT_Executar2.Multiline = true;
            this.TXT_Executar2.Name = "TXT_Executar2";
            this.TXT_Executar2.Size = new System.Drawing.Size(217, 37);
            this.TXT_Executar2.TabIndex = 6;
            // 
            // BTN_Salvar
            // 
            this.BTN_Salvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Salvar.Location = new System.Drawing.Point(362, 271);
            this.BTN_Salvar.Name = "BTN_Salvar";
            this.BTN_Salvar.Size = new System.Drawing.Size(104, 27);
            this.BTN_Salvar.TabIndex = 7;
            this.BTN_Salvar.Text = "Salvar / Atualizar";
            this.BTN_Salvar.UseVisualStyleBackColor = true;
            this.BTN_Salvar.Click += new System.EventHandler(this.BTN_SalvarClick);
            // 
            // TXT_TipoComando
            // 
            this.TXT_TipoComando.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TXT_TipoComando.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.TXT_TipoComando.Items.AddRange(new object[] {
            "CMD",
            "Programa",
            "Site",
            "Tecla"});
            this.TXT_TipoComando.Location = new System.Drawing.Point(369, 115);
            this.TXT_TipoComando.Name = "TXT_TipoComando";
            this.TXT_TipoComando.Size = new System.Drawing.Size(298, 21);
            this.TXT_TipoComando.TabIndex = 3;
            this.TXT_TipoComando.SelectedIndexChanged += new System.EventHandler(this.TXT_TipoComandoSelectedIndexChanged);
            // 
            // BTN_Limpar
            // 
            this.BTN_Limpar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Limpar.Location = new System.Drawing.Point(252, 271);
            this.BTN_Limpar.Name = "BTN_Limpar";
            this.BTN_Limpar.Size = new System.Drawing.Size(104, 27);
            this.BTN_Limpar.TabIndex = 8;
            this.BTN_Limpar.Text = "Limpar";
            this.BTN_Limpar.UseVisualStyleBackColor = true;
            this.BTN_Limpar.Click += new System.EventHandler(this.BTN_LimparClick);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(1, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(244, 296);
            this.dataGridView1.TabIndex = 17;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1CellClick);
            // 
            // BTN_Deletar
            // 
            this.BTN_Deletar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Deletar.Location = new System.Drawing.Point(472, 271);
            this.BTN_Deletar.Name = "BTN_Deletar";
            this.BTN_Deletar.Size = new System.Drawing.Size(96, 27);
            this.BTN_Deletar.TabIndex = 9;
            this.BTN_Deletar.Text = "Deletar";
            this.BTN_Deletar.UseVisualStyleBackColor = true;
            this.BTN_Deletar.Click += new System.EventHandler(this.BTN_DeletarClick);
            // 
            // TXT_Id
            // 
            this.TXT_Id.Location = new System.Drawing.Point(369, 5);
            this.TXT_Id.MaxLength = 3;
            this.TXT_Id.Name = "TXT_Id";
            this.TXT_Id.ReadOnly = true;
            this.TXT_Id.Size = new System.Drawing.Size(298, 20);
            this.TXT_Id.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(252, 5);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(111, 23);
            this.label8.TabIndex = 20;
            this.label8.Text = "ID";
            // 
            // BTN_Testar_Executar1e2
            // 
            this.BTN_Testar_Executar1e2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Testar_Executar1e2.Location = new System.Drawing.Point(592, 220);
            this.BTN_Testar_Executar1e2.Name = "BTN_Testar_Executar1e2";
            this.BTN_Testar_Executar1e2.Size = new System.Drawing.Size(75, 37);
            this.BTN_Testar_Executar1e2.TabIndex = 21;
            this.BTN_Testar_Executar1e2.Text = "Testar instruções";
            this.BTN_Testar_Executar1e2.UseVisualStyleBackColor = true;
            this.BTN_Testar_Executar1e2.Click += new System.EventHandler(this.BTN_Testar_Executar1e2Click);
            // 
            // BTN_SelecionarPrograma
            // 
            this.BTN_SelecionarPrograma.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_SelecionarPrograma.Location = new System.Drawing.Point(592, 174);
            this.BTN_SelecionarPrograma.Name = "BTN_SelecionarPrograma";
            this.BTN_SelecionarPrograma.Size = new System.Drawing.Size(75, 37);
            this.BTN_SelecionarPrograma.TabIndex = 22;
            this.BTN_SelecionarPrograma.Text = "Selecionar Programa";
            this.BTN_SelecionarPrograma.UseVisualStyleBackColor = true;
            this.BTN_SelecionarPrograma.Click += new System.EventHandler(this.BTN_SelecionarProgramaClick);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Criador_Comandos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 306);
            this.Controls.Add(this.BTN_SelecionarPrograma);
            this.Controls.Add(this.BTN_Testar_Executar1e2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.TXT_Id);
            this.Controls.Add(this.BTN_Deletar);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.BTN_Limpar);
            this.Controls.Add(this.TXT_TipoComando);
            this.Controls.Add(this.BTN_Salvar);
            this.Controls.Add(this.TXT_Executar2);
            this.Controls.Add(this.TXT_Executar1);
            this.Controls.Add(this.TXT_RespostaEsperada);
            this.Controls.Add(this.TXT_Pronuncia);
            this.Controls.Add(this.TXT_Instrucao);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.IsComando);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Criador_Comandos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adicionar Comando";
            this.Load += new System.EventHandler(this.Criador_ComandosLoad);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}//((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
        //this.ResumeLayout(false);
        //this.PerformLayout();

    }
	}
