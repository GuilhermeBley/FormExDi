using FormExDi.Core.Results;
using Smartec.Validations;

namespace FormExDi.Core.Model;
public class Vehicle
{
    public string Renavam { get; }
    public string Plate { get; }
    public string Uf { get; }

    private Vehicle(string renavam, string placa, string uf)
    {
        Renavam = renavam;
        Plate = placa;
        Uf = uf;
    }

    public static IResultGeneric<Vehicle> Create(string renavam, string plate, string uf)
    {
        if (Valid.IsRenavamBrl(renavam, out string? renavamOut))
            return ResultGeneric.Bad<Vehicle>("Invalid Renavam.");

        if (Valid.IsPlateBrl(plate, out string? plateOut))
            return ResultGeneric.Bad<Vehicle>("Invalid Plate.");

        if (Valid.IsPlateBrl(uf, out string? ufOut))
            return ResultGeneric.Bad<Vehicle>("Invalid Uf.");

        return ResultGeneric.Ok(new Vehicle(renavamOut!, plateOut!, ufOut!));
    }
}

