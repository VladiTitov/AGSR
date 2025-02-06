using MaternityHospital.Domain.Constants;

namespace MaternityHospital.Domain.Extensions;

public static class StringExtensions
{
    public static DateTime ToDateTime(this string value)
        => string.IsNullOrEmpty(value)
            ? throw new ArgumentNullException(
                string.Format(Messages.ArgumentNullExceptionMessage, "dateTimeValue", nameof(ToDateTime)))
            : DateTime.TryParse(value, out DateTime result)
                ? result
                : throw new InvalidCastException(
                    string.Format(Messages.InvalidCastExceptionMessage, value, nameof(DateTime)));

    public static TEnum ToEnum<TEnum>(this string value) where TEnum : struct
        => string.IsNullOrEmpty(value)
            ? throw new ArgumentNullException(
                string.Format(Messages.ArgumentNullExceptionMessage, "enumValue", nameof(ToEnum)))
            : Enum.TryParse(value, out TEnum result)
                ? result
                : throw new InvalidCastException(
                    string.Format(Messages.InvalidCastExceptionMessage, value, typeof(TEnum).Name));
}
