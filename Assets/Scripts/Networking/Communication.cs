using System;

namespace Networking
{
    public static class Communication
    {
        private static TCP server;
        private static UDP game;

        private static string serverIP;

        public static Action<Message> Listeners;


        public static void InitializeServer(string targetIP, int targetPort)
        {
            serverIP = targetIP;
            server = new TCP(serverIP, targetPort);
            server.InterpreteData = Listeners;
            server.Initialize();
        }

        public static void InitializeGame(int targetPort, int listeningPort = 11100)
        {
            game = new UDP("192.168.3.4", targetPort, listeningPort);
            game.InterpreteData = Listeners;
            game.Initialize();
        }

        public static void CloseGame()
        {
            game.Stop();
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
