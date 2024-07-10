using Workshop.Core.Entity;
using Workshop.Core.Service;
using Workshop.Core.Data;
using Workshop.Core;

//Customer cust= new Customer (1, "Ivan", "Voronin", "Tver", "VCT", "123S");
//Product prod = new Product(id:1,description:"map",price:100,production_time:360);
//Order order= new Order(orderId:1,state:State.ToDo);
//Ingredient ingredient= new Ingredient(id:1,amount:1, minimalAmount:1,cost:10,type:IngredientType.Clay);
//order.State = State.InProgress;
//Console.WriteLine(State.ToDo);
//Console.WriteLine(cust.ToString());


//Реализовать
//CinemaDataSource cinemaDataSource = new CinemaDataSource();
////Записываем список в файл
//cinemaDataSource.Write(cinemas);
////Считываем список из файла и выводим на экран
//Console.WriteLine(string.Join(" ", cinemaDataSource.Get()));


CustomerService dataService = new CustomerService(new CustomerDataSource());

Console.WriteLine("Start");
Console.WriteLine(string.Join("\n", dataService.GetAll()));
dataService.Create(new Customer(0, "Ivan", "Voronin", "Tver", "VCT", "123S"));
Console.WriteLine("Added Ivan");
Console.WriteLine(string.Join("\n", dataService.GetAll()));

dataService.Create(new Customer(1, "Volodya", "Vunin", "Tver", "KSK", "13"));
Console.WriteLine("Added Volodya");
Console.WriteLine(string.Join("\n", dataService.GetAll()));

dataService.Update(new Customer(0, "Kiril", "Zaharov", "Tver", "KVS", "123S"));
Console.WriteLine("Ivan Changed to Kiril");
Console.WriteLine(string.Join("\n", dataService.GetAll()));

dataService.Delete(1);
Console.WriteLine("Deleted Volodya");
Console.WriteLine(string.Join("\n", dataService.GetAll()));

dataService.Delete(0);
Console.WriteLine("Deleted Kiril");
Console.WriteLine(string.Join("\n", dataService.GetAll()));