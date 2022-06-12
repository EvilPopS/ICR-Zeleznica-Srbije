using System.Collections.Generic;

namespace ZeleznicaSrbije.API.Models {
    public class RegularUser {
		private int id;
		private string name;
		private string surname;
		private string email;
		private string password;
		private List<Ticket> tickets;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public List<Ticket> Tickets { get => tickets; set => tickets = value; }
    }
}
