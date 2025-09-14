using apListaLigada;
using System;
using System.Collections;
using System.Collections.Generic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

public class BucketHash<T> where T : IRegistro<T>, IComparable<T>, new()
{
    //Cada compartimento pode guardar mais de uma coisa.
    //Se duas coisas caírem no mesmo compartimento, você coloca na mesma lista dentro dele.

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

            if (dados.Atual.Info != null)
            {
                string linha = $"{i,5} : ";

                foreach (T dado in dados.Atual.Info.ListarDados())
                    linha += " | " + dado;

                saida.Add(linha);
            }
        }

        return saida;
    }

    public bool Alterar(T dadoAntigo, T dadoNovo)
    {
        //mas tipo, tem que verificar se existe e como eu vou saber se o usuário quer alterar a dica ou a palavra ou os dois?
        if (Excluir(dadoAntigo))
        {
            Incluir(dadoNovo);
            return true;
        }
        return false;
    }

}
