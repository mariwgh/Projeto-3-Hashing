using apListaLigada;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace apHashing
{
    public partial class Form1 : Form
    {
        string hashEscolhido;
        ListaSimples<Dicionario> arqPalavraDica;

        BucketHash<Dicionario> bucketHash = new BucketHash<Dicionario>();
        SondLinear<string> sondLinear = new SondLinear<string>();
        SondQuad<string> sondQuadra = new SondQuad<string>();
        DuploHash<string> duplo = new DuploHash<string>();
        
        public Form1()
        {
            InitializeComponent();
            hashEscolhido = "";
        }


        //seleção da técnica de hashing:
        //qnd o user selecionar o radiobutton de buckethashing
        private void bcktHash_CheckedChanged(object sender, EventArgs e)
        {
            hashEscolhido = bcktHash.Text;
            FazerLeitura(arqPalavraDica);
        }

        //qnd o user selecionar o radiobutton de sondagem linear
        private void sondLin_CheckedChanged(object sender, EventArgs e)
        {
            hashEscolhido = sondLin.Text;
            FazerLeitura(arqPalavraDica);
        }

        //qnd o user selecionar o radiobutton de sondagem quadrática
        private void sondQua_CheckedChanged(object sender, EventArgs e)
        {
            hashEscolhido = sondQua.Text;
            FazerLeitura(arqPalavraDica);
        }

        //qnd o user selecionar o radiobutton de duplo hashing
        private void duplHash_CheckedChanged(object sender, EventArgs e)
        {
            hashEscolhido = duplHash.Text;
            FazerLeitura(arqPalavraDica);
        }

        //ler o arquivo de palavras e dicas qnd ele escolhe uma tecnica

        private void FazerLeitura(ListaSimples<Dicionario> qualLista)
        {
            qualLista = new ListaSimples<Dicionario>();     // recria a lista a ser lida

            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)  // usuário pressionou botão Abrir?
            {
                StreamReader arquivo = new StreamReader(openFileDialog.FileName);
                string linha = "";
                while (!arquivo.EndOfStream)  // enquanto não acabou o arquivo
                {
                    linha = arquivo.ReadLine();
                    qualLista.InserirAposOFim(new Dicionario(linha));
                }
                lsbListagem.Text = qualLista.ListarDados().ToString();
                arquivo.Close();
            }
        }

        //se ele tiver escolhido outra tecnica antes, percorrer a tebela e salvar no arq, para percorrer segundo a nova tecnica

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            switch (hashEscolhido.Trim())
            {
                case "Bucket hashing":
                    bucketHash.Incluir(txtBPalavra.Text);
                    bucketHash.Incluir(txtBDica.Text);
                    break;

                case "Sondagem linear":
                    sondLinear.Incluir(txtBPalavra.Text);
                    sondLinear.Incluir(txtBDica.Text);
                    break;

                case "Sondagem quadrática":
                    sondQuadra.Incluir(txtBPalavra.Text);
                    sondQuadra.Incluir(txtBDica.Text);
                    break;

                case "Duplo hashing":
                    duplo.Incluir(txtBPalavra.Text);
                    duplo.Incluir(txtBDica.Text);
                    break;

                default: break;
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            switch (hashEscolhido.Trim())
            {
                case "Bucket hashing":
                    bucketHash.Excluir(txtBPalavra.Text);
                    bucketHash.Excluir(txtBDica.Text);
                    break;

                case "Sondagem linear":
                    sondLinear.Excluir(txtBPalavra.Text);
                    sondLinear.Excluir(txtBDica.Text);
                    break;
                case "Sondagem quadrática":
                    sondQuadra.Excluir(txtBPalavra.Text);
                    sondQuadra.Excluir(txtBDica.Text);
                    break;
                case "Duplo hashing":
                    duplo.Excluir(txtBPalavra.Text);
                    duplo.Excluir(txtBDica.Text);
                    break;
                default: break;
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            switch (hashEscolhido.Trim())
            {
                case "Bucket hashing":
                    bucketHash.Alterar(txtBPalavra.Text, txtBPalavra.Text);
                    bucketHash.Alterar(txtBDica.Text, txtBDica.Text);
                    break;

                case "Sondagem linear":
                    sondLinear.Alterar(txtBPalavra.Text, txtBPalavra.Text);
                    sondLinear.Alterar(txtBDica.Text, txtBDica.Text);
                    break;
                case "Sondagem quadrática":
                    sondQuadra.Alterar(txtBPalavra.Text, txtBPalavra.Text);
                    sondQuadra.Alterar(txtBDica.Text, txtBDica.Text);
                    break;
                case "Duplo hashing":
                    duplo.Alterar(txtBPalavra.Text, txtBPalavra.Text);
                    duplo.Alterar(txtBDica.Text, txtBDica.Text);
                    break;
                default: break;
            }
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            switch (hashEscolhido.Trim())
            {
                case "Bucket hashing":
                    bucketHash.Conteudo();
                    break;

                case "Sondagem linear":
                    sondLinear.Conteudo();
                    break;
                case "Sondagem quadrática":
                    sondQuadra.Conteudo();
                    break;
                case "Duplo hashing":
                    duplo.Conteudo();
                    break;
                default: break;
            }
        }


        //qnd o programa for encerrado, percorrer a tabela de hashing e salvar os dados no arq

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                arqPalavraDica.GravarDados(openFileDialog.FileName);
            }

        }
    }
}
