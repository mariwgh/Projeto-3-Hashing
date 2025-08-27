using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class NoLista<Dado> where Dado : IComparable<Dado>
{
    Dado info;
    NoLista<Dado> prox;

    public NoLista(Dado informacao)
    {
        Info = informacao;
        prox = null;
    }

    // propriedades para os atributos desta classe

    public Dado Info
    {
        get => info;
        set
        {
            if (value == null)
                throw new Exception("Informação não pode ser nula!");

            info = value;
        }
    }

    public NoLista<Dado> Prox
    {
        get => prox;
        set => prox = value;
    }
}
