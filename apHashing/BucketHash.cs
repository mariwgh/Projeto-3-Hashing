using apListaLigada;
using System;
using System.Collections;
using System.Collections.Generic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

public class BucketHash<T> where T : IRegistro<T>, IComparable<T>, new()
{
    // cada compartimento pode guardar mais de uma coisa
    // se duas coisas cairem no mesmo compartimento, coloca na mesma lista dentro dele

    private const int SIZE = 37;            // para gerar mais colisões; o ideal é primo > 100
    ListaSimples<ListaSimples<T>> dados;    // tabela de hash expansível; é uma lista de listas

    public BucketHash()
    {
        dados = new ListaSimples<ListaSimples<T>>();

        for (int i = 0; i < SIZE; i++)
            dados.InserirAposOFim(new ListaSimples<T>());
    }

    private int Hash(string chave)
    {
        long tot = 0;

        for (int i = 0; i < chave.Length; i++)
            tot += 37 * tot + (char)chave[i];

        tot = tot % dados.QuantosNos;
        if (tot < 0)
            tot += dados.QuantosNos;

        return (int)tot;
    }

    public bool Incluir(T novoDado)
    {
        int valorDeHash = Hash(novoDado.Chave);     //compartimento q sera adicionado

        dados.PosicionaLista(valorDeHash);
        ListaSimples<T> compartimento = dados.Atual.Info;

        if (!compartimento.Existe(novoDado))
        {
            compartimento.InserirAposOFim(novoDado);
            return true;
        }
        return false;
    }

    public bool Excluir(T dado)
    {
        int onde = 0;
        if (!Existe(dado, out onde))
            return false;
        dados.PosicionaLista(onde);
        dados.Atual.Info.Remover(dado);
        return true;
    }

    public bool Existe(T dado, out int onde)
    {
        onde = Hash(dado.Chave);
        dados.PosicionaLista(onde);
        return dados.Atual.Info.Existe(dado);
    }

    public List<string> Conteudo()
    {
        List<string> saida = new List<string>();

        for (int i = 0; i < dados.QuantosNos; i++)
        {
            dados.PosicionaLista(i);
            ListaSimples<T> listaDoBucket = dados.Atual.Info;

            string linha = $"{i,5} : | ";

            if (listaDoBucket != null && !listaDoBucket.EstaVazia)
            {

                listaDoBucket.PosicionaLista(0);
                var noAtual = listaDoBucket.Atual;

                while (noAtual != null)
                {
                    Dicionario dadoNoDicionario = noAtual.Info as Dicionario;
                    linha += $"{dadoNoDicionario.Palavra.PadRight(30, ' ').Substring(0, 30)} - {dadoNoDicionario.Dica.PadRight(30, ' ').Substring(0, 30)} | ";
                    noAtual = noAtual.Prox;
                }
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
            // se dado novo existe, encontra ele na lista
            dados.PosicionaLista(indice);
            ListaSimples<T> compPalavraDica = dados.Atual.Info;

            // encontrar o item especifico dentro da lista do bucket
            var no = compPalavraDica.Atual;
            while (no != null)
            {
                if (no.Info.Equals(dadoNovo))
                {
                    Dicionario dadoNoDicionario = no.Info as Dicionario;

                    if (dadoNoDicionario != null)
                    {
                        dadoNoDicionario.Dica = (dadoNovo as Dicionario).Dica;
                        return true;
                    }
                }
                no = no.Prox;
            }
        }
        return false;
    }
}
