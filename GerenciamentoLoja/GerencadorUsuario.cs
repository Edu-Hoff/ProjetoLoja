using System;

namespace GerenciamentoLoja;

public class GerencadorUsuario
{

    
    public void AlterarSenha (String nome, String senha, String novaSenha)
    {
        senha=HashSenha(senha);
        //TodosUsuarios Vetor com todos usuario
        foreach (Usuario user in TodosUsuarios)  
        {
            if(user.UserName == nome && user.Senha == senha)
            {
                user.Senha = novaSenha;
                return;
            }
        }
        //Excecao
    }

    public void ExcluiUsuario (String nome, String senha)
    {
        senha=HashSenha(senha);
        //TodosUsuarios Vetor com todos usuario
        foreach (Usuario user in TodosUsuarios)  
        {
            if(user.UserName == nome && user.Senha == senha)
            {
                
                return;
            }
        }
        //Excecao
    }
}
