using System.Collections;
using System.Collections.Generic;

public class SondLinear<T> where T : IRegistro<T>, new()
{
    private const int SIZE = 37;  // para gerar mais colisões; o ideal é primo > 100
    ArrayList[] dados;            // tabela de hash expansível

    public SondLinear()
    {
        dados = new ArrayList[SIZE];
        for (int i = 0; i < SIZE; i++)
            dados[i] = new ArrayList(4);
    }

    private int Hash(T chave)
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
        int valorHash = Hash(novoDado);
        bool vazio = false;
        while (!vazio && valorHash){
            if (dados[valorHash] == null)
            {
                dados[valorHash] = novoDado;
                vazio = true; 
            }
            else
            {
                valorHash++;
            }
            if (valorHash <= dados.Length)
            {
                valorHash = 0;
            }
        }
        return vazio;
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

