using System;
using System.Collections.Generic;

public class HashAprimorado<T> where T : IRegistro<T>, new()
{
    const int tamanhoPadrao = 10007;
    T[] tabelaDeHash;
    public HashAprimorado() : this(tamanhoPadrao) { }
    public HashAprimorado(int tamanhoDesejado)
    {
        tabelaDeHash = new T[tamanhoDesejado];
    }

    private int Hash(string chave)
    {
        long tot = 0;
        for (int i = 0; i < chave.Length; i++)
            tot += 37 * tot + (int)chave[i];
        tot = tot % tabelaDeHash.Length;
        if (tot < 0)
            tot += tabelaDeHash.Length;
        return (int)tot;
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

    public List<string> Conteudo()
    {
        var saida = new List<string>();
        for (int i = 0; i < tabelaDeHash.Length; i++)
            if (tabelaDeHash[i] != null)
                saida.Add($"{i,5} : {tabelaDeHash[i]}");
        //else
        //  saida.Add($"{i} ");
        return saida;
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

    public void Limpar()
    {
        for (int i = 0; i < tabelaDeHash.Length; i++)
            tabelaDeHash[i] = default(T);
    }

}
