using System;

namespace Entidades;

public abstract class Contato : ObjetoComNome
{
    public String? Email { get; set; }
    public String? Telefone { get; set; }
}
