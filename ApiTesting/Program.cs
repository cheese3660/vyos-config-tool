// See https://aka.ms/new-console-template for more information

using VyosConfigLibrary.Network;

var apiKey = args[0];

var handler = new HttpClientHandler
{
    ClientCertificateOptions = ClientCertificateOption.Manual,
    ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
};

using VyosClient client = new(new Uri("https://10.101.0.1"), apiKey: apiKey, handler: handler);

var info = await client.GetVyosInformationAsync();
Console.WriteLine($"Vyos Version: {info.Version}");
Console.WriteLine($"Hostname:     {info.Hostname}");
Console.WriteLine($"Banner:       {info.Banner}");


var info2 = await client.RetrieveVyosConfigAsync();
Console.WriteLine(info2);