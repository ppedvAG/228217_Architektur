using HalloDeko;

Console.WriteLine("Hello, World!");

var p1 = new Käse( new Brot());

Console.WriteLine($"{p1.Name} {p1.Price:c}");

var p2 = new Salami(new Käse(new Käse( new Pizza())));
Console.WriteLine($"{p2.Name} {p2.Price:c}");
