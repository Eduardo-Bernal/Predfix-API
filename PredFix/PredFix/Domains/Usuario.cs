using System;
using System.Collections.Generic;

namespace PredFix.Domains;

public partial class Usuario
{
    public int UsuarioID { get; set; }

    public string Nome { get; set; } = null!;

    public string Email { get; set; } = null!;

    public byte[] Senha { get; set; } = null!;

    public bool IsAdmin { get; set; }

    public virtual ICollection<Inspecao> Inspecao { get; set; } = new List<Inspecao>();
}
