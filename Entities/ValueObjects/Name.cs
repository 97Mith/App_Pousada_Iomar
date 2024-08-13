namespace PousadaIomar.Entities.ValueObjects;

public class Name
{
    public string Value;

    public Name(string value)
    {
        VOValidation.Util.IsNullOrBlank(value, "Name");
        VOValidation.Util.LengthSizeValidation(value, 3, 25, "Name");

        Value = value;
    }
}
