using apListaLigada;
using System.Collections;
using System.Collections.Generic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

public class BucketHash<T> where T : IRegistro<T>, new()
{
    //Cada compartimento pode guardar mais de uma coisa.
    //Se duas coisas caírem no mesmo compartimento, você coloca na mesma lista dentro dele.

    private const int SIZE = 37;    // para gerar mais colisões; o ideal é primo > 100
    ListaSimples<T> dados;          // tabela de hash expansível

    public BucketHash()
    {
        dados = new ListaSimples<T>();
        dados.QuantosNos = SIZE;

        for (int i = 0; i < SIZE; i++)
            dados[i] = new ArrayList(4);
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
        int valorDeHash = Hash(novoDado.Chave);
        if (!dados[valorDeHash].Contains(novoDado))
        {
            dados[valorDeHash].Add(novoDado);
            return true;
        }
        return false;
    }

    public bool Excluir(T dado)
    {
        int onde = 0;
        if (!Existe(dado, out onde))
            return false;
        dados[onde].Remove(dado);
        return true;
    }

    public bool Existe(T dado, out int onde)
    {
        onde = Hash(dado.Chave);
        return dados[onde].Contains(dado);
    }

    public List<string> Conteudo()
    {
        List<string> saida = new List<string>();
        for (int i = 0; i < dados.QuantosNos; i++)
            if (dados[i].Count > 0)
            {
                string linha = $"{i,5} : ";
                foreach (T dado in dados[i])
                    linha += " | " + dado;
                saida.Add(linha);
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
