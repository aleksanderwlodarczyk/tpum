using System;
using System.Globalization;
using System.Threading.Tasks;

namespace ShopServerPresentation
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Server started");
            await WebSocketServer.Server(8081, ConnectionHandler);
        }

        static void ConnectionHandler(WebSocketConnection webSocketConnection)
        {
            
            webSocketConnection.onMessage = ParseMessage;
            webSocketConnection.onClose = () => { Console.WriteLine("[Server]: Connection closed"); };
            webSocketConnection.onError = () => { Console.WriteLine("[Server]: Connection error encountered"); };
        }

        static async void ParseMessage(string message)
        {
            Console.WriteLine($"[Client]: {message}");
        }
    }
}
