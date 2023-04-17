using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.WebSockets;

namespace lab1 {
    public class WebSocketHandler : IHttpHandler {
        public bool IsReusable => false;

        private WebSocket socket;

        public void ProcessRequest(HttpContext context) {
            if(context.IsWebSocketRequest) {
                context.AcceptWebSocketRequest(ProcessWebSocket);
            }
        }

        private async Task ProcessWebSocket(AspNetWebSocketContext context) {
            socket = context.WebSocket;
            await Send(await Recieve());
            int i = 0;
            while(socket.State == WebSocketState.Open) {
                await Send(DateTime.Now.ToString("HH:mm:ss"));
                Thread.Sleep(2000);
            }
        }

        private async Task Send(string text) {
            await socket.SendAsync(new ArraySegment<byte>(Encoding.UTF8.GetBytes( text )), WebSocketMessageType.Text, true, CancellationToken.None);
        }

        private async Task<string> Recieve() {
            ArraySegment<byte> buffer = new ArraySegment<byte>(new byte[512]);
            WebSocketReceiveResult result = await socket.ReceiveAsync(buffer, CancellationToken.None);
            return Encoding.UTF8.GetString(buffer.Array,0, result.Count);
        }
    }
}