using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopData;
using ShopLogic;
using ShopServerPresentation;
using WebSocketConnection = ShopData.WebSocketConnection;

//using WebSocketConnection = ShopServerPresentation.WebSocketConnection;

namespace IntegrationTest
{
    [TestClass]
    public class ClientServerTest
    {
        [TestMethod]
        public async Task ConnectionService()
        {
            List<string> logs = new List<string>();
            IConnectionService connService = ServiceFactory.CreateConnectionService;

            connService.ConnectionLogger += s => { logs.Add(s); };

            var task = Task.Run( async () => ShopServerPresentation.Program.CreateServer());

            await connService.Connect(new Uri("ws://localhost:8081/"));


            Assert.IsTrue(connService.Connected);
            await connService.Disconnect();
            await Task.Delay(10);
            
            task.Dispose();
            Assert.IsFalse(connService.Connected);
        }

        [TestMethod]
        public async Task WebSocketUsageTestMethod()
        {
            ShopServerPresentation.WebSocketConnection _wserver = null;
            ShopData.WebSocketConnection _wclient = null;
            const int _delay = 10;

            //create server
            Uri uri = new Uri("ws://localhost:6966");
            List<string> logOutput = new List<string>();
            Task server = Task.Run(async () => await WebSocketServer.Server(uri.Port,
                _ws =>
                {
                    _wserver = _ws;
                    Console.WriteLine("Connected with");
                    Console.WriteLine(_ws);
                    Console.WriteLine(_wserver);
                    Console.WriteLine(_wserver is null);
                    _wserver.onMessage = (data) =>
                    {
                        logOutput.Add($"Received message from client: { data}");
                    };
                }));

            await Task.Delay(_delay);

            _wclient = await WebSocketClient.Connect(uri, message => logOutput.Add(message));
            Console.WriteLine(_wserver);
            Console.WriteLine(_wserver is null);

            Assert.IsNotNull(_wclient);
            Assert.IsTrue(_wclient.IsConnected);

            Console.WriteLine(_wserver);
            Console.WriteLine(_wserver is null);
            Console.WriteLine(_wclient is null);

            Assert.IsNotNull(_wserver);


            Task clientSendTask = _wclient.SendAsync("test");
            Assert.IsTrue(clientSendTask.Wait(new TimeSpan(0, 0, 1)));
            await Task.Delay(_delay);


            Assert.AreEqual($"Received message from client: test", logOutput[0]);


            _wclient.onMessage = (data) =>
            {
                logOutput.Add($"Received message from server: { data}");
            };
            Task serverSendTask = _wserver.SendAsync("test 2");
            Assert.IsTrue(serverSendTask.Wait(new TimeSpan(0, 0, 1)));
            await Task.Delay(_delay);
            Assert.AreEqual($"Received message from server: test 2", logOutput[1]);
            await _wclient?.DisconnectAsync();
            await _wserver?.DisconnectAsync();
        }
    }
}
