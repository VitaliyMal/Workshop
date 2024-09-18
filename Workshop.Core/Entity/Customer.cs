using Newtonsoft.Json;

namespace Workshop.Core.Entity
{
    /// <summary>
    /// Заказчик
    /// </summary>

    public class Customer
    {
        public Customer(string name = "", string lastName = "", string adress = "", string login = "", string password = "")
        {
            Id = _idCounter++;
            Name = name;
            LastName = lastName;
            Adress = adress;
            Login = login;
            Password = password;
        }

        public Customer()
        {
            Id = _idCounter++;
            Name = "no_name";
            LastName = "no_lastName";
            Adress = "no_adress";
            Login = "no_login";
            Password = "no_password";
        }
        public static int _idCounter = 1;

        [JsonProperty("Id")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Adress { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public override string ToString()
        {
            return string.Join(",", Convert.ToString(Id), Name, LastName, Adress, Login, Password);
        }
    }
}
