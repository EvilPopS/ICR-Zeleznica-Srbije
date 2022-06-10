using ZeleznicaSrbije.API.CRUD;
using ZeleznicaSrbije.API.Models;

namespace ZeleznicaSrbije.API.Services {
    internal class LoginRegisterService {
        private ManagerCRUD _managerCRUD;
        private  RegularUserCRUD _regularUserCRUD;

        public LoginRegisterService() {
            _managerCRUD = new ManagerCRUD();
            _regularUserCRUD = new RegularUserCRUD();
        }

        public bool TryLoginAsManager(string email, string password) {
            Manager manager = _managerCRUD.GetByEmail(email);
            if (manager != null && manager.Password == password)
                return true;
             return false;
        }

        public bool TryLoginAsRegularUser(string email, string password) {
            RegularUser user = _regularUserCRUD.GetByEmail(email);
            if (user != null && user.Password == password)
                return true;
            return false;
        }

        public bool RegisterNewUser(string name, string surname, string email, string password) {
            if (_regularUserCRUD.GetByEmail(email) != null)
                return false;

            _regularUserCRUD.CreateNewUser(name, surname, email, password);
            return true;
        }
    }
}
