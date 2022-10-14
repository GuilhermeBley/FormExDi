namespace FormExDi.Application.Model
{
    public class InfracaoModel
    {
        public string Renavam { get; set; } = string.Empty;
        public string Ait { get; set; } = string.Empty;
        public DateTime DtInfracao { get; set; } = DateTime.MinValue;
        public string Local { get; set; } = string.Empty;
        public DateTime? DtValidity { get; set; }
    }
}
