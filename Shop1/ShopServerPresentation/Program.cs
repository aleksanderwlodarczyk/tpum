using System;
using System.Globalization;
using System.Net;
using System.Threading.Tasks;
using ShopServerLogic;

namespace ShopServerPresentation
{
    internal class Program
    {
        static IShop shop;
        private static ILogicLayer logicLayer;

        static async Task Main(string[] args)
        {
            Console.WriteLine("Server started");
            logicLayer = ILogicLayer.Create();
            shop = logicLayer.Shop;
            await WebSocketServer.Server(8081, ConnectionHandler);
        }

        static void ConnectionHandler(WebSocketConnection webSocketConnection)
        {
            Console.WriteLine("[Server]: Client connected");
            WebSocketServer.CurrentConnection = webSocketConnection;
            webSocketConnection.onMessage = ParseMessage;
            webSocketConnection.onClose = () => { Console.WriteLine("[Server]: Connection closed"); };
            webSocketConnection.onError = () => { Console.WriteLine("[Server]: Connection error encountered"); };
        }

        static async void ParseMessage(string message)
        {
            Console.WriteLine($"[Client]: {message}");
            if (message == "echo")
            {
                await SendMessageAsync("echoResponse");
            }
            //test
            //else
            //{
            //    var fruits = Serializer.JsonToManyFruits(message);
            //    Console.WriteLine("fruits count" + fruits.Count);
            //    var fruit = fruits[0];
            //    Console.WriteLine($"ID: {fruit.ID}, price: {fruit.Price}, name: {fruit.Name}");
            //    Console.WriteLine($"fruits count: {fruits.Count}");
            //}

            if (message == "RequestAll")
            {
                await SendCurrentWarehouseState();
            }
        }

        static async Task SendCurrentWarehouseState()
        {
            var fruits = shop.GetAvailableFruits();
            var json = Serializer.AllFruitsToJson(fruits);
            var message = "UpdateAll" + json;

            await SendMessageAsync(message);
        }

        static async Task SendMessageAsync(string message)
        {
            Console.WriteLine($"[Server]: {message}");
            await WebSocketServer.CurrentConnection.SendAsync(message);
        }
    }
}
