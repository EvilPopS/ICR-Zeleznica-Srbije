using ZeleznicaSrbije.API.CRUD;
using ZeleznicaSrbije.API.Models;

namespace ZeleznicaSrbije.API.Services {
    public class ManagerService
    {
        private readonly ManagerCRUD _managerCRUD;

        public ManagerService()
        {
            _managerCRUD = new ManagerCRUD();
        }

        public Manager getManager(string email)
        {
            return _managerCRUD.GetByEmail(email);

        }

    }
}
