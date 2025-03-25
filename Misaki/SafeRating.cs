namespace Misaki;

/// <remarks>
/// <seealso href="https://danbooru.donmai.us/wiki_pages/howto:rate"/>
/// </remarks>
public readonly record struct SafeRating(sbyte SafeRatingValue)
{
    private const sbyte NotSpecifiedValue = -1; 

    private const sbyte GeneralValue = 10; 

    private const sbyte SensitiveValue = 20; 

    private const sbyte QuestionableValue = 30; 

    private const sbyte ExplicitValue = 40; 

    private const sbyte GuroValue = 50; 

    public static SafeRating NotSpecified { get; } = new(NotSpecifiedValue);

    public static SafeRating General { get; } = new(GeneralValue);

    public static SafeRating Sensitive { get; } = new(SensitiveValue);

    public static SafeRating Questionable { get; } = new(QuestionableValue);

    /// <summary>
    /// Can be guro in booru
    /// </summary>
    public static SafeRating Explicit { get; } = new(ExplicitValue);

    public static SafeRating Guro { get; } = new(GuroValue);

    public bool IsNotSpecified => SafeRatingValue is NotSpecifiedValue;

    public bool IsGeneral => SafeRatingValue is > NotSpecifiedValue and <= GeneralValue;

    public bool IsSensitive => SafeRatingValue is > GeneralValue and <= SensitiveValue;

    public bool IsQuestionable => SafeRatingValue is > SensitiveValue and <= QuestionableValue;

    public bool IsExplicit => SafeRatingValue is > QuestionableValue and <= ExplicitValue;

    public bool IsGuro => SafeRatingValue > ExplicitValue;

    public bool IsSafe => IsGeneral || IsSensitive;

    public bool IsR17 => IsQuestionable;

    public bool IsR18 => IsExplicit;

    public bool IsR18G => IsGuro;
}