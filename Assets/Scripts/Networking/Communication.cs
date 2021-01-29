using System;
using System.Diagnostics;

namespace Networking
{
    public static class Communication
    {
        private static TCP server;
        private static UDP game;

        private static string serverIP;

        public static Action<Message> Listeners;


        public static bool InitializeServer(string targetIP, int targetPort)
        {
            if (server != null)
                return true;
            serverIP = targetIP;
            server = new TCP(serverIP, targetPort);
            server.InterpreteData = Listeners;
            server.Initialize();
            if (!server.active)
            {
                server.Stop();
                server = null;
                return false;
            }

            return true;
        }

        public static void InitializeGame(string targetIP, int targetPort, int listeningPort = 11100)
        {
            game = new UDP(targetIP, targetPort, listeningPort);
            game.InterpreteData = Listeners;
            game.Initialize();
        }

        public static void CloseServer()
        {
            server.Stop();
            server = null;
        }
        
        public static void CloseGame()
        {
            if (!(game is null))
            {
                game.Stop();
            }
            game = null;
        }

        public static bool SendToServer(Message message)
        {
            return SendMessage(message, server);
        }
        
        public static bool SendToGame(Message message)
        {
            return SendMessage(message, game);
        }

        private static bool SendMessage(Message message, Connection connection)
        {
            if (connection == null)
                return false;
            
            connection.SendData(message.ToBytes());
            return true;
        }
    }
}
