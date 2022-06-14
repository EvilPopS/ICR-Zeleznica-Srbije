using ZeleznicaSrbije.API.CRUD;
using ZeleznicaSrbije.API.Models;

namespace ZeleznicaSrbije.API.Services {
    public class RegularUserService {
        private readonly RegularUserCRUD _userCRUD;

        public RegularUserService() {
            _userCRUD = new RegularUserCRUD();
        }

        public RegularUser GetUserByEmail(string email) {
            return _userCRUD.GetByEmail(email);
        }


    }
}
