// See https://aka.ms/new-console-template for more information
using HalloBuilder;

Console.WriteLine("Hello Builder!");


var s1 = new Schrank.Builder()
    .SetTüren(5)
    .SetBöden(5)
    .Build();

