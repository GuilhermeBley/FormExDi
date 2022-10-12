using FormExDi.Core.Results;

namespace FormExDi.Core.Model;
public class Vehicle
{
    public string Renavam { get; }
    public string Placa { get; }

    private Vehicle(string renavam, string placa)
    {
        Renavam = renavam;
        Placa = placa;
    }

    public IResult<Vehicle> Create(string renavam, string placa)
    {
        throw new NotImplementedException();
    }
}

