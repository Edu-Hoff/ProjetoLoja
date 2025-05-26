using System;

namespace Entidades;

public class Endereco 
{
    public Endereco(String Rua, String Numero, String Complemento, String Bairro, String Cep, String Cidade, String Estado)
    {
        this.Rua = Rua;
        this.Numero = Numero;
        this.Complemento = Complemento;
        this.Bairro = Bairro;
        this.Cep = Cep;
        this.Cidade = Cidade;
        this.Estado = Estado;
    }
    public String Rua { get; set; }
    public String Numero {get;set;}
    public String Complemento {get;set;}
    public String Bairro {get;set;}
    public String Cep {get;set;}
    public String Cidade {get;set;}
    public String Estado {get;set;}

    //Apenas para Admin ou do proprio cliente
    public String ObterEndereco()
    {
        return $"{Rua}, {Numero}{((Complemento=="")?"": ", ")}{Complemento} - CEP: {Cep}\n{Bairro}, {Cidade}, {Estado}";
    }
}
