using System;

namespace Entidades;

public abstract class Endereco : Contato
{
    public String? Rua {get;set;}
    public String? Numero {get;set;}
    public String? Complemento {get;set;}
    public String? Bairro {get;set;}
    public String? Cep {get;set;}
    public String? Cidade {get;set;}
    public String? Estado {get;set;}

    //Apenas para Adim ou do proprio cliente
    public String ObterEndereco()
    {
        return $"{Rua}, {Numero}, {Complemento} - {Cep}\n{Bairro}, {Cidade}, {Estado}";
    }
}
