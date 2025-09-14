using apListaLigada;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apHashing
{
    internal class SondQuad<T> where T : IRegistro<T>, new()
    {
        //Igual a linear, mas em vez de ir um por um, você pula cada vez mais longe para achar espaço.
        
        private const int SIZE = 37;    // para gerar mais colisões; o ideal é primo > 100
        T[] dados;                      // tabela de hash expansível

        public SondQuad()
        {
            dados = new T[SIZE];
            
        }

        private int Hash(string chave)
        {
            long tot = 0;
            for (int i = 0; i < chave.Length; i++)
                tot += 37 * tot + (char)chave[i];
            tot = tot % dados.Length;
            if (tot < 0)
                tot += dados.Length;
            return (int)tot;
            //return HashSimples.Hash(chave);     //pega o hash que o chico já fez
        }

        public bool Incluir(T novoDado)
        {
            int valorHash = Hash(novoDado.Chave);
            bool vazio = false;
            int tentativas = 0;
            while (!vazio)
            {
                if (dados[valorHash] == null)
                {
                    dados[valorHash] = novoDado;
                    vazio = true;
                }
                else
                {
                    tentativas++;
                    valorHash = (valorHash + tentativas * tentativas) % SIZE;
                }
            }
            return vazio;
        }

        public bool Excluir(T dado)
        {
            int onde = 0;
            bool excluiu = false;
            if (!Existe(dado, out onde))
            {
                return false;
            }
            else
            {
                dados[onde] = default;
                excluiu = true;
            }
            return excluiu;
        }

        public bool Existe(T dado, out int onde)
        {
            onde = Hash(dado.Chave);
            bool achou = false;
            int tentativas = 0;
            while (!achou && tentativas < SIZE)         //se não achou E tentativas < SIZE
            {
                if (dados[onde].Equals(dado))
                    achou = true;
                else
                {
                    tentativas++;
                    onde = (onde + tentativas * tentativas) % SIZE;
                }
            }
            if (!achou)
                onde = -1;      //não achou
            return achou;
        }

        public List<string> Conteudo()
        {
            List<string> saida = new List<string>();

            for (int i = 0; i < SIZE; i++)
            {
                string linha = $"{i,5} : | ";

                if (dados[i] != null)
                {
                    Dicionario dadoNoDicionario = dados[i] as Dicionario;
                    linha += $"{dadoNoDicionario.Palavra.PadRight(30, ' ').Substring(0, 30)} - {dadoNoDicionario.Dica.PadRight(30, ' ').Substring(0, 30)} | ";
                }

                saida.Add(linha);
            }

            return saida;
        }

        public bool Alterar(T dadoNovo)
        {
            //usuario so altera dica

            int indice;
            if (Existe(dadoNovo, out indice))
            {
                T compPalavraDica = dados[indice];
                Dicionario dadoNoDicionario = compPalavraDica as Dicionario;
                dadoNoDicionario.Dica = (dadoNovo as Dicionario).Dica;
            }
            return false;
        }
    }
}
