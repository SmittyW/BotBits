using PlayerIOClient;

namespace BotBits.SendMessages
{
    public sealed class UnlikeSendMessage : SendMessage<UnlikeSendMessage>
    {
        //No arguments

        /// <summary>
        ///     Gets the PlayerIO message representing the data in this <see cref="SendMessage{T}" />.
        /// </summary>
        /// <returns></returns>
        protected override Message GetMessage()
        {
            return Message.Create("unlike");
        }
    }
}