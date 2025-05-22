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
    public void CadastraProduto(String Nome, double Valor, int Quantidade, String Fornecedor)
    {
        //verifica se fornecedor existe
        //funcao generica
    }
//inteface - aqui modifica direto
    public void AlteraProduto(String Nome) // revisar
    {
        
    }
    public void ExcluiProduto(int Id)
    {

    }
    public void ObterItemCodigo(int Id)
    {
        
    }
    public void ObterItemNome(String Nome)
    {

    }
}
