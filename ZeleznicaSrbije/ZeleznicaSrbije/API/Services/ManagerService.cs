using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeleznicaSrbije.API.CRUD;
using ZeleznicaSrbije.API.Models;

namespace ZeleznicaSrbije.API.Services
{
    internal class ManagerService
    {
        ManagerCRUD managerCRUD;

        public ManagerService()
        {
            managerCRUD = new ManagerCRUD();
        }

        public Manager getManager(string email)
        {
            return managerCRUD.GetByEmail(email);

        }

    }
}
