using System;
using System.Security.Cryptography.X509Certificates;
using Entidades;
using InfoContato;

namespace ProjetoLoja;

public class BaseDados
{
    public Fornecedor[] TodosFonecedor { get; set; }
    public Transportadora[] TodasTransportaras { get; set; }
    public Cliente[] TodosClientes { get; set; }
    public Usuario[] TodosUsuarios { get; set; }

    public BaseDados()
    {
        TodosFonecedor = new Fornecedor[0];
        TodasTransportaras = new Transportadora[0];
        TodosClientes = new Cliente[0];
        TodosUsuarios = new Usuario[0];
    }
}
