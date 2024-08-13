namespace PousadaIomar.Entities.ValueObjects.VOValidation;

public class Util
{
    public static void IsNullOrBlank(string value, string namesField)
    {
        ExceptionValidation.When
            (
                string.IsNullOrEmpty(value),
                $"{namesField} cannot be null or blank."
            );
    }

    public static void LengthSizeValidation(string value, int min, int max, string namesField)
    {
        ExceptionValidation.When
            (
                value.Length < min,
                $"{namesField} length must be between {min} and {max} characters."
            );
        ExceptionValidation.When
            (
                value.Length > max,
                $"{namesField} length must be between {min} and {max} characters."
            );
    }

    public static void ValidatePrice(decimal price, string namesField)
    {
        ExceptionValidation.When
            (
                price < 0,
                $"{namesField} cannot be negative."
            );
    }
}
