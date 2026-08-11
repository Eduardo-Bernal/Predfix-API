using System;
using System.Collections.Generic;

namespace PredFix.Domains;

public partial class Inspecao
{
    public int InspecaoID { get; set; }

    public string Equipamento { get; set; } = null!;

    public string Localizacao { get; set; } = null!;

    public string Cliente { get; set; } = null!;

    public byte[] Observacao { get; set; } = null!;

    public bool StatusInspecao { get; set; }

    public DateTime DataCriacao { get; set; }

    public int UsuarioID { get; set; }

    public virtual Usuario Usuario { get; set; } = null!;
}
