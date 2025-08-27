using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ListaSimples<Dado> where Dado : IComparable<Dado>
{
    NoLista<Dado> primeiro,     // aponta o primeiro nó da lista ligada
                  ultimo,       // aponta o último nó da lista ligada
                  atual,        // aponta um nó que está sendo visitado no momento
                  anterior;     // aponta o nó que vem antes do nó apontado por atual
    int quantosNos;             // contagem de quantos nós há ligados na lista
    bool primeiroAcessoDoPercurso;

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

        if (EstaVazia)        // se a lista está vazia, estamos
            ultimo = novoNo;   // incluindo o 1o e o último nós!

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

}
