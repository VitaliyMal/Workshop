using Workshop.Core.Data;
using Workshop.Core.Data.Remote;
using Workshop.Core.Entity;
using Workshop.Core.Service;
using Workshop.Server.DTOs.CustomerDTOs;
using Workshop.Server.Entity;

//Customer cust= new Customer (1, "Ivan", "Voronin", "Tver", "VCT", "123S");
//Product prod = new Product(id:1,description:"map",price:100,production_time:360);
//Order order= new Order(orderId:1,state:State.ToDo);
//Ingredient ingredient= new Ingredient(id:1,amount:1, minimalAmount:1,cost:10,type:IngredientType.Clay);
//order.State = State.InProgress;
//Console.WriteLine(State.ToDo);
//Console.WriteLine(cust.ToString());



////Проверка сервисов заказчика
//CustomerService dataServiceCustomer = new CustomerService(new CustomerDataSource());

//Console.WriteLine("Start");
//Console.WriteLine(string.Join("\n", dataServiceCustomer.GetAll()));
//dataServiceCustomer.Create(new Customer("Ivan", "Voronin", "Tver", "VCT", "123S"));
//Console.WriteLine("Added Ivan");
//Console.WriteLine(string.Join("\n", dataServiceCustomer.GetAll()));

//dataServiceCustomer.Create(new Customer("Volodya", "Vunin", "Tver", "KSK", "13"));
//Console.WriteLine("Added Volodya");
//Console.WriteLine(string.Join("\n", dataServiceCustomer.GetAll()));

//dataServiceCustomer.Update(new Customer("Kiril", "Zaharov", "Tver", "KVS", "123S"));
//Console.WriteLine("Ivan Changed to Kiril");
//Console.WriteLine(string.Join("\n", dataServiceCustomer.GetAll()));

//dataServiceCustomer.Delete(1);
//Console.WriteLine("Deleted Volodya");
//Console.WriteLine(string.Join("\n", dataServiceCustomer.GetAll()));

//dataServiceCustomer.Delete(0);
//Console.WriteLine("Deleted Kiril");
//Console.WriteLine(string.Join("\n", dataServiceCustomer.GetAll()));


/////Проверка сервисов ингредиентов
//IngredientService dataServiceIngredient = new IngredientService(new IngredientDataSource());
//Console.WriteLine("Check ingredient");
//Console.WriteLine((string.Join("\n", dataServiceIngredient.GetAll())));
//dataServiceIngredient.Create(new Ingredient("Stone", 1, 1, 30, IngredientType.Clay));
//Console.WriteLine("Added Stone");
//Console.WriteLine(string.Join("\n", dataServiceIngredient.GetAll()));

//dataServiceIngredient.Create(new Ingredient("Leather", 2, 1, 15, IngredientType.Leather));
//Console.WriteLine("Added Leather");
//Console.WriteLine(string.Join("\n", dataServiceIngredient.GetAll()));

//dataServiceIngredient.Update(new Ingredient("Steel", 3, 2, 200, IngredientType.Metal));
//Console.WriteLine("Leather changed to Steel");
//Console.WriteLine(string.Join("\n", dataServiceIngredient.GetAll()));

//dataServiceIngredient.Delete(0);
//Console.WriteLine("Deletet Stone");
//Console.WriteLine(string.Join("\n", dataServiceIngredient.GetAll()));

//dataServiceIngredient.Delete(1);
//Console.WriteLine("Deleted Steel");
//Console.WriteLine(string.Join("\n", dataServiceIngredient.GetAll()));

////Проверка сервисов заказа
//OrderService dataServiceOrder = new OrderService(new OrderDataSource());
//Console.WriteLine("Check Orders");
//Console.WriteLine(string.Join("\n", dataServiceOrder.GetAll()));
//dataServiceOrder.Create(new Order(customerId: 0, State.InProgress));
//Console.WriteLine("Added Order n0");
//Console.WriteLine(string.Join("\n", dataServiceOrder.GetAll()));

//dataServiceOrder.Create(new Order(customerId: 1, State.Ready));
//Console.WriteLine("Added Order n1");
//Console.WriteLine(string.Join("\n", dataServiceOrder.GetAll()));

//dataServiceOrder.Update(new Order(customerId: 0, State.Canceled));
//Console.WriteLine("State changen from InProgress to Canceled");
//Console.WriteLine(string.Join("\n", dataServiceOrder.GetAll()));

//dataServiceOrder.Delete(0);
//Console.WriteLine("Deleted Order n0");
//Console.WriteLine(string.Join("\n", dataServiceOrder.GetAll()));

//dataServiceOrder.Delete(1);
//Console.WriteLine("Deleted Order n1");
//Console.WriteLine(string.Join("\n", dataServiceOrder.GetAll()));


////Проверка сервисов продукта
//ProductService dataServiceProduct = new ProductService(new ProductDataSource());
//Console.WriteLine("Check Product");
//Console.WriteLine(string.Join("\n", dataServiceProduct.GetAll()));
//dataServiceProduct.Create(new Product(name: "Rose", description: "Clay and Steel", price: 500, production_time: 360));
//Console.WriteLine("Added Rose");
//Console.WriteLine(string.Join("\n", dataServiceProduct.GetAll()));

//dataServiceProduct.Create(new Product(name: "Knife", description: "Knife with package", price: 900, production_time: 500));
//Console.WriteLine("Added Knife");
//Console.WriteLine(string.Join("\n", dataServiceProduct.GetAll()));

//dataServiceProduct.Update(new Product(name: "Knife", description: "Knife with package", price: 1200, production_time: 600));
//Console.WriteLine("In Knife changed price and prod time");
//Console.WriteLine(string.Join("\n", dataServiceProduct.GetAll()));

//dataServiceProduct.Delete(0);
//Console.WriteLine("Deleted product n0");
//Console.WriteLine(string.Join("\n", dataServiceProduct.GetAll()));

//dataServiceProduct.Delete(1);
//Console.WriteLine("Deleted product n1");
//Console.WriteLine(string.Join("\n", dataServiceProduct.GetAll()));

var customerDataSource = new CustomerRemoteDataSource();
var customers = await customerDataSource.GetCustomers();

Console.WriteLine(string.Join(" ", customers));

if (customers.Count > 0)
    Console.WriteLine(await customerDataSource.GetCustomer(customers.First().Id));


await customerDataSource.PostCustomer(new AddCustomerDTO(
    "Test_customer",
    "qq",
    "q",
    "qqqqqq",
    "pasqqqqs"
    ));


customers = await customerDataSource.GetCustomers();
Console.WriteLine(string.Join(" ", customers));


await customerDataSource.UpdateCustomer(new UpgradeCustomerDTO(
    "Test_customer222",
    "qq",
    "q",
    "qqqqq",
    "passq"
    ));


customers = await customerDataSource.GetCustomers();
Console.WriteLine(string.Join(" ", customers));



await customerDataSource.DeleteCustomer(customers.Last().Id);

customers = await customerDataSource.GetCustomers();
Console.WriteLine(string.Join(" ", customers));