using System;
using Entidades;
using InfoContato;
using Pedidos;

namespace BaseDeDados;

public class BaseDados
{
    public Fornecedor[] TodosFornecedores { get; set; }
    public Transportadora[] TodasTransportadoras { get; set; }
    public Cliente[] TodosClientes { get; set; }
    public Usuario[] TodosUsuarios { get; set; }
    public Produto[] TodosProdutos { get; set;}
    public int ContFor=100, ContTrans=100, ContCli=100, ContUsua=100, ContProd=100;

    public BaseDados()
    {
        TodosFornecedores = new Fornecedor[0];
        TodasTransportadoras = new Transportadora[0];
        TodosClientes = new Cliente[0];
        TodosUsuarios = new Usuario[0];
        TodosProdutos = new Produto[0];
    }
}
