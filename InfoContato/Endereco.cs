using System;

namespace Entidades;

public abstract class Endereco : Contato
{
    public String Rua {get;set;}
    public String Numero {get;set;}
    public String Complemento {get;set;}
    public String Bairro {get;set;}
    public String Cep {get;set;}
    public String Cidade {get;set;}
    public String Estado {get;set;}

    public String ObterEndereco()
    {
        return $"Rua: {Rua}\nNumero: {Numero}\nComplemento: {Complemento}\nBairro: {Bairro}\nCep: {Cep}\nCidade: {Cidade}\nEstado: {Estado}";
    }
}
