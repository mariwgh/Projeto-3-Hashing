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
        int valorHash = Hash(novoDado.Chave);
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
        bool encontrou = false;
        int onde = 0;
        if (!Existe(dado, out onde))        //se nao existir no dados
        {
            return encontrou;
        }
        else
        {
            int hash = Hash(dado.Chave);
            int i = 0;
            while (i < dados.Length)
            {
                if (dados[onde].Equals(dado))
                    return true;

                onde = (onde + 1) % dados.Length;       //pega o hash e soma +1, e o %dados.Length serve p voltar ao início
                i++;
            }
        }
    }

    public bool Existe(T dado, out int onde)
    {
        int hash = Hash(dado.Chave);
        int i = 0;
        onde = hash;
        while (i < dados.Length)
        {
            if (dados[onde].Equals(dado))
                return true;

            onde = (onde + 1) % dados.Length;       //pega o hash e soma +1, e o %dados.Length serve p voltar ao início
            i++;
        }
        onde = -1;      //-1 sendo como um null
        return false;
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

    public bool Alterar(T palavra, T dica)
    {
        //mas tipo, tem que verificar se existe e como eu vou saber se o usuário quer alterar a dica ou a palavra ou os dois?
        if (Existe(palavra, 0))        //se existe a palavra, ele quer alterar a dica
        {
            
        }
        else if (Existe(dica, 0)){      //se existe a dica, ele quer alterar a palavra

        }
    }

}

