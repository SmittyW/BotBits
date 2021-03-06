using PlayerIOClient;

namespace BotBits.Events
{
    /// <summary>
    ///     Occurs when a player's gold or blue coin count changes.
    /// </summary>
    /// <seealso cref="PlayerEvent{T}" />
    [ReceiveEvent("c")]
    public sealed class CoinEvent : PlayerEvent<CoinEvent>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CoinEvent" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="client"></param>
        internal CoinEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
            this.GoldCoins = message.GetInteger(1);
            this.BlueCoins = message.GetInteger(2);
            this.X = message.GetUInt(3);
            this.Y = message.GetUInt(4);
        }

        /// <summary>
        ///     Gets or sets the y coordinate of the collected coin.
        /// </summary>
        /// <value>The y coordinate.</value>
        public uint Y { get; set; }

        /// <summary>
        ///     Gets or sets the x coordinate of the collected coin.
        /// </summary>
        /// <value>The x coordinate.</value>
        public uint X { get; set; }

        /// <summary>
        ///     Gets or sets the coins of the player.
        /// </summary>
        /// <value>The coins.</value>
        public int GoldCoins { get; set; }

        /// <summary>
        ///     Gets or sets the blue coins of the player.
        /// </summary>
        /// <value>The blue coins.</value>
        public int BlueCoins { get; set; }
    }
}