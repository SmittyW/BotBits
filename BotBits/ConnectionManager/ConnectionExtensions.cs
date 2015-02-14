﻿using System;
using System.Threading.Tasks;
using PlayerIOClient;

namespace BotBits
{
    public static class ConnectionExtensions
    {
        public static Task JoinRoomAsync(this Task<ConnectionManager.LoginClient> client, string roomId)
        {
            return client.ContinueWith(c =>
            {
                try
                {
                    return c.Result.JoinRoomAsync(roomId);
                }
                catch (Exception ex)
                {
                    throw ex.InnerException;
                }
            }).Unwrap();
        }

        public static Task CreateJoinRoomAsync(this Task<ConnectionManager.LoginClient> client, string roomId)
        {
            return client.ContinueWith(c =>
            {
                try
                {
                    return c.Result.CreateJoinRoomAsync(roomId);
                }
                catch (AggregateException ex)
                {
                    throw ex.InnerException;
                }
            }).Unwrap();
        }

        /// <summary>
        /// Send a message to the connected client without first having to construct a Message object.
        /// </summary>
        /// <param name="connection">The connection.</param>
        /// <param name="type">The type of message to send</param>
        /// <param name="parameters">The data to put in the message to send</param>
        public static void Send(this IConnection connection, string type, params object[] parameters)
        {
            connection.Send(Message.Create(type, parameters));
        }

        /// <summary>
        /// Add a message handler to the OnMessage event
        /// </summary>
        public static void AddOnMessage(this IConnection connection, MessageReceivedEventHandler handler)
        {
            connection.OnMessage += handler;
        }


        /// <summary>
        /// Add a disconnect handler to the OnDisconnect event
        /// </summary>
        public static void AddOnDisconnect(this IConnection connection, DisconnectEventHandler handler)
        {
            connection.OnDisconnect += handler;
        }
    }
}