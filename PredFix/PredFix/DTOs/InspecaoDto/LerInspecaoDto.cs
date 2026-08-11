namespace PredFix.DTOs.InspecaoDto
{
    public class LerInspecaoDto
    {
        public int InspecaoID { get; set; }
        public string Equipamento { get; set; } = string.Empty;
        public string Localizacao { get; set; } = string.Empty;
        public string Cliente { get; set; } = string.Empty;
        public bool StatusInspecao { get; set; }

        public string StatusTexto => StatusInspecao ? "Pendente" : "Conforme";
        public DateTime DataCriacao { get; set; }
        public int UsuarioID { get; set; }
    }
}
