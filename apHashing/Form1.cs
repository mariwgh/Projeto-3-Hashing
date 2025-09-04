using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace apHashing
{
    public partial class Form1 : Form
    {
        string hashEscolhido;
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

        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {

        }

        private void btnListar_Click(object sender, EventArgs e)
        {

        }

        //EU DE VERDADE NÃO FAÇO A MENOR IDEIA DO QUE FAZER.
        private void btnIncluir_Click(object sender, EventArgs e)
        {
            switch (hashEscolhido)
            {
                case "Bucket hashing": break;       //fazer uma função para cada combinação? (bucket hashing p excluir, p incluir...???)
                case "Sondagem linear": break;
                case "Sondagem quadrática": break;
                case "Duplo hashing": break;
                default: break;
            }
        }
    }
}
