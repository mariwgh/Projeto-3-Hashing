using apListaLigada;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apHashing
{
    internal class DuploHash<T> where T : IRegistro<T>, new()
    {
        // usa outro cálculo pra achar lugar

        private const int SIZE = 37;    // para gerar mais colisões; o ideal é primo > 100
        T[] dados;                      // tabela de hash expansível

        public DuploHash()
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

        public bool Incluir(T dado)
        {
            bool incluiu = false;
            int tentativas = 0;
            int chaveNumerica = dado.Chave.GetHashCode();       //transforma em ASCII

            if (chaveNumerica < 0)
                chaveNumerica = -chaveNumerica;

            int hash1 = Hash(dado.Chave);
            int hash2 = 1 + (chaveNumerica % (SIZE - 1));

            int where = hash1;

            while (!incluiu && tentativas < SIZE)
            {
                if (dados[where] == null)
                {
                    dados[where] = dado;
                    incluiu = true;
                }
                else
                {
                    tentativas++;
                    where = (hash1 + tentativas * hash2) % SIZE;
                }
            }
            return incluiu;
        }

        public bool Excluir(T dado)
        {
            bool excluiu = false;
            int onde = 0;
            if (!Existe(dado, out onde))
            {
                return excluiu;
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
            int chaveNumerica = dado.Chave.GetHashCode();       //transforma em ASCII
            bool achou = false;
            int tentativas = 0;
            if (chaveNumerica < 0)
                chaveNumerica = -chaveNumerica;
            int hash1 = Hash(dado.Chave);
            int hash2 = 1 + (chaveNumerica % (SIZE - 1));

            onde = hash1;

            while (!achou && tentativas < SIZE)     //se ja rodou tudo e nao achou, é pq não existe
            {
                if (dados[onde].Equals(dado))
                    achou = true;

                else
                {
                    tentativas++;
                    onde = (hash1 + tentativas * hash2) % SIZE;
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
