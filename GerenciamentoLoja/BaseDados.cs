using System;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using Entidades;
using InfoContato;
using Pedidos;

namespace ProjetoLoja;

public class BaseDados
{
    public Fornecedor[] TodosFornecedores { get; set; }
    public Transportadora[] TodasTransportaras { get; set; }
    public Cliente[] TodosClientes { get; set; }
    public Usuario[] TodosUsuarios { get; set; }
    public Produto[] TodosProdutos { get; set;}

    public BaseDados()
    {
        TodosFornecedores = new Fornecedor[0];
        TodasTransportaras = new Transportadora[0];
        TodosClientes = new Cliente[0];
        TodosUsuarios = new Usuario[0];
    }
}
