using System;
using System.ComponentModel.DataAnnotations;
using BaseDeDados;
using Entidades;

namespace Gerenciadores;

public class GerenciadorProduto
{
    public GerenciadorProduto(BaseDados BaseDeDados)
    {
        this.BaseDeDados = BaseDeDados;
    }
    private BaseDados BaseDeDados { get; set; }
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
