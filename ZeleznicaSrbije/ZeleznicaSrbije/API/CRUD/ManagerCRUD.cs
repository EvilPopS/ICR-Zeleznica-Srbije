using ZeleznicaSrbije.API.Models;
using ZeleznicaSrbije.Database;
using ZeleznicaSrbije.Database.Repositories;

namespace ZeleznicaSrbije.API.CRUD {
    internal class ManagerCRUD {
        private readonly string FILE_PATH = AppSettings.databasePath + "managers.json";
        private readonly Repository<Manager> _managers;

        public ManagerCRUD() {
            _managers = FileReaderWriter.ReadFile<Manager>(FILE_PATH);
        }

        public Manager GetByEmail(string email) {
            foreach (var manager in _managers.Entities)
                if (manager.Email == email)
                    return manager;
            return null;
        }
    }
}
