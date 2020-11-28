/*
 * Created by SharpDevelop.
 * User: Omnia
 * Date: 19/02/2020
 * Time: 15:53
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Serena_5._.Model
{
	/// <summary>
	/// Description of Pronuncia_Comandos.
	/// </summary>
	public class Pronuncia_Comandos
	{		
		//Palavras aceitas
			public List<string> Comandos_Internos = new List<string> {
				"Leia esse texto", //Necessário o usuário selecionar o texto antes de dizer esse comando
	        	"Que horas são",
                "Que dia é hoje",
				"Serena",
				"Quem é você",
	        	"Para de Falar",
	        	
	        	//Comandos para fazer pesquisas, Todos são Necessário o usuário selecionar o texto antes de dizer esse comando
	        	"Pesquisa no Google",
	        	"Pesquisa Imagens",
	        	"Pesquisa Videos",
	        	"Pesquisa Noticias",
	        	"Pesquisa no Youtube",
	        	"Pesquisa no wikipedia",
	        	
	        	//Comandos para acessar telas
	        	"Abrir lista de comandos",
	        	"Fechar lista de comandos",
	        	"Abrir Criador de Comandos",
	        	"Fechar Criador de Comandos",
	        	"Abrir Configurações de voz",
	        	"Fechar Configurações de voz",
	        	
	        	//Comandos Básicos
	        	"Copiar",
	        	"Colar",
	        	"Selecionar Tudo",
	        	"Fechar Tela"
			};
		
			public Pronuncia_Comandos()
			{
				
			}
	}
}
