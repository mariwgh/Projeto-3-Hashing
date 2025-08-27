using System;
using System.Collections.Generic;

public class HashSimples<T> where T : IRegistro<T>, new()
{
    const int tamanhoPadrao = 10007;
    T[] tabelaDeHash;
    public HashSimples() : this(tamanhoPadrao) { }
    public HashSimples(int tamanhoDesejado)
    {
        tabelaDeHash = new T[tamanhoDesejado];
    }

    private int Hash(string chave)
    {
        int tot = 0;
        for (int i = 0; i < chave.Trim().Length; i++)
            tot += (int)chave[i];
        return tot % tabelaDeHash.Length;
    }

    public string Incluir(T novoDado)
    {
        string saida = "";
        int valorDeHash = Hash(novoDado.Chave);   // posicao calculada para um registro
        if (tabelaDeHash[valorDeHash] != null)  // já há dado armazenado nessa posição
            saida = $"colisao na posicao {valorDeHash} entre " +
                    $"{tabelaDeHash[valorDeHash]} e {novoDado.Chave}";
        tabelaDeHash[valorDeHash] = novoDado;
        return saida;
    }

    public bool Existe(T dado, out int posicao)
    {
        posicao = Hash(dado.Chave);
        return tabelaDeHash[posicao].Equals(dado);
    }

    public bool Excluir(T dado)
    {
        int ondeAchou;
        if (Existe(dado, out ondeAchou))
        {
            tabelaDeHash[ondeAchou] = default(T);
            return true;
        }
        return false;
    }

    public List<string> Conteudo()
    {
        var saida = new List<string>();
        for (int i = 0; i < tabelaDeHash.Length; i++)
            if (tabelaDeHash[i] != null)
                saida.Add($"{i,5} : {tabelaDeHash[i].ToString()}");
        //else
        //  saida.Add($"{i} ");
        return saida;
    }

    public void Limpar()
    {
        for (int i = 0; i < tabelaDeHash.Length; i++)
            tabelaDeHash[i] = default(T);
    }


}

