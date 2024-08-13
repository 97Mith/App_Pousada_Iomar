namespace PousadaIomar.Entities.ValueObjects;

public class Cpf
{
    public readonly string Value;

    public Cpf(string value)
    {
        ExceptionValidation.When
            (
                !CpfValidation.IsCPFValid(value),
                "CPF is invalid."
            );

        Value = value;
    }
}
