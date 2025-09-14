// 24140 Mariana Marietti da Costa
// 24153 Rafaelly Maria Nascimento da Silva


using apHashSimples;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace apListaLigada
{
    public class Dicionario : IComparable<Dicionario>, ICriterioDeSeparacao<Dicionario>, IRegistro<Dicionario>
    {
        // atributos da antiga classe PalavraDica, agora Dicionario:
        string palavra, dica;
        private const int tamanhoMaximo = 30;

        // propriedades e metodos projeto II:
        // propriedade de acesso
        public List<bool> acertou;   // vetor de valores lógicos que sempre será iniciado com 15 posições valendo falso

        public bool ExisteLetra(string letra)
        {
            // retornar false caso a letra sorteada não exista na palavra
            bool encontrou = false;

            // Retornar true se a letra sorteada está na palavra(pode haver mais de uma posição)

            for (int i = 0; i < Palavra.Trim().Length; i++)
            {
                if (Palavra[i].ToString().ToUpper() == letra.ToString().ToUpper())
                {
                    // atualizando o vetor acertou com true nas posições onde a encontrou;
                    acertou.Insert(i, true);

                    encontrou = true;
                }
            }

            return encontrou;
        }

        /*
        public List<bool> Acertou
        {
            get => acertou;
            set
            {
                // sempre será iniciado com 15 posições valendo falso.
                for (int i = 0; i < 15; i++)
                {
                    acertou.Insert(i, false);
                }

                //Retornar o vetor acertou, contendo true nas posições em que letras indicadas pelo jogador
                //foram encontradas na palavra e false nas posições em que as letras correspondentes
                //ainda não foram indicadas.
            }
        }
        */

        // projeto I
        public string Palavra
        {
            get => palavra;
            set
            {
                // se houver palavra, atribui o valor
                if (value != "")
                    // se for menor, preenche com espaços, e se a palavra for maior que o tamanho máximo, corta
                    palavra = value.PadRight(tamanhoMaximo, ' ').Substring(0, tamanhoMaximo);
                else
                    throw new Exception("Palavra vazia é inválido.");
            }
        }
        public string Dica
        {
            get => dica;
            set
            {
                if (value != null)
                    dica = value;
                else
                    throw new Exception("Dica vazia é inválido.");
            }
        }

        public string Chave => this.Palavra.Trim();


        // construtores da classe PalavraDica: 
        // se passar a palavra e a dica ja separadas
        public Dicionario(string palavra, string dica)
        {
            // se a palavra for maior que o tamanho máximo, lança uma exceção
            if (palavra.Length > tamanhoMaximo)
            {
                throw new Exception("30 caracteres atingidos.");
            }

            //Acertou = acertou;

            Palavra = palavra;
            Dica = dica;
        }

        // se passar a palavra e a dica juntas
        public Dicionario(string linhaDeDados)
        {
            // separa a palavra, que é do 0 ate 30
            Palavra = linhaDeDados.PadRight(tamanhoMaximo, ' ').Substring(0, tamanhoMaximo);

            // se houver dica, ou seja, houver mais que 30 caracteres
            if (linhaDeDados.Length > tamanhoMaximo)
            {
                // separa a dica, que é do 30 até o final
                Dica = linhaDeDados.Substring(tamanhoMaximo).Trim();
            }
            // se não houver dica, atribui uma string vazia
            else
            {
                Dica = "";
            }
        }

        public Dicionario()
        {
            palavra = "";
            dica = "";
            acertou = new List<bool>();
        }


        public int CompareTo(Dicionario other)
        {
            return this.palavra.CompareTo(other.palavra);
        }

        public bool DeveSeparar()
        {
            throw new NotImplementedException();
        }

        public string FormatoDeArquivo()
        {
            return $"{palavra}{dica}";
        }

        public override string ToString()
        {
            return palavra + " " + dica;
        }

        public void LerRegistro(StreamReader arquivo)
        {
            throw new NotImplementedException();
        }

        public void EscreverRegistro(StreamWriter arquivo)
        {
            throw new NotImplementedException();
        }

        public bool Equals(Dicionario outroRegistro)
        {
            // Se o outro registro for nulo, eles não podem ser iguais
            if (outroRegistro == null)
                    return false;

            return this.Palavra.Equals(outroRegistro.Palavra);
        }


        public static bool operator <(Dicionario left, Dicionario right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator <=(Dicionario left, Dicionario right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator >(Dicionario left, Dicionario right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator >=(Dicionario left, Dicionario right)
        {
            return left.CompareTo(right) >= 0;
        }
    }
}
