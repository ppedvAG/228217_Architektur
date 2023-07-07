// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");




ServiceReference1.BLZServicePortTypeClient client = new ServiceReference1.BLZServicePortTypeClient("");

var result = client.getBankAsync("40050180").Result;
Console.WriteLine($"{result.bezeichnung}");