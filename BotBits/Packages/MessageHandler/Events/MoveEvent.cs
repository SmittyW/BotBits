using PlayerIOClient;

namespace BotBits.Events
{
    /// <summary>
    ///     Occurs when someone moves.
    /// </summary>
    /// <seealso cref="PlayerEvent{T}" />
    [ReceiveEvent("m")]
    public sealed class MoveEvent : PlayerEvent<MoveEvent>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="MoveEvent" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="client"></param>
        internal MoveEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
            this.X = message.GetDouble(1);
            this.Y = message.GetDouble(2);
            this.SpeedX = message.GetDouble(3);
            this.SpeedY = message.GetDouble(4);
            this.ModifierX = message.GetDouble(5);
            this.ModifierY = message.GetDouble(6);
            this.Horizontal = message.GetDouble(7);
            this.Vertical = message.GetDouble(8);
            this.SpaceDown = message.GetBoolean(9);
            this.SpaceJustDown = message.GetBoolean(10);
        }

        /// <summary>
        ///     Gets or sets a value indicating whether space was just pressed.
        /// </summary>
        /// <value>
        ///     <c>true</c> if space was pressed; otherwise, <c>false</c>.
        /// </value>
        public bool SpaceJustDown { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether the player is holding down the space bar.
        /// </summary>
        /// <value><c>true</c> if the space bar is held down; otherwise, <c>false</c>.</value>
        public bool SpaceDown { get; set; }

        /// <summary>
        ///     Gets or sets the horizontal.
        /// </summary>
        /// <value>The horizontal.</value>
        public double Horizontal { get; set; }

        /// <summary>
        ///     Gets or sets the x modifier.
        /// </summary>
        /// <value>The modifier x.</value>
        public double ModifierX { get; set; }

        /// <summary>
        ///     Gets or sets the y modifier.
        /// </summary>
        /// <value>The modifier y.</value>
        public double ModifierY { get; set; }

        /// <summary>
        ///     Gets or sets the speed x.
        /// </summary>
        /// <value>The speed x.</value>
        public double SpeedX { get; set; }

        /// <summary>
        ///     Gets or sets the speed y.
        /// </summary>
        /// <value>The speed y.</value>
        public double SpeedY { get; set; }

        /// <summary>
        ///     Gets or sets the vertical.
        /// </summary>
        /// <value>The vertical.</value>
        public double Vertical { get; set; }

        /// <summary>
        ///     Gets the block x.
        /// </summary>
        /// <value>The block x.</value>
        public int BlockX
        {
            get { return WorldUtils.PosToBlock(this.X); }
        }

        /// <summary>
        ///     Gets the block y.
        /// </summary>
        /// <value>The block y.</value>
        public int BlockY
        {
            get { return WorldUtils.PosToBlock(this.Y); }
        }

        /// <summary>
        ///     Gets or sets the user coordinate x.
        /// </summary>
        /// <value>The user position x.</value>
        public double X { get; set; }

        /// <summary>
        ///     Gets or sets the user coordinate y.
        /// </summary>
        /// <value>The user position y.</value>
        public double Y { get; set; }
    }
}