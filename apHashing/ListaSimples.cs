using apListaLigada;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ListaSimples<Dado> : IComparable<ListaSimples<Dado>> where Dado : IComparable<Dado>
{
    NoLista<Dado> primeiro,     // aponta o primeiro nó da lista ligada
                  ultimo,       // aponta o último nó da lista ligada
                  atual,        // aponta um nó que está sendo visitado no momento
                  anterior;     // aponta o nó que vem antes do nó apontado por atual
    int quantosNos;             // contagem de quantos nós há ligados na lista
    bool primeiroAcessoDoPercurso;

    public NoLista<Dado> Atual => atual;

    public ListaSimples()
    {
        primeiro = ultimo = atual = anterior = null;
        quantosNos = 0;
        primeiroAcessoDoPercurso = true;
    }

    public bool EstaVazia
    {
        get => primeiro == null;
    }

    public int QuantosNos
    {
        get => quantosNos;    // retorna o valor do atributo quantosNos
    }

    public void InserirAntesDoInicio(Dado novoDado)
    {
        NoLista<Dado> novoNo = new NoLista<Dado>(novoDado);
        // var novoNo = new NoLista<Dado>(novoDado);

        if (EstaVazia)              // se a lista está vazia, estamos
            ultimo = novoNo;        // incluindo o 1o e o último no

        novoNo.Prox = primeiro;

        primeiro = novoNo;  // o novo nó recém incluído passa a ser o primeiro da lista
        quantosNos++;
    }

    public void InserirAposOFim(Dado novoDado)
    {
        var novoNo = new NoLista<Dado>(novoDado);
        if (EstaVazia)
            primeiro = novoNo;
        else
            ultimo.Prox = novoNo;

        ultimo = novoNo;  // o novo nó recém incluído passa a ser o último da lista
        quantosNos++;
    }

    public bool Remover(Dado dadoARemover)
    {
        if (EstaVazia)
            return false;

        if (!Existe(dadoARemover))
            return false;

        // aqui sabemos que o nó foi encontrado e o método
        // Existe() configurou os ponteiros atual e anterior
        // para delimitar onde está o nó a ser removido

        if (atual == primeiro)
        {
            primeiro = primeiro.Prox;
            if (primeiro == null)  // removemos o único nó da lista
                ultimo = null;
        }
        else
          if (atual == ultimo)
        {
            anterior.Prox = null;   // desliga o último nó
            ultimo = anterior;
        }
        else     // nó interno a ser excluido
        {
            anterior.Prox = atual.Prox;
        }

        quantosNos--;
        return true;
    }

    public void ExibirLista()
    {
        Console.Clear();  // limpa a tela em modo console
        atual = primeiro;
        while (atual != null)
        {
            Console.WriteLine(atual.Info);
            atual = atual.Prox;
        }
    }

    public List<Dado> ListarDados()
    {
        var listaDeDados = new List<Dado>();
        atual = primeiro;
        while (atual != null)
        {
            listaDeDados.Add(atual.Info);
            atual = atual.Prox;
        }
        return listaDeDados;
    }

    public int CompareTo(ListaSimples<Dado> other)
    {
        throw new NotImplementedException();
    }

    public bool Existe(Dado outroProcurado)
    {
        anterior = null;
        atual = primeiro;

        if (EstaVazia)
        {
            return false;
        }

        bool achou = false;

        while (atual != null && !achou)
        {
            if (atual.Info.Equals(outroProcurado)) 
            {
                achou = true;
            }
            else
            {
                anterior = atual;
                atual = atual.Prox;
            }
        }

        if (!achou)
        {
            anterior = ultimo; 
            atual = null;      
        }

        return achou;
    }


    //metodo que retorna o valor do indice desejado
    public NoLista<Dado> RetornaValorIndice(int indice)
    {
        atual = primeiro;

        if (indice < 0 || indice >= quantosNos)
        {
            // se o índice for inválido, o método retorna null
            return null;
        }

        for (int i = 0; i < indice; i++)
        {
            atual = atual.Prox;
        }

        return atual;
    }

    //metodo que retorna o indice do valor desejado
    public int RetornaIndiceValor(Dicionario valor)
    {
        int indice = 0;
        atual = primeiro;

        while (atual != null)
        {
            if (atual.Info != null)
            {
                if (atual.Info is Dicionario dicionario)
                {
                    if (dicionario.Palavra.Trim().Equals(valor.Palavra.Trim()))
                    {
                        return indice;
                    }
                }
            }
            atual = atual.Prox;
            indice++;
        }

        return -1; 
    }

    //metodo que posiciona o cursor no indice desejado
    public void PosicionaLista(int indice)
    {
        atual = primeiro;

        if (indice < 0 || indice >= quantosNos)
        {
            atual = null;
        }

        for (int i = 0; i < indice; i++)
        {
            atual = atual.Prox;
        }

    }


    public void LerRegistro(string arquivo, ref ListaSimples<Dicionario> qualLista)
    {
        qualLista = new ListaSimples<Dicionario>();                 // recria a lista a ser lida
        StreamReader leitor = new StreamReader(arquivo);
        string linha = "";
        while (!leitor.EndOfStream)                            // enquanto não acabou o arquivo
        {
            linha = leitor.ReadLine();
            qualLista.InserirAposOFim(new Dicionario(linha));
        }
        leitor.Close();
    }

    public void GravarDados(string nomeArq)
    {
        var arquivo = new StreamWriter(nomeArq);
        atual = primeiro;
        while (atual != null)
        {
            arquivo.WriteLine(atual.Info.ToString());
            atual = atual.Prox;
        }
        arquivo.Close();
    }
}
