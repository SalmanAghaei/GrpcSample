using Grpc.Net.Client;
using GrpClient;
using GrpcSample;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

var data = new HelloRequest { Name = "salman" };


//var client = new Greeter.GreeterClient(channel);
//var result=client.SayHello(data);

Grpc(1);
Grpc(2);
Grpc(3);
Grpc(4);
Grpc(5);

await Rest(1);
await Rest(2);
await Rest(3);
await Rest(4);
await Rest(5);

Console.ReadLine();

static void Grpc(int count)
{
    var channel = GrpcChannel.ForAddress("http://localhost:5144/");
    var client = new Customer.CustomerClient(channel);
    var stopWacth = Stopwatch.StartNew();
    var result = client.GetCustomers(new CustomerInput());
    var el1 = stopWacth.ElapsedMilliseconds;
    Console.WriteLine($"GrpcApi{count} Time:{el1}");

}

static async Task Rest(int count)
{
    var httpclient = new HttpClient();
    var avstopWacth2 = Stopwatch.StartNew();
    var res = await httpclient.GetStringAsync("http://localhost:5000/Customer");
    var data2 = JsonConvert.DeserializeObject(res);
    var el2 = avstopWacth2.ElapsedMilliseconds;
    Console.WriteLine($"RestApi{count} Time:{el2}");
}