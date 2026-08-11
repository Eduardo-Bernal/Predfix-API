namespace PredFix.DTOs.InspecaoDto
{
    public class CriarInspecaoDto
    {
        public string Equipamento { get; set; } = string.Empty;
        public string Localizacao { get; set; } = string.Empty;
        public string Cliente { get; set; } = string.Empty;
        public bool StatusInspecao { get; set; }
        public int UsuarioID { get; set; }
        public IFormFile Observacao { get; set; } = null!;
    }
}
