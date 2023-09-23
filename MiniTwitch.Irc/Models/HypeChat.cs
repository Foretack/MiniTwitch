using MiniTwitch.Irc.Enums;

namespace MiniTwitch.Irc.Models;

/// <summary>
/// Represents data about HypeChat messages
/// </summary>
public readonly struct HypeChat
{
    /// <summary>
    /// The <c>pinned-chat-paid-amount</c> tag
    /// <para>Example: <c>pinned-chat-paid-amount=100</c></para>
    /// <para>This tag is not officially documented</para>
    /// </summary>
    public int PaidAmount { get; init; }
    /// <summary>
    /// The <c>pinned-chat-paid-canonical-amount</c> tag
    /// <para>Example: <c>pinned-chat-paid-canonical-amount=100</c></para>
    /// <para>This tag is not officially documented</para>
    /// </summary>
    public int CanonicalPaidAmount { get; init; }
    /// <summary>
    /// The <c>pinned-chat-paid-currency</c> tag
    /// <para>Example: <c>pinned-chat-paid-currency=GBP</c></para>
    /// <para>This tag is not officially documented</para>
    /// </summary>
    public string PaymentCurrency { get; init; }
    /// <summary>
    /// The <c>pinned-chat-paid-exponent</c> tag
    /// <para>Example: <c>pinned-chat-paid-exponent=2</c></para>
    /// <para>This tag is not officially documented</para>
    /// </summary>
    public int Exponent { get; init; }
    /// <summary>
    /// The <c>pinned-chat-paid-is-system-message</c> tag
    /// <para>Example: <c>pinned-chat-paid-is-system-message=0</c></para>
    /// <para>This tag is not officially documented</para>
    /// </summary>
    public bool IsSystemMessage { get; init; }
    /// <summary>
    /// The <c>pinned-chat-paid-level</c> tag
    /// <para>Example: <c>pinned-chat-paid-level=ONE</c></para>
    /// <para>This tag is not officially documented</para>
    /// </summary>
    public HypeChatLevel Level { get; init; }
    /// <summary>
    /// Whether the message is a HypeChat message or not
    /// </summary>
    public bool HasContent => this.PaidAmount != 0;
    /// <summary>
    /// Gets the actual amount of money donated in the <see cref="PaymentCurrency"/> currency
    /// <para><c>ActualAmount = PaidAmount * 10^(-Exponent)</c></para>
    /// </summary>
    /// <returns>A <see langword="double"/> representing the actual paid amount</returns>
    public double GetActualAmount() => this.PaidAmount * Math.Pow(10, -this.Exponent);
    /// <summary>
    /// Gets how long the HypeChat message will be pinned for
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
