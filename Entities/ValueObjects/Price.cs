namespace PousadaIomar.Entities.ValueObjects;

public class Price
{
    public readonly decimal Value;

    public Price(decimal price, string namesField)
    {
        VOValidation.Util.ValidatePrice(price, namesField);

        Value = price;
    }
}
