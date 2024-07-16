/*
 * Criado por SharpDevelop.
 * Usuário: PC
 * Data: 21/06/2024
 * Hora: 14:00
 * 
 * Para alterar este modelo use Ferramentas | Opções | Codificação | Editar Cabeçalhos Padrão.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace rodizicarros
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			
			InitializeComponent();
			
		}
		void Button1Click(object sender, EventArgs e)
		{
			openFileDialog1.ShowDialog();
	
		}
		
		void Button2Click(object sender, EventArgs e)
		{
			var rodizio = new Dictionary<string, List<string>>()
	 	{
	        { "Segunda-feira", new List<string>() },
	        { "Terça-feira", new List<string>() },
	        { "Quarta-feira", new List<string>() },
	        { "Quinta-feira", new List<string>() },
	        { "Sexta-feira", new List<string>() }
	    };
	
	    foreach (string linha in richTextBox1.Lines)
	    {
	        string[] dados = linha.Split('\t');
	        if (dados.Length == 2)
	        {
	            string chapa = dados[0];
	            string motorista = dados[1];
	            char ultimodigito = chapa[chapa.Length - 1];
	
	            if (ultimodigito == '1' || ultimodigito == '2')
	            {
	                rodizio["Segunda-feira"].Add(motorista);
	            }
	            else if (ultimodigito == '3' || ultimodigito == '4')
	            {
	                rodizio["Terça-feira"].Add(motorista);
	            }
	            else if (ultimodigito == '5' || ultimodigito == '6')
	            {						
	                rodizio["Quarta-feira"].Add(motorista);
	            }
	            else if (ultimodigito == '7' || ultimodigito == '8')
	            {
	                rodizio["Quinta-feira"].Add(motorista);
	            }
	            else if (ultimodigito == '9' || ultimodigito == '0')
	            {
	                rodizio["Sexta-feira"].Add(motorista);
	            }
	        }
	    }
	
	       richTextBox2.Clear();
	       foreach (var dia in rodizio.Keys)
	       {
	       	string motoristas = string.Join(", ", rodizio[dia]);
	        richTextBox2.AppendText(dia + ": " + motoristas + "\n");
	       }
		}
		
		void Button3Click(object sender, EventArgs e)
		{
			saveFileDialog1.ShowDialog();
	
		}
		void OpenFileDialog1FileOk(object sender, System.ComponentModel.CancelEventArgs e)
		{
			
		    try
	          {
	          richTextBox1.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.PlainText);
	          MessageBox.Show("Dados carregados com sucesso!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
	          }
	        catch
	        	
	        {
	        MessageBox.Show("Erro ao carregar o arquivo.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
	        richTextBox1.Clear();
	        }
	        
		}
		void SaveFileDialog1FileOk(object sender, System.ComponentModel.CancelEventArgs e)
		{
			try
			{
				
	          richTextBox2.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
	           MessageBox.Show("Arquivo salvo com sucesso!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}catch
	    	{
	       	
	        MessageBox.Show("Erro ao salvar o arquivo " , "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
	       	}
		}
		void MainFormLoad(object sender, EventArgs e)
		{
	
		}
	}
}
