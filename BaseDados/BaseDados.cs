using System;
using Entidades;


namespace BaseDeDados;

public class BaseDados
{
    public Fornecedor[] TodosFornecedores { get; set; }
    public Transportadora[] TodasTransportadoras { get; set; }
    public Cliente[] TodosClientes { get; set; }
    public Usuario[] TodosUsuarios { get; set; }
    public Produto[] TodosProdutos { get; set;}

    // um cont - DefineId : incrementa_cont
    // add ou remove : vem do gerenciador(verifica se pode ser add aqui e altera prod) que vem da interface (parte escrita)
    public BaseDados()
    {
        TodosFornecedores = new Fornecedor[0];
        TodasTransportadoras = new Transportadora[0];
        TodosClientes = new Cliente[0];
        TodosUsuarios = new Usuario[0];
        TodosProdutos = new Produto[0];
    }
}
