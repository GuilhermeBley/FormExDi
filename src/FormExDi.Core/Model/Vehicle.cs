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
            return ResultGeneric<Vehicle>.Bad("Invalid Renavam.");

        if (Valid.IsPlateBrl(plate, out string? plateOut))
            return ResultGeneric<Vehicle>.Bad("Invalid Plate.");

        if (Valid.IsPlateBrl(uf, out string? ufOut))
            return ResultGeneric<Vehicle>.Bad("Invalid Uf.");

        return ResultGeneric<Vehicle>.Ok(new Vehicle(renavamOut!, plateOut!, ufOut!));
    }
}

