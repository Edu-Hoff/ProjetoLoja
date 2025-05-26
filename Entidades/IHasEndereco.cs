using System;

namespace Entidades;

/// Define uma entidade que possui um endereço.
public interface IHasEndereco
{
    public Endereco Endereco { get; set; }
}
