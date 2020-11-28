/*
 * Created by SharpDevelop.
 * User: Omnia
 * Date: 19/02/2020
 * Time: 14:40
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Windows.Forms;

//usado pelo reconhecimento
using Microsoft.Speech.Recognition;
using Microsoft.Speech.Synthesis;
using System.Globalization;

namespace Serena_5._.Controller
{
	/// <summary>
	/// Description of Reconhecimento_Voz.
	/// </summary>
	public class Reconhecimento_Voz
	{
        private static SpeechRecognitionEngine reconhecedor;//Não remover o static é obrigatorio por conta das funções usadas
        private SpeechSynthesizer Sintetiza_Voz = new SpeechSynthesizer();
        
		public void Iniciar_Reconhecimento()
        {
			Model.Conexao_BD c = new Model.Conexao_BD();
			
			Controles_do_sintetizador_de_voz();//Inicializa a configuração de voz salva no BD
			Carregar_Cultura();//Inicializa a cultura pt-BR
            Carregar_Gramatica_SQL();//inicialização da gramatica SQL
            Carregar_Gramatica_interna();// inicialização da gramatica Interna
			Carregar_Entrada_Saida_de_Voz();//Defini a entrada e saida da voz usadas
        }
		
		/*---------------------Reconhecimento de voz---------------------------*/
		public void Controles_do_sintetizador_de_voz()
		{
			Model.OBJ_Configuracoes c = new Model.OBJ_Configuracoes();
			c.Consultar_Configuracoes();	
			try{
				Sintetiza_Voz.Volume = Convert.ToInt32(c.getVolumeVoz()); // controla volume de saida
				Sintetiza_Voz.Rate = Convert.ToInt32(c.getVelocidadeVoz()); // velocidade de fala
			}
			catch(Exception ex){
				MessageBox.Show("Houve um erro ao definir o volume ou a fala do sintetizador de voz \nMotivo: " + ex.Message);
			}
		}
		private void Carregar_Cultura()
		{
			try{
                CultureInfo ci = new CultureInfo("pt-BR");// Idioma utilizado
                reconhecedor = new SpeechRecognitionEngine(ci);
            } 
            catch (Exception ex)
            {
                MessageBox.Show("Houve um erro durante o uso da cultura pt-BR escolhida \nMotivo: " + ex.Message);
            }
		}
		private void Carregar_Gramatica_interna()
		{
			Model.Pronuncia_Comandos p = new Model.Pronuncia_Comandos();
			try{
				//Ler as pronuncias internas e adiciona em uma lista
				var lista_pronuncias = new Choices();
				foreach (string element in p.Comandos_Internos)
				{
					lista_pronuncias.Add(element);
				}
				
				//Construindo a gramatica com a lista de pronuncias
				GrammarBuilder gramatica = new GrammarBuilder();
				gramatica.Append(lista_pronuncias);
				
				//passando a gramatica criada para a biblioteca
				Grammar g = new Grammar(gramatica);
				g.Name = "Gramatica_Interna";
				reconhecedor.RequestRecognizerUpdate();
				reconhecedor.LoadGrammarAsync(g);
			}
            catch (Exception ex)
            {
                MessageBox.Show("Houve um erro ao criar ao carregar ou criar a Gramatica de comandos internos do sistema \nMotivo: " + ex.Message);
            }
            try{
            	//reconhecedor.SpeechDetected += reconhecedor_SpeechDetected;//Detecção de Voz
                reconhecedor.SpeechRecognized += Executa_Comandos_Internos;//Executa ações com comando de voz
               	//reconhecedor.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(Executar_Comandos.Executa_Comandos_Internos);
            }
            catch(Exception ex){
            	MessageBox.Show("Erro encontrado ao detectar a voz do usuário ou executar os comandos \nMotivo: " + ex.Message);
            }
		}
        private void Carregar_Gramatica_SQL()
		{
			try
            {
	        	string Comando_SQL = "Select Pronuncia from controlecomando";
	        	Model.Conexao_BD c = new Model.Conexao_BD();
	        	c.Conexao.Open();
	        	SQLiteCommand Comando = new SQLiteCommand(Comando_SQL,c.Conexao);//instancio o metodo SqlliteCommand
	        	SQLiteDataReader sdr = Comando.ExecuteReader();//Lê o resultado de um comando sql

                while (sdr.Read()){
                    //Faz a leitura de toda a coluna 'Pronuncia'
                    string Socialcmd = sdr["Pronuncia"].ToString();
                    Grammar commandgrammar = new Grammar(new GrammarBuilder(new Choices(Socialcmd)));
                    commandgrammar.Name = "Gramatica_SQL";
                    //reconhecedor.RequestRecognizerUpdate();//Pausa o reconhecimento e atualiza a gramatica
                    reconhecedor.LoadGrammarAsync(commandgrammar);
                }
				sdr.Close();
				c.Conexao.Close();
			}
            catch (Exception ex)
            {
                MessageBox.Show("Houve um erro ao criar ou carregar a Gramatica de comandos SQL do sistema \nMotivo: " + ex.Message);
            }
            try{
                reconhecedor.SpeechRecognized += Executa_Comandos_Sqlite;//Executa ações com comando de voz
            }
            catch(Exception ex){
            	MessageBox.Show("Erro encontrado ao detectar a voz do usuário ou executar os comandos do banco de dados\nMotivo: " + ex.Message);
            }
		}
        private void Remover_Gramatica_SQL()
        {
            try {
                foreach (Grammar g in reconhecedor.Grammars)
                {
                    if (g.Name == "Gramatica_SQL")
                    {
                        reconhecedor.UnloadGrammar(g);
                        break;//Obrigatorio usar por conta do foreach
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Houve um erro ao limpar a gramática SQL para atualizar os Comandos\nMotivo: "+ex.Message);
            }
        }
        private void Carregar_Entrada_Saida_de_Voz()
		{
			try{
				reconhecedor.SetInputToDefaultAudioDevice(); // microfone padrao
	            Sintetiza_Voz.SetOutputToDefaultAudioDevice(); // auto falante padrao
                Ativar_Reconhecimento_de_voz();//Ativa o reconhecimento de voz
            }
            catch
            {
                MessageBox.Show("Não encontrei nenhum Microfone ativo neste computador\nRealize os passos abaixo e reinicie a SERENA\n\n" +
                    "\n 01° Passo: Verifique se o seu microfone está conectado e funcionando\n\n" +
                    "\n 02° Passo: Acesse a aba de configurações de som deste computador, clique na aba \"Gravação\" e verifique se o seu microfone está ativado");
            }

		}

        private void Ativar_Reconhecimento_de_voz()
        {
            try
            {
                reconhecedor.RecognizeAsync(RecognizeMode.Multiple); // multiplo reconhecimento
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possivel iniciar o reconhecimento de voz \n\nMotivo: " + ex.Message);
            }
        }
        private void Parar_Reconhecimento_de_voz()
        {
            try
            {
                reconhecedor.RecognizeAsyncStop(); // Encerrar o reconhecimento de voz
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível parar o reconhecimento de voz \n\nMotivo: " + ex.Message);
            }
        }
        public void Reiniciar_Reconhecimento()
        {
            reconhecedor.Dispose();
            Iniciar_Reconhecimento();
        }

        /*---------------------Ações do reconhecimento de voz---------------------------*/
        private void Executa_Comandos_Internos(object sender, SpeechRecognizedEventArgs e){
			if(e.Result == null) return;
				foreach (RecognizedPhrase frase in e.Result.Alternates){
			    	if(frase.Confidence >= 0.6){
                    Model.OBJ_Configuracoes usuario = new Model.OBJ_Configuracoes();
                    usuario.Consultar_Configuracoes();

                    string speech = e.Result.Text;
		            	try{
		            		switch(speech){
		            			case "Selecionar Tudo":
		            				SendKeys.Send("^a");
									Emulador_de_Voz("Tudo Selecionado");
		            		break;
		            			case "Copiar":
		            				Emulador_de_Voz("Copiando");
		            				SendKeys.Send("^c");
		            		break;
		            			case "Fechar Tela":
		            				Emulador_de_Voz("Fechei a tela");
		            				SendKeys.Send("%{F4}");
		            		break;
		            			case "Colar":
		            				SendKeys.Send("^v");
									Emulador_de_Voz("Colando");
		            		break;
		            			case "Leia esse texto":
								    //Método que lê o texto que estiver na área de tranferência
		            				SendKeys.Send("^c");
									Emulador_de_Voz(Clipboard.GetText());
                             break;
		            			case "Pesquisa no Google":
								    //Método que copia o que o usuário selecionou e pesquisa a informação no Google
									SendKeys.Send("^c");
									Emulador_de_Voz("Procurando." + Clipboard.GetText() + ".No google");
									Process.Start("https://www.google.com/search?q="+ Clipboard.GetText());
		            		break;
		            			case "Pesquisa no wikipedia":
		            				//Método que copia o que o usuário selecionou e pesquisa a informação no Google
									SendKeys.Send("^c");
									Emulador_de_Voz("Procurando." + Clipboard.GetText() + ".No úikipedía");
									Process.Start("https://pt.wikipedia.org/wiki/"+ Clipboard.GetText());
                                break;
		            			case "Pesquisa Imagens":
									//Método que copia o que o usuário selecionou e pesquisa a informação no Google
									SendKeys.Send("^c");
									Emulador_de_Voz("Procurando imagens sobre." + Clipboard.GetText());
									Process.Start("https://www.google.com/search?q="+ Clipboard.GetText()+"&tbm=isch");
                                break;
		            			case "Pesquisa Videos":
		            				//Método que copia o que o usuário selecionou e pesquisa a informação no Google
									SendKeys.Send("^c");
									Emulador_de_Voz("Procurando Vídeos sobre." + Clipboard.GetText());
									Process.Start("https://www.google.com/search?q="+ Clipboard.GetText()+"&tbm=vid");
                                break;
		            			case "Pesquisa Noticias":
								//Método que copia o que o usuário selecionou e pesquisa a informação no Google
									SendKeys.Send("^c");
									Emulador_de_Voz("Procurando Notícias sobre."+Clipboard.GetText());
									Process.Start("https://www.google.com/search?q="+ Clipboard.GetText()+"&tbm=nws");
                               break;
		            			case "Pesquisa no Youtube":
		            				//Método que copia o que o usuário selecionou e pesquisa a informação no Google
									SendKeys.Send("^c");
									Emulador_de_Voz("Procurando. " + Clipboard.GetText() + "No youtube");
									Process.Start("https://www.youtube.com/results?search_query="+ Clipboard.GetText());
                              break;
		            			case "Que horas são":
		            				Emulador_de_Voz("agora são exatamente,"+DateTime.Now.ToString("hh:mm"));
		            		break;
                               case "Que dia é hoje":
                                    Emulador_de_Voz("Hoje é," + DateTime.Today.Date);
                                break;
                                case "Quem é você":
                					Emulador_de_Voz("Pode me chamar de Serena, sou uma assistente de voz desenvolvida para ajudar em tarefas simples, como controlar o seus vídeos do youtube, te ajudar em jogos, ou formatar seus documentos");
                			    break;
							case "Serena":
								View.Tela_Inicio tela = new View.Tela_Inicio();
                                if (Application.OpenForms["Tela_Inicio"] != null)
                                {
                                    Application.OpenForms["Tela_Inicio"].WindowState = FormWindowState.Minimized;
                                    Application.OpenForms["Tela_Inicio"].WindowState = FormWindowState.Normal;
                                    Emulador_de_Voz("Estou aqui." + usuario.getNomeUsuario());
                                }
								break;
							case "Para de Falar":
	                				//Encerra todos os processos que usem a voz
	                				Encerrar_Voz();
                                    Emulador_de_Voz("Desculpe."+usuario.getNomeUsuario());
                			break;
                				case "Abrir lista de comandos":
                                    if (Application.OpenForms["Exibir_Comandos"] != null)
                                    {
                                        Application.OpenForms["Tela_Inicio"].WindowState = FormWindowState.Normal;
                                        Application.OpenForms["Exibir_Comandos"].WindowState = FormWindowState.Normal;
                                        Emulador_de_Voz("A lista de comandos já está aberta");
                                    }
                                    else
                                    {
                                        Emulador_de_Voz("Exibindo Lista de comandos");
                                        View.Exibir_Comandos abrir_comandos = new View.Exibir_Comandos();
                                        abrir_comandos.Show();
                                        Application.OpenForms["Exibir_Comandos"].WindowState = FormWindowState.Normal;
                                    }
                                break;
                				case "Fechar lista de comandos":
								if (Application.OpenForms["Exibir_Comandos"] != null)
								{
									Application.OpenForms["Exibir_Comandos"].Close();
									Emulador_de_Voz("Fechando Lista de comandos");
								}
								else
								{
									Emulador_de_Voz("A lista de comandos não está aberta");
								}
                			break;
                				case "Abrir Criador de Comandos":
                                    if (Application.OpenForms["Criador_Comandos"] != null)
                                    {
                                        Application.OpenForms["Criador_Comandos"].WindowState = FormWindowState.Normal;
                                        Emulador_de_Voz("A tela para criar comandos já está aberta");
                                    }
                                    else
                                    {
                                        Emulador_de_Voz("Abrindo tela para criar comando");
                                        View.Criador_Comandos Criar_Comando = new View.Criador_Comandos();
                                        Criar_Comando.Show();
                                        Application.OpenForms["Criador_Comandos"].WindowState = FormWindowState.Normal;
                                    }
                                break;
                				case "Fechar Criador de Comandos":
                					if (Application.OpenForms["Criador_Comandos"] != null)
                                    {
                                        Application.OpenForms["Criador_Comandos"].Close();
                                        Emulador_de_Voz("Fechando tela");
                                    }
                                    else
                                    {
                                        Emulador_de_Voz("A tela para criar comando não está aberta");
                                    }
                                break;
                				case "Abrir Configurações de voz":                					
                                    if (Application.OpenForms["Config_Voz"] != null)
                                    {
                                        Application.OpenForms["Config_Voz"].WindowState = FormWindowState.Normal;
                                        Emulador_de_Voz("A tela de configurações de voz já está aberta");
                                    }
                                    else
                                    {
                                        Emulador_de_Voz("Exibindo Configurações de voz");
                                        View.Config_Voz Abrir_configuracoes = new View.Config_Voz();
                                        Abrir_configuracoes.Show();
                                        Application.OpenForms["Config_Voz"].WindowState = FormWindowState.Normal;
                                    }
                                break;
                				case "Fechar Configurações de voz":
                                    if (Application.OpenForms["Config_Voz"] != null)
                                    {
                                        Application.OpenForms["Config_Voz"].Close();
                                        Emulador_de_Voz("Fechando Configurações de voz");
                                    }
                                    else
                                    {
                                        Emulador_de_Voz("A tela de Configurações de voz não está aberta");
                                    }
                                break;
		            			default:
		            		break;
		            		}
		            	}
		            	catch(Exception Erro){
		            		MessageBox.Show("Houve um erro com os comandos internos \n"+Erro.Message);
		            	}
					}
				}
		}
		private void Executa_Comandos_Sqlite(object sender, SpeechRecognizedEventArgs e){
			if(e.Result == null) return;
				foreach (RecognizedPhrase frase in e.Result.Alternates){
			    	if(frase.Confidence >= 0.6){
		            	string speech = e.Result.Text;
			            try{
		            		
		            		DataTable Tabela = new DataTable();
				        	string Comando_SQL = "Select Id,Pronuncia,Instrucao,RespostaEsperada,IsCommand,Executar1,Executar2,TipoComando from controlecomando";
				        	Model.Conexao_BD c = new Model.Conexao_BD();
				        	c.Conectar();
				        	SQLiteCommand Comando = new SQLiteCommand(Comando_SQL,c.Conexao);//instancio o metodo SqlliteCommand
				        	SQLiteDataReader sdr = Comando.ExecuteReader();//Lê o resultado de um comando sql

				        	while (sdr.Read())
							{
				                {				                    
				                    string Id = sdr["Id"].ToString();
					            	string Pronuncia = sdr["Pronuncia"].ToString();
					            	string Instrucao = sdr["Instrucao"].ToString();
					            	string RespostaEsperada = sdr["RespostaEsperada"].ToString();
					            	string IsCommand = sdr["IsCommand"].ToString();
					            	string Executar1 = sdr["Executar1"].ToString();
					            	string Executar2 = sdr["Executar2"].ToString();
					            	string TipoComando = sdr["TipoComando"].ToString();
			            		
				            	if (Pronuncia == speech)
				                    {
				                    	if(IsCommand == "Sim")
				                    	{
				                    		switch (TipoComando)
				                    		{
				                    		case "CMD":
				                    			try
				                    			{
				                    				if(Executar1 == "")
				                    				{
				                    					Process.Start("\""+Executar2+"\"");
				                    				}
				                    				else if(Executar2 == "")
				                    				{
				                    					Process.Start("\""+Executar1+"\"");
				                    				}
				                    				else
				                    				{
				                    					Process.Start("\""+Executar1+"\"","\""+Executar2+"\"");//scape para poder usar as aspas dentro de outras aspas
				                    				}
													Encerrar_Voz();
													Emulador_de_Voz(RespostaEsperada);
												}
				                    			catch(Exception erro)
				                    			{
				                    			//Emulador_de_Voz("Encontrei um erro nesse comando, por padrão será deletado da base de dados");
				                    			MessageBox.Show(DateTime.Now+"\n"+"Detalhes: "+erro.Message);
				                    			Encerrar_Voz();
				                    			}
				                    		break;
				                    		case "Tecla":
				                    			try
				                    			{
													Encerrar_Voz();
													Emulador_de_Voz(RespostaEsperada);
				                    				SendKeys.Send(Executar1);
				                    			}
				                    			catch(Exception erro)
				                    			{
													Encerrar_Voz();
													Emulador_de_Voz("Encontrei um erro ao usar essa teclas, por padrão será deletado da base de dados");
					                    			MessageBox.Show(DateTime.Now+"\n"+"Detalhes: "+erro.Message);
				                    			}
				                    		break;
				                    		case "Site":
				                    			try
				                    			{
													Encerrar_Voz();
													Emulador_de_Voz(RespostaEsperada);
				                    				Process.Start("\""+Executar1+"\"");
				                    			}
				                    			catch(Exception erro)
				                    			{
													Encerrar_Voz();
													Emulador_de_Voz("Este não é um link válido, por padrão será deletado da base de dados");
													MessageBox.Show(DateTime.Now+"\n"+"Detalhes: "+erro.Message);
				                    			}
				                    		break;
				                    		case "Programa":
				                    			try
				                    			{
													Encerrar_Voz();
													Emulador_de_Voz(RespostaEsperada);
				                    				Process.Start("\""+Executar1+"\"");
				                    			}
				                    			catch(Exception erro)
				                    			{
													Encerrar_Voz();
													Emulador_de_Voz("O Endereço do programa não foi encontrado");
					                    			MessageBox.Show(DateTime.Now+"\n"+"Detalhes: "+erro.Message);
				                    			}
				                    		break;
				                    		default:
												Encerrar_Voz();
												Emulador_de_Voz("Não conheço o tipo de comando da instrução,"+speech+"");
				                    		break;
				                    		}
				                    	}
				                    	else{
										//Caso não seja um comando, escrever a instrução na tela
					                    	//Encerrar_Voz();
				                    	}
				                    }
				                }
			            	}
							//sdr.Close();
							c.Desconectar();
			            }
		            	catch (Exception ex){
		                	MessageBox.Show("Você perguntou: "+speech+"\nDetalhes: " +ex.Message);
		            	}
		        	}
			}
		}
		
		/*---------------------Sintetizador de voz---------------------------*/
		public void Emulador_de_Voz(string Texto_para_Voz)
		{
			try{
				Encerrar_Voz();
				Sintetiza_Voz.SpeakAsync(Texto_para_Voz);
			}
			catch(Exception ex){
				MessageBox.Show("Houve um erro ao sintetizar a voz, \nMotivo: "+ex.Message);
			}
		}
		private void Encerrar_Voz()
		{
			Sintetiza_Voz.SpeakAsyncCancelAll();
		}
		
	}
}
