﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeleznicaSrbije.API.Models;
using ZeleznicaSrbije.Database;
using ZeleznicaSrbije.Database.Repositories;

namespace ZeleznicaSrbije.API.CRUD {
    internal class RegularUserCRUD {
        private readonly string FILE_PATH = AppSettings.databasePath + "regular_users.json";
        private Repository<RegularUser> users;

        public RegularUserCRUD() {
            users = FileReaderWriter.ReadFile<RegularUser>(FILE_PATH);
        }
    }
}