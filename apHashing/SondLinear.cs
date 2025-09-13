using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using apListaLigada;

namespace apHashing
{
    internal class SondLinear<T> where T : IRegistro<T>, new()
    {
        //Cada compartimento só guarda uma coisa.
        //Se bater colisão(já tem alguém lá), você vai para o próximo compartimento vazio.

        private const int SIZE = 37;    // para gerar mais colisões; o ideal é primo > 100
        T[] dados;                      // tabela de hash expansível

        public SondLinear()
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
            int tentativas = 0;     //só para caso o dados esteja cheio
            while (!vazio && tentativas < SIZE)
            {
                if (dados[valorHash] == null)
                {
                    dados[valorHash] = novoDado;
                    vazio = true;
                }
                else
                {
                    valorHash = (valorHash + 1) % SIZE;
                    tentativas++;
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
            else {
                dados[onde] = default;
                excluiu = true; 
            }
            return excluiu;
        }

        public bool Existe(T dado, out int onde)
        {
            int hash = Hash(dado.Chave);
            int i = 0;
            onde = hash;
            while (i < SIZE)
            {
                if (dados[onde].Equals(dado))
                    return true;

                onde = (onde + 1) % SIZE;       //pega o hash e soma +1, e o %dados.Length serve p voltar ao início
                i++;
            }
            onde = -1;      //-1 sendo como um null
            return false;
        }

        public List<string> Conteudo()
        {
            List<string> saida = new List<string>();
            for(int i = 0; i < SIZE; i++)
            {
                if (dados[i] != null)
                {
                    string linha = $"{i,5} : {dados[i]}";
                    saida.Add(linha);
                }
            }
            return saida;
        }

        public bool Alterar(T palavra, T dica)      //o usuário só altera a dica.
        {
            //Dicionario dicionario = new Dicionario();
            return false;
        }

    }
}
