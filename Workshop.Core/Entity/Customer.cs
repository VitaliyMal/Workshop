using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop.Core.Entity
{
    /// <summary>
    /// Заказчик
    /// </summary>

    public class Customer(int id, string name = "", string lastName = "", string adress = "", string login = "", string password = "")
    {
        public int Id { get; set; } = id;
        public string Name { get; set; } = name;
        public string LastName { get; set; } = lastName;
        public string Adress { get; set; } = adress;
        public string Login { get; set; } = login;
        public string Password { get; set; } = password;

        public override string ToString()
        {
            return string.Join(",", Convert.ToString(Id), Name, LastName, Adress, Login, Password);
        }
    }
}
