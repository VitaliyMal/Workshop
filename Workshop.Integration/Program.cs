// See https://aka.ms/new-console-template for more information
using Workshop.Core;

Console.WriteLine("Hello, World!");

Product prod= new Product(1);
Order order= new Order();

order.State = State.InProgress;
Console.WriteLine(State.ToDo);

Customer cust= new Customer (1, "Ivan", "Voronin", "Tver", "VCT", "123S");

Console.WriteLine(cust.ToString());

