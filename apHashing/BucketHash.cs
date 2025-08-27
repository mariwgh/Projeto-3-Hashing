using System.Collections;
using System.Collections.Generic;

public class BucketHash<T> where T : IRegistro<T>, new()
{
    private const int SIZE = 37;  // para gerar mais colisões; o ideal é primo > 100
    ArrayList[] dados;            // tabela de hash expansível

    public BucketHash()
    {
        dados = new ArrayList[SIZE];
        for (int i = 0; i < SIZE; i++)
            dados[i] = new ArrayList(4);
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
        for (int i = 0; i < dados.Length; i++)
            if (dados[i].Count > 0)
            {
                string linha = $"{i,5} : ";
                foreach (T dado in dados[i])
                    linha += " | " + dado;
                saida.Add(linha);
            }
        return saida;
    }

}

