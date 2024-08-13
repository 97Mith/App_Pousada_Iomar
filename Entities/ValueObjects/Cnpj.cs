namespace PousadaIomar.Entities.ValueObjects;

public class Cnpj
{
    public readonly string Value;

    public Cnpj(String value)
    {
        ExceptionValidation.When
            (
                !CnpjValidation.IsCNPJValid(value),
                "CNPJ is invalid."
            );

        Value = value;
    }
}
