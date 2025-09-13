using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using apListaLigada;

namespace apHashing
{
    public partial class Form1 : Form
    {
        string hashEscolhido;

        BucketHash<Dicionario> bucketHash = new BucketHash<Dicionario>();
        SondLinear<Dicionario> sondLinear = new SondLinear<Dicionario>();
        SondQuad<Dicionario> sondQuadra = new SondQuad<Dicionario>();
        DuploHash<Dicionario> duplo = new DuploHash<Dicionario>();
        
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
        }

        //qnd o user selecionar o radiobutton de sondagem linear
        private void sondLin_CheckedChanged(object sender, EventArgs e)
        {
            hashEscolhido = sondLin.Text;
        }

        //qnd o user selecionar o radiobutton de sondagem quadrática
        private void sondQua_CheckedChanged(object sender, EventArgs e)
        {
            hashEscolhido = sondQua.Text;
        }

        //qnd o user selecionar o radiobutton de duplo hashing
        private void duplHash_CheckedChanged(object sender, EventArgs e)
        {
            hashEscolhido = duplHash.Text;
        }

        //ler o arquivo de palavras e dicas qnd ele escolhe uma tecnica
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
    }
}
