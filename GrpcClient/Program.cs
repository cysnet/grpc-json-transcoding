using Grpc.Net.Client;
using GrpcServiceClient;

namespace GrpcClient
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:7167");
            var client = new Greeter.GreeterClient(channel);
            var reply = await client.SayHelloAsync(new HelloRequest { Name = "GreeterClient" });
            Console.WriteLine("Greeting: " + reply.Message);

            var replyPost = await client.SayHelloPostAsync(new HelloRequestPost { Data = new HelloRequestPostData { Name = "111" } });
            Console.WriteLine("Greeting: " + replyPost.Message);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}