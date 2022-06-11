using System.Collections.Generic;
using ZeleznicaSrbije.API.Models;
using ZeleznicaSrbije.Database;
using ZeleznicaSrbije.Database.Repositories;

namespace ZeleznicaSrbije.API.CRUD {
    internal class RegularUserCRUD {
        private readonly string FILE_PATH = AppSettings.databasePath + "regular_users.json";
        private Repository<RegularUser> _users;

        public RegularUserCRUD() {
            _users = FileReaderWriter.ReadFile<RegularUser>(FILE_PATH);
        }

        public RegularUser GetByEmail(string email) {
            foreach (var user in _users.Entities)
                if (user.Email == email)
                    return user;
            return null;
        }

        public void CreateNewUser(string name, string surname, string email, string password) {
            _users.AddEntity(
                new RegularUser() {
                    Id = _users.NextInd,
                    Name = name,
                    Surname = surname,
                    Email = email,
                    Password = password,
                    Tickets = new List<Ticket>()
                }
            );

            FileReaderWriter.UpdateFile(FILE_PATH, _users);
        }


    }
}
