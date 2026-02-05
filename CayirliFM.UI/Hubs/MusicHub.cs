using Microsoft.AspNetCore.SignalR;

namespace CayirliFM.UI.Hubs
{
    public class MusicHub : Hub
    {
        private static bool isStreaming = false;

        public async Task StartStreaming(string filePath)
        {
            if (isStreaming) return;

            isStreaming = true;

            var fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot" + filePath);
            if (!File.Exists(fullPath))
            {
                await Clients.Caller.SendAsync("Error", "Dosya Bulunamadı.");
                isStreaming = false;
                return;
            }

            byte[] buffer = new byte[16 * 1024];
            using (var stream = new FileStream(fullPath, FileMode.Open, FileAccess.Read))
            {
                int byteReads;
                while ((byteReads = stream.Read(buffer, 0, buffer.Length)) > 0 && isStreaming)
                {
                    var chunk = Convert.ToBase64String(buffer, 0, byteReads);
                    await Clients.All.SendAsync("RecieveMusicChunk", chunk);

                    await Task.Delay(50);
                }
            }

            isStreaming = false;
            await Clients.All.SendAsync("Akış Tamamlandı");
        }

        public Task StopStreaming()
        {
            isStreaming = false;
            return Task.CompletedTask;
        }
    }
}
