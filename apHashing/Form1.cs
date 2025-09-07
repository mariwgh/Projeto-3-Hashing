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
        BucketHash<string> bucketHash = new BucketHash<string>();
        SondLinear<String> sondLinear = new SondLinear<String>();
        SondQuad<String> sondQuadra = new SondQuad<String>();
        DuploHash<String> duplo = new DuploHash<String>();
        public Form1()
        {
            InitializeComponent();
            hashEscolhido = "";
        }

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
            hashEscolhido = sondLin.Text;
        }

        //qnd o user selecionar o radiobutton de duplo hashing
        private void duplHash_CheckedChanged(object sender, EventArgs e)
        {
            hashEscolhido = duplHash.Text;
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
                    sondQuadra.Incluir( txtBDica.Text);
                    break;

                case "Duplo hashing":
                    duplo.Incluir(txtBPalavra.Text);
                    duplo.Incluir(txtBDica.Text);
                    break;

                default: break;
            }
        }
    }
}
