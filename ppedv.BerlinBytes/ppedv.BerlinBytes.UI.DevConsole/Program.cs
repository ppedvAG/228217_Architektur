using ppedv.BerlinBytes.Logic.Core;
using ppedv.BerlinBytes.Model.Contracts;
using ppedv.BerlinBytes.Model.DomainModel;

Console.WriteLine("*** BerlinBytes v0.1 PREMIUM EDITION ***");

string conString = "Server=(localdb)\\mssqllocaldb;Database=BerlinBytes_Test;Trusted_Connection=true;";

IRepository repo = new ppedv.BerlinBytes.Data.Db.EfRepository(conString);
ComputerService cs = new ComputerService(repo);

foreach (var computer in repo.GetAll<Computer>())
{
    Console.WriteLine($"{computer.Name} {computer.OsVersion}");
}

Console.WriteLine("Alle mit unsupported Apps");

foreach (var computer in cs.GetComputersWithOutOfSupportAppsInstalled())
{
    Console.WriteLine($"{computer.Name} {computer.OsVersion}");
}


Console.WriteLine("Ende");
Console.ReadLine();
