using FormExDi.Core.Results;
using Smartec.Validations;

namespace FormExDi.Core.Model;

public class Infracao
{
    public string Renavam { get; private set; } = string.Empty;
    public string Ait { get; private set; } = string.Empty;
    public DateTime DtInfracao { get; private set; } = DateTime.MinValue;
    public string Local { get; private set; } = string.Empty;
    public DateTime? DtValidity { get; private set; }

    private Infracao(string renavam, string ait, DateTime dtInfracao, string local, DateTime? dtValidity)
    {
        Renavam = renavam;
        Ait = ait;
        DtInfracao = dtInfracao;
        Local = local;
        DtValidity = dtValidity;
    }

    public IResultGeneric<Infracao> Create(string renavam, string ait, DateTime dtInfracao, string local, DateTime? dtValidity)
    {
        if (Valid.IsRenavamBrl(renavam, out string? renavamOut))
            return ResultGeneric.Bad<Infracao>("Invalid Renavam.");
        if (dtInfracao.Equals(DateTime.MinValue) || dtValidity == DateTime.MinValue)
            return ResultGeneric.Bad<Infracao>("Invalid Date or dates.");
        if (string.IsNullOrWhiteSpace(local))
            return ResultGeneric.Bad<Infracao>("Invalid Local");
        ait = ait.Trim();
        if (string.IsNullOrWhiteSpace(ait) || ait.Length <= 3)
            return ResultGeneric.Bad<Infracao>("Invalid Ait, he should be greater than 3 characters.");
        return ResultGeneric.Ok(new Infracao(renavamOut!, ait, dtInfracao, local, dtValidity));
    }
}

