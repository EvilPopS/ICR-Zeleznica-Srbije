using ZeleznicaSrbije.API.Models;
using ZeleznicaSrbije.Database;
using ZeleznicaSrbije.Database.Repositories;

namespace ZeleznicaSrbije.API.CRUD {
    internal class ManagerCRUD {
        private readonly string FILE_PATH = AppSettings.databasePath + "managers.json";
        private Repository<Manager> managers;

        public ManagerCRUD() {
            managers = FileReaderWriter.ReadFile<Manager>(FILE_PATH);
        }
    }
}
