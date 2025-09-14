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
        SondLinear<Dicionario> sondLinear = new SondLinear<Dicionario>();
        SondQuad<Dicionario> sondQuadra = new SondQuad<Dicionario>();
        DuploHash<Dicionario> duplo = new DuploHash<Dicionario>();
        
        public Form1()
        {
            InitializeComponent();
            lsbListagem.Font = new Font("Consolas", 8);
            hashEscolhido = "";
        }


        //seleção da técnica de hashing:
        //qnd o user selecionar o radiobutton de buckethashing
        private void bcktHash_CheckedChanged(object sender, EventArgs e)
        {
            hashEscolhido = bcktHash.Text;
            FazerLeitura(arqPalavraDica);

            if (arqPalavraDica != null)
            {
                // Itera sobre a lista de dados lida do arquivo
                arqPalavraDica.PosicionaLista(0);
                var noAtual = arqPalavraDica.Atual;

                while (noAtual != null)
                {
                    // Insere cada item lido do arquivo na tabela de hash
                    bucketHash.Incluir(noAtual.Info);
                    noAtual = noAtual.Prox;
                }
            }

            btnListar_Click(sender, e);
        }

        //qnd o user selecionar o radiobutton de sondagem linear
        private void sondLin_CheckedChanged(object sender, EventArgs e)
        {
            hashEscolhido = sondLin.Text;
            FazerLeitura(arqPalavraDica);

            if (arqPalavraDica != null)
            {
                // Itera sobre a lista de dados lida do arquivo
                arqPalavraDica.PosicionaLista(0);
                var noAtual = arqPalavraDica.Atual;

                while (noAtual != null)
                {
                    // Insere cada item lido do arquivo na tabela de hash
                    bucketHash.Incluir(noAtual.Info);
                    noAtual = noAtual.Prox;
                }
            }

            btnListar_Click(sender, e);
        }

        //qnd o user selecionar o radiobutton de sondagem quadrática
        private void sondQua_CheckedChanged(object sender, EventArgs e)
        {
            hashEscolhido = sondQua.Text;
            FazerLeitura(arqPalavraDica);

            if (arqPalavraDica != null)
            {
                // Itera sobre a lista de dados lida do arquivo
                arqPalavraDica.PosicionaLista(0);
                var noAtual = arqPalavraDica.Atual;

                while (noAtual != null)
                {
                    // Insere cada item lido do arquivo na tabela de hash
                    bucketHash.Incluir(noAtual.Info);
                    noAtual = noAtual.Prox;
                }
            }

            btnListar_Click(sender, e);
        }

        //qnd o user selecionar o radiobutton de duplo hashing
        private void duplHash_CheckedChanged(object sender, EventArgs e)
        {
            hashEscolhido = duplHash.Text;
            FazerLeitura(arqPalavraDica);

            if (arqPalavraDica != null)
            {
                // Itera sobre a lista de dados lida do arquivo
                arqPalavraDica.PosicionaLista(0);
                var noAtual = arqPalavraDica.Atual;

                while (noAtual != null)
                {
                    // Insere cada item lido do arquivo na tabela de hash
                    bucketHash.Incluir(noAtual.Info);
                    noAtual = noAtual.Prox;
                }
            }

            btnListar_Click(sender, e);
        }

        //ler o arquivo de palavras e dicas qnd ele escolhe uma tecnica

        private void FazerLeitura(ListaSimples<Dicionario> qualLista)
        {
            lsbListagem.Items.Clear();

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
                    //lsbListagem.Items.Add(linha.ToString());
                }
                arquivo.Close();
            }

            arqPalavraDica = qualLista;
        }

        //se ele tiver escolhido outra tecnica, percorrer a tabela e gravar dados, para percorrer segundo a nova tecnica

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            Dicionario novoRegistro = new Dicionario(txtBPalavra.Text, txtBDica.Text);

            arqPalavraDica.InserirAntesDoInicio(novoRegistro);

            switch (hashEscolhido.Trim())
            {
                case "Bucket hashing":
                    bucketHash.Incluir(novoRegistro);
                    break;

                case "Sondagem linear":
                    sondLinear.Incluir(novoRegistro);
                    break;

                case "Sondagem quadrática":
                    sondQuadra.Incluir(novoRegistro);
                    break;

                case "Duplo hashing":
                    duplo.Incluir(novoRegistro);
                    break;

                default: break;
            }

            btnListar_Click(sender, e);
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            Dicionario novoRegistro = new Dicionario(txtBPalavra.Text, txtBDica.Text);

            arqPalavraDica.Remover(novoRegistro);

            switch (hashEscolhido.Trim())
            {
                case "Bucket hashing":
                    bucketHash.Excluir(novoRegistro);
                    break;

                case "Sondagem linear":
                    sondLinear.Excluir(novoRegistro);
                    break;

                case "Sondagem quadrática":
                    sondQuadra.Excluir(novoRegistro);
                    break;

                case "Duplo hashing":
                    duplo.Excluir(novoRegistro);
                    break;

                default: break;
            }

            btnListar_Click(sender, e);
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            Dicionario novoRegistro = new Dicionario(txtBPalavra.Text, txtBDica.Text);

            int indice = arqPalavraDica.RetornaIndiceValor(novoRegistro);
            arqPalavraDica.PosicionaLista(indice);
            arqPalavraDica.Atual.Info.Dica = novoRegistro.Dica;

            switch (hashEscolhido.Trim())
            {
                case "Bucket hashing":
                    bucketHash.Alterar(novoRegistro);
                    break;

                case "Sondagem linear":
                    sondLinear.Alterar(novoRegistro);
                    break;

                case "Sondagem quadrática":
                    sondQuadra.Alterar(novoRegistro);
                    break;

                case "Duplo hashing":
                    duplo.Alterar(novoRegistro);
                    break;

                default: break;
            }

            btnListar_Click(sender, e);
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            List<string> conteudoListagem;

            lsbListagem.Items.Clear();

            switch (hashEscolhido.Trim())
            {
                case "Bucket hashing":
                    conteudoListagem = bucketHash.Conteudo();
                    break;

                case "Sondagem linear":
                    conteudoListagem = sondLinear.Conteudo();
                    break;

                case "Sondagem quadrática":
                    conteudoListagem = sondQuadra.Conteudo();
                    break;

                case "Duplo hashing":
                    conteudoListagem = duplo.Conteudo();
                    break;

                default:
                    return;
            }

            foreach (string linha in conteudoListagem)
            {
                lsbListagem.Items.Add(linha);
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
