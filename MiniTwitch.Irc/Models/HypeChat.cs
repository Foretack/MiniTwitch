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
    /// <returns></returns>
    public double GetActualAmount() => this.PaidAmount * Math.Pow(10, -this.Exponent);
}
