using System;
using BaseDeDados;
using Entidades;

namespace Gerenciadores;

public class GerenciadorTransportadora
{
    public GerenciadorTransportadora(BaseDados BaseDeDados)
    {
        this.BaseDeDados = BaseDeDados;
    }
    public BaseDados BaseDeDados { get; set; }

    public void CadastraTransportadora(String Nome, Double ValorPorKM)
    {
        Transportadora Transportadora = new Transportadora(Nome, ValorPorKM);
        BaseDeDados.TodasTransportadoras = BaseDeDados.AdicionarItem(BaseDeDados.TodasTransportadoras, Transportadora);
    }
    public void AlteraTransportadora(int Indice, Transportadora Nova)
    {
        Transportadora temp = BaseDeDados.TodasTransportadoras[Indice];
        if (Nova.Nome != "" )
            if(!ProcuraTransportadora(Nova.Nome))
                temp.Nome = Nova.Nome;
            //else Exception ja existe
        if (Nova.ValorPorKM != -1) temp.ValorPorKM = Nova.ValorPorKM;
    }
    public bool ExcluiTransportadora(int Id)
    {
        int indice = BaseDeDados.ProcuraItemPorId(BaseDeDados.TodasTransportadoras, Id);
        if (indice != -1)
        {
            BaseDeDados.TodasTransportadoras = BaseDeDados.RemoverItem(BaseDeDados.TodasTransportadoras, BaseDeDados.TodasTransportadoras[indice]);
            return true;
        }
        return false;
    }

    public bool ExcluiTransportadora(String Nome)
    {
        int indice = BaseDeDados.ProcuraItemEspecificoPorNome(BaseDeDados.TodasTransportadoras, Nome);
        if (indice != -1)
        {
            BaseDeDados.TodasTransportadoras = BaseDeDados.RemoverItem(BaseDeDados.TodasTransportadoras, BaseDeDados.TodasTransportadoras[indice]);
            return true;
        }
        return false;
    }

    public bool ProcuraTransportadora(String Nome)
    {
        if (BaseDeDados.ProcuraItemEspecificoPorNome(BaseDeDados.TodasTransportadoras, Nome) == -1)
            return false;
        return true;
    }
    public bool ProcuraTransportadora(int Id)
    {
        if (BaseDeDados.ProcuraItemPorId(BaseDeDados.TodasTransportadoras, Id) == -1)
            return false;
        return true;
    }
}
