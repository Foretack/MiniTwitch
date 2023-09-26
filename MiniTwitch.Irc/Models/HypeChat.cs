using MiniTwitch.Irc.Enums;

namespace MiniTwitch.Irc.Models;

/// <summary>
/// Represents data about Hype Chat messages
/// </summary>
public readonly struct HypeChat
{
    /// <summary>
    /// The value of the Hype Chat sent by the user
    /// </summary>
    public int PaidAmount { get; init; }
    /// <summary>
    /// The <see href="https://en.wikipedia.org/wiki/ISO_4217#List_of_ISO_4217_currency_codes">ISO 4217</see> alphabetic currency code the user has sent the Hype Chat in
    /// </summary>
    public string PaymentCurrency { get; init; }
    /// <summary>
    /// Indicates how many decimal points this currency represents partial amounts in. Decimal points start from the right side of the value defined in <see cref="PaidAmount"/>.
    /// </summary>
    public int Exponent { get; init; }
    /// <summary>
    /// A Boolean value that determines if the message sent with the Hype Chat was filled in by the system
    /// </summary>
    public bool IsSystemMessage { get; init; }
    /// <summary>
    /// The level of the Hype Chat, in English. Possible values range from <see cref="HypeChatLevel.ONE"/> to <see cref="HypeChatLevel.TEN"/>
    /// </summary>
    public HypeChatLevel Level { get; init; }
    /// <summary>
    /// Whether the message is a Hype Chat message or not
    /// </summary>
    public bool HasContent => this.PaidAmount != 0;
    /// <summary>
    /// Gets the actual amount of money donated in the <see cref="PaymentCurrency"/> currency
    /// <para><c>ActualAmount = PaidAmount * 10^(-Exponent)</c></para>
    /// </summary>
    /// <returns>A <see langword="double"/> representing the actual paid amount</returns>
    public double GetActualAmount() => this.PaidAmount * Math.Pow(10, -this.Exponent);
    /// <summary>
    /// Gets how long the Hype Chat message will be pinned for
    /// </summary>
    /// <returns>A <see cref="TimeSpan"/> containing the duration of the pin</returns>
    public TimeSpan GetPinDuration() => this.Level switch
    {
        HypeChatLevel.ONE => TimeSpan.FromSeconds(30),
        HypeChatLevel.TWO => TimeSpan.FromMinutes(2.5),
        HypeChatLevel.THREE => TimeSpan.FromMinutes(5),
        HypeChatLevel.FOUR => TimeSpan.FromMinutes(10),
        HypeChatLevel.FIVE => TimeSpan.FromMinutes(30),
        HypeChatLevel.SIX => TimeSpan.FromMinutes(60),
        HypeChatLevel.SEVEN => TimeSpan.FromHours(2),
        HypeChatLevel.EIGHT => TimeSpan.FromHours(3),
        HypeChatLevel.NINE => TimeSpan.FromHours(4),
        HypeChatLevel.TEN => TimeSpan.FromHours(5),
        _ => TimeSpan.Zero
    };
}
