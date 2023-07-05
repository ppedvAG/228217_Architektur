using Autofac;
using Autofac.Builder;
using ppedv.BerlinBytes.Data.Db;
using ppedv.BerlinBytes.Logic.Core;
using ppedv.BerlinBytes.Model.Contracts;
using ppedv.BerlinBytes.Model.DomainModel;
using System.Reflection;

Console.WriteLine("*** BerlinBytes v0.1 PREMIUM EDITION ***");

string conString = "Server=(localdb)\\mssqllocaldb;Database=BerlinBytes_Test;Trusted_Connection=true;";

//Di per Reflection
//var filePath = @"C:\Users\ar2\source\repos\ppedvAG\228217_Architektur\ppedv.BerlinBytes\ppedv.BerlinBytes.Data.Db\bin\Debug\net7.0\ppedv.BerlinBytes.Data.Db.dll";
//var ass = Assembly.LoadFrom(filePath);
//var typeMitRepo = ass.GetTypes().FirstOrDefault(x => x.GetInterfaces().Contains(typeof(IRepository)));
//IRepository repo = Activator.CreateInstance(typeMitRepo,conString) as IRepository;

//Di per AutoFac
var containerBuilder = new ContainerBuilder();
containerBuilder.Register<EfRepository>(x => new EfRepository(conString)).AsImplementedInterfaces();
var container = containerBuilder.Build();

IRepository repo = container.Resolve<IRepository>();

//'Di' per code und reference
//IRepository repo = new ppedv.BerlinBytes.Data.Db.EfRepository(conString);
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
