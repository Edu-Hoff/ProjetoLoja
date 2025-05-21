using System;
using System.ComponentModel.DataAnnotations;
using BaseDeDados;
using Entidades;

namespace Gerenciadores;

public class GerenciadorProduto
{
    Produto[] TodosProdutos = new Produto[5];
    public void CadastraProduto()
    {
        //funcao generica
    }
//inteface - aquic modifica direto
    public void AlteraProduto(String Nome) // revisar
    {
        
    }
    public void ExcluiProduto(String Nome)
    {

    }
    public void ObterItemCodigo(int Id)
    {
        
    }
    public void ObterItemNome(String Nome)
    {

    }
}
